using HuongViet.DAL;
using HuongViet.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HuongViet.BLL
{
    /// <summary>
    /// Business Logic Layer cho hệ thống POS (Point of Sale)
    /// </summary>
    public class POSBLL
    {
        private readonly TableBLL tableBLL;
        private readonly AreaBLL areaBLL;
        private readonly ItemBLL itemBLL;
        private readonly OrderBLL orderBLL;
        private readonly CustomerBLL customerBLL;
        private readonly OrderDAL orderDAL;

        public POSBLL()
        {
            tableBLL = new TableBLL();
            areaBLL = new AreaBLL();
            itemBLL = new ItemBLL();
            orderBLL = new OrderBLL();
            customerBLL = new CustomerBLL();
            orderDAL = new OrderDAL();
        }

        /// <summary>
        /// Lấy tất cả khu vực
        /// </summary>
        public List<Area> GetAllAreas()
        {
            try
            {
                return areaBLL.GetAllAreas();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách khu vực: {ex.Message}");
            }
        }

        /// <summary>
        /// Lấy tất cả bàn, có thể filter theo khu vực
        /// </summary>
        public List<Table> GetAllTables(string areaId = null)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(areaId))
                {
                    return tableBLL.GetAllTables();
                }
                else
                {
                    return tableBLL.GetTablesByArea(areaId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách bàn: {ex.Message}");
            }
        }

        /// <summary>
        /// Lấy thông tin bàn kèm đơn hàng đang active
        /// </summary>
        public TableInfo GetTableInfo(string tableId)
        {
            try
            {
                var table = tableBLL.GetTableById(tableId);
                if (table == null)
                {
                    return null;
                }

                var tableInfo = new TableInfo
                {
                    Table = table,
                    CurrentOrder = null,
                    OrderDetails = new List<OrderDetail>(),
                    TotalAmount = 0,
                    Duration = TimeSpan.Zero
                };

                // Lấy đơn hàng đang active của bàn
                if (!string.IsNullOrWhiteSpace(table.CurrentOrderID))
                {
                    var order = orderBLL.GetById(table.CurrentOrderID, true);
                    if (order != null && order.OrderStatus != OrderStatus.Completed && 
                        order.OrderStatus != OrderStatus.Cancelled)
                    {
                        tableInfo.CurrentOrder = order;
                        tableInfo.OrderDetails = order.OrderDetails?.ToList() ?? new List<OrderDetail>();
                        tableInfo.TotalAmount = order.TotalAmount;
                        
                        // Tính thời gian đã sử dụng
                        tableInfo.Duration = DateTime.Now - order.OrderTime;
                    }
                }

                return tableInfo;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy thông tin bàn: {ex.Message}");
            }
        }

        /// <summary>
        /// Lấy tất cả items (dịch vụ, thức ăn, nước uống), có thể filter theo loại
        /// </summary>
        public List<Item> GetAllItems(ItemType? itemType = null)
        {
            try
            {
                if (itemType.HasValue)
                {
                    return itemBLL.GetByType(itemType.Value);
                }
                else
                {
                    return itemBLL.GetActiveItems();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách món: {ex.Message}");
            }
        }

        /// <summary>
        /// Tìm kiếm khách hàng theo số điện thoại hoặc tên
        /// </summary>
        public Customer SearchCustomer(string searchTerm)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(searchTerm))
                {
                    return null;
                }

                // Tìm theo số điện thoại trước
                var customer = customerBLL.GetByPhoneNumber(searchTerm);
                if (customer != null)
                {
                    return customer;
                }

                // Nếu không tìm thấy, tìm theo tên
                var customers = customerBLL.SearchByName(searchTerm);
                return customers.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tìm kiếm khách hàng: {ex.Message}");
            }
        }

        /// <summary>
        /// Tạo hoặc cập nhật đơn hàng cho bàn
        /// </summary>
        public Order CreateOrUpdateTableOrder(string tableId, string customerName, string customerPhone, 
            string staffId, List<OrderDetail> orderDetails, string customerId = null, FormOfService formOfService = FormOfService.DineIn)
        {
            try
            {
                var table = tableBLL.GetTableById(tableId);
                if (table == null)
                {
                    throw new Exception("Bàn không tồn tại");
                }

                Order order = null;

                // Kiểm tra xem bàn đã có đơn hàng đang active chưa
                if (!string.IsNullOrWhiteSpace(table.CurrentOrderID))
                {
                    order = orderBLL.GetById(table.CurrentOrderID, true);
                    if (order != null && order.OrderStatus != OrderStatus.Completed && 
                        order.OrderStatus != OrderStatus.Cancelled)
                    {
                        // Cập nhật đơn hàng hiện có
                        // Xóa order details cũ và thêm mới
                        DeleteOrderDetails(order.OrderID);
                        
                        // Set OrderID cho tất cả details mới
                        foreach (var detail in orderDetails)
                        {
                            detail.OrderID = order.OrderID;
                        }
                        
                        // Thêm order details mới
                        InsertOrderDetails(order.OrderID, orderDetails);
                        
                        // Cập nhật thông tin đơn hàng
                        order.OrderDetails = orderDetails;
                        order.TotalAmount = CalculateTotalAmount(orderDetails);
                        order.CustomerName = customerName;
                        order.CustomerPhone = customerPhone;
                        order.CustomerID = customerId;
                        order.FormOfService = formOfService;
                        order.UpdatedAt = DateTime.Now;

                        orderBLL.Update(order);
                        
                        // Đảm bảo bàn có CurrentOrderID và trạng thái đúng
                        if (table.CurrentOrderID != order.OrderID || table.TableStatus != TableStatus.Occupied)
                        {
                            table.CurrentOrderID = order.OrderID;
                            table.TableStatus = TableStatus.Occupied;
                            table.UpdatedAt = DateTime.Now;
                            tableBLL.Update(table);
                        }
                        
                        return order;
                    }
                }

                // Tạo đơn hàng mới
                order = new Order
                {
                    OrderID = orderBLL.GenerateNewOrderID(),
                    OrderDate = DateTime.Now,
                    OrderTime = DateTime.Now,
                    OrderStatus = OrderStatus.Pending,
                    FormOfService = formOfService,
                    CustomerID = customerId,
                    CustomerName = customerName,
                    CustomerPhone = customerPhone,
                    TableID = tableId,
                    StaffID = staffId,
                    OrderDetails = orderDetails,
                    TotalAmount = CalculateTotalAmount(orderDetails),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                // Set OrderID cho tất cả details
                foreach (var detail in orderDetails)
                {
                    detail.OrderID = order.OrderID;
                }

                if (orderBLL.Insert(order))
                {
                    // Cập nhật CurrentOrderID và trạng thái của bàn
                    table.CurrentOrderID = order.OrderID;
                    table.TableStatus = TableStatus.Occupied;
                    table.UpdatedAt = DateTime.Now;
                    tableBLL.Update(table);
                    return order;
                }

                throw new Exception("Không thể tạo đơn hàng");
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tạo/cập nhật đơn hàng: {ex.Message}");
            }
        }

        /// <summary>
        /// Cập nhật tổng tiền đơn hàng (tổng của tất cả order details)
        /// </summary>
        public bool UpdateOrderTotalAmount(string orderId)
        {
            try
            {
                var order = orderBLL.GetById(orderId, true);
                if (order == null)
                {
                    throw new Exception("Đơn hàng không tồn tại");
                }

                if (order.OrderDetails == null || order.OrderDetails.Count == 0)
                {
                    throw new Exception("Đơn hàng không có chi tiết");
                }

                // Calculate grand total (sum of all order details)
                decimal grandTotal = order.OrderDetails.Sum(d => d.TotalAmount);

                // Update order TotalAmount
                order.TotalAmount = grandTotal;
                order.UpdatedAt = DateTime.Now;
                orderBLL.Update(order);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật tổng tiền đơn hàng: {ex.Message}");
            }
        }

        /// <summary>
        /// Áp dụng voucher discount vào đơn hàng
        /// </summary>
        public bool ApplyVoucherDiscount(string orderId, decimal discountPercentage)
        {
            try
            {
                var order = orderBLL.GetById(orderId, true);
                if (order == null)
                {
                    throw new Exception("Đơn hàng không tồn tại");
                }

                if (order.OrderDetails == null || order.OrderDetails.Count == 0)
                {
                    throw new Exception("Đơn hàng không có chi tiết");
                }

                // Apply discount percentage to each order detail
                foreach (var detail in order.OrderDetails)
                {
                    detail.Discount = discountPercentage;
                    // Recalculate TotalAmount with discount
                    decimal discountAmount = detail.UnitPrice * detail.Quantity * (discountPercentage / 100);
                    detail.TotalAmount = (detail.UnitPrice * detail.Quantity) - discountAmount;
                }

                // Calculate grand total (sum of all order details after discount)
                decimal grandTotal = order.OrderDetails.Sum(d => d.TotalAmount);

                // Delete old order details and insert new ones with discount
                DeleteOrderDetails(orderId);
                InsertOrderDetails(orderId, order.OrderDetails.ToList());

                // Update order TotalAmount with grand total
                order.TotalAmount = grandTotal;
                order.UpdatedAt = DateTime.Now;
                orderBLL.Update(order);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi áp dụng voucher: {ex.Message}");
            }
        }

        /// <summary>
        /// Thanh toán đơn hàng
        /// </summary>
        public bool ProcessPayment(string orderId, PaymentMethod paymentMethod, string staffId)
        {
            try
            {
                var order = orderBLL.GetById(orderId, false);
                if (order == null)
                {
                    throw new Exception("Đơn hàng không tồn tại");
                }

                // Cập nhật phương thức thanh toán và trạng thái
                order.PaymentMethod = paymentMethod;
                order.OrderStatus = OrderStatus.Completed;
                order.UpdatedAt = DateTime.Now;

                if (orderBLL.Update(order))
                {
                    // Cập nhật trạng thái bàn về Available và xóa CurrentOrderID
                    if (!string.IsNullOrWhiteSpace(order.TableID))
                    {
                        var table = tableBLL.GetTableById(order.TableID);
                        if (table != null)
                        {
                            table.CurrentOrderID = null;
                            table.TableStatus = TableStatus.Available;
                            table.UpdatedAt = DateTime.Now;
                            tableBLL.Update(table);
                        }
                    }

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thanh toán: {ex.Message}");
            }
        }

        /// <summary>
        /// Tính tổng tiền từ danh sách order details
        /// </summary>
        private decimal CalculateTotalAmount(List<OrderDetail> orderDetails)
        {
            if (orderDetails == null || orderDetails.Count == 0)
            {
                return 0;
            }

            return orderDetails.Sum(d => d.TotalAmount);
        }

        /// <summary>
        /// Cập nhật trạng thái bàn
        /// </summary>
        public bool UpdateTableStatus(string tableId, TableStatus status)
        {
            try
            {
                return tableBLL.UpdateTableStatus(tableId, status);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật trạng thái bàn: {ex.Message}");
            }
        }

        /// <summary>
        /// Xóa tất cả order details của một đơn hàng
        /// </summary>
        private void DeleteOrderDetails(string orderId)
        {
            try
            {
                orderDAL.DeleteOrderDetails(orderId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa order details: {ex.Message}");
            }
        }

        /// <summary>
        /// Thêm order details vào database
        /// </summary>
        private void InsertOrderDetails(string orderId, List<OrderDetail> orderDetails)
        {
            try
            {
                orderDAL.InsertOrderDetails(orderId, orderDetails);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm order details: {ex.Message}");
            }
        }
    }

    /// <summary>
    /// Class chứa thông tin bàn kèm đơn hàng
    /// </summary>
    public class TableInfo
    {
        public Table Table { get; set; }
        public Order CurrentOrder { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public decimal TotalAmount { get; set; }
        public TimeSpan Duration { get; set; }
    }
}

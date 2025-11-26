using HuongViet.DAL;
using HuongViet.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HuongViet.BLL
{
    public class OrderBLL
    {
        private readonly OrderDAL orderDAL;
        private readonly CustomerDAL customerDAL;
        private readonly ItemDAL itemDAL;
        private readonly UserDAL userDAL;
        private readonly TableDAL tableDAL;
        private readonly RoomDAL roomDAL;
        private readonly AccumulatedPointsDAL pointsDAL;

        public OrderBLL()
        {
            this.orderDAL = new OrderDAL();
            this.customerDAL = new CustomerDAL();
            this.itemDAL = new ItemDAL();
            this.userDAL = new UserDAL();
            this.tableDAL = new TableDAL();
            this.roomDAL = new RoomDAL();
            this.pointsDAL = new AccumulatedPointsDAL();
        }

        public List<Order> GetAll()
        {
            try
            {
                return orderDAL.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách đơn hàng: {ex.Message}");
            }
        }

        public Order GetById(string id, bool loadDetails = true)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id))
                {
                    throw new ArgumentException("Mã đơn hàng không được để trống");
                }

                return orderDAL.GetById(id, loadDetails);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy thông tin đơn hàng: {ex.Message}");
            }
        }

        public List<Order> GetByCustomer(string customerId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(customerId))
                {
                    throw new ArgumentException("Mã khách hàng không được để trống");
                }

                return orderDAL.GetByCustomer(customerId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy đơn hàng theo khách hàng: {ex.Message}");
            }
        }

        public List<Order> GetByStatus(OrderStatus status)
        {
            try
            {
                return orderDAL.GetByStatus(status);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy đơn hàng theo trạng thái: {ex.Message}");
            }
        }

        public List<Order> GetByDateRange(DateTime fromDate, DateTime toDate)
        {
            try
            {
                if (fromDate > toDate)
                {
                    throw new ArgumentException("Ngày bắt đầu không được lớn hơn ngày kết thúc");
                }

                return orderDAL.GetByDateRange(fromDate, toDate);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy đơn hàng theo khoảng thời gian: {ex.Message}");
            }
        }

        public bool Insert(Order order)
        {
            try
            {
                ValidateOrder(order);

                // Check if ID already exists
                if (orderDAL.Exists(order.OrderID))
                {
                    throw new Exception("Mã đơn hàng đã tồn tại");
                }

                // Validate staff exists
                if (!userDAL.Exists(order.StaffID))
                {
                    throw new Exception("Nhân viên không tồn tại");
                }

                // Validate customer if provided
                if (!string.IsNullOrEmpty(order.CustomerID))
                {
                    if (!customerDAL.Exists(order.CustomerID))
                    {
                        throw new Exception("Khách hàng không tồn tại");
                    }
                }

                // Validate table if provided
                if (!string.IsNullOrEmpty(order.TableID))
                {
                    if (!tableDAL.Exists(order.TableID))
                    {
                        throw new Exception("Bàn không tồn tại");
                    }
                }

                // Validate room if provided
                if (!string.IsNullOrEmpty(order.RoomID))
                {
                    if (!roomDAL.Exists(order.RoomID))
                    {
                        throw new Exception("Phòng không tồn tại");
                    }
                }

                // Validate order details
                if (order.OrderDetails != null && order.OrderDetails.Count > 0)
                {
                    ValidateOrderDetails(order.OrderDetails);
                    
                    // Calculate total amount
                    order.TotalAmount = CalculateTotalAmount(order.OrderDetails);
                }

                bool result = orderDAL.Insert(order);

                // Add points for customer if order is completed and customer exists
                if (result && order.OrderStatus == OrderStatus.Completed && !string.IsNullOrEmpty(order.CustomerID))
                {
                    AddPointsForOrder(order.CustomerID, order.TotalAmount);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm đơn hàng: {ex.Message}");
            }
        }

        public bool Update(Order order)
        {
            try
            {
                ValidateOrder(order);

                // Check if order exists
                if (!orderDAL.Exists(order.OrderID))
                {
                    throw new Exception("Đơn hàng không tồn tại");
                }

                // Get current order to check status change
                var currentOrder = orderDAL.GetById(order.OrderID, false);
                bool statusChanged = currentOrder != null && currentOrder.OrderStatus != order.OrderStatus;

                // Validate staff exists
                if (!userDAL.Exists(order.StaffID))
                {
                    throw new Exception("Nhân viên không tồn tại");
                }

                // Validate customer if provided
                if (!string.IsNullOrEmpty(order.CustomerID))
                {
                    if (!customerDAL.Exists(order.CustomerID))
                    {
                        throw new Exception("Khách hàng không tồn tại");
                    }
                }

                // Validate table if provided
                if (!string.IsNullOrEmpty(order.TableID))
                {
                    if (!tableDAL.Exists(order.TableID))
                    {
                        throw new Exception("Bàn không tồn tại");
                    }
                }

                // Validate room if provided
                if (!string.IsNullOrEmpty(order.RoomID))
                {
                    if (!roomDAL.Exists(order.RoomID))
                    {
                        throw new Exception("Phòng không tồn tại");
                    }
                }

                bool result = orderDAL.Update(order);

                // Add points if status changed to completed and customer exists
                if (result && statusChanged && order.OrderStatus == OrderStatus.Completed && 
                    !string.IsNullOrEmpty(order.CustomerID) && currentOrder.OrderStatus != OrderStatus.Completed)
                {
                    AddPointsForOrder(order.CustomerID, order.TotalAmount);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật đơn hàng: {ex.Message}");
            }
        }

        public bool UpdateStatus(string orderId, OrderStatus status)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(orderId))
                {
                    throw new ArgumentException("Mã đơn hàng không được để trống");
                }

                if (!orderDAL.Exists(orderId))
                {
                    throw new Exception("Đơn hàng không tồn tại");
                }

                // Get current order to check status change
                var currentOrder = orderDAL.GetById(orderId, false);
                bool statusChanged = currentOrder != null && currentOrder.OrderStatus != status;

                bool result = orderDAL.UpdateStatus(orderId, status);

                // Add points if status changed to completed and customer exists
                if (result && statusChanged && status == OrderStatus.Completed && 
                    !string.IsNullOrEmpty(currentOrder.CustomerID) && currentOrder.OrderStatus != OrderStatus.Completed)
                {
                    AddPointsForOrder(currentOrder.CustomerID, currentOrder.TotalAmount);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật trạng thái đơn hàng: {ex.Message}");
            }
        }

        public bool Delete(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id))
                {
                    throw new ArgumentException("Mã đơn hàng không được để trống");
                }

                if (!orderDAL.Exists(id))
                {
                    throw new Exception("Đơn hàng không tồn tại");
                }

                return orderDAL.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa đơn hàng: {ex.Message}");
            }
        }

        public bool Exists(string id)
        {
            try
            {
                return orderDAL.Exists(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi kiểm tra đơn hàng: {ex.Message}");
            }
        }

        public string GenerateNewOrderID()
        {
            try
            {
                var orders = orderDAL.GetAll();
                int maxNumber = 0;

                foreach (var order in orders)
                {
                    if (order.OrderID.StartsWith("ORD"))
                    {
                        string numberPart = order.OrderID.Substring(3);
                        if (int.TryParse(numberPart, out int number))
                        {
                            maxNumber = Math.Max(maxNumber, number);
                        }
                    }
                }

                return $"ORD{(maxNumber + 1).ToString("D6")}";
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tạo mã đơn hàng: {ex.Message}");
            }
        }

        public PagedResult<Order> SearchOrders(SearchCriteria criteria, OrderStatus? status = null, 
            DateTime? fromDate = null, DateTime? toDate = null, string customerId = null)
        {
            try
            {
                if (criteria == null)
                {
                    criteria = new SearchCriteria
                    {
                        PageNumber = 1,
                        PageSize = 20
                    };
                }

                // Validate page number
                if (criteria.PageNumber < 1)
                {
                    criteria.PageNumber = 1;
                }

                // Validate page size
                if (criteria.PageSize < 1)
                {
                    criteria.PageSize = 20;
                }

                // Validate date range
                if (fromDate.HasValue && toDate.HasValue && fromDate.Value > toDate.Value)
                {
                    throw new ArgumentException("Ngày bắt đầu không được lớn hơn ngày kết thúc");
                }

                return orderDAL.SearchOrders(criteria, status, fromDate, toDate, customerId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tìm kiếm đơn hàng: {ex.Message}");
            }
        }

        public List<OrderDetail> GetOrderDetails(string orderId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(orderId))
                {
                    throw new ArgumentException("Mã đơn hàng không được để trống");
                }

                return orderDAL.GetOrderDetails(orderId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy chi tiết đơn hàng: {ex.Message}");
            }
        }

        private void ValidateOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order), "Thông tin đơn hàng không được null");
            }

            if (string.IsNullOrWhiteSpace(order.OrderID))
            {
                throw new ArgumentException("Mã đơn hàng không được để trống");
            }

            if (string.IsNullOrWhiteSpace(order.CustomerName))
            {
                throw new ArgumentException("Tên khách hàng không được để trống");
            }

            if (order.CustomerName.Length > 50)
            {
                throw new ArgumentException("Tên khách hàng không được vượt quá 50 ký tự");
            }

            if (string.IsNullOrWhiteSpace(order.CustomerPhone))
            {
                throw new ArgumentException("Số điện thoại khách hàng không được để trống");
            }

            if (order.CustomerPhone.Length > 15)
            {
                throw new ArgumentException("Số điện thoại không được vượt quá 15 ký tự");
            }

            if (string.IsNullOrWhiteSpace(order.StaffID))
            {
                throw new ArgumentException("Nhân viên phục vụ không được để trống");
            }

            if (!string.IsNullOrWhiteSpace(order.OrderNote) && order.OrderNote.Length > 200)
            {
                throw new ArgumentException("Ghi chú đơn hàng không được vượt quá 200 ký tự");
            }

            if (order.TotalAmount < 0)
            {
                throw new ArgumentException("Tổng tiền không được âm");
            }

            if (order.OrderDate > DateTime.Now.AddDays(1))
            {
                throw new ArgumentException("Ngày đặt hàng không được lớn hơn ngày hiện tại");
            }
        }

        private void ValidateOrderDetails(ICollection<OrderDetail> orderDetails)
        {
            if (orderDetails == null || orderDetails.Count == 0)
            {
                throw new ArgumentException("Chi tiết đơn hàng không được để trống");
            }

            foreach (var detail in orderDetails)
            {
                if (string.IsNullOrWhiteSpace(detail.ItemID))
                {
                    throw new ArgumentException("Mã món ăn không được để trống");
                }

                if (!itemDAL.Exists(detail.ItemID))
                {
                    throw new Exception($"Món ăn {detail.ItemID} không tồn tại");
                }

                if (detail.Quantity <= 0)
                {
                    throw new ArgumentException("Số lượng phải lớn hơn 0");
                }

                if (detail.UnitPrice < 0)
                {
                    throw new ArgumentException("Đơn giá không được âm");
                }

                if (detail.Discount < 0 || detail.Discount > 100)
                {
                    throw new ArgumentException("Giảm giá phải từ 0 đến 100%");
                }

                // Calculate total amount for detail
                decimal discountAmount = detail.UnitPrice * detail.Quantity * (detail.Discount / 100);
                detail.TotalAmount = (detail.UnitPrice * detail.Quantity) - discountAmount;
            }
        }

        private decimal CalculateTotalAmount(ICollection<OrderDetail> orderDetails)
        {
            return orderDetails.Sum(d => d.TotalAmount);
        }

        private void AddPointsForOrder(string customerId, decimal orderAmount)
        {
            try
            {
                // Calculate points: 1 point per 10,000 VND
                int pointsToAdd = (int)(orderAmount / 10000);
                
                if (pointsToAdd > 0)
                {
                    pointsDAL.UpdatePoints(customerId, pointsToAdd);
                }
            }
            catch (Exception ex)
            {
                // Log error but don't throw - points are not critical for order processing
                System.Diagnostics.Debug.WriteLine($"Lỗi khi cộng điểm: {ex.Message}");
            }
        }

        /// <summary>
        /// Tạo đơn hàng nhanh với thông tin cơ bản
        /// </summary>
        public Order CreateQuickOrder(string customerName, string customerPhone, string staffId, 
            FormOfService formOfService, List<OrderDetail> orderDetails, string tableId = null, string roomId = null)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(customerName))
                {
                    throw new ArgumentException("Tên khách hàng không được để trống");
                }

                if (string.IsNullOrWhiteSpace(customerPhone))
                {
                    throw new ArgumentException("Số điện thoại không được để trống");
                }

                if (string.IsNullOrWhiteSpace(staffId))
                {
                    throw new ArgumentException("Nhân viên phục vụ không được để trống");
                }

                if (orderDetails == null || orderDetails.Count == 0)
                {
                    throw new ArgumentException("Chi tiết đơn hàng không được để trống");
                }

                // Try to find existing customer by phone
                var customer = customerDAL.GetByPhoneNumber(customerPhone);
                
                var order = new Order
                {
                    OrderID = GenerateNewOrderID(),
                    OrderDate = DateTime.Now,
                    OrderTime = DateTime.Now,
                    OrderStatus = OrderStatus.Pending,
                    FormOfService = formOfService,
                    CustomerID = customer?.CustomerID,
                    CustomerName = customerName,
                    CustomerPhone = customerPhone,
                    TableID = tableId,
                    RoomID = roomId,
                    StaffID = staffId,
                    OrderDetails = orderDetails,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                // Set OrderID for all details
                foreach (var detail in orderDetails)
                {
                    detail.OrderID = order.OrderID;
                }

                if (Insert(order))
                {
                    return order;
                }

                throw new Exception("Không thể tạo đơn hàng");
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tạo đơn hàng nhanh: {ex.Message}");
            }
        }
    }
}

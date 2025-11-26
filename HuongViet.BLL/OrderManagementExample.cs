using HuongViet.Models;
using System;
using System.Collections.Generic;

namespace HuongViet.BLL
{
    /// <summary>
    /// Ví dụ về cách sử dụng các lớp quản lý khách hàng và đơn hàng
    /// </summary>
    public class OrderManagementExample
    {
        private readonly CustomerBLL customerBLL;
        private readonly OrderBLL orderBLL;
        private readonly AccumulatedPointsBLL pointsBLL;
        private readonly ItemBLL itemBLL;

        public OrderManagementExample()
        {
            customerBLL = new CustomerBLL();
            orderBLL = new OrderBLL();
            pointsBLL = new AccumulatedPointsBLL();
            itemBLL = new ItemBLL();
        }

        /// <summary>
        /// Ví dụ tạo đơn hàng hoàn chỉnh
        /// </summary>
        public void CreateOrderExample()
        {
            try
            {
                // 1. Tạo hoặc tìm khách hàng
                string customerName = "Nguyễn Văn A";
                string customerPhone = "0901234567";
                
                Customer customer = customerBLL.CreateQuickCustomer(customerName, customerPhone);
                Console.WriteLine($"Khách hàng: {customer.CustomerName} - ID: {customer.CustomerID}");

                // 2. Tạo chi tiết đơn hàng
                List<OrderDetail> orderDetails = new List<OrderDetail>
                {
                    new OrderDetail
                    {
                        ItemID = "ITEM001", // Giả sử món này tồn tại
                        Quantity = 2,
                        UnitPrice = 50000,
                        Discount = 0,
                        Note = "Ít cay"
                    },
                    new OrderDetail
                    {
                        ItemID = "ITEM002", // Giả sử món này tồn tại
                        Quantity = 1,
                        UnitPrice = 25000,
                        Discount = 10, // Giảm 10%
                        Note = "Không đá"
                    }
                };

                // Tính tổng tiền cho từng chi tiết
                foreach (var detail in orderDetails)
                {
                    decimal discountAmount = detail.UnitPrice * detail.Quantity * (detail.Discount / 100);
                    detail.TotalAmount = (detail.UnitPrice * detail.Quantity) - discountAmount;
                }

                // 3. Tạo đơn hàng
                Order order = orderBLL.CreateQuickOrder(
                    customerName: customer.CustomerName,
                    customerPhone: customer.CustomerPhoneNum,
                    staffId: "USER001", // Giả sử nhân viên này tồn tại
                    formOfService: FormOfService.DineIn,
                    orderDetails: orderDetails,
                    tableId: "TABLE001" // Giả sử bàn này tồn tại
                );

                Console.WriteLine($"Đơn hàng đã tạo: {order.OrderID}");
                Console.WriteLine($"Tổng tiền: {order.TotalAmount:N0} VND");

                // 4. Cập nhật trạng thái đơn hàng
                orderBLL.UpdateStatus(order.OrderID, OrderStatus.Confirmed);
                Console.WriteLine("Đã xác nhận đơn hàng");

                orderBLL.UpdateStatus(order.OrderID, OrderStatus.Completed);
                Console.WriteLine("Đã hoàn thành đơn hàng");

                // 5. Kiểm tra điểm tích lũy
                int currentPoints = pointsBLL.GetCurrentPoints(customer.CustomerID);
                Console.WriteLine($"Điểm tích lũy hiện tại: {currentPoints}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }
        }

        /// <summary>
        /// Ví dụ sử dụng điểm tích lũy
        /// </summary>
        public void UsePointsExample()
        {
            try
            {
                string customerId = "CUST000001"; // Giả sử khách hàng này tồn tại
                
                // Kiểm tra điểm hiện tại
                int currentPoints = pointsBLL.GetCurrentPoints(customerId);
                Console.WriteLine($"Điểm hiện tại: {currentPoints}");

                // Sử dụng 50 điểm (tương đương 50,000 VND)
                int pointsToUse = 50;
                if (pointsBLL.CanUsePoints(customerId, pointsToUse))
                {
                    decimal discountAmount = pointsBLL.CalculateAmountFromPoints(pointsToUse);
                    Console.WriteLine($"Có thể sử dụng {pointsToUse} điểm = {discountAmount:N0} VND");
                    
                    pointsBLL.UsePoints(customerId, pointsToUse);
                    Console.WriteLine("Đã sử dụng điểm thành công");
                    
                    int remainingPoints = pointsBLL.GetCurrentPoints(customerId);
                    Console.WriteLine($"Điểm còn lại: {remainingPoints}");
                }
                else
                {
                    Console.WriteLine("Không đủ điểm để sử dụng");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }
        }

        /// <summary>
        /// Ví dụ tìm kiếm đơn hàng
        /// </summary>
        public void SearchOrdersExample()
        {
            try
            {
                var searchCriteria = new SearchCriteria
                {
                    SearchTerm = "Nguyễn", // Tìm theo tên khách hàng
                    PageNumber = 1,
                    PageSize = 10,
                    SortBy = "OrderDate",
                    SortDirection = "DESC"
                };

                var result = orderBLL.SearchOrders(
                    criteria: searchCriteria,
                    status: OrderStatus.Completed,
                    fromDate: DateTime.Today.AddDays(-7), // 7 ngày trước
                    toDate: DateTime.Today
                );

                Console.WriteLine($"Tìm thấy {result.TotalRecords} đơn hàng");
                Console.WriteLine($"Trang {result.PageNumber}/{result.TotalPages}");

                foreach (var order in result.Data)
                {
                    Console.WriteLine($"- {order.OrderID}: {order.CustomerName} - {order.TotalAmount:N0} VND");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }
        }

        /// <summary>
        /// Ví dụ tìm kiếm khách hàng
        /// </summary>
        public void SearchCustomersExample()
        {
            try
            {
                var searchCriteria = new SearchCriteria
                {
                    SearchTerm = "0901", // Tìm theo số điện thoại
                    PageNumber = 1,
                    PageSize = 10
                };

                var result = customerBLL.SearchCustomers(searchCriteria);

                Console.WriteLine($"Tìm thấy {result.TotalRecords} khách hàng");

                foreach (var customer in result.Data)
                {
                    int points = pointsBLL.GetCurrentPoints(customer.CustomerID);
                    Console.WriteLine($"- {customer.CustomerName} ({customer.CustomerPhoneNum}) - {points} điểm");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }
        }
    }
}

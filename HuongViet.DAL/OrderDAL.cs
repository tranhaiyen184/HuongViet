using HuongViet.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace HuongViet.DAL
{
    public class OrderDAL
    {
        private readonly DatabaseHelper dbHelper;

        public OrderDAL()
        {
            this.dbHelper = new DatabaseHelper();
        }

        private Order MapDataRowToEntity(DataRow row)
        {
            OrderStatus orderStatus;
            string statusStr = row["OrderStatus"].ToString();
            Enum.TryParse(statusStr, out orderStatus);

            FormOfService formOfService;
            string serviceStr = row["FormOfService"].ToString();
            if (serviceStr == "Dine In")
                formOfService = FormOfService.DineIn;
            else
                formOfService = FormOfService.Takeaway;

            PaymentMethod? paymentMethod = null;
            if (!row.IsNull("PaymentMethod"))
            {
                string paymentStr = row["PaymentMethod"].ToString();
                if (paymentStr == "Cash")
                    paymentMethod = PaymentMethod.Cash;
                else if (paymentStr == "Bank Transfer")
                    paymentMethod = PaymentMethod.BankTransfer;
            }

            return new Order
            {
                OrderID = row["OrderID"].ToString(),
                OrderDate = Convert.ToDateTime(row["OrderDate"]),
                OrderTime = Convert.ToDateTime(row["OrderTime"]),
                OrderStatus = orderStatus,
                OrderNote = row.IsNull("OrderNote") ? null : row["OrderNote"].ToString(),
                FormOfService = formOfService,
                PaymentMethod = paymentMethod,
                TotalAmount = Convert.ToDecimal(row["TotalAmount"]),
                CustomerID = row.IsNull("CustomerID") ? null : row["CustomerID"].ToString(),
                CustomerName = row["CustomerName"].ToString(),
                CustomerPhone = row["CustomerPhone"].ToString(),
                TableID = row.IsNull("TableID") ? null : row["TableID"].ToString(),
                RoomID = row.IsNull("RoomID") ? null : row["RoomID"].ToString(),
                ReservationID = row.IsNull("ReservationID") ? null : row["ReservationID"].ToString(),
                StaffID = row["StaffID"].ToString(),
                DeletedAt = row.IsNull("DeletedAt") ? (DateTime?)null : Convert.ToDateTime(row["DeletedAt"]),
                CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                UpdatedAt = Convert.ToDateTime(row["UpdatedAt"])
            };
        }

        private string GetOrderStatusString(OrderStatus status)
        {
            return status.ToString();
        }

        private string GetFormOfServiceString(FormOfService service)
        {
            return service == FormOfService.DineIn ? "Dine In" : "Takeaway";
        }

        private string GetPaymentMethodString(PaymentMethod? method)
        {
            if (!method.HasValue) return null;
            return method.Value == PaymentMethod.Cash ? "Cash" : "Bank Transfer";
        }

        public List<Order> GetAll()
        {
            string query = @"SELECT o.*, c.CustomerName as CustName, u.FirstName, u.LastName,
                           t.TableName, r.RoomName
                           FROM orders o
                           LEFT JOIN customers c ON o.CustomerID = c.CustomerID
                           LEFT JOIN users u ON o.StaffID = u.UserID
                           LEFT JOIN tables t ON o.TableID = t.TableID
                           LEFT JOIN rooms r ON o.RoomID = r.RoomID
                           WHERE o.DeletedAt IS NULL
                           ORDER BY o.OrderDate DESC, o.OrderTime DESC";
            DataTable dt = dbHelper.ExecuteQuery(query);
            return ConvertDataTableToList(dt);
        }

        public Order GetById(string id, bool loadDetails = true)
        {
            string query = @"SELECT o.*, c.CustomerName as CustName, u.FirstName, u.LastName,
                           t.TableName, r.RoomName
                           FROM orders o
                           LEFT JOIN customers c ON o.CustomerID = c.CustomerID
                           LEFT JOIN users u ON o.StaffID = u.UserID
                           LEFT JOIN tables t ON o.TableID = t.TableID
                           LEFT JOIN rooms r ON o.RoomID = r.RoomID
                           WHERE o.OrderID = @id AND o.DeletedAt IS NULL";
            MySqlParameter[] parameters = { new MySqlParameter("@id", id) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            
            if (dt.Rows.Count > 0)
            {
                var order = MapDataRowToEntity(dt.Rows[0]);
                
                // Add navigation properties
                if (!dt.Rows[0].IsNull("CustName"))
                {
                    order.Customer = new Customer
                    {
                        CustomerID = order.CustomerID,
                        CustomerName = dt.Rows[0]["CustName"].ToString()
                    };
                }
                
                if (!dt.Rows[0].IsNull("FirstName"))
                {
                    order.Staff = new User
                    {
                        UserID = order.StaffID,
                        FirstName = dt.Rows[0]["FirstName"].ToString(),
                        LastName = dt.Rows[0]["LastName"].ToString()
                    };
                }
                
                // Load order details if needed
                if (loadDetails)
                {
                    order.OrderDetails = GetOrderDetails(order.OrderID);
                }
                
                return order;
            }
            return null;
        }

        public List<Order> GetByCustomer(string customerId)
        {
            string query = @"SELECT o.*, c.CustomerName as CustName, u.FirstName, u.LastName,
                           t.TableName, r.RoomName
                           FROM orders o
                           LEFT JOIN customers c ON o.CustomerID = c.CustomerID
                           LEFT JOIN users u ON o.StaffID = u.UserID
                           LEFT JOIN tables t ON o.TableID = t.TableID
                           LEFT JOIN rooms r ON o.RoomID = r.RoomID
                           WHERE o.CustomerID = @customerId AND o.DeletedAt IS NULL
                           ORDER BY o.OrderDate DESC, o.OrderTime DESC";
            MySqlParameter[] parameters = { new MySqlParameter("@customerId", customerId) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            return ConvertDataTableToList(dt);
        }

        public List<Order> GetByStatus(OrderStatus status)
        {
            string query = @"SELECT o.*, c.CustomerName as CustName, u.FirstName, u.LastName,
                           t.TableName, r.RoomName
                           FROM orders o
                           LEFT JOIN customers c ON o.CustomerID = c.CustomerID
                           LEFT JOIN users u ON o.StaffID = u.UserID
                           LEFT JOIN tables t ON o.TableID = t.TableID
                           LEFT JOIN rooms r ON o.RoomID = r.RoomID
                           WHERE o.OrderStatus = @status AND o.DeletedAt IS NULL
                           ORDER BY o.OrderDate DESC, o.OrderTime DESC";
            MySqlParameter[] parameters = { new MySqlParameter("@status", GetOrderStatusString(status)) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            return ConvertDataTableToList(dt);
        }

        public List<Order> GetByDateRange(DateTime fromDate, DateTime toDate)
        {
            string query = @"SELECT o.*, c.CustomerName as CustName, u.FirstName, u.LastName,
                           t.TableName, r.RoomName
                           FROM orders o
                           LEFT JOIN customers c ON o.CustomerID = c.CustomerID
                           LEFT JOIN users u ON o.StaffID = u.UserID
                           LEFT JOIN tables t ON o.TableID = t.TableID
                           LEFT JOIN rooms r ON o.RoomID = r.RoomID
                           WHERE DATE(o.OrderDate) BETWEEN @fromDate AND @toDate 
                           AND o.DeletedAt IS NULL
                           ORDER BY o.OrderDate DESC, o.OrderTime DESC";
            MySqlParameter[] parameters = 
            {
                new MySqlParameter("@fromDate", fromDate.Date),
                new MySqlParameter("@toDate", toDate.Date)
            };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            return ConvertDataTableToList(dt);
        }

        public bool Insert(Order order)
        {
            MySqlConnection connection = null;
            MySqlTransaction transaction = null;
            
            try
            {
                connection = new MySqlConnection(dbHelper.GetConnectionString());
                connection.Open();
                transaction = connection.BeginTransaction();

                // Insert order
                string orderQuery = @"INSERT INTO orders (OrderID, OrderDate, OrderTime, OrderStatus, 
                                    OrderNote, FormOfService, PaymentMethod, TotalAmount, CustomerID, 
                                    CustomerName, CustomerPhone, TableID, RoomID, ReservationID, StaffID, 
                                    CreatedAt, UpdatedAt) 
                                    VALUES (@OrderID, @OrderDate, @OrderTime, @OrderStatus, @OrderNote, 
                                    @FormOfService, @PaymentMethod, @TotalAmount, @CustomerID, @CustomerName, 
                                    @CustomerPhone, @TableID, @RoomID, @ReservationID, @StaffID, 
                                    @CreatedAt, @UpdatedAt)";
                
                using (var cmd = new MySqlCommand(orderQuery, connection, transaction))
                {
                    cmd.Parameters.AddRange(new MySqlParameter[]
                    {
                        new MySqlParameter("@OrderID", order.OrderID),
                        new MySqlParameter("@OrderDate", order.OrderDate),
                        new MySqlParameter("@OrderTime", order.OrderTime),
                        new MySqlParameter("@OrderStatus", GetOrderStatusString(order.OrderStatus)),
                        new MySqlParameter("@OrderNote", (object)order.OrderNote ?? DBNull.Value),
                        new MySqlParameter("@FormOfService", GetFormOfServiceString(order.FormOfService)),
                        new MySqlParameter("@PaymentMethod", (object)GetPaymentMethodString(order.PaymentMethod) ?? DBNull.Value),
                        new MySqlParameter("@TotalAmount", order.TotalAmount),
                        new MySqlParameter("@CustomerID", (object)order.CustomerID ?? DBNull.Value),
                        new MySqlParameter("@CustomerName", order.CustomerName),
                        new MySqlParameter("@CustomerPhone", order.CustomerPhone),
                        new MySqlParameter("@TableID", (object)order.TableID ?? DBNull.Value),
                        new MySqlParameter("@RoomID", (object)order.RoomID ?? DBNull.Value),
                        new MySqlParameter("@ReservationID", (object)order.ReservationID ?? DBNull.Value),
                        new MySqlParameter("@StaffID", order.StaffID),
                        new MySqlParameter("@CreatedAt", order.CreatedAt),
                        new MySqlParameter("@UpdatedAt", order.UpdatedAt)
                    });
                    
                    cmd.ExecuteNonQuery();
                }

                // Insert order details
                if (order.OrderDetails != null && order.OrderDetails.Count > 0)
                {
                    string detailQuery = @"INSERT INTO order_details (OrderID, ItemID, Quantity, 
                                         UnitPrice, TotalAmount, Discount, Note) 
                                         VALUES (@OrderID, @ItemID, @Quantity, @UnitPrice, 
                                         @TotalAmount, @Discount, @Note)";
                    
                    foreach (var detail in order.OrderDetails)
                    {
                        using (var cmd = new MySqlCommand(detailQuery, connection, transaction))
                        {
                            cmd.Parameters.AddRange(new MySqlParameter[]
                            {
                                new MySqlParameter("@OrderID", order.OrderID),
                                new MySqlParameter("@ItemID", detail.ItemID),
                                new MySqlParameter("@Quantity", detail.Quantity),
                                new MySqlParameter("@UnitPrice", detail.UnitPrice),
                                new MySqlParameter("@TotalAmount", detail.TotalAmount),
                                new MySqlParameter("@Discount", detail.Discount),
                                new MySqlParameter("@Note", (object)detail.Note ?? DBNull.Value)
                            });
                            
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                throw new Exception($"Lỗi khi thêm đơn hàng: {ex.Message}");
            }
            finally
            {
                transaction?.Dispose();
                connection?.Close();
                connection?.Dispose();
            }
        }

        public bool Update(Order order)
        {
            try
            {
                string query = @"UPDATE orders SET OrderDate = @OrderDate, OrderTime = @OrderTime, 
                               OrderStatus = @OrderStatus, OrderNote = @OrderNote, 
                               FormOfService = @FormOfService, PaymentMethod = @PaymentMethod, 
                               TotalAmount = @TotalAmount, CustomerID = @CustomerID, 
                               CustomerName = @CustomerName, CustomerPhone = @CustomerPhone, 
                               TableID = @TableID, RoomID = @RoomID, ReservationID = @ReservationID, 
                               StaffID = @StaffID, UpdatedAt = @UpdatedAt 
                               WHERE OrderID = @OrderID AND DeletedAt IS NULL";
                
                MySqlParameter[] parameters = 
                {
                    new MySqlParameter("@OrderID", order.OrderID),
                    new MySqlParameter("@OrderDate", order.OrderDate),
                    new MySqlParameter("@OrderTime", order.OrderTime),
                    new MySqlParameter("@OrderStatus", GetOrderStatusString(order.OrderStatus)),
                    new MySqlParameter("@OrderNote", (object)order.OrderNote ?? DBNull.Value),
                    new MySqlParameter("@FormOfService", GetFormOfServiceString(order.FormOfService)),
                    new MySqlParameter("@PaymentMethod", (object)GetPaymentMethodString(order.PaymentMethod) ?? DBNull.Value),
                    new MySqlParameter("@TotalAmount", order.TotalAmount),
                    new MySqlParameter("@CustomerID", (object)order.CustomerID ?? DBNull.Value),
                    new MySqlParameter("@CustomerName", order.CustomerName),
                    new MySqlParameter("@CustomerPhone", order.CustomerPhone),
                    new MySqlParameter("@TableID", (object)order.TableID ?? DBNull.Value),
                    new MySqlParameter("@RoomID", (object)order.RoomID ?? DBNull.Value),
                    new MySqlParameter("@ReservationID", (object)order.ReservationID ?? DBNull.Value),
                    new MySqlParameter("@StaffID", order.StaffID),
                    new MySqlParameter("@UpdatedAt", DateTime.Now)
                };
                
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
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
                string query = @"UPDATE orders SET OrderStatus = @status, UpdatedAt = @UpdatedAt 
                               WHERE OrderID = @orderId AND DeletedAt IS NULL";
                
                MySqlParameter[] parameters = 
                {
                    new MySqlParameter("@orderId", orderId),
                    new MySqlParameter("@status", GetOrderStatusString(status)),
                    new MySqlParameter("@UpdatedAt", DateTime.Now)
                };
                
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
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
                // Soft delete
                string query = "UPDATE orders SET DeletedAt = @DeletedAt WHERE OrderID = @id";
                MySqlParameter[] parameters = 
                {
                    new MySqlParameter("@id", id),
                    new MySqlParameter("@DeletedAt", DateTime.Now)
                };
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa đơn hàng: {ex.Message}");
            }
        }

        public bool Exists(string id)
        {
            string query = "SELECT COUNT(*) FROM orders WHERE OrderID = @id AND DeletedAt IS NULL";
            MySqlParameter[] parameters = { new MySqlParameter("@id", id) };
            int count = Convert.ToInt32(dbHelper.ExecuteScalar(query, parameters));
            return count > 0;
        }

        public List<OrderDetail> GetOrderDetails(string orderId)
        {
            string query = @"SELECT od.*, i.ItemName, i.ItemImage, u.UnitName 
                           FROM order_details od
                           LEFT JOIN items i ON od.ItemID = i.ItemID
                           LEFT JOIN units u ON i.UnitID = u.UnitID
                           WHERE od.OrderID = @orderId";
            MySqlParameter[] parameters = { new MySqlParameter("@orderId", orderId) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            
            List<OrderDetail> details = new List<OrderDetail>();
            foreach (DataRow row in dt.Rows)
            {
                var detail = new OrderDetail
                {
                    OrderID = row["OrderID"].ToString(),
                    ItemID = row["ItemID"].ToString(),
                    Quantity = Convert.ToInt32(row["Quantity"]),
                    UnitPrice = Convert.ToDecimal(row["UnitPrice"]),
                    TotalAmount = Convert.ToDecimal(row["TotalAmount"]),
                    Discount = Convert.ToDecimal(row["Discount"]),
                    Note = row.IsNull("Note") ? null : row["Note"].ToString()
                };
                
                // Add item navigation property
                if (!row.IsNull("ItemName"))
                {
                    detail.Item = new Item
                    {
                        ItemID = detail.ItemID,
                        ItemName = row["ItemName"].ToString(),
                        ItemImage = row.IsNull("ItemImage") ? null : row["ItemImage"].ToString()
                    };
                    
                    if (!row.IsNull("UnitName"))
                    {
                        detail.Item.Unit = new Unit
                        {
                            UnitName = row["UnitName"].ToString()
                        };
                    }
                }
                
                details.Add(detail);
            }
            
            return details;
        }

        /// <summary>
        /// Xóa tất cả order details của một đơn hàng
        /// </summary>
        public bool DeleteOrderDetails(string orderId)
        {
            try
            {
                string query = "DELETE FROM order_details WHERE OrderID = @OrderID";
                MySqlParameter[] parameters = 
                {
                    new MySqlParameter("@OrderID", orderId)
                };
                
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result >= 0; // >= 0 because might be 0 if no details exist
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa order details: {ex.Message}");
            }
        }

        /// <summary>
        /// Thêm order details vào database
        /// </summary>
        public bool InsertOrderDetails(string orderId, List<OrderDetail> orderDetails)
        {
            try
            {
                if (orderDetails == null || orderDetails.Count == 0)
                {
                    return true;
                }

                string detailQuery = @"INSERT INTO order_details (OrderID, ItemID, Quantity, 
                                     UnitPrice, TotalAmount, Discount, Note) 
                                     VALUES (@OrderID, @ItemID, @Quantity, @UnitPrice, 
                                     @TotalAmount, @Discount, @Note)";
                
                foreach (var detail in orderDetails)
                {
                    MySqlParameter[] parameters = 
                    {
                        new MySqlParameter("@OrderID", orderId),
                        new MySqlParameter("@ItemID", detail.ItemID),
                        new MySqlParameter("@Quantity", detail.Quantity),
                        new MySqlParameter("@UnitPrice", detail.UnitPrice),
                        new MySqlParameter("@TotalAmount", detail.TotalAmount),
                        new MySqlParameter("@Discount", detail.Discount),
                        new MySqlParameter("@Note", (object)detail.Note ?? DBNull.Value)
                    };
                    
                    int result = dbHelper.ExecuteNonQuery(detailQuery, parameters);
                    if (result <= 0)
                    {
                        throw new Exception($"Không thể thêm order detail cho item {detail.ItemID}");
                    }
                }
                
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm order details: {ex.Message}");
            }
        }

        public PagedResult<Order> SearchOrders(SearchCriteria criteria, OrderStatus? status = null, 
            DateTime? fromDate = null, DateTime? toDate = null, string customerId = null)
        {
            try
            {
                // Xây dựng WHERE clause
                List<string> conditions = new List<string> { "o.DeletedAt IS NULL" };
                List<MySqlParameter> parameters = new List<MySqlParameter>();

                // Filter theo tên khách hàng hoặc số điện thoại
                if (!string.IsNullOrEmpty(criteria.SearchTerm))
                {
                    conditions.Add("(o.CustomerName LIKE @searchTerm OR o.CustomerPhone LIKE @searchTerm OR o.OrderID LIKE @searchTerm)");
                    parameters.Add(new MySqlParameter("@searchTerm", $"%{criteria.SearchTerm}%"));
                }

                // Filter theo trạng thái
                if (status.HasValue)
                {
                    conditions.Add("o.OrderStatus = @status");
                    parameters.Add(new MySqlParameter("@status", GetOrderStatusString(status.Value)));
                }

                // Filter theo ngày
                if (fromDate.HasValue)
                {
                    conditions.Add("DATE(o.OrderDate) >= @fromDate");
                    parameters.Add(new MySqlParameter("@fromDate", fromDate.Value.Date));
                }

                if (toDate.HasValue)
                {
                    conditions.Add("DATE(o.OrderDate) <= @toDate");
                    parameters.Add(new MySqlParameter("@toDate", toDate.Value.Date));
                }

                // Filter theo khách hàng
                if (!string.IsNullOrEmpty(customerId))
                {
                    conditions.Add("o.CustomerID = @customerId");
                    parameters.Add(new MySqlParameter("@customerId", customerId));
                }

                string whereClause = "WHERE " + string.Join(" AND ", conditions);

                // Tạo ORDER BY
                string orderBy = "ORDER BY o.OrderDate DESC, o.OrderTime DESC";
                if (!string.IsNullOrEmpty(criteria.SortBy))
                {
                    orderBy = $"ORDER BY {criteria.SortBy} {criteria.SortDirection}";
                }

                // Đếm tổng số bản ghi
                string countQuery = $@"SELECT COUNT(*) FROM orders o {whereClause}";
                int totalRecords = Convert.ToInt32(dbHelper.ExecuteScalar(countQuery, parameters.ToArray()));

                // Tính toán phân trang
                int offset = (criteria.PageNumber - 1) * criteria.PageSize;

                // Lấy dữ liệu với phân trang
                string dataQuery = $@"SELECT o.*, c.CustomerName as CustName, u.FirstName, u.LastName,
                                    t.TableName, r.RoomName
                                    FROM orders o
                                    LEFT JOIN customers c ON o.CustomerID = c.CustomerID
                                    LEFT JOIN users u ON o.StaffID = u.UserID
                                    LEFT JOIN tables t ON o.TableID = t.TableID
                                    LEFT JOIN rooms r ON o.RoomID = r.RoomID
                                    {whereClause} {orderBy} LIMIT {criteria.PageSize} OFFSET {offset}";
                DataTable dt = dbHelper.ExecuteQuery(dataQuery, parameters.ToArray());

                return new PagedResult<Order>
                {
                    Data = ConvertDataTableToList(dt),
                    TotalRecords = totalRecords,
                    PageNumber = criteria.PageNumber,
                    PageSize = criteria.PageSize
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tìm kiếm đơn hàng: {ex.Message}");
            }
        }

        private List<Order> ConvertDataTableToList(DataTable dt)
        {
            List<Order> list = new List<Order>();
            foreach (DataRow row in dt.Rows)
            {
                var order = MapDataRowToEntity(row);
                
                // Add navigation properties if available
                if (!row.IsNull("CustName"))
                {
                    order.Customer = new Customer
                    {
                        CustomerID = order.CustomerID,
                        CustomerName = row["CustName"].ToString()
                    };
                }
                
                if (!row.IsNull("FirstName"))
                {
                    order.Staff = new User
                    {
                        UserID = order.StaffID,
                        FirstName = row["FirstName"].ToString(),
                        LastName = row["LastName"].ToString()
                    };
                }
                
                list.Add(order);
            }
            return list;
        }
    }
}

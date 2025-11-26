using HuongViet.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace HuongViet.DAL
{
    public class AccumulatedPointsDAL
    {
        private readonly DatabaseHelper dbHelper;

        public AccumulatedPointsDAL()
        {
            this.dbHelper = new DatabaseHelper();
        }

        private AccumulatedPoints MapDataRowToEntity(DataRow row)
        {
            return new AccumulatedPoints
            {
                AccumulatedPointID = row["AccumulatedPointID"].ToString(),
                CustomerID = row["CustomerID"].ToString(),
                AccumPoint = Convert.ToInt32(row["AccumPoint"]),
                TotalAccumPoint = Convert.ToInt32(row["TotalAccumPoint"]),
                UpdateDate = Convert.ToDateTime(row["UpdateDate"]),
                DeletedAt = row.IsNull("DeletedAt") ? (DateTime?)null : Convert.ToDateTime(row["DeletedAt"]),
                CreatedAt = Convert.ToDateTime(row["CreatedAt"])
            };
        }

        public List<AccumulatedPoints> GetAll()
        {
            string query = @"SELECT ap.*, c.CustomerName 
                           FROM accumulated_points ap
                           LEFT JOIN customers c ON ap.CustomerID = c.CustomerID
                           WHERE ap.DeletedAt IS NULL 
                           ORDER BY ap.UpdateDate DESC";
            DataTable dt = dbHelper.ExecuteQuery(query);
            return ConvertDataTableToList(dt);
        }

        public AccumulatedPoints GetById(string id)
        {
            string query = @"SELECT ap.*, c.CustomerName 
                           FROM accumulated_points ap
                           LEFT JOIN customers c ON ap.CustomerID = c.CustomerID
                           WHERE ap.AccumulatedPointID = @id AND ap.DeletedAt IS NULL";
            MySqlParameter[] parameters = { new MySqlParameter("@id", id) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            
            if (dt.Rows.Count > 0)
            {
                var point = MapDataRowToEntity(dt.Rows[0]);
                
                // Add navigation property
                if (!dt.Rows[0].IsNull("CustomerName"))
                {
                    point.Customer = new Customer
                    {
                        CustomerID = point.CustomerID,
                        CustomerName = dt.Rows[0]["CustomerName"].ToString()
                    };
                }
                
                return point;
            }
            return null;
        }

        public AccumulatedPoints GetByCustomer(string customerId)
        {
            string query = @"SELECT ap.*, c.CustomerName 
                           FROM accumulated_points ap
                           LEFT JOIN customers c ON ap.CustomerID = c.CustomerID
                           WHERE ap.CustomerID = @customerId AND ap.DeletedAt IS NULL
                           ORDER BY ap.UpdateDate DESC LIMIT 1";
            MySqlParameter[] parameters = { new MySqlParameter("@customerId", customerId) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            
            if (dt.Rows.Count > 0)
            {
                var point = MapDataRowToEntity(dt.Rows[0]);
                
                // Add navigation property
                if (!dt.Rows[0].IsNull("CustomerName"))
                {
                    point.Customer = new Customer
                    {
                        CustomerID = point.CustomerID,
                        CustomerName = dt.Rows[0]["CustomerName"].ToString()
                    };
                }
                
                return point;
            }
            return null;
        }

        public List<AccumulatedPoints> GetHistoryByCustomer(string customerId)
        {
            string query = @"SELECT ap.*, c.CustomerName 
                           FROM accumulated_points ap
                           LEFT JOIN customers c ON ap.CustomerID = c.CustomerID
                           WHERE ap.CustomerID = @customerId AND ap.DeletedAt IS NULL
                           ORDER BY ap.UpdateDate DESC";
            MySqlParameter[] parameters = { new MySqlParameter("@customerId", customerId) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            return ConvertDataTableToList(dt);
        }

        public bool Insert(AccumulatedPoints point)
        {
            try
            {
                string query = @"INSERT INTO accumulated_points (AccumulatedPointID, CustomerID, 
                               AccumPoint, TotalAccumPoint, UpdateDate, CreatedAt) 
                               VALUES (@AccumulatedPointID, @CustomerID, @AccumPoint, 
                               @TotalAccumPoint, @UpdateDate, @CreatedAt)";
                
                MySqlParameter[] parameters = 
                {
                    new MySqlParameter("@AccumulatedPointID", point.AccumulatedPointID),
                    new MySqlParameter("@CustomerID", point.CustomerID),
                    new MySqlParameter("@AccumPoint", point.AccumPoint),
                    new MySqlParameter("@TotalAccumPoint", point.TotalAccumPoint),
                    new MySqlParameter("@UpdateDate", point.UpdateDate),
                    new MySqlParameter("@CreatedAt", point.CreatedAt)
                };
                
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm điểm tích lũy: {ex.Message}");
            }
        }

        public bool Update(AccumulatedPoints point)
        {
            try
            {
                string query = @"UPDATE accumulated_points SET AccumPoint = @AccumPoint, 
                               TotalAccumPoint = @TotalAccumPoint, UpdateDate = @UpdateDate 
                               WHERE AccumulatedPointID = @AccumulatedPointID AND DeletedAt IS NULL";
                
                MySqlParameter[] parameters = 
                {
                    new MySqlParameter("@AccumulatedPointID", point.AccumulatedPointID),
                    new MySqlParameter("@AccumPoint", point.AccumPoint),
                    new MySqlParameter("@TotalAccumPoint", point.TotalAccumPoint),
                    new MySqlParameter("@UpdateDate", DateTime.Now)
                };
                
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật điểm tích lũy: {ex.Message}");
            }
        }

        public bool UpdatePoints(string customerId, int pointsToAdd)
        {
            try
            {
                // Lấy điểm hiện tại
                var currentPoints = GetByCustomer(customerId);
                
                if (currentPoints == null)
                {
                    // Tạo mới nếu chưa có
                    var newPoints = new AccumulatedPoints
                    {
                        AccumulatedPointID = GenerateNewId(),
                        CustomerID = customerId,
                        AccumPoint = pointsToAdd,
                        TotalAccumPoint = pointsToAdd,
                        UpdateDate = DateTime.Now,
                        CreatedAt = DateTime.Now
                    };
                    
                    return Insert(newPoints);
                }
                else
                {
                    // Cập nhật điểm hiện tại
                    currentPoints.AccumPoint += pointsToAdd;
                    currentPoints.TotalAccumPoint += pointsToAdd;
                    currentPoints.UpdateDate = DateTime.Now;
                    
                    return Update(currentPoints);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật điểm tích lũy: {ex.Message}");
            }
        }

        public bool UsePoints(string customerId, int pointsToUse)
        {
            try
            {
                var currentPoints = GetByCustomer(customerId);
                
                if (currentPoints == null || currentPoints.AccumPoint < pointsToUse)
                {
                    throw new Exception("Không đủ điểm để sử dụng");
                }
                
                // Trừ điểm hiện tại (không trừ tổng điểm tích lũy)
                currentPoints.AccumPoint -= pointsToUse;
                currentPoints.UpdateDate = DateTime.Now;
                
                return Update(currentPoints);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi sử dụng điểm tích lũy: {ex.Message}");
            }
        }

        public bool Delete(string id)
        {
            try
            {
                // Soft delete
                string query = "UPDATE accumulated_points SET DeletedAt = @DeletedAt WHERE AccumulatedPointID = @id";
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
                throw new Exception($"Lỗi khi xóa điểm tích lũy: {ex.Message}");
            }
        }

        public bool Exists(string id)
        {
            string query = "SELECT COUNT(*) FROM accumulated_points WHERE AccumulatedPointID = @id AND DeletedAt IS NULL";
            MySqlParameter[] parameters = { new MySqlParameter("@id", id) };
            int count = Convert.ToInt32(dbHelper.ExecuteScalar(query, parameters));
            return count > 0;
        }

        public bool CustomerHasPoints(string customerId)
        {
            string query = "SELECT COUNT(*) FROM accumulated_points WHERE CustomerID = @customerId AND DeletedAt IS NULL";
            MySqlParameter[] parameters = { new MySqlParameter("@customerId", customerId) };
            int count = Convert.ToInt32(dbHelper.ExecuteScalar(query, parameters));
            return count > 0;
        }

        public string GenerateNewId()
        {
            try
            {
                var points = GetAll();
                int maxNumber = 0;

                foreach (var point in points)
                {
                    if (point.AccumulatedPointID.StartsWith("AP"))
                    {
                        string numberPart = point.AccumulatedPointID.Substring(2);
                        if (int.TryParse(numberPart, out int number))
                        {
                            maxNumber = Math.Max(maxNumber, number);
                        }
                    }
                }

                return $"AP{(maxNumber + 1).ToString("D6")}";
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tạo mã điểm tích lũy: {ex.Message}");
            }
        }

        public PagedResult<AccumulatedPoints> SearchPoints(SearchCriteria criteria, string customerId = null)
        {
            try
            {
                // Xây dựng WHERE clause
                List<string> conditions = new List<string> { "ap.DeletedAt IS NULL" };
                List<MySqlParameter> parameters = new List<MySqlParameter>();

                // Filter theo tên khách hàng
                if (!string.IsNullOrEmpty(criteria.SearchTerm))
                {
                    conditions.Add("c.CustomerName LIKE @searchTerm");
                    parameters.Add(new MySqlParameter("@searchTerm", $"%{criteria.SearchTerm}%"));
                }

                // Filter theo khách hàng
                if (!string.IsNullOrEmpty(customerId))
                {
                    conditions.Add("ap.CustomerID = @customerId");
                    parameters.Add(new MySqlParameter("@customerId", customerId));
                }

                string whereClause = "WHERE " + string.Join(" AND ", conditions);

                // Tạo ORDER BY
                string orderBy = "ORDER BY ap.UpdateDate DESC";
                if (!string.IsNullOrEmpty(criteria.SortBy))
                {
                    orderBy = $"ORDER BY {criteria.SortBy} {criteria.SortDirection}";
                }

                // Đếm tổng số bản ghi
                string countQuery = $@"SELECT COUNT(*) FROM accumulated_points ap 
                                     LEFT JOIN customers c ON ap.CustomerID = c.CustomerID 
                                     {whereClause}";
                int totalRecords = Convert.ToInt32(dbHelper.ExecuteScalar(countQuery, parameters.ToArray()));

                // Tính toán phân trang
                int offset = (criteria.PageNumber - 1) * criteria.PageSize;

                // Lấy dữ liệu với phân trang
                string dataQuery = $@"SELECT ap.*, c.CustomerName 
                                    FROM accumulated_points ap
                                    LEFT JOIN customers c ON ap.CustomerID = c.CustomerID
                                    {whereClause} {orderBy} LIMIT {criteria.PageSize} OFFSET {offset}";
                DataTable dt = dbHelper.ExecuteQuery(dataQuery, parameters.ToArray());

                return new PagedResult<AccumulatedPoints>
                {
                    Data = ConvertDataTableToList(dt),
                    TotalRecords = totalRecords,
                    PageNumber = criteria.PageNumber,
                    PageSize = criteria.PageSize
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tìm kiếm điểm tích lũy: {ex.Message}");
            }
        }

        private List<AccumulatedPoints> ConvertDataTableToList(DataTable dt)
        {
            List<AccumulatedPoints> list = new List<AccumulatedPoints>();
            foreach (DataRow row in dt.Rows)
            {
                var point = MapDataRowToEntity(row);
                
                // Add navigation property if available
                if (!row.IsNull("CustomerName"))
                {
                    point.Customer = new Customer
                    {
                        CustomerID = point.CustomerID,
                        CustomerName = row["CustomerName"].ToString()
                    };
                }
                
                list.Add(point);
            }
            return list;
        }
    }
}

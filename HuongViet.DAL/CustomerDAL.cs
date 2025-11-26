using HuongViet.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace HuongViet.DAL
{
    public class CustomerDAL
    {
        private readonly DatabaseHelper dbHelper;

        public CustomerDAL()
        {
            this.dbHelper = new DatabaseHelper();
        }

        private Customer MapDataRowToEntity(DataRow row)
        {
            return new Customer
            {
                CustomerID = row["CustomerID"].ToString(),
                CustomerName = row["CustomerName"].ToString(),
                CustomerPhoneNum = row["CustomerPhoneNum"].ToString(),
                CustomerEmail = row.IsNull("CustomerEmail") ? null : row["CustomerEmail"].ToString(),
                CustomerDOB = row.IsNull("CustomerDOB") ? (DateTime?)null : Convert.ToDateTime(row["CustomerDOB"]),
                CusAssignDate = Convert.ToDateTime(row["CusAssignDate"]),
                DeletedAt = row.IsNull("DeletedAt") ? (DateTime?)null : Convert.ToDateTime(row["DeletedAt"]),
                CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                UpdatedAt = Convert.ToDateTime(row["UpdatedAt"])
            };
        }

        public List<Customer> GetAll()
        {
            string query = @"SELECT * FROM customers 
                           WHERE DeletedAt IS NULL 
                           ORDER BY CustomerName";
            DataTable dt = dbHelper.ExecuteQuery(query);
            return ConvertDataTableToList(dt);
        }

        public Customer GetById(string id)
        {
            string query = @"SELECT * FROM customers 
                           WHERE CustomerID = @id AND DeletedAt IS NULL";
            MySqlParameter[] parameters = { new MySqlParameter("@id", id) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            
            if (dt.Rows.Count > 0)
            {
                return MapDataRowToEntity(dt.Rows[0]);
            }
            return null;
        }

        public Customer GetByPhoneNumber(string phoneNumber)
        {
            string query = @"SELECT * FROM customers 
                           WHERE CustomerPhoneNum = @phoneNumber AND DeletedAt IS NULL";
            MySqlParameter[] parameters = { new MySqlParameter("@phoneNumber", phoneNumber) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            
            if (dt.Rows.Count > 0)
            {
                return MapDataRowToEntity(dt.Rows[0]);
            }
            return null;
        }

        public List<Customer> SearchByName(string name)
        {
            string query = @"SELECT * FROM customers 
                           WHERE CustomerName LIKE @name AND DeletedAt IS NULL 
                           ORDER BY CustomerName";
            MySqlParameter[] parameters = { new MySqlParameter("@name", $"%{name}%") };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            return ConvertDataTableToList(dt);
        }

        public bool Insert(Customer customer)
        {
            try
            {
                string query = @"INSERT INTO customers (CustomerID, CustomerName, CustomerPhoneNum, 
                               CustomerEmail, CustomerDOB, CusAssignDate, CreatedAt, UpdatedAt) 
                               VALUES (@CustomerID, @CustomerName, @CustomerPhoneNum, 
                               @CustomerEmail, @CustomerDOB, @CusAssignDate, @CreatedAt, @UpdatedAt)";
                
                MySqlParameter[] parameters = 
                {
                    new MySqlParameter("@CustomerID", customer.CustomerID),
                    new MySqlParameter("@CustomerName", customer.CustomerName),
                    new MySqlParameter("@CustomerPhoneNum", customer.CustomerPhoneNum),
                    new MySqlParameter("@CustomerEmail", (object)customer.CustomerEmail ?? DBNull.Value),
                    new MySqlParameter("@CustomerDOB", (object)customer.CustomerDOB ?? DBNull.Value),
                    new MySqlParameter("@CusAssignDate", customer.CusAssignDate),
                    new MySqlParameter("@CreatedAt", customer.CreatedAt),
                    new MySqlParameter("@UpdatedAt", customer.UpdatedAt)
                };
                
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm khách hàng: {ex.Message}");
            }
        }

        public bool Update(Customer customer)
        {
            try
            {
                string query = @"UPDATE customers SET CustomerName = @CustomerName, 
                               CustomerPhoneNum = @CustomerPhoneNum, CustomerEmail = @CustomerEmail, 
                               CustomerDOB = @CustomerDOB, UpdatedAt = @UpdatedAt 
                               WHERE CustomerID = @CustomerID AND DeletedAt IS NULL";
                
                MySqlParameter[] parameters = 
                {
                    new MySqlParameter("@CustomerID", customer.CustomerID),
                    new MySqlParameter("@CustomerName", customer.CustomerName),
                    new MySqlParameter("@CustomerPhoneNum", customer.CustomerPhoneNum),
                    new MySqlParameter("@CustomerEmail", (object)customer.CustomerEmail ?? DBNull.Value),
                    new MySqlParameter("@CustomerDOB", (object)customer.CustomerDOB ?? DBNull.Value),
                    new MySqlParameter("@UpdatedAt", DateTime.Now)
                };
                
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật khách hàng: {ex.Message}");
            }
        }

        public bool Delete(string id)
        {
            try
            {
                // Soft delete
                string query = "UPDATE customers SET DeletedAt = @DeletedAt WHERE CustomerID = @id";
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
                throw new Exception($"Lỗi khi xóa khách hàng: {ex.Message}");
            }
        }

        public bool Exists(string id)
        {
            string query = "SELECT COUNT(*) FROM customers WHERE CustomerID = @id AND DeletedAt IS NULL";
            MySqlParameter[] parameters = { new MySqlParameter("@id", id) };
            int count = Convert.ToInt32(dbHelper.ExecuteScalar(query, parameters));
            return count > 0;
        }

        public bool IsPhoneNumberExists(string phoneNumber, string excludeCustomerId = null)
        {
            string query = "SELECT COUNT(*) FROM customers WHERE CustomerPhoneNum = @phoneNumber AND DeletedAt IS NULL";
            List<MySqlParameter> parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@phoneNumber", phoneNumber)
            };

            if (!string.IsNullOrEmpty(excludeCustomerId))
            {
                query += " AND CustomerID != @excludeCustomerId";
                parameters.Add(new MySqlParameter("@excludeCustomerId", excludeCustomerId));
            }

            int count = Convert.ToInt32(dbHelper.ExecuteScalar(query, parameters.ToArray()));
            return count > 0;
        }

        public PagedResult<Customer> SearchCustomers(SearchCriteria criteria)
        {
            try
            {
                // Xây dựng WHERE clause
                List<string> conditions = new List<string> { "DeletedAt IS NULL" };
                List<MySqlParameter> parameters = new List<MySqlParameter>();

                // Filter theo tên hoặc số điện thoại
                if (!string.IsNullOrEmpty(criteria.SearchTerm))
                {
                    conditions.Add("(CustomerName LIKE @searchTerm OR CustomerPhoneNum LIKE @searchTerm)");
                    parameters.Add(new MySqlParameter("@searchTerm", $"%{criteria.SearchTerm}%"));
                }

                string whereClause = "WHERE " + string.Join(" AND ", conditions);

                // Tạo ORDER BY
                string orderBy = "ORDER BY CustomerName ASC";
                if (!string.IsNullOrEmpty(criteria.SortBy))
                {
                    orderBy = $"ORDER BY {criteria.SortBy} {criteria.SortDirection}";
                }

                // Đếm tổng số bản ghi
                string countQuery = $@"SELECT COUNT(*) FROM customers {whereClause}";
                int totalRecords = Convert.ToInt32(dbHelper.ExecuteScalar(countQuery, parameters.ToArray()));

                // Tính toán phân trang
                int offset = (criteria.PageNumber - 1) * criteria.PageSize;

                // Lấy dữ liệu với phân trang
                string dataQuery = $@"SELECT * FROM customers {whereClause} {orderBy} 
                                    LIMIT {criteria.PageSize} OFFSET {offset}";
                DataTable dt = dbHelper.ExecuteQuery(dataQuery, parameters.ToArray());

                return new PagedResult<Customer>
                {
                    Data = ConvertDataTableToList(dt),
                    TotalRecords = totalRecords,
                    PageNumber = criteria.PageNumber,
                    PageSize = criteria.PageSize
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tìm kiếm khách hàng: {ex.Message}");
            }
        }

        private List<Customer> ConvertDataTableToList(DataTable dt)
        {
            List<Customer> list = new List<Customer>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapDataRowToEntity(row));
            }
            return list;
        }
    }
}

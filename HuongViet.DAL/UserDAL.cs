using HuongViet.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace HuongViet.DAL
{
    public class UserDAL
    {
        private readonly DatabaseHelper dbHelper;

        public UserDAL()
        {
            this.dbHelper = new DatabaseHelper();
        }

        private User MapDataRowToEntity(DataRow row)
        {
            return new User
            {
                UserID = row["UserID"].ToString(),
                LastName = row["LastName"].ToString(),
                FirstName = row["FirstName"].ToString(),
                PhoneNumber = row["PhoneNumber"].ToString(),
                UserName = row["UserName"].ToString(),
                Password = row["Password"].ToString(),
                PositionID = row["PositionID"].ToString(),
                RoleID = row["RoleID"].ToString(),
                Status = (UserStatus)Enum.Parse(typeof(UserStatus), row["Status"].ToString()),
                CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                UpdatedAt = Convert.ToDateTime(row["UpdatedAt"])
            };
        }

        public List<User> GetAll()
        {
            string query = "SELECT * FROM users WHERE DeletedAt IS NULL";
            DataTable dt = dbHelper.ExecuteQuery(query);
            return ConvertDataTableToList(dt);
        }

        public User GetById(string id)
        {
            string query = "SELECT * FROM users WHERE UserID = @id AND DeletedAt IS NULL";
            MySqlParameter[] parameters = { new MySqlParameter("@id", id) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            
            if (dt.Rows.Count > 0)
                return MapDataRowToEntity(dt.Rows[0]);
            return null;
        }

        public bool Insert(User user)
        {
            try
            {
                string query = @"INSERT INTO users (UserID, LastName, FirstName, PhoneNumber, UserName, Password, 
                               PositionID, RoleID, Status, CreatedAt, UpdatedAt) 
                               VALUES (@UserID, @LastName, @FirstName, @PhoneNumber, @UserName, @Password, 
                               @PositionID, @RoleID, @Status, @CreatedAt, @UpdatedAt)";
                
                MySqlParameter[] parameters = 
                {
                    new MySqlParameter("@UserID", user.UserID),
                    new MySqlParameter("@LastName", user.LastName),
                    new MySqlParameter("@FirstName", user.FirstName),
                    new MySqlParameter("@PhoneNumber", user.PhoneNumber),
                    new MySqlParameter("@UserName", user.UserName),
                    new MySqlParameter("@Password", user.Password),
                    new MySqlParameter("@PositionID", user.PositionID),
                    new MySqlParameter("@RoleID", user.RoleID),
                    new MySqlParameter("@Status", user.Status.ToString()),
                    new MySqlParameter("@CreatedAt", user.CreatedAt),
                    new MySqlParameter("@UpdatedAt", user.UpdatedAt)
                };
                
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm user: {ex.Message}");
            }
        }

        public bool Update(User user)
        {
            try
            {
                string query = @"UPDATE users SET LastName = @LastName, FirstName = @FirstName, 
                               PhoneNumber = @PhoneNumber, UserName = @UserName, Password = @Password,
                               PositionID = @PositionID, RoleID = @RoleID, Status = @Status, 
                               UpdatedAt = @UpdatedAt WHERE UserID = @UserID AND DeletedAt IS NULL";
                
                MySqlParameter[] parameters = 
                {
                    new MySqlParameter("@UserID", user.UserID),
                    new MySqlParameter("@LastName", user.LastName),
                    new MySqlParameter("@FirstName", user.FirstName),
                    new MySqlParameter("@PhoneNumber", user.PhoneNumber),
                    new MySqlParameter("@UserName", user.UserName),
                    new MySqlParameter("@Password", user.Password),
                    new MySqlParameter("@PositionID", user.PositionID),
                    new MySqlParameter("@RoleID", user.RoleID),
                    new MySqlParameter("@Status", user.Status.ToString()),
                    new MySqlParameter("@UpdatedAt", DateTime.Now)
                };
                
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật user: {ex.Message}");
            }
        }

        public bool Delete(string id)
        {
            try
            {
                string query = "UPDATE users SET DeletedAt = @DeletedAt, UpdatedAt = @UpdatedAt WHERE UserID = @id AND DeletedAt IS NULL";
                MySqlParameter[] parameters = 
                { 
                    new MySqlParameter("@id", id),
                    new MySqlParameter("@DeletedAt", DateTime.Now),
                    new MySqlParameter("@UpdatedAt", DateTime.Now)
                };
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa user: {ex.Message}");
            }
        }

        public bool Exists(string id)
        {
            string query = "SELECT COUNT(*) FROM users WHERE UserID = @id AND DeletedAt IS NULL";
            MySqlParameter[] parameters = { new MySqlParameter("@id", id) };
            int count = Convert.ToInt32(dbHelper.ExecuteScalar(query, parameters));
            return count > 0;
        }

        private List<User> ConvertDataTableToList(DataTable dt)
        {
            List<User> list = new List<User>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapDataRowToEntity(row));
            }
            return list;
        }

        // Phương thức đặc biệt cho User
        public User GetByUserName(string userName)
        {
            string query = "SELECT * FROM users WHERE UserName = @userName AND DeletedAt IS NULL";
            MySqlParameter[] parameters = { new MySqlParameter("@userName", userName) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            
            if (dt.Rows.Count > 0)
                return MapDataRowToEntity(dt.Rows[0]);
            return null;
        }

        public bool IsUserNameExists(string userName, string excludeUserId = null)
        {
            string query = "SELECT COUNT(*) FROM users WHERE UserName = @userName AND DeletedAt IS NULL";
            List<MySqlParameter> parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@userName", userName)
            };

            if (!string.IsNullOrEmpty(excludeUserId))
            {
                query += " AND UserID != @excludeUserId";
                parameters.Add(new MySqlParameter("@excludeUserId", excludeUserId));
            }

            int count = Convert.ToInt32(dbHelper.ExecuteScalar(query, parameters.ToArray()));
            return count > 0;
        }

        public List<User> GetUsersByRole(string roleId)
        {
            string query = "SELECT * FROM users WHERE RoleID = @roleId AND DeletedAt IS NULL";
            MySqlParameter[] parameters = { new MySqlParameter("@roleId", roleId) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            return ConvertDataTableToList(dt);
        }

        public List<User> GetUsersByPosition(string positionId)
        {
            string query = "SELECT * FROM users WHERE PositionID = @positionId AND DeletedAt IS NULL";
            MySqlParameter[] parameters = { new MySqlParameter("@positionId", positionId) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            return ConvertDataTableToList(dt);
        }

        public List<User> GetUsersByStatus(UserStatus status)
        {
            string query = "SELECT * FROM users WHERE Status = @status AND DeletedAt IS NULL";
            MySqlParameter[] parameters = { new MySqlParameter("@status", status.ToString()) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            return ConvertDataTableToList(dt);
        }

        public bool ChangePassword(string userId, string newPassword)
        {
            try
            {
                string query = "UPDATE users SET Password = @password, UpdatedAt = @UpdatedAt WHERE UserID = @userId AND DeletedAt IS NULL";
                MySqlParameter[] parameters = 
                {
                    new MySqlParameter("@password", newPassword),
                    new MySqlParameter("@UpdatedAt", DateTime.Now),
                    new MySqlParameter("@userId", userId)
                };
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi đổi mật khẩu: {ex.Message}");
            }
        }

        public bool ChangeStatus(string userId, UserStatus status)
        {
            try
            {
                string query = "UPDATE users SET Status = @status, UpdatedAt = @UpdatedAt WHERE UserID = @userId AND DeletedAt IS NULL";
                MySqlParameter[] parameters = 
                {
                    new MySqlParameter("@status", status.ToString()),
                    new MySqlParameter("@UpdatedAt", DateTime.Now),
                    new MySqlParameter("@userId", userId)
                };
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thay đổi trạng thái: {ex.Message}");
            }
        }

        public PagedResult<User> Search(SearchCriteria criteria)
        {
            try
            {
                // Tạo điều kiện WHERE
                string whereClause = "";
                List<MySqlParameter> parameters = new List<MySqlParameter>();

                if (!string.IsNullOrEmpty(criteria.SearchTerm))
                {
                    whereClause = @"WHERE (LastName LIKE @searchTerm OR FirstName LIKE @searchTerm OR 
                                   UserName LIKE @searchTerm OR PhoneNumber LIKE @searchTerm) AND DeletedAt IS NULL";
                    parameters.Add(new MySqlParameter("@searchTerm", $"%{criteria.SearchTerm}%"));
                }
                else
                {
                    whereClause = "WHERE DeletedAt IS NULL";
                }

                // Tạo ORDER BY
                string orderBy = "";
                if (!string.IsNullOrEmpty(criteria.SortBy))
                {
                    orderBy = $"ORDER BY {criteria.SortBy} {criteria.SortDirection}";
                }
                else
                {
                    orderBy = "ORDER BY CreatedAt DESC";
                }

                // Đếm tổng số bản ghi
                string countQuery = $"SELECT COUNT(*) FROM users {whereClause}";
                int totalRecords = Convert.ToInt32(dbHelper.ExecuteScalar(countQuery, parameters.ToArray()));

                // Tính toán phân trang
                int offset = (criteria.PageNumber - 1) * criteria.PageSize;

                // Lấy dữ liệu với phân trang
                string dataQuery = $"SELECT * FROM users {whereClause} {orderBy} LIMIT {criteria.PageSize} OFFSET {offset}";
                DataTable dt = dbHelper.ExecuteQuery(dataQuery, parameters.ToArray());

                return new PagedResult<User>
                {
                    Data = ConvertDataTableToList(dt),
                    TotalRecords = totalRecords,
                    PageNumber = criteria.PageNumber,
                    PageSize = criteria.PageSize
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tìm kiếm user: {ex.Message}");
            }
        }

        // Lấy danh sách user với thông tin chi tiết (join với bảng khác)
        public PagedResult<User> GetUsersWithDetails(SearchCriteria criteria, string positionId = null, UserStatus? status = null)
        {
            try
            {
                // Tạo điều kiện WHERE
                string whereClause = "";
                List<MySqlParameter> parameters = new List<MySqlParameter>();
                List<string> conditions = new List<string>();

                // Điều kiện cơ bản
                conditions.Add("u.DeletedAt IS NULL");

                // Tìm kiếm keyword
                if (!string.IsNullOrEmpty(criteria.SearchTerm))
                {
                    conditions.Add(@"(u.LastName LIKE @searchTerm OR u.FirstName LIKE @searchTerm OR 
                                   u.UserName LIKE @searchTerm OR u.PhoneNumber LIKE @searchTerm OR
                                   p.PositionName LIKE @searchTerm OR r.RoleName LIKE @searchTerm OR
                                   d.DepartmentName LIKE @searchTerm)");
                    parameters.Add(new MySqlParameter("@searchTerm", $"%{criteria.SearchTerm}%"));
                }

                // Filter theo PositionID
                if (!string.IsNullOrEmpty(positionId))
                {
                    conditions.Add("u.PositionID = @positionId");
                    parameters.Add(new MySqlParameter("@positionId", positionId));
                }

                // Filter theo Status
                if (status.HasValue)
                {
                    conditions.Add("u.Status = @status");
                    parameters.Add(new MySqlParameter("@status", status.Value.ToString()));
                }

                whereClause = "WHERE " + string.Join(" AND ", conditions);

                // Tạo ORDER BY
                string orderBy = "";
                if (!string.IsNullOrEmpty(criteria.SortBy))
                {
                    orderBy = $"ORDER BY {criteria.SortBy} {criteria.SortDirection}";
                }
                else
                {
                    orderBy = "ORDER BY u.CreatedAt DESC";
                }

                // Đếm tổng số bản ghi
                string countQuery = @"SELECT COUNT(*) FROM users u
                                    LEFT JOIN positions p ON u.PositionID = p.PositionID AND p.DeletedAt IS NULL
                                    LEFT JOIN roles r ON u.RoleID = r.RoleID AND r.DeletedAt IS NULL
                                    LEFT JOIN departments d ON p.DepartmentID = d.DepartmentID AND d.DeletedAt IS NULL " + whereClause;

                int totalRecords = Convert.ToInt32(dbHelper.ExecuteScalar(countQuery, parameters.ToArray()));

                // Tính toán phân trang
                int offset = (criteria.PageNumber - 1) * criteria.PageSize;

                // Lấy dữ liệu với phân trang
                string dataQuery = @"SELECT u.*, p.PositionName, r.RoleName, r.RoleCode, 
                                   d.DepartmentName, d.DepartmentID
                                   FROM users u
                                   LEFT JOIN positions p ON u.PositionID = p.PositionID AND p.DeletedAt IS NULL
                                   LEFT JOIN roles r ON u.RoleID = r.RoleID AND r.DeletedAt IS NULL
                                   LEFT JOIN departments d ON p.DepartmentID = d.DepartmentID AND d.DeletedAt IS NULL " +
                                   whereClause + " " + orderBy + $" LIMIT {criteria.PageSize} OFFSET {offset}";

                DataTable dt = dbHelper.ExecuteQuery(dataQuery, parameters.ToArray());
                List<User> users = new List<User>();

                foreach (DataRow row in dt.Rows)
                {
                    var user = MapDataRowToEntity(row);
                    
                    // Thêm thông tin Position và Role
                    if (!row.IsNull("PositionName"))
                    {
                        user.Position = new Position
                        {
                            PositionID = user.PositionID,
                            PositionName = row["PositionName"].ToString(),
                            DepartmentID = row["DepartmentID"].ToString(),
                            Department = new Department
                            {
                                DepartmentID = row["DepartmentID"].ToString(),
                                DepartmentName = row["DepartmentName"].ToString()
                            }
                        };
                    }

                    if (!row.IsNull("RoleName"))
                    {
                        user.Role = new Role
                        {
                            RoleID = user.RoleID,
                            RoleName = row["RoleName"].ToString(),
                            RoleCode = row["RoleCode"].ToString()
                        };
                    }

                    users.Add(user);
                }

                return new PagedResult<User>
                {
                    Data = users,
                    TotalRecords = totalRecords,
                    PageNumber = criteria.PageNumber,
                    PageSize = criteria.PageSize
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách user với thông tin chi tiết: {ex.Message}");
            }
        }
    }
}

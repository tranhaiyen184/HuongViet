using HuongViet.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace HuongViet.DAL
{
    public class PositionDAL
    {
        private readonly DatabaseHelper dbHelper;

        public PositionDAL()
        {
            this.dbHelper = new DatabaseHelper();
        }

        private Position MapDataRowToEntity(DataRow row)
        {
            return new Position
            {
                PositionID = row["PositionID"].ToString(),
                PositionName = row["PositionName"].ToString(),
                DepartmentID = row["DepartmentID"].ToString(),
                CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                UpdatedAt = Convert.ToDateTime(row["UpdatedAt"])
            };
        }

        public List<Position> GetAll()
        {
            string query = "SELECT * FROM positions WHERE DeletedAt IS NULL";
            DataTable dt = dbHelper.ExecuteQuery(query);
            return ConvertDataTableToList(dt);
        }

        public Position GetById(string id)
        {
            string query = "SELECT * FROM positions WHERE PositionID = @id AND DeletedAt IS NULL";
            MySqlParameter[] parameters = { new MySqlParameter("@id", id) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            
            if (dt.Rows.Count > 0)
                return MapDataRowToEntity(dt.Rows[0]);
            return null;
        }

        public bool Insert(Position position)
        {
            try
            {
                string query = @"INSERT INTO positions (PositionID, PositionName, DepartmentID, CreatedAt, UpdatedAt) 
                               VALUES (@PositionID, @PositionName, @DepartmentID, @CreatedAt, @UpdatedAt)";
                
                MySqlParameter[] parameters = 
                {
                    new MySqlParameter("@PositionID", position.PositionID),
                    new MySqlParameter("@PositionName", position.PositionName),
                    new MySqlParameter("@DepartmentID", position.DepartmentID),
                    new MySqlParameter("@CreatedAt", DateTime.Now),
                    new MySqlParameter("@UpdatedAt", DateTime.Now)
                };
                
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm vị trí: {ex.Message}");
            }
        }

        public bool Update(Position position)
        {
            try
            {
                string query = @"UPDATE positions SET PositionName = @PositionName, DepartmentID = @DepartmentID, 
                               UpdatedAt = @UpdatedAt WHERE PositionID = @PositionID AND DeletedAt IS NULL";
                
                MySqlParameter[] parameters = 
                {
                    new MySqlParameter("@PositionID", position.PositionID),
                    new MySqlParameter("@PositionName", position.PositionName),
                    new MySqlParameter("@DepartmentID", position.DepartmentID),
                    new MySqlParameter("@UpdatedAt", DateTime.Now)
                };
                
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật vị trí: {ex.Message}");
            }
        }

        public bool Delete(string id)
        {
            try
            {
                string query = "UPDATE positions SET DeletedAt = @DeletedAt, UpdatedAt = @UpdatedAt WHERE PositionID = @id AND DeletedAt IS NULL";
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
                throw new Exception($"Lỗi khi xóa vị trí: {ex.Message}");
            }
        }

        public bool Exists(string id)
        {
            string query = "SELECT COUNT(*) FROM positions WHERE PositionID = @id AND DeletedAt IS NULL";
            MySqlParameter[] parameters = { new MySqlParameter("@id", id) };
            int count = Convert.ToInt32(dbHelper.ExecuteScalar(query, parameters));
            return count > 0;
        }

        private List<Position> ConvertDataTableToList(DataTable dt)
        {
            List<Position> list = new List<Position>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapDataRowToEntity(row));
            }
            return list;
        }

        public PagedResult<Position> Search(SearchCriteria criteria)
        {
            try
            {
                // Tạo điều kiện WHERE
                string whereClause = "";
                List<MySqlParameter> parameters = new List<MySqlParameter>();

                if (!string.IsNullOrEmpty(criteria.SearchTerm))
                {
                    whereClause = "WHERE (p.PositionName LIKE @searchTerm OR d.DepartmentName LIKE @searchTerm) AND p.DeletedAt IS NULL";
                    parameters.Add(new MySqlParameter("@searchTerm", $"%{criteria.SearchTerm}%"));
                }
                else
                {
                    whereClause = "WHERE p.DeletedAt IS NULL";
                }

                // Tạo ORDER BY
                string orderBy = "";
                if (!string.IsNullOrEmpty(criteria.SortBy))
                {
                    orderBy = $"ORDER BY {criteria.SortBy} {criteria.SortDirection}";
                }
                else
                {
                    orderBy = "ORDER BY p.CreatedAt DESC";
                }

                // Đếm tổng số bản ghi
                string countQuery = @"SELECT COUNT(*) FROM positions p
                                    LEFT JOIN departments d ON p.DepartmentID = d.DepartmentID AND d.DeletedAt IS NULL " + whereClause;
                int totalRecords = Convert.ToInt32(dbHelper.ExecuteScalar(countQuery, parameters.ToArray()));

                // Tính toán phân trang
                int offset = (criteria.PageNumber - 1) * criteria.PageSize;

                // Lấy dữ liệu với phân trang
                string dataQuery = @"SELECT p.*, d.DepartmentName
                                   FROM positions p
                                   LEFT JOIN departments d ON p.DepartmentID = d.DepartmentID AND d.DeletedAt IS NULL " +
                                   whereClause + " " + orderBy + $" LIMIT {criteria.PageSize} OFFSET {offset}";

                DataTable dt = dbHelper.ExecuteQuery(dataQuery, parameters.ToArray());
                List<Position> positions = new List<Position>();

                foreach (DataRow row in dt.Rows)
                {
                    var position = MapDataRowToEntity(row);
                    
                    // Thêm thông tin Department
                    if (!row.IsNull("DepartmentName"))
                    {
                        position.Department = new Department
                        {
                            DepartmentID = position.DepartmentID,
                            DepartmentName = row["DepartmentName"].ToString()
                        };
                    }

                    positions.Add(position);
                }

                return new PagedResult<Position>
                {
                    Data = positions,
                    TotalRecords = totalRecords,
                    PageNumber = criteria.PageNumber,
                    PageSize = criteria.PageSize
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tìm kiếm vị trí: {ex.Message}");
            }
        }

        // Phương thức đặc biệt cho Position
        public Position GetByPositionName(string positionName)
        {
            string query = "SELECT * FROM positions WHERE PositionName = @positionName AND DeletedAt IS NULL";
            MySqlParameter[] parameters = { new MySqlParameter("@positionName", positionName) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            
            if (dt.Rows.Count > 0)
                return MapDataRowToEntity(dt.Rows[0]);
            return null;
        }

        public bool IsPositionNameExists(string positionName, string excludePositionId = null)
        {
            string query = "SELECT COUNT(*) FROM positions WHERE PositionName = @positionName AND DeletedAt IS NULL";
            List<MySqlParameter> parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@positionName", positionName)
            };

            if (!string.IsNullOrEmpty(excludePositionId))
            {
                query += " AND PositionID != @excludePositionId";
                parameters.Add(new MySqlParameter("@excludePositionId", excludePositionId));
            }

            int count = Convert.ToInt32(dbHelper.ExecuteScalar(query, parameters.ToArray()));
            return count > 0;
        }

        public List<Position> GetPositionsByDepartment(string departmentId)
        {
            string query = "SELECT * FROM positions WHERE DepartmentID = @departmentId AND DeletedAt IS NULL ORDER BY PositionName";
            MySqlParameter[] parameters = { new MySqlParameter("@departmentId", departmentId) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            return ConvertDataTableToList(dt);
        }

        // Lấy danh sách position với số lượng user
        public PagedResult<Position> GetPositionsWithUserCount(SearchCriteria criteria)
        {
            try
            {
                // Tạo điều kiện WHERE
                string whereClause = "";
                List<MySqlParameter> parameters = new List<MySqlParameter>();

                if (!string.IsNullOrEmpty(criteria.SearchTerm))
                {
                    whereClause = "WHERE (p.PositionName LIKE @searchTerm OR d.DepartmentName LIKE @searchTerm) AND p.DeletedAt IS NULL";
                    parameters.Add(new MySqlParameter("@searchTerm", $"%{criteria.SearchTerm}%"));
                }
                else
                {
                    whereClause = "WHERE p.DeletedAt IS NULL";
                }

                // Tạo ORDER BY
                string orderBy = "";
                if (!string.IsNullOrEmpty(criteria.SortBy))
                {
                    orderBy = $"ORDER BY {criteria.SortBy} {criteria.SortDirection}";
                }
                else
                {
                    orderBy = "ORDER BY p.CreatedAt DESC";
                }

                // Đếm tổng số bản ghi
                string countQuery = @"SELECT COUNT(*) FROM positions p
                                    LEFT JOIN departments d ON p.DepartmentID = d.DepartmentID AND d.DeletedAt IS NULL " + whereClause;
                int totalRecords = Convert.ToInt32(dbHelper.ExecuteScalar(countQuery, parameters.ToArray()));

                // Tính toán phân trang
                int offset = (criteria.PageNumber - 1) * criteria.PageSize;

                // Lấy dữ liệu với phân trang
                string dataQuery = @"SELECT p.*, d.DepartmentName, COUNT(u.UserID) as UserCount
                                   FROM positions p
                                   LEFT JOIN departments d ON p.DepartmentID = d.DepartmentID AND d.DeletedAt IS NULL
                                   LEFT JOIN users u ON p.PositionID = u.PositionID AND u.DeletedAt IS NULL " +
                                   whereClause + @" GROUP BY p.PositionID, p.PositionName, p.DepartmentID, p.CreatedAt, p.UpdatedAt, p.DeletedAt, d.DepartmentName " +
                                   orderBy + $" LIMIT {criteria.PageSize} OFFSET {offset}";

                DataTable dt = dbHelper.ExecuteQuery(dataQuery, parameters.ToArray());
                List<Position> positions = new List<Position>();

                foreach (DataRow row in dt.Rows)
                {
                    var position = MapDataRowToEntity(row);
                    
                    // Thêm thông tin Department
                    if (!row.IsNull("DepartmentName"))
                    {
                        position.Department = new Department
                        {
                            DepartmentID = position.DepartmentID,
                            DepartmentName = row["DepartmentName"].ToString()
                        };
                    }

                    positions.Add(position);
                }

                return new PagedResult<Position>
                {
                    Data = positions,
                    TotalRecords = totalRecords,
                    PageNumber = criteria.PageNumber,
                    PageSize = criteria.PageSize
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách vị trí với số lượng user: {ex.Message}");
            }
        }

        // Kiểm tra position có đang được sử dụng không
        public bool IsPositionInUse(string positionId)
        {
            string query = "SELECT COUNT(*) FROM users WHERE PositionID = @positionId AND DeletedAt IS NULL";
            MySqlParameter[] parameters = { new MySqlParameter("@positionId", positionId) };
            int count = Convert.ToInt32(dbHelper.ExecuteScalar(query, parameters));
            return count > 0;
        }

        // Lấy danh sách user thuộc position
        public List<User> GetPositionUsers(string positionId)
        {
            string query = "SELECT * FROM users WHERE PositionID = @positionId AND DeletedAt IS NULL ORDER BY LastName, FirstName";
            MySqlParameter[] parameters = { new MySqlParameter("@positionId", positionId) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            
            List<User> users = new List<User>();
            foreach (DataRow row in dt.Rows)
            {
                users.Add(new User
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
                });
            }
            return users;
        }

        // Lấy position với thông tin department
        public Position GetPositionWithDepartment(string positionId)
        {
            string query = @"SELECT p.*, d.DepartmentName
                           FROM positions p
                           LEFT JOIN departments d ON p.DepartmentID = d.DepartmentID AND d.DeletedAt IS NULL
                           WHERE p.PositionID = @positionId AND p.DeletedAt IS NULL";
            MySqlParameter[] parameters = { new MySqlParameter("@positionId", positionId) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            
            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                var position = MapDataRowToEntity(row);
                
                if (!row.IsNull("DepartmentName"))
                {
                    position.Department = new Department
                    {
                        DepartmentID = position.DepartmentID,
                        DepartmentName = row["DepartmentName"].ToString()
                    };
                }
                
                return position;
            }
            return null;
        }

        // Lấy số lượng nhân viên trong position
        public int GetPositionEmployeeCount(string positionId)
        {
            string query = "SELECT COUNT(*) FROM users WHERE PositionID = @positionId AND DeletedAt IS NULL";
            MySqlParameter[] parameters = { new MySqlParameter("@positionId", positionId) };
            return Convert.ToInt32(dbHelper.ExecuteScalar(query, parameters));
        }

        // Chuyển nhân viên sang position khác
        public bool TransferEmployeesToPosition(string fromPositionId, string toPositionId)
        {
            try
            {
                string query = "UPDATE users SET PositionID = @toPositionId, UpdatedAt = @UpdatedAt WHERE PositionID = @fromPositionId AND DeletedAt IS NULL";
                MySqlParameter[] parameters = 
                {
                    new MySqlParameter("@toPositionId", toPositionId),
                    new MySqlParameter("@UpdatedAt", DateTime.Now),
                    new MySqlParameter("@fromPositionId", fromPositionId)
                };
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result >= 0; // Trả về true ngay cả khi không có nhân viên nào để chuyển
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi chuyển nhân viên sang vị trí khác: {ex.Message}");
            }
        }
    }
}

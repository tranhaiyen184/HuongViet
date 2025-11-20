using HuongViet.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace HuongViet.DAL
{
    public class DepartmentDAL
    {
        private readonly DatabaseHelper dbHelper;

        public DepartmentDAL()
        {
            this.dbHelper = new DatabaseHelper();
        }

        private Department MapDataRowToEntity(DataRow row)
        {
            return new Department
            {
                DepartmentID = row["DepartmentID"].ToString(),
                DepartmentName = row["DepartmentName"].ToString(),
                CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                UpdatedAt = Convert.ToDateTime(row["UpdatedAt"])
            };
        }

        public List<Department> GetAll()
        {
            string query = "SELECT * FROM departments WHERE DeletedAt IS NULL";
            DataTable dt = dbHelper.ExecuteQuery(query);
            return ConvertDataTableToList(dt);
        }

        public Department GetById(string id)
        {
            string query = "SELECT * FROM departments WHERE DepartmentID = @id AND DeletedAt IS NULL";
            MySqlParameter[] parameters = { new MySqlParameter("@id", id) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            
            if (dt.Rows.Count > 0)
                return MapDataRowToEntity(dt.Rows[0]);
            return null;
        }

        public bool Insert(Department department)
        {
            try
            {
                string query = @"INSERT INTO departments (DepartmentID, DepartmentName, CreatedAt, UpdatedAt) 
                               VALUES (@DepartmentID, @DepartmentName, @CreatedAt, @UpdatedAt)";
                
                MySqlParameter[] parameters = 
                {
                    new MySqlParameter("@DepartmentID", department.DepartmentID),
                    new MySqlParameter("@DepartmentName", department.DepartmentName),
                    new MySqlParameter("@CreatedAt", DateTime.Now),
                    new MySqlParameter("@UpdatedAt", DateTime.Now)
                };
                
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm phòng ban: {ex.Message}");
            }
        }

        public bool Update(Department department)
        {
            try
            {
                string query = @"UPDATE departments SET DepartmentName = @DepartmentName, 
                               UpdatedAt = @UpdatedAt WHERE DepartmentID = @DepartmentID AND DeletedAt IS NULL";
                
                MySqlParameter[] parameters = 
                {
                    new MySqlParameter("@DepartmentID", department.DepartmentID),
                    new MySqlParameter("@DepartmentName", department.DepartmentName),
                    new MySqlParameter("@UpdatedAt", DateTime.Now)
                };
                
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật phòng ban: {ex.Message}");
            }
        }

        public bool Delete(string id)
        {
            try
            {
                string query = "UPDATE departments SET DeletedAt = @DeletedAt, UpdatedAt = @UpdatedAt WHERE DepartmentID = @id AND DeletedAt IS NULL";
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
                throw new Exception($"Lỗi khi xóa phòng ban: {ex.Message}");
            }
        }

        public bool Exists(string id)
        {
            string query = "SELECT COUNT(*) FROM departments WHERE DepartmentID = @id AND DeletedAt IS NULL";
            MySqlParameter[] parameters = { new MySqlParameter("@id", id) };
            int count = Convert.ToInt32(dbHelper.ExecuteScalar(query, parameters));
            return count > 0;
        }

        public PagedResult<Department> Search(SearchCriteria criteria)
        {
            try
            {
                // Tạo điều kiện WHERE
                string whereClause = "";
                List<MySqlParameter> parameters = new List<MySqlParameter>();

                if (!string.IsNullOrEmpty(criteria.SearchTerm))
                {
                    whereClause = "WHERE DepartmentName LIKE @searchTerm AND DeletedAt IS NULL";
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
                string countQuery = $"SELECT COUNT(*) FROM departments {whereClause}";
                int totalRecords = Convert.ToInt32(dbHelper.ExecuteScalar(countQuery, parameters.ToArray()));

                // Tính toán phân trang
                int offset = (criteria.PageNumber - 1) * criteria.PageSize;

                // Lấy dữ liệu với phân trang
                string dataQuery = $"SELECT * FROM departments {whereClause} {orderBy} LIMIT {criteria.PageSize} OFFSET {offset}";
                DataTable dt = dbHelper.ExecuteQuery(dataQuery, parameters.ToArray());

                return new PagedResult<Department>
                {
                    Data = ConvertDataTableToList(dt),
                    TotalRecords = totalRecords,
                    PageNumber = criteria.PageNumber,
                    PageSize = criteria.PageSize
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tìm kiếm phòng ban: {ex.Message}");
            }
        }

        private List<Department> ConvertDataTableToList(DataTable dt)
        {
            List<Department> list = new List<Department>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapDataRowToEntity(row));
            }
            return list;
        }

        // Phương thức đặc biệt cho Department
        public Department GetByDepartmentName(string departmentName)
        {
            string query = "SELECT * FROM departments WHERE DepartmentName = @departmentName AND DeletedAt IS NULL";
            MySqlParameter[] parameters = { new MySqlParameter("@departmentName", departmentName) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            
            if (dt.Rows.Count > 0)
                return MapDataRowToEntity(dt.Rows[0]);
            return null;
        }

        public bool IsDepartmentNameExists(string departmentName, string excludeDepartmentId = null)
        {
            string query = "SELECT COUNT(*) FROM departments WHERE DepartmentName = @departmentName AND DeletedAt IS NULL";
            List<MySqlParameter> parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@departmentName", departmentName)
            };

            if (!string.IsNullOrEmpty(excludeDepartmentId))
            {
                query += " AND DepartmentID != @excludeDepartmentId";
                parameters.Add(new MySqlParameter("@excludeDepartmentId", excludeDepartmentId));
            }

            int count = Convert.ToInt32(dbHelper.ExecuteScalar(query, parameters.ToArray()));
            return count > 0;
        }

        // Lấy danh sách department với số lượng position
        public PagedResult<Department> GetDepartmentWithPositionCount(SearchCriteria criteria)
        {
            try
            {
                // Tạo điều kiện WHERE
                string whereClause = "";
                List<MySqlParameter> parameters = new List<MySqlParameter>();

                if (!string.IsNullOrEmpty(criteria.SearchTerm))
                {
                    whereClause = "WHERE d.DepartmentName LIKE @searchTerm AND d.DeletedAt IS NULL";
                    parameters.Add(new MySqlParameter("@searchTerm", $"%{criteria.SearchTerm}%"));
                }
                else
                {
                    whereClause = "WHERE d.DeletedAt IS NULL";
                }

                // Tạo ORDER BY
                string orderBy = "";
                if (!string.IsNullOrEmpty(criteria.SortBy))
                {
                    orderBy = $"ORDER BY {criteria.SortBy} {criteria.SortDirection}";
                }
                else
                {
                    orderBy = "ORDER BY d.CreatedAt DESC";
                }

                // Đếm tổng số bản ghi
                string countQuery = @"SELECT COUNT(*) FROM departments d " + whereClause;
                int totalRecords = Convert.ToInt32(dbHelper.ExecuteScalar(countQuery, parameters.ToArray()));

                // Tính toán phân trang
                int offset = (criteria.PageNumber - 1) * criteria.PageSize;

                // Lấy dữ liệu với phân trang
                string dataQuery = @"SELECT d.*, COUNT(p.PositionID) as PositionCount
                                   FROM departments d
                                   LEFT JOIN positions p ON d.DepartmentID = p.DepartmentID AND p.DeletedAt IS NULL " +
                                   whereClause + @" GROUP BY d.DepartmentID, d.DepartmentName, d.CreatedAt, d.UpdatedAt, d.DeletedAt " +
                                   orderBy + $" LIMIT {criteria.PageSize} OFFSET {offset}";

                DataTable dt = dbHelper.ExecuteQuery(dataQuery, parameters.ToArray());
                List<Department> Department = new List<Department>();

                foreach (DataRow row in dt.Rows)
                {
                    var department = MapDataRowToEntity(row);
                    // Có thể thêm thuộc tính PositionCount vào model Department nếu cần
                    Department.Add(department);
                }

                return new PagedResult<Department>
                {
                    Data = Department,
                    TotalRecords = totalRecords,
                    PageNumber = criteria.PageNumber,
                    PageSize = criteria.PageSize
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách phòng ban với số lượng vị trí: {ex.Message}");
            }
        }

        // Kiểm tra department có đang được sử dụng không
        public bool IsDepartmentInUse(string departmentId)
        {
            string query = "SELECT COUNT(*) FROM positions WHERE DepartmentID = @departmentId AND DeletedAt IS NULL";
            MySqlParameter[] parameters = { new MySqlParameter("@departmentId", departmentId) };
            int count = Convert.ToInt32(dbHelper.ExecuteScalar(query, parameters));
            return count > 0;
        }

        // Lấy danh sách position thuộc department
        public List<Position> GetDepartmentPosition(string departmentId)
        {
            string query = "SELECT * FROM positions WHERE DepartmentID = @departmentId AND DeletedAt IS NULL ORDER BY PositionName";
            MySqlParameter[] parameters = { new MySqlParameter("@departmentId", departmentId) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            
            List<Position> Position = new List<Position>();
            foreach (DataRow row in dt.Rows)
            {
                Position.Add(new Position
                {
                    PositionID = row["PositionID"].ToString(),
                    PositionName = row["PositionName"].ToString(),
                    DepartmentID = row["DepartmentID"].ToString(),
                    CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                    UpdatedAt = Convert.ToDateTime(row["UpdatedAt"])
                });
            }
            return Position;
        }

        // Lấy số lượng nhân viên trong department
        public int GetDepartmentEmployeeCount(string departmentId)
        {
            string query = @"SELECT COUNT(u.UserID) FROM users u
                           INNER JOIN positions p ON u.PositionID = p.PositionID
                           WHERE p.DepartmentID = @departmentId AND u.DeletedAt IS NULL AND p.DeletedAt IS NULL";
            MySqlParameter[] parameters = { new MySqlParameter("@departmentId", departmentId) };
            return Convert.ToInt32(dbHelper.ExecuteScalar(query, parameters));
        }

        // Lấy danh sách nhân viên trong department
        public List<User> GetDepartmentEmployees(string departmentId)
        {
            string query = @"SELECT u.* FROM users u
                           INNER JOIN positions p ON u.PositionID = p.PositionID
                           WHERE p.DepartmentID = @departmentId AND u.DeletedAt IS NULL AND p.DeletedAt IS NULL
                           ORDER BY u.LastName, u.FirstName";
            MySqlParameter[] parameters = { new MySqlParameter("@departmentId", departmentId) };
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

        // Lấy thống kê department
        public object GetDepartmenttatistics(string departmentId)
        {
            try
            {
                string query = @"SELECT 
                               COUNT(DISTINCT p.PositionID) as PositionCount,
                               COUNT(DISTINCT u.UserID) as EmployeeCount,
                               COUNT(DISTINCT CASE WHEN u.Status = 'active' THEN u.UserID END) as ActiveEmployeeCount,
                               COUNT(DISTINCT CASE WHEN u.Status = 'inactive' THEN u.UserID END) as InactiveEmployeeCount
                               FROM departments d
                               LEFT JOIN positions p ON d.DepartmentID = p.DepartmentID AND p.DeletedAt IS NULL
                               LEFT JOIN users u ON p.PositionID = u.PositionID AND u.DeletedAt IS NULL
                               WHERE d.DepartmentID = @departmentId AND d.DeletedAt IS NULL";

                MySqlParameter[] parameters = { new MySqlParameter("@departmentId", departmentId) };
                DataTable dt = dbHelper.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    var row = dt.Rows[0];
                    return new
                    {
                        PositionCount = Convert.ToInt32(row["PositionCount"]),
                        EmployeeCount = Convert.ToInt32(row["EmployeeCount"]),
                        ActiveEmployeeCount = Convert.ToInt32(row["ActiveEmployeeCount"]),
                        InactiveEmployeeCount = Convert.ToInt32(row["InactiveEmployeeCount"])
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy thống kê phòng ban: {ex.Message}");
            }
        }
    }
}

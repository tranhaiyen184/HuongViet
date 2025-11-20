using HuongViet.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace HuongViet.DAL
{
    public class RoleDAL
    {
        private readonly DatabaseHelper dbHelper;

        public RoleDAL()
        {
            this.dbHelper = new DatabaseHelper();
        }

        private Role MapDataRowToEntity(DataRow row)
        {
            return new Role
            {
                RoleID = row["RoleID"].ToString(),
                RoleCode = row["RoleCode"].ToString(),
                RoleName = row["RoleName"].ToString(),
                CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                UpdatedAt = Convert.ToDateTime(row["UpdatedAt"])
            };
        }

        public List<Role> GetAll()
        {
            string query = "SELECT * FROM roles WHERE DeletedAt IS NULL";
            DataTable dt = dbHelper.ExecuteQuery(query);
            return ConvertDataTableToList(dt);
        }

        public Role GetById(string id)
        {
            string query = "SELECT * FROM roles WHERE RoleID = @id AND DeletedAt IS NULL";
            MySqlParameter[] parameters = { new MySqlParameter("@id", id) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            
            if (dt.Rows.Count > 0)
                return MapDataRowToEntity(dt.Rows[0]);
            return null;
        }

        public bool Insert(Role role)
        {
            try
            {
                string query = @"INSERT INTO roles (RoleID, RoleCode, RoleName, CreatedAt, UpdatedAt) 
                               VALUES (@RoleID, @RoleCode, @RoleName, @CreatedAt, @UpdatedAt)";
                
                MySqlParameter[] parameters = 
                {
                    new MySqlParameter("@RoleID", role.RoleID),
                    new MySqlParameter("@RoleCode", role.RoleCode),
                    new MySqlParameter("@RoleName", role.RoleName),
                    new MySqlParameter("@CreatedAt", role.CreatedAt),
                    new MySqlParameter("@UpdatedAt", role.UpdatedAt)
                };
                
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm vai trò: {ex.Message}");
            }
        }

        public bool Update(Role role)
        {
            try
            {
                string query = @"UPDATE roles SET RoleCode = @RoleCode, RoleName = @RoleName, 
                               UpdatedAt = @UpdatedAt WHERE RoleID = @RoleID";
                
                MySqlParameter[] parameters = 
                {
                    new MySqlParameter("@RoleID", role.RoleID),
                    new MySqlParameter("@RoleCode", role.RoleCode),
                    new MySqlParameter("@RoleName", role.RoleName),
                    new MySqlParameter("@UpdatedAt", DateTime.Now)
                };
                
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật vai trò: {ex.Message}");
            }
        }

        public bool Delete(string id)
        {
            try
            {
                string query = "UPDATE roles SET DeletedAt = @DeletedAt, UpdatedAt = @UpdatedAt WHERE RoleID = @id AND DeletedAt IS NULL";
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
                throw new Exception($"Lỗi khi xóa vai trò: {ex.Message}");
            }
        }

        public bool Exists(string id)
        {
            string query = "SELECT COUNT(*) FROM roles WHERE RoleID = @id AND DeletedAt IS NULL";
            MySqlParameter[] parameters = { new MySqlParameter("@id", id) };
            int count = Convert.ToInt32(dbHelper.ExecuteScalar(query, parameters));
            return count > 0;
        }

        private List<Role> ConvertDataTableToList(DataTable dt)
        {
            List<Role> list = new List<Role>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapDataRowToEntity(row));
            }
            return list;
        }

        public PagedResult<Role> Search(SearchCriteria criteria)
        {
            try
            {
                // Tạo điều kiện WHERE
                string whereClause = "";
                List<MySqlParameter> parameters = new List<MySqlParameter>();

                if (!string.IsNullOrEmpty(criteria.SearchTerm))
                {
                    whereClause = "WHERE (RoleCode LIKE @searchTerm OR RoleName LIKE @searchTerm) AND DeletedAt IS NULL";
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
                string countQuery = $"SELECT COUNT(*) FROM roles {whereClause}";
                int totalRecords = Convert.ToInt32(dbHelper.ExecuteScalar(countQuery, parameters.ToArray()));

                // Tính toán phân trang
                int offset = (criteria.PageNumber - 1) * criteria.PageSize;

                // Lấy dữ liệu với phân trang
                string dataQuery = $"SELECT * FROM roles {whereClause} {orderBy} LIMIT {criteria.PageSize} OFFSET {offset}";
                DataTable dt = dbHelper.ExecuteQuery(dataQuery, parameters.ToArray());

                return new PagedResult<Role>
                {
                    Data = ConvertDataTableToList(dt),
                    TotalRecords = totalRecords,
                    PageNumber = criteria.PageNumber,
                    PageSize = criteria.PageSize
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tìm kiếm vai trò: {ex.Message}");
            }
        }

        // Phương thức đặc biệt cho Role
        public Role GetByRoleCode(string roleCode)
        {
            string query = "SELECT * FROM roles WHERE RoleCode = @roleCode AND DeletedAt IS NULL";
            MySqlParameter[] parameters = { new MySqlParameter("@roleCode", roleCode) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            
            if (dt.Rows.Count > 0)
                return MapDataRowToEntity(dt.Rows[0]);
            return null;
        }

        public bool IsRoleCodeExists(string roleCode, string excludeRoleId = null)
        {
            string query = "SELECT COUNT(*) FROM roles WHERE RoleCode = @roleCode AND DeletedAt IS NULL";
            List<MySqlParameter> parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@roleCode", roleCode)
            };

            if (!string.IsNullOrEmpty(excludeRoleId))
            {
                query += " AND RoleID != @excludeRoleId";
                parameters.Add(new MySqlParameter("@excludeRoleId", excludeRoleId));
            }

            int count = Convert.ToInt32(dbHelper.ExecuteScalar(query, parameters.ToArray()));
            return count > 0;
        }

        public bool IsRoleNameExists(string roleName, string excludeRoleId = null)
        {
            string query = "SELECT COUNT(*) FROM roles WHERE RoleName = @roleName AND DeletedAt IS NULL";
            List<MySqlParameter> parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@roleName", roleName)
            };

            if (!string.IsNullOrEmpty(excludeRoleId))
            {
                query += " AND RoleID != @excludeRoleId";
                parameters.Add(new MySqlParameter("@excludeRoleId", excludeRoleId));
            }

            int count = Convert.ToInt32(dbHelper.ExecuteScalar(query, parameters.ToArray()));
            return count > 0;
        }

        // Lấy danh sách role với số lượng user
        public PagedResult<Role> GetRolesWithUserCount(SearchCriteria criteria)
        {
            try
            {
                // Tạo điều kiện WHERE
                string whereClause = "";
                List<MySqlParameter> parameters = new List<MySqlParameter>();

                if (!string.IsNullOrEmpty(criteria.SearchTerm))
                {
                    whereClause = "WHERE (r.RoleCode LIKE @searchTerm OR r.RoleName LIKE @searchTerm) AND r.DeletedAt IS NULL";
                    parameters.Add(new MySqlParameter("@searchTerm", $"%{criteria.SearchTerm}%"));
                }
                else
                {
                    whereClause = "WHERE r.DeletedAt IS NULL";
                }

                // Tạo ORDER BY
                string orderBy = "";
                if (!string.IsNullOrEmpty(criteria.SortBy))
                {
                    orderBy = $"ORDER BY {criteria.SortBy} {criteria.SortDirection}";
                }
                else
                {
                    orderBy = "ORDER BY r.CreatedAt DESC";
                }

                // Đếm tổng số bản ghi
                string countQuery = @"SELECT COUNT(*) FROM roles r " + whereClause;
                int totalRecords = Convert.ToInt32(dbHelper.ExecuteScalar(countQuery, parameters.ToArray()));

                // Tính toán phân trang
                int offset = (criteria.PageNumber - 1) * criteria.PageSize;

                // Lấy dữ liệu với phân trang
                string dataQuery = @"SELECT r.*, COUNT(u.UserID) as UserCount
                                   FROM roles r
                                   LEFT JOIN users u ON r.RoleID = u.RoleID AND u.DeletedAt IS NULL " +
                                   whereClause + @" GROUP BY r.RoleID, r.RoleCode, r.RoleName, r.CreatedAt, r.UpdatedAt, r.DeletedAt " +
                                   orderBy + $" LIMIT {criteria.PageSize} OFFSET {offset}";

                DataTable dt = dbHelper.ExecuteQuery(dataQuery, parameters.ToArray());
                List<Role> roles = new List<Role>();

                foreach (DataRow row in dt.Rows)
                {
                    var role = MapDataRowToEntity(row);
                    // Có thể thêm thuộc tính UserCount vào model Role nếu cần
                    roles.Add(role);
                }

                return new PagedResult<Role>
                {
                    Data = roles,
                    TotalRecords = totalRecords,
                    PageNumber = criteria.PageNumber,
                    PageSize = criteria.PageSize
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách role với số lượng user: {ex.Message}");
            }
        }

        // Kiểm tra role có đang được sử dụng không
        public bool IsRoleInUse(string roleId)
        {
            string query = "SELECT COUNT(*) FROM users WHERE RoleID = @roleId AND DeletedAt IS NULL";
            MySqlParameter[] parameters = { new MySqlParameter("@roleId", roleId) };
            int count = Convert.ToInt32(dbHelper.ExecuteScalar(query, parameters));
            return count > 0;
        }

        // Lấy danh sách permission của role
        public List<Permission> GetRolePermissions(string roleId)
        {
            string query = @"SELECT p.* FROM permissions p
                           INNER JOIN role_permissions rp ON p.PermissionID = rp.PermissionID
                           WHERE rp.RoleID = @roleId AND p.DeletedAt IS NULL";
            MySqlParameter[] parameters = { new MySqlParameter("@roleId", roleId) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            
            List<Permission> permissions = new List<Permission>();
            foreach (DataRow row in dt.Rows)
            {
                permissions.Add(new Permission
                {
                    PermissionID = row["PermissionID"].ToString(),
                    PermissionCode = row["PermissionCode"].ToString(),
                    PermissionName = row["PermissionName"].ToString(),
                    CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                    UpdatedAt = Convert.ToDateTime(row["UpdatedAt"])
                });
            }
            return permissions;
        }

        // Gán permission cho role
        public bool AssignPermissionToRole(string roleId, string permissionId)
        {
            try
            {
                string query = @"INSERT INTO role_permissions (RoleID, PermissionID) 
                               VALUES (@roleId, @permissionId)
                               ON DUPLICATE KEY UPDATE RoleID = RoleID";
                MySqlParameter[] parameters = 
                {
                    new MySqlParameter("@roleId", roleId),
                    new MySqlParameter("@permissionId", permissionId)
                };
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi gán quyền cho role: {ex.Message}");
            }
        }

        // Xóa permission khỏi role
        public bool RemovePermissionFromRole(string roleId, string permissionId)
        {
            try
            {
                string query = "DELETE FROM role_permissions WHERE RoleID = @roleId AND PermissionID = @permissionId";
                MySqlParameter[] parameters = 
                {
                    new MySqlParameter("@roleId", roleId),
                    new MySqlParameter("@permissionId", permissionId)
                };
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa quyền khỏi role: {ex.Message}");
            }
        }

        // Xóa tất cả permission của role
        public bool RemoveAllPermissionsFromRole(string roleId)
        {
            try
            {
                string query = "DELETE FROM role_permissions WHERE RoleID = @roleId";
                MySqlParameter[] parameters = { new MySqlParameter("@roleId", roleId) };
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return true; // Trả về true ngay cả khi không có permission nào để xóa
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa tất cả quyền của role: {ex.Message}");
            }
        }
    }
}

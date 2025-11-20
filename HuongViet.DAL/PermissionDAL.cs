using HuongViet.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace HuongViet.DAL
{
    public class PermissionDAL
    {
        private readonly DatabaseHelper dbHelper;

        public PermissionDAL()
        {
            this.dbHelper = new DatabaseHelper();
        }

        private Permission MapDataRowToEntity(DataRow row)
        {
            return new Permission
            {
                PermissionID = row["PermissionID"].ToString(),
                PermissionCode = row["PermissionCode"].ToString(),
                PermissionName = row["PermissionName"].ToString(),
                CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                UpdatedAt = Convert.ToDateTime(row["UpdatedAt"])
            };
        }

        public List<Permission> GetAll()
        {
            string query = "SELECT * FROM permissions WHERE DeletedAt IS NULL";
            DataTable dt = dbHelper.ExecuteQuery(query);
            return ConvertDataTableToList(dt);
        }

        public Permission GetById(string id)
        {
            string query = "SELECT * FROM permissions WHERE PermissionID = @id AND DeletedAt IS NULL";
            MySqlParameter[] parameters = { new MySqlParameter("@id", id) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            
            if (dt.Rows.Count > 0)
                return MapDataRowToEntity(dt.Rows[0]);
            return null;
        }

        public bool Insert(Permission permission)
        {
            try
            {
                string query = @"INSERT INTO permissions (PermissionID, PermissionCode, PermissionName, CreatedAt, UpdatedAt) 
                               VALUES (@PermissionID, @PermissionCode, @PermissionName, @CreatedAt, @UpdatedAt)";
                
                MySqlParameter[] parameters = 
                {
                    new MySqlParameter("@PermissionID", permission.PermissionID),
                    new MySqlParameter("@PermissionCode", permission.PermissionCode),
                    new MySqlParameter("@PermissionName", permission.PermissionName),
                    new MySqlParameter("@CreatedAt", permission.CreatedAt),
                    new MySqlParameter("@UpdatedAt", permission.UpdatedAt)
                };
                
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm quyền: {ex.Message}");
            }
        }

        public bool Update(Permission permission)
        {
            try
            {
                string query = @"UPDATE permissions SET PermissionCode = @PermissionCode, PermissionName = @PermissionName, 
                               UpdatedAt = @UpdatedAt WHERE PermissionID = @PermissionID";
                
                MySqlParameter[] parameters = 
                {
                    new MySqlParameter("@PermissionID", permission.PermissionID),
                    new MySqlParameter("@PermissionCode", permission.PermissionCode),
                    new MySqlParameter("@PermissionName", permission.PermissionName),
                    new MySqlParameter("@UpdatedAt", DateTime.Now)
                };
                
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật quyền: {ex.Message}");
            }
        }

        public bool Delete(string id)
        {
            try
            {
                string query = "UPDATE permissions SET DeletedAt = @DeletedAt, UpdatedAt = @UpdatedAt WHERE PermissionID = @id AND DeletedAt IS NULL";
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
                throw new Exception($"Lỗi khi xóa quyền: {ex.Message}");
            }
        }

        public bool Exists(string id)
        {
            string query = "SELECT COUNT(*) FROM permissions WHERE PermissionID = @id AND DeletedAt IS NULL";
            MySqlParameter[] parameters = { new MySqlParameter("@id", id) };
            int count = Convert.ToInt32(dbHelper.ExecuteScalar(query, parameters));
            return count > 0;
        }

        private List<Permission> ConvertDataTableToList(DataTable dt)
        {
            List<Permission> list = new List<Permission>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapDataRowToEntity(row));
            }
            return list;
        }

        public PagedResult<Permission> Search(SearchCriteria criteria)
        {
            try
            {
                // Tạo điều kiện WHERE
                string whereClause = "";
                List<MySqlParameter> parameters = new List<MySqlParameter>();

                if (!string.IsNullOrEmpty(criteria.SearchTerm))
                {
                    whereClause = "WHERE (PermissionCode LIKE @searchTerm OR PermissionName LIKE @searchTerm) AND DeletedAt IS NULL";
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
                string countQuery = $"SELECT COUNT(*) FROM permissions {whereClause}";
                int totalRecords = Convert.ToInt32(dbHelper.ExecuteScalar(countQuery, parameters.ToArray()));

                // Tính toán phân trang
                int offset = (criteria.PageNumber - 1) * criteria.PageSize;

                // Lấy dữ liệu với phân trang
                string dataQuery = $"SELECT * FROM permissions {whereClause} {orderBy} LIMIT {criteria.PageSize} OFFSET {offset}";
                DataTable dt = dbHelper.ExecuteQuery(dataQuery, parameters.ToArray());

                return new PagedResult<Permission>
                {
                    Data = ConvertDataTableToList(dt),
                    TotalRecords = totalRecords,
                    PageNumber = criteria.PageNumber,
                    PageSize = criteria.PageSize
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tìm kiếm quyền: {ex.Message}");
            }
        }

        // Phương thức đặc biệt cho Permission
        public Permission GetByPermissionCode(string permissionCode)
        {
            string query = "SELECT * FROM permissions WHERE PermissionCode = @permissionCode AND DeletedAt IS NULL";
            MySqlParameter[] parameters = { new MySqlParameter("@permissionCode", permissionCode) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            
            if (dt.Rows.Count > 0)
                return MapDataRowToEntity(dt.Rows[0]);
            return null;
        }

        public bool IsPermissionCodeExists(string permissionCode, string excludePermissionId = null)
        {
            string query = "SELECT COUNT(*) FROM permissions WHERE PermissionCode = @permissionCode AND DeletedAt IS NULL";
            List<MySqlParameter> parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@permissionCode", permissionCode)
            };

            if (!string.IsNullOrEmpty(excludePermissionId))
            {
                query += " AND PermissionID != @excludePermissionId";
                parameters.Add(new MySqlParameter("@excludePermissionId", excludePermissionId));
            }

            int count = Convert.ToInt32(dbHelper.ExecuteScalar(query, parameters.ToArray()));
            return count > 0;
        }

        public bool IsPermissionNameExists(string permissionName, string excludePermissionId = null)
        {
            string query = "SELECT COUNT(*) FROM permissions WHERE PermissionName = @permissionName AND DeletedAt IS NULL";
            List<MySqlParameter> parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@permissionName", permissionName)
            };

            if (!string.IsNullOrEmpty(excludePermissionId))
            {
                query += " AND PermissionID != @excludePermissionId";
                parameters.Add(new MySqlParameter("@excludePermissionId", excludePermissionId));
            }

            int count = Convert.ToInt32(dbHelper.ExecuteScalar(query, parameters.ToArray()));
            return count > 0;
        }

        // Lấy danh sách permission với số lượng role sử dụng
        public PagedResult<Permission> GetPermissionsWithRoleCount(SearchCriteria criteria)
        {
            try
            {
                // Tạo điều kiện WHERE
                string whereClause = "";
                List<MySqlParameter> parameters = new List<MySqlParameter>();

                if (!string.IsNullOrEmpty(criteria.SearchTerm))
                {
                    whereClause = "WHERE (p.PermissionCode LIKE @searchTerm OR p.PermissionName LIKE @searchTerm) AND p.DeletedAt IS NULL";
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
                string countQuery = @"SELECT COUNT(*) FROM permissions p " + whereClause;
                int totalRecords = Convert.ToInt32(dbHelper.ExecuteScalar(countQuery, parameters.ToArray()));

                // Tính toán phân trang
                int offset = (criteria.PageNumber - 1) * criteria.PageSize;

                // Lấy dữ liệu với phân trang
                string dataQuery = @"SELECT p.*, COUNT(rp.RoleID) as RoleCount
                                   FROM permissions p
                                   LEFT JOIN role_permissions rp ON p.PermissionID = rp.PermissionID " +
                                   whereClause + @" GROUP BY p.PermissionID, p.PermissionCode, p.PermissionName, p.CreatedAt, p.UpdatedAt, p.DeletedAt " +
                                   orderBy + $" LIMIT {criteria.PageSize} OFFSET {offset}";

                DataTable dt = dbHelper.ExecuteQuery(dataQuery, parameters.ToArray());
                List<Permission> permissions = new List<Permission>();

                foreach (DataRow row in dt.Rows)
                {
                    var permission = MapDataRowToEntity(row);
                    // Có thể thêm thuộc tính RoleCount vào model Permission nếu cần
                    permissions.Add(permission);
                }

                return new PagedResult<Permission>
                {
                    Data = permissions,
                    TotalRecords = totalRecords,
                    PageNumber = criteria.PageNumber,
                    PageSize = criteria.PageSize
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách quyền với số lượng role: {ex.Message}");
            }
        }

        // Kiểm tra permission có đang được sử dụng không
        public bool IsPermissionInUse(string permissionId)
        {
            string query = "SELECT COUNT(*) FROM role_permissions WHERE PermissionID = @permissionId";
            MySqlParameter[] parameters = { new MySqlParameter("@permissionId", permissionId) };
            int count = Convert.ToInt32(dbHelper.ExecuteScalar(query, parameters));
            return count > 0;
        }

        // Lấy danh sách role có permission này
        public List<Role> GetPermissionRoles(string permissionId)
        {
            string query = @"SELECT r.* FROM roles r
                           INNER JOIN role_permissions rp ON r.RoleID = rp.RoleID
                           WHERE rp.PermissionID = @permissionId AND r.DeletedAt IS NULL
                           ORDER BY r.RoleName";
            MySqlParameter[] parameters = { new MySqlParameter("@permissionId", permissionId) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            
            List<Role> roles = new List<Role>();
            foreach (DataRow row in dt.Rows)
            {
                roles.Add(new Role
                {
                    RoleID = row["RoleID"].ToString(),
                    RoleCode = row["RoleCode"].ToString(),
                    RoleName = row["RoleName"].ToString(),
                    CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                    UpdatedAt = Convert.ToDateTime(row["UpdatedAt"])
                });
            }
            return roles;
        }

        // Lấy danh sách permission chưa được gán cho role
        public List<Permission> GetUnassignedPermissions(string roleId)
        {
            string query = @"SELECT p.* FROM permissions p
                           WHERE p.PermissionID NOT IN (
                               SELECT rp.PermissionID FROM role_permissions rp 
                               WHERE rp.RoleID = @roleId
                           ) AND p.DeletedAt IS NULL
                           ORDER BY p.PermissionName";
            MySqlParameter[] parameters = { new MySqlParameter("@roleId", roleId) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            return ConvertDataTableToList(dt);
        }

        // Lấy danh sách permission đã được gán cho role
        public List<Permission> GetAssignedPermissions(string roleId)
        {
            string query = @"SELECT p.* FROM permissions p
                           INNER JOIN role_permissions rp ON p.PermissionID = rp.PermissionID
                           WHERE rp.RoleID = @roleId AND p.DeletedAt IS NULL
                           ORDER BY p.PermissionName";
            MySqlParameter[] parameters = { new MySqlParameter("@roleId", roleId) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            return ConvertDataTableToList(dt);
        }

        // Lấy danh sách permission theo mã code (có thể dùng để tìm kiếm theo nhóm)
        public List<Permission> GetPermissionsByCodePattern(string codePattern)
        {
            string query = "SELECT * FROM permissions WHERE PermissionCode LIKE @codePattern AND DeletedAt IS NULL ORDER BY PermissionCode";
            MySqlParameter[] parameters = { new MySqlParameter("@codePattern", $"%{codePattern}%") };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            return ConvertDataTableToList(dt);
        }

        // Lấy số lượng role sử dụng permission
        public int GetPermissionRoleCount(string permissionId)
        {
            string query = "SELECT COUNT(*) FROM role_permissions WHERE PermissionID = @permissionId";
            MySqlParameter[] parameters = { new MySqlParameter("@permissionId", permissionId) };
            return Convert.ToInt32(dbHelper.ExecuteScalar(query, parameters));
        }

        // Kiểm tra user có permission không (thông qua role)
        public bool UserHasPermission(string userId, string permissionCode)
        {
            string query = @"SELECT COUNT(*) FROM users u
                           INNER JOIN roles r ON u.RoleID = r.RoleID AND r.DeletedAt IS NULL
                           INNER JOIN role_permissions rp ON r.RoleID = rp.RoleID
                           INNER JOIN permissions p ON rp.PermissionID = p.PermissionID AND p.DeletedAt IS NULL
                           WHERE u.UserID = @userId AND p.PermissionCode = @permissionCode AND u.DeletedAt IS NULL";
            MySqlParameter[] parameters = 
            {
                new MySqlParameter("@userId", userId),
                new MySqlParameter("@permissionCode", permissionCode)
            };
            int count = Convert.ToInt32(dbHelper.ExecuteScalar(query, parameters));
            return count > 0;
        }

        // Lấy tất cả permission của user (thông qua role)
        public List<Permission> GetUserPermissions(string userId)
        {
            string query = @"SELECT DISTINCT p.* FROM permissions p
                           INNER JOIN role_permissions rp ON p.PermissionID = rp.PermissionID
                           INNER JOIN roles r ON rp.RoleID = r.RoleID AND r.DeletedAt IS NULL
                           INNER JOIN users u ON r.RoleID = u.RoleID AND u.DeletedAt IS NULL
                           WHERE u.UserID = @userId AND p.DeletedAt IS NULL
                           ORDER BY p.PermissionCode";
            MySqlParameter[] parameters = { new MySqlParameter("@userId", userId) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            return ConvertDataTableToList(dt);
        }

        // Lấy danh sách permission theo nhóm (dựa trên prefix của code)
        public Dictionary<string, List<Permission>> GetPermissionsByGroup()
        {
            try
            {
                string query = "SELECT * FROM permissions WHERE DeletedAt IS NULL ORDER BY PermissionCode";
                DataTable dt = dbHelper.ExecuteQuery(query);
                
                Dictionary<string, List<Permission>> groupedPermissions = new Dictionary<string, List<Permission>>();
                
                foreach (DataRow row in dt.Rows)
                {
                    var permission = MapDataRowToEntity(row);
                    string group = "Other";
                    
                    // Tách nhóm dựa trên prefix của PermissionCode (ví dụ: USER_CREATE -> USER)
                    if (!string.IsNullOrEmpty(permission.PermissionCode) && permission.PermissionCode.Contains("_"))
                    {
                        group = permission.PermissionCode.Split('_')[0];
                    }
                    
                    if (!groupedPermissions.ContainsKey(group))
                    {
                        groupedPermissions[group] = new List<Permission>();
                    }
                    
                    groupedPermissions[group].Add(permission);
                }
                
                return groupedPermissions;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách permission theo nhóm: {ex.Message}");
            }
        }
    }
}

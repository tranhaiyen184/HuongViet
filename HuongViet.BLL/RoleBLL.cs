using HuongViet.DAL;
using HuongViet.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace HuongViet.BLL
{
    public class RoleBLL
    {
        private readonly RoleDAL roleDAL;
        private readonly PermissionDAL permissionDAL;

        public RoleBLL()
        {
            roleDAL = new RoleDAL();
            permissionDAL = new PermissionDAL();
        }

        /// <summary>
        /// Lấy tất cả vai trò
        /// </summary>
        /// <returns>Danh sách vai trò</returns>
        public List<Role> GetAllRoles()
        {
            try
            {
                return roleDAL.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách vai trò: {ex.Message}");
            }
        }

        /// <summary>
        /// Lấy vai trò theo ID
        /// </summary>
        /// <param name="roleId">ID vai trò</param>
        /// <returns>Thông tin vai trò</returns>
        public Role GetRoleById(string roleId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(roleId))
                    return null;

                var role = roleDAL.GetById(roleId);
                if (role != null)
                {
                    // Load permissions
                    role.Permissions = roleDAL.GetRolePermissions(roleId);
                }
                return role;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy thông tin vai trò: {ex.Message}");
            }
        }

        /// <summary>
        /// Thêm vai trò mới
        /// </summary>
        /// <param name="role">Thông tin vai trò</param>
        /// <param name="permissionIds">Danh sách ID permissions</param>
        /// <returns>True nếu thành công</returns>
        public bool AddRole(Role role, List<string> permissionIds = null)
        {
            try
            {
                // Validate input
                string validationError = ValidateRole(role);
                if (!string.IsNullOrEmpty(validationError))
                {
                    throw new Exception(validationError);
                }

                // Auto-generate RoleCode from RoleName if not provided
                if (string.IsNullOrWhiteSpace(role.RoleCode))
                {
                    role.RoleCode = GenerateRoleCode(role.RoleName);
                }

                // Check if role code already exists
                if (roleDAL.IsRoleCodeExists(role.RoleCode))
                {
                    throw new Exception("Mã vai trò đã tồn tại!");
                }

                // Check if role name already exists
                if (roleDAL.IsRoleNameExists(role.RoleName))
                {
                    throw new Exception("Tên vai trò đã tồn tại!");
                }

                // Generate ID if not provided
                if (string.IsNullOrWhiteSpace(role.RoleID))
                {
                    role.RoleID = GenerateRoleId();
                }

                role.CreatedAt = DateTime.Now;
                role.UpdatedAt = DateTime.Now;

                // Insert role
                bool success = roleDAL.Insert(role);
                if (!success)
                {
                    return false;
                }

                // Assign permissions if provided
                if (permissionIds != null && permissionIds.Count > 0)
                {
                    foreach (string permissionId in permissionIds)
                    {
                        roleDAL.AssignPermissionToRole(role.RoleID, permissionId);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm vai trò: {ex.Message}");
            }
        }

        /// <summary>
        /// Cập nhật vai trò
        /// </summary>
        /// <param name="role">Thông tin vai trò</param>
        /// <param name="permissionIds">Danh sách ID permissions mới</param>
        /// <returns>True nếu thành công</returns>
        public bool UpdateRole(Role role, List<string> permissionIds = null)
        {
            try
            {
                // Validate input
                string validationError = ValidateRole(role);
                if (!string.IsNullOrEmpty(validationError))
                {
                    throw new Exception(validationError);
                }

                // Auto-generate RoleCode from RoleName if not provided
                if (string.IsNullOrWhiteSpace(role.RoleCode))
                {
                    role.RoleCode = GenerateRoleCode(role.RoleName);
                }

                // Check if role exists
                if (!roleDAL.Exists(role.RoleID))
                {
                    throw new Exception("Vai trò không tồn tại!");
                }

                // Check if role code already exists (excluding current role)
                if (roleDAL.IsRoleCodeExists(role.RoleCode, role.RoleID))
                {
                    throw new Exception("Mã vai trò đã tồn tại!");
                }

                // Check if role name already exists (excluding current role)
                if (roleDAL.IsRoleNameExists(role.RoleName, role.RoleID))
                {
                    throw new Exception("Tên vai trò đã tồn tại!");
                }

                role.UpdatedAt = DateTime.Now;

                // Update role
                bool success = roleDAL.Update(role);
                if (!success)
                {
                    return false;
                }

                // Update permissions if provided
                if (permissionIds != null)
                {
                    // Remove all existing permissions
                    roleDAL.RemoveAllPermissionsFromRole(role.RoleID);

                    // Assign new permissions
                    foreach (string permissionId in permissionIds)
                    {
                        roleDAL.AssignPermissionToRole(role.RoleID, permissionId);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật vai trò: {ex.Message}");
            }
        }

        /// <summary>
        /// Xóa vai trò
        /// </summary>
        /// <param name="roleId">ID vai trò</param>
        /// <returns>True nếu thành công</returns>
        public bool DeleteRole(string roleId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(roleId))
                {
                    throw new Exception("ID vai trò không hợp lệ!");
                }

                // Check if role exists
                if (!roleDAL.Exists(roleId))
                {
                    throw new Exception("Vai trò không tồn tại!");
                }

                // Check if role is in use
                if (roleDAL.IsRoleInUse(roleId))
                {
                    throw new Exception("Không thể xóa vai trò đang được sử dụng!");
                }

                return roleDAL.Delete(roleId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa vai trò: {ex.Message}");
            }
        }

        /// <summary>
        /// Tìm kiếm vai trò với phân trang
        /// </summary>
        /// <param name="criteria">Tiêu chí tìm kiếm và phân trang</param>
        /// <returns>Kết quả phân trang</returns>
        public PagedResult<Role> SearchRoles(SearchCriteria criteria)
        {
            try
            {
                return roleDAL.Search(criteria);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tìm kiếm vai trò: {ex.Message}");
            }
        }

        /// <summary>
        /// Lấy danh sách permissions
        /// </summary>
        /// <returns>Danh sách permissions</returns>
        public List<Permission> GetAllPermissions()
        {
            try
            {
                return permissionDAL.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách quyền: {ex.Message}");
            }
        }

        /// <summary>
        /// Lấy danh sách permissions của role
        /// </summary>
        /// <param name="roleId">ID vai trò</param>
        /// <returns>Danh sách permissions</returns>
        public List<Permission> GetRolePermissions(string roleId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(roleId))
                    return new List<Permission>();

                return roleDAL.GetRolePermissions(roleId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách quyền của vai trò: {ex.Message}");
            }
        }

        #region Private Methods

        /// <summary>
        /// Validate thông tin vai trò
        /// </summary>
        /// <param name="role">Thông tin vai trò</param>
        /// <returns>Thông báo lỗi hoặc null nếu hợp lệ</returns>
        private string ValidateRole(Role role)
        {
            if (role == null)
                return "Thông tin vai trò không hợp lệ!";

            if (string.IsNullOrWhiteSpace(role.RoleName))
                return "Vui lòng nhập tên vai trò!";

            if (role.RoleName.Length > 50)
                return "Tên vai trò không được vượt quá 50 ký tự!";

            return null; // Valid
        }

        /// <summary>
        /// Tạo ID vai trò tự động
        /// </summary>
        /// <returns>ID vai trò</returns>
        private string GenerateRoleId()
        {
            return "ROLE" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        /// <summary>
        /// Chuyển đổi tên vai trò thành mã vai trò (in hoa, cách nhau bằng _)
        /// Ví dụ: "Quản trị viên" -> "QUAN_TRI_VIEN"
        /// </summary>
        /// <param name="roleName">Tên vai trò</param>
        /// <returns>Mã vai trò</returns>
        private string GenerateRoleCode(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
                return string.Empty;

            // Remove diacritics (dấu tiếng Việt)
            string normalized = RemoveDiacritics(roleName.Trim());

            // Replace spaces and special characters with underscore
            normalized = Regex.Replace(normalized, @"[^a-zA-Z0-9]+", "_");

            // Remove leading/trailing underscores
            normalized = normalized.Trim('_');

            // Convert to uppercase
            normalized = normalized.ToUpperInvariant();

            // Replace multiple underscores with single underscore
            normalized = Regex.Replace(normalized, @"_+", "_");

            return normalized;
        }

        /// <summary>
        /// Loại bỏ dấu tiếng Việt
        /// </summary>
        /// <param name="text">Chuỗi có dấu</param>
        /// <returns>Chuỗi không dấu</returns>
        private string RemoveDiacritics(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        #endregion
    }
}


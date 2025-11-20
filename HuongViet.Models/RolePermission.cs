using System;

namespace HuongViet.Models
{
    /// <summary>
    /// Lớp đại diện cho mối quan hệ giữa Role và Permission
    /// </summary>
    public class RolePermission
    {
        /// <summary>
        /// ID của Role
        /// </summary>
        public string RoleID { get; set; }

        /// <summary>
        /// ID của Permission
        /// </summary>
        public string PermissionID { get; set; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// Ngày cập nhật
        /// </summary>
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// Thông tin Role (navigation property)
        /// </summary>
        public Role Role { get; set; }

        /// <summary>
        /// Thông tin Permission (navigation property)
        /// </summary>
        public Permission Permission { get; set; }

        /// <summary>
        /// Constructor mặc định
        /// </summary>
        public RolePermission()
        {
        }

        /// <summary>
        /// Constructor với tham số
        /// </summary>
        /// <param name="roleId">ID của Role</param>
        /// <param name="permissionId">ID của Permission</param>
        public RolePermission(string roleId, string permissionId)
        {
            RoleID = roleId;
            PermissionID = permissionId;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        /// <summary>
        /// Override ToString để hiển thị thông tin
        /// </summary>
        /// <returns>Chuỗi mô tả RolePermission</returns>
        public override string ToString()
        {
            return $"Role: {Role?.RoleName ?? RoleID} - Permission: {Permission?.PermissionName ?? PermissionID}";
        }

        /// <summary>
        /// Override Equals để so sánh
        /// </summary>
        /// <param name="obj">Object cần so sánh</param>
        /// <returns>True nếu bằng nhau</returns>
        public override bool Equals(object obj)
        {
            if (obj is RolePermission other)
            {
                return RoleID == other.RoleID && PermissionID == other.PermissionID;
            }
            return false;
        }

        /// <summary>
        /// Override GetHashCode
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (RoleID?.GetHashCode() ?? 0);
                hash = hash * 23 + (PermissionID?.GetHashCode() ?? 0);
                return hash;
            }
        }
    }
}

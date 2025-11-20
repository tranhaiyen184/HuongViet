using System;

namespace HuongViet.Models
{
    public class Permission
    {
        public string PermissionID { get; set; }
        public string PermissionCode { get; set; }
        public string PermissionName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;

namespace HuongViet.Models
{
    public class Role
    {
        public string RoleID { get; set; }
        public string RoleCode { get; set; }
        public string RoleName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public ICollection<Permission> Permissions { get; set; } = new List<Permission>();
    }
}

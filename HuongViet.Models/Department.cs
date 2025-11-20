using System;

namespace HuongViet.Models
{
    public class Department
    {
        public string DepartmentID { get; set; }

        public string DepartmentName { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}

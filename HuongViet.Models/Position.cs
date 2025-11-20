using System;

namespace HuongViet.Models
{
    public class Position
    {
        public string PositionID { get; set; }
        public string PositionName { get; set; }
        
        public string DepartmentID { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public Department Department { get; set; }
    }
}

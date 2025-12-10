using System;

namespace HuongViet.Models
{
    public class Area
    {
        public string AreaID { get; set; }
        public string AreaName { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}


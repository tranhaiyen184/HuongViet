using System;

namespace HuongViet.Models
{
    public class AccumulatedPoints
    {
        public string AccumulatedPointID { get; set; }
        public string CustomerID { get; set; }
        public int AccumPoint { get; set; } = 0;
        public int TotalAccumPoint { get; set; } = 0;
        public DateTime UpdateDate { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        public Customer Customer { get; set; }
    }
}

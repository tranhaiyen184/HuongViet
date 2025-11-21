using System;

namespace HuongViet.Models
{
    public class Table
    {
        public string TableID { get; set; }
        public string TableName { get; set; }
        public TableStatus TableStatus { get; set; } = TableStatus.Available;
        public int Capacity { get; set; }
        public string FloorID { get; set; }
        public string CurrentOrderID { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        
        // Navigation property
        public Floor Floor { get; set; }
    }
}


using System;

namespace HuongViet.Models
{
    public class Floor
    {
        public string FloorID { get; set; }
        public int FloorNumber { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}


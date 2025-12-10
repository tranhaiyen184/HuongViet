using System;

namespace HuongViet.Models
{
    public class Room
    {
        public string RoomID { get; set; }
        public string RoomName { get; set; }
        public RoomStatus RoomStatus { get; set; } = RoomStatus.Available;
        public RoomType RoomType { get; set; }
        public decimal PricePerHour { get; set; }
        public int Capacity { get; set; }
        public string AreaID { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        
        // Navigation property
        public Area Area { get; set; }
    }
}


using System;

namespace HuongViet.Models
{
    public class Reservation
    {
        public string ReservationID { get; set; }
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string ContactPhone { get; set; }
        public DateTime ReservationDate { get; set; }
        public TimeSpan ReservationTime { get; set; }
        public int NumberOfGuests { get; set; }
        public string TableID { get; set; }
        public string RoomID { get; set; }
        public int? Duration { get; set; }
        public ReservationStatus ReservationStatus { get; set; } = ReservationStatus.Pending;
        public string SpecialRequests { get; set; }
        public decimal? DepositAmount { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        public Customer Customer { get; set; }
        public Table Table { get; set; }
    }
}

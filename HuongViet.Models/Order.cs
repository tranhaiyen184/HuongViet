using System;
using System.Collections.Generic;

namespace HuongViet.Models
{
    public enum OrderStatus
    {
        Pending,
        Confirmed,
        Preparing,
        Ready,
        Served,
        Completed,
        Cancelled
    }

    public enum FormOfService
    {
        DineIn,
        Takeaway
    }

    public enum PaymentMethod
    {
        Cash,
        BankTransfer
    }

    public class Order
    {
        public string OrderID { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public DateTime OrderTime { get; set; } = DateTime.Now;
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
        public string OrderNote { get; set; }
        public FormOfService FormOfService { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }
        public decimal TotalAmount { get; set; } = 0;
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string TableID { get; set; }
        public string RoomID { get; set; }
        public string ReservationID { get; set; }
        public string StaffID { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        public Customer Customer { get; set; }
        public Table Table { get; set; }
        public Room Room { get; set; }
        public User Staff { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}

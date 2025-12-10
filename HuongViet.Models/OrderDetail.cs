using System;

namespace HuongViet.Models
{
    public class OrderDetail
    {
        public string OrderID { get; set; }
        public string ItemID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; } = 0;
        public string Note { get; set; }

        // Navigation properties
        public Order Order { get; set; }
        public Item Item { get; set; }
    }
}

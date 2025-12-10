using System;

namespace HuongViet.Models
{
    public class ItemPrice
    {
        public DateTime PriceUpdateDate { get; set; }
        public string ItemID { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation property
        public Item Item { get; set; }
    }
}


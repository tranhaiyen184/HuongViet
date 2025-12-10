using System;
using System.Collections.Generic;

namespace HuongViet.Models
{
    public class Item
    {
        public string ItemID { get; set; }
        public string ItemName { get; set; }
        public string ItemImage { get; set; }
        public ItemType ItemType { get; set; }
        public decimal ItemPrice { get; set; }
        public string ItemDescription { get; set; }
        public string CateID { get; set; }
        public string UnitID { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime? DeletedAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        public Category Category { get; set; }
        public Unit Unit { get; set; }
        public ICollection<ItemPrice> ItemPrices { get; set; }
    }
}


using System;
using System.Collections.Generic;

namespace HuongViet.Models
{
    public class Unit
    {
        public string UnitID { get; set; }
        public string UnitName { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Navigation property
        public ICollection<Item> Items { get; set; }
    }
}


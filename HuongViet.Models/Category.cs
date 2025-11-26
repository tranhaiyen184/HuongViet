using System;
using System.Collections.Generic;

namespace HuongViet.Models
{
    public class Category
    {
        public string CateID { get; set; }
        public string CateName { get; set; }
        public string CateDescription { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Navigation property
        public ICollection<Item> Items { get; set; }
    }
}


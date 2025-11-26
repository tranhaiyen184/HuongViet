using System;
using System.Collections.Generic;

namespace HuongViet.Models
{
    public class Customer
    {
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhoneNum { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime? CustomerDOB { get; set; }
        public DateTime CusAssignDate { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        public ICollection<Order> Orders { get; set; }
        public ICollection<AccumulatedPoints> AccumulatedPoints { get; set; }
    }
}

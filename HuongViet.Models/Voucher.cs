using System;

namespace HuongViet.Models
{
    public class Voucher
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public decimal Percentage { get; set; }
        public string Description { get; set; }
        public DateTime? StartAt { get; set; }
        public DateTime? EndAt { get; set; }
        public int? UsageLimit { get; set; }
        public int UsageCount { get; set; } = 0;
        public bool Active { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}


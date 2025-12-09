using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuongViet.Models
{
    public class ReportingBestSellingItem
    {
        public string ItemID { get; set; }
        public string ItemName { get; set; }
        public int TotalQuantitySold { get; set; }
        public decimal TotalRevenue { get; set; }

        public decimal QuantityPercent { get; set; }
        public decimal RevenuePercent { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HuongViet.Models;
using MySql.Data.MySqlClient;

namespace HuongViet.DAL
{
    public class ReportDAL
    {
        private readonly DatabaseHelper dbHelper;

        public ReportDAL()
        {
            dbHelper = new DatabaseHelper();
        }

        private ReportingBestSellingItem MapDataRowToEntity(DataRow row)
        {
            if (row == null) return null;

            var item = new ReportingBestSellingItem();

            // ItemID
            if (row.Table.Columns.Contains("ItemID") && row["ItemID"] != DBNull.Value)
                item.ItemID = row["ItemID"].ToString();

            // ItemName
            if (row.Table.Columns.Contains("ItemName") && row["ItemName"] != DBNull.Value)
                item.ItemName = row["ItemName"].ToString();

            // TotalQuantitySold
            if (row.Table.Columns.Contains("TotalQuantitySold") && row["TotalQuantitySold"] != DBNull.Value)
                item.TotalQuantitySold = Convert.ToInt32(row["TotalQuantitySold"]);

            // TotalRevenue
            if (row.Table.Columns.Contains("TotalRevenue") && row["TotalRevenue"] != DBNull.Value)
                item.TotalRevenue = Convert.ToDecimal(row["TotalRevenue"]);

            // QuantityPercent
            if (row.Table.Columns.Contains("QuantityPercent") && row["QuantityPercent"] != DBNull.Value)
                item.QuantityPercent = Convert.ToDecimal(row["QuantityPercent"]);

            // RevenuePercent
            if (row.Table.Columns.Contains("RevenuePercent") && row["RevenuePercent"] != DBNull.Value)
                item.RevenuePercent = Convert.ToDecimal(row["RevenuePercent"]);

            return item;
        }


        private List<ReportingBestSellingItem> ConvertDataTableToList(DataTable dt)
        {
            List<ReportingBestSellingItem> list = new List<ReportingBestSellingItem>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapDataRowToEntity(row));
            }
            return list;
        }

        public List<ReportingBestSellingItem> GetBestSalerItems(DateTime from, DateTime to)
        {
			string query = @"
SELECT
    i.ItemID,
    i.ItemName,
    SUM(od.Quantity) AS TotalQuantitySold,
    SUM(od.TotalAmount) AS TotalRevenue,

    -- % theo số lượng
    (SUM(od.Quantity) * 100.0) 
        / NULLIF(SUM(SUM(od.Quantity)) OVER (), 0) AS QuantityPercent,

    -- % theo doanh thu
    (SUM(od.TotalAmount) * 100.0) 
        / NULLIF(SUM(SUM(od.TotalAmount)) OVER (), 0) AS RevenuePercent

FROM orders o
INNER JOIN order_details od 
    ON o.OrderID = od.OrderID
INNER JOIN items i 
    ON od.ItemID = i.ItemID

WHERE
    o.OrderStatus = 'Completed'
    AND o.DeletedAt IS NULL
    AND o.OrderDate >= @FromDate
    AND o.OrderDate < DATE_ADD(@ToDate, INTERVAL 1 DAY)

GROUP BY
    i.ItemID, i.ItemName
ORDER BY
    TotalQuantitySold DESC;
";


			var parameters = new MySqlParameter[]
            {
                new MySqlParameter("@FromDate", MySqlDbType.Date) { Value = from.Date },
                new MySqlParameter("@ToDate", MySqlDbType.Date) { Value = to.Date }
            };

            var table = dbHelper.ExecuteQuery(query, parameters);
            if (table != null && table.Rows.Count > 0)
            {
                return ConvertDataTableToList(table);
            }

            return new List<ReportingBestSellingItem>();
        }

        public int GetTotalRevenue(DateTime from, DateTime to)
        {
            string query = @"
SELECT
    COALESCE(SUM(od.TotalAmount), 0) AS TotalRevenue
FROM orders o
LEFT JOIN order_details od
    ON o.OrderID = od.OrderID
WHERE
    o.OrderStatus = 'Completed'
    AND o.DeletedAt IS NULL
    AND o.OrderDate BETWEEN @FromDate AND @ToDate;
";
            var parameters = new MySqlParameter[]
            {
                new MySqlParameter("@FromDate", MySqlDbType.DateTime) { Value = from },
                new MySqlParameter("@ToDate", MySqlDbType.DateTime) { Value = to }
            };
            var table = dbHelper.ExecuteQuery(query, parameters);
            if (table != null && table.Rows.Count > 0)
            {
                var row = table.Rows[0];
                if (row["TotalRevenue"] != DBNull.Value)
                {
                    return Convert.ToInt32(row["TotalRevenue"]);
                }
            }
            return 0;
        }

        public Dictionary<DateTime, int> GetDailyRevenue(DateTime from, DateTime to)
        {
            string query = @"
SELECT
    DATE(o.OrderDate) AS RevenueDate,
    COALESCE(SUM(od.TotalAmount), 0) AS DailyRevenue
FROM orders o
LEFT JOIN order_details od
    ON o.OrderID = od.OrderID
WHERE
    o.OrderStatus = 'Completed'
    AND o.DeletedAt IS NULL
    AND o.OrderDate BETWEEN @FromDate AND @ToDate
GROUP BY
    DATE(o.OrderDate)
ORDER BY
    RevenueDate ASC;
";
            var parameters = new MySqlParameter[]
            {
                new MySqlParameter("@FromDate", MySqlDbType.DateTime) { Value = from },
                new MySqlParameter("@ToDate", MySqlDbType.DateTime) { Value = to }
            };
            var table = dbHelper.ExecuteQuery(query, parameters);
            var dailyRevenues = new Dictionary<DateTime, int>();
            if (table != null && table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    var date = Convert.ToDateTime(row["RevenueDate"]).Date;
                    var value = row["DailyRevenue"] != DBNull.Value ? Convert.ToInt32(row["DailyRevenue"]) : 0;
                    dailyRevenues[date] = value;
                }
            }
            return dailyRevenues;
        }
    }
}

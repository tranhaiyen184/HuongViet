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
    COALESCE(SUM(od.Quantity), 0) AS TotalQuantitySold,
    COALESCE(SUM(od.TotalAmount), 0) AS TotalRevenue,
    
    -- Quantity percentage
    CASE 
        WHEN SUM(SUM(od.Quantity)) OVER () = 0 THEN 0
        ELSE 
            (COALESCE(SUM(od.Quantity), 0) * 100.0) 
            / NULLIF(SUM(SUM(od.Quantity)) OVER (), 0)
    END AS QuantityPercent,

    -- Revenue percentage
    CASE 
        WHEN SUM(SUM(od.TotalAmount)) OVER () = 0 THEN 0
        ELSE 
            (COALESCE(SUM(od.TotalAmount), 0) * 100.0) 
            / NULLIF(SUM(SUM(od.TotalAmount)) OVER (), 0)
    END AS RevenuePercent

FROM items i
LEFT JOIN order_details od 
    ON i.ItemID = od.ItemID
LEFT JOIN orders o
    ON od.OrderID = o.OrderID
    AND o.OrderStatus = 'Completed'
    AND o.DeletedAt IS NULL
    AND o.OrderDate BETWEEN @FromDate AND @ToDate

GROUP BY 
    i.ItemID, i.ItemName
ORDER BY 
    TotalQuantitySold DESC;
";

            var parameters = new MySqlParameter[]
            {
                new MySqlParameter("@FromDate", MySqlDbType.DateTime) { Value = from },
                new MySqlParameter("@ToDate", MySqlDbType.DateTime) { Value = to }
            };

            var table = dbHelper.ExecuteQuery(query, parameters);
            if (table != null && table.Rows.Count > 0)
            {
                return ConvertDataTableToList(table);
            }

            return null;
        }
    }
}

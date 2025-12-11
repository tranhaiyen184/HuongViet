using System;
using System.Collections.Generic;
using HuongViet.DAL;
using HuongViet.Models;

namespace HuongViet.BLL
{
    public class ReportBLL
    {
        private readonly ReportDAL reportDAL;

        public ReportBLL()
        {
            reportDAL = new ReportDAL();
        }

        private (DateTime from, DateTime to) GetDateRange(ReportType reportType, DateTime referenceDate)
        {
            DateTime from, to;
            switch (reportType)
            {
                case ReportType.Daily:
                    from = referenceDate.Date;
                    to = referenceDate.Date.AddDays(1).AddTicks(-1);
                    break;
                case ReportType.Weekly:
                    int diff = (7 + (referenceDate.DayOfWeek - DayOfWeek.Monday)) % 7;
                    from = referenceDate.AddDays(-diff).Date;                     // Start of week (Monday)
                    to = from.AddDays(7).AddTicks(-1);                            // End of week (Sunday 23:59:59.9999999)
                    break;
                case ReportType.Monthly:
                    from = new DateTime(referenceDate.Year, referenceDate.Month, 1);
                    to = from.AddMonths(1).AddTicks(-1);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(reportType), "Loại báo cáo không hợp lệ.");
            }
            return (from, to);
        }

        /// <summary>
        /// Lấy mặt hàng bán chạy nhất theo ngày, tuần tháng
        /// </summary>
        /// <returns>
        /// Mặt hàng bán chạy nhất hoặc null nếu không có dữ liệu
        /// Mặt hàng sẽ có các thuộc tính: 
        ///     ItemID, 
        ///     ItemName, 
        ///     TotalQuantitySold (số lượng đã bán), 
        ///     TotalRevenue (doanh thu tính theo sản phẩm), 
        ///     QuantityPercent (% theo số lượng), 
        ///     RevenuePercent (% theo doanh thu)
        /// </returns>
        public List<ReportingBestSellingItem> GetBestSalerItems(ReportType reportType)
        {
            try
            {
                var (from, to) = GetDateRange(reportType, DateTime.Now);
                if (from > to)
                    throw new ArgumentException("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.");

                return reportDAL.GetBestSalerItems(from, to);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy báo cáo mặt hàng bán chạy: {ex.Message}");
            }
        }

        public int GetTotalRevenue(ReportType reportType)
        {
            try
            {
                var (from, to) = GetDateRange(reportType, DateTime.Now);
                if (from > to)
                    throw new ArgumentException("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.");
                return reportDAL.GetTotalRevenue(from, to);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy tổng doanh thu: {ex.Message}");
            }
        }

        public List<int> GetDailyRevenue(ReportType reportType)
        {
            try
            {
                var (from, to) = GetDateRange(reportType, DateTime.Now);
                if (from > to)
                    throw new ArgumentException("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.");
                return reportDAL.GetDailyRevenue(from, to);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy doanh thu theo ngày: {ex.Message}");
            }
        }

        public enum ReportType
        {
            Daily,
            Weekly,
            Monthly
        }
    }
}

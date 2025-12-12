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
                case ReportType.Monthly:
                    from = new DateTime(referenceDate.Year, referenceDate.Month, 1);
                    to = from.AddMonths(1).AddTicks(-1);
                    break;
                case ReportType.Yearly:
                    from = new DateTime(referenceDate.Year, 1, 1);
                    to = from.AddYears(1).AddTicks(-1);
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

        public List<ReportingBestSellingItem> GetBestSalerItems(DateTime startDate, DateTime endDate)
        {
            try
            {
                if (startDate > endDate)
                    throw new ArgumentException("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.");

                DateTime from = startDate.Date;
                DateTime to = endDate.Date.AddDays(1).AddTicks(-1);
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

        public int GetTotalRevenue(DateTime startDate, DateTime endDate)
        {
            try
            {
                if (startDate > endDate)
                    throw new ArgumentException("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.");

                DateTime from = startDate.Date;
                DateTime to = endDate.Date.AddDays(1).AddTicks(-1);
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
                return BuildDailySeries(from, to);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy doanh thu theo ngày: {ex.Message}");
            }
        }

        public List<int> GetMonthlyRevenueTotals(int year)
        {
            try
            {
                var monthlyTotals = new List<int>(12);
                for (int month = 1; month <= 12; month++)
                {
                    var from = new DateTime(year, month, 1);
                    var to = from.AddMonths(1).AddTicks(-1);
                    monthlyTotals.Add(reportDAL.GetTotalRevenue(from, to));
                }
                return monthlyTotals;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy doanh thu theo tháng trong năm: {ex.Message}");
            }
        }

        public List<int> GetYearlyRevenueTotals(int startYear, int yearCount)
        {
            if (yearCount <= 0)
                throw new ArgumentException("Số năm phải lớn hơn 0.");

            try
            {
                var yearlyTotals = new List<int>(yearCount);
                for (int i = 0; i < yearCount; i++)
                {
                    int year = startYear + i;
                    var from = new DateTime(year, 1, 1);
                    var to = from.AddYears(1).AddTicks(-1);
                    yearlyTotals.Add(reportDAL.GetTotalRevenue(from, to));
                }
                return yearlyTotals;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy doanh thu theo năm: {ex.Message}");
            }
        }

        public List<int> GetDailyRevenue(DateTime startDate, DateTime endDate)
        {
            try
            {
                if (startDate > endDate)
                    throw new ArgumentException("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.");

                DateTime from = startDate.Date;
                DateTime to = endDate.Date.AddDays(1).AddTicks(-1);
                return BuildDailySeries(from, to);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy doanh thu theo ngày: {ex.Message}");
            }
        }

        private List<int> BuildDailySeries(DateTime fromDateInclusive, DateTime toDateInclusive)
        {
            var map = reportDAL.GetDailyRevenue(fromDateInclusive, toDateInclusive);
            var series = new List<int>();
            for (var d = fromDateInclusive.Date; d <= toDateInclusive.Date; d = d.AddDays(1))
            {
                if (map.TryGetValue(d, out var value))
                    series.Add(value);
                else
                    series.Add(0);
            }
            return series;
        }

        public enum ReportType
        {
            Daily,
            Monthly,
            Yearly
        }
    }
}

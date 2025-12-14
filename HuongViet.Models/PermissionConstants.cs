using System.Collections.Generic;

namespace HuongViet.Models
{
    public static class PermissionConstants
    {
        public const string MenuReport = "MENU_REPORT";
        public const string MenuTableSetup = "MENU_TABLE_SETUP";
        public const string MenuFood = "MENU_FOOD";
        public const string MenuSales = "MENU_SALES";
        public const string MenuReservation = "MENU_RESERVATION";
        public const string MenuVoucher = "MENU_VOUCHER";
        public const string MenuStaff = "MENU_STAFF";

        public static readonly IReadOnlyDictionary<string, string> MenuPermissionDisplayNames =
            new Dictionary<string, string>
            {
                { MenuReport, "Thống kê" },
                { MenuTableSetup, "Thiết lập bàn" },
                { MenuFood, "Thực đơn" },
                { MenuSales, "Bán hàng" },
                { MenuReservation, "Đặt bàn" },
                { MenuVoucher, "Voucher" },
                { MenuStaff, "Nhân viên" }
            };
    }
}

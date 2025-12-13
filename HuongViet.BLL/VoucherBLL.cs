using HuongViet.DAL;
using HuongViet.Models;
using System;
using System.Collections.Generic;

namespace HuongViet.BLL
{
    public class VoucherBLL
    {
        private readonly VoucherDAL voucherDAL;

        public VoucherBLL()
        {
            this.voucherDAL = new VoucherDAL();
        }

        public List<Voucher> GetAll()
        {
            try
            {
                return voucherDAL.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách voucher: {ex.Message}");
            }
        }

        public List<Voucher> GetActiveVouchers()
        {
            try
            {
                return voucherDAL.GetActiveVouchers();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách voucher đang hoạt động: {ex.Message}");
            }
        }

        public Voucher GetById(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id))
                {
                    throw new ArgumentException("Mã voucher không được để trống");
                }

                return voucherDAL.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy thông tin voucher: {ex.Message}");
            }
        }

        public Voucher GetByCode(string code)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(code))
                {
                    throw new ArgumentException("Mã code voucher không được để trống");
                }

                return voucherDAL.GetByCode(code);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tìm voucher theo code: {ex.Message}");
            }
        }

        public bool Insert(Voucher voucher)
        {
            try
            {
                ValidateVoucher(voucher);

                // Check if ID already exists
                if (voucherDAL.Exists(voucher.Id))
                {
                    throw new Exception("Mã voucher đã tồn tại");
                }

                // Check if code already exists
                if (voucherDAL.IsCodeExists(voucher.Code))
                {
                    throw new Exception("Mã code voucher đã được sử dụng");
                }

                return voucherDAL.Insert(voucher);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm voucher: {ex.Message}");
            }
        }

        public bool Update(Voucher voucher)
        {
            try
            {
                ValidateVoucher(voucher);

                // Check if voucher exists
                if (!voucherDAL.Exists(voucher.Id))
                {
                    throw new Exception("Voucher không tồn tại");
                }

                // Check if code already exists (exclude current voucher)
                if (voucherDAL.IsCodeExists(voucher.Code, voucher.Id))
                {
                    throw new Exception("Mã code voucher đã được sử dụng");
                }

                return voucherDAL.Update(voucher);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật voucher: {ex.Message}");
            }
        }

        public bool Delete(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id))
                {
                    throw new ArgumentException("Mã voucher không được để trống");
                }

                if (!voucherDAL.Exists(id))
                {
                    throw new Exception("Voucher không tồn tại");
                }

                return voucherDAL.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa voucher: {ex.Message}");
            }
        }

        public bool Exists(string id)
        {
            try
            {
                return voucherDAL.Exists(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi kiểm tra voucher: {ex.Message}");
            }
        }

        public bool IsVoucherValid(string code)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(code))
                {
                    return false;
                }

                Voucher voucher = voucherDAL.GetByCode(code);
                if (voucher == null)
                {
                    return false;
                }

                return IsVoucherValid(voucher);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi kiểm tra tính hợp lệ của voucher: {ex.Message}");
            }
        }

        public bool IsVoucherValid(Voucher voucher)
        {
            if (voucher == null)
            {
                return false;
            }

            // Check if voucher is active
            if (!voucher.Active)
            {
                return false;
            }

            // Check start date
            if (voucher.StartAt.HasValue && voucher.StartAt.Value > DateTime.Now)
            {
                return false;
            }

            // Check end date
            if (voucher.EndAt.HasValue && voucher.EndAt.Value < DateTime.Now)
            {
                return false;
            }

            // Check usage limit
            if (voucher.UsageLimit.HasValue && voucher.UsageCount >= voucher.UsageLimit.Value)
            {
                return false;
            }

            return true;
        }

        public bool UseVoucher(string code)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(code))
                {
                    throw new ArgumentException("Mã code voucher không được để trống");
                }

                Voucher voucher = voucherDAL.GetByCode(code);
                if (voucher == null)
                {
                    throw new Exception("Voucher không tồn tại");
                }

                if (!IsVoucherValid(voucher))
                {
                    throw new Exception("Voucher không hợp lệ hoặc đã hết hạn");
                }

                // Increment usage count
                return voucherDAL.IncrementUsageCount(voucher.Id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi sử dụng voucher: {ex.Message}");
            }
        }

        public decimal CalculateDiscount(string code, decimal originalAmount)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(code))
                {
                    throw new ArgumentException("Mã code voucher không được để trống");
                }

                Voucher voucher = voucherDAL.GetByCode(code);
                if (voucher == null)
                {
                    throw new Exception("Voucher không tồn tại");
                }

                if (!IsVoucherValid(voucher))
                {
                    throw new Exception("Voucher không hợp lệ hoặc đã hết hạn");
                }

                return CalculateDiscount(voucher, originalAmount);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tính toán giảm giá: {ex.Message}");
            }
        }

        public decimal CalculateDiscount(Voucher voucher, decimal originalAmount)
        {
            if (voucher == null || originalAmount <= 0)
            {
                return 0;
            }

            decimal discountAmount = originalAmount * (voucher.Percentage / 100);
            return discountAmount;
        }

        public string GenerateNewVoucherID()
        {
            try
            {
                var vouchers = voucherDAL.GetAll();
                int maxNumber = 0;

                foreach (var voucher in vouchers)
                {
                    if (voucher.Id.StartsWith("VCH"))
                    {
                        string numberPart = voucher.Id.Substring(3);
                        if (int.TryParse(numberPart, out int number))
                        {
                            maxNumber = Math.Max(maxNumber, number);
                        }
                    }
                }

                return $"VCH{(maxNumber + 1).ToString("D6")}";
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tạo mã voucher: {ex.Message}");
            }
        }

        public string GenerateVoucherID()
        {
            // Generate GUID-based ID (36 characters as per schema)
            return Guid.NewGuid().ToString();
        }

        public PagedResult<Voucher> SearchVouchers(SearchCriteria criteria)
        {
            try
            {
                if (criteria == null)
                {
                    criteria = new SearchCriteria
                    {
                        PageNumber = 1,
                        PageSize = 20
                    };
                }

                // Validate page number
                if (criteria.PageNumber < 1)
                {
                    criteria.PageNumber = 1;
                }

                // Validate page size
                if (criteria.PageSize < 1)
                {
                    criteria.PageSize = 20;
                }

                return voucherDAL.SearchVouchers(criteria);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tìm kiếm voucher: {ex.Message}");
            }
        }

        private void ValidateVoucher(Voucher voucher)
        {
            if (voucher == null)
            {
                throw new ArgumentNullException(nameof(voucher), "Thông tin voucher không được null");
            }

            if (string.IsNullOrWhiteSpace(voucher.Id))
            {
                throw new ArgumentException("Mã voucher không được để trống");
            }

            if (string.IsNullOrWhiteSpace(voucher.Code))
            {
                throw new ArgumentException("Mã code voucher không được để trống");
            }

            if (voucher.Code.Length > 64)
            {
                throw new ArgumentException("Mã code voucher không được vượt quá 64 ký tự");
            }

            if (voucher.Percentage <= 0 || voucher.Percentage > 100)
            {
                throw new ArgumentException("Phần trăm giảm giá phải từ 0 đến 100");
            }

            // Validate date range
            if (voucher.StartAt.HasValue && voucher.EndAt.HasValue)
            {
                if (voucher.StartAt.Value >= voucher.EndAt.Value)
                {
                    throw new ArgumentException("Ngày bắt đầu phải nhỏ hơn ngày kết thúc");
                }
            }

            // Validate usage limit
            if (voucher.UsageLimit.HasValue && voucher.UsageLimit.Value < 0)
            {
                throw new ArgumentException("Giới hạn số lần sử dụng phải lớn hơn hoặc bằng 0");
            }

            if (voucher.UsageCount < 0)
            {
                throw new ArgumentException("Số lần đã sử dụng phải lớn hơn hoặc bằng 0");
            }

            if (voucher.UsageLimit.HasValue && voucher.UsageCount > voucher.UsageLimit.Value)
            {
                throw new ArgumentException("Số lần đã sử dụng không được vượt quá giới hạn");
            }
        }
    }
}


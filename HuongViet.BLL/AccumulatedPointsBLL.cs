using HuongViet.DAL;
using HuongViet.Models;
using System;
using System.Collections.Generic;

namespace HuongViet.BLL
{
    public class AccumulatedPointsBLL
    {
        private readonly AccumulatedPointsDAL pointsDAL;
        private readonly CustomerDAL customerDAL;

        public AccumulatedPointsBLL()
        {
            this.pointsDAL = new AccumulatedPointsDAL();
            this.customerDAL = new CustomerDAL();
        }

        public List<AccumulatedPoints> GetAll()
        {
            try
            {
                return pointsDAL.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách điểm tích lũy: {ex.Message}");
            }
        }

        public AccumulatedPoints GetById(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id))
                {
                    throw new ArgumentException("Mã điểm tích lũy không được để trống");
                }

                return pointsDAL.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy thông tin điểm tích lũy: {ex.Message}");
            }
        }

        public AccumulatedPoints GetByCustomer(string customerId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(customerId))
                {
                    throw new ArgumentException("Mã khách hàng không được để trống");
                }

                return pointsDAL.GetByCustomer(customerId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy điểm tích lũy theo khách hàng: {ex.Message}");
            }
        }

        public List<AccumulatedPoints> GetHistoryByCustomer(string customerId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(customerId))
                {
                    throw new ArgumentException("Mã khách hàng không được để trống");
                }

                return pointsDAL.GetHistoryByCustomer(customerId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy lịch sử điểm tích lũy: {ex.Message}");
            }
        }

        public bool Insert(AccumulatedPoints point)
        {
            try
            {
                ValidateAccumulatedPoints(point);

                // Check if ID already exists
                if (pointsDAL.Exists(point.AccumulatedPointID))
                {
                    throw new Exception("Mã điểm tích lũy đã tồn tại");
                }

                // Check if customer exists
                if (!customerDAL.Exists(point.CustomerID))
                {
                    throw new Exception("Khách hàng không tồn tại");
                }

                return pointsDAL.Insert(point);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm điểm tích lũy: {ex.Message}");
            }
        }

        public bool Update(AccumulatedPoints point)
        {
            try
            {
                ValidateAccumulatedPoints(point);

                // Check if point exists
                if (!pointsDAL.Exists(point.AccumulatedPointID))
                {
                    throw new Exception("Điểm tích lũy không tồn tại");
                }

                // Check if customer exists
                if (!customerDAL.Exists(point.CustomerID))
                {
                    throw new Exception("Khách hàng không tồn tại");
                }

                return pointsDAL.Update(point);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật điểm tích lũy: {ex.Message}");
            }
        }

        public bool UpdatePoints(string customerId, int pointsToAdd)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(customerId))
                {
                    throw new ArgumentException("Mã khách hàng không được để trống");
                }

                if (!customerDAL.Exists(customerId))
                {
                    throw new Exception("Khách hàng không tồn tại");
                }

                if (pointsToAdd == 0)
                {
                    return true; // No change needed
                }

                return pointsDAL.UpdatePoints(customerId, pointsToAdd);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật điểm tích lũy: {ex.Message}");
            }
        }

        public bool UsePoints(string customerId, int pointsToUse)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(customerId))
                {
                    throw new ArgumentException("Mã khách hàng không được để trống");
                }

                if (!customerDAL.Exists(customerId))
                {
                    throw new Exception("Khách hàng không tồn tại");
                }

                if (pointsToUse <= 0)
                {
                    throw new ArgumentException("Số điểm sử dụng phải lớn hơn 0");
                }

                // Check if customer has enough points
                var currentPoints = pointsDAL.GetByCustomer(customerId);
                if (currentPoints == null || currentPoints.AccumPoint < pointsToUse)
                {
                    throw new Exception("Không đủ điểm để sử dụng");
                }

                return pointsDAL.UsePoints(customerId, pointsToUse);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi sử dụng điểm tích lũy: {ex.Message}");
            }
        }

        public bool Delete(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id))
                {
                    throw new ArgumentException("Mã điểm tích lũy không được để trống");
                }

                if (!pointsDAL.Exists(id))
                {
                    throw new Exception("Điểm tích lũy không tồn tại");
                }

                return pointsDAL.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa điểm tích lũy: {ex.Message}");
            }
        }

        public bool Exists(string id)
        {
            try
            {
                return pointsDAL.Exists(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi kiểm tra điểm tích lũy: {ex.Message}");
            }
        }

        public bool CustomerHasPoints(string customerId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(customerId))
                {
                    return false;
                }

                return pointsDAL.CustomerHasPoints(customerId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi kiểm tra điểm khách hàng: {ex.Message}");
            }
        }

        public string GenerateNewId()
        {
            try
            {
                return pointsDAL.GenerateNewId();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tạo mã điểm tích lũy: {ex.Message}");
            }
        }

        public PagedResult<AccumulatedPoints> SearchPoints(SearchCriteria criteria, string customerId = null)
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

                return pointsDAL.SearchPoints(criteria, customerId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tìm kiếm điểm tích lũy: {ex.Message}");
            }
        }

        private void ValidateAccumulatedPoints(AccumulatedPoints point)
        {
            if (point == null)
            {
                throw new ArgumentNullException(nameof(point), "Thông tin điểm tích lũy không được null");
            }

            if (string.IsNullOrWhiteSpace(point.AccumulatedPointID))
            {
                throw new ArgumentException("Mã điểm tích lũy không được để trống");
            }

            if (string.IsNullOrWhiteSpace(point.CustomerID))
            {
                throw new ArgumentException("Mã khách hàng không được để trống");
            }

            if (point.AccumPoint < 0)
            {
                throw new ArgumentException("Điểm hiện tại không được âm");
            }

            if (point.TotalAccumPoint < 0)
            {
                throw new ArgumentException("Tổng điểm tích lũy không được âm");
            }

            if (point.AccumPoint > point.TotalAccumPoint)
            {
                throw new ArgumentException("Điểm hiện tại không được lớn hơn tổng điểm tích lũy");
            }
        }

        /// <summary>
        /// Tính điểm tích lũy từ số tiền đơn hàng
        /// </summary>
        public int CalculatePointsFromAmount(decimal amount)
        {
            // 1 điểm cho mỗi 10,000 VND
            return (int)(amount / 10000);
        }

        /// <summary>
        /// Tính giá trị tiền từ điểm tích lũy
        /// </summary>
        public decimal CalculateAmountFromPoints(int points)
        {
            // 1 điểm = 1,000 VND khi sử dụng
            return points * 1000;
        }

        /// <summary>
        /// Kiểm tra xem khách hàng có đủ điểm để sử dụng không
        /// </summary>
        public bool CanUsePoints(string customerId, int pointsToUse)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(customerId) || pointsToUse <= 0)
                {
                    return false;
                }

                var currentPoints = pointsDAL.GetByCustomer(customerId);
                return currentPoints != null && currentPoints.AccumPoint >= pointsToUse;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Lấy số điểm hiện tại của khách hàng
        /// </summary>
        public int GetCurrentPoints(string customerId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(customerId))
                {
                    return 0;
                }

                var points = pointsDAL.GetByCustomer(customerId);
                return points?.AccumPoint ?? 0;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Lấy tổng điểm tích lũy của khách hàng
        /// </summary>
        public int GetTotalAccumulatedPoints(string customerId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(customerId))
                {
                    return 0;
                }

                var points = pointsDAL.GetByCustomer(customerId);
                return points?.TotalAccumPoint ?? 0;
            }
            catch
            {
                return 0;
            }
        }
    }
}

using HuongViet.DAL;
using HuongViet.Models;
using System;
using System.Collections.Generic;

namespace HuongViet.BLL
{
    public class FloorBLL
    {
        private readonly FloorDAL floorDAL;

        public FloorBLL()
        {
            floorDAL = new FloorDAL();
        }

        /// <summary>
        /// Lấy tất cả tầng
        /// </summary>
        /// <returns>Danh sách tầng</returns>
        public List<Floor> GetAllFloors()
        {
            try
            {
                return floorDAL.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách tầng: {ex.Message}");
            }
        }

        /// <summary>
        /// Lấy tầng theo ID
        /// </summary>
        /// <param name="floorId">ID tầng</param>
        /// <returns>Thông tin tầng</returns>
        public Floor GetFloorById(string floorId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(floorId))
                    return null;

                return floorDAL.GetById(floorId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy thông tin tầng: {ex.Message}");
            }
        }

        /// <summary>
        /// Thêm tầng mới
        /// </summary>
        /// <param name="floor">Thông tin tầng</param>
        /// <returns>True nếu thành công</returns>
        public bool AddFloor(Floor floor)
        {
            try
            {
                // Validate input
                string validationError = ValidateFloor(floor);
                if (!string.IsNullOrEmpty(validationError))
                {
                    throw new Exception(validationError);
                }

                // Check if floor number already exists
                if (floorDAL.IsFloorNumberExists(floor.FloorNumber))
                {
                    throw new Exception("Số tầng đã tồn tại!");
                }

                // Generate ID if not provided
                if (string.IsNullOrWhiteSpace(floor.FloorID))
                {
                    floor.FloorID = GenerateFloorId();
                }

                floor.CreatedAt = DateTime.Now;
                floor.UpdatedAt = DateTime.Now;

                return floorDAL.Insert(floor);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm tầng: {ex.Message}");
            }
        }

        /// <summary>
        /// Cập nhật tầng
        /// </summary>
        /// <param name="floor">Thông tin tầng</param>
        /// <returns>True nếu thành công</returns>
        public bool UpdateFloor(Floor floor)
        {
            try
            {
                // Validate input
                string validationError = ValidateFloor(floor);
                if (!string.IsNullOrEmpty(validationError))
                {
                    throw new Exception(validationError);
                }

                // Check if floor exists
                if (!floorDAL.Exists(floor.FloorID))
                {
                    throw new Exception("Tầng không tồn tại!");
                }

                // Check if floor number already exists (excluding current floor)
                if (floorDAL.IsFloorNumberExists(floor.FloorNumber, floor.FloorID))
                {
                    throw new Exception("Số tầng đã tồn tại!");
                }

                floor.UpdatedAt = DateTime.Now;

                return floorDAL.Update(floor);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật tầng: {ex.Message}");
            }
        }

        /// <summary>
        /// Xóa tầng
        /// </summary>
        /// <param name="floorId">ID tầng</param>
        /// <returns>True nếu thành công</returns>
        public bool DeleteFloor(string floorId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(floorId))
                {
                    throw new Exception("ID tầng không hợp lệ!");
                }

                // Check if floor exists
                if (!floorDAL.Exists(floorId))
                {
                    throw new Exception("Tầng không tồn tại!");
                }

                return floorDAL.Delete(floorId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa tầng: {ex.Message}");
            }
        }

        #region Private Methods

        /// <summary>
        /// Validate thông tin tầng
        /// </summary>
        /// <param name="floor">Thông tin tầng</param>
        /// <returns>Thông báo lỗi hoặc null nếu hợp lệ</returns>
        private string ValidateFloor(Floor floor)
        {
            if (floor == null)
                return "Thông tin tầng không hợp lệ!";

            if (floor.FloorNumber < 0)
                return "Số tầng phải lớn hơn hoặc bằng 0!";

            return null; // Valid
        }

        /// <summary>
        /// Tạo ID tầng tự động
        /// </summary>
        /// <returns>ID tầng</returns>
        private string GenerateFloorId()
        {
            return "FLR" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        #endregion
    }
}


using HuongViet.DAL;
using HuongViet.Models;
using System;
using System.Collections.Generic;

namespace HuongViet.BLL
{
    public class AreaBLL
    {
        private readonly AreaDAL areaDAL;

        public AreaBLL()
        {
            areaDAL = new AreaDAL();
        }

        /// <summary>
        /// Lấy tất cả khu vực
        /// </summary>
        /// <returns>Danh sách khu vực</returns>
        public List<Area> GetAllAreas()
        {
            try
            {
                return areaDAL.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách khu vực: {ex.Message}");
            }
        }

        /// <summary>
        /// Lấy khu vực theo ID
        /// </summary>
        /// <param name="areaId">ID khu vực</param>
        /// <returns>Thông tin khu vực</returns>
        public Area GetAreaById(string areaId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(areaId))
                    return null;

                return areaDAL.GetById(areaId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy thông tin khu vực: {ex.Message}");
            }
        }

        /// <summary>
        /// Thêm khu vực mới
        /// </summary>
        /// <param name="area">Thông tin khu vực</param>
        /// <returns>True nếu thành công</returns>
        public bool AddArea(Area area)
        {
            try
            {
                // Validate input
                string validationError = ValidateArea(area);
                if (!string.IsNullOrEmpty(validationError))
                {
                    throw new Exception(validationError);
                }

                // Check if area name already exists
                if (areaDAL.IsAreaNameExists(area.AreaName))
                {
                    throw new Exception("Tên khu vực đã tồn tại!");
                }

                // Generate ID if not provided
                if (string.IsNullOrWhiteSpace(area.AreaID))
                {
                    area.AreaID = GenerateAreaId();
                }

                area.CreatedAt = DateTime.Now;
                area.UpdatedAt = DateTime.Now;

                return areaDAL.Insert(area);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm khu vực: {ex.Message}");
            }
        }

        /// <summary>
        /// Cập nhật khu vực
        /// </summary>
        /// <param name="area">Thông tin khu vực</param>
        /// <returns>True nếu thành công</returns>
        public bool UpdateArea(Area area)
        {
            try
            {
                // Validate input
                string validationError = ValidateArea(area);
                if (!string.IsNullOrEmpty(validationError))
                {
                    throw new Exception(validationError);
                }

                // Check if area exists
                if (!areaDAL.Exists(area.AreaID))
                {
                    throw new Exception("Khu vực không tồn tại!");
                }

                // Check if area name already exists (excluding current area)
                if (areaDAL.IsAreaNameExists(area.AreaName, area.AreaID))
                {
                    throw new Exception("Tên khu vực đã tồn tại!");
                }

                area.UpdatedAt = DateTime.Now;

                return areaDAL.Update(area);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật khu vực: {ex.Message}");
            }
        }

        /// <summary>
        /// Xóa khu vực
        /// </summary>
        /// <param name="areaId">ID khu vực</param>
        /// <returns>True nếu thành công</returns>
        public bool DeleteArea(string areaId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(areaId))
                {
                    throw new Exception("ID khu vực không hợp lệ!");
                }

                // Check if area exists
                if (!areaDAL.Exists(areaId))
                {
                    throw new Exception("Khu vực không tồn tại!");
                }

                return areaDAL.Delete(areaId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa khu vực: {ex.Message}");
            }
        }

        #region Private Methods

        /// <summary>
        /// Validate thông tin khu vực
        /// </summary>
        /// <param name="area">Thông tin khu vực</param>
        /// <returns>Thông báo lỗi hoặc null nếu hợp lệ</returns>
        private string ValidateArea(Area area)
        {
            if (area == null)
                return "Thông tin khu vực không hợp lệ!";

            if (string.IsNullOrWhiteSpace(area.AreaName))
                return "Vui lòng nhập tên khu vực!";

            if (area.AreaName.Length > 30)
                return "Tên khu vực không được vượt quá 30 ký tự!";

            return null; // Valid
        }

        /// <summary>
        /// Tạo ID khu vực tự động
        /// </summary>
        /// <returns>ID khu vực</returns>
        private string GenerateAreaId()
        {
            return "AREA" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        #endregion
    }
}


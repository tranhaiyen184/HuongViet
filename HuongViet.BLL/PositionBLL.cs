using System;
using System.Collections.Generic;
using HuongViet.DAL;
using HuongViet.Models;

namespace HuongViet.BLL
{
    public class PositionBLL
    {
        private readonly PositionDAL positionDAL;
        private readonly DepartmentDAL departmentDAL;

        public PositionBLL()
        {
            positionDAL = new PositionDAL();
            departmentDAL = new DepartmentDAL();
        }

        /// <summary>
        /// Lấy tất cả vị trí
        /// </summary>
        /// <returns>Danh sách vị trí</returns>
        public List<Position> GetAllPositions()
        {
            try
            {
                return positionDAL.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách vị trí: {ex.Message}");
            }
        }

        /// <summary>
        /// Lấy vị trí theo ID
        /// </summary>
        /// <param name="positionId">ID vị trí</param>
        /// <returns>Thông tin vị trí</returns>
        public Position GetPositionById(string positionId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(positionId))
                    return null;

                return positionDAL.GetById(positionId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy thông tin vị trí: {ex.Message}");
            }
        }

        /// <summary>
        /// Thêm vị trí mới
        /// </summary>
        /// <param name="position">Thông tin vị trí</param>
        /// <returns>True nếu thành công</returns>
        public bool AddPosition(Position position)
        {
            try
            {
                // Validate input
                string validationError = ValidatePosition(position);
                if (!string.IsNullOrEmpty(validationError))
                {
                    throw new Exception(validationError);
                }

                // Check if position name already exists
                if (positionDAL.IsPositionNameExists(position.PositionName))
                {
                    throw new Exception("Tên vị trí đã tồn tại!");
                }

                // Generate ID if not provided
                if (string.IsNullOrWhiteSpace(position.PositionID))
                {
                    position.PositionID = GeneratePositionId();
                }

                position.CreatedAt = DateTime.Now;
                position.UpdatedAt = DateTime.Now;

                return positionDAL.Insert(position);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm vị trí: {ex.Message}");
            }
        }

        /// <summary>
        /// Cập nhật vị trí
        /// </summary>
        /// <param name="position">Thông tin vị trí</param>
        /// <returns>True nếu thành công</returns>
        public bool UpdatePosition(Position position)
        {
            try
            {
                // Validate input
                string validationError = ValidatePosition(position);
                if (!string.IsNullOrEmpty(validationError))
                {
                    throw new Exception(validationError);
                }

                // Check if position exists
                if (!positionDAL.Exists(position.PositionID))
                {
                    throw new Exception("Vị trí không tồn tại!");
                }

                // Check if position name already exists (excluding current position)
                if (positionDAL.IsPositionNameExists(position.PositionName, position.PositionID))
                {
                    throw new Exception("Tên vị trí đã tồn tại!");
                }

                position.UpdatedAt = DateTime.Now;

                return positionDAL.Update(position);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật vị trí: {ex.Message}");
            }
        }

        /// <summary>
        /// Xóa vị trí
        /// </summary>
        /// <param name="positionId">ID vị trí</param>
        /// <returns>True nếu thành công</returns>
        public bool DeletePosition(string positionId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(positionId))
                {
                    throw new Exception("ID vị trí không hợp lệ!");
                }

                // Check if position exists
                if (!positionDAL.Exists(positionId))
                {
                    throw new Exception("Vị trí không tồn tại!");
                }

                // Check if position has employees
                int employeeCount = positionDAL.GetPositionEmployeeCount(positionId);
                if (employeeCount > 0)
                {
                    throw new Exception($"Không thể xóa vị trí này vì có {employeeCount} nhân viên đang thuộc vị trí này!");
                }

                return positionDAL.Delete(positionId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa vị trí: {ex.Message}");
            }
        }

        /// <summary>
        /// Tìm kiếm vị trí
        /// </summary>
        /// <param name="searchTerm">Từ khóa tìm kiếm</param>
        /// <returns>Danh sách vị trí</returns>
        public List<Position> SearchPositions(string searchTerm)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(searchTerm))
                    return GetAllPositions();

                var searchCriteria = new SearchCriteria
                {
                    SearchTerm = searchTerm,
                    PageNumber = 1,
                    PageSize = int.MaxValue // Get all results
                };

                var result = positionDAL.Search(searchCriteria);
                return result.Data;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tìm kiếm vị trí: {ex.Message}");
            }
        }

        /// <summary>
        /// Lấy danh sách vị trí với phân trang
        /// </summary>
        /// <param name="criteria">Tiêu chí tìm kiếm và phân trang</param>
        /// <returns>Kết quả phân trang</returns>
        public PagedResult<Position> GetPositionsWithPaging(SearchCriteria criteria)
        {
            try
            {
                return positionDAL.Search(criteria);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách vị trí: {ex.Message}");
            }
        }

        /// <summary>
        /// Lấy danh sách vị trí theo phòng ban
        /// </summary>
        /// <param name="departmentId">ID phòng ban</param>
        /// <returns>Danh sách vị trí</returns>
        public List<Position> GetPositionsByDepartment(string departmentId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(departmentId))
                    return new List<Position>();

                return positionDAL.GetPositionsByDepartment(departmentId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách vị trí theo phòng ban: {ex.Message}");
            }
        }

        /// <summary>
        /// Lấy danh sách phòng ban (để hiển thị trong ComboBox)
        /// </summary>
        /// <returns>Danh sách phòng ban</returns>
        public List<Department> GetAllDepartments()
        {
            try
            {
                return departmentDAL.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách phòng ban: {ex.Message}");
            }
        }

        /// <summary>
        /// Lấy vị trí với thông tin phòng ban
        /// </summary>
        /// <param name="positionId">ID vị trí</param>
        /// <returns>Vị trí với thông tin phòng ban</returns>
        public Position GetPositionWithDepartment(string positionId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(positionId))
                    return null;

                return positionDAL.GetPositionWithDepartment(positionId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy thông tin vị trí: {ex.Message}");
            }
        }

        #region Private Methods

        /// <summary>
        /// Validate thông tin vị trí
        /// </summary>
        /// <param name="position">Thông tin vị trí</param>
        /// <returns>Thông báo lỗi hoặc null nếu hợp lệ</returns>
        private string ValidatePosition(Position position)
        {
            if (position == null)
                return "Thông tin vị trí không hợp lệ!";

            if (string.IsNullOrWhiteSpace(position.PositionName))
                return "Vui lòng nhập tên vị trí!";

            if (position.PositionName.Length < 2)
                return "Tên vị trí phải có ít nhất 2 ký tự!";

            if (position.PositionName.Length > 50)
                return "Tên vị trí không được vượt quá 50 ký tự!";

            if (string.IsNullOrWhiteSpace(position.DepartmentID))
                return "Vui lòng chọn phòng ban!";

            // Check if department exists
            if (!departmentDAL.Exists(position.DepartmentID))
                return "Phòng ban không tồn tại!";

            return null; // Valid
        }

        /// <summary>
        /// Tạo ID vị trí tự động
        /// </summary>
        /// <returns>ID vị trí</returns>
        private string GeneratePositionId()
        {
            return "POS" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        #endregion
    }
}

using HuongViet.DAL;
using HuongViet.Models;
using System;
using System.Collections.Generic;

namespace HuongViet.BLL
{
    public class DepartmentBLL
    {
        private readonly DepartmentDAL departmentDAL;

        public DepartmentBLL()
        {
            departmentDAL = new DepartmentDAL();
        }

        /// <summary>
        /// Lấy tất cả phòng ban
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
        /// Lấy phòng ban theo ID
        /// </summary>
        /// <param name="departmentId">ID phòng ban</param>
        /// <returns>Department object</returns>
        public Department GetDepartmentById(string departmentId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(departmentId))
                    return null;

                return departmentDAL.GetById(departmentId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy thông tin phòng ban: {ex.Message}");
            }
        }

        /// <summary>
        /// Thêm phòng ban mới
        /// </summary>
        /// <param name="department">Thông tin phòng ban</param>
        /// <returns>True nếu thành công</returns>
        public bool AddDepartment(Department department)
        {
            try
            {
                // Validate thông tin
                string validationError = ValidateDepartment(department);
                if (!string.IsNullOrEmpty(validationError))
                {
                    throw new ArgumentException(validationError);
                }

                // Kiểm tra trùng tên
                if (departmentDAL.IsDepartmentNameExists(department.DepartmentName))
                {
                    throw new InvalidOperationException("Tên phòng ban đã tồn tại");
                }

                // Tạo ID mới nếu chưa có
                if (string.IsNullOrWhiteSpace(department.DepartmentID))
                {
                    department.DepartmentID = GenerateDepartmentId();
                }

                department.CreatedAt = DateTime.Now;
                department.UpdatedAt = DateTime.Now;

                return departmentDAL.Insert(department);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm phòng ban: {ex.Message}");
            }
        }

        /// <summary>
        /// Cập nhật phòng ban
        /// </summary>
        /// <param name="department">Thông tin phòng ban</param>
        /// <returns>True nếu thành công</returns>
        public bool UpdateDepartment(Department department)
        {
            try
            {
                // Validate thông tin
                string validationError = ValidateDepartment(department);
                if (!string.IsNullOrEmpty(validationError))
                {
                    throw new ArgumentException(validationError);
                }

                // Kiểm tra phòng ban có tồn tại không
                var existingDept = departmentDAL.GetById(department.DepartmentID);
                if (existingDept == null)
                {
                    throw new InvalidOperationException("Không tìm thấy phòng ban cần cập nhật");
                }

                // Kiểm tra trùng tên (loại trừ chính nó)
                if (departmentDAL.IsDepartmentNameExists(department.DepartmentName, department.DepartmentID))
                {
                    throw new InvalidOperationException("Tên phòng ban đã tồn tại");
                }

                department.UpdatedAt = DateTime.Now;
                return departmentDAL.Update(department);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật phòng ban: {ex.Message}");
            }
        }

        /// <summary>
        /// Xóa phòng ban
        /// </summary>
        /// <param name="departmentId">ID phòng ban</param>
        /// <returns>True nếu thành công</returns>
        public bool DeleteDepartment(string departmentId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(departmentId))
                {
                    throw new ArgumentException("ID phòng ban không được để trống");
                }

                // Kiểm tra phòng ban có tồn tại không
                var department = departmentDAL.GetById(departmentId);
                if (department == null)
                {
                    throw new InvalidOperationException("Không tìm thấy phòng ban cần xóa");
                }

                // Kiểm tra phòng ban có đang được sử dụng không
                if (departmentDAL.IsDepartmentInUse(departmentId))
                {
                    throw new InvalidOperationException("Không thể xóa phòng ban đang có vị trí công việc");
                }

                return departmentDAL.Delete(departmentId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa phòng ban: {ex.Message}");
            }
        }

        /// <summary>
        /// Tìm kiếm phòng ban
        /// </summary>
        /// <param name="searchTerm">Từ khóa tìm kiếm</param>
        /// <returns>Danh sách phòng ban</returns>
        public List<Department> SearchDepartments(string searchTerm)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(searchTerm))
                    return GetAllDepartments();

                var searchCriteria = new SearchCriteria
                {
                    SearchTerm = searchTerm,
                    PageNumber = 1,
                    PageSize = int.MaxValue // Get all results
                };

                var result = departmentDAL.Search(searchCriteria);
                return result.Data;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tìm kiếm phòng ban: {ex.Message}");
            }
        }

        /// <summary>
        /// Lấy danh sách phòng ban với phân trang
        /// </summary>
        /// <param name="criteria">Tiêu chí tìm kiếm và phân trang</param>
        /// <returns>Kết quả phân trang</returns>
        public PagedResult<Department> GetDepartmentsWithPaging(SearchCriteria criteria)
        {
            try
            {
                return departmentDAL.GetDepartmentWithPositionCount(criteria);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách phòng ban: {ex.Message}");
            }
        }

        /// <summary>
        /// Lấy danh sách vị trí trong phòng ban
        /// </summary>
        /// <param name="departmentId">ID phòng ban</param>
        /// <returns>Danh sách vị trí</returns>
        public List<Position> GetDepartmentPositions(string departmentId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(departmentId))
                    return new List<Position>();

                // Use PositionDAL instead of DepartmentDAL
                var positionDAL = new PositionDAL();
                return positionDAL.GetPositionsByDepartment(departmentId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách vị trí: {ex.Message}");
            }
        }

        /// <summary>
        /// Lấy số lượng nhân viên trong phòng ban
        /// </summary>
        /// <param name="departmentId">ID phòng ban</param>
        /// <returns>Số lượng nhân viên</returns>
        public int GetDepartmentEmployeeCount(string departmentId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(departmentId))
                    return 0;

                return departmentDAL.GetDepartmentEmployeeCount(departmentId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy số lượng nhân viên: {ex.Message}");
            }
        }

        /// <summary>
        /// Validate thông tin phòng ban
        /// </summary>
        /// <param name="department">Thông tin phòng ban</param>
        /// <returns>Thông báo lỗi nếu có, null nếu hợp lệ</returns>
        private string ValidateDepartment(Department department)
        {
            if (department == null)
                return "Thông tin phòng ban không được để trống";

            if (string.IsNullOrWhiteSpace(department.DepartmentName))
                return "Tên phòng ban không được để trống";

            if (department.DepartmentName.Trim().Length < 2)
                return "Tên phòng ban phải có ít nhất 2 ký tự";

            if (department.DepartmentName.Trim().Length > 30)
                return "Tên phòng ban không được vượt quá 30 ký tự";

            return null; // Hợp lệ
        }

        /// <summary>
        /// Tạo ID phòng ban mới
        /// </summary>
        /// <returns>ID phòng ban</returns>
        private string GenerateDepartmentId()
        {
            return "DEPT" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        /// <summary>
        /// Kiểm tra tên phòng ban có tồn tại không
        /// </summary>
        /// <param name="departmentName">Tên phòng ban</param>
        /// <param name="excludeDepartmentId">ID phòng ban loại trừ (dùng khi update)</param>
        /// <returns>True nếu tồn tại</returns>
        public bool IsDepartmentNameExists(string departmentName, string excludeDepartmentId = null)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(departmentName))
                    return false;

                return departmentDAL.IsDepartmentNameExists(departmentName.Trim(), excludeDepartmentId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi kiểm tra tên phòng ban: {ex.Message}");
            }
        }
    }
}

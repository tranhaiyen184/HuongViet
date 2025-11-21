using HuongViet.DAL;
using HuongViet.Models;
using System;
using System.Collections.Generic;

namespace HuongViet.BLL
{
    public class UserBLL
    {
        private readonly UserDAL userDAL;
        private readonly PositionDAL positionDAL;
        private readonly RoleDAL roleDAL;

        public UserBLL()
        {
            userDAL = new UserDAL();
            positionDAL = new PositionDAL();
            roleDAL = new RoleDAL();
        }

        /// <summary>
        /// Lấy tất cả nhân viên
        /// </summary>
        /// <returns>Danh sách nhân viên</returns>
        public List<User> GetAllUsers()
        {
            try
            {
                return userDAL.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách nhân viên: {ex.Message}");
            }
        }

        /// <summary>
        /// Lấy nhân viên theo ID
        /// </summary>
        /// <param name="userId">ID nhân viên</param>
        /// <returns>Thông tin nhân viên</returns>
        public User GetUserById(string userId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userId))
                    return null;

                return userDAL.GetById(userId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy thông tin nhân viên: {ex.Message}");
            }
        }

        /// <summary>
        /// Thêm nhân viên mới
        /// </summary>
        /// <param name="user">Thông tin nhân viên</param>
        /// <returns>True nếu thành công</returns>
        public bool AddUser(User user)
        {
            try
            {
                // Validate input
                string validationError = ValidateUser(user);
                if (!string.IsNullOrEmpty(validationError))
                {
                    throw new Exception(validationError);
                }

                // Check if username already exists
                if (userDAL.IsUserNameExists(user.UserName))
                {
                    throw new Exception("Tên đăng nhập đã tồn tại!");
                }

                // Generate ID if not provided
                if (string.IsNullOrWhiteSpace(user.UserID))
                {
                    user.UserID = GenerateUserId();
                }

                user.CreatedAt = DateTime.Now;
                user.UpdatedAt = DateTime.Now;

                return userDAL.Insert(user);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm nhân viên: {ex.Message}");
            }
        }

        /// <summary>
        /// Cập nhật nhân viên
        /// </summary>
        /// <param name="user">Thông tin nhân viên</param>
        /// <returns>True nếu thành công</returns>
        public bool UpdateUser(User user)
        {
            try
            {
                // Validate input
                string validationError = ValidateUser(user);
                if (!string.IsNullOrEmpty(validationError))
                {
                    throw new Exception(validationError);
                }

                // Check if user exists
                if (!userDAL.Exists(user.UserID))
                {
                    throw new Exception("Nhân viên không tồn tại!");
                }

                // Check if username already exists (excluding current user)
                if (userDAL.IsUserNameExists(user.UserName, user.UserID))
                {
                    throw new Exception("Tên đăng nhập đã tồn tại!");
                }

                user.UpdatedAt = DateTime.Now;

                return userDAL.Update(user);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật nhân viên: {ex.Message}");
            }
        }

        /// <summary>
        /// Xóa nhân viên
        /// </summary>
        /// <param name="userId">ID nhân viên</param>
        /// <returns>True nếu thành công</returns>
        public bool DeleteUser(string userId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userId))
                {
                    throw new Exception("ID nhân viên không hợp lệ!");
                }

                // Check if user exists
                if (!userDAL.Exists(userId))
                {
                    throw new Exception("Nhân viên không tồn tại!");
                }

                return userDAL.Delete(userId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa nhân viên: {ex.Message}");
            }
        }

        /// <summary>
        /// Lấy danh sách nhân viên với phân trang và filter
        /// </summary>
        /// <param name="criteria">Tiêu chí tìm kiếm và phân trang</param>
        /// <param name="positionId">Lọc theo vị trí (null = tất cả)</param>
        /// <param name="status">Lọc theo trạng thái (null = tất cả)</param>
        /// <returns>Kết quả phân trang</returns>
        public PagedResult<User> GetUsersWithPaging(SearchCriteria criteria, string positionId = null, UserStatus? status = null)
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

                return userDAL.GetUsersWithDetails(criteria, positionId, status);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách nhân viên: {ex.Message}");
            }
        }

        /// <summary>
        /// Tìm kiếm nhân viên với phân trang
        /// </summary>
        /// <param name="criteria">Tiêu chí tìm kiếm và phân trang</param>
        /// <returns>Kết quả phân trang</returns>
        public PagedResult<User> SearchUsers(SearchCriteria criteria)
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

                return userDAL.Search(criteria);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tìm kiếm nhân viên: {ex.Message}");
            }
        }

        /// <summary>
        /// Lấy danh sách vị trí (để hiển thị trong ComboBox)
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
        /// Lấy danh sách vai trò (để hiển thị trong ComboBox)
        /// </summary>
        /// <returns>Danh sách vai trò</returns>
        public List<Role> GetAllRoles()
        {
            try
            {
                return roleDAL.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách vai trò: {ex.Message}");
            }
        }

        #region Private Methods

        /// <summary>
        /// Validate thông tin nhân viên
        /// </summary>
        /// <param name="user">Thông tin nhân viên</param>
        /// <returns>Thông báo lỗi hoặc null nếu hợp lệ</returns>
        private string ValidateUser(User user)
        {
            if (user == null)
                return "Thông tin nhân viên không hợp lệ!";

            if (string.IsNullOrWhiteSpace(user.FirstName))
                return "Vui lòng nhập tên!";

            if (string.IsNullOrWhiteSpace(user.LastName))
                return "Vui lòng nhập họ!";

            if (string.IsNullOrWhiteSpace(user.UserName))
                return "Vui lòng nhập tên đăng nhập!";

            if (user.UserName.Length < 3)
                return "Tên đăng nhập phải có ít nhất 3 ký tự!";

            if (string.IsNullOrWhiteSpace(user.Password))
                return "Vui lòng nhập mật khẩu!";

            if (user.Password.Length < 3)
                return "Mật khẩu phải có ít nhất 3 ký tự!";

            if (string.IsNullOrWhiteSpace(user.RoleID))
                return "Vui lòng chọn vai trò!";

            // Check if role exists
            var role = roleDAL.GetById(user.RoleID);
            if (role == null)
                return "Vai trò không tồn tại!";

            // Check if position exists (if provided)
            if (!string.IsNullOrWhiteSpace(user.PositionID))
            {
                var position = positionDAL.GetById(user.PositionID);
                if (position == null)
                    return "Vị trí không tồn tại!";
            }

            return null; // Valid
        }

        /// <summary>
        /// Tạo ID nhân viên tự động
        /// </summary>
        /// <returns>ID nhân viên</returns>
        private string GenerateUserId()
        {
            return "USER" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        #endregion
    }
}


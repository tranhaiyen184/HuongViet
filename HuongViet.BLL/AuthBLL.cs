using HuongViet.DAL;
using HuongViet.Models;
using System;

namespace HuongViet.BLL
{
    public class AuthBLL
    {
        private readonly UserDAL userDAL;

        public AuthBLL()
        {
            userDAL = new UserDAL();
        }

        /// <summary>
        /// Đăng nhập người dùng
        /// </summary>
        /// <param name="userName">Tên đăng nhập</param>
        /// <param name="password">Mật khẩu (không mã hóa)</param>
        /// <returns>User nếu đăng nhập thành công, null nếu thất bại</returns>
        public User Login(string userName, string password)
        {
            try
            {
                // Kiểm tra thông tin đầu vào
                if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
                {
                    throw new ArgumentException("Tên đăng nhập và mật khẩu không được để trống");
                }

                // Tìm user theo username
                User user = userDAL.GetByUserName(userName.Trim());
                
                if (user == null)
                {
                    return null; // Không tìm thấy user
                }

                // Kiểm tra trạng thái user
                if (user.Status != UserStatus.active)
                {
                    throw new InvalidOperationException("Tài khoản đã bị khóa hoặc không hoạt động");
                }

                // So sánh mật khẩu (không mã hóa theo yêu cầu)
                if (user.Password == password.Trim())
                {
                    return user; // Đăng nhập thành công
                }

                return null; // Mật khẩu không đúng
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi đăng nhập: {ex.Message}");
            }
        }

        /// <summary>
        /// Kiểm tra tên đăng nhập có tồn tại không
        /// </summary>
        /// <param name="userName">Tên đăng nhập</param>
        /// <returns>True nếu tồn tại, False nếu không</returns>
        public bool IsUserNameExists(string userName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userName))
                    return false;

                return userDAL.IsUserNameExists(userName.Trim());
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi kiểm tra tên đăng nhập: {ex.Message}");
            }
        }

        /// <summary>
        /// Đổi mật khẩu người dùng
        /// </summary>
        /// <param name="userId">ID người dùng</param>
        /// <param name="oldPassword">Mật khẩu cũ</param>
        /// <param name="newPassword">Mật khẩu mới</param>
        /// <returns>True nếu thành công, False nếu thất bại</returns>
        public bool ChangePassword(string userId, string oldPassword, string newPassword)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userId) || 
                    string.IsNullOrWhiteSpace(oldPassword) || 
                    string.IsNullOrWhiteSpace(newPassword))
                {
                    throw new ArgumentException("Thông tin không được để trống");
                }

                // Lấy thông tin user hiện tại
                User user = userDAL.GetById(userId);
                if (user == null)
                {
                    throw new InvalidOperationException("Không tìm thấy người dùng");
                }

                // Kiểm tra mật khẩu cũ
                if (user.Password != oldPassword.Trim())
                {
                    throw new InvalidOperationException("Mật khẩu cũ không đúng");
                }

                // Cập nhật mật khẩu mới
                return userDAL.ChangePassword(userId, newPassword.Trim());
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi đổi mật khẩu: {ex.Message}");
            }
        }

        /// <summary>
        /// Lấy thông tin user theo ID
        /// </summary>
        /// <param name="userId">ID người dùng</param>
        /// <returns>User object</returns>
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
                throw new Exception($"Lỗi khi lấy thông tin người dùng: {ex.Message}");
            }
        }

        /// <summary>
        /// Validate thông tin đăng nhập
        /// </summary>
        /// <param name="userName">Tên đăng nhập</param>
        /// <param name="password">Mật khẩu</param>
        /// <returns>Thông báo lỗi nếu có, null nếu hợp lệ</returns>
        public string ValidateLoginInfo(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName))
                return "Tên đăng nhập không được để trống";

            if (string.IsNullOrWhiteSpace(password))
                return "Mật khẩu không được để trống";

            if (userName.Trim().Length < 3)
                return "Tên đăng nhập phải có ít nhất 3 ký tự";

            if (password.Trim().Length < 1)
                return "Mật khẩu không được để trống";

            return null; // Hợp lệ
        }
    }
}

using HuongViet.DAL;
using HuongViet.Models;
using System;
using BCryptNet = BCrypt.Net.BCrypt;

namespace HuongViet.BLL
{
    public class AuthBLL
    {
        private readonly UserDAL userDAL;
        private readonly RoleBLL roleBLL;

        public AuthBLL()
        {
            userDAL = new UserDAL();
            roleBLL = new RoleBLL();
        }

        /// <summary>
        /// Đăng nhập người dùng
        /// </summary>
        /// <param name="userName">Tên đăng nhập</param>
        /// <param name="password">Mật khẩu (plain text nhập từ người dùng)</param>
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

                var inputPassword = password.Trim();

                bool passwordMatches = VerifyPassword(inputPassword, user.Password);
                bool storedIsPlainMatch = string.Equals(user.Password?.Trim(), inputPassword, StringComparison.Ordinal);

                // Nâng cấp hash nếu đang lưu plain-text nhưng khớp
                if (passwordMatches && storedIsPlainMatch)
                {
                    var upgradedHash = BCryptNet.HashPassword(inputPassword);
                    userDAL.ChangePassword(user.UserID, upgradedHash);
                    user.Password = upgradedHash;
                }

                if (passwordMatches)
                {
                    AttachRolePermissions(user);
                    return user; // Đăng nhập thành công
                }

                return null; // Mật khẩu không đúng
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi đăng nhập: {ex.Message}");
            }
        }

        private void AttachRolePermissions(User user)
        {
            if (user == null || string.IsNullOrWhiteSpace(user.RoleID))
            {
                return;
            }

            var role = roleBLL.GetRoleById(user.RoleID);
            user.Role = role;
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

                string oldPlain = oldPassword.Trim();
                string newPlain = newPassword.Trim();

                bool oldMatches = VerifyPassword(oldPlain, user.Password);
                if (!oldMatches)
                {
                    throw new InvalidOperationException("Mật khẩu cũ không đúng");
                }

                // Cập nhật mật khẩu mới (hash)
                string hashedNew = BCryptNet.HashPassword(newPlain);
                return userDAL.ChangePassword(userId, hashedNew);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi đổi mật khẩu: {ex.Message}");
            }
        }

        private bool VerifyPassword(string input, string stored)
        {
            if (string.IsNullOrWhiteSpace(input) || string.IsNullOrWhiteSpace(stored))
            {
                return false;
            }

            // Nếu stored không phải bcrypt, fallback so sánh plain-text
            if (!stored.StartsWith("$2"))
            {
                return string.Equals(stored.Trim(), input.Trim(), StringComparison.Ordinal);
            }

            try
            {
                return BCryptNet.Verify(input, stored);
            }
            catch
            {
                // Nếu salt/hash hỏng, tránh throw ra và cho phép xử lý tiếp theo (sẽ trả false)
                return false;
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

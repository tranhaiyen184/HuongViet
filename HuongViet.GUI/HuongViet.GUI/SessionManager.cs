using HuongViet.Models;

namespace HuongViet.GUI
{
    /// <summary>
    /// Quản lý phiên đăng nhập của user hiện tại
    /// </summary>
    public static class SessionManager
    {
        private static User _currentUser;

        /// <summary>
        /// User hiện đang đăng nhập
        /// </summary>
        public static User CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; }
        }

        /// <summary>
        /// Kiểm tra xem có user đang đăng nhập không
        /// </summary>
        public static bool IsLoggedIn
        {
            get { return _currentUser != null; }
        }

        /// <summary>
        /// Lấy UserID của user hiện tại
        /// </summary>
        public static string CurrentUserID
        {
            get { return _currentUser?.UserID; }
        }

        /// <summary>
        /// Lấy tên đầy đủ của user hiện tại
        /// </summary>
        public static string CurrentUserFullName
        {
            get 
            { 
                if (_currentUser == null)
                    return string.Empty;
                return $"{_currentUser.FirstName} {_currentUser.LastName}".Trim();
            }
        }

        /// <summary>
        /// Xóa thông tin phiên đăng nhập (logout)
        /// </summary>
        public static void ClearSession()
        {
            _currentUser = null;
        }
    }
}

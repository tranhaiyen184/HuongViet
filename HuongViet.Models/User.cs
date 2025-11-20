using System;

namespace HuongViet.Models
{
    public enum UserStatus
    {
        active,
        inactive
    }

    public class User
    {
        public string UserID { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string PhoneNumber { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string PositionID { get; set; }

        public string RoleID { get; set; }

        public UserStatus Status { get; set; } = UserStatus.active;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public Position Position { get; set; }

        public Role Role { get; set; }
    }
}

using HuongViet.DAL;
using HuongViet.Models;
using System;
using System.Collections.Generic;

namespace HuongViet.BLL
{
    public class RoomBLL
    {
        private readonly RoomDAL roomDAL;
        private readonly AreaDAL areaDAL;

        public RoomBLL()
        {
            roomDAL = new RoomDAL();
            areaDAL = new AreaDAL();
        }

        /// <summary>
        /// Lấy tất cả phòng
        /// </summary>
        /// <returns>Danh sách phòng</returns>
        public List<Room> GetAllRooms()
        {
            try
            {
                return roomDAL.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách phòng: {ex.Message}");
            }
        }

        /// <summary>
        /// Lấy phòng theo ID
        /// </summary>
        /// <param name="roomId">ID phòng</param>
        /// <returns>Thông tin phòng</returns>
        public Room GetRoomById(string roomId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(roomId))
                    return null;

                return roomDAL.GetById(roomId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy thông tin phòng: {ex.Message}");
            }
        }

        /// <summary>
        /// Lấy danh sách phòng theo khu vực
        /// </summary>
        /// <param name="areaId">ID khu vực</param>
        /// <returns>Danh sách phòng</returns>
        public List<Room> GetRoomsByArea(string areaId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(areaId))
                    return new List<Room>();

                return roomDAL.GetByAreaId(areaId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách phòng: {ex.Message}");
            }
        }

        /// <summary>
        /// Thêm phòng mới
        /// </summary>
        /// <param name="room">Thông tin phòng</param>
        /// <returns>True nếu thành công</returns>
        public bool AddRoom(Room room)
        {
            try
            {
                // Validate input
                string validationError = ValidateRoom(room);
                if (!string.IsNullOrEmpty(validationError))
                {
                    throw new Exception(validationError);
                }

                // Check if room name already exists in the same area
                if (roomDAL.IsRoomNameExists(room.RoomName, room.AreaID))
                {
                    throw new Exception("Tên phòng đã tồn tại trong khu vực này!");
                }

                // Generate ID if not provided
                if (string.IsNullOrWhiteSpace(room.RoomID))
                {
                    room.RoomID = GenerateRoomId();
                }

                room.CreatedAt = DateTime.Now;
                room.UpdatedAt = DateTime.Now;

                return roomDAL.Insert(room);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm phòng: {ex.Message}");
            }
        }

        /// <summary>
        /// Cập nhật phòng
        /// </summary>
        /// <param name="room">Thông tin phòng</param>
        /// <returns>True nếu thành công</returns>
        public bool UpdateRoom(Room room)
        {
            try
            {
                // Validate input
                string validationError = ValidateRoom(room);
                if (!string.IsNullOrEmpty(validationError))
                {
                    throw new Exception(validationError);
                }

                // Check if room exists
                if (!roomDAL.Exists(room.RoomID))
                {
                    throw new Exception("Phòng không tồn tại!");
                }

                // Check if room name already exists in the same area (excluding current room)
                if (roomDAL.IsRoomNameExists(room.RoomName, room.AreaID, room.RoomID))
                {
                    throw new Exception("Tên phòng đã tồn tại trong khu vực này!");
                }

                room.UpdatedAt = DateTime.Now;

                return roomDAL.Update(room);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật phòng: {ex.Message}");
            }
        }

        /// <summary>
        /// Xóa phòng
        /// </summary>
        /// <param name="roomId">ID phòng</param>
        /// <returns>True nếu thành công</returns>
        public bool DeleteRoom(string roomId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(roomId))
                {
                    throw new Exception("ID phòng không hợp lệ!");
                }

                // Check if room exists
                if (!roomDAL.Exists(roomId))
                {
                    throw new Exception("Phòng không tồn tại!");
                }

                return roomDAL.Delete(roomId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa phòng: {ex.Message}");
            }
        }

        /// <summary>
        /// Lấy danh sách khu vực (để hiển thị trong ComboBox)
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

        #region Private Methods

        /// <summary>
        /// Validate thông tin phòng
        /// </summary>
        /// <param name="room">Thông tin phòng</param>
        /// <returns>Thông báo lỗi hoặc null nếu hợp lệ</returns>
        private string ValidateRoom(Room room)
        {
            if (room == null)
                return "Thông tin phòng không hợp lệ!";

            if (string.IsNullOrWhiteSpace(room.RoomName))
                return "Vui lòng nhập tên phòng!";

            if (room.RoomName.Length > 30)
                return "Tên phòng không được vượt quá 30 ký tự!";

            if (string.IsNullOrWhiteSpace(room.AreaID))
                return "Vui lòng chọn khu vực!";

            // Check if area exists
            var area = areaDAL.GetById(room.AreaID);
            if (area == null)
                return "Khu vực không tồn tại!";

            if (room.PricePerHour < 0)
                return "Giá mỗi giờ phải lớn hơn hoặc bằng 0!";

            if (room.Capacity <= 0)
                return "Sức chứa phải lớn hơn 0!";

            return null; // Valid
        }

        /// <summary>
        /// Tạo ID phòng tự động
        /// </summary>
        /// <returns>ID phòng</returns>
        private string GenerateRoomId()
        {
            return "ROOM" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        #endregion
    }
}


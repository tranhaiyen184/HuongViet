using HuongViet.DAL;
using HuongViet.Models;
using System;
using System.Collections.Generic;

namespace HuongViet.BLL
{
    public class RoomBLL
    {
        private readonly RoomDAL roomDAL;
        private readonly FloorDAL floorDAL;

        public RoomBLL()
        {
            roomDAL = new RoomDAL();
            floorDAL = new FloorDAL();
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
        /// Lấy danh sách phòng theo tầng
        /// </summary>
        /// <param name="floorId">ID tầng</param>
        /// <returns>Danh sách phòng</returns>
        public List<Room> GetRoomsByFloor(string floorId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(floorId))
                    return new List<Room>();

                return roomDAL.GetByFloorId(floorId);
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

                // Check if room name already exists on the same floor
                if (roomDAL.IsRoomNameExists(room.RoomName, room.FloorID))
                {
                    throw new Exception("Tên phòng đã tồn tại trên tầng này!");
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

                // Check if room name already exists on the same floor (excluding current room)
                if (roomDAL.IsRoomNameExists(room.RoomName, room.FloorID, room.RoomID))
                {
                    throw new Exception("Tên phòng đã tồn tại trên tầng này!");
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
        /// Lấy danh sách tầng (để hiển thị trong ComboBox)
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

            if (string.IsNullOrWhiteSpace(room.FloorID))
                return "Vui lòng chọn tầng!";

            // Check if floor exists
            var floor = floorDAL.GetById(room.FloorID);
            if (floor == null)
                return "Tầng không tồn tại!";

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


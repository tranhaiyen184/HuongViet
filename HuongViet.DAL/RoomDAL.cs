using HuongViet.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace HuongViet.DAL
{
    public class RoomDAL
    {
        private readonly DatabaseHelper dbHelper;

        public RoomDAL()
        {
            this.dbHelper = new DatabaseHelper();
        }

        private Room MapDataRowToEntity(DataRow row)
        {
            return new Room
            {
                RoomID = row["RoomID"].ToString(),
                RoomName = row["RoomName"].ToString(),
                RoomStatus = (RoomStatus)Enum.Parse(typeof(RoomStatus), row["RoomStatus"].ToString()),
                RoomType = (RoomType)Enum.Parse(typeof(RoomType), row["RoomType"].ToString()),
                PricePerHour = Convert.ToDecimal(row["PricePerHour"]),
                Capacity = Convert.ToInt32(row["Capacity"]),
                FloorID = row["FloorID"].ToString(),
                CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                UpdatedAt = Convert.ToDateTime(row["UpdatedAt"])
            };
        }

        public List<Room> GetAll()
        {
            string query = @"SELECT r.*, f.FloorNumber 
                           FROM rooms r 
                           LEFT JOIN floors f ON r.FloorID = f.FloorID 
                           ORDER BY f.FloorNumber, r.RoomName";
            DataTable dt = dbHelper.ExecuteQuery(query);
            return ConvertDataTableToList(dt);
        }

        public Room GetById(string id)
        {
            string query = @"SELECT r.*, f.FloorNumber 
                           FROM rooms r 
                           LEFT JOIN floors f ON r.FloorID = f.FloorID 
                           WHERE r.RoomID = @id";
            MySqlParameter[] parameters = { new MySqlParameter("@id", id) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            
            if (dt.Rows.Count > 0)
            {
                var room = MapDataRowToEntity(dt.Rows[0]);
                if (!dt.Rows[0].IsNull("FloorNumber"))
                {
                    room.Floor = new Floor
                    {
                        FloorID = room.FloorID,
                        FloorNumber = Convert.ToInt32(dt.Rows[0]["FloorNumber"])
                    };
                }
                return room;
            }
            return null;
        }

        public List<Room> GetByFloorId(string floorId)
        {
            string query = "SELECT * FROM rooms WHERE FloorID = @floorId ORDER BY RoomName";
            MySqlParameter[] parameters = { new MySqlParameter("@floorId", floorId) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            return ConvertDataTableToList(dt);
        }

        public bool Insert(Room room)
        {
            try
            {
                string query = @"INSERT INTO rooms (RoomID, RoomName, RoomStatus, RoomType, PricePerHour, 
                               Capacity, FloorID, CreatedAt, UpdatedAt) 
                               VALUES (@RoomID, @RoomName, @RoomStatus, @RoomType, @PricePerHour, 
                               @Capacity, @FloorID, @CreatedAt, @UpdatedAt)";
                
                MySqlParameter[] parameters = 
                {
                    new MySqlParameter("@RoomID", room.RoomID),
                    new MySqlParameter("@RoomName", room.RoomName),
                    new MySqlParameter("@RoomStatus", room.RoomStatus.ToString()),
                    new MySqlParameter("@RoomType", room.RoomType.ToString()),
                    new MySqlParameter("@PricePerHour", room.PricePerHour),
                    new MySqlParameter("@Capacity", room.Capacity),
                    new MySqlParameter("@FloorID", room.FloorID),
                    new MySqlParameter("@CreatedAt", room.CreatedAt),
                    new MySqlParameter("@UpdatedAt", room.UpdatedAt)
                };
                
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm phòng: {ex.Message}");
            }
        }

        public bool Update(Room room)
        {
            try
            {
                string query = @"UPDATE rooms SET RoomName = @RoomName, RoomStatus = @RoomStatus, 
                               RoomType = @RoomType, PricePerHour = @PricePerHour, Capacity = @Capacity,
                               FloorID = @FloorID, UpdatedAt = @UpdatedAt WHERE RoomID = @RoomID";
                
                MySqlParameter[] parameters = 
                {
                    new MySqlParameter("@RoomID", room.RoomID),
                    new MySqlParameter("@RoomName", room.RoomName),
                    new MySqlParameter("@RoomStatus", room.RoomStatus.ToString()),
                    new MySqlParameter("@RoomType", room.RoomType.ToString()),
                    new MySqlParameter("@PricePerHour", room.PricePerHour),
                    new MySqlParameter("@Capacity", room.Capacity),
                    new MySqlParameter("@FloorID", room.FloorID),
                    new MySqlParameter("@UpdatedAt", DateTime.Now)
                };
                
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật phòng: {ex.Message}");
            }
        }

        public bool Delete(string id)
        {
            try
            {
                string query = "DELETE FROM rooms WHERE RoomID = @id";
                MySqlParameter[] parameters = { new MySqlParameter("@id", id) };
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa phòng: {ex.Message}");
            }
        }

        public bool Exists(string id)
        {
            string query = "SELECT COUNT(*) FROM rooms WHERE RoomID = @id";
            MySqlParameter[] parameters = { new MySqlParameter("@id", id) };
            int count = Convert.ToInt32(dbHelper.ExecuteScalar(query, parameters));
            return count > 0;
        }

        public bool IsRoomNameExists(string roomName, string floorId, string excludeRoomId = null)
        {
            string query = "SELECT COUNT(*) FROM rooms WHERE RoomName = @roomName AND FloorID = @floorId";
            List<MySqlParameter> parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@roomName", roomName),
                new MySqlParameter("@floorId", floorId)
            };

            if (!string.IsNullOrEmpty(excludeRoomId))
            {
                query += " AND RoomID != @excludeRoomId";
                parameters.Add(new MySqlParameter("@excludeRoomId", excludeRoomId));
            }

            int count = Convert.ToInt32(dbHelper.ExecuteScalar(query, parameters.ToArray()));
            return count > 0;
        }

        private List<Room> ConvertDataTableToList(DataTable dt)
        {
            List<Room> list = new List<Room>();
            foreach (DataRow row in dt.Rows)
            {
                var room = MapDataRowToEntity(row);
                if (!row.IsNull("FloorNumber"))
                {
                    room.Floor = new Floor
                    {
                        FloorID = room.FloorID,
                        FloorNumber = Convert.ToInt32(row["FloorNumber"])
                    };
                }
                list.Add(room);
            }
            return list;
        }
    }
}


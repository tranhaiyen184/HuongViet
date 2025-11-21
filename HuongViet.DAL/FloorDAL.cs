using HuongViet.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace HuongViet.DAL
{
    public class FloorDAL
    {
        private readonly DatabaseHelper dbHelper;

        public FloorDAL()
        {
            this.dbHelper = new DatabaseHelper();
        }

        private Floor MapDataRowToEntity(DataRow row)
        {
            return new Floor
            {
                FloorID = row["FloorID"].ToString(),
                FloorNumber = Convert.ToInt32(row["FloorNumber"]),
                CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                UpdatedAt = Convert.ToDateTime(row["UpdatedAt"])
            };
        }

        public List<Floor> GetAll()
        {
            string query = "SELECT * FROM floors ORDER BY FloorNumber";
            DataTable dt = dbHelper.ExecuteQuery(query);
            return ConvertDataTableToList(dt);
        }

        public Floor GetById(string id)
        {
            string query = "SELECT * FROM floors WHERE FloorID = @id";
            MySqlParameter[] parameters = { new MySqlParameter("@id", id) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            
            if (dt.Rows.Count > 0)
                return MapDataRowToEntity(dt.Rows[0]);
            return null;
        }

        public bool Insert(Floor floor)
        {
            try
            {
                string query = @"INSERT INTO floors (FloorID, FloorNumber, CreatedAt, UpdatedAt) 
                               VALUES (@FloorID, @FloorNumber, @CreatedAt, @UpdatedAt)";
                
                MySqlParameter[] parameters = 
                {
                    new MySqlParameter("@FloorID", floor.FloorID),
                    new MySqlParameter("@FloorNumber", floor.FloorNumber),
                    new MySqlParameter("@CreatedAt", floor.CreatedAt),
                    new MySqlParameter("@UpdatedAt", floor.UpdatedAt)
                };
                
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm tầng: {ex.Message}");
            }
        }

        public bool Update(Floor floor)
        {
            try
            {
                string query = @"UPDATE floors SET FloorNumber = @FloorNumber, 
                               UpdatedAt = @UpdatedAt WHERE FloorID = @FloorID";
                
                MySqlParameter[] parameters = 
                {
                    new MySqlParameter("@FloorID", floor.FloorID),
                    new MySqlParameter("@FloorNumber", floor.FloorNumber),
                    new MySqlParameter("@UpdatedAt", DateTime.Now)
                };
                
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật tầng: {ex.Message}");
            }
        }

        public bool Delete(string id)
        {
            try
            {
                // Check if floor has rooms or tables
                string checkRoomsQuery = "SELECT COUNT(*) FROM rooms WHERE FloorID = @id";
                string checkTablesQuery = "SELECT COUNT(*) FROM tables WHERE FloorID = @id";
                
                int roomCount = Convert.ToInt32(dbHelper.ExecuteScalar(checkRoomsQuery, new MySqlParameter("@id", id)));
                int tableCount = Convert.ToInt32(dbHelper.ExecuteScalar(checkTablesQuery, new MySqlParameter("@id", id)));
                
                if (roomCount > 0 || tableCount > 0)
                {
                    throw new Exception("Không thể xóa tầng vì còn phòng hoặc bàn đang sử dụng!");
                }

                string query = "DELETE FROM floors WHERE FloorID = @id";
                MySqlParameter[] parameters = { new MySqlParameter("@id", id) };
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa tầng: {ex.Message}");
            }
        }

        public bool Exists(string id)
        {
            string query = "SELECT COUNT(*) FROM floors WHERE FloorID = @id";
            MySqlParameter[] parameters = { new MySqlParameter("@id", id) };
            int count = Convert.ToInt32(dbHelper.ExecuteScalar(query, parameters));
            return count > 0;
        }

        public bool IsFloorNumberExists(int floorNumber, string excludeFloorId = null)
        {
            string query = "SELECT COUNT(*) FROM floors WHERE FloorNumber = @floorNumber";
            List<MySqlParameter> parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@floorNumber", floorNumber)
            };

            if (!string.IsNullOrEmpty(excludeFloorId))
            {
                query += " AND FloorID != @excludeFloorId";
                parameters.Add(new MySqlParameter("@excludeFloorId", excludeFloorId));
            }

            int count = Convert.ToInt32(dbHelper.ExecuteScalar(query, parameters.ToArray()));
            return count > 0;
        }

        private List<Floor> ConvertDataTableToList(DataTable dt)
        {
            List<Floor> list = new List<Floor>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapDataRowToEntity(row));
            }
            return list;
        }
    }
}


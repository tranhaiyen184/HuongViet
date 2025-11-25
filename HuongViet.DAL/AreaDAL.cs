using HuongViet.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace HuongViet.DAL
{
    public class AreaDAL
    {
        private readonly DatabaseHelper dbHelper;

        public AreaDAL()
        {
            this.dbHelper = new DatabaseHelper();
        }

        private Area MapDataRowToEntity(DataRow row)
        {
            return new Area
            {
                AreaID = row["AreaID"].ToString(),
                AreaName = row["AreaName"].ToString(),
                DeletedAt = row.IsNull("DeletedAt") ? (DateTime?)null : Convert.ToDateTime(row["DeletedAt"]),
                CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                UpdatedAt = Convert.ToDateTime(row["UpdatedAt"])
            };
        }

        public List<Area> GetAll()
        {
            string query = "SELECT * FROM areas WHERE DeletedAt IS NULL ORDER BY AreaName";
            DataTable dt = dbHelper.ExecuteQuery(query);
            return ConvertDataTableToList(dt);
        }

        public Area GetById(string id)
        {
            string query = "SELECT * FROM areas WHERE AreaID = @id AND DeletedAt IS NULL";
            MySqlParameter[] parameters = { new MySqlParameter("@id", id) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            
            if (dt.Rows.Count > 0)
                return MapDataRowToEntity(dt.Rows[0]);
            return null;
        }

        public bool Insert(Area area)
        {
            try
            {
                string query = @"INSERT INTO areas (AreaID, AreaName, CreatedAt, UpdatedAt) 
                               VALUES (@AreaID, @AreaName, @CreatedAt, @UpdatedAt)";
                
                MySqlParameter[] parameters = 
                {
                    new MySqlParameter("@AreaID", area.AreaID),
                    new MySqlParameter("@AreaName", area.AreaName),
                    new MySqlParameter("@CreatedAt", area.CreatedAt),
                    new MySqlParameter("@UpdatedAt", area.UpdatedAt)
                };
                
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm khu vực: {ex.Message}");
            }
        }

        public bool Update(Area area)
        {
            try
            {
                string query = @"UPDATE areas SET AreaName = @AreaName, 
                               UpdatedAt = @UpdatedAt WHERE AreaID = @AreaID AND DeletedAt IS NULL";
                
                MySqlParameter[] parameters = 
                {
                    new MySqlParameter("@AreaID", area.AreaID),
                    new MySqlParameter("@AreaName", area.AreaName),
                    new MySqlParameter("@UpdatedAt", DateTime.Now)
                };
                
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật khu vực: {ex.Message}");
            }
        }

        public bool Delete(string id)
        {
            try
            {
                // Check if area has rooms or tables
                string checkRoomsQuery = "SELECT COUNT(*) FROM rooms WHERE AreaID = @id";
                string checkTablesQuery = "SELECT COUNT(*) FROM tables WHERE AreaID = @id";
                
                int roomCount = Convert.ToInt32(dbHelper.ExecuteScalar(checkRoomsQuery, new MySqlParameter("@id", id)));
                int tableCount = Convert.ToInt32(dbHelper.ExecuteScalar(checkTablesQuery, new MySqlParameter("@id", id)));
                
                if (roomCount > 0 || tableCount > 0)
                {
                    throw new Exception("Không thể xóa khu vực vì còn phòng hoặc bàn đang sử dụng!");
                }

                // Soft delete
                string query = "UPDATE areas SET DeletedAt = @DeletedAt WHERE AreaID = @id";
                MySqlParameter[] parameters = 
                {
                    new MySqlParameter("@id", id),
                    new MySqlParameter("@DeletedAt", DateTime.Now)
                };
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa khu vực: {ex.Message}");
            }
        }

        public bool Exists(string id)
        {
            string query = "SELECT COUNT(*) FROM areas WHERE AreaID = @id AND DeletedAt IS NULL";
            MySqlParameter[] parameters = { new MySqlParameter("@id", id) };
            int count = Convert.ToInt32(dbHelper.ExecuteScalar(query, parameters));
            return count > 0;
        }

        public bool IsAreaNameExists(string areaName, string excludeAreaId = null)
        {
            string query = "SELECT COUNT(*) FROM areas WHERE AreaName = @areaName AND DeletedAt IS NULL";
            List<MySqlParameter> parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@areaName", areaName)
            };

            if (!string.IsNullOrEmpty(excludeAreaId))
            {
                query += " AND AreaID != @excludeAreaId";
                parameters.Add(new MySqlParameter("@excludeAreaId", excludeAreaId));
            }

            int count = Convert.ToInt32(dbHelper.ExecuteScalar(query, parameters.ToArray()));
            return count > 0;
        }

        private List<Area> ConvertDataTableToList(DataTable dt)
        {
            List<Area> list = new List<Area>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapDataRowToEntity(row));
            }
            return list;
        }
    }
}


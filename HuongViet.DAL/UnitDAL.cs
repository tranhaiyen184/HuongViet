using HuongViet.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace HuongViet.DAL
{
    public class UnitDAL
    {
        private readonly DatabaseHelper dbHelper;

        public UnitDAL()
        {
            this.dbHelper = new DatabaseHelper();
        }

        private Unit MapDataRowToEntity(DataRow row)
        {
            return new Unit
            {
                UnitID = row["UnitID"].ToString(),
                UnitName = row["UnitName"].ToString(),
                DeletedAt = row.IsNull("DeletedAt") ? (DateTime?)null : Convert.ToDateTime(row["DeletedAt"]),
                CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                UpdatedAt = Convert.ToDateTime(row["UpdatedAt"])
            };
        }

        public List<Unit> GetAll()
        {
            string query = "SELECT * FROM units WHERE DeletedAt IS NULL ORDER BY UnitName";
            DataTable dt = dbHelper.ExecuteQuery(query);
            return ConvertDataTableToList(dt);
        }

        public Unit GetById(string id)
        {
            string query = "SELECT * FROM units WHERE UnitID = @id AND DeletedAt IS NULL";
            MySqlParameter[] parameters = { new MySqlParameter("@id", id) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            
            if (dt.Rows.Count > 0)
                return MapDataRowToEntity(dt.Rows[0]);
            return null;
        }

        public bool Insert(Unit unit)
        {
            try
            {
                string query = @"INSERT INTO units (UnitID, UnitName, CreatedAt, UpdatedAt) 
                               VALUES (@UnitID, @UnitName, @CreatedAt, @UpdatedAt)";
                
                MySqlParameter[] parameters = 
                {
                    new MySqlParameter("@UnitID", unit.UnitID),
                    new MySqlParameter("@UnitName", unit.UnitName),
                    new MySqlParameter("@CreatedAt", unit.CreatedAt),
                    new MySqlParameter("@UpdatedAt", unit.UpdatedAt)
                };
                
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm đơn vị: {ex.Message}");
            }
        }

        public bool Update(Unit unit)
        {
            try
            {
                string query = @"UPDATE units SET UnitName = @UnitName, 
                               UpdatedAt = @UpdatedAt WHERE UnitID = @UnitID AND DeletedAt IS NULL";
                
                MySqlParameter[] parameters = 
                {
                    new MySqlParameter("@UnitID", unit.UnitID),
                    new MySqlParameter("@UnitName", unit.UnitName),
                    new MySqlParameter("@UpdatedAt", DateTime.Now)
                };
                
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật đơn vị: {ex.Message}");
            }
        }

        public bool Delete(string id)
        {
            try
            {
                // Check if unit is being used by any items
                string checkItemsQuery = "SELECT COUNT(*) FROM items WHERE UnitID = @id AND DeletedAt IS NULL";
                int itemCount = Convert.ToInt32(dbHelper.ExecuteScalar(checkItemsQuery, new MySqlParameter("@id", id)));
                
                if (itemCount > 0)
                {
                    throw new Exception("Không thể xóa đơn vị vì còn món ăn đang sử dụng!");
                }

                // Soft delete
                string query = "UPDATE units SET DeletedAt = @DeletedAt WHERE UnitID = @id";
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
                throw new Exception($"Lỗi khi xóa đơn vị: {ex.Message}");
            }
        }

        public bool Exists(string id)
        {
            string query = "SELECT COUNT(*) FROM units WHERE UnitID = @id AND DeletedAt IS NULL";
            MySqlParameter[] parameters = { new MySqlParameter("@id", id) };
            int count = Convert.ToInt32(dbHelper.ExecuteScalar(query, parameters));
            return count > 0;
        }

        public bool IsUnitNameExists(string unitName, string excludeUnitId = null)
        {
            string query = "SELECT COUNT(*) FROM units WHERE UnitName = @unitName AND DeletedAt IS NULL";
            List<MySqlParameter> parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@unitName", unitName)
            };

            if (!string.IsNullOrEmpty(excludeUnitId))
            {
                query += " AND UnitID != @excludeUnitId";
                parameters.Add(new MySqlParameter("@excludeUnitId", excludeUnitId));
            }

            int count = Convert.ToInt32(dbHelper.ExecuteScalar(query, parameters.ToArray()));
            return count > 0;
        }

        private List<Unit> ConvertDataTableToList(DataTable dt)
        {
            List<Unit> list = new List<Unit>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapDataRowToEntity(row));
            }
            return list;
        }
    }
}


using HuongViet.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace HuongViet.DAL
{
    public class CategoryDAL
    {
        private readonly DatabaseHelper dbHelper;

        public CategoryDAL()
        {
            this.dbHelper = new DatabaseHelper();
        }

        private Category MapDataRowToEntity(DataRow row)
        {
            return new Category
            {
                CateID = row["CateID"].ToString(),
                CateName = row["CateName"].ToString(),
                CateDescription = row.IsNull("CateDescription") ? null : row["CateDescription"].ToString(),
                DeletedAt = row.IsNull("DeletedAt") ? (DateTime?)null : Convert.ToDateTime(row["DeletedAt"]),
                CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                UpdatedAt = Convert.ToDateTime(row["UpdatedAt"])
            };
        }

        public List<Category> GetAll()
        {
            string query = "SELECT * FROM categories WHERE DeletedAt IS NULL ORDER BY CateName";
            DataTable dt = dbHelper.ExecuteQuery(query);
            return ConvertDataTableToList(dt);
        }

        public Category GetById(string id)
        {
            string query = "SELECT * FROM categories WHERE CateID = @id AND DeletedAt IS NULL";
            MySqlParameter[] parameters = { new MySqlParameter("@id", id) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            
            if (dt.Rows.Count > 0)
                return MapDataRowToEntity(dt.Rows[0]);
            return null;
        }

        public bool Insert(Category category)
        {
            try
            {
                string query = @"INSERT INTO categories (CateID, CateName, CateDescription, CreatedAt, UpdatedAt) 
                               VALUES (@CateID, @CateName, @CateDescription, @CreatedAt, @UpdatedAt)";
                
                MySqlParameter[] parameters = 
                {
                    new MySqlParameter("@CateID", category.CateID),
                    new MySqlParameter("@CateName", category.CateName),
                    new MySqlParameter("@CateDescription", (object)category.CateDescription ?? DBNull.Value),
                    new MySqlParameter("@CreatedAt", category.CreatedAt),
                    new MySqlParameter("@UpdatedAt", category.UpdatedAt)
                };
                
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm danh mục: {ex.Message}");
            }
        }

        public bool Update(Category category)
        {
            try
            {
                string query = @"UPDATE categories SET CateName = @CateName, 
                               CateDescription = @CateDescription,
                               UpdatedAt = @UpdatedAt WHERE CateID = @CateID AND DeletedAt IS NULL";
                
                MySqlParameter[] parameters = 
                {
                    new MySqlParameter("@CateID", category.CateID),
                    new MySqlParameter("@CateName", category.CateName),
                    new MySqlParameter("@CateDescription", (object)category.CateDescription ?? DBNull.Value),
                    new MySqlParameter("@UpdatedAt", DateTime.Now)
                };
                
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật danh mục: {ex.Message}");
            }
        }

        public bool Delete(string id)
        {
            try
            {
                // Check if category is being used by any items
                string checkItemsQuery = "SELECT COUNT(*) FROM items WHERE CateID = @id AND DeletedAt IS NULL";
                int itemCount = Convert.ToInt32(dbHelper.ExecuteScalar(checkItemsQuery, new MySqlParameter("@id", id)));
                
                if (itemCount > 0)
                {
                    throw new Exception("Không thể xóa danh mục vì còn món ăn đang sử dụng!");
                }

                // Soft delete
                string query = "UPDATE categories SET DeletedAt = @DeletedAt WHERE CateID = @id";
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
                throw new Exception($"Lỗi khi xóa danh mục: {ex.Message}");
            }
        }

        public bool Exists(string id)
        {
            string query = "SELECT COUNT(*) FROM categories WHERE CateID = @id AND DeletedAt IS NULL";
            MySqlParameter[] parameters = { new MySqlParameter("@id", id) };
            int count = Convert.ToInt32(dbHelper.ExecuteScalar(query, parameters));
            return count > 0;
        }

        public bool IsCategoryNameExists(string cateName, string excludeCateId = null)
        {
            string query = "SELECT COUNT(*) FROM categories WHERE CateName = @cateName AND DeletedAt IS NULL";
            List<MySqlParameter> parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@cateName", cateName)
            };

            if (!string.IsNullOrEmpty(excludeCateId))
            {
                query += " AND CateID != @excludeCateId";
                parameters.Add(new MySqlParameter("@excludeCateId", excludeCateId));
            }

            int count = Convert.ToInt32(dbHelper.ExecuteScalar(query, parameters.ToArray()));
            return count > 0;
        }

        private List<Category> ConvertDataTableToList(DataTable dt)
        {
            List<Category> list = new List<Category>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapDataRowToEntity(row));
            }
            return list;
        }
    }
}


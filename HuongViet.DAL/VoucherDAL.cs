using HuongViet.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace HuongViet.DAL
{
    public class VoucherDAL
    {
        private readonly DatabaseHelper dbHelper;

        public VoucherDAL()
        {
            this.dbHelper = new DatabaseHelper();
        }

        private Voucher MapDataRowToEntity(DataRow row)
        {
            return new Voucher
            {
                Id = row["id"].ToString(),
                Code = row["code"].ToString(),
                Percentage = Convert.ToDecimal(row["percentage"]),
                Description = row.IsNull("description") ? null : row["description"].ToString(),
                StartAt = row.IsNull("start_at") ? (DateTime?)null : Convert.ToDateTime(row["start_at"]),
                EndAt = row.IsNull("end_at") ? (DateTime?)null : Convert.ToDateTime(row["end_at"]),
                UsageLimit = row.IsNull("usage_limit") ? (int?)null : Convert.ToInt32(row["usage_limit"]),
                UsageCount = Convert.ToInt32(row["usage_count"]),
                Active = Convert.ToBoolean(row["active"]),
                CreatedAt = Convert.ToDateTime(row["created_at"]),
                UpdatedAt = Convert.ToDateTime(row["updated_at"])
            };
        }

        public List<Voucher> GetAll()
        {
            string query = @"SELECT * FROM vouchers 
                           ORDER BY created_at DESC";
            DataTable dt = dbHelper.ExecuteQuery(query);
            return ConvertDataTableToList(dt);
        }

        public List<Voucher> GetActiveVouchers()
        {
            string query = @"SELECT * FROM vouchers 
                           WHERE active = 1 
                           AND (start_at IS NULL OR start_at <= NOW())
                           AND (end_at IS NULL OR end_at >= NOW())
                           ORDER BY created_at DESC";
            DataTable dt = dbHelper.ExecuteQuery(query);
            return ConvertDataTableToList(dt);
        }

        public Voucher GetById(string id)
        {
            string query = @"SELECT * FROM vouchers 
                           WHERE id = @id";
            MySqlParameter[] parameters = { new MySqlParameter("@id", id) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            
            if (dt.Rows.Count > 0)
            {
                return MapDataRowToEntity(dt.Rows[0]);
            }
            return null;
        }

        public Voucher GetByCode(string code)
        {
            string query = @"SELECT * FROM vouchers 
                           WHERE code = @code";
            MySqlParameter[] parameters = { new MySqlParameter("@code", code) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            
            if (dt.Rows.Count > 0)
            {
                return MapDataRowToEntity(dt.Rows[0]);
            }
            return null;
        }

        public bool Insert(Voucher voucher)
        {
            try
            {
                string query = @"INSERT INTO vouchers (id, code, percentage, description, 
                               start_at, end_at, usage_limit, usage_count, active, 
                               created_at, updated_at) 
                               VALUES (@id, @code, @percentage, @description, 
                               @start_at, @end_at, @usage_limit, @usage_count, @active, 
                               @created_at, @updated_at)";
                
                MySqlParameter[] parameters = 
                {
                    new MySqlParameter("@id", voucher.Id),
                    new MySqlParameter("@code", voucher.Code),
                    new MySqlParameter("@percentage", voucher.Percentage),
                    new MySqlParameter("@description", (object)voucher.Description ?? DBNull.Value),
                    new MySqlParameter("@start_at", (object)voucher.StartAt ?? DBNull.Value),
                    new MySqlParameter("@end_at", (object)voucher.EndAt ?? DBNull.Value),
                    new MySqlParameter("@usage_limit", (object)voucher.UsageLimit ?? DBNull.Value),
                    new MySqlParameter("@usage_count", voucher.UsageCount),
                    new MySqlParameter("@active", voucher.Active),
                    new MySqlParameter("@created_at", voucher.CreatedAt),
                    new MySqlParameter("@updated_at", voucher.UpdatedAt)
                };
                
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm voucher: {ex.Message}");
            }
        }

        public bool Update(Voucher voucher)
        {
            try
            {
                string query = @"UPDATE vouchers SET code = @code, percentage = @percentage, 
                               description = @description, start_at = @start_at, 
                               end_at = @end_at, usage_limit = @usage_limit, 
                               usage_count = @usage_count, active = @active, 
                               updated_at = @updated_at 
                               WHERE id = @id";
                
                MySqlParameter[] parameters = 
                {
                    new MySqlParameter("@id", voucher.Id),
                    new MySqlParameter("@code", voucher.Code),
                    new MySqlParameter("@percentage", voucher.Percentage),
                    new MySqlParameter("@description", (object)voucher.Description ?? DBNull.Value),
                    new MySqlParameter("@start_at", (object)voucher.StartAt ?? DBNull.Value),
                    new MySqlParameter("@end_at", (object)voucher.EndAt ?? DBNull.Value),
                    new MySqlParameter("@usage_limit", (object)voucher.UsageLimit ?? DBNull.Value),
                    new MySqlParameter("@usage_count", voucher.UsageCount),
                    new MySqlParameter("@active", voucher.Active),
                    new MySqlParameter("@updated_at", DateTime.Now)
                };
                
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật voucher: {ex.Message}");
            }
        }

        public bool IncrementUsageCount(string id)
        {
            try
            {
                string query = @"UPDATE vouchers SET usage_count = usage_count + 1, 
                               updated_at = @updated_at 
                               WHERE id = @id";
                
                MySqlParameter[] parameters = 
                {
                    new MySqlParameter("@id", id),
                    new MySqlParameter("@updated_at", DateTime.Now)
                };
                
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tăng số lần sử dụng voucher: {ex.Message}");
            }
        }

        public bool Delete(string id)
        {
            try
            {
                // Hard delete for vouchers (or you can change to soft delete if needed)
                string query = "DELETE FROM vouchers WHERE id = @id";
                MySqlParameter[] parameters = 
                {
                    new MySqlParameter("@id", id)
                };
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa voucher: {ex.Message}");
            }
        }

        public bool Exists(string id)
        {
            string query = "SELECT COUNT(*) FROM vouchers WHERE id = @id";
            MySqlParameter[] parameters = { new MySqlParameter("@id", id) };
            int count = Convert.ToInt32(dbHelper.ExecuteScalar(query, parameters));
            return count > 0;
        }

        public bool IsCodeExists(string code, string excludeVoucherId = null)
        {
            string query = "SELECT COUNT(*) FROM vouchers WHERE code = @code";
            List<MySqlParameter> parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@code", code)
            };

            if (!string.IsNullOrEmpty(excludeVoucherId))
            {
                query += " AND id != @excludeVoucherId";
                parameters.Add(new MySqlParameter("@excludeVoucherId", excludeVoucherId));
            }

            int count = Convert.ToInt32(dbHelper.ExecuteScalar(query, parameters.ToArray()));
            return count > 0;
        }

        public PagedResult<Voucher> SearchVouchers(SearchCriteria criteria)
        {
            try
            {
                // Xây dựng WHERE clause
                List<string> conditions = new List<string>();
                List<MySqlParameter> parameters = new List<MySqlParameter>();

                // Filter theo code hoặc description
                if (!string.IsNullOrEmpty(criteria.SearchTerm))
                {
                    conditions.Add("(code LIKE @searchTerm OR description LIKE @searchTerm)");
                    parameters.Add(new MySqlParameter("@searchTerm", $"%{criteria.SearchTerm}%"));
                }

                string whereClause = conditions.Count > 0 ? "WHERE " + string.Join(" AND ", conditions) : "";

                // Tạo ORDER BY
                string orderBy = "ORDER BY created_at DESC";
                if (!string.IsNullOrEmpty(criteria.SortBy))
                {
                    orderBy = $"ORDER BY {criteria.SortBy} {criteria.SortDirection}";
                }

                // Đếm tổng số bản ghi
                string countQuery = $@"SELECT COUNT(*) FROM vouchers {whereClause}";
                int totalRecords = Convert.ToInt32(dbHelper.ExecuteScalar(countQuery, parameters.ToArray()));

                // Tính toán phân trang
                int offset = (criteria.PageNumber - 1) * criteria.PageSize;

                // Lấy dữ liệu với phân trang
                string dataQuery = $@"SELECT * FROM vouchers {whereClause} {orderBy} 
                                    LIMIT {criteria.PageSize} OFFSET {offset}";
                DataTable dt = dbHelper.ExecuteQuery(dataQuery, parameters.ToArray());

                return new PagedResult<Voucher>
                {
                    Data = ConvertDataTableToList(dt),
                    TotalRecords = totalRecords,
                    PageNumber = criteria.PageNumber,
                    PageSize = criteria.PageSize
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tìm kiếm voucher: {ex.Message}");
            }
        }

        private List<Voucher> ConvertDataTableToList(DataTable dt)
        {
            List<Voucher> list = new List<Voucher>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapDataRowToEntity(row));
            }
            return list;
        }
    }
}


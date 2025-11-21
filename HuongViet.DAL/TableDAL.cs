using HuongViet.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace HuongViet.DAL
{
    public class TableDAL
    {
        private readonly DatabaseHelper dbHelper;

        public TableDAL()
        {
            this.dbHelper = new DatabaseHelper();
        }

        private Table MapDataRowToEntity(DataRow row)
        {
            return new Table
            {
                TableID = row["TableID"].ToString(),
                TableName = row["TableName"].ToString(),
                TableStatus = (TableStatus)Enum.Parse(typeof(TableStatus), row["TableStatus"].ToString()),
                Capacity = Convert.ToInt32(row["Capacity"]),
                FloorID = row["FloorID"].ToString(),
                CurrentOrderID = row.IsNull("CurrentOrderID") ? null : row["CurrentOrderID"].ToString(),
                CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                UpdatedAt = Convert.ToDateTime(row["UpdatedAt"])
            };
        }

        public List<Table> GetAll()
        {
            string query = @"SELECT t.*, f.FloorNumber 
                           FROM tables t 
                           LEFT JOIN floors f ON t.FloorID = f.FloorID 
                           ORDER BY f.FloorNumber, t.TableName";
            DataTable dt = dbHelper.ExecuteQuery(query);
            return ConvertDataTableToList(dt);
        }

        public Table GetById(string id)
        {
            string query = @"SELECT t.*, f.FloorNumber 
                           FROM tables t 
                           LEFT JOIN floors f ON t.FloorID = f.FloorID 
                           WHERE t.TableID = @id";
            MySqlParameter[] parameters = { new MySqlParameter("@id", id) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            
            if (dt.Rows.Count > 0)
            {
                var table = MapDataRowToEntity(dt.Rows[0]);
                if (!dt.Rows[0].IsNull("FloorNumber"))
                {
                    table.Floor = new Floor
                    {
                        FloorID = table.FloorID,
                        FloorNumber = Convert.ToInt32(dt.Rows[0]["FloorNumber"])
                    };
                }
                return table;
            }
            return null;
        }

        public List<Table> GetByFloorId(string floorId)
        {
            string query = "SELECT * FROM tables WHERE FloorID = @floorId ORDER BY TableName";
            MySqlParameter[] parameters = { new MySqlParameter("@floorId", floorId) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            return ConvertDataTableToList(dt);
        }

        public List<Table> GetByStatus(TableStatus status)
        {
            string query = "SELECT * FROM tables WHERE TableStatus = @status ORDER BY TableName";
            MySqlParameter[] parameters = { new MySqlParameter("@status", status.ToString()) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            return ConvertDataTableToList(dt);
        }

        public bool Insert(Table table)
        {
            try
            {
                string query = @"INSERT INTO tables (TableID, TableName, TableStatus, Capacity, FloorID, 
                               CurrentOrderID, CreatedAt, UpdatedAt) 
                               VALUES (@TableID, @TableName, @TableStatus, @Capacity, @FloorID, 
                               @CurrentOrderID, @CreatedAt, @UpdatedAt)";
                
                MySqlParameter[] parameters = 
                {
                    new MySqlParameter("@TableID", table.TableID),
                    new MySqlParameter("@TableName", table.TableName),
                    new MySqlParameter("@TableStatus", table.TableStatus.ToString()),
                    new MySqlParameter("@Capacity", table.Capacity),
                    new MySqlParameter("@FloorID", table.FloorID),
                    new MySqlParameter("@CurrentOrderID", (object)table.CurrentOrderID ?? DBNull.Value),
                    new MySqlParameter("@CreatedAt", table.CreatedAt),
                    new MySqlParameter("@UpdatedAt", table.UpdatedAt)
                };
                
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm bàn: {ex.Message}");
            }
        }

        public bool Update(Table table)
        {
            try
            {
                string query = @"UPDATE tables SET TableName = @TableName, TableStatus = @TableStatus, 
                               Capacity = @Capacity, FloorID = @FloorID, CurrentOrderID = @CurrentOrderID,
                               UpdatedAt = @UpdatedAt WHERE TableID = @TableID";
                
                MySqlParameter[] parameters = 
                {
                    new MySqlParameter("@TableID", table.TableID),
                    new MySqlParameter("@TableName", table.TableName),
                    new MySqlParameter("@TableStatus", table.TableStatus.ToString()),
                    new MySqlParameter("@Capacity", table.Capacity),
                    new MySqlParameter("@FloorID", table.FloorID),
                    new MySqlParameter("@CurrentOrderID", (object)table.CurrentOrderID ?? DBNull.Value),
                    new MySqlParameter("@UpdatedAt", DateTime.Now)
                };
                
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật bàn: {ex.Message}");
            }
        }

        public bool Delete(string id)
        {
            try
            {
                // Check if table has active order
                string checkOrderQuery = "SELECT COUNT(*) FROM tables WHERE TableID = @id AND CurrentOrderID IS NOT NULL";
                int orderCount = Convert.ToInt32(dbHelper.ExecuteScalar(checkOrderQuery, new MySqlParameter("@id", id)));
                
                if (orderCount > 0)
                {
                    throw new Exception("Không thể xóa bàn vì đang có đơn hàng đang sử dụng!");
                }

                string query = "DELETE FROM tables WHERE TableID = @id";
                MySqlParameter[] parameters = { new MySqlParameter("@id", id) };
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa bàn: {ex.Message}");
            }
        }

        public bool Exists(string id)
        {
            string query = "SELECT COUNT(*) FROM tables WHERE TableID = @id";
            MySqlParameter[] parameters = { new MySqlParameter("@id", id) };
            int count = Convert.ToInt32(dbHelper.ExecuteScalar(query, parameters));
            return count > 0;
        }

        public bool IsTableNameExists(string tableName, string floorId, string excludeTableId = null)
        {
            string query = "SELECT COUNT(*) FROM tables WHERE TableName = @tableName AND FloorID = @floorId";
            List<MySqlParameter> parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@tableName", tableName),
                new MySqlParameter("@floorId", floorId)
            };

            if (!string.IsNullOrEmpty(excludeTableId))
            {
                query += " AND TableID != @excludeTableId";
                parameters.Add(new MySqlParameter("@excludeTableId", excludeTableId));
            }

            int count = Convert.ToInt32(dbHelper.ExecuteScalar(query, parameters.ToArray()));
            return count > 0;
        }

        public bool UpdateTableStatus(string tableId, TableStatus status)
        {
            try
            {
                string query = "UPDATE tables SET TableStatus = @status, UpdatedAt = @UpdatedAt WHERE TableID = @tableId";
                MySqlParameter[] parameters = 
                {
                    new MySqlParameter("@status", status.ToString()),
                    new MySqlParameter("@UpdatedAt", DateTime.Now),
                    new MySqlParameter("@tableId", tableId)
                };
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật trạng thái bàn: {ex.Message}");
            }
        }

        public PagedResult<Table> Search(SearchCriteria criteria, string floorId = null, TableStatus? status = null)
        {
            try
            {
                // Tạo điều kiện WHERE
                string whereClause = "";
                List<MySqlParameter> parameters = new List<MySqlParameter>();
                List<string> conditions = new List<string>();

                // Tìm kiếm keyword
                if (!string.IsNullOrEmpty(criteria.SearchTerm))
                {
                    conditions.Add(@"(t.TableName LIKE @searchTerm OR f.FloorNumber LIKE @searchTerm)");
                    parameters.Add(new MySqlParameter("@searchTerm", $"%{criteria.SearchTerm}%"));
                }

                // Filter theo FloorID
                if (!string.IsNullOrEmpty(floorId))
                {
                    conditions.Add("t.FloorID = @floorId");
                    parameters.Add(new MySqlParameter("@floorId", floorId));
                }

                // Filter theo Status
                if (status.HasValue)
                {
                    conditions.Add("t.TableStatus = @status");
                    parameters.Add(new MySqlParameter("@status", status.Value.ToString()));
                }

                if (conditions.Count > 0)
                {
                    whereClause = "WHERE " + string.Join(" AND ", conditions);
                }

                // Tạo ORDER BY
                string orderBy = "";
                if (!string.IsNullOrEmpty(criteria.SortBy))
                {
                    orderBy = $"ORDER BY {criteria.SortBy} {criteria.SortDirection}";
                }
                else
                {
                    orderBy = "ORDER BY f.FloorNumber, t.TableName";
                }

                // Đếm tổng số bản ghi
                string countQuery = @"SELECT COUNT(*) FROM tables t
                                    LEFT JOIN floors f ON t.FloorID = f.FloorID " + whereClause;

                int totalRecords = Convert.ToInt32(dbHelper.ExecuteScalar(countQuery, parameters.ToArray()));

                // Tính toán phân trang
                int offset = (criteria.PageNumber - 1) * criteria.PageSize;

                // Lấy dữ liệu với phân trang
                string dataQuery = @"SELECT t.*, f.FloorNumber 
                                   FROM tables t
                                   LEFT JOIN floors f ON t.FloorID = f.FloorID " +
                                   whereClause + " " + orderBy + $" LIMIT {criteria.PageSize} OFFSET {offset}";

                DataTable dt = dbHelper.ExecuteQuery(dataQuery, parameters.ToArray());

                return new PagedResult<Table>
                {
                    Data = ConvertDataTableToList(dt),
                    TotalRecords = totalRecords,
                    PageNumber = criteria.PageNumber,
                    PageSize = criteria.PageSize
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tìm kiếm bàn: {ex.Message}");
            }
        }

        private List<Table> ConvertDataTableToList(DataTable dt)
        {
            List<Table> list = new List<Table>();
            foreach (DataRow row in dt.Rows)
            {
                var table = MapDataRowToEntity(row);
                if (!row.IsNull("FloorNumber"))
                {
                    table.Floor = new Floor
                    {
                        FloorID = table.FloorID,
                        FloorNumber = Convert.ToInt32(row["FloorNumber"])
                    };
                }
                list.Add(table);
            }
            return list;
        }
    }
}


using HuongViet.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace HuongViet.DAL
{
    public class ItemDAL
    {
        private readonly DatabaseHelper dbHelper;

        public ItemDAL()
        {
            this.dbHelper = new DatabaseHelper();
        }

        private Item MapDataRowToEntity(DataRow row)
        {
            ItemType itemType;
            string itemTypeStr = row["ItemType"].ToString();
            switch (itemTypeStr)
            {
                case "Thức ăn":
                    itemType = ItemType.ThucAn;
                    break;
                case "Nước uống":
                    itemType = ItemType.NuocUong;
                    break;
                case "Dịch vụ":
                    itemType = ItemType.DichVu;
                    break;
                default:
                    itemType = ItemType.ThucAn;
                    break;
            }

            return new Item
            {
                ItemID = row["ItemID"].ToString(),
                ItemName = row["ItemName"].ToString(),
                ItemImage = row.IsNull("ItemImage") ? null : row["ItemImage"].ToString(),
                ItemType = itemType,
                ItemPrice = Convert.ToDecimal(row["ItemPrice"]),
                ItemDescription = row.IsNull("ItemDescription") ? null : row["ItemDescription"].ToString(),
                CateID = row["CateID"].ToString(),
                UnitID = row["UnitID"].ToString(),
                IsActive = Convert.ToBoolean(row["IsActive"]),
                DeletedAt = row.IsNull("DeletedAt") ? (DateTime?)null : Convert.ToDateTime(row["DeletedAt"]),
                CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                UpdatedAt = Convert.ToDateTime(row["UpdatedAt"])
            };
        }

        private string GetItemTypeString(ItemType itemType)
        {
            switch (itemType)
            {
                case ItemType.ThucAn:
                    return "Thức ăn";
                case ItemType.NuocUong:
                    return "Nước uống";
                case ItemType.DichVu:
                    return "Dịch vụ";
                default:
                    return "Thức ăn";
            }
        }

        public List<Item> GetAll()
        {
            // Lấy giá mới nhất từ bảng item_prices
            string query = @"SELECT i.*, c.CateName, u.UnitName,
                           COALESCE(
                               (SELECT ip.Price 
                                FROM item_prices ip 
                                WHERE ip.ItemID = i.ItemID 
                                ORDER BY ip.PriceUpdateDate DESC 
                                LIMIT 1), 
                               i.ItemPrice
                           ) as ItemPrice
                           FROM items i
                           LEFT JOIN categories c ON i.CateID = c.CateID
                           LEFT JOIN units u ON i.UnitID = u.UnitID
                           WHERE i.DeletedAt IS NULL
                           ORDER BY i.ItemName";
            DataTable dt = dbHelper.ExecuteQuery(query);
            return ConvertDataTableToList(dt);
        }

        public Item GetById(string id, bool loadPriceHistory = true)
        {
            // Lấy giá mới nhất từ bảng item_prices
            string query = @"SELECT i.*, c.CateName, u.UnitName,
                           COALESCE(
                               (SELECT ip.Price 
                                FROM item_prices ip 
                                WHERE ip.ItemID = i.ItemID 
                                ORDER BY ip.PriceUpdateDate DESC 
                                LIMIT 1), 
                               i.ItemPrice
                           ) as ItemPrice
                           FROM items i
                           LEFT JOIN categories c ON i.CateID = c.CateID
                           LEFT JOIN units u ON i.UnitID = u.UnitID
                           WHERE i.ItemID = @id AND i.DeletedAt IS NULL";
            MySqlParameter[] parameters = { new MySqlParameter("@id", id) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            
            if (dt.Rows.Count > 0)
            {
                var item = MapDataRowToEntity(dt.Rows[0]);
                
                // Add navigation properties
                if (!dt.Rows[0].IsNull("CateName"))
                {
                    item.Category = new Category
                    {
                        CateID = item.CateID,
                        CateName = dt.Rows[0]["CateName"].ToString()
                    };
                }
                
                if (!dt.Rows[0].IsNull("UnitName"))
                {
                    item.Unit = new Unit
                    {
                        UnitID = item.UnitID,
                        UnitName = dt.Rows[0]["UnitName"].ToString()
                    };
                }
                
                // Load price history nếu cần (mặc định có load)
                if (loadPriceHistory)
                {
                    item.ItemPrices = GetPriceHistory(item.ItemID);
                }
                
                return item;
            }
            return null;
        }

        public List<Item> GetByCategory(string categoryId)
        {
            string query = @"SELECT i.*, c.CateName, u.UnitName,
                           COALESCE(
                               (SELECT ip.Price 
                                FROM item_prices ip 
                                WHERE ip.ItemID = i.ItemID 
                                ORDER BY ip.PriceUpdateDate DESC 
                                LIMIT 1), 
                               i.ItemPrice
                           ) as ItemPrice
                           FROM items i
                           LEFT JOIN categories c ON i.CateID = c.CateID
                           LEFT JOIN units u ON i.UnitID = u.UnitID
                           WHERE i.CateID = @categoryId AND i.DeletedAt IS NULL
                           ORDER BY i.ItemName";
            MySqlParameter[] parameters = { new MySqlParameter("@categoryId", categoryId) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            return ConvertDataTableToList(dt);
        }

        public List<Item> GetByType(ItemType itemType)
        {
            string query = @"SELECT i.*, c.CateName, u.UnitName,
                           COALESCE(
                               (SELECT ip.Price 
                                FROM item_prices ip 
                                WHERE ip.ItemID = i.ItemID 
                                ORDER BY ip.PriceUpdateDate DESC 
                                LIMIT 1), 
                               i.ItemPrice
                           ) as ItemPrice
                           FROM items i
                           LEFT JOIN categories c ON i.CateID = c.CateID
                           LEFT JOIN units u ON i.UnitID = u.UnitID
                           WHERE i.ItemType = @itemType AND i.DeletedAt IS NULL
                           ORDER BY i.ItemName";
            MySqlParameter[] parameters = { new MySqlParameter("@itemType", GetItemTypeString(itemType)) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            return ConvertDataTableToList(dt);
        }

        public List<Item> GetActiveItems()
        {
            string query = @"SELECT i.*, c.CateName, u.UnitName,
                           COALESCE(
                               (SELECT ip.Price 
                                FROM item_prices ip 
                                WHERE ip.ItemID = i.ItemID 
                                ORDER BY ip.PriceUpdateDate DESC 
                                LIMIT 1), 
                               i.ItemPrice
                           ) as ItemPrice
                           FROM items i
                           LEFT JOIN categories c ON i.CateID = c.CateID
                           LEFT JOIN units u ON i.UnitID = u.UnitID
                           WHERE i.IsActive = 1 AND i.DeletedAt IS NULL
                           ORDER BY i.ItemName";
            DataTable dt = dbHelper.ExecuteQuery(query);
            return ConvertDataTableToList(dt);
        }

        public bool Insert(Item item)
        {
            try
            {
                string query = @"INSERT INTO items (ItemID, ItemName, ItemImage, ItemType, ItemPrice, 
                               ItemDescription, CateID, UnitID, IsActive, CreatedAt, UpdatedAt) 
                               VALUES (@ItemID, @ItemName, @ItemImage, @ItemType, @ItemPrice, 
                               @ItemDescription, @CateID, @UnitID, @IsActive, @CreatedAt, @UpdatedAt)";
                
                MySqlParameter[] parameters = 
                {
                    new MySqlParameter("@ItemID", item.ItemID),
                    new MySqlParameter("@ItemName", item.ItemName),
                    new MySqlParameter("@ItemImage", (object)item.ItemImage ?? DBNull.Value),
                    new MySqlParameter("@ItemType", GetItemTypeString(item.ItemType)),
                    new MySqlParameter("@ItemPrice", item.ItemPrice),
                    new MySqlParameter("@ItemDescription", (object)item.ItemDescription ?? DBNull.Value),
                    new MySqlParameter("@CateID", item.CateID),
                    new MySqlParameter("@UnitID", item.UnitID),
                    new MySqlParameter("@IsActive", item.IsActive),
                    new MySqlParameter("@CreatedAt", item.CreatedAt),
                    new MySqlParameter("@UpdatedAt", item.UpdatedAt)
                };
                
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                
                // Thêm giá ban đầu vào bảng item_prices
                if (result > 0)
                {
                    InsertItemPrice(item.ItemID, item.ItemPrice, DateTime.Now);
                }
                
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm món: {ex.Message}");
            }
        }

        public bool Update(Item item)
        {
            try
            {
                // Lấy giá hiện tại trước khi cập nhật
                var currentItem = GetById(item.ItemID, false);
                bool priceChanged = currentItem != null && currentItem.ItemPrice != item.ItemPrice;
                
                string query = @"UPDATE items SET ItemName = @ItemName, ItemImage = @ItemImage, 
                               ItemType = @ItemType, ItemPrice = @ItemPrice, ItemDescription = @ItemDescription, 
                               CateID = @CateID, UnitID = @UnitID, IsActive = @IsActive,
                               UpdatedAt = @UpdatedAt 
                               WHERE ItemID = @ItemID AND DeletedAt IS NULL";
                
                MySqlParameter[] parameters = 
                {
                    new MySqlParameter("@ItemID", item.ItemID),
                    new MySqlParameter("@ItemName", item.ItemName),
                    new MySqlParameter("@ItemImage", (object)item.ItemImage ?? DBNull.Value),
                    new MySqlParameter("@ItemType", GetItemTypeString(item.ItemType)),
                    new MySqlParameter("@ItemPrice", item.ItemPrice),
                    new MySqlParameter("@ItemDescription", (object)item.ItemDescription ?? DBNull.Value),
                    new MySqlParameter("@CateID", item.CateID),
                    new MySqlParameter("@UnitID", item.UnitID),
                    new MySqlParameter("@IsActive", item.IsActive),
                    new MySqlParameter("@UpdatedAt", DateTime.Now)
                };
                
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                
                // Nếu giá thay đổi, thêm vào lịch sử giá
                if (result > 0 && priceChanged)
                {
                    InsertItemPrice(item.ItemID, item.ItemPrice, DateTime.Now);
                }
                
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật món: {ex.Message}");
            }
        }

        public bool UpdatePrice(string itemId, decimal? newPrice)
        {
            try
            {
                // Nếu không nhập giá mới (null), không làm gì
                if (!newPrice.HasValue)
                {
                    return true; // Không cập nhật nhưng vẫn trả về true
                }

                // Cập nhật giá trong bảng items
                string updateQuery = @"UPDATE items SET ItemPrice = @newPrice, UpdatedAt = @UpdatedAt 
                                     WHERE ItemID = @itemId AND DeletedAt IS NULL";
                
                MySqlParameter[] updateParams = 
                {
                    new MySqlParameter("@itemId", itemId),
                    new MySqlParameter("@newPrice", newPrice.Value),
                    new MySqlParameter("@UpdatedAt", DateTime.Now)
                };
                
                int result = dbHelper.ExecuteNonQuery(updateQuery, updateParams);
                
                // Thêm bản ghi mới vào bảng item_prices để lưu lịch sử giá
                if (result > 0)
                {
                    InsertItemPrice(itemId, newPrice.Value, DateTime.Now);
                }
                
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật giá món: {ex.Message}");
            }
        }

        private bool InsertItemPrice(string itemId, decimal price, DateTime priceUpdateDate)
        {
            try
            {
                string query = @"INSERT INTO item_prices (PriceUpdateDate, ItemID, Price, CreatedAt) 
                               VALUES (@PriceUpdateDate, @ItemID, @Price, @CreatedAt)";
                
                MySqlParameter[] parameters = 
                {
                    new MySqlParameter("@PriceUpdateDate", priceUpdateDate),
                    new MySqlParameter("@ItemID", itemId),
                    new MySqlParameter("@Price", price),
                    new MySqlParameter("@CreatedAt", DateTime.Now)
                };
                
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lưu lịch sử giá: {ex.Message}");
            }
        }

        public List<ItemPrice> GetPriceHistory(string itemId)
        {
            try
            {
                string query = @"SELECT * FROM item_prices 
                               WHERE ItemID = @itemId 
                               ORDER BY PriceUpdateDate DESC";
                
                MySqlParameter[] parameters = { new MySqlParameter("@itemId", itemId) };
                DataTable dt = dbHelper.ExecuteQuery(query, parameters);
                
                List<ItemPrice> priceHistory = new List<ItemPrice>();
                foreach (DataRow row in dt.Rows)
                {
                    priceHistory.Add(new ItemPrice
                    {
                        PriceUpdateDate = Convert.ToDateTime(row["PriceUpdateDate"]),
                        ItemID = row["ItemID"].ToString(),
                        Price = Convert.ToDecimal(row["Price"]),
                        CreatedAt = Convert.ToDateTime(row["CreatedAt"])
                    });
                }
                
                return priceHistory;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy lịch sử giá: {ex.Message}");
            }
        }

        public bool Delete(string id)
        {
            try
            {
                // Soft delete
                string query = "UPDATE items SET DeletedAt = @DeletedAt WHERE ItemID = @id";
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
                throw new Exception($"Lỗi khi xóa món: {ex.Message}");
            }
        }

        public bool Exists(string id)
        {
            string query = "SELECT COUNT(*) FROM items WHERE ItemID = @id AND DeletedAt IS NULL";
            MySqlParameter[] parameters = { new MySqlParameter("@id", id) };
            int count = Convert.ToInt32(dbHelper.ExecuteScalar(query, parameters));
            return count > 0;
        }

        public bool IsItemNameExists(string itemName, string excludeItemId = null)
        {
            string query = "SELECT COUNT(*) FROM items WHERE ItemName = @itemName AND DeletedAt IS NULL";
            List<MySqlParameter> parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@itemName", itemName)
            };

            if (!string.IsNullOrEmpty(excludeItemId))
            {
                query += " AND ItemID != @excludeItemId";
                parameters.Add(new MySqlParameter("@excludeItemId", excludeItemId));
            }

            int count = Convert.ToInt32(dbHelper.ExecuteScalar(query, parameters.ToArray()));
            return count > 0;
        }

        public bool UpdateActiveStatus(string itemId, bool isActive)
        {
            try
            {
                string query = @"UPDATE items SET IsActive = @isActive, UpdatedAt = @UpdatedAt 
                               WHERE ItemID = @itemId AND DeletedAt IS NULL";
                
                MySqlParameter[] parameters = 
                {
                    new MySqlParameter("@itemId", itemId),
                    new MySqlParameter("@isActive", isActive),
                    new MySqlParameter("@UpdatedAt", DateTime.Now)
                };
                
                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật trạng thái món: {ex.Message}");
            }
        }

        private List<Item> ConvertDataTableToList(DataTable dt, bool loadPriceHistory = false)
        {
            List<Item> list = new List<Item>();
            foreach (DataRow row in dt.Rows)
            {
                var item = MapDataRowToEntity(row);
                
                // Add navigation properties if available
                if (!row.IsNull("CateName"))
                {
                    item.Category = new Category
                    {
                        CateID = item.CateID,
                        CateName = row["CateName"].ToString()
                    };
                }
                
                if (!row.IsNull("UnitName"))
                {
                    item.Unit = new Unit
                    {
                        UnitID = item.UnitID,
                        UnitName = row["UnitName"].ToString()
                    };
                }
                
                // Load price history nếu cần (mặc định không load để tránh chậm khi GetAll)
                if (loadPriceHistory)
                {
                    item.ItemPrices = GetPriceHistory(item.ItemID);
                }
                
                list.Add(item);
            }
            return list;
        }

        /// <summary>
        /// Tìm kiếm món ăn với filter và pagination
        /// </summary>
        public PagedResult<Item> SearchItems(SearchCriteria criteria, string categoryId = null, ItemType? itemType = null, decimal? priceFrom = null, decimal? priceTo = null)
        {
            try
            {
                // Xây dựng WHERE clause
                List<string> conditions = new List<string> { "i.DeletedAt IS NULL" };
                List<MySqlParameter> parameters = new List<MySqlParameter>();

                // Filter theo tên món
                if (!string.IsNullOrEmpty(criteria.SearchTerm))
                {
                    conditions.Add("i.ItemName LIKE @searchTerm");
                    parameters.Add(new MySqlParameter("@searchTerm", $"%{criteria.SearchTerm}%"));
                }

                // Filter theo danh mục
                if (!string.IsNullOrEmpty(categoryId))
                {
                    conditions.Add("i.CateID = @categoryId");
                    parameters.Add(new MySqlParameter("@categoryId", categoryId));
                }

                // Filter theo loại món
                if (itemType.HasValue)
                {
                    conditions.Add("i.ItemType = @itemType");
                    parameters.Add(new MySqlParameter("@itemType", GetItemTypeString(itemType.Value)));
                }

                // Filter theo giá từ
                if (priceFrom.HasValue)
                {
                    conditions.Add("COALESCE((SELECT ip.Price FROM item_prices ip WHERE ip.ItemID = i.ItemID ORDER BY ip.PriceUpdateDate DESC LIMIT 1), i.ItemPrice) >= @priceFrom");
                    parameters.Add(new MySqlParameter("@priceFrom", priceFrom.Value));
                }

                // Filter theo giá đến
                if (priceTo.HasValue)
                {
                    conditions.Add("COALESCE((SELECT ip.Price FROM item_prices ip WHERE ip.ItemID = i.ItemID ORDER BY ip.PriceUpdateDate DESC LIMIT 1), i.ItemPrice) <= @priceTo");
                    parameters.Add(new MySqlParameter("@priceTo", priceTo.Value));
                }

                string whereClause = "WHERE " + string.Join(" AND ", conditions);

                // Tạo ORDER BY
                string orderBy = "ORDER BY i.ItemName ASC";
                if (!string.IsNullOrEmpty(criteria.SortBy))
                {
                    orderBy = $"ORDER BY {criteria.SortBy} {criteria.SortDirection}";
                }

                // Đếm tổng số bản ghi
                string countQuery = $@"SELECT COUNT(*) FROM items i {whereClause}";
                int totalRecords = Convert.ToInt32(dbHelper.ExecuteScalar(countQuery, parameters.ToArray()));

                // Tính toán phân trang
                int offset = (criteria.PageNumber - 1) * criteria.PageSize;

                // Lấy dữ liệu với phân trang
                string dataQuery = $@"SELECT i.*, c.CateName, u.UnitName,
                                   COALESCE(
                                       (SELECT ip.Price 
                                        FROM item_prices ip 
                                        WHERE ip.ItemID = i.ItemID 
                                        ORDER BY ip.PriceUpdateDate DESC 
                                        LIMIT 1), 
                                       i.ItemPrice
                                   ) as ItemPrice
                                   FROM items i
                                   LEFT JOIN categories c ON i.CateID = c.CateID
                                   LEFT JOIN units u ON i.UnitID = u.UnitID
                                   {whereClause} {orderBy} LIMIT {criteria.PageSize} OFFSET {offset}";
                DataTable dt = dbHelper.ExecuteQuery(dataQuery, parameters.ToArray());

                return new PagedResult<Item>
                {
                    Data = ConvertDataTableToList(dt),
                    TotalRecords = totalRecords,
                    PageNumber = criteria.PageNumber,
                    PageSize = criteria.PageSize
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tìm kiếm món: {ex.Message}");
            }
        }
    }
}


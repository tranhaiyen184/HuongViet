using HuongViet.DAL;
using HuongViet.Models;
using System;
using System.Collections.Generic;

namespace HuongViet.BLL
{
    public class ItemBLL
    {
        private readonly ItemDAL itemDAL;
        private readonly CategoryDAL categoryDAL;
        private readonly UnitDAL unitDAL;

        public ItemBLL()
        {
            this.itemDAL = new ItemDAL();
            this.categoryDAL = new CategoryDAL();
            this.unitDAL = new UnitDAL();
        }

        public List<Item> GetAll()
        {
            try
            {
                return itemDAL.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách món: {ex.Message}");
            }
        }

        public Item GetById(string id, bool loadPriceHistory = true)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id))
                {
                    throw new ArgumentException("Mã món không được để trống");
                }

                return itemDAL.GetById(id, loadPriceHistory);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy thông tin món: {ex.Message}");
            }
        }

        public List<Item> GetByCategory(string categoryId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(categoryId))
                {
                    throw new ArgumentException("Mã danh mục không được để trống");
                }

                return itemDAL.GetByCategory(categoryId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách món theo danh mục: {ex.Message}");
            }
        }

        public List<Item> GetByType(ItemType itemType)
        {
            try
            {
                return itemDAL.GetByType(itemType);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách món theo loại: {ex.Message}");
            }
        }

        public List<Item> GetActiveItems()
        {
            try
            {
                return itemDAL.GetActiveItems();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách món đang hoạt động: {ex.Message}");
            }
        }

        public bool Insert(Item item)
        {
            try
            {
                ValidateItem(item);

                // Check if ID already exists
                if (itemDAL.Exists(item.ItemID))
                {
                    throw new Exception("Mã món đã tồn tại");
                }

                // Check if name already exists
                if (itemDAL.IsItemNameExists(item.ItemName))
                {
                    throw new Exception("Tên món đã tồn tại");
                }

                // Check if category exists
                if (!categoryDAL.Exists(item.CateID))
                {
                    throw new Exception("Danh mục không tồn tại");
                }

                // Check if unit exists
                if (!unitDAL.Exists(item.UnitID))
                {
                    throw new Exception("Đơn vị tính không tồn tại");
                }

                return itemDAL.Insert(item);
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
                ValidateItem(item);

                // Check if item exists
                if (!itemDAL.Exists(item.ItemID))
                {
                    throw new Exception("Món không tồn tại");
                }

                // Check if name already exists (exclude current item)
                if (itemDAL.IsItemNameExists(item.ItemName, item.ItemID))
                {
                    throw new Exception("Tên món đã tồn tại");
                }

                // Check if category exists
                if (!categoryDAL.Exists(item.CateID))
                {
                    throw new Exception("Danh mục không tồn tại");
                }

                // Check if unit exists
                if (!unitDAL.Exists(item.UnitID))
                {
                    throw new Exception("Đơn vị tính không tồn tại");
                }

                return itemDAL.Update(item);
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
                if (string.IsNullOrWhiteSpace(itemId))
                {
                    throw new ArgumentException("Mã món không được để trống");
                }

                if (!itemDAL.Exists(itemId))
                {
                    throw new Exception("Món không tồn tại");
                }

                if (newPrice.HasValue && newPrice.Value < 0)
                {
                    throw new ArgumentException("Giá món không được âm");
                }

                return itemDAL.UpdatePrice(itemId, newPrice);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật giá món: {ex.Message}");
            }
        }

        public bool Delete(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id))
                {
                    throw new ArgumentException("Mã món không được để trống");
                }

                if (!itemDAL.Exists(id))
                {
                    throw new Exception("Món không tồn tại");
                }

                return itemDAL.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa món: {ex.Message}");
            }
        }

        public bool UpdateActiveStatus(string itemId, bool isActive)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(itemId))
                {
                    throw new ArgumentException("Mã món không được để trống");
                }

                if (!itemDAL.Exists(itemId))
                {
                    throw new Exception("Món không tồn tại");
                }

                return itemDAL.UpdateActiveStatus(itemId, isActive);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật trạng thái món: {ex.Message}");
            }
        }

        public List<ItemPrice> GetPriceHistory(string itemId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(itemId))
                {
                    throw new ArgumentException("Mã món không được để trống");
                }

                return itemDAL.GetPriceHistory(itemId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy lịch sử giá: {ex.Message}");
            }
        }

        public bool Exists(string id)
        {
            try
            {
                return itemDAL.Exists(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi kiểm tra món: {ex.Message}");
            }
        }

        public string GenerateNewItemID()
        {
            try
            {
                var items = itemDAL.GetAll();
                int maxNumber = 0;

                foreach (var item in items)
                {
                    if (item.ItemID.StartsWith("ITEM"))
                    {
                        string numberPart = item.ItemID.Substring(4);
                        if (int.TryParse(numberPart, out int number))
                        {
                            maxNumber = Math.Max(maxNumber, number);
                        }
                    }
                }

                return $"ITEM{(maxNumber + 1).ToString("D3")}";
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tạo mã món: {ex.Message}");
            }
        }

        private void ValidateItem(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Thông tin món không được null");
            }

            if (string.IsNullOrWhiteSpace(item.ItemID))
            {
                throw new ArgumentException("Mã món không được để trống");
            }

            if (string.IsNullOrWhiteSpace(item.ItemName))
            {
                throw new ArgumentException("Tên món không được để trống");
            }

            if (item.ItemName.Length > 200)
            {
                throw new ArgumentException("Tên món không được vượt quá 200 ký tự");
            }

            if (string.IsNullOrWhiteSpace(item.CateID))
            {
                throw new ArgumentException("Danh mục không được để trống");
            }

            if (string.IsNullOrWhiteSpace(item.UnitID))
            {
                throw new ArgumentException("Đơn vị tính không được để trống");
            }

            if (item.ItemPrice < 0)
            {
                throw new ArgumentException("Giá món không được âm");
            }

            if (!string.IsNullOrWhiteSpace(item.ItemDescription) && item.ItemDescription.Length > 1000)
            {
                throw new ArgumentException("Mô tả món không được vượt quá 1000 ký tự");
            }
        }

        /// <summary>
        /// Tìm kiếm món ăn với filter và pagination
        /// </summary>
        public PagedResult<Item> SearchItems(SearchCriteria criteria, string categoryId = null, ItemType? itemType = null, decimal? priceFrom = null, decimal? priceTo = null)
        {
            try
            {
                if (criteria == null)
                {
                    criteria = new SearchCriteria
                    {
                        PageNumber = 1,
                        PageSize = 20
                    };
                }

                // Validate page number
                if (criteria.PageNumber < 1)
                {
                    criteria.PageNumber = 1;
                }

                // Validate page size
                if (criteria.PageSize < 1)
                {
                    criteria.PageSize = 20;
                }

                // Validate giá
                if (priceFrom.HasValue && priceFrom.Value < 0)
                {
                    throw new ArgumentException("Giá từ không được âm");
                }

                if (priceTo.HasValue && priceTo.Value < 0)
                {
                    throw new ArgumentException("Giá đến không được âm");
                }

                if (priceFrom.HasValue && priceTo.HasValue && priceFrom.Value > priceTo.Value)
                {
                    throw new ArgumentException("Giá từ không được lớn hơn giá đến");
                }

                return itemDAL.SearchItems(criteria, categoryId, itemType, priceFrom, priceTo);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tìm kiếm món: {ex.Message}");
            }
        }
    }
}


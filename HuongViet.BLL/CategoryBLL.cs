using HuongViet.DAL;
using HuongViet.Models;
using System;
using System.Collections.Generic;

namespace HuongViet.BLL
{
    public class CategoryBLL
    {
        private readonly CategoryDAL categoryDAL;

        public CategoryBLL()
        {
            this.categoryDAL = new CategoryDAL();
        }

        public List<Category> GetAll()
        {
            try
            {
                return categoryDAL.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách danh mục: {ex.Message}");
            }
        }

        public Category GetById(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id))
                {
                    throw new ArgumentException("Mã danh mục không được để trống");
                }

                return categoryDAL.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy thông tin danh mục: {ex.Message}");
            }
        }

        public bool Insert(Category category)
        {
            try
            {
                ValidateCategory(category);

                // Check if ID already exists
                if (categoryDAL.Exists(category.CateID))
                {
                    throw new Exception("Mã danh mục đã tồn tại");
                }

                // Check if name already exists
                if (categoryDAL.IsCategoryNameExists(category.CateName))
                {
                    throw new Exception("Tên danh mục đã tồn tại");
                }

                return categoryDAL.Insert(category);
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
                ValidateCategory(category);

                // Check if category exists
                if (!categoryDAL.Exists(category.CateID))
                {
                    throw new Exception("Danh mục không tồn tại");
                }

                // Check if name already exists (exclude current category)
                if (categoryDAL.IsCategoryNameExists(category.CateName, category.CateID))
                {
                    throw new Exception("Tên danh mục đã tồn tại");
                }

                return categoryDAL.Update(category);
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
                if (string.IsNullOrWhiteSpace(id))
                {
                    throw new ArgumentException("Mã danh mục không được để trống");
                }

                if (!categoryDAL.Exists(id))
                {
                    throw new Exception("Danh mục không tồn tại");
                }

                return categoryDAL.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa danh mục: {ex.Message}");
            }
        }

        public bool Exists(string id)
        {
            try
            {
                return categoryDAL.Exists(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi kiểm tra danh mục: {ex.Message}");
            }
        }

        public string GenerateNewCategoryID()
        {
            try
            {
                var categories = categoryDAL.GetAll();
                int maxNumber = 0;

                foreach (var cat in categories)
                {
                    if (cat.CateID.StartsWith("CATE"))
                    {
                        string numberPart = cat.CateID.Substring(4);
                        if (int.TryParse(numberPart, out int number))
                        {
                            maxNumber = Math.Max(maxNumber, number);
                        }
                    }
                }

                return $"CATE{(maxNumber + 1).ToString("D3")}";
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tạo mã danh mục: {ex.Message}");
            }
        }

        private void ValidateCategory(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category), "Thông tin danh mục không được null");
            }

            if (string.IsNullOrWhiteSpace(category.CateID))
            {
                throw new ArgumentException("Mã danh mục không được để trống");
            }

            if (string.IsNullOrWhiteSpace(category.CateName))
            {
                throw new ArgumentException("Tên danh mục không được để trống");
            }

            if (category.CateName.Length > 100)
            {
                throw new ArgumentException("Tên danh mục không được vượt quá 100 ký tự");
            }

            if (!string.IsNullOrWhiteSpace(category.CateDescription) && category.CateDescription.Length > 500)
            {
                throw new ArgumentException("Mô tả danh mục không được vượt quá 500 ký tự");
            }
        }
    }
}


using HuongViet.DAL;
using HuongViet.Models;
using System;
using System.Collections.Generic;

namespace HuongViet.BLL
{
    public class UnitBLL
    {
        private readonly UnitDAL unitDAL;

        public UnitBLL()
        {
            this.unitDAL = new UnitDAL();
        }

        public List<Unit> GetAll()
        {
            try
            {
                return unitDAL.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách đơn vị tính: {ex.Message}");
            }
        }

        public Unit GetById(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id))
                {
                    throw new ArgumentException("Mã đơn vị tính không được để trống");
                }

                return unitDAL.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy thông tin đơn vị tính: {ex.Message}");
            }
        }

        public bool Insert(Unit unit)
        {
            try
            {
                ValidateUnit(unit);

                // Check if ID already exists
                if (unitDAL.Exists(unit.UnitID))
                {
                    throw new Exception("Mã đơn vị tính đã tồn tại");
                }

                // Check if name already exists
                if (unitDAL.IsUnitNameExists(unit.UnitName))
                {
                    throw new Exception("Tên đơn vị tính đã tồn tại");
                }

                return unitDAL.Insert(unit);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm đơn vị tính: {ex.Message}");
            }
        }

        public bool Update(Unit unit)
        {
            try
            {
                ValidateUnit(unit);

                // Check if unit exists
                if (!unitDAL.Exists(unit.UnitID))
                {
                    throw new Exception("Đơn vị tính không tồn tại");
                }

                // Check if name already exists (exclude current unit)
                if (unitDAL.IsUnitNameExists(unit.UnitName, unit.UnitID))
                {
                    throw new Exception("Tên đơn vị tính đã tồn tại");
                }

                return unitDAL.Update(unit);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật đơn vị tính: {ex.Message}");
            }
        }

        public bool Delete(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id))
                {
                    throw new ArgumentException("Mã đơn vị tính không được để trống");
                }

                if (!unitDAL.Exists(id))
                {
                    throw new Exception("Đơn vị tính không tồn tại");
                }

                return unitDAL.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa đơn vị tính: {ex.Message}");
            }
        }

        public bool Exists(string id)
        {
            try
            {
                return unitDAL.Exists(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi kiểm tra đơn vị tính: {ex.Message}");
            }
        }

        public string GenerateNewUnitID()
        {
            try
            {
                var units = unitDAL.GetAll();
                int maxNumber = 0;

                foreach (var unit in units)
                {
                    if (unit.UnitID.StartsWith("UNIT"))
                    {
                        string numberPart = unit.UnitID.Substring(4);
                        if (int.TryParse(numberPart, out int number))
                        {
                            maxNumber = Math.Max(maxNumber, number);
                        }
                    }
                }

                return $"UNIT{(maxNumber + 1).ToString("D3")}";
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tạo mã đơn vị tính: {ex.Message}");
            }
        }

        private void ValidateUnit(Unit unit)
        {
            if (unit == null)
            {
                throw new ArgumentNullException(nameof(unit), "Thông tin đơn vị tính không được null");
            }

            if (string.IsNullOrWhiteSpace(unit.UnitID))
            {
                throw new ArgumentException("Mã đơn vị tính không được để trống");
            }

            if (string.IsNullOrWhiteSpace(unit.UnitName))
            {
                throw new ArgumentException("Tên đơn vị tính không được để trống");
            }

            if (unit.UnitName.Length > 50)
            {
                throw new ArgumentException("Tên đơn vị tính không được vượt quá 50 ký tự");
            }
        }
    }
}


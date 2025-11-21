using HuongViet.DAL;
using HuongViet.Models;
using System;
using System.Collections.Generic;

namespace HuongViet.BLL
{
    public class TableBLL
    {
        private readonly TableDAL tableDAL;
        private readonly FloorDAL floorDAL;

        public TableBLL()
        {
            tableDAL = new TableDAL();
            floorDAL = new FloorDAL();
        }

        /// <summary>
        /// Lấy tất cả bàn
        /// </summary>
        /// <returns>Danh sách bàn</returns>
        public List<Table> GetAllTables()
        {
            try
            {
                return tableDAL.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách bàn: {ex.Message}");
            }
        }

        /// <summary>
        /// Lấy bàn theo ID
        /// </summary>
        /// <param name="tableId">ID bàn</param>
        /// <returns>Thông tin bàn</returns>
        public Table GetTableById(string tableId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tableId))
                    return null;

                return tableDAL.GetById(tableId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy thông tin bàn: {ex.Message}");
            }
        }

        /// <summary>
        /// Lấy danh sách bàn theo tầng
        /// </summary>
        /// <param name="floorId">ID tầng</param>
        /// <returns>Danh sách bàn</returns>
        public List<Table> GetTablesByFloor(string floorId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(floorId))
                    return new List<Table>();

                return tableDAL.GetByFloorId(floorId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách bàn: {ex.Message}");
            }
        }

        /// <summary>
        /// Lấy danh sách bàn theo trạng thái
        /// </summary>
        /// <param name="status">Trạng thái</param>
        /// <returns>Danh sách bàn</returns>
        public List<Table> GetTablesByStatus(TableStatus status)
        {
            try
            {
                return tableDAL.GetByStatus(status);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách bàn: {ex.Message}");
            }
        }

        /// <summary>
        /// Thêm bàn mới
        /// </summary>
        /// <param name="table">Thông tin bàn</param>
        /// <returns>True nếu thành công</returns>
        public bool AddTable(Table table)
        {
            try
            {
                // Validate input
                string validationError = ValidateTable(table);
                if (!string.IsNullOrEmpty(validationError))
                {
                    throw new Exception(validationError);
                }

                // Check if table name already exists on the same floor
                if (tableDAL.IsTableNameExists(table.TableName, table.FloorID))
                {
                    throw new Exception("Tên bàn đã tồn tại trên tầng này!");
                }

                // Generate ID if not provided
                if (string.IsNullOrWhiteSpace(table.TableID))
                {
                    table.TableID = GenerateTableId();
                }

                table.CreatedAt = DateTime.Now;
                table.UpdatedAt = DateTime.Now;

                return tableDAL.Insert(table);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm bàn: {ex.Message}");
            }
        }

        /// <summary>
        /// Cập nhật bàn
        /// </summary>
        /// <param name="table">Thông tin bàn</param>
        /// <returns>True nếu thành công</returns>
        public bool UpdateTable(Table table)
        {
            try
            {
                // Validate input
                string validationError = ValidateTable(table);
                if (!string.IsNullOrEmpty(validationError))
                {
                    throw new Exception(validationError);
                }

                // Check if table exists
                if (!tableDAL.Exists(table.TableID))
                {
                    throw new Exception("Bàn không tồn tại!");
                }

                // Check if table name already exists on the same floor (excluding current table)
                if (tableDAL.IsTableNameExists(table.TableName, table.FloorID, table.TableID))
                {
                    throw new Exception("Tên bàn đã tồn tại trên tầng này!");
                }

                table.UpdatedAt = DateTime.Now;

                return tableDAL.Update(table);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật bàn: {ex.Message}");
            }
        }

        /// <summary>
        /// Xóa bàn
        /// </summary>
        /// <param name="tableId">ID bàn</param>
        /// <returns>True nếu thành công</returns>
        public bool DeleteTable(string tableId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tableId))
                {
                    throw new Exception("ID bàn không hợp lệ!");
                }

                // Check if table exists
                if (!tableDAL.Exists(tableId))
                {
                    throw new Exception("Bàn không tồn tại!");
                }

                return tableDAL.Delete(tableId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa bàn: {ex.Message}");
            }
        }

        /// <summary>
        /// Cập nhật trạng thái bàn
        /// </summary>
        /// <param name="tableId">ID bàn</param>
        /// <param name="status">Trạng thái mới</param>
        /// <returns>True nếu thành công</returns>
        public bool UpdateTableStatus(string tableId, TableStatus status)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tableId))
                {
                    throw new Exception("ID bàn không hợp lệ!");
                }

                // Check if table exists
                if (!tableDAL.Exists(tableId))
                {
                    throw new Exception("Bàn không tồn tại!");
                }

                return tableDAL.UpdateTableStatus(tableId, status);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật trạng thái bàn: {ex.Message}");
            }
        }

        /// <summary>
        /// Lấy danh sách tầng (để hiển thị trong ComboBox)
        /// </summary>
        /// <returns>Danh sách tầng</returns>
        public List<Floor> GetAllFloors()
        {
            try
            {
                return floorDAL.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách tầng: {ex.Message}");
            }
        }

        /// <summary>
        /// Tìm kiếm bàn với phân trang
        /// </summary>
        /// <param name="criteria">Tiêu chí tìm kiếm và phân trang</param>
        /// <param name="floorId">Lọc theo tầng (null = tất cả)</param>
        /// <param name="status">Lọc theo trạng thái (null = tất cả)</param>
        /// <returns>Kết quả phân trang</returns>
        public PagedResult<Table> SearchTables(SearchCriteria criteria, string floorId = null, TableStatus? status = null)
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

                return tableDAL.Search(criteria, floorId, status);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tìm kiếm bàn: {ex.Message}");
            }
        }

        #region Private Methods

        /// <summary>
        /// Validate thông tin bàn
        /// </summary>
        /// <param name="table">Thông tin bàn</param>
        /// <returns>Thông báo lỗi hoặc null nếu hợp lệ</returns>
        private string ValidateTable(Table table)
        {
            if (table == null)
                return "Thông tin bàn không hợp lệ!";

            if (string.IsNullOrWhiteSpace(table.TableName))
                return "Vui lòng nhập tên bàn!";

            if (table.TableName.Length > 20)
                return "Tên bàn không được vượt quá 20 ký tự!";

            if (string.IsNullOrWhiteSpace(table.FloorID))
                return "Vui lòng chọn tầng!";

            // Check if floor exists
            var floor = floorDAL.GetById(table.FloorID);
            if (floor == null)
                return "Tầng không tồn tại!";

            if (table.Capacity <= 0)
                return "Sức chứa phải lớn hơn 0!";

            return null; // Valid
        }

        /// <summary>
        /// Tạo ID bàn tự động
        /// </summary>
        /// <returns>ID bàn</returns>
        private string GenerateTableId()
        {
            return "TBL" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        #endregion
    }
}


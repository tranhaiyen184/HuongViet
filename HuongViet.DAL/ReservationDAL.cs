using HuongViet.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace HuongViet.DAL
{
    public class ReservationDAL
    {
        private readonly DatabaseHelper dbHelper;

        public ReservationDAL()
        {
            dbHelper = new DatabaseHelper();
        }

        private Reservation MapDataRowToEntity(DataRow row)
        {
            return new Reservation
            {
                ReservationID = row["ReservationID"].ToString(),
                CustomerID = row.IsNull("CustomerID") ? null : row["CustomerID"].ToString(),
                CustomerName = row.IsNull("CustomerName") ? null : row["CustomerName"].ToString(),
                ContactPhone = row.IsNull("ContactPhone") ? null : row["ContactPhone"].ToString(),
                ReservationDate = row.IsNull("ReservationDate") ? DateTime.MinValue : Convert.ToDateTime(row["ReservationDate"]),
                ReservationTime = row.IsNull("ReservationTime") ? TimeSpan.Zero : TimeSpan.Parse(row["ReservationTime"].ToString()),
                NumberOfGuests = row.IsNull("NumberOfGuests") ? 0 : Convert.ToInt32(row["NumberOfGuests"]),
                TableID = row.IsNull("TableID") ? null : row["TableID"].ToString(),
                RoomID = row.IsNull("RoomID") ? null : row["RoomID"].ToString(),
                Duration = row.IsNull("Duration") ? (int?)null : Convert.ToInt32(row["Duration"]),
                ReservationStatus = row.IsNull("ReservationStatus") ? ReservationStatus.Pending : (ReservationStatus)Enum.Parse(typeof(ReservationStatus), row["ReservationStatus"].ToString()),
                SpecialRequests = row.IsNull("SpecialRequests") ? null : row["SpecialRequests"].ToString(),
                DepositAmount = row.IsNull("DepositAmount") ? (decimal?)null : Convert.ToDecimal(row["DepositAmount"]),
                DeletedAt = row.IsNull("DeletedAt") ? (DateTime?)null : Convert.ToDateTime(row["DeletedAt"]),
                CreatedAt = row.IsNull("CreatedAt") ? DateTime.MinValue : Convert.ToDateTime(row["CreatedAt"]),
                UpdatedAt = row.IsNull("UpdatedAt") ? DateTime.MinValue : Convert.ToDateTime(row["UpdatedAt"])            };
        }

        public List<Reservation> GetAll()
        {
            string query = "SELECT * FROM reservations WHERE DeletedAt IS NULL ORDER BY ReservationDate, ReservationTime";
            DataTable dt = dbHelper.ExecuteQuery(query);
            return ConvertDataTableToList(dt);
        }

        public Reservation GetById(string id)
        {
            string query = "SELECT * FROM reservations WHERE ReservationID = @id AND DeletedAt IS NULL";
            MySqlParameter[] parameters = { new MySqlParameter("@id", id) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            if (dt.Rows.Count > 0) return MapDataRowToEntity(dt.Rows[0]);
            return null;
        }

        public List<Reservation> GetByCustomerId(string customerId)
        {
            string query = "SELECT * FROM reservations WHERE CustomerID = @customerId AND DeletedAt IS NULL ORDER BY ReservationDate DESC";
            MySqlParameter[] parameters = { new MySqlParameter("@customerId", customerId) };
            DataTable dt = dbHelper.ExecuteQuery(query, parameters);
            return ConvertDataTableToList(dt);
        }

        public bool Insert(Reservation reservation)
        {
            try
            {
                string query = @"INSERT INTO reservations (ReservationID, CustomerID, CustomerName, ContactPhone, ReservationDate, ReservationTime, NumberOfGuests, TableID, RoomID, Duration, ReservationStatus, SpecialRequests, DepositAmount, CreatedAt, UpdatedAt)
                                 VALUES (@ReservationID, @CustomerID, @CustomerName, @ContactPhone, @ReservationDate, @ReservationTime, @NumberOfGuests, @TableID, @RoomID, @Duration, @ReservationStatus, @SpecialRequests, @DepositAmount, @CreatedAt, @UpdatedAt)";

                MySqlParameter[] parameters =
                {
                    new MySqlParameter("@ReservationID", reservation.ReservationID),
                    new MySqlParameter("@CustomerID", (object)reservation.CustomerID ?? DBNull.Value),
                    new MySqlParameter("@CustomerName", (object)reservation.CustomerName ?? DBNull.Value),
                    new MySqlParameter("@ContactPhone", (object)reservation.ContactPhone ?? DBNull.Value),
                    new MySqlParameter("@ReservationDate", reservation.ReservationDate),
                    new MySqlParameter("@ReservationTime", reservation.ReservationTime),
                    new MySqlParameter("@NumberOfGuests", reservation.NumberOfGuests),
                    new MySqlParameter("@TableID", (object)reservation.TableID ?? DBNull.Value),
                    new MySqlParameter("@RoomID", (object)reservation.RoomID ?? DBNull.Value),
                    new MySqlParameter("@Duration", (object)reservation.Duration ?? DBNull.Value),
                    new MySqlParameter("@ReservationStatus", reservation.ReservationStatus.ToString()),
                    new MySqlParameter("@SpecialRequests", (object)reservation.SpecialRequests ?? DBNull.Value),
                    new MySqlParameter("@DepositAmount", (object)reservation.DepositAmount ?? DBNull.Value),
                    new MySqlParameter("@CreatedAt", reservation.CreatedAt),
                    new MySqlParameter("@UpdatedAt", reservation.UpdatedAt)
                };

                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"L?i khi thêm ??t ch?: {ex.Message}");
            }
        }

        public bool Update(Reservation reservation)
        {
            try
            {
                string query = @"UPDATE reservations SET CustomerID = @CustomerID, CustomerName = @CustomerName, ContactPhone = @ContactPhone, ReservationDate = @ReservationDate, ReservationTime = @ReservationTime, NumberOfGuests = @NumberOfGuests, TableID = @TableID, RoomID = @RoomID, Duration = @Duration, ReservationStatus = @ReservationStatus, SpecialRequests = @SpecialRequests, DepositAmount = @DepositAmount, UpdatedAt = @UpdatedAt
                                 WHERE ReservationID = @ReservationID AND DeletedAt IS NULL";

                MySqlParameter[] parameters =
                {
                    new MySqlParameter("@ReservationID", reservation.ReservationID),
                    new MySqlParameter("@CustomerID", (object)reservation.CustomerID ?? DBNull.Value),
                    new MySqlParameter("@CustomerName", (object)reservation.CustomerName ?? DBNull.Value),
                    new MySqlParameter("@ContactPhone", (object)reservation.ContactPhone ?? DBNull.Value),
                    new MySqlParameter("@ReservationDate", reservation.ReservationDate),
                    new MySqlParameter("@ReservationTime", reservation.ReservationTime),
                    new MySqlParameter("@NumberOfGuests", reservation.NumberOfGuests),
                    new MySqlParameter("@TableID", (object)reservation.TableID ?? DBNull.Value),
                    new MySqlParameter("@RoomID", (object)reservation.RoomID ?? DBNull.Value),
                    new MySqlParameter("@Duration", (object)reservation.Duration ?? DBNull.Value),
                    new MySqlParameter("@ReservationStatus", reservation.ReservationStatus.ToString()),
                    new MySqlParameter("@SpecialRequests", (object)reservation.SpecialRequests ?? DBNull.Value),
                    new MySqlParameter("@DepositAmount", (object)reservation.DepositAmount ?? DBNull.Value),
                    new MySqlParameter("@UpdatedAt", reservation.UpdatedAt)
                };

                int result = dbHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"L?i khi c?p nh?t ??t ch?: {ex.Message}");
            }
        }

        public bool Delete(string id)
        {
            try
            {
                string query = "UPDATE reservations SET DeletedAt = @DeletedAt WHERE ReservationID = @id";
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
                throw new Exception($"L?i khi xóa ??t ch?: {ex.Message}");
            }
        }

        public bool Exists(string id)
        {
            string query = "SELECT COUNT(*) FROM reservations WHERE ReservationID = @id AND DeletedAt IS NULL";
            MySqlParameter[] parameters = { new MySqlParameter("@id", id) };
            int count = Convert.ToInt32(dbHelper.ExecuteScalar(query, parameters));
            return count > 0;
        }

        public List<Reservation> SearchReservations(string searchTerm)
        {
            string query = "SELECT * FROM reservations WHERE DeletedAt IS NULL";
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query += " AND (CustomerName LIKE @search OR ContactPhone LIKE @search)";
                parameters.Add(new MySqlParameter("@search", $"%{searchTerm}%"));
            }

            query += " ORDER BY ReservationDate, ReservationTime";

            DataTable dt = dbHelper.ExecuteQuery(query, parameters.ToArray());
            return ConvertDataTableToList(dt);
        }

        private List<Reservation> ConvertDataTableToList(DataTable dt)
        {
            List<Reservation> list = new List<Reservation>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapDataRowToEntity(row));
            }
            return list;
        }
    }
}

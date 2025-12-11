using HuongViet.DAL;
using HuongViet.Models;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace HuongViet.BLL
{
    public class ReservationBLL
    {
        private readonly ReservationDAL reservationDAL;
        private readonly CustomerDAL customerDAL;

        public ReservationBLL()
        {
            reservationDAL = new ReservationDAL();
            customerDAL = new CustomerDAL();
        }

        public List<Reservation> GetAll()
        {
            try
            {
                return reservationDAL.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception($"L?i khi l?y danh sách ??t ch?: {ex.Message}");
            }
        }

        public Reservation GetById(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id))
                    throw new ArgumentException("Mã ??t ch? không ???c ?? tr?ng");

                return reservationDAL.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"L?i khi l?y ??t ch?: {ex.Message}");
            }
        }

        public bool Insert(Reservation reservation)
        {
            try
            {
                ValidateReservation(reservation);

                // If customerId provided, ensure customer exists
                if (!string.IsNullOrWhiteSpace(reservation.CustomerID) && !customerDAL.Exists(reservation.CustomerID))
                {
                    throw new Exception("Khách hàng không t?n t?i");
                }

                // Generate ReservationID if empty
                if (string.IsNullOrWhiteSpace(reservation.ReservationID))
                {
                    reservation.ReservationID = GenerateNewReservationID();
                }

                reservation.CreatedAt = DateTime.Now;
                reservation.UpdatedAt = DateTime.Now;

                return reservationDAL.Insert(reservation);
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
                if (string.IsNullOrWhiteSpace(reservation.ReservationID))
                    throw new ArgumentException("Mã ??t ch? không ???c ?? tr?ng");

                ValidateReservation(reservation);

                reservation.UpdatedAt = DateTime.Now;
                return reservationDAL.Update(reservation);
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
                if (string.IsNullOrWhiteSpace(id))
                    throw new ArgumentException("Mã ??t ch? không ???c ?? tr?ng");

                if (!reservationDAL.Exists(id))
                    throw new Exception("??t ch? không t?n t?i");

                return reservationDAL.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"L?i khi xóa ??t ch?: {ex.Message}");
            }
        }

        public List<Reservation> Search(string term)
        {
            try
            {
                return reservationDAL.SearchReservations(term);
            }
            catch (Exception ex)
            {
                throw new Exception($"L?i khi tìm ??t ch?: {ex.Message}");
            }
        }

        public string GenerateNewReservationID()
        {
            var reservations = reservationDAL.GetAll();
            int max = 0;
            foreach (var r in reservations)
            {
                if (r.ReservationID != null && r.ReservationID.StartsWith("RES"))
                {
                    string numPart = r.ReservationID.Substring(3);
                    if (int.TryParse(numPart, out int n)) max = Math.Max(max, n);
                }
            }
            return $"RES{(max + 1).ToString("D8")}";
        }

        private void ValidateReservation(Reservation reservation)
        {
            if (reservation == null)
                throw new ArgumentNullException(nameof(reservation));

            if (string.IsNullOrWhiteSpace(reservation.CustomerName) && string.IsNullOrWhiteSpace(reservation.CustomerID))
                throw new ArgumentException("Ph?i cung c?p tên khách ho?c mã khách");

            if (!string.IsNullOrWhiteSpace(reservation.ContactPhone) && reservation.ContactPhone.Length > 15)
                throw new ArgumentException("S? ?i?n tho?i không ???c v??t quá 15 ký t?");

            if (reservation.NumberOfGuests < 1)
                throw new ArgumentException("S? khách ph?i l?n h?n 0");

            // Date/time checks
            if (reservation.ReservationDate == DateTime.MinValue)
                throw new ArgumentException("Ngày ??t ch? không h?p l?");

            // Validate reservation time range
            if (reservation.ReservationTime < TimeSpan.Zero || reservation.ReservationTime > new TimeSpan(23,59,59))
                throw new ArgumentException("Th?i gian ??t ch? không h?p l?");

            if (reservation.Duration.HasValue && reservation.Duration <= 0)
                throw new ArgumentException("Th?i l??ng ph?i l?n h?n 0 n?u ???c ch? ??nh");

            if (reservation.DepositAmount.HasValue && reservation.DepositAmount < 0)
                throw new ArgumentException("S? ti?n ??t c?c không th? âm");
        }
    }
}

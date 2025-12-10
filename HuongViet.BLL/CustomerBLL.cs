using HuongViet.DAL;
using HuongViet.Models;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace HuongViet.BLL
{
    public class CustomerBLL
    {
        private readonly CustomerDAL customerDAL;

        public CustomerBLL()
        {
            this.customerDAL = new CustomerDAL();
        }

        public List<Customer> GetAll()
        {
            try
            {
                return customerDAL.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách khách hàng: {ex.Message}");
            }
        }

        public Customer GetById(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id))
                {
                    throw new ArgumentException("Mã khách hàng không được để trống");
                }

                return customerDAL.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy thông tin khách hàng: {ex.Message}");
            }
        }

        public Customer GetByPhoneNumber(string phoneNumber)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(phoneNumber))
                {
                    throw new ArgumentException("Số điện thoại không được để trống");
                }

                return customerDAL.GetByPhoneNumber(phoneNumber);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tìm khách hàng theo số điện thoại: {ex.Message}");
            }
        }

        public List<Customer> SearchByName(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    return GetAll();
                }

                return customerDAL.SearchByName(name);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tìm kiếm khách hàng: {ex.Message}");
            }
        }

        public bool Insert(Customer customer)
        {
            try
            {
                ValidateCustomer(customer);

                // Check if ID already exists
                if (customerDAL.Exists(customer.CustomerID))
                {
                    throw new Exception("Mã khách hàng đã tồn tại");
                }

                // Check if phone number already exists
                if (customerDAL.IsPhoneNumberExists(customer.CustomerPhoneNum))
                {
                    throw new Exception("Số điện thoại đã được sử dụng");
                }

                return customerDAL.Insert(customer);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm khách hàng: {ex.Message}");
            }
        }

        public bool Update(Customer customer)
        {
            try
            {
                ValidateCustomer(customer);

                // Check if customer exists
                if (!customerDAL.Exists(customer.CustomerID))
                {
                    throw new Exception("Khách hàng không tồn tại");
                }

                // Check if phone number already exists (exclude current customer)
                if (customerDAL.IsPhoneNumberExists(customer.CustomerPhoneNum, customer.CustomerID))
                {
                    throw new Exception("Số điện thoại đã được sử dụng");
                }

                return customerDAL.Update(customer);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật khách hàng: {ex.Message}");
            }
        }

        public bool Delete(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id))
                {
                    throw new ArgumentException("Mã khách hàng không được để trống");
                }

                if (!customerDAL.Exists(id))
                {
                    throw new Exception("Khách hàng không tồn tại");
                }

                return customerDAL.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa khách hàng: {ex.Message}");
            }
        }

        public bool Exists(string id)
        {
            try
            {
                return customerDAL.Exists(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi kiểm tra khách hàng: {ex.Message}");
            }
        }

        public string GenerateNewCustomerID()
        {
            try
            {
                var customers = customerDAL.GetAll();
                int maxNumber = 0;

                foreach (var customer in customers)
                {
                    if (customer.CustomerID.StartsWith("CUST"))
                    {
                        string numberPart = customer.CustomerID.Substring(4);
                        if (int.TryParse(numberPart, out int number))
                        {
                            maxNumber = Math.Max(maxNumber, number);
                        }
                    }
                }

                return $"CUST{(maxNumber + 1).ToString("D6")}";
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tạo mã khách hàng: {ex.Message}");
            }
        }

        public PagedResult<Customer> SearchCustomers(SearchCriteria criteria)
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

                return customerDAL.SearchCustomers(criteria);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tìm kiếm khách hàng: {ex.Message}");
            }
        }

        private void ValidateCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer), "Thông tin khách hàng không được null");
            }

            if (string.IsNullOrWhiteSpace(customer.CustomerID))
            {
                throw new ArgumentException("Mã khách hàng không được để trống");
            }

            if (string.IsNullOrWhiteSpace(customer.CustomerName))
            {
                throw new ArgumentException("Tên khách hàng không được để trống");
            }

            if (customer.CustomerName.Length > 50)
            {
                throw new ArgumentException("Tên khách hàng không được vượt quá 50 ký tự");
            }

            if (string.IsNullOrWhiteSpace(customer.CustomerPhoneNum))
            {
                throw new ArgumentException("Số điện thoại không được để trống");
            }

            if (customer.CustomerPhoneNum.Length > 15)
            {
                throw new ArgumentException("Số điện thoại không được vượt quá 15 ký tự");
            }

            // Validate phone number format (Vietnamese phone number)
            if (!IsValidPhoneNumber(customer.CustomerPhoneNum))
            {
                throw new ArgumentException("Số điện thoại không đúng định dạng");
            }

            // Validate email if provided
            if (!string.IsNullOrWhiteSpace(customer.CustomerEmail))
            {
                if (customer.CustomerEmail.Length > 100)
                {
                    throw new ArgumentException("Email không được vượt quá 100 ký tự");
                }

                if (!IsValidEmail(customer.CustomerEmail))
                {
                    throw new ArgumentException("Email không đúng định dạng");
                }
            }

            // Validate date of birth if provided
            if (customer.CustomerDOB.HasValue)
            {
                if (customer.CustomerDOB.Value > DateTime.Now)
                {
                    throw new ArgumentException("Ngày sinh không được lớn hơn ngày hiện tại");
                }

                if (customer.CustomerDOB.Value < DateTime.Now.AddYears(-150))
                {
                    throw new ArgumentException("Ngày sinh không hợp lệ");
                }
            }
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // Vietnamese phone number pattern
            // Mobile: 09x, 08x, 07x, 05x, 03x (10 digits)
            // Landline: 02x (10-11 digits)
            string pattern = @"^(0[3-9]\d{8,9})$";
            return Regex.IsMatch(phoneNumber, pattern);
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Tạo khách hàng nhanh từ thông tin đơn hàng
        /// </summary>
        public Customer CreateQuickCustomer(string customerName, string customerPhone)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(customerName))
                {
                    throw new ArgumentException("Tên khách hàng không được để trống");
                }

                if (string.IsNullOrWhiteSpace(customerPhone))
                {
                    throw new ArgumentException("Số điện thoại không được để trống");
                }

                // Kiểm tra xem khách hàng đã tồn tại chưa
                var existingCustomer = GetByPhoneNumber(customerPhone);
                if (existingCustomer != null)
                {
                    return existingCustomer;
                }

                // Tạo khách hàng mới
                var newCustomer = new Customer
                {
                    CustomerID = GenerateNewCustomerID(),
                    CustomerName = customerName,
                    CustomerPhoneNum = customerPhone,
                    CusAssignDate = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                if (Insert(newCustomer))
                {
                    return newCustomer;
                }

                throw new Exception("Không thể tạo khách hàng mới");
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tạo khách hàng nhanh: {ex.Message}");
            }
        }
    }
}

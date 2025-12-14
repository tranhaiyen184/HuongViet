using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HuongViet.BLL;
using HuongViet.Models;

namespace HuongViet.GUI
{
    public partial class FrmCreateCustomer : Form
    {
        private readonly CustomerBLL customerBLL;
        public Customer CreatedCustomer { get; private set; }

        public FrmCreateCustomer()
        {
            InitializeComponent();
            customerBLL = new CustomerBLL();
        }

        private void FrmCreateCustomer_Load(object sender, EventArgs e)
        {
            // Generate and display customer ID
            try
            {
                txtCustomerID.Text = customerBLL.GenerateNewCustomerID();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo mã khách hàng: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Set default date of birth to 20 years ago
            dtpCustomerDOB.Value = DateTime.Now.AddYears(-20);
            dtpCustomerDOB.Checked = false; // Make it optional
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate required fields
                if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên khách hàng.", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCustomerName.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtCustomerPhoneNum.Text))
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại.", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCustomerPhoneNum.Focus();
                    return;
                }

                // Create customer object
                var customer = new Customer
                {
                    CustomerID = txtCustomerID.Text,
                    CustomerName = txtCustomerName.Text.Trim(),
                    CustomerPhoneNum = txtCustomerPhoneNum.Text.Trim(),
                    CustomerEmail = string.IsNullOrWhiteSpace(txtCustomerEmail.Text) 
                        ? null 
                        : txtCustomerEmail.Text.Trim(),
                    CustomerDOB = dtpCustomerDOB.Checked ? dtpCustomerDOB.Value : (DateTime?)null,
                    CusAssignDate = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                // Insert customer
                bool success = customerBLL.Insert(customer);
                
                if (success)
                {
                    CreatedCustomer = customer;
                    MessageBox.Show("Tạo khách hàng mới thành công!", "Thành công", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không thể tạo khách hàng mới.", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo khách hàng: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

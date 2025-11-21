using System;
using System.Drawing;
using System.Windows.Forms;
using HuongViet.BLL;
using HuongViet.Models;

namespace HuongViet.GUI
{
    public partial class FrmLogin : Form
    {
        private readonly AuthBLL authBLL;
        public User LoggedInUser { get; private set; }

        public FrmLogin()
        {
            InitializeComponent();
            authBLL = new AuthBLL();
            SetupForm();
        }


        private void SetupForm()
        {
            // Set default focus
            txtUsername.Focus();
            
            // Enable Enter key for login
            AcceptButton = btnLogin;
            
            // Set password character
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input
                string validationError = authBLL.ValidateLoginInfo(txtUsername.Text, txtPassword.Text);
                if (!string.IsNullOrEmpty(validationError))
                {
                    MessageBox.Show(validationError, "Thông tin không hợp lệ", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Disable button to prevent multiple clicks
                btnLogin.Enabled = false;
                btnLogin.Text = "...";
                Application.DoEvents();

                // Attempt login
                User user = authBLL.Login(txtUsername.Text, txtPassword.Text);
                
                if (user != null)
                {
                    LoggedInUser = user;
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", 
                        "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    // Clear password and focus username
                    txtPassword.Clear();
                    txtUsername.Focus();
                    txtUsername.SelectAll();
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi đăng nhập", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Clear();
                txtUsername.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi đăng nhập: {ex.Message}", 
                    "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Re-enable button
                btnLogin.Enabled = true;
                btnLogin.Text = "Đăng nhập";
            }
        }

        private void lnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(
                "Vui lòng liên hệ quản trị viên để được hỗ trợ đặt lại mật khẩu.",
                "Quên mật khẩu",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void formLayout_Paint(object sender, PaintEventArgs e)
        {

        }

		private void FrmLogin_Load(object sender, EventArgs e)
		{

		}

		private void pictureLogo_Click(object sender, EventArgs e)
		{

		}
	}
}


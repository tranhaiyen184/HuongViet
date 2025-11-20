namespace HuongViet.GUI
{
    partial class FrmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.logoPanel = new System.Windows.Forms.Panel();
            this.pictureLogo = new System.Windows.Forms.PictureBox();
            this.formPanel = new System.Windows.Forms.Panel();
            this.formLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lnkForgotPassword = new System.Windows.Forms.LinkLabel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.mainLayout.SuspendLayout();
            this.logoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).BeginInit();
            this.formPanel.SuspendLayout();
            this.formLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 2;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58F));
            this.mainLayout.Controls.Add(this.logoPanel, 0, 0);
            this.mainLayout.Controls.Add(this.formPanel, 1, 0);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 1;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Size = new System.Drawing.Size(720, 439);
            this.mainLayout.TabIndex = 0;
            // 
            // logoPanel
            // 
            this.logoPanel.Controls.Add(this.pictureLogo);
            this.logoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logoPanel.Location = new System.Drawing.Point(0, 0);
            this.logoPanel.Margin = new System.Windows.Forms.Padding(0);
            this.logoPanel.Name = "logoPanel";
            this.logoPanel.Size = new System.Drawing.Size(302, 439);
            this.logoPanel.TabIndex = 0;
            // 
            // pictureLogo
            // 
            this.pictureLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureLogo.Image = global::HuongViet.GUI.Properties.Resources.huong_viet_logo_no_bg;
            this.pictureLogo.Location = new System.Drawing.Point(0, 0);
            this.pictureLogo.Margin = new System.Windows.Forms.Padding(18, 20, 18, 20);
            this.pictureLogo.Name = "pictureLogo";
            this.pictureLogo.Padding = new System.Windows.Forms.Padding(36, 39, 36, 39);
            this.pictureLogo.Size = new System.Drawing.Size(302, 439);
            this.pictureLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureLogo.TabIndex = 0;
            this.pictureLogo.TabStop = false;
            // 
            // formPanel
            // 
            this.formPanel.Controls.Add(this.formLayout);
            this.formPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formPanel.Location = new System.Drawing.Point(302, 0);
            this.formPanel.Margin = new System.Windows.Forms.Padding(0);
            this.formPanel.Name = "formPanel";
            this.formPanel.Padding = new System.Windows.Forms.Padding(48, 39, 48, 39);
            this.formPanel.Size = new System.Drawing.Size(418, 439);
            this.formPanel.TabIndex = 1;
            // 
            // formLayout
            // 
            this.formLayout.ColumnCount = 1;
            this.formLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.formLayout.Controls.Add(this.lblWelcome, 0, 0);
            this.formLayout.Controls.Add(this.lblTitle, 0, 1);
            this.formLayout.Controls.Add(this.lblUsername, 0, 2);
            this.formLayout.Controls.Add(this.txtUsername, 0, 3);
            this.formLayout.Controls.Add(this.lblPassword, 0, 4);
            this.formLayout.Controls.Add(this.txtPassword, 0, 5);
            this.formLayout.Controls.Add(this.lnkForgotPassword, 0, 6);
            this.formLayout.Controls.Add(this.btnLogin, 0, 7);
            this.formLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formLayout.Location = new System.Drawing.Point(48, 39);
            this.formLayout.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.formLayout.Name = "formLayout";
            this.formLayout.RowCount = 8;
            this.formLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.formLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.formLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.formLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.formLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.formLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.formLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.formLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.formLayout.Size = new System.Drawing.Size(322, 361);
            this.formLayout.TabIndex = 0;
            this.formLayout.Paint += new System.Windows.Forms.PaintEventHandler(this.formLayout_Paint);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblWelcome.ForeColor = System.Drawing.Color.DimGray;
            this.lblWelcome.Location = new System.Drawing.Point(0, 0);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(158, 20);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Chào mừng bạn trở lại";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(0, 23);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0, 0, 0, 26);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(181, 45);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Đăng nhập";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblUsername.ForeColor = System.Drawing.Color.DimGray;
            this.lblUsername.Location = new System.Drawing.Point(0, 94);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(66, 19);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "Tài khoản";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(0, 116);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(0, 0, 0, 13);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(322, 20);
            this.txtUsername.TabIndex = 3;
            this.txtUsername.Text = "admin";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPassword.ForeColor = System.Drawing.Color.DimGray;
            this.lblPassword.Location = new System.Drawing.Point(0, 149);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(68, 19);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Mật khẩu";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(0, 171);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '•';
            this.txtPassword.Size = new System.Drawing.Size(322, 20);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.Text = "Admin@123";
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lnkForgotPassword
            // 
            this.lnkForgotPassword.AutoSize = true;
            this.lnkForgotPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lnkForgotPassword.Location = new System.Drawing.Point(0, 197);
            this.lnkForgotPassword.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.lnkForgotPassword.Name = "lnkForgotPassword";
            this.lnkForgotPassword.Size = new System.Drawing.Size(105, 19);
            this.lnkForgotPassword.TabIndex = 6;
            this.lnkForgotPassword.TabStop = true;
            this.lnkForgotPassword.Text = "Quên mật khẩu";
            this.lnkForgotPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkForgotPassword_LinkClicked);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(0, 236);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(0);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(135, 36);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // FrmLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 439);
            this.Controls.Add(this.mainLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.mainLayout.ResumeLayout(false);
            this.logoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).EndInit();
            this.formPanel.ResumeLayout(false);
            this.formLayout.ResumeLayout(false);
            this.formLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.Panel logoPanel;
        private System.Windows.Forms.PictureBox pictureLogo;
        private System.Windows.Forms.Panel formPanel;
        private System.Windows.Forms.TableLayoutPanel formLayout;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.LinkLabel lnkForgotPassword;
        private System.Windows.Forms.Button btnLogin;
    }
}


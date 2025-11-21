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
			this.lblUsername = new System.Windows.Forms.Label();
			this.txtUsername = new System.Windows.Forms.TextBox();
			this.lblPassword = new System.Windows.Forms.Label();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.lnkForgotPassword = new System.Windows.Forms.LinkLabel();
			this.btnLogin = new System.Windows.Forms.Button();
			this.lblTitle = new System.Windows.Forms.Label();
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
			this.mainLayout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.mainLayout.Name = "mainLayout";
			this.mainLayout.RowCount = 1;
			this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.mainLayout.Size = new System.Drawing.Size(1112, 540);
			this.mainLayout.TabIndex = 0;
			// 
			// logoPanel
			// 
			this.logoPanel.Controls.Add(this.pictureLogo);
			this.logoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.logoPanel.Location = new System.Drawing.Point(0, 0);
			this.logoPanel.Margin = new System.Windows.Forms.Padding(0);
			this.logoPanel.Name = "logoPanel";
			this.logoPanel.Size = new System.Drawing.Size(467, 540);
			this.logoPanel.TabIndex = 0;
			// 
			// pictureLogo
			// 
			this.pictureLogo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureLogo.Location = new System.Drawing.Point(0, 0);
			this.pictureLogo.Margin = new System.Windows.Forms.Padding(24, 25, 24, 25);
			this.pictureLogo.Name = "pictureLogo";
			this.pictureLogo.Padding = new System.Windows.Forms.Padding(48);
			this.pictureLogo.Size = new System.Drawing.Size(467, 540);
			this.pictureLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pictureLogo.TabIndex = 0;
			this.pictureLogo.TabStop = false;
			this.pictureLogo.Click += new System.EventHandler(this.pictureLogo_Click);
			// 
			// formPanel
			// 
			this.formPanel.Controls.Add(this.formLayout);
			this.formPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.formPanel.Location = new System.Drawing.Point(467, 0);
			this.formPanel.Margin = new System.Windows.Forms.Padding(0);
			this.formPanel.Name = "formPanel";
			this.formPanel.Padding = new System.Windows.Forms.Padding(64, 48, 64, 48);
			this.formPanel.Size = new System.Drawing.Size(645, 540);
			this.formPanel.TabIndex = 1;
			// 
			// formLayout
			// 
			this.formLayout.ColumnCount = 1;
			this.formLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.formLayout.Controls.Add(this.lblUsername, 0, 2);
			this.formLayout.Controls.Add(this.txtUsername, 0, 3);
			this.formLayout.Controls.Add(this.lblPassword, 0, 4);
			this.formLayout.Controls.Add(this.txtPassword, 0, 5);
			this.formLayout.Controls.Add(this.lnkForgotPassword, 0, 6);
			this.formLayout.Controls.Add(this.btnLogin, 0, 7);
			this.formLayout.Controls.Add(this.lblTitle, 0, 1);
			this.formLayout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.formLayout.Location = new System.Drawing.Point(64, 48);
			this.formLayout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.formLayout.Name = "formLayout";
			this.formLayout.RowCount = 8;
			this.formLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.formLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.formLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.formLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.formLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.formLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.formLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.formLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.formLayout.Size = new System.Drawing.Size(517, 444);
			this.formLayout.TabIndex = 0;
			this.formLayout.Paint += new System.Windows.Forms.PaintEventHandler(this.formLayout_Paint);
			// 
			// lblUsername
			// 
			this.lblUsername.AutoSize = true;
			this.lblUsername.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblUsername.ForeColor = System.Drawing.Color.DimGray;
			this.lblUsername.Location = new System.Drawing.Point(0, 77);
			this.lblUsername.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.lblUsername.Name = "lblUsername";
			this.lblUsername.Size = new System.Drawing.Size(88, 22);
			this.lblUsername.TabIndex = 2;
			this.lblUsername.Text = "Tài khoản";
			// 
			// txtUsername
			// 
			this.txtUsername.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtUsername.Location = new System.Drawing.Point(0, 103);
			this.txtUsername.Margin = new System.Windows.Forms.Padding(0, 0, 0, 16);
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.Size = new System.Drawing.Size(428, 30);
			this.txtUsername.TabIndex = 3;
			this.txtUsername.Text = "admin";
			// 
			// lblPassword
			// 
			this.lblPassword.AutoSize = true;
			this.lblPassword.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPassword.ForeColor = System.Drawing.Color.DimGray;
			this.lblPassword.Location = new System.Drawing.Point(0, 149);
			this.lblPassword.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.lblPassword.Name = "lblPassword";
			this.lblPassword.Size = new System.Drawing.Size(82, 22);
			this.lblPassword.TabIndex = 4;
			this.lblPassword.Text = "Mật khẩu";
			// 
			// txtPassword
			// 
			this.txtPassword.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtPassword.Location = new System.Drawing.Point(0, 175);
			this.txtPassword.Margin = new System.Windows.Forms.Padding(0, 0, 0, 7);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '•';
			this.txtPassword.Size = new System.Drawing.Size(428, 30);
			this.txtPassword.TabIndex = 5;
			this.txtPassword.Text = "Admin@123";
			this.txtPassword.UseSystemPasswordChar = true;
			// 
			// lnkForgotPassword
			// 
			this.lnkForgotPassword.AutoSize = true;
			this.lnkForgotPassword.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lnkForgotPassword.Location = new System.Drawing.Point(0, 212);
			this.lnkForgotPassword.Margin = new System.Windows.Forms.Padding(0, 0, 0, 25);
			this.lnkForgotPassword.Name = "lnkForgotPassword";
			this.lnkForgotPassword.Size = new System.Drawing.Size(109, 19);
			this.lnkForgotPassword.TabIndex = 6;
			this.lnkForgotPassword.TabStop = true;
			this.lnkForgotPassword.Text = "Quên mật khẩu";
			this.lnkForgotPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkForgotPassword_LinkClicked);
			// 
			// btnLogin
			// 
			this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnLogin.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnLogin.Location = new System.Drawing.Point(168, 328);
			this.btnLogin.Margin = new System.Windows.Forms.Padding(0);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(180, 44);
			this.btnLogin.TabIndex = 7;
			this.btnLogin.Text = "Đăng nhập";
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitle.ForeColor = System.Drawing.Color.Black;
			this.lblTitle.Location = new System.Drawing.Point(0, 0);
			this.lblTitle.Margin = new System.Windows.Forms.Padding(0, 0, 0, 32);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(517, 45);
			this.lblTitle.TabIndex = 1;
			this.lblTitle.Text = "ĐĂNG NHẬP";
			this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// FrmLogin
			// 
			this.AcceptButton = this.btnLogin;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1112, 540);
			this.Controls.Add(this.mainLayout);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
		private System.Windows.Forms.Label lblUsername;
		private System.Windows.Forms.TextBox txtUsername;
		private System.Windows.Forms.Label lblPassword;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.LinkLabel lnkForgotPassword;
		private System.Windows.Forms.Button btnLogin;
		private System.Windows.Forms.Label lblTitle;
	}
}


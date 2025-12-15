namespace HuongViet.GUI
{
    partial class Form1
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
            this.pnlBackup = new System.Windows.Forms.Panel();
            this.picBackup = new System.Windows.Forms.PictureBox();
            this.lblBackupTitle = new System.Windows.Forms.Label();
            this.lblBackupDesc = new System.Windows.Forms.Label();
            this.btnBackup = new System.Windows.Forms.Button();
            this.pnlRestore = new System.Windows.Forms.Panel();
            this.picRestore = new System.Windows.Forms.PictureBox();
            this.lblRestoreTitle = new System.Windows.Forms.Label();
            this.lblRestoreDesc = new System.Windows.Forms.Label();
            this.btnRestore = new System.Windows.Forms.Button();
            this.lblBackupList = new System.Windows.Forms.Label();
            this.dgvBackupFiles = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlBackup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBackup)).BeginInit();
            this.pnlRestore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRestore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBackupFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBackup
            // 
            this.pnlBackup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBackup.Controls.Add(this.picBackup);
            this.pnlBackup.Controls.Add(this.lblBackupTitle);
            this.pnlBackup.Controls.Add(this.lblBackupDesc);
            this.pnlBackup.Controls.Add(this.btnBackup);
            this.pnlBackup.Location = new System.Drawing.Point(40, 40);
            this.pnlBackup.Name = "pnlBackup";
            this.pnlBackup.Size = new System.Drawing.Size(495, 308);
            this.pnlBackup.TabIndex = 0;
            // 
            // picBackup
            // 
            this.picBackup.Location = new System.Drawing.Point(20, 20);
            this.picBackup.Name = "picBackup";
            this.picBackup.Size = new System.Drawing.Size(48, 48);
            this.picBackup.TabIndex = 0;
            this.picBackup.TabStop = false;
            // 
            // lblBackupTitle
            // 
            this.lblBackupTitle.AutoSize = true;
            this.lblBackupTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBackupTitle.Location = new System.Drawing.Point(85, 20);
            this.lblBackupTitle.Name = "lblBackupTitle";
            this.lblBackupTitle.Size = new System.Drawing.Size(159, 25);
            this.lblBackupTitle.TabIndex = 1;
            this.lblBackupTitle.Text = "Sao lưu Dữ liệu";
            // 
            // lblBackupDesc
            // 
            this.lblBackupDesc.AutoSize = true;
            this.lblBackupDesc.Location = new System.Drawing.Point(87, 108);
            this.lblBackupDesc.Name = "lblBackupDesc";
            this.lblBackupDesc.Size = new System.Drawing.Size(270, 32);
            this.lblBackupDesc.TabIndex = 2;
            this.lblBackupDesc.Text = "Tạo bản sao lưu dữ liệu hiện tại của hệ thống\r\nđể phục vụ khôi phục sau này.";
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(20, 236);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(457, 45);
            this.btnBackup.TabIndex = 3;
            this.btnBackup.Text = "Thực hiện Sao lưu";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // pnlRestore
            // 
            this.pnlRestore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRestore.Controls.Add(this.picRestore);
            this.pnlRestore.Controls.Add(this.lblRestoreTitle);
            this.pnlRestore.Controls.Add(this.lblRestoreDesc);
            this.pnlRestore.Controls.Add(this.btnRestore);
            this.pnlRestore.Location = new System.Drawing.Point(576, 40);
            this.pnlRestore.Name = "pnlRestore";
            this.pnlRestore.Size = new System.Drawing.Size(494, 308);
            this.pnlRestore.TabIndex = 1;
            // 
            // picRestore
            // 
            this.picRestore.Location = new System.Drawing.Point(20, 20);
            this.picRestore.Name = "picRestore";
            this.picRestore.Size = new System.Drawing.Size(48, 48);
            this.picRestore.TabIndex = 0;
            this.picRestore.TabStop = false;
            // 
            // lblRestoreTitle
            // 
            this.lblRestoreTitle.AutoSize = true;
            this.lblRestoreTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRestoreTitle.Location = new System.Drawing.Point(85, 20);
            this.lblRestoreTitle.Name = "lblRestoreTitle";
            this.lblRestoreTitle.Size = new System.Drawing.Size(182, 25);
            this.lblRestoreTitle.TabIndex = 1;
            this.lblRestoreTitle.Text = "Khôi phục Dữ liệu";
            // 
            // lblRestoreDesc
            // 
            this.lblRestoreDesc.AutoSize = true;
            this.lblRestoreDesc.Location = new System.Drawing.Point(87, 108);
            this.lblRestoreDesc.Name = "lblRestoreDesc";
            this.lblRestoreDesc.Size = new System.Drawing.Size(244, 32);
            this.lblRestoreDesc.TabIndex = 2;
            this.lblRestoreDesc.Text = "Khôi phục dữ liệu từ file backup đã lưu trữ\r\nhoặc chọn file từ danh sách bên dưới" +
    ".";
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(20, 236);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(456, 45);
            this.btnRestore.TabIndex = 3;
            this.btnRestore.Text = "Thực hiện Khôi phục";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // lblBackupList
            // 
            this.lblBackupList.AutoSize = true;
            this.lblBackupList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBackupList.Location = new System.Drawing.Point(36, 421);
            this.lblBackupList.Name = "lblBackupList";
            this.lblBackupList.Size = new System.Drawing.Size(210, 20);
            this.lblBackupList.TabIndex = 2;
            this.lblBackupList.Text = "Danh sách File Backup:";
            // 
            // dgvBackupFiles
            // 
            this.dgvBackupFiles.AllowUserToAddRows = false;
            this.dgvBackupFiles.AllowUserToDeleteRows = false;
            this.dgvBackupFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBackupFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBackupFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBackupFiles.Location = new System.Drawing.Point(40, 511);
            this.dgvBackupFiles.MultiSelect = false;
            this.dgvBackupFiles.Name = "dgvBackupFiles";
            this.dgvBackupFiles.ReadOnly = true;
            this.dgvBackupFiles.RowHeadersWidth = 51;
            this.dgvBackupFiles.RowTemplate.Height = 24;
            this.dgvBackupFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBackupFiles.Size = new System.Drawing.Size(995, 178);
            this.dgvBackupFiles.TabIndex = 3;
            this.dgvBackupFiles.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBackupFiles_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 461);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(345, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Đúp chuột vào file backup tương ứng để khôi phục dữ liệu.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 761);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvBackupFiles);
            this.Controls.Add(this.lblBackupList);
            this.Controls.Add(this.pnlRestore);
            this.Controls.Add(this.pnlBackup);
            this.Name = "Form1";
            this.Text = "Quản lý Backup và Restore";
            this.pnlBackup.ResumeLayout(false);
            this.pnlBackup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBackup)).EndInit();
            this.pnlRestore.ResumeLayout(false);
            this.pnlRestore.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRestore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBackupFiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBackup;
        private System.Windows.Forms.PictureBox picBackup;
        private System.Windows.Forms.Label lblBackupTitle;
        private System.Windows.Forms.Label lblBackupDesc;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Panel pnlRestore;
        private System.Windows.Forms.PictureBox picRestore;
        private System.Windows.Forms.Label lblRestoreTitle;
        private System.Windows.Forms.Label lblRestoreDesc;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Label lblBackupList;
        private System.Windows.Forms.DataGridView dgvBackupFiles;
        private System.Windows.Forms.Label label1;
    }
}
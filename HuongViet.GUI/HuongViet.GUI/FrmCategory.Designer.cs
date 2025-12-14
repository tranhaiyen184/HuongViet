using FontAwesome.Sharp;

namespace HuongViet.GUI
{
    partial class FrmCategory
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.pnlMain = new System.Windows.Forms.Panel();
			this.pnlContent = new System.Windows.Forms.Panel();
			this.dgvCategories = new System.Windows.Forms.DataGridView();
			this.pnlForm = new System.Windows.Forms.Panel();
			this.grpCategoryInfo = new System.Windows.Forms.GroupBox();
			this.btnCancel = new FontAwesome.Sharp.IconButton();
			this.btnSave = new FontAwesome.Sharp.IconButton();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.lblDescription = new System.Windows.Forms.Label();
			this.txtCategoryName = new System.Windows.Forms.TextBox();
			this.lblCategoryName = new System.Windows.Forms.Label();
			this.pnlButtons = new System.Windows.Forms.Panel();
			this.btnDelete = new FontAwesome.Sharp.IconButton();
			this.btnEdit = new FontAwesome.Sharp.IconButton();
			this.btnAdd = new FontAwesome.Sharp.IconButton();
			this.pnlHeader = new System.Windows.Forms.Panel();
			this.pnlSearch = new System.Windows.Forms.Panel();
			this.lblSearch = new System.Windows.Forms.Label();
			this.btnRefresh = new FontAwesome.Sharp.IconButton();
			this.btnSearch = new FontAwesome.Sharp.IconButton();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.pnlMain.SuspendLayout();
			this.pnlContent.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();
			this.pnlForm.SuspendLayout();
			this.grpCategoryInfo.SuspendLayout();
			this.pnlButtons.SuspendLayout();
			this.pnlHeader.SuspendLayout();
			this.pnlSearch.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlMain
			// 
			this.pnlMain.Controls.Add(this.pnlContent);
			this.pnlMain.Controls.Add(this.pnlForm);
			this.pnlMain.Controls.Add(this.pnlHeader);
			this.pnlMain.Location = new System.Drawing.Point(0, 0);
			this.pnlMain.Margin = new System.Windows.Forms.Padding(4);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Size = new System.Drawing.Size(2022, 1081);
			this.pnlMain.TabIndex = 0;
			// 
			// pnlContent
			// 
			this.pnlContent.Controls.Add(this.dgvCategories);
			this.pnlContent.Location = new System.Drawing.Point(13, 85);
			this.pnlContent.Margin = new System.Windows.Forms.Padding(4);
			this.pnlContent.Name = "pnlContent";
			this.pnlContent.Size = new System.Drawing.Size(1311, 983);
			this.pnlContent.TabIndex = 2;
			// 
			// dgvCategories
			// 
			this.dgvCategories.AllowUserToAddRows = false;
			this.dgvCategories.AllowUserToDeleteRows = false;
			this.dgvCategories.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvCategories.BackgroundColor = System.Drawing.Color.White;
			this.dgvCategories.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dgvCategories.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvCategories.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 14F);
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightBlue;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvCategories.DefaultCellStyle = dataGridViewCellStyle2;
			this.dgvCategories.Location = new System.Drawing.Point(0, 4);
			this.dgvCategories.Margin = new System.Windows.Forms.Padding(4);
			this.dgvCategories.MultiSelect = false;
			this.dgvCategories.Name = "dgvCategories";
			this.dgvCategories.ReadOnly = true;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvCategories.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dgvCategories.RowHeadersVisible = false;
			this.dgvCategories.RowHeadersWidth = 51;
			this.dgvCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvCategories.Size = new System.Drawing.Size(1309, 930);
			this.dgvCategories.TabIndex = 0;
			this.dgvCategories.SelectionChanged += new System.EventHandler(this.dgvCategories_SelectionChanged);
			// 
			// pnlForm
			// 
			this.pnlForm.Controls.Add(this.grpCategoryInfo);
			this.pnlForm.Controls.Add(this.pnlButtons);
			this.pnlForm.Location = new System.Drawing.Point(1327, 85);
			this.pnlForm.Margin = new System.Windows.Forms.Padding(4);
			this.pnlForm.Name = "pnlForm";
			this.pnlForm.Size = new System.Drawing.Size(580, 938);
			this.pnlForm.TabIndex = 1;
			// 
			// grpCategoryInfo
			// 
			this.grpCategoryInfo.Controls.Add(this.btnCancel);
			this.grpCategoryInfo.Controls.Add(this.btnSave);
			this.grpCategoryInfo.Controls.Add(this.txtDescription);
			this.grpCategoryInfo.Controls.Add(this.lblDescription);
			this.grpCategoryInfo.Controls.Add(this.txtCategoryName);
			this.grpCategoryInfo.Controls.Add(this.lblCategoryName);
			this.grpCategoryInfo.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpCategoryInfo.Location = new System.Drawing.Point(4, 12);
			this.grpCategoryInfo.Margin = new System.Windows.Forms.Padding(4);
			this.grpCategoryInfo.Name = "grpCategoryInfo";
			this.grpCategoryInfo.Padding = new System.Windows.Forms.Padding(20, 18, 20, 18);
			this.grpCategoryInfo.Size = new System.Drawing.Size(572, 394);
			this.grpCategoryInfo.TabIndex = 1;
			this.grpCategoryInfo.TabStop = false;
			this.grpCategoryInfo.Text = "Thông tin danh mục";
			// 
			// btnCancel
			// 
			this.btnCancel.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnCancel.IconChar = FontAwesome.Sharp.IconChar.CircleXmark;
			this.btnCancel.IconColor = System.Drawing.Color.Black;
			this.btnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnCancel.IconSize = 20;
			this.btnCancel.Location = new System.Drawing.Point(194, 330);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
			this.btnCancel.Size = new System.Drawing.Size(168, 51);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Hủy";
			this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSave
			// 
			this.btnSave.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSave.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
			this.btnSave.IconColor = System.Drawing.Color.Black;
			this.btnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnSave.IconSize = 20;
			this.btnSave.Location = new System.Drawing.Point(383, 330);
			this.btnSave.Margin = new System.Windows.Forms.Padding(4);
			this.btnSave.Name = "btnSave";
			this.btnSave.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
			this.btnSave.Size = new System.Drawing.Size(168, 51);
			this.btnSave.TabIndex = 3;
			this.btnSave.Text = "Lưu";
			this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// txtDescription
			// 
			this.txtDescription.Font = new System.Drawing.Font("Times New Roman", 12F);
			this.txtDescription.Location = new System.Drawing.Point(24, 233);
			this.txtDescription.Margin = new System.Windows.Forms.Padding(4);
			this.txtDescription.MaxLength = 500;
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(524, 73);
			this.txtDescription.TabIndex = 3;
			// 
			// lblDescription
			// 
			this.lblDescription.AutoSize = true;
			this.lblDescription.Font = new System.Drawing.Font("Times New Roman", 14F);
			this.lblDescription.Location = new System.Drawing.Point(24, 181);
			this.lblDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(75, 27);
			this.lblDescription.TabIndex = 2;
			this.lblDescription.Text = "Mô tả:";
			// 
			// txtCategoryName
			// 
			this.txtCategoryName.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtCategoryName.Location = new System.Drawing.Point(24, 107);
			this.txtCategoryName.Margin = new System.Windows.Forms.Padding(4);
			this.txtCategoryName.MaxLength = 100;
			this.txtCategoryName.Name = "txtCategoryName";
			this.txtCategoryName.Size = new System.Drawing.Size(524, 38);
			this.txtCategoryName.TabIndex = 1;
			this.txtCategoryName.TextChanged += new System.EventHandler(this.txtCategoryName_TextChanged);
			// 
			// lblCategoryName
			// 
			this.lblCategoryName.AutoSize = true;
			this.lblCategoryName.Font = new System.Drawing.Font("Times New Roman", 14F);
			this.lblCategoryName.Location = new System.Drawing.Point(24, 59);
			this.lblCategoryName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblCategoryName.Name = "lblCategoryName";
			this.lblCategoryName.Size = new System.Drawing.Size(155, 27);
			this.lblCategoryName.TabIndex = 0;
			this.lblCategoryName.Text = "Tên danh mục:";
			// 
			// pnlButtons
			// 
			this.pnlButtons.Controls.Add(this.btnDelete);
			this.pnlButtons.Controls.Add(this.btnEdit);
			this.pnlButtons.Controls.Add(this.btnAdd);
			this.pnlButtons.Location = new System.Drawing.Point(13, 414);
			this.pnlButtons.Margin = new System.Windows.Forms.Padding(4);
			this.pnlButtons.Name = "pnlButtons";
			this.pnlButtons.Size = new System.Drawing.Size(563, 79);
			this.pnlButtons.TabIndex = 0;
			// 
			// btnDelete
			// 
			this.btnDelete.Font = new System.Drawing.Font("Times New Roman", 13.8F);
			this.btnDelete.IconChar = FontAwesome.Sharp.IconChar.Trash;
			this.btnDelete.IconColor = System.Drawing.Color.Black;
			this.btnDelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnDelete.IconSize = 20;
			this.btnDelete.Location = new System.Drawing.Point(400, 14);
			this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
			this.btnDelete.Size = new System.Drawing.Size(158, 48);
			this.btnDelete.TabIndex = 2;
			this.btnDelete.Text = "Xóa";
			this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Font = new System.Drawing.Font("Times New Roman", 13.8F);
			this.btnEdit.IconChar = FontAwesome.Sharp.IconChar.Edit;
			this.btnEdit.IconColor = System.Drawing.Color.Black;
			this.btnEdit.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnEdit.IconSize = 20;
			this.btnEdit.Location = new System.Drawing.Point(210, 14);
			this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
			this.btnEdit.Size = new System.Drawing.Size(158, 48);
			this.btnEdit.TabIndex = 1;
			this.btnEdit.Text = "Sửa";
			this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Font = new System.Drawing.Font("Times New Roman", 13.8F);
			this.btnAdd.IconChar = FontAwesome.Sharp.IconChar.Plus;
			this.btnAdd.IconColor = System.Drawing.Color.Black;
			this.btnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnAdd.IconSize = 20;
			this.btnAdd.Location = new System.Drawing.Point(20, 14);
			this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
			this.btnAdd.Size = new System.Drawing.Size(158, 48);
			this.btnAdd.TabIndex = 0;
			this.btnAdd.Text = "Thêm";
			this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// pnlHeader
			// 
			this.pnlHeader.Controls.Add(this.pnlSearch);
			this.pnlHeader.Location = new System.Drawing.Point(13, 12);
			this.pnlHeader.Margin = new System.Windows.Forms.Padding(4);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Size = new System.Drawing.Size(1893, 67);
			this.pnlHeader.TabIndex = 0;
			// 
			// pnlSearch
			// 
			this.pnlSearch.Controls.Add(this.lblSearch);
			this.pnlSearch.Controls.Add(this.btnRefresh);
			this.pnlSearch.Controls.Add(this.btnSearch);
			this.pnlSearch.Controls.Add(this.txtSearch);
			this.pnlSearch.Location = new System.Drawing.Point(0, -8);
			this.pnlSearch.Margin = new System.Windows.Forms.Padding(4);
			this.pnlSearch.Name = "pnlSearch";
			this.pnlSearch.Size = new System.Drawing.Size(1893, 73);
			this.pnlSearch.TabIndex = 1;
			// 
			// lblSearch
			// 
			this.lblSearch.AutoSize = true;
			this.lblSearch.Font = new System.Drawing.Font("Times New Roman", 14F);
			this.lblSearch.Location = new System.Drawing.Point(20, 15);
			this.lblSearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblSearch.Name = "lblSearch";
			this.lblSearch.Size = new System.Drawing.Size(109, 27);
			this.lblSearch.TabIndex = 4;
			this.lblSearch.Text = "Tìm kiếm:";
			// 
			// btnRefresh
			// 
			this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRefresh.Font = new System.Drawing.Font("Times New Roman", 14F);
			this.btnRefresh.IconChar = FontAwesome.Sharp.IconChar.SyncAlt;
			this.btnRefresh.IconColor = System.Drawing.Color.Black;
			this.btnRefresh.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnRefresh.IconSize = 20;
			this.btnRefresh.Location = new System.Drawing.Point(1671, 5);
			this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
			this.btnRefresh.Size = new System.Drawing.Size(201, 47);
			this.btnRefresh.TabIndex = 3;
			this.btnRefresh.Text = "Làm mới";
			this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnRefresh.UseVisualStyleBackColor = true;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// btnSearch
			// 
			this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSearch.Font = new System.Drawing.Font("Times New Roman", 14F);
			this.btnSearch.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
			this.btnSearch.IconColor = System.Drawing.Color.Black;
			this.btnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.btnSearch.IconSize = 20;
			this.btnSearch.Location = new System.Drawing.Point(1449, 5);
			this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
			this.btnSearch.Size = new System.Drawing.Size(201, 47);
			this.btnSearch.TabIndex = 2;
			this.btnSearch.Text = "Tìm kiếm";
			this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// txtSearch
			// 
			this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 16F);
			this.txtSearch.Location = new System.Drawing.Point(183, 9);
			this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(1128, 43);
			this.txtSearch.TabIndex = 1;
			this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
			// 
			// FrmCategory
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1920, 1081);
			this.Controls.Add(this.pnlMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "FrmCategory";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Quản lý danh mục";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.pnlMain.ResumeLayout(false);
			this.pnlContent.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).EndInit();
			this.pnlForm.ResumeLayout(false);
			this.grpCategoryInfo.ResumeLayout(false);
			this.grpCategoryInfo.PerformLayout();
			this.pnlButtons.ResumeLayout(false);
			this.pnlHeader.ResumeLayout(false);
			this.pnlSearch.ResumeLayout(false);
			this.pnlSearch.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.DataGridView dgvCategories;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.GroupBox grpCategoryInfo;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.Label lblCategoryName;
		private System.Windows.Forms.Panel pnlButtons;
		private FontAwesome.Sharp.IconButton btnCancel;
		private FontAwesome.Sharp.IconButton btnSave;
		private FontAwesome.Sharp.IconButton btnDelete;
		private FontAwesome.Sharp.IconButton btnEdit;
		private FontAwesome.Sharp.IconButton btnAdd;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblSearch;
		private FontAwesome.Sharp.IconButton btnRefresh;
		private FontAwesome.Sharp.IconButton btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
	}
}


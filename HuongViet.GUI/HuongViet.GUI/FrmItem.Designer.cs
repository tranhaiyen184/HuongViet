namespace HuongViet.GUI
{
    partial class FrmItem
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.pnlPriceHistory = new System.Windows.Forms.Panel();
            this.dgvPriceHistory = new System.Windows.Forms.DataGridView();
            this.pnlPriceHistoryHeader = new System.Windows.Forms.Panel();
            this.lblPriceHistory = new System.Windows.Forms.Label();
            this.btnRestorePrice = new System.Windows.Forms.Button();
            this.pnlPaging = new System.Windows.Forms.Panel();
            this.btnFirstPage = new System.Windows.Forms.Button();
            this.btnPrevPage = new System.Windows.Forms.Button();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.btnLastPage = new System.Windows.Forms.Button();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.cmbPageSize = new System.Windows.Forms.ComboBox();
            this.lblPageSize = new System.Windows.Forms.Label();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.grpItemInfo = new System.Windows.Forms.GroupBox();
            this.picItemImage = new System.Windows.Forms.PictureBox();
            this.btnSelectImage = new System.Windows.Forms.Button();
            this.btnClearImage = new System.Windows.Forms.Button();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.cmbItemType = new System.Windows.Forms.ComboBox();
            this.lblItemType = new System.Windows.Forms.Label();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.txtItemPrice = new System.Windows.Forms.TextBox();
            this.lblItemPrice = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.lblItemName = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.lblFilter = new System.Windows.Forms.Label();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.txtPriceTo = new System.Windows.Forms.TextBox();
            this.lblPriceTo = new System.Windows.Forms.Label();
            this.txtPriceFrom = new System.Windows.Forms.TextBox();
            this.lblPriceFrom = new System.Windows.Forms.Label();
            this.cmbFilterItemType = new System.Windows.Forms.ComboBox();
            this.lblFilterItemType = new System.Windows.Forms.Label();
            this.cmbFilterCategory = new System.Windows.Forms.ComboBox();
            this.lblFilterCategory = new System.Windows.Forms.Label();
            this.txtSearchItem = new System.Windows.Forms.TextBox();
            this.lblSearchItem = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.pnlPriceHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPriceHistory)).BeginInit();
            this.pnlPriceHistoryHeader.SuspendLayout();
            this.pnlPaging.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picItemImage)).BeginInit();
            this.pnlForm.SuspendLayout();
            this.grpItemInfo.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlContent);
            this.pnlMain.Controls.Add(this.pnlForm);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.pnlMain.Size = new System.Drawing.Size(1400, 800);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.dgvItems);
            this.pnlContent.Controls.Add(this.pnlPriceHistory);
            this.pnlContent.Controls.Add(this.pnlPaging);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(13, 152);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(4);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.pnlContent.Size = new System.Drawing.Size(987, 636);
            this.pnlContent.TabIndex = 2;
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToAddRows = false;
            this.dgvItems.AllowUserToDeleteRows = false;
            this.dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItems.BackgroundColor = System.Drawing.Color.White;
            this.dgvItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvItems.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvItems.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.Location = new System.Drawing.Point(0, 12);
            this.dgvItems.Margin = new System.Windows.Forms.Padding(4);
            this.dgvItems.MultiSelect = false;
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvItems.RowHeadersVisible = false;
            this.dgvItems.RowHeadersWidth = 51;
            this.dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItems.Size = new System.Drawing.Size(987, 392);
            this.dgvItems.TabIndex = 0;
            this.dgvItems.SelectionChanged += new System.EventHandler(this.dgvItems_SelectionChanged);
            // 
            // pnlPriceHistory
            // 
            this.pnlPriceHistory.Controls.Add(this.dgvPriceHistory);
            this.pnlPriceHistory.Controls.Add(this.pnlPriceHistoryHeader);
            this.pnlPriceHistory.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPriceHistory.Location = new System.Drawing.Point(0, 404);
            this.pnlPriceHistory.Margin = new System.Windows.Forms.Padding(4);
            this.pnlPriceHistory.Name = "pnlPriceHistory";
            this.pnlPriceHistory.Size = new System.Drawing.Size(987, 180);
            this.pnlPriceHistory.TabIndex = 2;
            // 
            // dgvPriceHistory
            // 
            this.dgvPriceHistory.AllowUserToAddRows = false;
            this.dgvPriceHistory.AllowUserToDeleteRows = false;
            this.dgvPriceHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPriceHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvPriceHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPriceHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPriceHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPriceHistory.Location = new System.Drawing.Point(0, 40);
            this.dgvPriceHistory.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPriceHistory.MultiSelect = false;
            this.dgvPriceHistory.Name = "dgvPriceHistory";
            this.dgvPriceHistory.ReadOnly = true;
            this.dgvPriceHistory.RowHeadersVisible = false;
            this.dgvPriceHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPriceHistory.Size = new System.Drawing.Size(987, 140);
            this.dgvPriceHistory.TabIndex = 0;
            // 
            // pnlPriceHistoryHeader
            // 
            this.pnlPriceHistoryHeader.Controls.Add(this.lblPriceHistory);
            this.pnlPriceHistoryHeader.Controls.Add(this.btnRestorePrice);
            this.pnlPriceHistoryHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPriceHistoryHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlPriceHistoryHeader.Name = "pnlPriceHistoryHeader";
            this.pnlPriceHistoryHeader.Size = new System.Drawing.Size(987, 40);
            this.pnlPriceHistoryHeader.TabIndex = 1;
            // 
            // lblPriceHistory
            // 
            this.lblPriceHistory.AutoSize = true;
            this.lblPriceHistory.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.lblPriceHistory.Location = new System.Drawing.Point(4, 10);
            this.lblPriceHistory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPriceHistory.Name = "lblPriceHistory";
            this.lblPriceHistory.Size = new System.Drawing.Size(100, 21);
            this.lblPriceHistory.TabIndex = 0;
            this.lblPriceHistory.Text = "Lịch sử giá";
            // 
            // btnRestorePrice
            // 
            this.btnRestorePrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestorePrice.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.btnRestorePrice.Location = new System.Drawing.Point(840, 5);
            this.btnRestorePrice.Margin = new System.Windows.Forms.Padding(4);
            this.btnRestorePrice.Name = "btnRestorePrice";
            this.btnRestorePrice.Size = new System.Drawing.Size(140, 30);
            this.btnRestorePrice.TabIndex = 1;
            this.btnRestorePrice.Text = "Khôi phục giá này";
            this.btnRestorePrice.UseVisualStyleBackColor = true;
            this.btnRestorePrice.Click += new System.EventHandler(this.btnRestorePrice_Click);
            // 
            // pnlPaging
            // 
            this.pnlPaging.Controls.Add(this.btnFirstPage);
            this.pnlPaging.Controls.Add(this.btnPrevPage);
            this.pnlPaging.Controls.Add(this.btnNextPage);
            this.pnlPaging.Controls.Add(this.btnLastPage);
            this.pnlPaging.Controls.Add(this.lblPageInfo);
            this.pnlPaging.Controls.Add(this.cmbPageSize);
            this.pnlPaging.Controls.Add(this.lblPageSize);
            this.pnlPaging.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPaging.Location = new System.Drawing.Point(0, 584);
            this.pnlPaging.Margin = new System.Windows.Forms.Padding(4);
            this.pnlPaging.Name = "pnlPaging";
            this.pnlPaging.Size = new System.Drawing.Size(987, 52);
            this.pnlPaging.TabIndex = 1;
            // 
            // btnFirstPage
            // 
            this.btnFirstPage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFirstPage.Location = new System.Drawing.Point(15, 8);
            this.btnFirstPage.Margin = new System.Windows.Forms.Padding(4);
            this.btnFirstPage.Name = "btnFirstPage";
            this.btnFirstPage.Size = new System.Drawing.Size(45, 36);
            this.btnFirstPage.TabIndex = 0;
            this.btnFirstPage.Text = "<<";
            this.btnFirstPage.UseVisualStyleBackColor = true;
            this.btnFirstPage.Click += new System.EventHandler(this.btnFirstPage_Click);
            // 
            // btnPrevPage
            // 
            this.btnPrevPage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPrevPage.Location = new System.Drawing.Point(65, 8);
            this.btnPrevPage.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.Size = new System.Drawing.Size(45, 36);
            this.btnPrevPage.TabIndex = 1;
            this.btnPrevPage.Text = "<";
            this.btnPrevPage.UseVisualStyleBackColor = true;
            this.btnPrevPage.Click += new System.EventHandler(this.btnPrevPage_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNextPage.Location = new System.Drawing.Point(115, 8);
            this.btnNextPage.Margin = new System.Windows.Forms.Padding(4);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(45, 36);
            this.btnNextPage.TabIndex = 2;
            this.btnNextPage.Text = ">";
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // btnLastPage
            // 
            this.btnLastPage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLastPage.Location = new System.Drawing.Point(165, 8);
            this.btnLastPage.Margin = new System.Windows.Forms.Padding(4);
            this.btnLastPage.Name = "btnLastPage";
            this.btnLastPage.Size = new System.Drawing.Size(45, 36);
            this.btnLastPage.TabIndex = 3;
            this.btnLastPage.Text = ">>";
            this.btnLastPage.UseVisualStyleBackColor = true;
            this.btnLastPage.Click += new System.EventHandler(this.btnLastPage_Click);
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Font = new System.Drawing.Font("Times New Roman", 10.8F);
            this.lblPageInfo.Location = new System.Drawing.Point(320, 16);
            this.lblPageInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(175, 20);
            this.lblPageInfo.TabIndex = 6;
            this.lblPageInfo.Text = "Trang 1 / 1  (Tổng: 0)";
            this.lblPageInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbPageSize
            // 
            this.cmbPageSize.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbPageSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPageSize.Font = new System.Drawing.Font("Times New Roman", 10.8F);
            this.cmbPageSize.FormattingEnabled = true;
            this.cmbPageSize.Items.AddRange(new object[] {
            "10",
            "20",
            "50",
            "100"});
            this.cmbPageSize.Location = new System.Drawing.Point(750, 13);
            this.cmbPageSize.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPageSize.Name = "cmbPageSize";
            this.cmbPageSize.Size = new System.Drawing.Size(60, 28);
            this.cmbPageSize.TabIndex = 5;
            this.cmbPageSize.SelectedIndexChanged += new System.EventHandler(this.cmbPageSize_SelectedIndexChanged);
            // 
            // lblPageSize
            // 
            this.lblPageSize.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPageSize.AutoSize = true;
            this.lblPageSize.Font = new System.Drawing.Font("Times New Roman", 10.8F);
            this.lblPageSize.Location = new System.Drawing.Point(620, 16);
            this.lblPageSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPageSize.Name = "lblPageSize";
            this.lblPageSize.Size = new System.Drawing.Size(113, 20);
            this.lblPageSize.TabIndex = 4;
            this.lblPageSize.Text = "Số dòng/trang:";
            // 
            // pnlForm
            // 
            this.pnlForm.Controls.Add(this.grpItemInfo);
            this.pnlForm.Controls.Add(this.pnlButtons);
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlForm.Location = new System.Drawing.Point(1000, 152);
            this.pnlForm.Margin = new System.Windows.Forms.Padding(4);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Padding = new System.Windows.Forms.Padding(13, 12, 0, 0);
            this.pnlForm.Size = new System.Drawing.Size(387, 636);
            this.pnlForm.TabIndex = 1;
            // 
            // grpItemInfo
            // 
            this.grpItemInfo.Controls.Add(this.picItemImage);
            this.grpItemInfo.Controls.Add(this.btnSelectImage);
            this.grpItemInfo.Controls.Add(this.btnClearImage);
            this.grpItemInfo.Controls.Add(this.chkIsActive);
            this.grpItemInfo.Controls.Add(this.txtDescription);
            this.grpItemInfo.Controls.Add(this.lblDescription);
            this.grpItemInfo.Controls.Add(this.cmbItemType);
            this.grpItemInfo.Controls.Add(this.lblItemType);
            this.grpItemInfo.Controls.Add(this.cmbUnit);
            this.grpItemInfo.Controls.Add(this.lblUnit);
            this.grpItemInfo.Controls.Add(this.cmbCategory);
            this.grpItemInfo.Controls.Add(this.lblCategory);
            this.grpItemInfo.Controls.Add(this.txtItemPrice);
            this.grpItemInfo.Controls.Add(this.lblItemPrice);
            this.grpItemInfo.Controls.Add(this.txtItemName);
            this.grpItemInfo.Controls.Add(this.lblItemName);
            this.grpItemInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpItemInfo.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.grpItemInfo.Location = new System.Drawing.Point(13, 12);
            this.grpItemInfo.Margin = new System.Windows.Forms.Padding(4);
            this.grpItemInfo.Name = "grpItemInfo";
            this.grpItemInfo.Padding = new System.Windows.Forms.Padding(20, 18, 20, 18);
            this.grpItemInfo.Size = new System.Drawing.Size(374, 501);
            this.grpItemInfo.TabIndex = 1;
            this.grpItemInfo.TabStop = false;
            this.grpItemInfo.Text = "Thông tin món ăn";
            // 
            // picItemImage
            // 
            this.picItemImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picItemImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picItemImage.Location = new System.Drawing.Point(240, 40);
            this.picItemImage.Name = "picItemImage";
            this.picItemImage.Size = new System.Drawing.Size(110, 110);
            this.picItemImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picItemImage.TabIndex = 15;
            this.picItemImage.TabStop = false;
            // 
            // btnSelectImage
            // 
            this.btnSelectImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectImage.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.btnSelectImage.Location = new System.Drawing.Point(240, 155);
            this.btnSelectImage.Name = "btnSelectImage";
            this.btnSelectImage.Size = new System.Drawing.Size(110, 25);
            this.btnSelectImage.TabIndex = 16;
            this.btnSelectImage.Text = "Chọn ảnh";
            this.btnSelectImage.UseVisualStyleBackColor = true;
            this.btnSelectImage.Click += new System.EventHandler(this.btnSelectImage_Click);
            // 
            // btnClearImage
            // 
            this.btnClearImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearImage.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.btnClearImage.Location = new System.Drawing.Point(240, 185);
            this.btnClearImage.Name = "btnClearImage";
            this.btnClearImage.Size = new System.Drawing.Size(110, 25);
            this.btnClearImage.TabIndex = 17;
            this.btnClearImage.Text = "Xóa ảnh";
            this.btnClearImage.UseVisualStyleBackColor = true;
            this.btnClearImage.Click += new System.EventHandler(this.btnClearImage_Click);
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.chkIsActive.Location = new System.Drawing.Point(24, 460);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(109, 25);
            this.chkIsActive.TabIndex = 12;
            this.chkIsActive.Text = "Hoạt động";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.txtDescription.Location = new System.Drawing.Point(24, 390);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescription.MaxLength = 1000;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(326, 60);
            this.txtDescription.TabIndex = 11;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.lblDescription.Location = new System.Drawing.Point(24, 365);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 21);
            this.lblDescription.TabIndex = 10;
            this.lblDescription.Text = "Mô tả:";
            // 
            // cmbItemType
            // 
            this.cmbItemType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemType.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.cmbItemType.FormattingEnabled = true;
            this.cmbItemType.Items.AddRange(new object[] {
            "Thức ăn",
            "Nước uống"});
            this.cmbItemType.Location = new System.Drawing.Point(24, 325);
            this.cmbItemType.Margin = new System.Windows.Forms.Padding(4);
            this.cmbItemType.Name = "cmbItemType";
            this.cmbItemType.Size = new System.Drawing.Size(200, 29);
            this.cmbItemType.TabIndex = 9;
            // 
            // lblItemType
            // 
            this.lblItemType.AutoSize = true;
            this.lblItemType.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.lblItemType.Location = new System.Drawing.Point(24, 300);
            this.lblItemType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblItemType.Name = "lblItemType";
            this.lblItemType.Size = new System.Drawing.Size(90, 21);
            this.lblItemType.TabIndex = 8;
            this.lblItemType.Text = "Loại món:";
            // 
            // cmbUnit
            // 
            this.cmbUnit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnit.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Location = new System.Drawing.Point(24, 260);
            this.cmbUnit.Margin = new System.Windows.Forms.Padding(4);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(200, 29);
            this.cmbUnit.TabIndex = 7;
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.lblUnit.Location = new System.Drawing.Point(24, 235);
            this.lblUnit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(106, 21);
            this.lblUnit.TabIndex = 6;
            this.lblUnit.Text = "Đơn vị tính:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(24, 195);
            this.cmbCategory.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(326, 29);
            this.cmbCategory.TabIndex = 5;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.lblCategory.Location = new System.Drawing.Point(24, 170);
            this.lblCategory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(80, 21);
            this.lblCategory.TabIndex = 4;
            this.lblCategory.Text = "Thể loại:";
            // 
            // txtItemPrice
            // 
            this.txtItemPrice.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.txtItemPrice.Location = new System.Drawing.Point(24, 130);
            this.txtItemPrice.Margin = new System.Windows.Forms.Padding(4);
            this.txtItemPrice.MaxLength = 18;
            this.txtItemPrice.Name = "txtItemPrice";
            this.txtItemPrice.Size = new System.Drawing.Size(150, 29);
            this.txtItemPrice.TabIndex = 3;
            // 
            // lblItemPrice
            // 
            this.lblItemPrice.AutoSize = true;
            this.lblItemPrice.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.lblItemPrice.Location = new System.Drawing.Point(24, 105);
            this.lblItemPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblItemPrice.Name = "lblItemPrice";
            this.lblItemPrice.Size = new System.Drawing.Size(43, 21);
            this.lblItemPrice.TabIndex = 2;
            this.lblItemPrice.Text = "Giá:";
            // 
            // txtItemName
            // 
            this.txtItemName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemName.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.txtItemName.Location = new System.Drawing.Point(24, 65);
            this.txtItemName.Margin = new System.Windows.Forms.Padding(4);
            this.txtItemName.MaxLength = 200;
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(326, 29);
            this.txtItemName.TabIndex = 1;
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.lblItemName.Location = new System.Drawing.Point(24, 40);
            this.lblItemName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(83, 21);
            this.lblItemName.TabIndex = 0;
            this.lblItemName.Text = "Tên món:";
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Controls.Add(this.btnSave);
            this.pnlButtons.Controls.Add(this.btnDelete);
            this.pnlButtons.Controls.Add(this.btnEdit);
            this.pnlButtons.Controls.Add(this.btnAdd);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(13, 513);
            this.pnlButtons.Margin = new System.Windows.Forms.Padding(4);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.pnlButtons.Size = new System.Drawing.Size(374, 123);
            this.pnlButtons.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancel.Location = new System.Drawing.Point(193, 60);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(135, 40);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.Location = new System.Drawing.Point(47, 60);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(135, 40);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDelete.Location = new System.Drawing.Point(246, 13);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 40);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEdit.Location = new System.Drawing.Point(145, 13);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(85, 40);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAdd.Location = new System.Drawing.Point(44, 13);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 40);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.pnlFilter);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(13, 12);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1374, 140);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(540, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(277, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ MÓN ĂN";
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.lblFilter);
            this.pnlFilter.Controls.Add(this.btnClearFilter);
            this.pnlFilter.Controls.Add(this.lblStatus);
            this.pnlFilter.Controls.Add(this.btnFilter);
            this.pnlFilter.Controls.Add(this.txtPriceTo);
            this.pnlFilter.Controls.Add(this.lblPriceTo);
            this.pnlFilter.Controls.Add(this.txtPriceFrom);
            this.pnlFilter.Controls.Add(this.lblPriceFrom);
            this.pnlFilter.Controls.Add(this.cmbFilterItemType);
            this.pnlFilter.Controls.Add(this.lblFilterItemType);
            this.pnlFilter.Controls.Add(this.cmbFilterCategory);
            this.pnlFilter.Controls.Add(this.lblFilterCategory);
            this.pnlFilter.Controls.Add(this.txtSearchItem);
            this.pnlFilter.Controls.Add(this.lblSearchItem);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Margin = new System.Windows.Forms.Padding(4);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1374, 140);
            this.pnlFilter.TabIndex = 1;
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.lblFilter.Location = new System.Drawing.Point(4, 10);
            this.lblFilter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(87, 21);
            this.lblFilter.TabIndex = 13;
            this.lblFilter.Text = "Bộ lọc:";
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearFilter.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.btnClearFilter.Location = new System.Drawing.Point(1210, 80);
            this.btnClearFilter.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(120, 40);
            this.btnClearFilter.TabIndex = 12;
            this.btnClearFilter.Text = "Xóa lọc";
            this.btnClearFilter.UseVisualStyleBackColor = true;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.lblStatus.ForeColor = System.Drawing.Color.Gray;
            this.lblStatus.Location = new System.Drawing.Point(4, 115);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(105, 19);
            this.lblStatus.TabIndex = 11;
            this.lblStatus.Text = "Tổng số món: 0";
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.btnFilter.Location = new System.Drawing.Point(1070, 80);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(4);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(120, 40);
            this.btnFilter.TabIndex = 10;
            this.btnFilter.Text = "Lọc";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // txtPriceTo
            // 
            this.txtPriceTo.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.txtPriceTo.Location = new System.Drawing.Point(850, 85);
            this.txtPriceTo.Margin = new System.Windows.Forms.Padding(4);
            this.txtPriceTo.MaxLength = 18;
            this.txtPriceTo.Name = "txtPriceTo";
            this.txtPriceTo.Size = new System.Drawing.Size(120, 29);
            this.txtPriceTo.TabIndex = 9;
            // 
            // lblPriceTo
            // 
            this.lblPriceTo.AutoSize = true;
            this.lblPriceTo.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.lblPriceTo.Location = new System.Drawing.Point(846, 60);
            this.lblPriceTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPriceTo.Name = "lblPriceTo";
            this.lblPriceTo.Size = new System.Drawing.Size(76, 21);
            this.lblPriceTo.TabIndex = 8;
            this.lblPriceTo.Text = "Đến giá:";
            // 
            // txtPriceFrom
            // 
            this.txtPriceFrom.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.txtPriceFrom.Location = new System.Drawing.Point(690, 85);
            this.txtPriceFrom.Margin = new System.Windows.Forms.Padding(4);
            this.txtPriceFrom.MaxLength = 18;
            this.txtPriceFrom.Name = "txtPriceFrom";
            this.txtPriceFrom.Size = new System.Drawing.Size(120, 29);
            this.txtPriceFrom.TabIndex = 7;
            // 
            // lblPriceFrom
            // 
            this.lblPriceFrom.AutoSize = true;
            this.lblPriceFrom.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.lblPriceFrom.Location = new System.Drawing.Point(686, 60);
            this.lblPriceFrom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPriceFrom.Name = "lblPriceFrom";
            this.lblPriceFrom.Size = new System.Drawing.Size(69, 21);
            this.lblPriceFrom.TabIndex = 6;
            this.lblPriceFrom.Text = "Từ giá:";
            // 
            // cmbFilterItemType
            // 
            this.cmbFilterItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterItemType.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.cmbFilterItemType.FormattingEnabled = true;
            this.cmbFilterItemType.Items.AddRange(new object[] {
            "Tất cả",
            "Thức ăn",
            "Nước uống"});
            this.cmbFilterItemType.Location = new System.Drawing.Point(430, 85);
            this.cmbFilterItemType.Margin = new System.Windows.Forms.Padding(4);
            this.cmbFilterItemType.Name = "cmbFilterItemType";
            this.cmbFilterItemType.Size = new System.Drawing.Size(180, 29);
            this.cmbFilterItemType.TabIndex = 5;
            // 
            // lblFilterItemType
            // 
            this.lblFilterItemType.AutoSize = true;
            this.lblFilterItemType.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.lblFilterItemType.Location = new System.Drawing.Point(426, 60);
            this.lblFilterItemType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFilterItemType.Name = "lblFilterItemType";
            this.lblFilterItemType.Size = new System.Drawing.Size(90, 21);
            this.lblFilterItemType.TabIndex = 4;
            this.lblFilterItemType.Text = "Loại món:";
            // 
            // cmbFilterCategory
            // 
            this.cmbFilterCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterCategory.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.cmbFilterCategory.FormattingEnabled = true;
            this.cmbFilterCategory.Location = new System.Drawing.Point(8, 85);
            this.cmbFilterCategory.Margin = new System.Windows.Forms.Padding(4);
            this.cmbFilterCategory.Name = "cmbFilterCategory";
            this.cmbFilterCategory.Size = new System.Drawing.Size(350, 29);
            this.cmbFilterCategory.TabIndex = 3;
            // 
            // lblFilterCategory
            // 
            this.lblFilterCategory.AutoSize = true;
            this.lblFilterCategory.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.lblFilterCategory.Location = new System.Drawing.Point(4, 60);
            this.lblFilterCategory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFilterCategory.Name = "lblFilterCategory";
            this.lblFilterCategory.Size = new System.Drawing.Size(80, 21);
            this.lblFilterCategory.TabIndex = 2;
            this.lblFilterCategory.Text = "Thể loại:";
            // 
            // txtSearchItem
            // 
            this.txtSearchItem.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.txtSearchItem.Location = new System.Drawing.Point(100, 35);
            this.txtSearchItem.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearchItem.Name = "txtSearchItem";
            this.txtSearchItem.Size = new System.Drawing.Size(830, 29);
            this.txtSearchItem.TabIndex = 1;
            this.txtSearchItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchItem_KeyPress);
            // 
            // lblSearchItem
            // 
            this.lblSearchItem.AutoSize = true;
            this.lblSearchItem.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.lblSearchItem.Location = new System.Drawing.Point(4, 38);
            this.lblSearchItem.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSearchItem.Name = "lblSearchItem";
            this.lblSearchItem.Size = new System.Drawing.Size(83, 21);
            this.lblSearchItem.TabIndex = 0;
            this.lblSearchItem.Text = "Tên món:";
            // 
            // FrmItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 800);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmItem";
            this.Text = "Quản lý món ăn";
            this.pnlMain.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.pnlPriceHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPriceHistory)).EndInit();
            this.pnlPriceHistoryHeader.ResumeLayout(false);
            this.pnlPriceHistoryHeader.PerformLayout();
            this.pnlPaging.ResumeLayout(false);
            this.pnlPaging.PerformLayout();
            this.pnlForm.ResumeLayout(false);
            this.grpItemInfo.ResumeLayout(false);
            this.grpItemInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picItemImage)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlPaging;
        private System.Windows.Forms.Button btnFirstPage;
        private System.Windows.Forms.Button btnPrevPage;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnLastPage;
        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.ComboBox cmbPageSize;
        private System.Windows.Forms.Label lblPageSize;
        private System.Windows.Forms.GroupBox grpItemInfo;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label lblItemPrice;
        private System.Windows.Forms.TextBox txtItemPrice;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.ComboBox cmbUnit;
        private System.Windows.Forms.Label lblItemType;
        private System.Windows.Forms.ComboBox cmbItemType;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.TextBox txtSearchItem;
        private System.Windows.Forms.Label lblSearchItem;
        private System.Windows.Forms.ComboBox cmbFilterCategory;
        private System.Windows.Forms.Label lblFilterCategory;
        private System.Windows.Forms.ComboBox cmbFilterItemType;
        private System.Windows.Forms.Label lblFilterItemType;
        private System.Windows.Forms.TextBox txtPriceFrom;
        private System.Windows.Forms.Label lblPriceFrom;
        private System.Windows.Forms.TextBox txtPriceTo;
        private System.Windows.Forms.Label lblPriceTo;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Panel pnlPriceHistory;
        private System.Windows.Forms.DataGridView dgvPriceHistory;
        private System.Windows.Forms.Panel pnlPriceHistoryHeader;
        private System.Windows.Forms.Label lblPriceHistory;
        private System.Windows.Forms.Button btnRestorePrice;
        private System.Windows.Forms.PictureBox picItemImage;
        private System.Windows.Forms.Button btnSelectImage;
        private System.Windows.Forms.Button btnClearImage;
    }
}


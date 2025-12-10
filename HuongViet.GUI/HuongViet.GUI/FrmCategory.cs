using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HuongViet.BLL;
using HuongViet.Models;

namespace HuongViet.GUI
{
    public partial class FrmCategory : Form
    {
        private readonly CategoryBLL categoryBLL;
        private List<Category> categories;
        private Category selectedCategory;
        private bool isEditing = false;

        public FrmCategory()
        {
            InitializeComponent();
            categoryBLL = new CategoryBLL();
            InitializeForm();
            LoadCategories();
        }

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(value);
        }


        private void InitializeForm()
        {
            SetupDataGridView();
            ClearForm();
        }

        private void SetupDataGridView()
        {
            dgvCategories.RowHeadersVisible = false;
            dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategories.MultiSelect = false;
            dgvCategories.AllowUserToAddRows = false;
            dgvCategories.AllowUserToDeleteRows = false;
            dgvCategories.ReadOnly = true;
            dgvCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            // Header styles
            dgvCategories.EnableHeadersVisualStyles = false;
            dgvCategories.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 11F, FontStyle.Bold);
            dgvCategories.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            dgvCategories.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvCategories.ColumnHeadersHeight = 35;
            
            // Row styles
            dgvCategories.RowTemplate.Height = 30;
            dgvCategories.DefaultCellStyle.Font = new Font("Times New Roman", 11F);
            dgvCategories.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgvCategories.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void LoadCategories()
        {
            try
            {
                categories = categoryBLL.GetAll();
                BindDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách thể loại: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindDataGridView()
        {
            dgvCategories.DataSource = null;
            
            if (categories != null && categories.Count > 0)
            {
                var displayData = categories.Select(c => new
                {
                    CateID = c.CateID,
                    CateName = c.CateName,
                    CateDescription = c.CateDescription
                }).ToList();

                dgvCategories.DataSource = displayData;
                
                if (dgvCategories.Columns.Count > 0)
                {
                    dgvCategories.Columns["CateID"].HeaderText = "Mã thể loại";
                    dgvCategories.Columns["CateName"].HeaderText = "Tên thể loại";
                    dgvCategories.Columns["CateDescription"].HeaderText = "Mô tả";
                    
                    dgvCategories.Columns["CateID"].FillWeight = 20;
                    dgvCategories.Columns["CateName"].FillWeight = 30;
                    dgvCategories.Columns["CateDescription"].FillWeight = 50;
                }
            }
        }

        private void ClearForm()
        {
            txtCategoryName.Clear();
            txtDescription.Clear();
            selectedCategory = null;
            isEditing = false;
            
            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            
            EnableEditMode(false);
        }

        private void EnableEditMode(bool enable)
        {
            txtCategoryName.ReadOnly = !enable;
            txtDescription.ReadOnly = !enable;
            txtCategoryName.BackColor = enable ? SystemColors.Window : SystemColors.Control;
            txtDescription.BackColor = enable ? SystemColors.Window : SystemColors.Control;
            
            btnAdd.Enabled = !enable;
            btnEdit.Enabled = !enable && selectedCategory != null;
            btnDelete.Enabled = !enable && selectedCategory != null;
            btnSave.Enabled = enable;
            btnCancel.Enabled = enable;
            
            dgvCategories.Enabled = !enable;
        }

        private void dgvCategories_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategories.SelectedRows.Count > 0 && !isEditing)
            {
                var row = dgvCategories.SelectedRows[0];
                string categoryId = row.Cells["CateID"].Value.ToString();
                
                selectedCategory = categories.FirstOrDefault(c => c.CateID == categoryId);
                
                if (selectedCategory != null)
                {
                    txtCategoryName.Text = selectedCategory.CateName;
                    txtDescription.Text = selectedCategory.CateDescription ?? string.Empty;
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;
                }
            }
            else if (!isEditing)
            {
                ClearForm();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            selectedCategory = null;
            ClearForm();
            isEditing = true; // Set sau khi ClearForm để không bị reset
            EnableEditMode(true);
            btnSave.Enabled = true; // Enable nút Lưu ngay khi bấm Thêm
            txtCategoryName.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedCategory != null)
            {
                isEditing = true;
                EnableEditMode(true);
                txtCategoryName.Focus();
                txtCategoryName.SelectAll();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedCategory == null) return;

            var result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa thể loại '{selectedCategory.CateName}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    bool success = categoryBLL.Delete(selectedCategory.CateID);
                    if (success)
                    {
                        MessageBox.Show("Xóa thể loại thành công!", "Thành công", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCategories();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa thể loại!", "Lỗi", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên thể loại!", "Lỗi nhập liệu", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCategoryName.Focus();
                    return;
                }

                Category category = selectedCategory ?? new Category
                {
                    CateID = categoryBLL.GenerateNewCategoryID()
                };
                
                category.CateName = txtCategoryName.Text.Trim();
                category.CateDescription = txtDescription.Text.Trim();

                bool success;
                string message;

                if (selectedCategory == null) // Add new
                {
                    success = categoryBLL.Insert(category);
                    message = success ? "Thêm thể loại thành công!" : "Không thể thêm thể loại!";
                }
                else // Update existing
                {
                    success = categoryBLL.Update(category);
                    message = success ? "Cập nhật thể loại thành công!" : "Không thể cập nhật thể loại!";
                }

                if (success)
                {
                    MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCategories();
                    ClearForm();
                    EnableEditMode(false);
                }
                else
                {
                    MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (selectedCategory != null)
            {
                txtCategoryName.Text = selectedCategory.CateName;
                txtDescription.Text = selectedCategory.CateDescription ?? string.Empty;
            }
            else
            {
                ClearForm();
            }
            
            isEditing = false;
            EnableEditMode(false);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // TODO: Implement search functionality
            LoadCategories();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadCategories();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearch_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}


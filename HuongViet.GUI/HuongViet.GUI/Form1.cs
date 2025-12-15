using HuongViet.BLL;
using HuongViet.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuongViet.GUI
{
    public partial class Form1 : Form
    {
        private readonly BackupBLL _backupService;
        private string _backupDirectory;

        public Form1()
        {
            InitializeComponent();

            var repo = new BackupRepository(
		@"C:\Program Files\MySQL\MySQL Server 8.0\bin\mysqldump.exe",
        "huongviet",
        "root",
        "root");

            _backupService = new BackupBLL(repo);
            
            // Set default backup directory (can be changed to a specific folder)
            _backupDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "HuongVietBackups");
            if (!Directory.Exists(_backupDirectory))
            {
                Directory.CreateDirectory(_backupDirectory);
            }

            InitializeIcons();
            InitializeDataGridView();
            LoadBackupFiles();
        }

        private void InitializeDataGridView()
        {
            // Clear existing columns
            dgvBackupFiles.Columns.Clear();
            
            // Add columns
            dgvBackupFiles.Columns.Add("FileName", "Tên File");
            dgvBackupFiles.Columns.Add("Date", "Ngày Tạo");
            dgvBackupFiles.Columns.Add("Size", "Kích Thước");
            dgvBackupFiles.Columns.Add("FilePath", "Đường Dẫn");
            
            // Hide the FilePath column (we'll use it for restore but don't show it)
            dgvBackupFiles.Columns["FilePath"].Visible = false;
            
            // Set column fill weights for AutoSizeColumnsMode.Fill
            dgvBackupFiles.Columns["FileName"].FillWeight = 50;
            dgvBackupFiles.Columns["Date"].FillWeight = 30;
            dgvBackupFiles.Columns["Size"].FillWeight = 20;
            
            // Set column properties
            dgvBackupFiles.Columns["FileName"].ReadOnly = true;
            dgvBackupFiles.Columns["Date"].ReadOnly = true;
            dgvBackupFiles.Columns["Size"].ReadOnly = true;
            dgvBackupFiles.Columns["FilePath"].ReadOnly = true;
            
            // Set minimum widths
            dgvBackupFiles.Columns["FileName"].MinimumWidth = 200;
            dgvBackupFiles.Columns["Date"].MinimumWidth = 150;
            dgvBackupFiles.Columns["Size"].MinimumWidth = 100;
        }

        private void InitializeIcons()
        {
            // Set backup icon (using system icons)
            try
            {
                picBackup.Image = SystemIcons.Shield.ToBitmap();
                picBackup.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch
            {
                // If icon fails, leave it empty
            }

            // Set restore icon
            try
            {
                picRestore.Image = SystemIcons.Application.ToBitmap();
                picRestore.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch
            {
                // If icon fails, leave it empty
            }
        }

        private void LoadBackupFiles()
        {
            dgvBackupFiles.Rows.Clear();
            
            try
            {
                // Load from default backup directory
                if (Directory.Exists(_backupDirectory))
                {
                    var backupFiles = Directory.GetFiles(_backupDirectory, "*.sql")
                        .OrderByDescending(f => new FileInfo(f).CreationTime)
                        .ToList();

                    foreach (var file in backupFiles)
                    {
                        var fileInfo = new FileInfo(file);
                        string fileName = fileInfo.Name;
                        string dateTime = fileInfo.CreationTime.ToString("dd/MM/yyyy HH:mm:ss");
                        string fileSize = $"{fileInfo.Length / 1024.0:F2} KB";
                        
                        dgvBackupFiles.Rows.Add(fileName, dateTime, fileSize, file);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách backup: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog
            {
                Filter = "SQL Files (*.sql)|*.sql",
                FileName = $"backup_{DateTime.Now:yyyyMMdd_HHmmss}.sql",
                InitialDirectory = _backupDirectory
            })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _backupService.BackupDatabase(dialog.FileName);
                        MessageBox.Show("Sao lưu dữ liệu thành công!", "Thông báo", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadBackupFiles(); // Refresh the list
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Sao lưu thất bại: {ex.Message}", "Lỗi", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog
            {
                Filter = "SQL Files (*.sql)|*.sql",
                InitialDirectory = _backupDirectory
            })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    RestoreFromFile(dialog.FileName);
                }
            }
        }

        private void dgvBackupFiles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvBackupFiles.Rows.Count)
            {
                var row = dgvBackupFiles.Rows[e.RowIndex];
                string filePath = row.Cells["FilePath"].Value?.ToString();
                string fileName = row.Cells["FileName"].Value?.ToString();

                if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
                {
                    var result = MessageBox.Show(
                        $"Bạn có chắc chắn muốn khôi phục từ file:\n{fileName}\n\n" +
                        "CẢNH BÁO: Thao tác này sẽ ghi đè dữ liệu hiện tại!",
                        "Xác nhận Khôi phục",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        RestoreFromFile(filePath);
                    }
                }
            }
        }

        private void RestoreFromFile(string filePath)
        {
            try
            {
                _backupService.RestoreDatabase(filePath);
                MessageBox.Show("Khôi phục dữ liệu thành công!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Khôi phục thất bại: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

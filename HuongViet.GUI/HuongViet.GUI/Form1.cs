using HuongViet.BLL;
using HuongViet.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuongViet.GUI
{
    public partial class Form1 : Form
    {
        private readonly BackupBLL _backupService;

        public Form1()
        {
            InitializeComponent();

            var repo = new BackupRepository(
        @"C:\Program Files\MySQL\MySQL Server 9.5\bin\mysqldump.exe",
        "huongviet",
        "root",
        "root");

            _backupService = new BackupBLL(repo);
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog
            {
                Filter = "SQL Files (*.sql)|*.sql",
                FileName = "backup.sql"
            })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _backupService.BackupDatabase(dialog.FileName);
                        MessageBox.Show("Backup completed.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Backup failed: " + ex.Message);
                    }
                }
            }
        }
    }
}

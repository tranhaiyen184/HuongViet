using HuongViet.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuongViet.BLL
{
    public class BackupBLL
    {
        private readonly BackupRepository _repo;

        public BackupBLL(BackupRepository repo)
        {
            _repo = repo;
        }

        public void BackupDatabase(string destinationPath)
        {
            if (string.IsNullOrWhiteSpace(destinationPath))
                throw new ArgumentException("Backup file path is required.");

            _repo.BackupTo(destinationPath);
        }
    }
}

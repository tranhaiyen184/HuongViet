using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuongViet.DAL
{
    public class BackupRepository
    {
        private readonly string _mysqldumpPath;
        private readonly string _dbName;
        private readonly string _user;
        private readonly string _password;

        public BackupRepository(string mysqldumpPath, string dbName, string user, string password)
        {
            _mysqldumpPath = mysqldumpPath;
            _dbName = dbName;
            _user = user;
            _password = password;
        }

        public void BackupTo(string backupFile)
        {
            // Example: mysqldump -u root -p123 mydb > backup.sql
            var psi = new ProcessStartInfo
            {
                FileName = _mysqldumpPath,
                Arguments = $"-u {_user} -p{_password} {_dbName}",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = Process.Start(psi))
            {
                string dump = process.StandardOutput.ReadToEnd();
                File.WriteAllText(backupFile, dump);
                process.WaitForExit();

                if (process.ExitCode != 0)
                    throw new Exception("Backup failed (mysqldump returned non-zero exit code).");
            }
        }
    }
}

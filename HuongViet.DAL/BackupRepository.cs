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
            // Example: mysqldump -u root -p123 --set-gtid-purged=OFF mydb > backup.sql
            // --set-gtid-purged=OFF prevents GTID conflicts during restore
            var psi = new ProcessStartInfo
            {
                FileName = _mysqldumpPath,
                Arguments = $"-u {_user} -p{_password} --set-gtid-purged=OFF {_dbName}",
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

        public void RestoreFrom(string backupFile)
        {
            if (!File.Exists(backupFile))
                throw new FileNotFoundException("Backup file not found.", backupFile);

            // Get mysql.exe path (usually in the same directory as mysqldump.exe)
            string mysqlPath = _mysqldumpPath.Replace("mysqldump.exe", "mysql.exe");
            if (!File.Exists(mysqlPath))
                throw new FileNotFoundException("mysql.exe not found at expected location.", mysqlPath);

            // Example: mysql -u root -p123 dbname < backup.sql
            var psi = new ProcessStartInfo
            {
                FileName = mysqlPath,
                Arguments = $"-u {_user} -p{_password} {_dbName}",
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                //StandardInputEncoding = Encoding.UTF8,
                StandardOutputEncoding = Encoding.UTF8,
                StandardErrorEncoding = Encoding.UTF8
            };

            using (var process = Process.Start(psi))
            {
                using (var writer = process.StandardInput)
                {
                    string sqlContent = File.ReadAllText(backupFile, Encoding.UTF8);
                    writer.Write(sqlContent);
                }
                
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (process.ExitCode != 0)
                {
                    string errorMsg = !string.IsNullOrEmpty(error) ? error : output;
                    throw new Exception($"Restore failed: {errorMsg}");
                }
            }
        }
    }
}

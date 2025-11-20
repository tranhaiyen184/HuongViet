using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuongViet.DAL
{
    public class DatabaseHelper
    {
        private readonly string connectionString =
            "server=localhost;port=3306;database=huongviet;uid=root;pwd=root;";

        public DataTable ExecuteQuery(string query, params MySqlParameter[] parameters)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                using (var cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        var table = new DataTable();
                        adapter.Fill(table);
                        return table;
                    }
                }
            }
        }

        public int ExecuteNonQuery(string query, params MySqlParameter[] parameters)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public object ExecuteScalar(string query, params MySqlParameter[] parameters)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteScalar();
                }
            }
        }
    }
}

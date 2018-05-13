using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace Web.Models
{
    public class WebDbContext : DbContext
    {
        private MySqlConnection conn;
        public string ConnectionString { get; set; }

        public WebDbContext(string connectionString)
        {
            this.ConnectionString = connectionString;
            conn = GetConnection();
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        // Login data
        public MySqlDataReader GetLoginData(string email)
        {
            conn.Open();

            MySqlCommand getDataCmd = new MySqlCommand("Get_UserLogin_Data", conn);
            getDataCmd.CommandType = CommandType.StoredProcedure;
            getDataCmd.Parameters.AddWithValue("@UID", email);

            MySqlDataReader reader = getDataCmd.ExecuteReader(CommandBehavior.CloseConnection);

            return reader;
        }

        public int GetLoginUsername(string email)
        {
            conn.Open();

            MySqlCommand getDataCmd = new MySqlCommand("UserLogin_Check_Username", conn);
            getDataCmd.CommandType = CommandType.StoredProcedure;
            getDataCmd.Parameters.AddWithValue("@UID", email);

            int count = Convert.ToInt32(getDataCmd.ExecuteScalar());

            conn.Close();
            getDataCmd.Dispose();
            return count;
        }

        public int GetLoginMatch(string email, string password)
        {
            conn.Open();

            MySqlCommand getDataCmd = new MySqlCommand("UserLogin_Check_Match", conn);
            getDataCmd.CommandType = CommandType.StoredProcedure;
            getDataCmd.Parameters.AddWithValue("@UID", email);
            getDataCmd.Parameters.AddWithValue("@PW", password);

            int count = Convert.ToInt32(getDataCmd.ExecuteScalar());

            conn.Close();
            getDataCmd.Dispose();
            return count;
        }
    }
}

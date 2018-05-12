using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using Web.Utils;

namespace Web.Models
{
    public class WebDbContext : DbContext
    {
        public string ConnectionString { get; set; }

        public WebDbContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        // Login data
        public static MySqlDataReader GetLoginData(string userid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("UID", userid));

            DBConn dbconn = new DBConn();
            return dbconn.GetReader("Get_UserLogin_Data", CommandType.StoredProcedure, parameters);
        }

        public static int GetLoginUsername(string userid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("UID", userid));

            DBConn dbconn = new DBConn();
            return dbconn.GetCount("UserLogin_Check_Username", CommandType.StoredProcedure, parameters);
        }

        public static int GetLoginMatch(string userid, string password)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("UID", userid));
            parameters.Add(new MySqlParameter("PW", password));

            DBConn dbconn = new DBConn();
            return dbconn.GetCount("UserLogin_Check_Match", CommandType.StoredProcedure, parameters);
        }

        /*
        public DbSet<UserData> Users { get; set; }
        public DbSet<RegisterData> Registers { get; set; }
        public DbSet<RoomBookingData> RoomBookings { get; set; }
        public DbSet<HallBookingData> HallBookings { get; set; }
        */
    }
}

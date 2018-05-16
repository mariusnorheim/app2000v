using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Web.Models;

namespace Web.Utils
{
    public class WebDbContext : DbContext
    {
        private MySqlConnection conn;
        public string ConnectionString { get; set; }

        public WebDbContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        // User login data
        public MySqlDataReader GetLoginData(UserModel model)
        {
            MySqlConnection conn = GetConnection();
            MySqlCommand getDataCmd = new MySqlCommand("Get_UserLogin_Data", conn);
            getDataCmd.CommandType = CommandType.StoredProcedure;
            getDataCmd.Parameters.AddWithValue("UID", model.Email);

            conn.Open();
            MySqlDataReader reader = getDataCmd.ExecuteReader(CommandBehavior.CloseConnection);

            return reader;
        }

        public int GetLoginUsername(UserModel model)
        {
            using(MySqlConnection conn = GetConnection())
            {
                MySqlCommand getDataCmd = new MySqlCommand("UserLogin_Check_Username", conn);
                getDataCmd.CommandType = CommandType.StoredProcedure;
                getDataCmd.Parameters.AddWithValue("UID", model.Email);

                conn.Open();
                int count = Convert.ToInt32(getDataCmd.ExecuteScalar());
                conn.Close();
                conn.Dispose();

                return count;
            }
        }

        public int LoginValidate(UserModel model)
        {
            using(MySqlConnection conn = GetConnection())
            {
                MySqlCommand getDataCmd = new MySqlCommand("UserLogin_Check_Match", conn);
                getDataCmd.CommandType = CommandType.StoredProcedure;
                getDataCmd.Parameters.AddWithValue("UID", model.Email);
                getDataCmd.Parameters.AddWithValue("PW", model.Password);
                getDataCmd.Parameters.AddWithValue("S", model.Salt);

                conn.Open();
                int count = Convert.ToInt32(getDataCmd.ExecuteScalar());
                conn.Close();
                conn.Dispose();

                return count;
            }
        }

        public void RegisterUser(UserModel model)
        {
            using(MySqlConnection conn = GetConnection())
            {
                MySqlCommand setDataCmd = new MySqlCommand("Set_WebUser_Add", conn);
                setDataCmd.CommandType = CommandType.StoredProcedure;
                setDataCmd.Parameters.AddWithValue("UID", model.Email);
                setDataCmd.Parameters.AddWithValue("PW", model.Password);
                setDataCmd.Parameters.AddWithValue("S", model.Salt);
                setDataCmd.Parameters.AddWithValue("Firstname", model.Firstname);
                setDataCmd.Parameters.AddWithValue("Lastname", model.Lastname);
                setDataCmd.Parameters.AddWithValue("Address", model.Address);
                setDataCmd.Parameters.AddWithValue("City", model.City);
                setDataCmd.Parameters.AddWithValue("Postcode", model.Postcode);
                if(model.Telephone != null)
                    setDataCmd.Parameters.AddWithValue("Telephone", model.Telephone);
                else
                    setDataCmd.Parameters.AddWithValue("Telephone", Convert.DBNull);

                conn.Open();
                setDataCmd.ExecuteNonQuery();
                conn.Close();
            }
        }


        // Booking data
        public List<RoomBookingModel> GetAvailableRooms(RoomBookingModel model)
        {
            List<RoomBookingModel> list = new List<RoomBookingModel>();

            using(MySqlConnection conn = GetConnection())
            {
                MySqlCommand getDataCmd = new MySqlCommand("Get_RR_AvailableRooms", conn);
                getDataCmd.CommandType = CommandType.StoredProcedure;
                getDataCmd.Parameters.Add(new MySqlParameter("RoomTypeID", model.Roomtype));
                getDataCmd.Parameters.Add(new MySqlParameter("dFrom", model.DateFrom.ToShortDateString()));
                getDataCmd.Parameters.Add(new MySqlParameter("dTo", model.DateTo.ToShortDateString()));

                conn.Open();
                using(MySqlDataReader reader = getDataCmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        list.Add(new RoomBookingModel()
                        {
                            RoomID = reader.GetInt32(0)
                        });
                    }
                }
            }

            return list;
        }

        public void RegisterBooking(int guestid, RoomBookingModel model)
        {
            using(MySqlConnection conn = GetConnection())
            {
                MySqlCommand setDataCmd = new MySqlCommand("Set_RR_Add", conn);
                setDataCmd.CommandType = CommandType.StoredProcedure;
                setDataCmd.Parameters.Add(new MySqlParameter("GID", guestid));
                setDataCmd.Parameters.Add(new MySqlParameter("RID", model.RoomID));
                setDataCmd.Parameters.Add(new MySqlParameter("DFrom", model.DateFrom));
                setDataCmd.Parameters.Add(new MySqlParameter("DTo", model.DateTo));
                if(model.Remark != null)
                    setDataCmd.Parameters.Add(new MySqlParameter("Remark", model.Remark));
                else
                    setDataCmd.Parameters.Add(new MySqlParameter("Remark", Convert.DBNull));

                conn.Open();
                setDataCmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}

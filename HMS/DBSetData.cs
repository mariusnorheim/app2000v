using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace HMS
{
    /// <summary>
    /// Adds or updates data with DBconn objects
    /// </summary>
    class DBSetData
    {
        //
        // Booking data
        //
        public static void DeleteRoomReservation(int reservationid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("rrid", reservationid));

            DBConn dbconn = new DBConn();
            dbconn.Execute("DeleteRoomReservation", CommandType.StoredProcedure, parameters);
        }

        public static void CheckkinRoomReservation(int reservationid, String adminid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("rrid", reservationid));
            parameters.Add(new MySqlParameter("aid", adminid));

            DBConn dbconn = new DBConn();
            dbconn.Execute("RR_Checkin", CommandType.StoredProcedure, parameters);
        }

        //
        // Guest data
        //
        public static void AddGuest(string firstname, string lastname, string address, string city, string postcode, string telephone)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("fname", firstname));
            parameters.Add(new MySqlParameter("lname", lastname));
            parameters.Add(new MySqlParameter("addr", address));
            parameters.Add(new MySqlParameter("cty", city));
            parameters.Add(new MySqlParameter("pcode", postcode));
            if (telephone != null) { parameters.Add(new MySqlParameter("tel", telephone)); }
            else { parameters.Add(new MySqlParameter("tel", Convert.DBNull)); }

            DBConn dbconn = new DBConn();
            dbconn.Execute("Set_Guest_Add", CommandType.StoredProcedure, parameters);
        }

        public static void EditGuest(int guestid, string firstname, string lastname, string address, string city, string postcode, string telephone)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("gid", guestid));
            parameters.Add(new MySqlParameter("fname", firstname));
            parameters.Add(new MySqlParameter("lname", lastname));
            parameters.Add(new MySqlParameter("addr", address));
            parameters.Add(new MySqlParameter("cty", city));
            parameters.Add(new MySqlParameter("pcode", postcode));
            if (telephone != null) { parameters.Add(new MySqlParameter("tel", telephone)); }
            else { parameters.Add(new MySqlParameter("tel", Convert.DBNull)); }

            DBConn dbconn = new DBConn();
            dbconn.Execute("Set_Guest_Edit", CommandType.StoredProcedure, parameters);
        }
    }
}

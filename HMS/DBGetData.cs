using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace HMS
{
    /// <summary>
    /// Returns spesific data with DBconn objects
    /// </summary>
    public static class DBGetData
    {
        // QueryID reference for edit forms
        private static int queryID;
        public static int QueryID
        {
            get => queryID;
            set => queryID = value;
        }

        //
        //  Booking data
        //
        public static DataSet GetRoomBookingsAll(int isActive)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("active", isActive));

            DBConn dbconn = new DBConn();
            return dbconn.GetDataSet("GetRoomReservations_All", parameters);
        }

        public static DataSet GetRoomBookingsBetweenDates(DateTime datefrom, DateTime dateto)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("df", datefrom));
            parameters.Add(new MySqlParameter("dt", dateto));

            DBConn dbconn = new DBConn();
            return dbconn.GetDataSet("GetRoomReservations_BetweenDates", parameters);
        }

        public static DataSet GetRoomBookingsSpesificDate(DateTime date)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("ds", date));

            DBConn dbconn = new DBConn();
            return dbconn.GetDataSet("GetRoomReservations_SpesificDate", parameters);
        }

        public static DataSet GetRoomBookingsSearch(string input)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("Search", "%" + input + "%"));

            DBConn dbconn = new DBConn();
            return dbconn.GetDataSet("GetRoomReservations_Search", parameters);
        }

        public static DataSet GetHallBookingsAll(int isActive)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("active", isActive));

            DBConn dbconn = new DBConn();
            return dbconn.GetDataSet("GetHallReservations_All", parameters);
        }

        public static DataSet GetHallBookingsBetweenDates(DateTime datefrom, DateTime dateto)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("df", datefrom));
            parameters.Add(new MySqlParameter("dt", dateto));

            DBConn dbconn = new DBConn();
            return dbconn.GetDataSet("GetHallReservations_BetweenDates", parameters);
        }

        public static DataSet GetHallBookingsSpesificDate(DateTime date)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("ds", date));

            DBConn dbconn = new DBConn();
            return dbconn.GetDataSet("GetHallReservations_SpesificDate", parameters);
        }


        //
        // Guest data
        //
        public static DataSet GetGuestsAll()
        {
            DBConn dbconn = new DBConn();
            return dbconn.GetDataSet("GetGuests_All", null);
        }

        public static DataSet GetGuestsSearch(string input)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("Search", "%" + input + "%"));

            DBConn dbconn = new DBConn();
            return dbconn.GetDataSet("GetGuests_Search", parameters);
        }

        public static List<string> GetGuestData(int guestid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("gid", guestid));

            DBConn dbconn = new DBConn();
            return dbconn.Reader("GetGuestData", parameters);
        }


        //
        // Folio data
        //
        public static DataSet GetFoliosAll(int isActive)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("active", isActive));

            DBConn dbconn = new DBConn();
            return dbconn.GetDataSet("GetFolios_Active", parameters);
        }

        public static DataSet GetFoliosSearch(string input)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("Search", "%" + input + "%"));

            DBConn dbconn = new DBConn();
            return dbconn.GetDataSet("GetFolios_Search", parameters);
        }
    }
}

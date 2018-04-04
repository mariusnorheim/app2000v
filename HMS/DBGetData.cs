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
        // Room booking data
        //
        public static DataSet GetRoomBookingsAll(int isActive)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("active", isActive));

            DBConn dbconn = new DBConn();
            return dbconn.GetDataSet("Get_RR_All", CommandType.StoredProcedure, parameters);
        }

        public static DataSet GetRoomBookingsBetweenDates(DateTime datefrom, DateTime dateto)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("df", datefrom));
            parameters.Add(new MySqlParameter("dt", dateto));

            DBConn dbconn = new DBConn();
            return dbconn.GetDataSet("Get_RR_BetweenDates", CommandType.StoredProcedure, parameters);
        }

        public static DataSet GetRoomBookingsSpesificDate(DateTime date)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("ds", date));

            DBConn dbconn = new DBConn();
            return dbconn.GetDataSet("Get_RR_SpesificDate", CommandType.StoredProcedure, parameters);
        }

        public static DataSet GetRoomBookingsSearch(string input)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("Search", "%" + input + "%"));

            DBConn dbconn = new DBConn();
            return dbconn.GetDataSet("Get_RR_Search", CommandType.StoredProcedure, parameters);
        }

        public static int GetRoomCheckedin(int reservationid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("rrid", reservationid));

            DBConn dbconn = new DBConn();
            return dbconn.Count("RR_Check_Checkedin", CommandType.StoredProcedure, parameters);
        }

        public static MySqlDataReader GetRoomCheckinDate(int reservationid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("rrid", reservationid));

            DBConn dbconn = new DBConn();
            return dbconn.ExecuteReader("RR_Check_CheckinDate", CommandType.StoredProcedure, parameters);
        }

        public static MySqlDataReader GetRoomHousekeeping(int roomid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("rid", roomid));

            DBConn dbconn = new DBConn();
            return dbconn.ExecuteReader("RR_Check_Housekeeping", CommandType.StoredProcedure, parameters);
        }

        //
        // Hall booking data
        //
        public static DataSet GetHallBookingsAll(int isActive)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("active", isActive));

            DBConn dbconn = new DBConn();
            return dbconn.GetDataSet("Get_HR_All", CommandType.StoredProcedure, parameters);
        }

        public static DataSet GetHallBookingsBetweenDates(DateTime datefrom, DateTime dateto)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("df", datefrom));
            parameters.Add(new MySqlParameter("dt", dateto));

            DBConn dbconn = new DBConn();
            return dbconn.GetDataSet("Get_HR_BetweenDates", CommandType.StoredProcedure, parameters);
        }

        public static DataSet GetHallBookingsSpesificDate(DateTime date)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("ds", date));

            DBConn dbconn = new DBConn();
            return dbconn.GetDataSet("Get_HR_SpesificDate", CommandType.StoredProcedure, parameters);
        }


        //
        // Guest data
        //
        public static DataSet GetGuestsAll()
        {
            DBConn dbconn = new DBConn();
            return dbconn.GetDataSet("Get_Guest_All", CommandType.StoredProcedure, null);
        }

        public static DataSet GetGuestsSearch(string input)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("Search", "%" + input + "%"));

            DBConn dbconn = new DBConn();
            return dbconn.GetDataSet("Get_Guest_Search", CommandType.StoredProcedure, parameters);
        }

        public static List<string> GetGuestData(int guestid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("gid", guestid));

            DBConn dbconn = new DBConn();
            return dbconn.Reader("Get_Guest_Data", CommandType.StoredProcedure, parameters);
        }


        //
        // Folio data
        //
        public static DataSet GetFoliosAll(int isActive)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("active", isActive));

            DBConn dbconn = new DBConn();
            return dbconn.GetDataSet("Get_Folio_Active", CommandType.StoredProcedure, parameters);
        }

        public static DataSet GetFoliosSearch(string input)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("Search", "%" + input + "%"));

            DBConn dbconn = new DBConn();
            return dbconn.GetDataSet("Get_Folio_Search", CommandType.StoredProcedure, parameters);
        }
    }
}

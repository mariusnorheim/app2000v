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
            parameters.Add(new MySqlParameter("dFrom", datefrom));
            parameters.Add(new MySqlParameter("dTo", dateto));

            DBConn dbconn = new DBConn();
            return dbconn.GetDataSet("Get_RR_BetweenDates", CommandType.StoredProcedure, parameters);
        }

        public static DataSet GetRoomBookingsSpesificDate(DateTime date)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("dSearch", date));

            DBConn dbconn = new DBConn();
            return dbconn.GetDataSet("Get_RR_SpesificDate", CommandType.StoredProcedure, parameters);
        }

        public static DataSet GetRoomBookingsSearch(string input)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("search", "%" + input + "%"));

            DBConn dbconn = new DBConn();
            return dbconn.GetDataSet("Get_RR_Search", CommandType.StoredProcedure, parameters);
        }

        // Validations
        public static int GetRoomCheckedin(int reservationid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("reservationid", reservationid));

            DBConn dbconn = new DBConn();
            return dbconn.Count("RR_Check_Checkedin", CommandType.StoredProcedure, parameters);
        }

        public static MySqlDataReader GetRoomCheckinDate(int reservationid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("reservationid", reservationid));

            DBConn dbconn = new DBConn();
            return dbconn.Read("RR_Check_CheckinDate", CommandType.StoredProcedure, parameters);
        }

        public static MySqlDataReader GetRoomHousekeeping(int roomid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("rid", roomid));

            DBConn dbconn = new DBConn();
            return dbconn.Read("RR_Check_Housekeeping", CommandType.StoredProcedure, parameters);
        }

        public static int GetRoomCheckedout(int reservationid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("reservationid", reservationid));

            DBConn dbconn = new DBConn();
            return dbconn.Count("RR_Check_Checkedout", CommandType.StoredProcedure, parameters);
        }

        public static MySqlDataReader GetRoomCheckoutDate(int reservationid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("reservationid", reservationid));

            DBConn dbconn = new DBConn();
            return dbconn.Read("RR_Check_CheckoutDate", CommandType.StoredProcedure, parameters);
        }

        public static MySqlDataReader GetRoomMessages(int reservationid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("reservationid", reservationid));

            DBConn dbconn = new DBConn();
            return dbconn.Read("Get_RR_Messages", CommandType.StoredProcedure, parameters);
        }

        public static int GetRoomCount(int reservationid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("reservationid", reservationid));

            DBConn dbconn = new DBConn();
            return dbconn.Count("Get_RR_Roomcount", CommandType.StoredProcedure, parameters);
        }

        public static MySqlDataReader GetRoomCheckoutTotal(int reservationid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("reservationid", reservationid));

            DBConn dbconn = new DBConn();
            return dbconn.Read("RR_Checkout_FolioTotal", CommandType.StoredProcedure, parameters);
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
            parameters.Add(new MySqlParameter("dFrom", datefrom));
            parameters.Add(new MySqlParameter("dTo", dateto));

            DBConn dbconn = new DBConn();
            return dbconn.GetDataSet("Get_HR_BetweenDates", CommandType.StoredProcedure, parameters);
        }

        public static DataSet GetHallBookingsSpesificDate(DateTime date)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("dSearch", date));

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
            parameters.Add(new MySqlParameter("search", "%" + input + "%"));

            DBConn dbconn = new DBConn();
            return dbconn.GetDataSet("Get_Guest_Search", CommandType.StoredProcedure, parameters);
        }

        public static MySqlDataReader GetGuestData(int guestid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("GuestID", guestid));

            DBConn dbconn = new DBConn();
            return dbconn.Read("Get_Guest_Data", CommandType.StoredProcedure, parameters);
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
            parameters.Add(new MySqlParameter("search", "%" + input + "%"));

            DBConn dbconn = new DBConn();
            return dbconn.GetDataSet("Get_Folio_Search", CommandType.StoredProcedure, parameters);
        }
    }
}

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
            parameters.Add(new MySqlParameter("Active", isActive));

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
            parameters.Add(new MySqlParameter("Search", "%" + input + "%"));

            DBConn dbconn = new DBConn();
            return dbconn.GetDataSet("Get_RR_Search", CommandType.StoredProcedure, parameters);
        }

        // Validations
        public static int GetRoomCheckedin(int reservationid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("ReservationID", reservationid));

            DBConn dbconn = new DBConn();
            return dbconn.GetCount("RR_Check_Checkedin", CommandType.StoredProcedure, parameters);
        }

        public static MySqlDataReader GetRoomCheckinDate(int reservationid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("ReservationID", reservationid));

            DBConn dbconn = new DBConn();
            return dbconn.GetReader("RR_Check_CheckinDate", CommandType.StoredProcedure, parameters);
        }

        public static MySqlDataReader GetRoomHousekeeping(int roomid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("rID", roomid));

            DBConn dbconn = new DBConn();
            return dbconn.GetReader("RR_Check_Housekeeping", CommandType.StoredProcedure, parameters);
        }

        public static int GetRoomCheckedout(int reservationid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("ReservationID", reservationid));

            DBConn dbconn = new DBConn();
            return dbconn.GetCount("RR_Check_Checkedout", CommandType.StoredProcedure, parameters);
        }

        public static MySqlDataReader GetRoomCheckoutDate(int reservationid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("ReservationID", reservationid));

            DBConn dbconn = new DBConn();
            return dbconn.GetReader("RR_Check_CheckoutDate", CommandType.StoredProcedure, parameters);
        }

        public static MySqlDataReader GetRoomMessages(int reservationid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("ReservationID", reservationid));

            DBConn dbconn = new DBConn();
            return dbconn.GetReader("Get_RR_Messages", CommandType.StoredProcedure, parameters);
        }

        public static int GetRoomCount(int reservationid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("ReservationID", reservationid));

            DBConn dbconn = new DBConn();
            return dbconn.GetCount("RR_Check_Roomcount", CommandType.StoredProcedure, parameters);
        }

        public static MySqlDataReader GetRoomCheckoutTotal(int reservationid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("ReservationID", reservationid));

            DBConn dbconn = new DBConn();
            return dbconn.GetReader("Get_RR_FolioTotal", CommandType.StoredProcedure, parameters);
        }

        public static DataSet GetGuestList()
        {
            DBConn dbconn = new DBConn();
            return dbconn.GetDataSet("Get_RR_GuestList", CommandType.StoredProcedure);
        }

        public static DataSet GetRoomtypeList()
        {
            DBConn dbconn = new DBConn();
            return dbconn.GetDataSet("Get_RR_RoomtypeList", CommandType.StoredProcedure);
        }

        public static DataSet GetGuestListSearch(string input)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("Search", "%" + input + "%"));

            DBConn dbconn = new DBConn();
            return dbconn.GetDataSet("Get_RR_GuestListSearch", CommandType.StoredProcedure, parameters);
        }

        public static MySqlDataReader GetAvailableRooms(int roomtypeid, string datefrom, string dateto)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("RoomTypeID", roomtypeid));
            parameters.Add(new MySqlParameter("dFrom", datefrom));
            parameters.Add(new MySqlParameter("dTo", dateto));

            DBConn dbconn = new DBConn();
            return dbconn.GetReader("Get_RR_AvailableRooms", CommandType.StoredProcedure, parameters);
        }

        public static MySqlDataReader GetRoomreservationData(int reservationid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("ReservationID", reservationid));

            DBConn dbconn = new DBConn();
            return dbconn.GetReader("Get_RR_Data", CommandType.StoredProcedure, parameters);
        }

        public static MySqlDataReader GetRoomreservationGuest(int reservationid, int guestid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("ReservationID", reservationid));
            parameters.Add(new MySqlParameter("GID", guestid));

            DBConn dbconn = new DBConn();
            return dbconn.GetReader("Get_RR_GuestChange", CommandType.StoredProcedure, parameters);
        }


        //
        // Hall booking data
        //
        public static DataSet GetHallBookingsAll(int isActive)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("Active", isActive));

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
            return dbconn.GetDataSet("Get_Guest_All", CommandType.StoredProcedure);
        }

        public static DataSet GetGuestsSearch(string input)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("Search", "%" + input + "%"));

            DBConn dbconn = new DBConn();
            return dbconn.GetDataSet("Get_Guest_Search", CommandType.StoredProcedure, parameters);
        }

        public static MySqlDataReader GetGuestData(int guestid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("GID", guestid));

            DBConn dbconn = new DBConn();
            return dbconn.GetReader("Get_Guest_Data", CommandType.StoredProcedure, parameters);
        }


        //
        // Folio data
        //
        public static DataSet GetFoliosAll(int isActive)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("Active", isActive));

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

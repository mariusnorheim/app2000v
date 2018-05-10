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

        //UserID reference for user management
        private static string userID;
        public static string UserID
        {
            get => userID;
            set => userID = value;
        }

        //
        // Login data
        //
        public static MySqlDataReader GetLoginData(string userid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("UID", userid));

            DBConn dbconn = new DBConn();
            return dbconn.GetReader("Get_Login_Data", CommandType.StoredProcedure, parameters);
        }

        public static int GetLoginUsername(string userid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("UID", userid));

            DBConn dbconn = new DBConn();
            return dbconn.GetCount("Login_Check_Username", CommandType.StoredProcedure, parameters);
        }

        public static int GetLoginMatch(string userid, string password)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("UID", userid));
            parameters.Add(new MySqlParameter("PW", password));

            DBConn dbconn = new DBConn();
            return dbconn.GetCount("Login_Check_Match", CommandType.StoredProcedure, parameters);
        }

        //
        // Room booking data
        //
        public static DataSet GetRoomBookingDGVAll(int isActive)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("Active", isActive));

            DBConn dbconn = new DBConn();
            return dbconn.GetDataSet("Get_RR_All", CommandType.StoredProcedure, parameters);
        }

        public static DataSet GetRoomBookingDGVBetweenDates(DateTime datefrom, DateTime dateto)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("dFrom", datefrom));
            parameters.Add(new MySqlParameter("dTo", dateto));

            DBConn dbconn = new DBConn();
            return dbconn.GetDataSet("Get_RR_BetweenDates", CommandType.StoredProcedure, parameters);
        }

        public static DataSet GetRoomBookingDGVSpesificDate(DateTime date)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("dSearch", date));

            DBConn dbconn = new DBConn();
            return dbconn.GetDataSet("Get_RR_SpesificDate", CommandType.StoredProcedure, parameters);
        }

        public static DataSet GetRoomBookingDGVSearch(string input)
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
        public static DataSet GetGuestDGVAll()
        {
            DBConn dbconn = new DBConn();
            return dbconn.GetDataSet("Get_Guest_All", CommandType.StoredProcedure);
        }

        public static DataSet GetGuestDGVSearch(string input)
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
        public static DataSet GetFolioDGVAll()
        {
            DBConn dbconn = new DBConn();
            return dbconn.GetDataSet("Get_Folio_Active", CommandType.StoredProcedure);
        }

        public static DataSet GetFolioDGVDue()
        {
            DBConn dbconn = new DBConn();
            return dbconn.GetDataSet("Get_Folio_Due", CommandType.StoredProcedure);
        }

        public static DataSet GetFolioDGVSearch(string input)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("Search", "%" + input + "%"));

            DBConn dbconn = new DBConn();
            return dbconn.GetDataSet("Get_Folio_Search", CommandType.StoredProcedure, parameters);
        }

        public static MySqlDataReader GetFolioData(int folioid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("FID", folioid));

            DBConn dbconn = new DBConn();
            return dbconn.GetReader("Get_Folio_Data", CommandType.StoredProcedure, parameters);
        }

        public static MySqlDataReader GetFolioDueDate(int folioid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("FID", folioid));

            DBConn dbconn = new DBConn();
            return dbconn.GetReader("Folio_Check_DueDate", CommandType.StoredProcedure, parameters);
        }

        public static MySqlDataReader GetFolioPaidDate(int folioid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("FID", folioid));

            DBConn dbconn = new DBConn();
            return dbconn.GetReader("Folio_Check_PaidDate", CommandType.StoredProcedure, parameters);
        }

        public static int GetFolioRoomreservation(int folioid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("FID", folioid));

            DBConn dbconn = new DBConn();
            return dbconn.GetCount("Folio_Check_RoomReservation", CommandType.StoredProcedure, parameters);
        }

        public static int GetFolioHallreservation(int folioid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("FID", folioid));

            DBConn dbconn = new DBConn();
            return dbconn.GetCount("Folio_Check_HallReservation", CommandType.StoredProcedure, parameters);
        }

        public static DataSet GetBillingItemList()
        {
            DBConn dbconn = new DBConn();
            return dbconn.GetDataSet("Get_Folio_BillingItemList", CommandType.StoredProcedure);
        }

        public static int GetFolioExists(int guestid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("GID", guestid));

            DBConn dbconn = new DBConn();
            return dbconn.GetCount("Folio_Check_Exists", CommandType.StoredProcedure, parameters);
        }

        public static MySqlDataReader GetFolioid(int guestid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("GID", guestid));

            DBConn dbconn = new DBConn();
            return dbconn.GetReader("Get_Folio_ID", CommandType.StoredProcedure, parameters);
        }

        public static MySqlDataReader GetFolioGuest(int folioid, int guestid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("FID", folioid));
            parameters.Add(new MySqlParameter("GID", guestid));

            DBConn dbconn = new DBConn();
            return dbconn.GetReader("Get_Folio_GuestChange", CommandType.StoredProcedure, parameters);
        }

        //
        // Todo
        //
        public static DataSet GetTodoDGVActive()
        {
            DBConn dbconn = new DBConn();
            return dbconn.GetDataSet("Get_Todo_Active", CommandType.StoredProcedure);
        }

        public static DataSet GetTodoDGVSearch(string input)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("Search", "%" + input + "%"));

            DBConn dbconn = new DBConn();
            return dbconn.GetDataSet("Get_Todo_Search", CommandType.StoredProcedure, parameters);
        }

        //
        // User
        //
        public static DataSet GetUserDGVActive()
        {
            DBConn dbconn = new DBConn();
            return dbconn.GetDataSet("Get_User_Active", CommandType.StoredProcedure);
        }

        public static DataSet GetUserDGVSearch(string input)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("Search", "%" + input + "%"));

            DBConn dbconn = new DBConn();
            return dbconn.GetDataSet("Get_User_Search", CommandType.StoredProcedure, parameters);
        }

        public static MySqlDataReader GetUserData(string adminid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("AID", adminid));

            DBConn dbconn = new DBConn();
            return dbconn.GetReader("Get_User_Data", CommandType.StoredProcedure, parameters);
        }
    }
}

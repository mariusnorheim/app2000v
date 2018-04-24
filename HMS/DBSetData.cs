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
        public static void RoomreservationDelete(int reservationid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("ReservationID", reservationid));

            DBConn dbconn = new DBConn();
            dbconn.Execute("Set_RR_Inactive", CommandType.StoredProcedure, parameters);
        }

        public static void RoomreservationCheckin(int reservationid, String adminid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("ReservationID", reservationid));
            parameters.Add(new MySqlParameter("AdminID", adminid)); 

            DBConn dbconn = new DBConn();
            dbconn.Execute("RR_Checkin", CommandType.StoredProcedure, parameters);
        }

        public static void RoomreservationCheckout(int reservationid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("ReservationID", reservationid));

            DBConn dbconn = new DBConn();
            dbconn.Execute("RR_Checkout", CommandType.StoredProcedure, parameters);
        }

        public static void RoomreservationUpdateMessages(int reservationid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("ReservationID", reservationid));

            DBConn dbconn = new DBConn();
            dbconn.Execute("Set_RR_Messages_Inactive", CommandType.StoredProcedure, parameters);
        }

        public static void RoomreservationFolioPaid(int reservationid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("ReservationID", reservationid));

            DBConn dbconn = new DBConn();
            dbconn.Execute("Set_RR_FolioPaid", CommandType.StoredProcedure, parameters);
        }

        public static void RoomreservationFolioDue(int reservationid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("ReservationID", reservationid));

            DBConn dbconn = new DBConn();
            dbconn.Execute("Set_RR_FolioDue", CommandType.StoredProcedure, parameters);
        }

        public static void RoomreservationAdd(int guestid, string roomid, string datefrom, string dateto, string remark)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("GID", guestid));
            parameters.Add(new MySqlParameter("RID", roomid));
            parameters.Add(new MySqlParameter("DFrom", datefrom));
            parameters.Add(new MySqlParameter("DTo", dateto));
            if (remark != null) { parameters.Add(new MySqlParameter("Remark", remark)); }
            else { parameters.Add(new MySqlParameter("Remark", Convert.DBNull)); }

            DBConn dbconn = new DBConn();
            dbconn.Execute("Set_RR_Add", CommandType.StoredProcedure, parameters);
        }

        public static void RoomreservationEdit(int reservationid, int guestid, string roomid, string datefrom, string dateto, string remark)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("ReservationID", reservationid));
            parameters.Add(new MySqlParameter("GID", guestid));
            parameters.Add(new MySqlParameter("RID", roomid));
            parameters.Add(new MySqlParameter("DFrom", datefrom));
            parameters.Add(new MySqlParameter("DTo", dateto));
            if (remark != null) { parameters.Add(new MySqlParameter("Remark", remark)); }
            else { parameters.Add(new MySqlParameter("Remark", Convert.DBNull)); }

            DBConn dbconn = new DBConn();
            dbconn.Execute("Set_RR_Edit", CommandType.StoredProcedure, parameters);
        }

        //
        // Guest data
        //
        public static void GuestAdd(string firstname, string lastname, string address, string city, string postcode, string telephone)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("Firstname", firstname));
            parameters.Add(new MySqlParameter("Lastname", lastname));
            parameters.Add(new MySqlParameter("Address", address));
            parameters.Add(new MySqlParameter("City", city));
            parameters.Add(new MySqlParameter("Postcode", postcode));
            if (telephone != null) { parameters.Add(new MySqlParameter("Telephone", telephone)); }
            else { parameters.Add(new MySqlParameter("Telephone", Convert.DBNull)); }

            DBConn dbconn = new DBConn();
            dbconn.Execute("Set_Guest_Add", CommandType.StoredProcedure, parameters);
        }

        public static void GuestEdit(int guestid, string firstname, string lastname, string address, string city, string postcode, string telephone)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("GID", guestid));
            parameters.Add(new MySqlParameter("Firstname", firstname));
            parameters.Add(new MySqlParameter("Lastname", lastname));
            parameters.Add(new MySqlParameter("Address", address));
            parameters.Add(new MySqlParameter("City", city));
            parameters.Add(new MySqlParameter("Postcode", postcode));
            if (telephone != null) { parameters.Add(new MySqlParameter("Telephone", telephone)); }
            else { parameters.Add(new MySqlParameter("Telephone", Convert.DBNull)); }

            DBConn dbconn = new DBConn();
            dbconn.Execute("Set_Guest_Edit", CommandType.StoredProcedure, parameters);
        }

        //
        // Folio data
        //
        public static void FolioPaidDate(int folioid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("FID", folioid));

            DBConn dbconn = new DBConn();
            dbconn.Execute("Set_Folio_PaidDate", CommandType.StoredProcedure, parameters);
        }

        public static void FolioDueDate(int folioid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("FID", folioid));

            DBConn dbconn = new DBConn();
            dbconn.Execute("Set_Folio_DueDate", CommandType.StoredProcedure, parameters);
        }

        public static void FolioAdd(int guestid, string adminid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("GID", guestid));
            parameters.Add(new MySqlParameter("AdminID", adminid));

            DBConn dbconn = new DBConn();
            dbconn.Execute("Set_Folio_Add", CommandType.StoredProcedure, parameters);
        }

        public static void FolioItemAdd(int folioid, int billingitemid, string adminid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("FID", folioid));
            parameters.Add(new MySqlParameter("BIID", billingitemid));
            parameters.Add(new MySqlParameter("AdminID", adminid));

            DBConn dbconn = new DBConn();
            dbconn.Execute("Set_FolioItem_Add", CommandType.StoredProcedure, parameters);
        }
    }
}

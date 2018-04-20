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
            parameters.Add(new MySqlParameter("ReservationID", reservationid));

            DBConn dbconn = new DBConn();
            dbconn.Execute("DeleteRoomReservation", CommandType.StoredProcedure, parameters);
        }

        public static void CheckinRoomReservation(int reservationid, String adminid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("ReservationID", reservationid));
            parameters.Add(new MySqlParameter("AdminID", adminid)); 

            DBConn dbconn = new DBConn();
            dbconn.Execute("RR_Checkin", CommandType.StoredProcedure, parameters);
        }

        public static void UpdateMessagesRoomReservation(int reservationid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("ReservationID", reservationid));

            DBConn dbconn = new DBConn();
            dbconn.Execute("Set_RR_Messages_Inactive", CommandType.StoredProcedure, parameters);
        }

        public static void CheckoutRoomReservation(int reservationid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("ReservationID", reservationid));

            DBConn dbconn = new DBConn();
            dbconn.Execute("RR_Checkout", CommandType.StoredProcedure, parameters);
        }

        public static void CheckoutFolioPaid(int reservationid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("ReservationID", reservationid));

            DBConn dbconn = new DBConn();
            dbconn.Execute("Set_RR_FolioPaid", CommandType.StoredProcedure, parameters);
        }

        public static void CheckoutFolioDue(int reservationid)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("ReservationID", reservationid));

            DBConn dbconn = new DBConn();
            dbconn.Execute("Set_RR_FolioDue", CommandType.StoredProcedure, parameters);
        }


        //
        // Guest data
        //
        public static void AddGuest(string firstname, string lastname, string address, string city, string postcode, string telephone)
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

        public static void EditGuest(int guestid, string firstname, string lastname, string address, string city, string postcode, string telephone)
        {
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("GuestID", guestid));
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
    }
}

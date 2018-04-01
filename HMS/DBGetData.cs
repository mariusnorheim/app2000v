using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace HMS
{
    public class DBGetData
    {
        //
        //  Booking data
        //
        public DataSet GetRoomBookingsAll(int isActive)
        {
            DBConn dbconn = new DBConn();
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("isActive", isActive));

            return dbconn.GetDataSet("GetRoomReservations_All", parameters);
        }

        public DataSet GetRoomBookingsBetweenDates(DateTime datefrom, DateTime dateto)
        {
            DBConn dbconn = new DBConn();
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("dateFrom", datefrom));
            parameters.Add(new MySqlParameter("dateTo", dateto));

            return dbconn.GetDataSet("GetRoomReservations_BetweenDates", parameters);
        }

        public DataSet GetRoomBookingsSpesificDate(DateTime date)
        {
            DBConn dbconn = new DBConn();
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("dateSelected", date));

            return dbconn.GetDataSet("GetRoomReservations_SpesificDate", parameters);
        }

        public DataSet GetHallBookingsAll(int isActive)
        {
            DBConn dbconn = new DBConn();
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("isActive", isActive));

            return dbconn.GetDataSet("GetHallReservations_All", parameters);
        }

        public DataSet GetHallBookingsBetweenDates(DateTime datefrom, DateTime dateto)
        {
            DBConn dbconn = new DBConn();
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("dateFrom", datefrom));
            parameters.Add(new MySqlParameter("dateTo", dateto));

            return dbconn.GetDataSet("GetHallReservations_BetweenDates", parameters);
        }

        public DataSet GetHallBookingsSpesificDate(DateTime date)
        {
            DBConn dbconn = new DBConn();
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("dateSelected", date));

            return dbconn.GetDataSet("GetHallReservations_SpesificDate", parameters);
        }

        //
        // Guest data
        //
        public DataSet GetGuestsAll()
        {
            DBConn dbconn = new DBConn();

            return dbconn.GetDataSet("GetGuests_All", null);
        }

        public DataSet GetGuestsSearch(string search)
        {
            DBConn dbconn = new DBConn();
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("Search", "%" + search + "%"));

            return dbconn.GetDataSet("GetGuests_Search", parameters);
        }

        public void AddGuest(string firstname, string lastname, string address, string city, string postcode, string telephone)
        {
            DBConn dbconn = new DBConn();
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("Firstname", firstname));
            parameters.Add(new MySqlParameter("Lastname", lastname));
            parameters.Add(new MySqlParameter("Address", address));
            parameters.Add(new MySqlParameter("City", city));
            parameters.Add(new MySqlParameter("Postcode", postcode));
            parameters.Add(new MySqlParameter("Telephone", telephone));


            dbconn.Execute("AddGuest", parameters);
        }

        public void EditGuest(int guestid, string firstname, string lastname, string address, string city, string postcode, string telephone)
        {
            DBConn dbconn = new DBConn();
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("Guestid", guestid));
            parameters.Add(new MySqlParameter("Firstname", firstname));
            parameters.Add(new MySqlParameter("Lastname", lastname));
            parameters.Add(new MySqlParameter("Address", address));
            parameters.Add(new MySqlParameter("City", city));
            parameters.Add(new MySqlParameter("Postcode", postcode));
            parameters.Add(new MySqlParameter("Telephone", telephone));


            dbconn.Execute("EditGuest", parameters);
        }

        public List<string>[] GetGuestData(int guestid)
        {
            DBConn dbconn = new DBConn();
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("Guestid", guestid));

            return dbconn.Reader("GetGuestData", parameters);
        }

        //
        // Folio data
        //
        public DataSet GetFoliosAll(int isActive)
        {
            DBConn dbconn = new DBConn();
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("isActive", isActive));

            return dbconn.GetDataSet("GetFolios_Active", parameters);
        }

        public DataSet GetFoliosSearch(string search)
        {
            DBConn dbconn = new DBConn();
            List<DbParameter> parameters = new List<DbParameter>();
            parameters.Add(new MySqlParameter("Search", search));

            return dbconn.GetDataSet("GetFolios_Search", parameters);
        }
    }
}

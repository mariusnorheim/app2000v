using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace HMS
{
    /// <summary>
    /// Adds or updates data with DBconn objects
    /// </summary>
    class DBSetData
    {
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
            dbconn.Execute("AddGuest", parameters);
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
            dbconn.Execute("EditGuest", parameters);
        }
    }
}

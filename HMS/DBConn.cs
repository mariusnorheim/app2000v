using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;

namespace HMS
{
    public class DBConn
    {
        public static string ConnectionString = "server=localhost;uid=root;password=;database=app2000v";
    }
}
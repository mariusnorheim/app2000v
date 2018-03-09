using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Security.Cryptography;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace HMS
{
    class DBConn
    {
        private MySqlConnection conn;
        private string server;
        private string uid;
        private string password;
        private string db;
        protected string query
        {
            get;
            set;
        }

        public string statusmsg
        {
            get;
            set;
        }

        public DBConn()
        {
            Init();
        }

        private void Init()
        {
            // Set database connection values
            server = "localhost";
            uid = "root";
            password = "";
            db = "app2000v";

            // Database connection string
            string connectionString;
            connectionString = "server=" + server + ";uid=" + uid + ";password=" + password + ";database=" + db;

            conn = new MySqlConnection(connectionString);
        }

        // Open database connection
        private bool OpenConnection()
        {
            try
            {
                //MessageBox.Show = "Kobler til MySQL database...";
                conn.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        statusmsg = "Kan ikke koble til MySQL server. Kontakt administrator";
                        break;

                    case 1045:
                        statusmsg = "Ugyldig brukernavn eller passord til MySQL server. Kontakt administrator";
                        break;

                    default:
                        statusmsg = ex.Message;
                        break;
                }
                return false;
            }
        }

        // Close database connection
        private bool CloseConnection()
        {
            try
            {
                conn.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                statusmsg = ex.Message;
                return false;
            }
        }

        // Count statement
        public int Count(string query)
        {
            int Count = -1;

            // Open Connection
            if (this.OpenConnection() == true)
            {
                // Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, conn);
                // ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");
                // Close Connection
                this.CloseConnection();
                return Count;
            }
            else
            {
                return Count;
            }
        }

        private void GetData(string query)
        {
            MySqlDataAdapter da;
            DataSet ds;

            if (this.OpenConnection() == true)
            {
                // Create a new data adapter based on the specified query.
                da = new MySqlDataAdapter(query, conn);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand. These are used to
                // update the database.
                MySqlCommandBuilder cb = new MySqlCommandBuilder(da);

                // Populate a new data table and bind it to the BindingSource.
                ds = new DataSet();
                da.Fill(ds);
                /*
                dataGridView1.DataSource = ds;

                // Resize the DataGridView columns to fit the newly loaded content.
                dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
                */

                // Close connection
                this.CloseConnection();
            }
        }

        // Add a default superuser to the database
        public void AddDefaultSuperUser()
        {
            PasswordHasher pwHasher = new PasswordHasher();
            HashResult hashedPassword = pwHasher.PasswordHash("adminpw321", SHA512.Create());

            query = "INSERT INTO admin (admin_name, admin_username, admin_password, admin_superuser)" +
                "VALUES('Nerd Herd administrator', 'nhadmin', '" + hashedPassword.Digest + "', 'YES');";
            // Open connection
            if (this.OpenConnection() == true)
            {
                // Create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, conn);
                // Execute command
                cmd.ExecuteNonQuery();
                // Close connection
                this.CloseConnection();
            }
        }

    }
}
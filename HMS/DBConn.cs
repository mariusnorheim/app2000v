using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HMS
{
    /// <summary>
    /// Handles database connection and executions
    /// Returns data with option for mysql parameters
    /// </summary>
    public class DBConn
    {
        // MySQL variables
        private MySqlConnection conn;
        private string server;
        private string database;
        private string uid;
        private string password;

        // Temporary
        public static string ConnectionString = "SERVER=localhost;DATABASE=app2000v;UID=root;PASSWORD=;";

        public DBConn()
        {
            Init();
        }

        // Initiate database variables
        private void Init()
        {
            server = "localhost";
            database = "app2000v";
            uid = "root";
            password = "";
            string connectionString = "SERVER=" + server + ";DATABASE=" + database + ";UID=" + uid + ";PASSWORD=" + password;

            conn = new MySqlConnection(connectionString);
        }

        // MySQL open connection
        private bool Connect()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                new StatusMessage(ex.Message);
                return false;
            }
        }

        // MySQL close connection
        private bool Disconnect()
        {
            try
            {
                conn.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                new StatusMessage(ex.Message);
                return false;
            }
            // Dispose connection
            finally
            {
                conn.Dispose();
            }
        }

        // Return dataset from MySQL query
        // @param1: Query to be executed
        // @param2: CommandType
        // @param2: List of parameters
        public DataSet GetDataSet(string query, CommandType commandType, List<DbParameter> parameters = null)
        {
            // No MySQL connection could be made
            if (Connect() == false) { return null; }

            MySqlCommand getDataCmd = new MySqlCommand(query, conn);
            getDataCmd.CommandType = commandType;

            if (parameters != null)
            {
                foreach (DbParameter parameter in parameters)
                {
                    // Do type selection from .net types to selecte correct MySqlDbType
                    if (parameter.Value is string)
                    {
                        getDataCmd.Parameters.Add(parameter.ParameterName, MySqlDbType.VarChar).Value = parameter.Value;
                    }
                    else if (parameter.Value is byte)
                    {
                        getDataCmd.Parameters.Add(parameter.ParameterName, MySqlDbType.Byte).Value = parameter.Value;
                    }
                    else if (parameter.Value is short)
                    {
                        getDataCmd.Parameters.Add(parameter.ParameterName, MySqlDbType.Int16).Value = parameter.Value;
                    }
                    else if (parameter.Value is int)
                    {
                        getDataCmd.Parameters.Add(parameter.ParameterName, MySqlDbType.Int32).Value = parameter.Value;
                    }
                    else if (parameter.Value is long)
                    {
                        getDataCmd.Parameters.Add(parameter.ParameterName, MySqlDbType.Int64).Value = parameter.Value;
                    }
                    else if (parameter.Value is decimal)
                    {
                        getDataCmd.Parameters.Add(parameter.ParameterName, MySqlDbType.Decimal).Value = parameter.Value;
                    }
                    else if (parameter.Value is DateTime)
                    {
                        getDataCmd.Parameters.Add(parameter.ParameterName, MySqlDbType.DateTime).Value = parameter.Value;
                    }
                    else if (parameter.Value is bool)
                    {
                        getDataCmd.Parameters.Add(parameter.ParameterName, MySqlDbType.Bit).Value = parameter.Value;
                    }
                    else if (parameter.Value is TimeSpan)
                    {
                        getDataCmd.Parameters.Add(parameter.ParameterName, MySqlDbType.Time).Value = parameter.Value;
                    }
                    else if (parameter.Value == Convert.DBNull)
                    {
                        getDataCmd.Parameters.Add(parameter.ParameterName, MySqlDbType.VarChar).Value = Convert.DBNull;
                    }
                }
            }

            MySqlDataAdapter getDataAdapter = new MySqlDataAdapter(getDataCmd);
            DataSet getDataset = new DataSet();

            try
            {
                // Fill adapter for use on DataGridView
                getDataAdapter.Fill(getDataset, query);
            }
            // Catch exceptions and display in labelStatus
            catch (MySqlException ex)
            {
                new StatusMessage(ex.Message);
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                Disconnect();
                getDataCmd.Dispose();
                getDataAdapter.Dispose();
            }

            return getDataset;
        }


        // Return MySqlDataReader results from MySQL query
        // @param1: Query to be executed
        // @param2: CommandType
        // @param3: List of parameters
        public MySqlDataReader GetReader(string query, CommandType commandType, List<DbParameter> parameters = null)
        {
            // No MySQL connection could be made
            if (Connect() == false) { return null; }

            MySqlCommand getDataCmd = new MySqlCommand(query, conn);
            getDataCmd.CommandType = commandType;

            if (parameters != null)
            {
                foreach (DbParameter parameter in parameters)
                {
                    // Do type selection from .net types to selecte correct MySqlDbType
                    if (parameter.Value is string)
                    {
                        getDataCmd.Parameters.Add(parameter.ParameterName, MySqlDbType.VarChar).Value = parameter.Value;
                    }
                    else if (parameter.Value is byte)
                    {
                        getDataCmd.Parameters.Add(parameter.ParameterName, MySqlDbType.Byte).Value = parameter.Value;
                    }
                    else if (parameter.Value is short)
                    {
                        getDataCmd.Parameters.Add(parameter.ParameterName, MySqlDbType.Int16).Value = parameter.Value;
                    }
                    else if (parameter.Value is int)
                    {
                        getDataCmd.Parameters.Add(parameter.ParameterName, MySqlDbType.Int32).Value = parameter.Value;
                    }
                    else if (parameter.Value is long)
                    {
                        getDataCmd.Parameters.Add(parameter.ParameterName, MySqlDbType.Int64).Value = parameter.Value;
                    }
                    else if (parameter.Value is decimal)
                    {
                        getDataCmd.Parameters.Add(parameter.ParameterName, MySqlDbType.Decimal).Value = parameter.Value;
                    }
                    else if (parameter.Value is DateTime)
                    {
                        getDataCmd.Parameters.Add(parameter.ParameterName, MySqlDbType.DateTime).Value = parameter.Value;
                    }
                    else if (parameter.Value is bool)
                    {
                        getDataCmd.Parameters.Add(parameter.ParameterName, MySqlDbType.Bit).Value = parameter.Value;
                    }
                    else if (parameter.Value is TimeSpan)
                    {
                        getDataCmd.Parameters.Add(parameter.ParameterName, MySqlDbType.Time).Value = parameter.Value;
                    }
                    else if (parameter.Value == Convert.DBNull)
                    {
                        getDataCmd.Parameters.Add(parameter.ParameterName, MySqlDbType.VarChar).Value = Convert.DBNull;
                    }
                }
            }

            // Do not dispose, need to keep until result is read
            MySqlDataReader getResult = getDataCmd.ExecuteReader(CommandBehavior.CloseConnection);

            try
            {
                // Return reader results
                return getResult;
            }

            // Catch exceptions and display in labelStatus
            catch (MySqlException ex)
            {
                new StatusMessage(ex.Message);
                return null;
            }
        }


        // Return count of rows matched from MySQL query
        // @param1: Query to be executed
        // @param2: CommandType
        // @param3: List of parameters
        public int GetCount(string query, CommandType commandType, List<DbParameter> parameters = null)
        {
            // No MySQL connection could be made
            if (Connect() == false) { return 0; }

            MySqlCommand getDataCmd = new MySqlCommand(query, conn);
            getDataCmd.CommandType = commandType;

            if (parameters != null)
            {
                foreach (DbParameter parameter in parameters)
                {
                    // Do type selection from .net types to selecte correct MySqlDbType
                    if (parameter.Value is string)
                    {
                        getDataCmd.Parameters.Add(parameter.ParameterName, MySqlDbType.VarChar).Value = parameter.Value;
                    }
                    else if (parameter.Value is byte)
                    {
                        getDataCmd.Parameters.Add(parameter.ParameterName, MySqlDbType.Byte).Value = parameter.Value;
                    }
                    else if (parameter.Value is short)
                    {
                        getDataCmd.Parameters.Add(parameter.ParameterName, MySqlDbType.Int16).Value = parameter.Value;
                    }
                    else if (parameter.Value is int)
                    {
                        getDataCmd.Parameters.Add(parameter.ParameterName, MySqlDbType.Int32).Value = parameter.Value;
                    }
                    else if (parameter.Value is long)
                    {
                        getDataCmd.Parameters.Add(parameter.ParameterName, MySqlDbType.Int64).Value = parameter.Value;
                    }
                    else if (parameter.Value is decimal)
                    {
                        getDataCmd.Parameters.Add(parameter.ParameterName, MySqlDbType.Decimal).Value = parameter.Value;
                    }
                    else if (parameter.Value is DateTime)
                    {
                        getDataCmd.Parameters.Add(parameter.ParameterName, MySqlDbType.DateTime).Value = parameter.Value;
                    }
                    else if (parameter.Value is bool)
                    {
                        getDataCmd.Parameters.Add(parameter.ParameterName, MySqlDbType.Bit).Value = parameter.Value;
                    }
                    else if (parameter.Value is TimeSpan)
                    {
                        getDataCmd.Parameters.Add(parameter.ParameterName, MySqlDbType.Time).Value = parameter.Value;
                    }
                    else if (parameter.Value == Convert.DBNull)
                    {
                        getDataCmd.Parameters.Add(parameter.ParameterName, MySqlDbType.VarChar).Value = Convert.DBNull;
                    }
                }
            }

            int count;

            try
            {
                // Fetch number of rows matched
                count = Convert.ToInt32(getDataCmd.ExecuteScalar());
            }
            // Catch exceptions and display in labelStatus
            catch (MySqlException ex)
            {
                new StatusMessage(ex.Message);
                return 0;
            }
            finally
            {
                Disconnect();
                getDataCmd.Dispose();
            }

            return count;
        }


        // Executes MySQL query
        // @param1: Query to be executed
        // @param2: CommandType
        // @param3: List of parameters
        public void Execute(string query, CommandType commandType, List<DbParameter> parameters = null)
        {
            // No MySQL connection could be made
            if (Connect() == false) { MessageBox.Show("Database connection failed."); }

            MySqlCommand setDataCmd = new MySqlCommand(query, conn);
            setDataCmd.CommandType = commandType;

            if (parameters != null)
            {
                foreach (DbParameter parameter in parameters)
                {
                    // Do type selection from .net types to selecte correct MySqlDbType
                    if (parameter.Value is string)
                    {
                        setDataCmd.Parameters.Add(parameter.ParameterName, MySqlDbType.VarChar).Value = parameter.Value;
                    }
                    else if (parameter.Value is byte)
                    {
                        setDataCmd.Parameters.Add(parameter.ParameterName, MySqlDbType.Byte).Value = parameter.Value;
                    }
                    else if (parameter.Value is short)
                    {
                        setDataCmd.Parameters.Add(parameter.ParameterName, MySqlDbType.Int16).Value = parameter.Value;
                    }
                    else if (parameter.Value is int)
                    {
                        setDataCmd.Parameters.Add(parameter.ParameterName, MySqlDbType.Int32).Value = parameter.Value;
                    }
                    else if (parameter.Value is long)
                    {
                        setDataCmd.Parameters.Add(parameter.ParameterName, MySqlDbType.Int64).Value = parameter.Value;
                    }
                    else if (parameter.Value is decimal)
                    {
                        setDataCmd.Parameters.Add(parameter.ParameterName, MySqlDbType.Decimal).Value = parameter.Value;
                    }
                    else if (parameter.Value is DateTime)
                    {
                        setDataCmd.Parameters.Add(parameter.ParameterName, MySqlDbType.DateTime).Value = parameter.Value;
                    }
                    else if (parameter.Value is bool)
                    {
                        setDataCmd.Parameters.Add(parameter.ParameterName, MySqlDbType.Bit).Value = parameter.Value;
                    }
                    else if (parameter.Value is TimeSpan)
                    {
                        setDataCmd.Parameters.Add(parameter.ParameterName, MySqlDbType.Time).Value = parameter.Value;
                    }
                    else if (parameter.Value == Convert.DBNull)
                    {
                        setDataCmd.Parameters.Add(parameter.ParameterName, MySqlDbType.VarChar).Value = Convert.DBNull;
                    }
                }
            }

            try
            {
                // Execute
                setDataCmd.ExecuteNonQuery();
            }
            // Catch exceptions and display in labelStatus
            catch (MySqlException ex)
            {
                new StatusMessage(ex.Message);
            }
            finally
            {
                Disconnect();
                setDataCmd.Dispose();
            }
        }
    }
}
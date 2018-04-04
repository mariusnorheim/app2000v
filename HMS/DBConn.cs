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

        // Temporary (used in code)
        public static string ConnectionString = "SERVER=localhost;DATABASE=app2000v;UID=root;PASSWORD=";

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

        // Return dataset from MySQL stored procedure
        // @param1: Stored Procedure name to be executed
        // @param2: List of parameters related to query
        public DataSet GetDataSet(string procedureName, List<DbParameter> parameters = null)
        {
            // No MySQL connection could be made
            if (Connect() == false) { return null; }

            MySqlCommand getDataCmd = new MySqlCommand(procedureName, conn);
            getDataCmd.CommandType = System.Data.CommandType.StoredProcedure;

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
                getDataAdapter.Fill(getDataset, procedureName);
                Disconnect();
            }
            // Catch exceptions and display in labelStatus
            catch (MySqlException ex)
            {
                //UserInterface uiForm = (UserInterface)Application.OpenForms["UserInterface"];
                //uiForm.labelStatus.Text = ex.Message;
                new StatusMessage(ex.Message);
                return null;
            }
            finally
            {
                getDataCmd.Dispose();
                getDataAdapter.Dispose();
            }

            return getDataset;
        }

        // Return list of reader results from MySQL stored procedure
        // @param1: Stored Procedure name to be executed
        // @param2: List of parameters related to query
        public List<string> Reader(string procedureName, List<DbParameter> parameters = null)
        {
            // No MySQL connection could be made
            if (Connect() == false) { return null; }

            MySqlCommand getDataCmd = new MySqlCommand(procedureName, conn);
            getDataCmd.CommandType = System.Data.CommandType.StoredProcedure;

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

            MySqlDataReader getDataResult = getDataCmd.ExecuteReader();
            List<string> resultList = new List<string>();

            try
            {
                // Fetch result in reader
                while (getDataResult.Read())
                {
                    for (int i = 0; i < getDataResult.FieldCount; i++)
                    {
                        if (getDataResult.GetValue(i) == null || getDataResult.GetValue(i) == DBNull.Value)  { resultList.Add(string.Empty); }
                        else { resultList.Add((string)getDataResult.GetValue(i)); }
                    }
                }

                getDataResult.Close();
                Disconnect();
            }

            // Catch exceptions and display in labelStatus
            catch (MySqlException ex)
            {
                //UserInterface uiForm = (UserInterface)Application.OpenForms["UserInterface"];
                //uiForm.labelStatus.Text = ex.Message;
                new StatusMessage(ex.Message);
                return null;
            }
            finally
            {
                getDataCmd.Dispose();
                getDataResult.Dispose();
            }

            return resultList;
        }

        // Return count of rows matched from MySQL stored procedure
        // @param1: Stored Procedure name to be executed
        // @param2: List of parameters related to query
        public int Count(string procedureName, List<DbParameter> parameters = null)
        {
            // No MySQL connection could be made
            if (Connect() == false) { return 0; }

            MySqlCommand getDataCmd = new MySqlCommand(procedureName, conn);
            getDataCmd.CommandType = System.Data.CommandType.StoredProcedure;

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
                Disconnect();
            }
            // Catch exceptions and display in labelStatus
            catch (MySqlException ex)
            {
                //UserInterface uiForm = (UserInterface)Application.OpenForms["UserInterface"];
                //uiForm.labelStatus.Text = ex.Message;
                new StatusMessage(ex.Message);
                return 0;
            }
            finally
            {
                getDataCmd.Dispose();
            }

            return count;
        }

        // Executes stored procedure into SQL
        // @param1: Stored Procedure name to be executed
        // @param2: List of parameters related to query
        public void Execute(string procedureName, List<DbParameter> parameters = null)
        {
            // No MySQL connection could be made
            if (Connect() == false) { MessageBox.Show("Database connection failed."); }

            MySqlCommand setDataCmd = new MySqlCommand(procedureName, conn);
            setDataCmd.CommandType = System.Data.CommandType.StoredProcedure;

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
                // Execute procedure
                setDataCmd.ExecuteNonQuery();
                Disconnect();
            }
            // Catch exceptions and display in labelStatus
            catch (MySqlException ex)
            {
                //UserInterface uiForm = (UserInterface)Application.OpenForms["UserInterface"];
                //uiForm.labelStatus.Text = ex.Message;
                new StatusMessage(ex.Message);
            }
            finally
            {
                setDataCmd.Dispose();
            }
        }


    }
}
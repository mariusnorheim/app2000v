﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HMS
{
    public class DBConn
    {
        // MySQL variables
        private MySqlConnection conn;
        private string server;
        private string database;
        private string uid;
        private string password;

        // QueryID variable - temporary
        private static int queryID;

        // Temporary (used in code)
        public static string ConnectionString = "SERVER=localhost;DATABASE=app2000v;UID=root;PASSWORD=";

        public DBConn()
        {
            Init();
        }

        private void Init()
        {
            server = "localhost";
            database = "app2000v";
            uid = "root";
            password = "";
            string connectionString = "SERVER=" + server + ";DATABASE=" + database + ";UID=" + uid + ";PASSWORD=" + password;

            conn = new MySqlConnection(connectionString);
        }

        // QueryID reference for edit forms
        // TODO: make non-static
        public static int QueryID
        {
            get => queryID;
            set => queryID = value;
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
                MessageBox.Show(string.Format("An exception of type {0} was generated while performing your SQL operation. The error message returned was {1}",
                    ex.GetType(),
                    ex.Message));
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
                MessageBox.Show(ex.Message);
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
            if (Connect() == true)
            {
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
                    MessageBox.Show(ex.Message);
                    return null;
                }
                finally
                {
                    getDataCmd.Dispose();
                    getDataAdapter.Dispose();
                }

                return getDataset;
            }
            // No MySQL connection could be made
            else { return null; }
        }

        // Return list of reader results from MySQL stored procedure
        // @param1: Stored Procedure name to be executed
        // @param2: List of parameters related to query
        public List<string>[] Reader(string procedureName, List<DbParameter> parameters = null)
        {
            if (Connect() == true)
            {
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
                Object[] getValues = new Object[getDataResult.FieldCount];
                int fieldCount = getDataResult.GetValues(getValues);
                List<string>[] resultList = new List<string>[fieldCount];

                try
                {
                    // Fetch result in reader
                    while (getDataResult.Read())
                    {
                        for (int i = 0; i < fieldCount; i++)
                        {
                            // TODO: all objects return null
                            resultList[i].Add((string)getValues[i]);
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
                    MessageBox.Show(ex.Message);
                    return null;
                }
                finally
                {
                    getDataCmd.Dispose();
                    getDataResult.Dispose();
                }

                return resultList;
            }
            // No MySQL connection could be made
            else { return null; }
        }

        // Return count of rows matched from MySQL stored procedure
        // @param1: Stored Procedure name to be executed
        // @param2: List of parameters related to query
        public int Count(string procedureName, List<DbParameter> parameters = null)
        {
            if (Connect() == true)
            {
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
                    MessageBox.Show(ex.Message);
                    return 0;
                }
                finally
                {
                    getDataCmd.Dispose();
                }

                return count;
            }
            // No MySQL connection could be made
            else { return 0; }
        }

        // Executes stored procedure into SQL
        // @param1: Stored Procedure name to be executed
        // @param2: List of parameters related to query
        public void Execute(string procedureName, List<DbParameter> parameters = null)
        {
            if (Connect() == true)
            {
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
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    setDataCmd.Dispose();
                }

            }
        }

        // Begin database transactions
        // Returns MySqlTransaction object
        // @param1:
        public MySqlTransaction BeginTransaction()
        {
            if (Connect() == true)
            {
                try
                {
                    // Return object and close connection
                    return conn.BeginTransaction();
                }

                catch (MySqlException ex)
                {
                    MessageBox.Show(string.Format(
                        "An exception of type {0} was generated while beginning your transaction. The error message returned was {1}",
                        ex.GetType(),
                        ex.Message));
                    return null;
                }
            }
            // No MySQL connection could be made
            else { return null; }
        }

        // Commit the specified MySqlTransaction object
        // @param1: MySqlTransaction object
        public bool CommitTransaction(MySqlTransaction transaction)
        {
            try
            {
                // Make sure MySqlTransaction still exists
                if (transaction != null)
                {
                    // Make sure our connection for our transaction hasnt been terminated
                    if ((transaction.Connection != null) && (transaction.Connection.State == ConnectionState.Open))
                        transaction.Commit();
                    else
                    {
                        DBException dbexception = new DBException();
                        dbexception.ThrowSQLException();
                        return false;
                    }
                }
                else
                {
                    // Raise an error (since we cannot throw a MySqlException)
                    DBException dbexception = new DBException();
                    dbexception.ThrowSQLException();
                    return false;
                }


                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("An exception of type {0} was encountered when trying to commit the transaction and an error message of {1} was generated",
                    ex.GetType(),
                    ex.Message);
                return false;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(string.Format("An invalid operation was performed. The error message gereerated is {0}", ex.Message));
                return false;
            }
        }

        // Roll back the specified MySqlTransaction object if something went wrong
        private bool RollbackTransaction(ref MySqlTransaction transaction)
        {
            try
            {
                if (transaction != null)
                {
                    if ((transaction.Connection != null) && (transaction.Connection.State == ConnectionState.Open))
                        transaction.Rollback();
                    else
                    {
                        DBException dbexception = new DBException();
                        dbexception.ThrowSQLException();
                        return false;
                    }
                }
                else
                {
                    // Raise an error (since we cannot throw a MySqlException)
                    DBException dbexception = new DBException();
                    dbexception.ThrowSQLException();
                }

                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(string.Format("An exception of type {0} was generated while attepting to rollback the transaction. The error message generated is {1}",
                    ex.GetType(), ex.Message));
                return false;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(string.Format("An invalid operation was performed. The error message gereerated is {0}", ex.Message));
                return false;
            }
            finally
            {
                if (transaction.Connection.State == ConnectionState.Open)
                    transaction.Connection.Close();

                transaction.Dispose();
            }
        }


    }
}
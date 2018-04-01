using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HMS
{
    class DBException
    {
        //private UserInterface uiForm = (UserInterface) Application.OpenForms["UserInterface"];

        // Throws MySQLException using the RAISERROR function in the server
        public void ThrowSQLException()
        {
            MySqlCommand exCmd = null;
            try
            {
                exCmd = new MySqlCommand("raiserror('Transaction could not be found', 16,1)");
                exCmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                //uiForm.labelStatus.Text
                MessageBox.Show(string.Format("An exception of type {0} has been generated. The error message generated in {1}",
                    ex.GetType(),
                    ex.Message));
            }
            finally { exCmd.Dispose(); }
        }
    }

}

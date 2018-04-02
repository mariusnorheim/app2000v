using System.Windows.Forms;

namespace HMS
{
    /// <summary>
    /// Displays status message in labelStatus
    /// </summary>
    public class StatusMessage
    {
        UserInterface uiForm = (UserInterface)Application.OpenForms["UserInterface"];

        public StatusMessage(string msg)
        {
            uiForm.labelStatusMessage.Text = msg;
        }
    }
}

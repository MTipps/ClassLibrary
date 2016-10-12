using System.Windows.Forms;

namespace ClassLibrary.Classes
{
    public class ControlsHelper
    {
        #region Methods

        // This will clear all text from Textboxes on the panel
        public static void ClearTextFieldsOnPanel(Panel pan)
        {
            foreach (Control ctrl in pan.Controls)
            {
                if (ctrl.Name.Contains("txt"))
                {
                    ctrl.Text = "";
                }
            }
        }

        #endregion Methods

    }
}
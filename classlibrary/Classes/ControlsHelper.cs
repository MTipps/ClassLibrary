using System.Windows.Forms;

namespace ClassLibrary.Classes
{
    /// <summary>
    /// A class to support all control functions. For example clearing a bunch of textboxes.
    /// </summary>
    public class ControlsHelper
    {
        #region Methods

        /// <summary>
        /// This will clear all text from Textboxes on the panel
        /// </summary>
        /// <param name="pan">The panel that has textboxes that need clearing</param>
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
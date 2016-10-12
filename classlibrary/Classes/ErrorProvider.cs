using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassLibrary
{
    public class ErrorProvider
    {
        #region Methods
            // Function will return an error provider with the correct icon for when the a correct or incorrect validation
            public static System.Windows.Forms.ErrorProvider SetErrorProvider(string errorMessage)
            {
                System.Windows.Forms.ErrorProvider newProvider = new System.Windows.Forms.ErrorProvider();

                // If the error message is empty then we show the icon that says it is correct
                // otherwise we show a warning
                if (errorMessage == "Correct")
                {
                    newProvider.Icon = Properties.Resources.checkmark16;
                    newProvider.Tag = "True";
                }
                else
                {
                    newProvider.Icon = Properties.Resources.error16;
                    newProvider.Tag = "False";
                }

                newProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;

                return newProvider;
            }
        #endregion        
    }
}

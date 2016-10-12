using System.Windows.Forms;

namespace ClassLibrary
{
    /// <summary>
    /// A custom error provider class to have a custom icon, instead of the old and boring windows image
    /// </summary>
    public class ErrorProvider
    {
        #region Variables

        private static System.Drawing.Icon _iconTrue;
        private static System.Drawing.Icon _iconFalse;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// The constructor needs images for the the true and false of the error provider
        /// </summary>
        /// <param name="iconTrue"></param>
        /// <param name="iconFalse"></param>
        public ErrorProvider(System.Drawing.Icon iconTrue, System.Drawing.Icon iconFalse)
        {
            _iconTrue = iconTrue;
            _iconFalse = iconFalse;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Function will return an error provider with the correct icon for when the validationis correct or incorrect
        /// </summary>
        /// <param name="errorMessage">Validation done on the following text:
        ///                            - Correct: The true message and icon will be shown
        ///                            - Anything Other Text: the false message and icon will be shown</param>
        /// <returns>Returns the updated error provider</returns>
        public static System.Windows.Forms.ErrorProvider SetErrorProvider(string errorMessage)
        {
            System.Windows.Forms.ErrorProvider newProvider = new System.Windows.Forms.ErrorProvider();

            // If the error message is empty then we show the icon that says it is correct
            // otherwise we show a warning
            if (errorMessage == "Correct")
            {
                newProvider.Icon = _iconTrue;
                newProvider.Tag = "True";
            }
            else
            {
                newProvider.Icon = _iconFalse;
                newProvider.Tag = "False";
            }

            newProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            return newProvider;
        }

        #endregion Methods
    }
}
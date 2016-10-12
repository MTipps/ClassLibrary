using System;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace ClassLibrary
{
    /// <summary>
    /// All general validation that we use everyday can be found in this class. A message will be returned to be used with the custom error provider.
    /// </summary>
    public class GeneralValidation
    {
        #region Methods

        /// <summary>
        /// Check if string only contains letters
        /// </summary>
        /// <param name="value">The string that needs to be validated</param>
        /// <returns>A message according to the validation</returns>
        public static string ValidateOnlyString(string value)
        {
            if (Regex.IsMatch(value, @"^[a-zA-Z]+$")) { return "Correct"; }
            return "Only letters are allowed.";
        }

        /// <summary>
        /// Check if string only contains numbers
        /// </summary>
        /// <param name="value">The string that needs to be validated</param>
        /// <returns>A message according to the validation</returns>
        public static string ValidateOnlyNumbers(string value)
        {
            if (value.All(Char.IsDigit)) { return "Correct"; }
            return "Only Numbers are allowed.";
        }

        /// <summary>
        /// Check if email is in the correct format
        /// </summary>
        /// <param name="value">The email that needs to be validated</param>
        /// <returns>A message according to the validation</returns>
        public static string ValidateEmail(string value)
        {
            try
            {
                MailAddress m = new MailAddress(value);
                return "Correct";
            }
            catch (FormatException)
            {
                return "Format of email address is incorrect.";
            }
        }

        #endregion Methods
    }
}
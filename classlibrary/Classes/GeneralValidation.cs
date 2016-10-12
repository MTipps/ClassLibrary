/* 
 * All general validation that we use everyday can be found in this class. A message will be returned to be used with the 
 * custom error provider.
 */

using System;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace ClassLibrary
{
    public class GeneralValidation
    {
        #region Methods

        // Check if string only contains letters
        public static string ValidateOnlyString(string value)
        {
            if (Regex.IsMatch(value, @"^[a-zA-Z]+$")) { return "Correct"; }
            return "Only letters are allowed.";
        }

        // Check if string only contains numbers
        public static string ValidateOnlyNumbers(string value)
        {
            if (value.All(Char.IsDigit)) { return "Correct"; }
            return "Only Numbers are allowed.";
        }

        // Check if email is in the correct format
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
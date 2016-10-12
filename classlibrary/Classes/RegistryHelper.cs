using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace ClassLibrary.Classes
{
    /// <summary>
    /// A class to easily read and write to a registry key
    /// </summary>
    internal class RegistryHelper
    {
        #region Methods

        /// <summary>
        /// Save details to the registry.
        /// </summary>
        /// <param name="registryKey">The whole key where the data should be stored</param>
        /// <param name="valueName">The name in the registry key</param>
        /// <param name="value">The value that needs to be saved</param>
        /// <returns>Returns a boolean value if according to validation</returns>
        public static bool AddToRegistry(string registryKey, string valueName, string value)
        {
            try
            {
                RegistryKey myReg = Registry.CurrentUser.CreateSubKey("registryKey");
                myReg.SetValue(valueName, value);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error saving details to registry: " + Environment.NewLine + e.Message, "Error - Registry Save", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        /// <summary>
        /// Reads the values from the registry key
        /// </summary>
        /// <param name="registryKey">The whole key where the data is stored</param>
        /// <param name="valueName">The name in the registry key</param>
        /// <returns>The registry key value</returns>
        public static string ReadFromRegistry(string registryKey, string valueName)
        {
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(registryKey);
            return (string)regKey.GetValue(valueName);
        }

        #endregion Methods
    }
}
/* 
 * A class to easily read and write to a registry key
 */

using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace ClassLibrary.Classes
{
    internal class RegistryHelper
    {
        #region Methods

        // Save details to the registry.
        // string registryKey: The whole key where the data should be stored
        // string valueName: The name in the registry key
        // string value: The actual value that needs to be saved
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

        // Reads the values from the registry key
        // string registryKey: The whole key where the data is stored
        // string valueName: The name in the registry key
        public static string ReadFromRegistry(string registryKey, string valueName)
        {
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey(registryKey);
            return (string)regKey.GetValue(valueName);
        }

        #endregion Methods
    }
}
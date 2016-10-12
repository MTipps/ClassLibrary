using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ClassLibrary.Forms
{
    public partial class frmSQLServer : Form
    {
        #region Variables
            private string _registryKey;
        #endregion

        #region Constructor
            // string registryKey: The registry key where the database information is stored
            public frmSQLServer(string registryKey)
            {
                InitializeComponent();
                _registryKey = registryKey;
            }
        #endregion

        #region Events
            // When the form opens all the server names located on the network will be added to the drop down list
            private void frmSQLServer_Load(object sender, EventArgs e)
            {
                LoadServerNames();
                SetIfRegistryNotEmpty();
            }

            private void btnSave_Click(object sender, EventArgs e)
            {                
                if (Classes.RegistryHelper.AddToRegistry(_registryKey, "ServerName", ClassLibrary.Classes.Encryption.Encrypt(cbServerName.Text)))
                {
                    if (Classes.RegistryHelper.AddToRegistry(_registryKey, "DatabaseName", ClassLibrary.Classes.Encryption.Encrypt(cbDBName.Text)))
                    {
                        this.Close();
                    }
                }
            }

            // When a server name has been selected a list of all the databases 
            // on that server will be added to the drop down list.
            private void cbServerName_SelectedIndexChanged(object sender, EventArgs e)
            {
                LoadDatabaseNames();
            }
        #endregion

        #region Methods
            // Retrieves a list of server names
            private void LoadServerNames()
            {
                DataTable dt = System.Data.Sql.SqlDataSourceEnumerator.Instance.GetDataSources();

                foreach (DataRow server in dt.Rows)
                {
                    cbServerName.Items.Add(server[dt.Columns["ServerName"]].ToString());
                }
            }

            // Retrieves a list of database names from the selected server
            private void LoadDatabaseNames()
            {
                using (var con = new SqlConnection("Data Source=" + cbServerName.Text + "; Integrated Security=True;"))
                {
                    con.Open();
                    DataTable databases = con.GetSchema("Databases");
                    foreach (DataRow db in databases.Rows)
                    {
                        cbDBName.Items.Add(db.Field<String>("database_name"));

                    }
                }
            }

            // Retrieves the saved database details from the registry and selects the correct options 
            // from the drop down list
            private void SetIfRegistryNotEmpty()
            {
                cbServerName.Text = Classes.RegistryHelper.ReadFromRegistry(_registryKey, "ServerName");
                cbDBName.Text = Classes.RegistryHelper.ReadFromRegistry(_registryKey, "DatabaseName");
            }
        #endregion                   
    }
}

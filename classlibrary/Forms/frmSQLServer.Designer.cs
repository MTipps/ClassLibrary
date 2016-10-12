namespace ClassLibrary.Forms
{
    partial class frmSQLServer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSQLServer));
            this.lblServerName = new System.Windows.Forms.Label();
            this.cbServerName = new System.Windows.Forms.ComboBox();
            this.cbDBName = new System.Windows.Forms.ComboBox();
            this.lblDBName = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Location = new System.Drawing.Point(13, 13);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(69, 13);
            this.lblServerName.TabIndex = 0;
            this.lblServerName.Text = "Server Name";
            // 
            // cbServerName
            // 
            this.cbServerName.FormattingEnabled = true;
            this.cbServerName.Location = new System.Drawing.Point(102, 10);
            this.cbServerName.Name = "cbServerName";
            this.cbServerName.Size = new System.Drawing.Size(223, 21);
            this.cbServerName.TabIndex = 1;
            this.cbServerName.SelectedIndexChanged += new System.EventHandler(this.cbServerName_SelectedIndexChanged);
            // 
            // cbDBName
            // 
            this.cbDBName.FormattingEnabled = true;
            this.cbDBName.Location = new System.Drawing.Point(102, 37);
            this.cbDBName.Name = "cbDBName";
            this.cbDBName.Size = new System.Drawing.Size(223, 21);
            this.cbDBName.TabIndex = 3;
            // 
            // lblDBName
            // 
            this.lblDBName.AutoSize = true;
            this.lblDBName.Location = new System.Drawing.Point(13, 40);
            this.lblDBName.Name = "lblDBName";
            this.lblDBName.Size = new System.Drawing.Size(84, 13);
            this.lblDBName.TabIndex = 2;
            this.lblDBName.Text = "Database Name";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Maroon;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = global::ClassLibrary.Properties.Resources.save16;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(259, 64);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmSQLServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(332, 92);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbDBName);
            this.Controls.Add(this.lblDBName);
            this.Controls.Add(this.cbServerName);
            this.Controls.Add(this.lblServerName);
            this.ForeColor = System.Drawing.Color.Maroon;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSQLServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQL Server Settings";
            this.Load += new System.EventHandler(this.frmSQLServer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.ComboBox cbServerName;
        private System.Windows.Forms.ComboBox cbDBName;
        private System.Windows.Forms.Label lblDBName;
        private System.Windows.Forms.Button btnSave;
    }
}
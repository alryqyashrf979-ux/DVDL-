namespace DVLD
{
    partial class FrmLocalDrivingLicenseApplications
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilterLDLAppsBy = new System.Windows.Forms.TextBox();
            this.cbFilterLDLApps = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvLDLApps = new System.Windows.Forms.DataGridView();
            this.CMSLDLApps = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showApplicationDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteNewApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sechduleTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visionTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writtenTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.practicleTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.issueDrivingLicenseFirstTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.LbRecords = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLDLApps)).BeginInit();
            this.CMSLDLApps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(434, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(412, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Local Driving License Applications ";
            // 
            // txtFilterLDLAppsBy
            // 
            this.txtFilterLDLAppsBy.Location = new System.Drawing.Point(376, 195);
            this.txtFilterLDLAppsBy.Name = "txtFilterLDLAppsBy";
            this.txtFilterLDLAppsBy.Size = new System.Drawing.Size(207, 24);
            this.txtFilterLDLAppsBy.TabIndex = 3;
            this.txtFilterLDLAppsBy.TextChanged += new System.EventHandler(this.txtFilterLDLAppsBy_TextChanged);
            // 
            // cbFilterLDLApps
            // 
            this.cbFilterLDLApps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterLDLApps.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbFilterLDLApps.FormattingEnabled = true;
            this.cbFilterLDLApps.Items.AddRange(new object[] {
            "None",
            "L.D.L AppID",
            "NationalNo",
            "Full_Name",
            "Status"});
            this.cbFilterLDLApps.Location = new System.Drawing.Point(147, 195);
            this.cbFilterLDLApps.Name = "cbFilterLDLApps";
            this.cbFilterLDLApps.Size = new System.Drawing.Size(202, 24);
            this.cbFilterLDLApps.TabIndex = 4;
            this.cbFilterLDLApps.SelectedIndexChanged += new System.EventHandler(this.cbFilterLDLApps_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Filter By :";
            // 
            // dgvLDLApps
            // 
            this.dgvLDLApps.AllowUserToAddRows = false;
            this.dgvLDLApps.AllowUserToDeleteRows = false;
            this.dgvLDLApps.AllowUserToOrderColumns = true;
            this.dgvLDLApps.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLDLApps.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvLDLApps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLDLApps.ContextMenuStrip = this.CMSLDLApps;
            this.dgvLDLApps.Location = new System.Drawing.Point(33, 240);
            this.dgvLDLApps.Name = "dgvLDLApps";
            this.dgvLDLApps.ReadOnly = true;
            this.dgvLDLApps.RowHeadersWidth = 51;
            this.dgvLDLApps.RowTemplate.Height = 26;
            this.dgvLDLApps.Size = new System.Drawing.Size(1223, 428);
            this.dgvLDLApps.TabIndex = 6;
            // 
            // CMSLDLApps
            // 
            this.CMSLDLApps.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CMSLDLApps.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showApplicationDetailsToolStripMenuItem,
            this.editApplicationToolStripMenuItem,
            this.DeleteNewApplicationToolStripMenuItem,
            this.cancelApplicationToolStripMenuItem,
            this.sechduleTestToolStripMenuItem,
            this.issueDrivingLicenseFirstTimeToolStripMenuItem,
            this.showLicenseToolStripMenuItem,
            this.showPersonLicenseHistoryToolStripMenuItem});
            this.CMSLDLApps.Name = "CMSLDLApps";
            this.CMSLDLApps.Size = new System.Drawing.Size(300, 240);
            this.CMSLDLApps.Opening += new System.ComponentModel.CancelEventHandler(this.CMSLDLApps_Opening);
            // 
            // showApplicationDetailsToolStripMenuItem
            // 
            this.showApplicationDetailsToolStripMenuItem.Image = global::DVLD.Properties.Resources.PersonDetails_32;
            this.showApplicationDetailsToolStripMenuItem.Name = "showApplicationDetailsToolStripMenuItem";
            this.showApplicationDetailsToolStripMenuItem.Size = new System.Drawing.Size(299, 26);
            this.showApplicationDetailsToolStripMenuItem.Text = "Show Application Details .";
            this.showApplicationDetailsToolStripMenuItem.Click += new System.EventHandler(this.showApplicationDetailsToolStripMenuItem_Click);
            // 
            // editApplicationToolStripMenuItem
            // 
            this.editApplicationToolStripMenuItem.Image = global::DVLD.Properties.Resources.edit_32;
            this.editApplicationToolStripMenuItem.Name = "editApplicationToolStripMenuItem";
            this.editApplicationToolStripMenuItem.Size = new System.Drawing.Size(299, 26);
            this.editApplicationToolStripMenuItem.Text = "Edit Application .";
            this.editApplicationToolStripMenuItem.Click += new System.EventHandler(this.editApplicationToolStripMenuItem_Click);
            // 
            // DeleteNewApplicationToolStripMenuItem
            // 
            this.DeleteNewApplicationToolStripMenuItem.Image = global::DVLD.Properties.Resources.Delete_32_2;
            this.DeleteNewApplicationToolStripMenuItem.Name = "DeleteNewApplicationToolStripMenuItem";
            this.DeleteNewApplicationToolStripMenuItem.Size = new System.Drawing.Size(299, 26);
            this.DeleteNewApplicationToolStripMenuItem.Text = "Delete Application .";
            // 
            // cancelApplicationToolStripMenuItem
            // 
            this.cancelApplicationToolStripMenuItem.Image = global::DVLD.Properties.Resources.Delete_32;
            this.cancelApplicationToolStripMenuItem.Name = "cancelApplicationToolStripMenuItem";
            this.cancelApplicationToolStripMenuItem.Size = new System.Drawing.Size(299, 26);
            this.cancelApplicationToolStripMenuItem.Text = "Cancel Application .";
            // 
            // sechduleTestToolStripMenuItem
            // 
            this.sechduleTestToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visionTestToolStripMenuItem,
            this.writtenTestToolStripMenuItem,
            this.practicleTestToolStripMenuItem});
            this.sechduleTestToolStripMenuItem.Image = global::DVLD.Properties.Resources.Test_32;
            this.sechduleTestToolStripMenuItem.Name = "sechduleTestToolStripMenuItem";
            this.sechduleTestToolStripMenuItem.Size = new System.Drawing.Size(299, 26);
            this.sechduleTestToolStripMenuItem.Text = "Sechdule Test.";
            this.sechduleTestToolStripMenuItem.DropDownOpening += new System.EventHandler(this.sechduleTestToolStripMenuItem_DropDownOpening);
            this.sechduleTestToolStripMenuItem.Click += new System.EventHandler(this.sechduleTestToolStripMenuItem_Click);
            // 
            // visionTestToolStripMenuItem
            // 
            this.visionTestToolStripMenuItem.Image = global::DVLD.Properties.Resources.Vision_512;
            this.visionTestToolStripMenuItem.Name = "visionTestToolStripMenuItem";
            this.visionTestToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.visionTestToolStripMenuItem.Text = "Vision test .";
            this.visionTestToolStripMenuItem.Click += new System.EventHandler(this.visionTestToolStripMenuItem_Click);
            // 
            // writtenTestToolStripMenuItem
            // 
            this.writtenTestToolStripMenuItem.Image = global::DVLD.Properties.Resources.Written_Test_512;
            this.writtenTestToolStripMenuItem.Name = "writtenTestToolStripMenuItem";
            this.writtenTestToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.writtenTestToolStripMenuItem.Text = "Written test .";
            this.writtenTestToolStripMenuItem.Click += new System.EventHandler(this.writtenTestToolStripMenuItem_Click);
            // 
            // practicleTestToolStripMenuItem
            // 
            this.practicleTestToolStripMenuItem.Image = global::DVLD.Properties.Resources.Street_Test_32;
            this.practicleTestToolStripMenuItem.Name = "practicleTestToolStripMenuItem";
            this.practicleTestToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
            this.practicleTestToolStripMenuItem.Text = "Practicle test . ";
            this.practicleTestToolStripMenuItem.Click += new System.EventHandler(this.practicleTestToolStripMenuItem_Click);
            // 
            // issueDrivingLicenseFirstTimeToolStripMenuItem
            // 
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Image = global::DVLD.Properties.Resources.IssueDrivingLicense_32;
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Name = "issueDrivingLicenseFirstTimeToolStripMenuItem";
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Size = new System.Drawing.Size(299, 26);
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Text = "Issue Driving License (First Time).";
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Click += new System.EventHandler(this.issueDrivingLicenseFirstTimeToolStripMenuItem_Click);
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.IssueDrivingLicense_32;
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(299, 26);
            this.showLicenseToolStripMenuItem.Text = "Show License .";
            this.showLicenseToolStripMenuItem.Click += new System.EventHandler(this.showLicenseToolStripMenuItem_Click);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Image = global::DVLD.Properties.Resources.PersonLicenseHistory_512;
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(299, 26);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History .";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 688);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "# Records :";
            // 
            // LbRecords
            // 
            this.LbRecords.AutoSize = true;
            this.LbRecords.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbRecords.Location = new System.Drawing.Point(121, 688);
            this.LbRecords.Name = "LbRecords";
            this.LbRecords.Size = new System.Drawing.Size(28, 16);
            this.LbRecords.TabIndex = 8;
            this.LbRecords.Text = "???";
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::DVLD.Properties.Resources.New_Application_64;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Location = new System.Drawing.Point(1174, 163);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 56);
            this.button1.TabIndex = 9;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD.Properties.Resources.Local_321;
            this.pictureBox2.Location = new System.Drawing.Point(701, 42);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(57, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.Applications1;
            this.pictureBox1.Location = new System.Drawing.Point(561, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(158, 121);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FrmLocalDrivingLicenseApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 730);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LbRecords);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvLDLApps);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbFilterLDLApps);
            this.Controls.Add(this.txtFilterLDLAppsBy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmLocalDrivingLicenseApplications";
            this.Text = "Local Driving License Applications";
            this.Load += new System.EventHandler(this.FrmLocalDrivingLicenseApplications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLDLApps)).EndInit();
            this.CMSLDLApps.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFilterLDLAppsBy;
        private System.Windows.Forms.ComboBox cbFilterLDLApps;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvLDLApps;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LbRecords;
        private System.Windows.Forms.ContextMenuStrip CMSLDLApps;
        private System.Windows.Forms.ToolStripMenuItem showApplicationDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteNewApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sechduleTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem issueDrivingLicenseFirstTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem visionTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writtenTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem practicleTestToolStripMenuItem;
    }
}
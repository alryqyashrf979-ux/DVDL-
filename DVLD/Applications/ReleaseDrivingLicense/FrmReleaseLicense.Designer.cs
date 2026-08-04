namespace DVLD
{
    partial class FrmReleaseLicense
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
            this.userControlFindLicenseWithFilter1 = new DVLD.UserControlFindLicenseWithFilter();
            this.label1 = new System.Windows.Forms.Label();
            this.GbDetainInfo = new System.Windows.Forms.GroupBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.LbApplicationID = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.LbFineFees = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.LbCreatedBy = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.LbLicenseID = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.LbTotalFees = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.LbApplicationFees = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.LbDetainDate = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LbDetainID = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LLbShowDriverInfo = new System.Windows.Forms.LinkLabel();
            this.btnRelease = new System.Windows.Forms.Button();
            this.LLbShowPersonHistory = new System.Windows.Forms.LinkLabel();
            this.GbDetainInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // userControlFindLicenseWithFilter1
            // 
            this.userControlFindLicenseWithFilter1.FilterEnabled = true;
            this.userControlFindLicenseWithFilter1.Location = new System.Drawing.Point(12, 49);
            this.userControlFindLicenseWithFilter1.Name = "userControlFindLicenseWithFilter1";
            this.userControlFindLicenseWithFilter1.Size = new System.Drawing.Size(1055, 493);
            this.userControlFindLicenseWithFilter1.TabIndex = 0;
            this.userControlFindLicenseWithFilter1.onLicenseSelected += new System.Action<int>(this.userControlFindLicenseWithFilter1_onLicenseSelected);
            this.userControlFindLicenseWithFilter1.Load += new System.EventHandler(this.userControlFindLicenseWithFilter1_Load);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(429, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Release License ";
            // 
            // GbDetainInfo
            // 
            this.GbDetainInfo.Controls.Add(this.pictureBox8);
            this.GbDetainInfo.Controls.Add(this.LbApplicationID);
            this.GbDetainInfo.Controls.Add(this.label11);
            this.GbDetainInfo.Controls.Add(this.pictureBox7);
            this.GbDetainInfo.Controls.Add(this.LbFineFees);
            this.GbDetainInfo.Controls.Add(this.label10);
            this.GbDetainInfo.Controls.Add(this.LbCreatedBy);
            this.GbDetainInfo.Controls.Add(this.pictureBox6);
            this.GbDetainInfo.Controls.Add(this.label9);
            this.GbDetainInfo.Controls.Add(this.LbLicenseID);
            this.GbDetainInfo.Controls.Add(this.pictureBox5);
            this.GbDetainInfo.Controls.Add(this.label8);
            this.GbDetainInfo.Controls.Add(this.pictureBox4);
            this.GbDetainInfo.Controls.Add(this.LbTotalFees);
            this.GbDetainInfo.Controls.Add(this.label7);
            this.GbDetainInfo.Controls.Add(this.LbApplicationFees);
            this.GbDetainInfo.Controls.Add(this.pictureBox3);
            this.GbDetainInfo.Controls.Add(this.label5);
            this.GbDetainInfo.Controls.Add(this.LbDetainDate);
            this.GbDetainInfo.Controls.Add(this.pictureBox2);
            this.GbDetainInfo.Controls.Add(this.label4);
            this.GbDetainInfo.Controls.Add(this.LbDetainID);
            this.GbDetainInfo.Controls.Add(this.pictureBox1);
            this.GbDetainInfo.Controls.Add(this.label2);
            this.GbDetainInfo.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GbDetainInfo.Location = new System.Drawing.Point(12, 548);
            this.GbDetainInfo.Name = "GbDetainInfo";
            this.GbDetainInfo.Size = new System.Drawing.Size(1049, 210);
            this.GbDetainInfo.TabIndex = 2;
            this.GbDetainInfo.TabStop = false;
            this.GbDetainInfo.Text = "Detain Info :";
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::DVLD.Properties.Resources.Number_32;
            this.pictureBox8.Location = new System.Drawing.Point(660, 162);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(52, 37);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 25;
            this.pictureBox8.TabStop = false;
            // 
            // LbApplicationID
            // 
            this.LbApplicationID.AutoSize = true;
            this.LbApplicationID.Location = new System.Drawing.Point(718, 178);
            this.LbApplicationID.Name = "LbApplicationID";
            this.LbApplicationID.Size = new System.Drawing.Size(48, 21);
            this.LbApplicationID.TabIndex = 24;
            this.LbApplicationID.Text = "[???]";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(511, 178);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(126, 21);
            this.label11.TabIndex = 23;
            this.label11.Text = "Application ID :";
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::DVLD.Properties.Resources.money_321;
            this.pictureBox7.Location = new System.Drawing.Point(660, 113);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(52, 37);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 22;
            this.pictureBox7.TabStop = false;
            // 
            // LbFineFees
            // 
            this.LbFineFees.AutoSize = true;
            this.LbFineFees.Location = new System.Drawing.Point(718, 129);
            this.LbFineFees.Name = "LbFineFees";
            this.LbFineFees.Size = new System.Drawing.Size(48, 21);
            this.LbFineFees.TabIndex = 21;
            this.LbFineFees.Text = "[???]";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(511, 129);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 21);
            this.label10.TabIndex = 19;
            this.label10.Text = "Fine Fees :";
            // 
            // LbCreatedBy
            // 
            this.LbCreatedBy.AutoSize = true;
            this.LbCreatedBy.Location = new System.Drawing.Point(718, 81);
            this.LbCreatedBy.Name = "LbCreatedBy";
            this.LbCreatedBy.Size = new System.Drawing.Size(48, 21);
            this.LbCreatedBy.TabIndex = 18;
            this.LbCreatedBy.Text = "[???]";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::DVLD.Properties.Resources.User_32__2;
            this.pictureBox6.Location = new System.Drawing.Point(660, 65);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(52, 37);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 17;
            this.pictureBox6.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(511, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 21);
            this.label9.TabIndex = 16;
            this.label9.Text = "Created By :";
            // 
            // LbLicenseID
            // 
            this.LbLicenseID.AutoSize = true;
            this.LbLicenseID.Location = new System.Drawing.Point(718, 37);
            this.LbLicenseID.Name = "LbLicenseID";
            this.LbLicenseID.Size = new System.Drawing.Size(48, 21);
            this.LbLicenseID.TabIndex = 15;
            this.LbLicenseID.Text = "[???]";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::DVLD.Properties.Resources.Local_Driving_License_512;
            this.pictureBox5.Location = new System.Drawing.Point(660, 21);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(52, 37);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 14;
            this.pictureBox5.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(511, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 21);
            this.label8.TabIndex = 13;
            this.label8.Text = "License ID :";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLD.Properties.Resources.money_321;
            this.pictureBox4.Location = new System.Drawing.Point(188, 165);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(52, 37);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 12;
            this.pictureBox4.TabStop = false;
            // 
            // LbTotalFees
            // 
            this.LbTotalFees.AutoSize = true;
            this.LbTotalFees.Location = new System.Drawing.Point(246, 178);
            this.LbTotalFees.Name = "LbTotalFees";
            this.LbTotalFees.Size = new System.Drawing.Size(48, 21);
            this.LbTotalFees.TabIndex = 11;
            this.LbTotalFees.Text = "[???]";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 178);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 21);
            this.label7.TabIndex = 9;
            this.label7.Text = "Total Fees :";
            // 
            // LbApplicationFees
            // 
            this.LbApplicationFees.AutoSize = true;
            this.LbApplicationFees.Location = new System.Drawing.Point(246, 129);
            this.LbApplicationFees.Name = "LbApplicationFees";
            this.LbApplicationFees.Size = new System.Drawing.Size(48, 21);
            this.LbApplicationFees.TabIndex = 8;
            this.LbApplicationFees.Text = "[???]";
            this.LbApplicationFees.Click += new System.EventHandler(this.label3_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD.Properties.Resources.money_321;
            this.pictureBox3.Location = new System.Drawing.Point(188, 113);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(52, 37);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 21);
            this.label5.TabIndex = 6;
            this.label5.Text = "Application Fees :";
            // 
            // LbDetainDate
            // 
            this.LbDetainDate.AutoSize = true;
            this.LbDetainDate.Location = new System.Drawing.Point(246, 81);
            this.LbDetainDate.Name = "LbDetainDate";
            this.LbDetainDate.Size = new System.Drawing.Size(48, 21);
            this.LbDetainDate.TabIndex = 5;
            this.LbDetainDate.Text = "[???]";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD.Properties.Resources.Calendar_321;
            this.pictureBox2.Location = new System.Drawing.Point(188, 65);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(52, 37);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Detain Date :";
            // 
            // LbDetainID
            // 
            this.LbDetainID.AutoSize = true;
            this.LbDetainID.Location = new System.Drawing.Point(246, 37);
            this.LbDetainID.Name = "LbDetainID";
            this.LbDetainID.Size = new System.Drawing.Size(48, 21);
            this.LbDetainID.TabIndex = 2;
            this.LbDetainID.Text = "[???]";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.Detain_512;
            this.pictureBox1.Location = new System.Drawing.Point(188, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 37);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Detain ID :";
            // 
            // LLbShowDriverInfo
            // 
            this.LLbShowDriverInfo.AutoSize = true;
            this.LLbShowDriverInfo.Location = new System.Drawing.Point(397, 782);
            this.LLbShowDriverInfo.Name = "LLbShowDriverInfo";
            this.LLbShowDriverInfo.Size = new System.Drawing.Size(115, 17);
            this.LLbShowDriverInfo.TabIndex = 3;
            this.LLbShowDriverInfo.TabStop = true;
            this.LLbShowDriverInfo.Text = "Show Driver Info ";
            this.LLbShowDriverInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLbShowDriverInfo_LinkClicked);
            // 
            // btnRelease
            // 
            this.btnRelease.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRelease.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelease.Location = new System.Drawing.Point(932, 768);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(106, 42);
            this.btnRelease.TabIndex = 4;
            this.btnRelease.Text = "Release";
            this.btnRelease.UseVisualStyleBackColor = true;
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // LLbShowPersonHistory
            // 
            this.LLbShowPersonHistory.AutoSize = true;
            this.LLbShowPersonHistory.Location = new System.Drawing.Point(52, 782);
            this.LLbShowPersonHistory.Name = "LLbShowPersonHistory";
            this.LLbShowPersonHistory.Size = new System.Drawing.Size(187, 17);
            this.LLbShowPersonHistory.TabIndex = 5;
            this.LLbShowPersonHistory.TabStop = true;
            this.LLbShowPersonHistory.Text = "Show Person License History ";
            this.LLbShowPersonHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLbShowPersonHistory_LinkClicked);
            // 
            // FrmReleaseLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 822);
            this.Controls.Add(this.LLbShowPersonHistory);
            this.Controls.Add(this.btnRelease);
            this.Controls.Add(this.LLbShowDriverInfo);
            this.Controls.Add(this.GbDetainInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userControlFindLicenseWithFilter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmReleaseLicense";
            this.Text = "Release License";
            this.Load += new System.EventHandler(this.FrmReleaseLicense_Load);
            this.GbDetainInfo.ResumeLayout(false);
            this.GbDetainInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControlFindLicenseWithFilter userControlFindLicenseWithFilter1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox GbDetainInfo;
        private System.Windows.Forms.Label LbApplicationFees;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LbDetainDate;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LbDetainID;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LbTotalFees;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label LbApplicationID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label LbFineFees;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label LbCreatedBy;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label LbLicenseID;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.LinkLabel LLbShowDriverInfo;
        private System.Windows.Forms.Button btnRelease;
        private System.Windows.Forms.LinkLabel LLbShowPersonHistory;
    }
}
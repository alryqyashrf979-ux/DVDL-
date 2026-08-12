namespace DVLD
{
    partial class FrmIssueInternationalDrivingLicense
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
            this.label1 = new System.Windows.Forms.Label();
            this.userControlFindLicenseWithFilter1 = new DVLD.UserControlFindLicenseWithFilter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LbFess = new System.Windows.Forms.Label();
            this.LbCreatedBy = new System.Windows.Forms.Label();
            this.LbInternationalLicenseID = new System.Windows.Forms.Label();
            this.LbLocalLicenseID = new System.Windows.Forms.Label();
            this.LbExpirationDate = new System.Windows.Forms.Label();
            this.LbIssueDate = new System.Windows.Forms.Label();
            this.LbApplicationDate = new System.Windows.Forms.Label();
            this.LbInternationalApplicationID = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnIssue = new System.Windows.Forms.Button();
            this.llbShowPersonLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.llbShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(307, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(406, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "International License Application ";
            // 
            // userControlFindLicenseWithFilter1
            // 
            this.userControlFindLicenseWithFilter1.FilterEnabled = true;
            this.userControlFindLicenseWithFilter1.Location = new System.Drawing.Point(12, 45);
            this.userControlFindLicenseWithFilter1.Name = "userControlFindLicenseWithFilter1";
            this.userControlFindLicenseWithFilter1.Size = new System.Drawing.Size(1055, 493);
            this.userControlFindLicenseWithFilter1.TabIndex = 1;
            this.userControlFindLicenseWithFilter1.onLicenseSelected += new System.Action<int>(this.userControlFindLicenseWithFilter1_onLicenseSelected);
            this.userControlFindLicenseWithFilter1.Load += new System.EventHandler(this.userControlFindLicenseWithFilter1_Load);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LbFess);
            this.groupBox1.Controls.Add(this.LbCreatedBy);
            this.groupBox1.Controls.Add(this.LbInternationalLicenseID);
            this.groupBox1.Controls.Add(this.LbLocalLicenseID);
            this.groupBox1.Controls.Add(this.LbExpirationDate);
            this.groupBox1.Controls.Add(this.LbIssueDate);
            this.groupBox1.Controls.Add(this.LbApplicationDate);
            this.groupBox1.Controls.Add(this.LbInternationalApplicationID);
            this.groupBox1.Controls.Add(this.pictureBox8);
            this.groupBox1.Controls.Add(this.pictureBox7);
            this.groupBox1.Controls.Add(this.pictureBox6);
            this.groupBox1.Controls.Add(this.pictureBox5);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.pictureBox4);
            this.groupBox1.Controls.Add(this.pictureBox3);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 544);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1031, 194);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Application Info :";
            // 
            // LbFess
            // 
            this.LbFess.AutoSize = true;
            this.LbFess.Location = new System.Drawing.Point(242, 160);
            this.LbFess.Name = "LbFess";
            this.LbFess.Size = new System.Drawing.Size(51, 21);
            this.LbFess.TabIndex = 24;
            this.LbFess.Text = "[$$$]";
            // 
            // LbCreatedBy
            // 
            this.LbCreatedBy.AutoSize = true;
            this.LbCreatedBy.Location = new System.Drawing.Point(739, 167);
            this.LbCreatedBy.Name = "LbCreatedBy";
            this.LbCreatedBy.Size = new System.Drawing.Size(48, 21);
            this.LbCreatedBy.TabIndex = 23;
            this.LbCreatedBy.Text = "[???]";
            // 
            // LbInternationalLicenseID
            // 
            this.LbInternationalLicenseID.AutoSize = true;
            this.LbInternationalLicenseID.Location = new System.Drawing.Point(739, 37);
            this.LbInternationalLicenseID.Name = "LbInternationalLicenseID";
            this.LbInternationalLicenseID.Size = new System.Drawing.Size(48, 21);
            this.LbInternationalLicenseID.TabIndex = 22;
            this.LbInternationalLicenseID.Text = "[???]";
            // 
            // LbLocalLicenseID
            // 
            this.LbLocalLicenseID.AutoSize = true;
            this.LbLocalLicenseID.Location = new System.Drawing.Point(739, 80);
            this.LbLocalLicenseID.Name = "LbLocalLicenseID";
            this.LbLocalLicenseID.Size = new System.Drawing.Size(48, 21);
            this.LbLocalLicenseID.TabIndex = 21;
            this.LbLocalLicenseID.Text = "[???]";
            // 
            // LbExpirationDate
            // 
            this.LbExpirationDate.AutoSize = true;
            this.LbExpirationDate.Location = new System.Drawing.Point(739, 123);
            this.LbExpirationDate.Name = "LbExpirationDate";
            this.LbExpirationDate.Size = new System.Drawing.Size(116, 21);
            this.LbExpirationDate.TabIndex = 20;
            this.LbExpirationDate.Text = "[dd/mm/yyyy]";
            // 
            // LbIssueDate
            // 
            this.LbIssueDate.AutoSize = true;
            this.LbIssueDate.Location = new System.Drawing.Point(242, 121);
            this.LbIssueDate.Name = "LbIssueDate";
            this.LbIssueDate.Size = new System.Drawing.Size(116, 21);
            this.LbIssueDate.TabIndex = 19;
            this.LbIssueDate.Text = "[dd/mm/yyyy]";
            // 
            // LbApplicationDate
            // 
            this.LbApplicationDate.AutoSize = true;
            this.LbApplicationDate.Location = new System.Drawing.Point(242, 80);
            this.LbApplicationDate.Name = "LbApplicationDate";
            this.LbApplicationDate.Size = new System.Drawing.Size(116, 21);
            this.LbApplicationDate.TabIndex = 18;
            this.LbApplicationDate.Text = "[dd/mm/yyyy]";
            // 
            // LbInternationalApplicationID
            // 
            this.LbInternationalApplicationID.AutoSize = true;
            this.LbInternationalApplicationID.Location = new System.Drawing.Point(242, 37);
            this.LbInternationalApplicationID.Name = "LbInternationalApplicationID";
            this.LbInternationalApplicationID.Size = new System.Drawing.Size(48, 21);
            this.LbInternationalApplicationID.TabIndex = 17;
            this.LbInternationalApplicationID.Text = "[???]";
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::DVLD.Properties.Resources.International_321;
            this.pictureBox8.Location = new System.Drawing.Point(691, 21);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(42, 37);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 16;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::DVLD.Properties.Resources.User_32__2;
            this.pictureBox7.Location = new System.Drawing.Point(691, 151);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(42, 37);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 15;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::DVLD.Properties.Resources.Calendar_32;
            this.pictureBox6.Location = new System.Drawing.Point(691, 107);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(42, 37);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 14;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::DVLD.Properties.Resources.Lost_Driving_License_32;
            this.pictureBox5.Location = new System.Drawing.Point(691, 64);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(42, 37);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 13;
            this.pictureBox5.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(543, 160);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 21);
            this.label9.TabIndex = 12;
            this.label9.Text = "Created By :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(543, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 21);
            this.label8.TabIndex = 11;
            this.label8.Text = "Expiration Date :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(543, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 21);
            this.label7.TabIndex = 10;
            this.label7.Text = "Local License ID :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(543, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 21);
            this.label6.TabIndex = 9;
            this.label6.Text = "I.License ID :";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLD.Properties.Resources.money_32;
            this.pictureBox4.Location = new System.Drawing.Point(194, 151);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(42, 37);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 8;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD.Properties.Resources.Calendar_32;
            this.pictureBox3.Location = new System.Drawing.Point(194, 107);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(42, 37);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD.Properties.Resources.Calendar_32;
            this.pictureBox2.Location = new System.Drawing.Point(194, 64);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(42, 37);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 21);
            this.label5.TabIndex = 5;
            this.label5.Text = "Fees :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "Issue Date :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "Application Date :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.Number_32;
            this.pictureBox1.Location = new System.Drawing.Point(194, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 37);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "I.Application ID :";
            // 
            // btnIssue
            // 
            this.btnIssue.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIssue.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssue.Location = new System.Drawing.Point(944, 744);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(99, 47);
            this.btnIssue.TabIndex = 2;
            this.btnIssue.Text = "Issue";
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // llbShowPersonLicenseHistory
            // 
            this.llbShowPersonLicenseHistory.AutoSize = true;
            this.llbShowPersonLicenseHistory.Location = new System.Drawing.Point(46, 761);
            this.llbShowPersonLicenseHistory.Name = "llbShowPersonLicenseHistory";
            this.llbShowPersonLicenseHistory.Size = new System.Drawing.Size(168, 17);
            this.llbShowPersonLicenseHistory.TabIndex = 3;
            this.llbShowPersonLicenseHistory.TabStop = true;
            this.llbShowPersonLicenseHistory.Text = "Show Person License Info ";
            this.llbShowPersonLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbShowPersonLicenseHistory_LinkClicked);
            // 
            // llbShowLicenseInfo
            // 
            this.llbShowLicenseInfo.AutoSize = true;
            this.llbShowLicenseInfo.Location = new System.Drawing.Point(275, 761);
            this.llbShowLicenseInfo.Name = "llbShowLicenseInfo";
            this.llbShowLicenseInfo.Size = new System.Drawing.Size(122, 17);
            this.llbShowLicenseInfo.TabIndex = 4;
            this.llbShowLicenseInfo.TabStop = true;
            this.llbShowLicenseInfo.Text = "Show License Info ";
            this.llbShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbShowLicenseInfo_LinkClicked);
            // 
            // FrmIssueInternationalDrivingLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 803);
            this.Controls.Add(this.llbShowLicenseInfo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.userControlFindLicenseWithFilter1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.llbShowPersonLicenseHistory);
            this.Controls.Add(this.btnIssue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmIssueInternationalDrivingLicense";
            this.Text = "Issue International Driving License";
            this.Load += new System.EventHandler(this.FrmIssueInternationalDrivingLicense_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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

        private System.Windows.Forms.Label label1;
        private UserControlFindLicenseWithFilter userControlFindLicenseWithFilter1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel llbShowPersonLicenseHistory;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LbApplicationDate;
        private System.Windows.Forms.Label LbInternationalApplicationID;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LbFess;
        private System.Windows.Forms.Label LbCreatedBy;
        private System.Windows.Forms.Label LbInternationalLicenseID;
        private System.Windows.Forms.Label LbLocalLicenseID;
        private System.Windows.Forms.Label LbExpirationDate;
        private System.Windows.Forms.Label LbIssueDate;
        private System.Windows.Forms.LinkLabel llbShowLicenseInfo;
    }
}
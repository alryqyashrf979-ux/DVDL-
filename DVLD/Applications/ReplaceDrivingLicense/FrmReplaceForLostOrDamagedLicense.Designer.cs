namespace DVLD
{
    partial class FrmReplaceForLostOrDamagedLicense
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
            this.lbTitle = new System.Windows.Forms.Label();
            this.gbReplacementType = new System.Windows.Forms.GroupBox();
            this.rbReplacementForDamaged = new System.Windows.Forms.RadioButton();
            this.rbReplacementForLost = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LbCreatedBy = new System.Windows.Forms.Label();
            this.LbOldLicenseID = new System.Windows.Forms.Label();
            this.LbnewLicenseID = new System.Windows.Forms.Label();
            this.LbApplicationFees = new System.Windows.Forms.Label();
            this.LbApplicationDate = new System.Windows.Forms.Label();
            this.LbRLApplicationID = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReplace = new System.Windows.Forms.Button();
            this.lbShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.gbReplacementType.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // userControlFindLicenseWithFilter1
            // 
            this.userControlFindLicenseWithFilter1.FilterEnabled = true;
            this.userControlFindLicenseWithFilter1.Location = new System.Drawing.Point(8, 39);
            this.userControlFindLicenseWithFilter1.Name = "userControlFindLicenseWithFilter1";
            this.userControlFindLicenseWithFilter1.Size = new System.Drawing.Size(1055, 471);
            this.userControlFindLicenseWithFilter1.TabIndex = 0;
            this.userControlFindLicenseWithFilter1.onLicenseSelected += new System.Action<int>(this.userControlFindLicenseWithFilter1_onLicenseSelected);
//            this.userControlFindLicenseWithFilter1.Load += new System.EventHandler(this.userControlFindLicenseWithFilter1_Load);
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.Red;
            this.lbTitle.Location = new System.Drawing.Point(366, 9);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(329, 34);
            this.lbTitle.TabIndex = 1;
            this.lbTitle.Text = "Replacement For Lost ";
            // 
            // gbReplacementType
            // 
            this.gbReplacementType.Controls.Add(this.rbReplacementForDamaged);
            this.gbReplacementType.Controls.Add(this.rbReplacementForLost);
            this.gbReplacementType.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbReplacementType.Location = new System.Drawing.Point(811, 39);
            this.gbReplacementType.Name = "gbReplacementType";
            this.gbReplacementType.Size = new System.Drawing.Size(252, 111);
            this.gbReplacementType.TabIndex = 2;
            this.gbReplacementType.TabStop = false;
            this.gbReplacementType.Text = "Replacement For :";
            // 
            // rbReplacementForDamaged
            // 
            this.rbReplacementForDamaged.AutoSize = true;
            this.rbReplacementForDamaged.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbReplacementForDamaged.Location = new System.Drawing.Point(30, 63);
            this.rbReplacementForDamaged.Name = "rbReplacementForDamaged";
            this.rbReplacementForDamaged.Size = new System.Drawing.Size(200, 20);
            this.rbReplacementForDamaged.TabIndex = 1;
            this.rbReplacementForDamaged.TabStop = true;
            this.rbReplacementForDamaged.Text = "Replacement For Damaged";
            this.rbReplacementForDamaged.UseVisualStyleBackColor = true;
            // 
            // rbReplacementForLost
            // 
            this.rbReplacementForLost.AutoSize = true;
            this.rbReplacementForLost.Checked = true;
            this.rbReplacementForLost.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbReplacementForLost.Location = new System.Drawing.Point(30, 37);
            this.rbReplacementForLost.Name = "rbReplacementForLost";
            this.rbReplacementForLost.Size = new System.Drawing.Size(167, 20);
            this.rbReplacementForLost.TabIndex = 0;
            this.rbReplacementForLost.TabStop = true;
            this.rbReplacementForLost.Text = "Replacement for Lost";
            this.rbReplacementForLost.UseVisualStyleBackColor = true;
            this.rbReplacementForLost.CheckedChanged += new System.EventHandler(this.rbReplacementForLost_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox3);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.pictureBox10);
            this.groupBox1.Controls.Add(this.pictureBox7);
            this.groupBox1.Controls.Add(this.pictureBox4);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.LbCreatedBy);
            this.groupBox1.Controls.Add(this.LbOldLicenseID);
            this.groupBox1.Controls.Add(this.LbnewLicenseID);
            this.groupBox1.Controls.Add(this.LbApplicationFees);
            this.groupBox1.Controls.Add(this.LbApplicationDate);
            this.groupBox1.Controls.Add(this.LbRLApplicationID);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 516);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1046, 139);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Application New License Info ";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD.Properties.Resources.User_32__2;
            this.pictureBox3.Location = new System.Drawing.Point(587, 91);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(39, 28);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 32;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD.Properties.Resources.Lost_Driving_License_32;
            this.pictureBox2.Location = new System.Drawing.Point(587, 23);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(39, 28);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 31;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = global::DVLD.Properties.Resources.Lost_Driving_License_32;
            this.pictureBox10.Location = new System.Drawing.Point(587, 57);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(39, 28);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox10.TabIndex = 30;
            this.pictureBox10.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::DVLD.Properties.Resources.money_321;
            this.pictureBox7.Location = new System.Drawing.Point(165, 95);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(39, 28);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 27;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLD.Properties.Resources.Calendar_32;
            this.pictureBox4.Location = new System.Drawing.Point(166, 57);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(39, 28);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 24;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.Number_32;
            this.pictureBox1.Location = new System.Drawing.Point(166, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(39, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // LbCreatedBy
            // 
            this.LbCreatedBy.AutoSize = true;
            this.LbCreatedBy.Location = new System.Drawing.Point(629, 106);
            this.LbCreatedBy.Name = "LbCreatedBy";
            this.LbCreatedBy.Size = new System.Drawing.Size(39, 17);
            this.LbCreatedBy.TabIndex = 20;
            this.LbCreatedBy.Text = "[???]";
            // 
            // LbOldLicenseID
            // 
            this.LbOldLicenseID.AutoSize = true;
            this.LbOldLicenseID.Location = new System.Drawing.Point(629, 68);
            this.LbOldLicenseID.Name = "LbOldLicenseID";
            this.LbOldLicenseID.Size = new System.Drawing.Size(39, 17);
            this.LbOldLicenseID.TabIndex = 18;
            this.LbOldLicenseID.Text = "[???]";
            // 
            // LbnewLicenseID
            // 
            this.LbnewLicenseID.AutoSize = true;
            this.LbnewLicenseID.Location = new System.Drawing.Point(629, 34);
            this.LbnewLicenseID.Name = "LbnewLicenseID";
            this.LbnewLicenseID.Size = new System.Drawing.Size(39, 17);
            this.LbnewLicenseID.TabIndex = 17;
            this.LbnewLicenseID.Text = "[???]";
            // 
            // LbApplicationFees
            // 
            this.LbApplicationFees.AutoSize = true;
            this.LbApplicationFees.Location = new System.Drawing.Point(222, 102);
            this.LbApplicationFees.Name = "LbApplicationFees";
            this.LbApplicationFees.Size = new System.Drawing.Size(42, 17);
            this.LbApplicationFees.TabIndex = 14;
            this.LbApplicationFees.Text = "[$$$]";
            // 
            // LbApplicationDate
            // 
            this.LbApplicationDate.AutoSize = true;
            this.LbApplicationDate.Location = new System.Drawing.Point(222, 64);
            this.LbApplicationDate.Name = "LbApplicationDate";
            this.LbApplicationDate.Size = new System.Drawing.Size(100, 17);
            this.LbApplicationDate.TabIndex = 12;
            this.LbApplicationDate.Text = "[dd/mm/yyyy]";
            // 
            // LbRLApplicationID
            // 
            this.LbRLApplicationID.AutoSize = true;
            this.LbRLApplicationID.Location = new System.Drawing.Point(222, 34);
            this.LbRLApplicationID.Name = "LbRLApplicationID";
            this.LbRLApplicationID.Size = new System.Drawing.Size(39, 17);
            this.LbRLApplicationID.TabIndex = 11;
            this.LbRLApplicationID.Text = "[???]";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(408, 102);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 21);
            this.label10.TabIndex = 9;
            this.label10.Text = "Created By :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(408, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(129, 21);
            this.label8.TabIndex = 7;
            this.label8.Text = "Old License ID :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(408, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 21);
            this.label7.TabIndex = 6;
            this.label7.Text = "New License ID :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Application Fees :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Application Date :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "R.L Application ID :";
            // 
            // btnReplace
            // 
            this.btnReplace.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReplace.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReplace.Location = new System.Drawing.Point(934, 666);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(124, 46);
            this.btnReplace.TabIndex = 4;
            this.btnReplace.Text = "Replace ";
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
            // 
            // lbShowLicenseInfo
            // 
            this.lbShowLicenseInfo.AutoSize = true;
            this.lbShowLicenseInfo.Location = new System.Drawing.Point(29, 683);
            this.lbShowLicenseInfo.Name = "lbShowLicenseInfo";
            this.lbShowLicenseInfo.Size = new System.Drawing.Size(118, 17);
            this.lbShowLicenseInfo.TabIndex = 5;
            this.lbShowLicenseInfo.TabStop = true;
            this.lbShowLicenseInfo.Text = "Show License Info";
            this.lbShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbShowLicenseInfo_LinkClicked);
            // 
            // FrmReplaceForLostOrDamagedLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 739);
            this.Controls.Add(this.lbShowLicenseInfo);
            this.Controls.Add(this.btnReplace);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbReplacementType);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.userControlFindLicenseWithFilter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmReplaceForLostOrDamagedLicense";
            this.Text = "Replace License .";
            this.Load += new System.EventHandler(this.FrmReplaceForLostOrDamagedLicense_Load);
            this.gbReplacementType.ResumeLayout(false);
            this.gbReplacementType.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControlFindLicenseWithFilter userControlFindLicenseWithFilter1;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.GroupBox gbReplacementType;
        private System.Windows.Forms.RadioButton rbReplacementForDamaged;
        private System.Windows.Forms.RadioButton rbReplacementForLost;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LbCreatedBy;
        private System.Windows.Forms.Label LbOldLicenseID;
        private System.Windows.Forms.Label LbnewLicenseID;
        private System.Windows.Forms.Label LbApplicationFees;
        private System.Windows.Forms.Label LbApplicationDate;
        private System.Windows.Forms.Label LbRLApplicationID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.LinkLabel lbShowLicenseInfo;
    }
}
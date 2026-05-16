namespace DVLD
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.applicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drivingLicenseServicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewDrivingLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.LocalDrivingLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.InternationalDrivingLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.RenewDrivingLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.ReplacementForLostOrDamaged = new System.Windows.Forms.ToolStripMenuItem();
            this.ReleaseDetainedDrivingLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.RetakeATest = new System.Windows.Forms.ToolStripMenuItem();
            this.DetainLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.ManageDetainedLicenses = new System.Windows.Forms.ToolStripMenuItem();
            this.DetainALicense = new System.Windows.Forms.ToolStripMenuItem();
            this.ReleaseADetainedLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.ManageApps = new System.Windows.Forms.ToolStripMenuItem();
            this.LocalDrivingLicenseApplications = new System.Windows.Forms.ToolStripMenuItem();
            this.InternationalDrivingLicenseApplications = new System.Windows.Forms.ToolStripMenuItem();
            this.ManageApplicationsTypes = new System.Windows.Forms.ToolStripMenuItem();
            this.ManageTestsTypes = new System.Windows.Forms.ToolStripMenuItem();
            this.peopleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.driversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentUserInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.SignOut = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationsToolStripMenuItem,
            this.peopleToolStripMenuItem,
            this.driversToolStripMenuItem,
            this.usersToolStripMenuItem,
            this.accountSettingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1446, 36);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // applicationsToolStripMenuItem
            // 
            this.applicationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drivingLicenseServicesToolStripMenuItem,
            this.DetainLicense,
            this.ManageApps,
            this.ManageApplicationsTypes,
            this.ManageTestsTypes});
            this.applicationsToolStripMenuItem.Image = global::DVLD.Properties.Resources.Applications;
            this.applicationsToolStripMenuItem.Name = "applicationsToolStripMenuItem";
            this.applicationsToolStripMenuItem.Size = new System.Drawing.Size(162, 32);
            this.applicationsToolStripMenuItem.Text = "Applications.";
            // 
            // drivingLicenseServicesToolStripMenuItem
            // 
            this.drivingLicenseServicesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewDrivingLicense,
            this.RenewDrivingLicense,
            this.ReplacementForLostOrDamaged,
            this.ReleaseDetainedDrivingLicense,
            this.RetakeATest});
            this.drivingLicenseServicesToolStripMenuItem.Image = global::DVLD.Properties.Resources.New_Driving_License_32;
            this.drivingLicenseServicesToolStripMenuItem.Name = "drivingLicenseServicesToolStripMenuItem";
            this.drivingLicenseServicesToolStripMenuItem.Size = new System.Drawing.Size(357, 32);
            this.drivingLicenseServicesToolStripMenuItem.Text = "Driving License Services .";
            // 
            // NewDrivingLicense
            // 
            this.NewDrivingLicense.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LocalDrivingLicense,
            this.InternationalDrivingLicense});
            this.NewDrivingLicense.Image = global::DVLD.Properties.Resources.New_Driving_License_321;
            this.NewDrivingLicense.Name = "NewDrivingLicense";
            this.NewDrivingLicense.Size = new System.Drawing.Size(487, 32);
            this.NewDrivingLicense.Text = "New Driving License.";
            // 
            // LocalDrivingLicense
            // 
            this.LocalDrivingLicense.Image = global::DVLD.Properties.Resources.Local_32;
            this.LocalDrivingLicense.Name = "LocalDrivingLicense";
            this.LocalDrivingLicense.Size = new System.Drawing.Size(363, 32);
            this.LocalDrivingLicense.Text = "Local Driving License.";
            // 
            // InternationalDrivingLicense
            // 
            this.InternationalDrivingLicense.Image = global::DVLD.Properties.Resources.International_32;
            this.InternationalDrivingLicense.Name = "InternationalDrivingLicense";
            this.InternationalDrivingLicense.Size = new System.Drawing.Size(363, 32);
            this.InternationalDrivingLicense.Text = "International Driving License.";
            // 
            // RenewDrivingLicense
            // 
            this.RenewDrivingLicense.Image = global::DVLD.Properties.Resources.Renew_Driving_License_32;
            this.RenewDrivingLicense.Name = "RenewDrivingLicense";
            this.RenewDrivingLicense.Size = new System.Drawing.Size(487, 32);
            this.RenewDrivingLicense.Text = "Renew Driving License.";
            // 
            // ReplacementForLostOrDamaged
            // 
            this.ReplacementForLostOrDamaged.Image = global::DVLD.Properties.Resources.Lost_Driving_License_32;
            this.ReplacementForLostOrDamaged.Name = "ReplacementForLostOrDamaged";
            this.ReplacementForLostOrDamaged.Size = new System.Drawing.Size(487, 32);
            this.ReplacementForLostOrDamaged.Text = "Replacement for Lost or Damaged License.";
            // 
            // ReleaseDetainedDrivingLicense
            // 
            this.ReleaseDetainedDrivingLicense.Image = global::DVLD.Properties.Resources.Release_Detained_License_64;
            this.ReleaseDetainedDrivingLicense.Name = "ReleaseDetainedDrivingLicense";
            this.ReleaseDetainedDrivingLicense.Size = new System.Drawing.Size(487, 32);
            this.ReleaseDetainedDrivingLicense.Text = "Release Detained Driving License.";
            // 
            // RetakeATest
            // 
            this.RetakeATest.Image = global::DVLD.Properties.Resources.Retake_Test_32;
            this.RetakeATest.Name = "RetakeATest";
            this.RetakeATest.Size = new System.Drawing.Size(487, 32);
            this.RetakeATest.Text = "Retake a test .";
            // 
            // DetainLicense
            // 
            this.DetainLicense.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ManageDetainedLicenses,
            this.DetainALicense,
            this.ReleaseADetainedLicense});
            this.DetainLicense.Image = global::DVLD.Properties.Resources.Detain_64;
            this.DetainLicense.Name = "DetainLicense";
            this.DetainLicense.Size = new System.Drawing.Size(357, 32);
            this.DetainLicense.Text = "Detain License.";
            // 
            // ManageDetainedLicenses
            // 
            this.ManageDetainedLicenses.Image = global::DVLD.Properties.Resources.Detained_Driving_License_32;
            this.ManageDetainedLicenses.Name = "ManageDetainedLicenses";
            this.ManageDetainedLicenses.Size = new System.Drawing.Size(341, 32);
            this.ManageDetainedLicenses.Text = "Manage Detained Licenses";
            // 
            // DetainALicense
            // 
            this.DetainALicense.Image = global::DVLD.Properties.Resources.Detain_642;
            this.DetainALicense.Name = "DetainALicense";
            this.DetainALicense.Size = new System.Drawing.Size(341, 32);
            this.DetainALicense.Text = "Detain a License";
            // 
            // ReleaseADetainedLicense
            // 
            this.ReleaseADetainedLicense.Image = global::DVLD.Properties.Resources.Release_Detained_License_641;
            this.ReleaseADetainedLicense.Name = "ReleaseADetainedLicense";
            this.ReleaseADetainedLicense.Size = new System.Drawing.Size(341, 32);
            this.ReleaseADetainedLicense.Text = "Release a Detain License";
            // 
            // ManageApps
            // 
            this.ManageApps.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LocalDrivingLicenseApplications,
            this.InternationalDrivingLicenseApplications});
            this.ManageApps.Image = global::DVLD.Properties.Resources.Manage_Applications_64;
            this.ManageApps.Name = "ManageApps";
            this.ManageApps.Size = new System.Drawing.Size(357, 32);
            this.ManageApps.Text = "Manage Applications.";
            // 
            // LocalDrivingLicenseApplications
            // 
            this.LocalDrivingLicenseApplications.Image = global::DVLD.Properties.Resources.Lost_Driving_License_32;
            this.LocalDrivingLicenseApplications.Name = "LocalDrivingLicenseApplications";
            this.LocalDrivingLicenseApplications.Size = new System.Drawing.Size(480, 32);
            this.LocalDrivingLicenseApplications.Text = "Local Driving License Applications";
            // 
            // InternationalDrivingLicenseApplications
            // 
            this.InternationalDrivingLicenseApplications.Image = global::DVLD.Properties.Resources.International_32;
            this.InternationalDrivingLicenseApplications.Name = "InternationalDrivingLicenseApplications";
            this.InternationalDrivingLicenseApplications.Size = new System.Drawing.Size(480, 32);
            this.InternationalDrivingLicenseApplications.Text = "International Driving License Applications.";
            // 
            // ManageApplicationsTypes
            // 
            this.ManageApplicationsTypes.Image = global::DVLD.Properties.Resources.Application_Types_512;
            this.ManageApplicationsTypes.Name = "ManageApplicationsTypes";
            this.ManageApplicationsTypes.Size = new System.Drawing.Size(357, 32);
            this.ManageApplicationsTypes.Text = "Manage Applications Types .";
            // 
            // ManageTestsTypes
            // 
            this.ManageTestsTypes.Image = global::DVLD.Properties.Resources.TestType_32;
            this.ManageTestsTypes.Name = "ManageTestsTypes";
            this.ManageTestsTypes.Size = new System.Drawing.Size(357, 32);
            this.ManageTestsTypes.Text = "Manage Tests Types .";
            // 
            // peopleToolStripMenuItem
            // 
            this.peopleToolStripMenuItem.Image = global::DVLD.Properties.Resources.People_64;
            this.peopleToolStripMenuItem.Name = "peopleToolStripMenuItem";
            this.peopleToolStripMenuItem.Size = new System.Drawing.Size(113, 32);
            this.peopleToolStripMenuItem.Text = "People.";
            this.peopleToolStripMenuItem.Click += new System.EventHandler(this.peopleToolStripMenuItem_Click);
            // 
            // driversToolStripMenuItem
            // 
            this.driversToolStripMenuItem.Image = global::DVLD.Properties.Resources.Drivers_641;
            this.driversToolStripMenuItem.Name = "driversToolStripMenuItem";
            this.driversToolStripMenuItem.Size = new System.Drawing.Size(114, 32);
            this.driversToolStripMenuItem.Text = "Drivers.";
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Image = global::DVLD.Properties.Resources.Users_2_400;
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(101, 32);
            this.usersToolStripMenuItem.Text = "Users.";
            // 
            // accountSettingsToolStripMenuItem
            // 
            this.accountSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentUserInfoToolStripMenuItem,
            this.ChangePassword,
            this.SignOut});
            this.accountSettingsToolStripMenuItem.Image = global::DVLD.Properties.Resources.account_settings_64;
            this.accountSettingsToolStripMenuItem.Name = "accountSettingsToolStripMenuItem";
            this.accountSettingsToolStripMenuItem.Size = new System.Drawing.Size(203, 32);
            this.accountSettingsToolStripMenuItem.Text = "Account settings.";
            // 
            // currentUserInfoToolStripMenuItem
            // 
            this.currentUserInfoToolStripMenuItem.Image = global::DVLD.Properties.Resources.User_32__2;
            this.currentUserInfoToolStripMenuItem.Name = "currentUserInfoToolStripMenuItem";
            this.currentUserInfoToolStripMenuItem.Size = new System.Drawing.Size(269, 32);
            this.currentUserInfoToolStripMenuItem.Text = "Current User Info.";
            // 
            // ChangePassword
            // 
            this.ChangePassword.Image = global::DVLD.Properties.Resources.Password_32;
            this.ChangePassword.Name = "ChangePassword";
            this.ChangePassword.Size = new System.Drawing.Size(269, 32);
            this.ChangePassword.Text = "Change Password .";
            // 
            // SignOut
            // 
            this.SignOut.Image = global::DVLD.Properties.Resources.sign_out_32__2;
            this.SignOut.Name = "SignOut";
            this.SignOut.Size = new System.Drawing.Size(269, 32);
            this.SignOut.Text = "Sign out .";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::DVLD.Properties.Resources.Gemini_Generated_Image_ije9k7ije9k7ije9;
            this.pictureBox1.Location = new System.Drawing.Point(0, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1446, 600);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1446, 636);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DVLD.";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem applicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drivingLicenseServicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DetainLicense;
        private System.Windows.Forms.ToolStripMenuItem ManageApps;
        private System.Windows.Forms.ToolStripMenuItem ManageApplicationsTypes;
        private System.Windows.Forms.ToolStripMenuItem ManageTestsTypes;
        private System.Windows.Forms.ToolStripMenuItem NewDrivingLicense;
        private System.Windows.Forms.ToolStripMenuItem RenewDrivingLicense;
        private System.Windows.Forms.ToolStripMenuItem ReplacementForLostOrDamaged;
        private System.Windows.Forms.ToolStripMenuItem ReleaseDetainedDrivingLicense;
        private System.Windows.Forms.ToolStripMenuItem RetakeATest;
        private System.Windows.Forms.ToolStripMenuItem LocalDrivingLicense;
        private System.Windows.Forms.ToolStripMenuItem InternationalDrivingLicense;
        private System.Windows.Forms.ToolStripMenuItem ManageDetainedLicenses;
        private System.Windows.Forms.ToolStripMenuItem DetainALicense;
        private System.Windows.Forms.ToolStripMenuItem ReleaseADetainedLicense;
        private System.Windows.Forms.ToolStripMenuItem LocalDrivingLicenseApplications;
        private System.Windows.Forms.ToolStripMenuItem InternationalDrivingLicenseApplications;
        private System.Windows.Forms.ToolStripMenuItem peopleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem driversToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem currentUserInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ChangePassword;
        private System.Windows.Forms.ToolStripMenuItem SignOut;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}


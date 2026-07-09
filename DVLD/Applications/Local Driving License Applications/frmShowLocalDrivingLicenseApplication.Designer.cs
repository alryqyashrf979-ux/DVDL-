namespace DVLD
{
    partial class frmShowLocalDrivingLicenseApplication
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
            this.userControlLocalDrivingLicenseApplicationInfo1 = new DVLD.userControlLocalDrivingLicenseApplicationInfo();
            this.SuspendLayout();
            // 
            // userControlLocalDrivingLicenseApplicationInfo1
            // 
            this.userControlLocalDrivingLicenseApplicationInfo1.Location = new System.Drawing.Point(12, 12);
            this.userControlLocalDrivingLicenseApplicationInfo1.Name = "userControlLocalDrivingLicenseApplicationInfo1";
            this.userControlLocalDrivingLicenseApplicationInfo1.Size = new System.Drawing.Size(1065, 474);
            this.userControlLocalDrivingLicenseApplicationInfo1.TabIndex = 0;
            // 
            // frmShowLocalDrivingLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 484);
            this.Controls.Add(this.userControlLocalDrivingLicenseApplicationInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmShowLocalDrivingLicenseApplication";
            this.Text = "Show Local Driving License Application";
            this.Load += new System.EventHandler(this.frmShowLocalDrivingLicenseApplication_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private userControlLocalDrivingLicenseApplicationInfo userControlLocalDrivingLicenseApplicationInfo1;
    }
}
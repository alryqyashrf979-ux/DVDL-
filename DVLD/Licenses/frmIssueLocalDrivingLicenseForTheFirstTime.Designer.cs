namespace DVLD
{
    partial class frmIssueLocalDrivingLicenseForTheFirstTime
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
            this.lbNote = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.btnIssueDrivingLicenseForTheFirstTime = new System.Windows.Forms.Button();
            this.userControlLocalDrivingLicenseApplicationInfo1 = new DVLD.userControlLocalDrivingLicenseApplicationInfo();
            this.SuspendLayout();
            // 
            // lbNote
            // 
            this.lbNote.AutoSize = true;
            this.lbNote.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNote.Location = new System.Drawing.Point(28, 491);
            this.lbNote.Name = "lbNote";
            this.lbNote.Size = new System.Drawing.Size(62, 21);
            this.lbNote.TabIndex = 1;
            this.lbNote.Text = "Note :";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(96, 492);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(964, 123);
            this.txtNote.TabIndex = 2;
            // 
            // btnIssueDrivingLicenseForTheFirstTime
            // 
            this.btnIssueDrivingLicenseForTheFirstTime.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssueDrivingLicenseForTheFirstTime.Location = new System.Drawing.Point(933, 632);
            this.btnIssueDrivingLicenseForTheFirstTime.Name = "btnIssueDrivingLicenseForTheFirstTime";
            this.btnIssueDrivingLicenseForTheFirstTime.Size = new System.Drawing.Size(127, 44);
            this.btnIssueDrivingLicenseForTheFirstTime.TabIndex = 3;
            this.btnIssueDrivingLicenseForTheFirstTime.Text = "Issue ";
            this.btnIssueDrivingLicenseForTheFirstTime.UseVisualStyleBackColor = true;
            this.btnIssueDrivingLicenseForTheFirstTime.Click += new System.EventHandler(this.btnIssueDrivingLicenseForTheFirstTime_Click);
            // 
            // userControlLocalDrivingLicenseApplicationInfo1
            // 
            this.userControlLocalDrivingLicenseApplicationInfo1.Location = new System.Drawing.Point(12, 12);
            this.userControlLocalDrivingLicenseApplicationInfo1.Name = "userControlLocalDrivingLicenseApplicationInfo1";
            this.userControlLocalDrivingLicenseApplicationInfo1.Size = new System.Drawing.Size(1065, 474);
            this.userControlLocalDrivingLicenseApplicationInfo1.TabIndex = 0;
            // 
            // frmIssueLocalDrivingLicenseForTheFirstTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 699);
            this.Controls.Add(this.btnIssueDrivingLicenseForTheFirstTime);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.lbNote);
            this.Controls.Add(this.userControlLocalDrivingLicenseApplicationInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmIssueLocalDrivingLicenseForTheFirstTime";
            this.Text = "Issue Driving License For The First Time ";
            this.Load += new System.EventHandler(this.frmIssueLocalDrivingLicenseForTheFirstTime_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private userControlLocalDrivingLicenseApplicationInfo userControlLocalDrivingLicenseApplicationInfo1;
        private System.Windows.Forms.Label lbNote;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Button btnIssueDrivingLicenseForTheFirstTime;
    }
}
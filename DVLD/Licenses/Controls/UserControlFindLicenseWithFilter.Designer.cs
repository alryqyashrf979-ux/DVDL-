namespace DVLD
{
    partial class UserControlFindLicenseWithFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbFilterLicense = new System.Windows.Forms.GroupBox();
            this.btnFindLicense = new System.Windows.Forms.Button();
            this.txtLicenseID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.userControlShowDrivingLicense1 = new DVLD.UserControlShowDrivingLicense();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbFilterLicense.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFilterLicense
            // 
            this.gbFilterLicense.Controls.Add(this.btnFindLicense);
            this.gbFilterLicense.Controls.Add(this.txtLicenseID);
            this.gbFilterLicense.Controls.Add(this.label1);
            this.gbFilterLicense.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFilterLicense.Location = new System.Drawing.Point(3, 12);
            this.gbFilterLicense.Name = "gbFilterLicense";
            this.gbFilterLicense.Size = new System.Drawing.Size(484, 75);
            this.gbFilterLicense.TabIndex = 1;
            this.gbFilterLicense.TabStop = false;
            this.gbFilterLicense.Text = "Filter ";
            // 
            // btnFindLicense
            // 
            this.btnFindLicense.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnFindLicense.BackgroundImage = global::DVLD.Properties.Resources.New_Driving_License_32;
            this.btnFindLicense.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFindLicense.Location = new System.Drawing.Point(409, 19);
            this.btnFindLicense.Name = "btnFindLicense";
            this.btnFindLicense.Size = new System.Drawing.Size(56, 45);
            this.btnFindLicense.TabIndex = 2;
            this.btnFindLicense.UseVisualStyleBackColor = false;
            this.btnFindLicense.Click += new System.EventHandler(this.btnFindLicense_Click);
            // 
            // txtLicenseID
            // 
            this.txtLicenseID.Location = new System.Drawing.Point(138, 36);
            this.txtLicenseID.Name = "txtLicenseID";
            this.txtLicenseID.Size = new System.Drawing.Size(237, 28);
            this.txtLicenseID.TabIndex = 2;
            this.txtLicenseID.TextChanged += new System.EventHandler(this.txtLicenseID_TextChanged);
            this.txtLicenseID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLicenseID_KeyPress);
            this.txtLicenseID.Validating += new System.ComponentModel.CancelEventHandler(this.txtLicenseID_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "LicenseID :";
            // 
            // userControlShowDrivingLicense1
            // 
            this.userControlShowDrivingLicense1.Location = new System.Drawing.Point(3, 102);
            this.userControlShowDrivingLicense1.Name = "userControlShowDrivingLicense1";
            this.userControlShowDrivingLicense1.Size = new System.Drawing.Size(1041, 437);
            this.userControlShowDrivingLicense1.TabIndex = 0;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // UserControlFindLicenseWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbFilterLicense);
            this.Controls.Add(this.userControlShowDrivingLicense1);
            this.Name = "UserControlFindLicenseWithFilter";
            this.Size = new System.Drawing.Size(1055, 493);
            this.Load += new System.EventHandler(this.UserControlFindLicenseWithFilter_Load);
            this.gbFilterLicense.ResumeLayout(false);
            this.gbFilterLicense.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UserControlShowDrivingLicense userControlShowDrivingLicense1;
        private System.Windows.Forms.GroupBox gbFilterLicense;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLicenseID;
        private System.Windows.Forms.Button btnFindLicense;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}

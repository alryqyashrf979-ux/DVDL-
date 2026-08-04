namespace DVLD
{
    partial class frmShowPersonLicenseHistory
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.userControlShowPersonCardWithFilter1 = new DVLD.UserControlShowPersonCardWithFilter();
            this.userControlDriverLicenses1 = new DVLD.UserControlDriverLicenses();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(579, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(284, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Person License History ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.PersonLicenseHistory_5121;
            this.pictureBox1.Location = new System.Drawing.Point(12, 277);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(263, 262);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // userControlShowPersonCardWithFilter1
            // 
            this.userControlShowPersonCardWithFilter1.FilterEnabled = true;
            this.userControlShowPersonCardWithFilter1.Location = new System.Drawing.Point(281, 40);
            this.userControlShowPersonCardWithFilter1.Name = "userControlShowPersonCardWithFilter1";
            this.userControlShowPersonCardWithFilter1.ShowPersonCard = true;
            this.userControlShowPersonCardWithFilter1.Size = new System.Drawing.Size(1290, 499);
            this.userControlShowPersonCardWithFilter1.TabIndex = 1;
            // 
            // userControlDriverLicenses1
            // 
            this.userControlDriverLicenses1.Location = new System.Drawing.Point(12, 575);
            this.userControlDriverLicenses1.Name = "userControlDriverLicenses1";
            this.userControlDriverLicenses1.Size = new System.Drawing.Size(1559, 269);
            this.userControlDriverLicenses1.TabIndex = 3;
            this.userControlDriverLicenses1.Load += new System.EventHandler(this.userControlDriverLicenses1_Load);
            // 
            // frmShowPersonLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1576, 842);
            this.Controls.Add(this.userControlDriverLicenses1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.userControlShowPersonCardWithFilter1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShowPersonLicenseHistory";
            this.Text = "Person License History.";
            this.Load += new System.EventHandler(this.frmShowPersonLicenseHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private UserControlShowPersonCardWithFilter userControlShowPersonCardWithFilter1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private UserControlDriverLicenses userControlDriverLicenses1;
    }
}
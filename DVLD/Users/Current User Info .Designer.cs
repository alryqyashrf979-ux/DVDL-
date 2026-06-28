namespace DVLD
{
    partial class frmCurrentUser
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
            this.userControlUserInfoCard1 = new DVLD.UserControlUserInfoCard();
            this.SuspendLayout();
            // 
            // userControlUserInfoCard1
            // 
            this.userControlUserInfoCard1.Location = new System.Drawing.Point(10, 3);
            this.userControlUserInfoCard1.Name = "userControlUserInfoCard1";
            this.userControlUserInfoCard1.Size = new System.Drawing.Size(1247, 527);
            this.userControlUserInfoCard1.TabIndex = 3;
            this.userControlUserInfoCard1.Load += new System.EventHandler(this.userControlUserInfoCard1_Load);
            // 
            // frmCurrentUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 537);
            this.Controls.Add(this.userControlUserInfoCard1);
            this.Name = "frmCurrentUser";
            this.Text = "Current_User_Info";
            this.Load += new System.EventHandler(this.Current_User_Info_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControlUserInfoCard userControlUserInfoCard1;
    }
}
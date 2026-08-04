namespace DVLD
{
    partial class frmAddEditTestAppointment
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
            this.userControlScheduleTest1 = new DVLD.UserControlScheduleTest();
            this.SuspendLayout();
            // 
            // userControlScheduleTest1
            // 
            this.userControlScheduleTest1.Location = new System.Drawing.Point(33, 12);
            this.userControlScheduleTest1.Name = "userControlScheduleTest1";
            this.userControlScheduleTest1.Size = new System.Drawing.Size(552, 747);
            this.userControlScheduleTest1.TabIndex = 0;
            this.userControlScheduleTest1.TestType = DVLD_BusinessLayer.clsTestAppointment.enTestType.Vision;
            this.userControlScheduleTest1.Load += new System.EventHandler(this.userControlScheduleTest1_Load);
            // 
            // frmAddEditTestAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 813);
            this.Controls.Add(this.userControlScheduleTest1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddEditTestAppointment";
            this.Text = "Add & Edit Test Appointment";
            this.Load += new System.EventHandler(this.frmAddEditTestAppointment_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControlScheduleTest userControlScheduleTest1;
    }
}
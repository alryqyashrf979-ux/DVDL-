namespace DVLD
{
    partial class FrmTestAppointments
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
            this.components = new System.ComponentModel.Container();
            this.lbTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DgvAppointments = new System.Windows.Forms.DataGridView();
            this.CMSAppointments = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.LbRecordsCount = new System.Windows.Forms.Label();
            this.userControlLocalDrivingLicenseApplicationInfo1 = new DVLD.userControlLocalDrivingLicenseApplicationInfo();
            this.btnSchduleAppointment = new System.Windows.Forms.Button();
            this.PicTestAppointmentType = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgvAppointments)).BeginInit();
            this.CMSAppointments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicTestAppointmentType)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.ForeColor = System.Drawing.Color.Red;
            this.lbTitle.Location = new System.Drawing.Point(393, 74);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(272, 24);
            this.lbTitle.TabIndex = 2;
            this.lbTitle.Text = "Vision Test Appointments ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 578);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Appoinments :";
            // 
            // DgvAppointments
            // 
            this.DgvAppointments.AllowUserToAddRows = false;
            this.DgvAppointments.AllowUserToDeleteRows = false;
            this.DgvAppointments.AllowUserToOrderColumns = true;
            this.DgvAppointments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvAppointments.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvAppointments.ContextMenuStrip = this.CMSAppointments;
            this.DgvAppointments.GridColor = System.Drawing.SystemColors.Control;
            this.DgvAppointments.Location = new System.Drawing.Point(27, 622);
            this.DgvAppointments.Name = "DgvAppointments";
            this.DgvAppointments.ReadOnly = true;
            this.DgvAppointments.RowHeadersWidth = 51;
            this.DgvAppointments.RowTemplate.Height = 26;
            this.DgvAppointments.Size = new System.Drawing.Size(1018, 163);
            this.DgvAppointments.TabIndex = 4;
            // 
            // CMSAppointments
            // 
            this.CMSAppointments.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CMSAppointments.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.takeTestToolStripMenuItem});
            this.CMSAppointments.Name = "CMSAppointments";
            this.CMSAppointments.Size = new System.Drawing.Size(149, 56);
            this.CMSAppointments.Opening += new System.ComponentModel.CancelEventHandler(this.CMSAppointments_Opening);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::DVLD.Properties.Resources.edit_32;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            this.editToolStripMenuItem.Text = "Edit . ";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // takeTestToolStripMenuItem
            // 
            this.takeTestToolStripMenuItem.Image = global::DVLD.Properties.Resources.Test_32;
            this.takeTestToolStripMenuItem.Name = "takeTestToolStripMenuItem";
            this.takeTestToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            this.takeTestToolStripMenuItem.Text = "Take Test .";
            this.takeTestToolStripMenuItem.Click += new System.EventHandler(this.takeTestToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 788);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "# Records :";
            // 
            // LbRecordsCount
            // 
            this.LbRecordsCount.AutoSize = true;
            this.LbRecordsCount.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbRecordsCount.Location = new System.Drawing.Point(127, 788);
            this.LbRecordsCount.Name = "LbRecordsCount";
            this.LbRecordsCount.Size = new System.Drawing.Size(46, 21);
            this.LbRecordsCount.TabIndex = 7;
            this.LbRecordsCount.Text = "###";
            // 
            // userControlLocalDrivingLicenseApplicationInfo1
            // 
            this.userControlLocalDrivingLicenseApplicationInfo1.Location = new System.Drawing.Point(-2, 101);
            this.userControlLocalDrivingLicenseApplicationInfo1.Name = "userControlLocalDrivingLicenseApplicationInfo1";
            this.userControlLocalDrivingLicenseApplicationInfo1.Size = new System.Drawing.Size(1065, 457);
            this.userControlLocalDrivingLicenseApplicationInfo1.TabIndex = 0;
            // 
            // btnSchduleAppointment
            // 
            this.btnSchduleAppointment.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSchduleAppointment.BackgroundImage = global::DVLD.Properties.Resources.Schedule_Test_512;
            this.btnSchduleAppointment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSchduleAppointment.Location = new System.Drawing.Point(982, 564);
            this.btnSchduleAppointment.Name = "btnSchduleAppointment";
            this.btnSchduleAppointment.Size = new System.Drawing.Size(63, 52);
            this.btnSchduleAppointment.TabIndex = 5;
            this.btnSchduleAppointment.UseVisualStyleBackColor = false;
            this.btnSchduleAppointment.Click += new System.EventHandler(this.btnSchduleAppointment_Click);
            // 
            // PicTestAppointmentType
            // 
            this.PicTestAppointmentType.Image = global::DVLD.Properties.Resources.Vision_512;
            this.PicTestAppointmentType.Location = new System.Drawing.Point(468, -1);
            this.PicTestAppointmentType.Name = "PicTestAppointmentType";
            this.PicTestAppointmentType.Size = new System.Drawing.Size(122, 72);
            this.PicTestAppointmentType.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicTestAppointmentType.TabIndex = 1;
            this.PicTestAppointmentType.TabStop = false;
            // 
            // FrmTestAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 818);
            this.Controls.Add(this.LbRecordsCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSchduleAppointment);
            this.Controls.Add(this.DgvAppointments);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.PicTestAppointmentType);
            this.Controls.Add(this.userControlLocalDrivingLicenseApplicationInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmTestAppointments";
            this.Text = "Vision Test Appointments";
            this.Load += new System.EventHandler(this.FrmvisionTestAppointments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvAppointments)).EndInit();
            this.CMSAppointments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicTestAppointmentType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private userControlLocalDrivingLicenseApplicationInfo userControlLocalDrivingLicenseApplicationInfo1;
        private System.Windows.Forms.PictureBox PicTestAppointmentType;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DgvAppointments;
        private System.Windows.Forms.Button btnSchduleAppointment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LbRecordsCount;
        private System.Windows.Forms.ContextMenuStrip CMSAppointments;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takeTestToolStripMenuItem;
    }
}
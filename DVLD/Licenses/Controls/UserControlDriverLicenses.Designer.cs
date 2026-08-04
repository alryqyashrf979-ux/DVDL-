namespace DVLD
{
    partial class UserControlDriverLicenses
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.LocalTag = new System.Windows.Forms.TabPage();
            this.dgvLocalDrivingLicenses = new System.Windows.Forms.DataGridView();
            this.cmsLocalLicenses = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.internationalTag = new System.Windows.Forms.TabPage();
            this.dgvInternationalDrivingLicenses = new System.Windows.Forms.DataGridView();
            this.cmsInternationalLicenses = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseInfoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label = new System.Windows.Forms.Label();
            this.lbRecords = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.LocalTag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDrivingLicenses)).BeginInit();
            this.cmsLocalLicenses.SuspendLayout();
            this.internationalTag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalDrivingLicenses)).BeginInit();
            this.cmsInternationalLicenses.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1552, 229);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driver Licenses";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.LocalTag);
            this.tabControl1.Controls.Add(this.internationalTag);
            this.tabControl1.Location = new System.Drawing.Point(16, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1536, 201);
            this.tabControl1.TabIndex = 0;
            // 
            // LocalTag
            // 
            this.LocalTag.Controls.Add(this.dgvLocalDrivingLicenses);
            this.LocalTag.Location = new System.Drawing.Point(4, 30);
            this.LocalTag.Name = "LocalTag";
            this.LocalTag.Padding = new System.Windows.Forms.Padding(3);
            this.LocalTag.Size = new System.Drawing.Size(1528, 167);
            this.LocalTag.TabIndex = 0;
            this.LocalTag.Text = "Local ";
            this.LocalTag.UseVisualStyleBackColor = true;
            // 
            // dgvLocalDrivingLicenses
            // 
            this.dgvLocalDrivingLicenses.AllowUserToAddRows = false;
            this.dgvLocalDrivingLicenses.AllowUserToDeleteRows = false;
            this.dgvLocalDrivingLicenses.AllowUserToOrderColumns = true;
            this.dgvLocalDrivingLicenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLocalDrivingLicenses.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvLocalDrivingLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalDrivingLicenses.ContextMenuStrip = this.cmsLocalLicenses;
            this.dgvLocalDrivingLicenses.Location = new System.Drawing.Point(6, 6);
            this.dgvLocalDrivingLicenses.Name = "dgvLocalDrivingLicenses";
            this.dgvLocalDrivingLicenses.ReadOnly = true;
            this.dgvLocalDrivingLicenses.RowHeadersWidth = 51;
            this.dgvLocalDrivingLicenses.RowTemplate.Height = 26;
            this.dgvLocalDrivingLicenses.Size = new System.Drawing.Size(1516, 155);
            this.dgvLocalDrivingLicenses.TabIndex = 1;
            this.dgvLocalDrivingLicenses.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLocalDrivingLicenses_CellContentClick);
            this.dgvLocalDrivingLicenses.TabIndexChanged += new System.EventHandler(this.dgvLocalDrivingLicenses_TabIndexChanged);
            // 
            // cmsLocalLicenses
            // 
            this.cmsLocalLicenses.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsLocalLicenses.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseInfoToolStripMenuItem});
            this.cmsLocalLicenses.Name = "cmsLocalLicenses";
            this.cmsLocalLicenses.Size = new System.Drawing.Size(215, 58);
            // 
            // showLicenseInfoToolStripMenuItem
            // 
            this.showLicenseInfoToolStripMenuItem.Image = global::DVLD.Properties.Resources.Local_Driving_License_5121;
            this.showLicenseInfoToolStripMenuItem.Name = "showLicenseInfoToolStripMenuItem";
            this.showLicenseInfoToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.showLicenseInfoToolStripMenuItem.Text = "Show License info .";
            this.showLicenseInfoToolStripMenuItem.Click += new System.EventHandler(this.showLicenseInfoToolStripMenuItem_Click);
            // 
            // internationalTag
            // 
            this.internationalTag.Controls.Add(this.dgvInternationalDrivingLicenses);
            this.internationalTag.Location = new System.Drawing.Point(4, 30);
            this.internationalTag.Name = "internationalTag";
            this.internationalTag.Padding = new System.Windows.Forms.Padding(3);
            this.internationalTag.Size = new System.Drawing.Size(1528, 167);
            this.internationalTag.TabIndex = 1;
            this.internationalTag.Text = "International ";
            this.internationalTag.UseVisualStyleBackColor = true;
            // 
            // dgvInternationalDrivingLicenses
            // 
            this.dgvInternationalDrivingLicenses.AllowUserToAddRows = false;
            this.dgvInternationalDrivingLicenses.AllowUserToDeleteRows = false;
            this.dgvInternationalDrivingLicenses.AllowUserToOrderColumns = true;
            this.dgvInternationalDrivingLicenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInternationalDrivingLicenses.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvInternationalDrivingLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalDrivingLicenses.ContextMenuStrip = this.cmsInternationalLicenses;
            this.dgvInternationalDrivingLicenses.Location = new System.Drawing.Point(6, 6);
            this.dgvInternationalDrivingLicenses.Name = "dgvInternationalDrivingLicenses";
            this.dgvInternationalDrivingLicenses.ReadOnly = true;
            this.dgvInternationalDrivingLicenses.RowHeadersWidth = 51;
            this.dgvInternationalDrivingLicenses.RowTemplate.Height = 26;
            this.dgvInternationalDrivingLicenses.Size = new System.Drawing.Size(1520, 161);
            this.dgvInternationalDrivingLicenses.TabIndex = 0;
            // 
            // cmsInternationalLicenses
            // 
            this.cmsInternationalLicenses.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsInternationalLicenses.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseInfoToolStripMenuItem1});
            this.cmsInternationalLicenses.Name = "cmsInternationalLicenses";
            this.cmsInternationalLicenses.Size = new System.Drawing.Size(208, 30);
            // 
            // showLicenseInfoToolStripMenuItem1
            // 
            this.showLicenseInfoToolStripMenuItem1.Image = global::DVLD.Properties.Resources.International_321;
            this.showLicenseInfoToolStripMenuItem1.Name = "showLicenseInfoToolStripMenuItem1";
            this.showLicenseInfoToolStripMenuItem1.Size = new System.Drawing.Size(207, 26);
            this.showLicenseInfoToolStripMenuItem1.Text = "Show License Info .";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(20, 242);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(81, 17);
            this.label.TabIndex = 1;
            this.label.Text = "# Records :";
            // 
            // lbRecords
            // 
            this.lbRecords.AutoSize = true;
            this.lbRecords.Location = new System.Drawing.Point(107, 242);
            this.lbRecords.Name = "lbRecords";
            this.lbRecords.Size = new System.Drawing.Size(38, 17);
            this.lbRecords.TabIndex = 2;
            this.lbRecords.Text = "###";
            // 
            // UserControlDriverLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbRecords);
            this.Controls.Add(this.label);
            this.Controls.Add(this.groupBox1);
            this.Name = "UserControlDriverLicenses";
            this.Size = new System.Drawing.Size(1559, 269);
            this.Load += new System.EventHandler(this.UserControlDriverLicenses_Load);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.LocalTag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDrivingLicenses)).EndInit();
            this.cmsLocalLicenses.ResumeLayout(false);
            this.internationalTag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalDrivingLicenses)).EndInit();
            this.cmsInternationalLicenses.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage LocalTag;
        private System.Windows.Forms.TabPage internationalTag;
        private System.Windows.Forms.DataGridView dgvLocalDrivingLicenses;
        private System.Windows.Forms.DataGridView dgvInternationalDrivingLicenses;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label lbRecords;
        private System.Windows.Forms.ContextMenuStrip cmsLocalLicenses;
        private System.Windows.Forms.ToolStripMenuItem showLicenseInfoToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsInternationalLicenses;
        private System.Windows.Forms.ToolStripMenuItem showLicenseInfoToolStripMenuItem1;
    }
}

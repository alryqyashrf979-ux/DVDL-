namespace DVLD
{
    partial class frmAppTypescs
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
            this.lb = new System.Windows.Forms.Label();
            this.dgvAppsTypes = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lbRecords = new System.Windows.Forms.Label();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppsTypes)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lb
            // 
            this.lb.AutoSize = true;
            this.lb.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb.ForeColor = System.Drawing.Color.Red;
            this.lb.Location = new System.Drawing.Point(314, 171);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(235, 28);
            this.lb.TabIndex = 0;
            this.lb.Text = "Applications Types.";
            this.lb.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lb.Click += new System.EventHandler(this.label1_Click);
            // 
            // dgvAppsTypes
            // 
            this.dgvAppsTypes.AllowUserToAddRows = false;
            this.dgvAppsTypes.AllowUserToDeleteRows = false;
            this.dgvAppsTypes.AllowUserToOrderColumns = true;
            this.dgvAppsTypes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAppsTypes.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvAppsTypes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvAppsTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppsTypes.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvAppsTypes.Location = new System.Drawing.Point(49, 226);
            this.dgvAppsTypes.Name = "dgvAppsTypes";
            this.dgvAppsTypes.ReadOnly = true;
            this.dgvAppsTypes.RowHeadersWidth = 51;
            this.dgvAppsTypes.RowTemplate.Height = 26;
            this.dgvAppsTypes.Size = new System.Drawing.Size(747, 380);
            this.dgvAppsTypes.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(231, 58);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 630);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "# Records : ";
            // 
            // lbRecords
            // 
            this.lbRecords.AutoSize = true;
            this.lbRecords.Location = new System.Drawing.Point(137, 630);
            this.lbRecords.Name = "lbRecords";
            this.lbRecords.Size = new System.Drawing.Size(16, 17);
            this.lbRecords.TabIndex = 4;
            this.lbRecords.Text = "0";
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Image = global::DVLD.Properties.Resources.edit_32;
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.U)));
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.updateToolStripMenuItem.Text = "Update .";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.Application_Types_512;
            this.pictureBox1.Location = new System.Drawing.Point(330, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(198, 156);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // frmAppTypescs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 677);
            this.Controls.Add(this.lbRecords);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvAppsTypes);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAppTypescs";
            this.Text = "frmAppTypescs";
            this.Load += new System.EventHandler(this.frmAppTypescs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppsTypes)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvAppsTypes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbRecords;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
    }
}
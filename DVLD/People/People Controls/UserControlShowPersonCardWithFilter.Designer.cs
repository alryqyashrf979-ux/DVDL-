namespace DVLD
{
    partial class UserControlShowPersonCardWithFilter
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
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.btnADD = new System.Windows.Forms.Button();
            this.btnFInd = new System.Windows.Forms.Button();
            this.txtfilterby = new System.Windows.Forms.TextBox();
            this.cbFilterPersonby = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.userControlShowPersonDetails1 = new DVLD.UserControlShowPersonDetails();
            this.gbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.btnADD);
            this.gbFilter.Controls.Add(this.btnFInd);
            this.gbFilter.Controls.Add(this.txtfilterby);
            this.gbFilter.Controls.Add(this.cbFilterPersonby);
            this.gbFilter.Controls.Add(this.label1);
            this.gbFilter.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFilter.Location = new System.Drawing.Point(13, 15);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(1223, 109);
            this.gbFilter.TabIndex = 0;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter :";
            // 
            // btnADD
            // 
            this.btnADD.Image = global::DVLD.Properties.Resources.Add_Person_40;
            this.btnADD.Location = new System.Drawing.Point(727, 29);
            this.btnADD.Name = "btnADD";
            this.btnADD.Size = new System.Drawing.Size(61, 48);
            this.btnADD.TabIndex = 4;
            this.btnADD.UseVisualStyleBackColor = true;
            this.btnADD.Click += new System.EventHandler(this.btnADD_Click);
            // 
            // btnFInd
            // 
            this.btnFInd.Image = global::DVLD.Properties.Resources.SearchPerson1;
            this.btnFInd.Location = new System.Drawing.Point(631, 31);
            this.btnFInd.Name = "btnFInd";
            this.btnFInd.Size = new System.Drawing.Size(63, 47);
            this.btnFInd.TabIndex = 3;
            this.btnFInd.UseVisualStyleBackColor = true;
            this.btnFInd.Click += new System.EventHandler(this.btnFInd_Click);
            // 
            // txtfilterby
            // 
            this.txtfilterby.Location = new System.Drawing.Point(325, 41);
            this.txtfilterby.Name = "txtfilterby";
            this.txtfilterby.Size = new System.Drawing.Size(217, 28);
            this.txtfilterby.TabIndex = 2;
            this.txtfilterby.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfilterby_KeyPress);
            this.txtfilterby.Validating += new System.ComponentModel.CancelEventHandler(this.txtfilterby_Validating);
            // 
            // cbFilterPersonby
            // 
            this.cbFilterPersonby.AllowDrop = true;
            this.cbFilterPersonby.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterPersonby.FormattingEnabled = true;
            this.cbFilterPersonby.Items.AddRange(new object[] {
            "National No.",
            "Person ID."});
            this.cbFilterPersonby.Location = new System.Drawing.Point(120, 41);
            this.cbFilterPersonby.Name = "cbFilterPersonby";
            this.cbFilterPersonby.Size = new System.Drawing.Size(168, 29);
            this.cbFilterPersonby.TabIndex = 1;
            this.cbFilterPersonby.SelectedIndexChanged += new System.EventHandler(this.cbFilterPersonby_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filter by :";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // userControlShowPersonDetails1
            // 
            this.userControlShowPersonDetails1.Location = new System.Drawing.Point(14, 151);
            this.userControlShowPersonDetails1.Name = "userControlShowPersonDetails1";
            this.userControlShowPersonDetails1.Size = new System.Drawing.Size(1222, 367);
            this.userControlShowPersonDetails1.TabIndex = 1;
            this.userControlShowPersonDetails1.Load += new System.EventHandler(this.userControlShowPersonDetails1_Load);
            // 
            // UserControlShowPersonCardWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.userControlShowPersonDetails1);
            this.Controls.Add(this.gbFilter);
            this.Name = "UserControlShowPersonCardWithFilter";
            this.Size = new System.Drawing.Size(1286, 551);
            this.Load += new System.EventHandler(this.UserControlShowPersonCardWithFilter_Load);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnADD;
        public System.Windows.Forms.TextBox txtfilterby;
        public UserControlShowPersonDetails userControlShowPersonDetails1;
        public System.Windows.Forms.ComboBox cbFilterPersonby;
        public System.Windows.Forms.Button btnFInd;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}

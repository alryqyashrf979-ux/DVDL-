namespace DVLD
{
    partial class frmAddEditUser
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
            this.Lbname = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPersonInfo = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.userControlShowPersonCardWithFilter1 = new DVLD.UserControlShowPersonCardWithFilter();
            this.tabUserLoginInfo = new System.Windows.Forms.TabPage();
            this.LbUserID = new System.Windows.Forms.Label();
            this.chBIsActive = new System.Windows.Forms.CheckBox();
            this.txtConfirmedPassword = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPersonInfo.SuspendLayout();
            this.tabUserLoginInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // Lbname
            // 
            this.Lbname.AutoSize = true;
            this.Lbname.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbname.ForeColor = System.Drawing.Color.Red;
            this.Lbname.Location = new System.Drawing.Point(532, 9);
            this.Lbname.Name = "Lbname";
            this.Lbname.Size = new System.Drawing.Size(191, 34);
            this.Lbname.TabIndex = 0;
            this.Lbname.Text = "Add Person .";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPersonInfo);
            this.tabControl1.Controls.Add(this.tabUserLoginInfo);
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(2, 63);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1271, 663);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPersonInfo
            // 
            this.tabPersonInfo.Controls.Add(this.btnNext);
            this.tabPersonInfo.Controls.Add(this.userControlShowPersonCardWithFilter1);
            this.tabPersonInfo.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPersonInfo.ForeColor = System.Drawing.Color.Black;
            this.tabPersonInfo.Location = new System.Drawing.Point(4, 30);
            this.tabPersonInfo.Name = "tabPersonInfo";
            this.tabPersonInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPersonInfo.Size = new System.Drawing.Size(1263, 629);
            this.tabPersonInfo.TabIndex = 0;
            this.tabPersonInfo.Text = "Personal Info ";
            this.tabPersonInfo.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.BackgroundImage = global::DVLD.Properties.Resources.Next_32;
            this.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNext.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(1060, 563);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(137, 47);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // userControlShowPersonCardWithFilter1
            // 
            this.userControlShowPersonCardWithFilter1.FilterEnabled = true;
            this.userControlShowPersonCardWithFilter1.Location = new System.Drawing.Point(3, 6);
            this.userControlShowPersonCardWithFilter1.Name = "userControlShowPersonCardWithFilter1";
            this.userControlShowPersonCardWithFilter1.ShowPersonCard = true;
            this.userControlShowPersonCardWithFilter1.Size = new System.Drawing.Size(1253, 551);
            this.userControlShowPersonCardWithFilter1.TabIndex = 1;
            this.userControlShowPersonCardWithFilter1.Load += new System.EventHandler(this.userControlShowPersonCardWithFilter1_Load);
            // 
            // tabUserLoginInfo
            // 
            this.tabUserLoginInfo.Controls.Add(this.LbUserID);
            this.tabUserLoginInfo.Controls.Add(this.chBIsActive);
            this.tabUserLoginInfo.Controls.Add(this.txtConfirmedPassword);
            this.tabUserLoginInfo.Controls.Add(this.txtPassword);
            this.tabUserLoginInfo.Controls.Add(this.txtUserName);
            this.tabUserLoginInfo.Controls.Add(this.pictureBox4);
            this.tabUserLoginInfo.Controls.Add(this.pictureBox3);
            this.tabUserLoginInfo.Controls.Add(this.pictureBox2);
            this.tabUserLoginInfo.Controls.Add(this.pictureBox1);
            this.tabUserLoginInfo.Controls.Add(this.label4);
            this.tabUserLoginInfo.Controls.Add(this.label3);
            this.tabUserLoginInfo.Controls.Add(this.label2);
            this.tabUserLoginInfo.Controls.Add(this.label1);
            this.tabUserLoginInfo.Location = new System.Drawing.Point(4, 30);
            this.tabUserLoginInfo.Name = "tabUserLoginInfo";
            this.tabUserLoginInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabUserLoginInfo.Size = new System.Drawing.Size(1263, 629);
            this.tabUserLoginInfo.TabIndex = 1;
            this.tabUserLoginInfo.Text = "Login Info ";
            this.tabUserLoginInfo.UseVisualStyleBackColor = true;
            // 
            // LbUserID
            // 
            this.LbUserID.AutoSize = true;
            this.LbUserID.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbUserID.Location = new System.Drawing.Point(330, 82);
            this.LbUserID.Name = "LbUserID";
            this.LbUserID.Size = new System.Drawing.Size(45, 21);
            this.LbUserID.TabIndex = 8;
            this.LbUserID.Text = "??? ";
            // 
            // chBIsActive
            // 
            this.chBIsActive.AutoSize = true;
            this.chBIsActive.Checked = true;
            this.chBIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chBIsActive.Location = new System.Drawing.Point(265, 280);
            this.chBIsActive.Name = "chBIsActive";
            this.chBIsActive.Size = new System.Drawing.Size(142, 25);
            this.chBIsActive.TabIndex = 4;
            this.chBIsActive.Text = "     Is Active .";
            this.chBIsActive.UseVisualStyleBackColor = true;
            // 
            // txtConfirmedPassword
            // 
            this.txtConfirmedPassword.Location = new System.Drawing.Point(334, 206);
            this.txtConfirmedPassword.Name = "txtConfirmedPassword";
            this.txtConfirmedPassword.PasswordChar = '*';
            this.txtConfirmedPassword.Size = new System.Drawing.Size(179, 28);
            this.txtConfirmedPassword.TabIndex = 3;
            this.txtConfirmedPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtConfirmedPassword_Validating);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(334, 160);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(179, 28);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Validating);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(334, 114);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(179, 28);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.Validating += new System.ComponentModel.CancelEventHandler(this.txt_Validating);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLD.Properties.Resources.Password_32;
            this.pictureBox4.Location = new System.Drawing.Point(265, 198);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(44, 36);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 7;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD.Properties.Resources.Password_32;
            this.pictureBox3.Location = new System.Drawing.Point(265, 151);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(44, 36);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD.Properties.Resources.Person_32;
            this.pictureBox2.Location = new System.Drawing.Point(265, 109);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(44, 36);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.Number_32;
            this.pictureBox1.Location = new System.Drawing.Point(265, 67);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(44, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(147, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Username : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(147, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(56, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Confirmed Password : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(168, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "User ID : ";
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = global::DVLD.Properties.Resources.Save_32;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(1066, 735);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(137, 47);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddEditUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 794);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.Lbname);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddEditUser";
            this.Text = "Add & Edit User ";
            this.Load += new System.EventHandler(this.frmAddEditUser_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPersonInfo.ResumeLayout(false);
            this.tabUserLoginInfo.ResumeLayout(false);
            this.tabUserLoginInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbname;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPersonInfo;
        private System.Windows.Forms.TabPage tabUserLoginInfo;
        private UserControlShowPersonCardWithFilter userControlShowPersonCardWithFilter1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtConfirmedPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chBIsActive;
        private System.Windows.Forms.Label LbUserID;
    }
}
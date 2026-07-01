using DVLD_BusinessLayer;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DVLD
{
    public partial class frmLogin : Form
    {
        enum enPasswordShowMode { Show = 0 , Hide =1};
        enPasswordShowMode Mode = enPasswordShowMode.Show;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string Data = File.ReadAllText(@"C:\Users\ALSAKHRA PC\Desktop\MyDVLD\DVLD\Remeber.txt");
            if (!string.IsNullOrEmpty(Data))
            {
                chkRemeberMe.Checked = true;
                txtuserName.Text = Data.Split('#')[0].Trim();
                txtPassword.Text = Data.Split('#')[1].Trim();
            }
        }
        private void gunaPictureBox1_Click(object sender, EventArgs e)
        {
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsUser User = clsUser.Find(txtuserName.Text.ToString().Trim(), txtPassword.Text.ToString().Trim());
                if (User != null)
                {
                if ( !User.IsActive)
                {
                    MessageBox.Show("This user is not active , please contact your admin .","Error .",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (chkRemeberMe.Checked)
                {
                    string Line = txtuserName.Text.Trim() + "#" + txtPassword.Text.Trim();
                    File.WriteAllText(@"C:\Users\ALSAKHRA PC\Desktop\MyDVLD\DVLD\Remeber.txt", Line);
                }
                else
                {
                    File.WriteAllText(@"C:\Users\ALSAKHRA PC\Desktop\MyDVLD\DVLD\Remeber.txt", "");
                }
                clsGlobal.CurrentUser = User;
                MainForm frmMainForm = new MainForm(clsGlobal.CurrentUser);
                    frmMainForm.ShowDialog();
                this.Close();
                }
                else
                {
                MessageBox.Show("Username or password is incorrect , try again .", "Error .", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                  
        }

        private void btnShowOrHidePassword_Click(object sender, EventArgs e)
        {
            switch (Mode)
            {
                case enPasswordShowMode.Show:
                    {
                        btnShowOrHidePassword.BackgroundImage = Properties.Resources.Hide_;
                        txtPassword.PasswordChar = '\0';
                        Mode = enPasswordShowMode.Hide;
                        break;
                    }
                case enPasswordShowMode.Hide:
                    {
                        btnShowOrHidePassword.BackgroundImage = Properties.Resources.Show;
                        txtPassword.PasswordChar = '*';
                        Mode = enPasswordShowMode.Show;
                        break;
                    }    
            }   
        }

        private void txt_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(((TextBox)sender).Text) )
            {
                e.Cancel = true;
                errorProvider1.SetError(((TextBox)sender), "This field should not be empty .");

                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(((TextBox)sender), null);
            }
        }

        private void chkRemeberMe_CheckedChanged(object sender, EventArgs e)
        {
          
          
        }
    }
}
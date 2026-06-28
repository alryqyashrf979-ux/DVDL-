using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmChangePassword : Form
    {
        clsUser _CurrentUser = null;
        public frmChangePassword(clsUser User)
        {
            InitializeComponent();
            _CurrentUser = User;

        }
        private void _ResetDefaultValues()
        {
          txtConfirmedPassword.Text = string.Empty; 
            txtCurrentPassword.Text = string.Empty;
            txtNewPassword.Text = string.Empty;
            txtCurrentPassword.Focus();
        }
        private void txt_Validating(object sender, CancelEventArgs e)
        {
              if( string.IsNullOrEmpty(((TextBox)sender).Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(((TextBox)sender), "This Field must not be empty .");
            }
            else
            {
                e.Cancel = false; errorProvider1.SetError(((TextBox)sender), null);
            }
              
        }
        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            txt_Validating(sender, e);
            if (txtCurrentPassword.Text.Trim() != _CurrentUser.Password.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, " this does not equal the current user password .");
            }
        }
        private void txtConfirmedPassword_Validating(object sender, CancelEventArgs e)
        {
            txt_Validating(sender, e);
            if (txtNewPassword.Text.Trim() != txtConfirmedPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmedPassword, "This password does not match the new password .");
            }

            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtConfirmedPassword, null);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show(" could not save due to some validations vaiolations .", "Error .", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _CurrentUser.Password = txtNewPassword.Text.Trim();
            if (_CurrentUser.Save())
            {
                MessageBox.Show("Password changed successfully .", "Confirm .", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _ResetDefaultValues();
                return;
            }
            MessageBox.Show("user was not updated .", "Error .", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }
    


        private void userControlUserInfoCard1_Load(object sender, EventArgs e)
        {

        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if (_CurrentUser != null) {
                
                    userControlUserInfoCard1.LoadDataFromObjectToForm(_CurrentUser);
                }
            else
            {
                MessageBox.Show("This user is not found .", "Error .", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtCurrentPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            txt_Validating(sender, e);
            if (txtNewPassword.Text.Trim() == _CurrentUser.Password.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "New password should not equal the current password .");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtNewPassword, null);
            }
        }
    }
}

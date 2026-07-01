using DVLD_BusinessLayer;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmAddEditUser : Form
    {
        enum enMode { Add =1, Edit =2};
        enMode Mode = enMode.Add;
        clsUser User = new clsUser();
        public frmAddEditUser()
        {
            InitializeComponent();
            Mode = enMode.Add;
        }
        public frmAddEditUser(int UserID)
        {
            InitializeComponent();
            User = clsUser.Find(UserID);
           
            Mode = enMode.Edit;
        }
        private void userControlShowPersonCardWithFilter1_Load(object sender, EventArgs e)
        {
        if(Mode == enMode.Edit)
            {
                GetDataFromObjectToForm();
            }  
        }
        private void ResetAllControls()
        {
            LbUserID.Text = "???";
            txtConfirmedPassword.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtUserName.Text = string.Empty;
        }

        private void SaveDataToObject()
        {
          User.PersonID = userControlShowPersonCardWithFilter1.PersonID;
          User.IsActive = chBIsActive.Checked;
          User.Username = txtUserName.Text.Trim();
          User.Password = txtPassword.Text.Trim();
        }
        private void GetDataFromObjectToForm()
        {
            if (User != null)
            {
                userControlShowPersonCardWithFilter1.userControlShowPersonDetails1.
                     LoadDataToPersonInfoCard(User.PersonID);
                Lbname.Text = "Edit user .";
                userControlShowPersonCardWithFilter1.FilterEnabled = false;
                txtPassword.Text = User.Password;
                txtUserName.Text = User.Username;
                chBIsActive.Checked = User.IsActive;
                LbUserID.Text = User.UserID.ToString();
            }
            else
            {
               if( MessageBox.Show("User is not found .","Error .",MessageBoxButtons.OK,
                    MessageBoxIcon.Error)==DialogResult.OK)
                {
                    this.Close();
                }
            }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (userControlShowPersonCardWithFilter1.PersonID == -1 && userControlShowPersonCardWithFilter1.
                FilterEnabled != false)
            {
                MessageBox.Show("Person was not found .", "Error .",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                //tabUserLoginInfo.Hide();
                return;
            }
            else if (clsUser.DoesUserExist(userControlShowPersonCardWithFilter1.PersonID))
            {
                MessageBox.Show("This person is already a user in the system .", "Error .",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
              //  tabUserLoginInfo.Hide();
                return;
            }
            else
            {
                // To show and scroll to next tab user .
               // tabUserLoginInfo.Show();
                tabControl1.SelectedTab = tabUserLoginInfo;
            }
                
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren()&& userControlShowPersonCardWithFilter1.FilterEnabled!=false)
            {
                MessageBox.Show("Some fields are not valid .", "Error .",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
          else if (clsUser.DoesUserExist(userControlShowPersonCardWithFilter1.PersonID)&& Mode != enMode.Edit)
            {
                MessageBox.Show("This person is already a user in the system .", "Error .",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                switch (Mode)
                {
                    case enMode.Add:
                        {
                            SaveDataToObject();
                            if (User.Save())
                            {
                                MessageBox.Show("User was added successfully .",
                                    "Confirmation .", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Mode = enMode.Edit;
                                userControlShowPersonCardWithFilter1.FilterEnabled = false;
                                Lbname.Text = "Edit user .";
                            }
                            else
                            {

                                MessageBox.Show("User was not saved .",
                                 "Confirmation .", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            break;
                        }
                    case enMode.Edit:
                        {
                            SaveDataToObject();
                            if (User.Save())
                            {
                                MessageBox.Show("User was Edited successfully .",
                                    "Confirmation .", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Mode = enMode.Add;
                            }
                            else
                            {

                                MessageBox.Show("User was not saved .",
                                 "Confirmation .", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            break;
                        }
                }

            }
        }

        private void txt_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(((TextBox)sender).Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(((TextBox)sender), "this field must not be empty .");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(((TextBox)sender), null);
            }
        }
        private void txtConfirmedPassword_Validating(object sender, CancelEventArgs e)
        {
            txt_Validating(sender,e);
            if(txtPassword.Text.Trim()!= txtConfirmedPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmedPassword, "this does not match the password .");
            }
            else 
            {
                e.Cancel = false;
                errorProvider1.SetError(txtConfirmedPassword,null);
            }
        }
        private void frmAddEditUser_Load(object sender, EventArgs e)
        {
            userControlShowPersonCardWithFilter1.txtfilterby.Focus();
        }
    }
}
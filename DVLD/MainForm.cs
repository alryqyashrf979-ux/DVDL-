using DVLD_BusinessLayer;
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
    public partial class MainForm : Form
    {
        public clsUser CurrentUser = null; 
        public MainForm(clsUser User)
        {
            InitializeComponent();
            CurrentUser = User;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PeopleMainForm PPlForm = new PeopleMainForm();
          
      
            PPlForm.Show();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsersMainForm UsersManagementForm = new FrmUsersMainForm();
            UsersManagementForm.Show();

        }

        private void SignOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            // we used Hide in order to hide the form immediately when clicking on Sign out tap and then close it , since it cannot be closed immediately .
            this.Close();
          
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            frmLogin LoginForm = new frmLogin();
            LoginForm.ShowDialog();
            this.Close();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCurrentUser currentUser = new frmCurrentUser(CurrentUser);
            currentUser.ShowDialog();
        }

        private void ChangePassword_Click(object sender, EventArgs e)
        {
            frmChangePassword changePasswordForm = new frmChangePassword(CurrentUser);
            changePasswordForm.ShowDialog();
        }

        private void applicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ManageApplicationsTypes_Click(object sender, EventArgs e)
        {
            frmAppTypescs AppTypesForm = new frmAppTypescs();
            AppTypesForm.ShowDialog();
        }

        private void ManageTestsTypes_Click(object sender, EventArgs e)
        {
            frmTestTypesList testTypesList = new frmTestTypesList();
            testTypesList.ShowDialog();

        }

        private void LocalDrivingLicenseApplications_Click(object sender, EventArgs e)
        {

            FrmLocalDrivingLicenseApplications localDrivingLicenseApplications = new FrmLocalDrivingLicenseApplications();
            localDrivingLicenseApplications.ShowDialog();
        }

        private void LocalDrivingLicense_Click(object sender, EventArgs e)
        {
           frmAddEditLocalDrivingLicenseApplication Add = new frmAddEditLocalDrivingLicenseApplication();
            Add.ShowDialog();
        }

        private void RenewDrivingLicense_Click(object sender, EventArgs e)
        {
            frmRenewLicense renewLicenseForm = new frmRenewLicense();
            renewLicenseForm.ShowDialog();

        }

        private void ReplacementForLostOrDamaged_Click(object sender, EventArgs e)
        {
            FrmReplaceForLostOrDamagedLicense ReplacementForm = new FrmReplaceForLostOrDamagedLicense();
            ReplacementForm.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDriversList driversList = new FrmDriversList();
            driversList.ShowDialog();
        }

        private void DetainALicense_Click(object sender, EventArgs e)
        {
            FrmDetainLicense DetainLicenseForm = new FrmDetainLicense();
            DetainLicenseForm.ShowDialog();
        }

        private void ManageDetainedLicenses_Click(object sender, EventArgs e)
        {
            FrmManageDetainedLicenses ManageDetainLicensesform = new FrmManageDetainedLicenses();
                    ManageDetainLicensesform.ShowDialog();
        }
    }
}

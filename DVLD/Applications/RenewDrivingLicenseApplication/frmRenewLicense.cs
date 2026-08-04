using DVLD_BusinessLayer;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_BusinessLayer.clsApplications;
using static DVLD_BusinessLayer.clsLicense;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD
{
    public partial class frmRenewLicense : Form
    {
        private int _NewLicenseID;
        public frmRenewLicense()
        {
            InitializeComponent();
        }

        private void frmRenewLicense_Load(object sender, EventArgs e)
        {
            LbApplicationDate.Text = DateTime.Now.ToString();
            lbIssueDate.Text = DateTime.Now.ToString();
            // 2 refers to Application type ID of Renew Driving license 
            LbApplicationFees.Text = clsApplicationTypes.GetTypeOfApplication(2).ApplicationTypeFee.ToString();
            LbCreatedBy.Text = clsGlobal.CurrentUser.UserID.ToString();
            llbShowNewLicenseInfo.Enabled = false;
            userControlFindLicenseWithFilter1.LicenseTextBoxFocus(); 
         
        }

  

   
        private void userControlFindLicenseWithFilter1_onLicenseSelected(int obj)
        {
            if(!userControlFindLicenseWithFilter1.License.IsLicenseExpired())
            {
                MessageBox.Show("License is not expired yet , so you can not renew it . ", "Error .", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenew.Enabled = false;
                userControlFindLicenseWithFilter1.LicenseTextBoxFocus();
                return;
            }
            btnRenew.Enabled = true;
            LbOldLicenseID.Text = userControlFindLicenseWithFilter1.License.LicenseID.ToString();
            LbExpirationDate.Text = DateTime.Now.AddYears(userControlFindLicenseWithFilter1.License.LicenseClass.DefaultValidityLength).ToString();
            float.TryParse(LbApplicationFees.Text, out float AppFees);
            float.TryParse(LbLicenseFees.Text, out float LicenseFees);
            LbTotalFees.Text = (AppFees + LicenseFees ).ToString();
            LbLicenseFees.Text = userControlFindLicenseWithFilter1.License.PaidFees.ToString();

        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to renew this license ???? ", "Confirm .",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Hand) == DialogResult.Cancel)
                return;

            clsLicense NewLicense = userControlFindLicenseWithFilter1.License.RenewLicense(txtNote.Text.ToString().Trim(), clsGlobal.CurrentUser.UserID); 
           
                MessageBox.Show("License with ID "+userControlFindLicenseWithFilter1.LicenseID+" was renewed successfully .","Confirm .",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            LbRLApplicationID.Text = NewLicense.ApplicationID.ToString();
                LbRenewedLicenseID.Text = NewLicense.LicenseID.ToString();
            btnRenew.Enabled = false;
            llbShowNewLicenseInfo.Enabled = true;
            userControlFindLicenseWithFilter1.FilterEnabled = false;
            _NewLicenseID = NewLicense.LicenseID;

           



        }

        private void llbShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowDrivingLicense ShowDrivingLicenseForm = new frmShowDrivingLicense(_NewLicenseID);
            ShowDrivingLicenseForm.ShowDialog();
        }

        private void userControlFindLicenseWithFilter1_Load(object sender, EventArgs e)
        {

        }
    }
}

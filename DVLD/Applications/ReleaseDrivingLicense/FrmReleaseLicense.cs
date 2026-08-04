using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class FrmReleaseLicense : Form
    {
        private int _LicenseID = -1;
        private clsLicense _License;
        public FrmReleaseLicense()
        {
            InitializeComponent();
        }
        public FrmReleaseLicense(int LicenseID)
        {
            _LicenseID = LicenseID;
            InitializeComponent();
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void FrmReleaseLicense_Load(object sender, EventArgs e)
        {
            btnRelease.Enabled = false;
            LLbShowDriverInfo.Enabled = false;
            LLbShowPersonHistory.Enabled = false;
            // 5 refers to Release Detained License type of application in DB.
            LbApplicationFees.Text = clsApplicationTypes.GetTypeOfApplication(5).ApplicationTypeFee.ToString();
            LbCreatedBy.Text = clsGlobal.CurrentUser.UserID.ToString();
            userControlFindLicenseWithFilter1.LicenseTextBoxFocus();
            if(_LicenseID != -1)
            {
                _License = clsLicense.FindByLicenseID(_LicenseID);
                if (!_License.DetainLicenseInfo.IsReleased)
                {
                    _FillDetainInfo();
                    btnRelease.Enabled = true;
                    LLbShowDriverInfo.Enabled = true;
                    LLbShowPersonHistory.Enabled = true;
                    userControlFindLicenseWithFilter1.Enabled = false;
                }
                else
                {
                    MessageBox.Show("License is already released .", "Error .", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  this.Close();
                    return;
                }
            }
        }
        private void _FillDetainInfo()
        {
         
            LbDetainID.Text = _License.DetainLicenseInfo.DetainID.ToString();
            LbDetainDate.Text = _License.DetainLicenseInfo.DetainDate.ToString();
            LbLicenseID.Text = _LicenseID.ToString();
            LbFineFees.Text = _License.DetainLicenseInfo.FineFees.ToString();
            // 5 refers to Release Detained License type of application in DB.
            LbTotalFees.Text = (_License.DetainLicenseInfo.FineFees + clsApplicationTypes.GetTypeOfApplication(5).ApplicationTypeFee).ToString();
        }
        private void _SetDetainInfo()
        {
            LbDetainID.Text = "[???]";
             LbDetainDate.Text = "[???]";
            LbLicenseID.Text = "[???]";
            LbFineFees.Text = "[???]";
            LbTotalFees.Text = "[???]";
        }
        private void userControlFindLicenseWithFilter1_onLicenseSelected(int obj)
        {
            _LicenseID = obj;
            if(!userControlFindLicenseWithFilter1.License.DetainLicenseInfo.IsReleased)
            {
                _FillDetainInfo();
                btnRelease.Enabled =           true;
                LLbShowDriverInfo.Enabled =    true;
                LLbShowPersonHistory.Enabled = true;
            }
            else
            {
                MessageBox.Show("License is already released .","Error .",MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRelease.Enabled =           false;
                LLbShowDriverInfo.Enabled =    false;
                LLbShowPersonHistory.Enabled = false;
                _SetDetainInfo ();
                return;
            }
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (!(MessageBox.Show("Are you sure you want to release this license ??", "Confirm .", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)) {
                int ReleaseApplicationID = -1;
                if (_License.ReleaseLicense(clsGlobal.CurrentUser.UserID, ref ReleaseApplicationID))
                {
                    LbApplicationID.Text = ReleaseApplicationID.ToString();
                    MessageBox.Show("License with License ID :"+_LicenseID+" was released successfully ." , "Confirm .", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    userControlFindLicenseWithFilter1.Enabled = false;
                    return;
                 }
                else
                {
                    MessageBox.Show("License with License ID "+_LicenseID+"  was  not released  .", "Confirm .", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
          
        }

        private void userControlFindLicenseWithFilter1_Load(object sender, EventArgs e)
        {

        }

        private void LLbShowPersonHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory showPersonLicenseHistoryForm = new frmShowPersonLicenseHistory(_License.Driver.PersonID);
            showPersonLicenseHistoryForm.ShowDialog();
        }

        private void LLbShowDriverInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowDrivingLicense showDrivingLicense = new frmShowDrivingLicense(_LicenseID);
            showDrivingLicense.ShowDialog();
        }
    }
}

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
    public partial class FrmDetainLicense : Form
    {
        private int _LicenseID;
        private clsLicense _License;
        public FrmDetainLicense()
        {
            InitializeComponent();
        }

        private void FrmDetainLicense_Load(object sender, EventArgs e)
        {
            LbShowPersonLicenseHistory.Enabled = false;
            llbShowDriverInfo.Enabled = false;
            userControlFindLicenseWithFilter1.LicenseTextBoxFocus();
            gbDetainInfo.Enabled = false;
            btnDetain.Enabled = false;
        }
        private void userControlFindLicenseWithFilter1_onLicenseSelected(int obj)
        {
            if (obj == -1)
            {
                MessageBox.Show("License was not found .", "Error .", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                gbDetainInfo.Enabled = false;
                return;
            }
            
            _LicenseID = obj;
            _License = clsLicense.FindByLicenseID(_LicenseID);

            if (_License != null)
            {
                if (!clsDetainReleaseLicenses.IsLicenseDetained(_LicenseID))
                {
                    llbShowDriverInfo.Enabled = true;
                    LbShowPersonLicenseHistory.Enabled = true;
                    btnDetain.Enabled = true;
                    gbDetainInfo.Enabled = true;
                    LbCreatedBy.Text = clsGlobal.CurrentUser.UserID.ToString();
                    LbDetainDate.Text = DateTime.Now.ToString();
                    LbLicenseID.Text = _LicenseID.ToString();
                    LbDetainID.Text = "[???]";
                    txtFineFees.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("License is already detained .", "Error .", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    LbShowPersonLicenseHistory.Enabled = true;
                    llbShowDriverInfo.Enabled = true ;
                    btnDetain.Enabled = false;
                    gbDetainInfo.Enabled = false;
                    return;
                }
            }
        }

        private void userControlFindLicenseWithFilter1_Load(object sender, EventArgs e)
        {

        }
        private void _SetModeAfterDetainLicense()
        {
            MessageBox.Show("License was detained successfully .", "confirmation .", MessageBoxButtons.OK, MessageBoxIcon.Question);
            btnDetain.Enabled = false;
            llbShowDriverInfo.Enabled = true;
            LbShowPersonLicenseHistory.Enabled = true;
            txtFineFees.Enabled = false;
          
        }
        private void _HandleSaveDetainRecord(int DetainID)
        {
            if (DetainID == -1)
            {
                MessageBox.Show("License was not detained .", "Error .", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                _SetModeAfterDetainLicense();
                LbDetainID.Text = DetainID.ToString();
            }
        }
        private void btnDetain_Click(object sender, EventArgs e)
        {
            int DetainID = -1;
            if(MessageBox.Show("Are you sure you want to detain this license ??","Confirm .",MessageBoxButtons.OKCancel, MessageBoxIcon.Stop)== DialogResult.Cancel)
            {

                return;
            }
            if (!decimal.TryParse(txtFineFees.Text, out decimal fineFees)) {
                DetainID = _License.Detain(clsGlobal.CurrentUser.UserID, fineFees);
                _HandleSaveDetainRecord(DetainID);
            }
            else
                DetainID = _License.Detain(clsGlobal.CurrentUser.UserID, 0);
            _HandleSaveDetainRecord(DetainID);
        }

        private void LbShowPersonLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory ShowPersonLicenseHistory = new frmShowPersonLicenseHistory(_License.Driver.PersonID);
            ShowPersonLicenseHistory.ShowDialog();
        }

        private void llbShowDriverInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowDrivingLicense ShowDrivingLicense = new frmShowDrivingLicense(_LicenseID);
            ShowDrivingLicense.ShowDialog();
        }
    }
    }

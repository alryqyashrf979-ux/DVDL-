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
using static System.Net.Mime.MediaTypeNames;

namespace DVLD
{
    public partial class FrmReplaceForLostOrDamagedLicense : Form
    {
        enum enReplacementReason { Lost = 3, Damaged =4};
        enReplacementReason ReplacementReason = enReplacementReason.Lost;
        private int _LicenseID;
        private clsLicense _License;
        public FrmReplaceForLostOrDamagedLicense()
        {
            InitializeComponent();
        }

        private void _ChooseReplacementOfLostLicense()
        {
            // 3 refers to application of the type Replacement of Lost License
            LbApplicationFees.Text = clsApplicationTypes.GetTypeOfApplication(3).ApplicationTypeFee.ToString();
            this.Text = "Replacement of Lost .";
            lbTitle.Text = "Replacement of Lost .";
        }
        private void _ChooseReplacementOfDamagedLicense()
        {
            // 4 refers to application of the type Replacement of Damaged License 
            LbApplicationFees.Text = clsApplicationTypes.GetTypeOfApplication(4).ApplicationTypeFee.ToString();
            this.Text = "Replacement of Damaged .";
            lbTitle.Text = "Replacement of Damaged .";
        }
        private void userControlFindLicenseWithFilter1_onLicenseSelected(int obj)
        {
            _LicenseID = obj;
             _License = clsLicense.FindByLicenseID(_LicenseID);
            if(_License==null)
            {
                _LicenseID =  -1;
                MessageBox.Show("License was not found .", "Error .", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if(!_License.IsActive)
            {
                MessageBox.Show("License is not active , License cannot be Replaced , unless it is active ."
                    , "Error .", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            btnReplace.Enabled = true;
            LbOldLicenseID.Text = _LicenseID.ToString();
        }

        private void FrmReplaceForLostOrDamagedLicense_Load(object sender, EventArgs e)
        {
            lbShowLicenseInfo.Enabled = false;
            rbReplacementForLost.Checked = true;
            LbApplicationDate.Text = DateTime.Now.ToString();
        
            if(rbReplacementForLost.Checked)
            {
                ReplacementReason = enReplacementReason.Lost;
                _ChooseReplacementOfLostLicense();
            }
            else
            {
                ReplacementReason = enReplacementReason.Damaged;
                _ChooseReplacementOfDamagedLicense();
            }
            LbCreatedBy.Text = clsGlobal.CurrentUser.UserID.ToString();
            btnReplace.Enabled = false;
        }

        private void rbReplacementForLost_CheckedChanged(object sender, EventArgs e)
        {
         
            if (rbReplacementForLost.Checked)
            {
                ReplacementReason = enReplacementReason.Lost;
                _ChooseReplacementOfLostLicense();
            }
            else
            {
                ReplacementReason = enReplacementReason.Damaged;
                _ChooseReplacementOfDamagedLicense();
            }
           
        }
        private void btnReplace_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Repalce this License ?? ",
                "Confirm .", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop) == DialogResult.Cancel)
                return;
            clsLicense NewLicense = new clsLicense();
          NewLicense=   _License.ReplaceLicense((int)ReplacementReason, clsGlobal.CurrentUser.UserID);
            if(NewLicense != null)
            {
                LbRLApplicationID.Text = NewLicense.ApplicationID.ToString();
                LbnewLicenseID.Text = NewLicense.LicenseID.ToString();
                btnReplace.Enabled=false;
                lbShowLicenseInfo.Enabled = true;
                userControlFindLicenseWithFilter1.FilterEnabled = false;
                gbReplacementType.Enabled=false;
                _License = NewLicense;
                _LicenseID = NewLicense.LicenseID;
            }
        }
        private void lbShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowDrivingLicense ShowDrivingLicenseForm = new frmShowDrivingLicense(_LicenseID);
            ShowDrivingLicenseForm.ShowDialog();
        }
    }
}

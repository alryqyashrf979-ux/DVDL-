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
    public partial class FrmIssueInternationalDrivingLicense : Form
    {
        private int _LocalLicenseID = -1;
        private int _InternationLicenseID = -1;
        private clsInternationalLicense _InternationalLicense;
        private clsLicense _License ;
        public FrmIssueInternationalDrivingLicense()
        {
            InitializeComponent();
        }

        private void FrmIssueInternationalDrivingLicense_Load(object sender, EventArgs e)
        {
            btnIssue.Enabled = false;
            llbShowPersonLicenseHistory.Enabled = false;
            llbShowLicenseInfo.Enabled = false;
            LbCreatedBy.Text = clsGlobal.CurrentUser.UserID.ToString();
            LbApplicationDate.Text = DateTime.Now.ToString();   
            // 6 refers to international license type of application 
            LbFess.Text = clsApplicationTypes.GetTypeOfApplication(6).ApplicationTypeFee.ToString();
        }
        private void userControlFindLicenseWithFilter1_onLicenseSelected(int obj)
        {
            if(!clsLicense.DoesLicenesExistByLicenseID(obj))
            {
                MessageBox.Show("License with ID " + obj + " does not exist . ", "Error .", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            _LocalLicenseID = obj;
            _License = clsLicense.FindByLicenseID(_LocalLicenseID);
            if (!_License.IsActive)
            {
                MessageBox.Show(" License is not active  . ", "Error .", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if(_License.IsLicenseExpired())
            {
                MessageBox.Show(" License is expired , cannot issue an international license . ", "Error .", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
           
            if (clsInternationalLicense.DoesInternationalLicenseExistByDriverID(_License.DriverID))
            {
                MessageBox.Show(" international License was already issued for this driver . ", "Error .", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            //userControlFindLicenseWithFilter1.LoadDataToCtrl(_LocalLicenseID);
            llbShowPersonLicenseHistory.Enabled = true;
            btnIssue.Enabled = true;
            LbLocalLicenseID.Text = _License.LicenseID.ToString();
        }

        private void llbShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmInternationalLicenseInfo InternationalLicenseInfoForm = new FrmInternationalLicenseInfo(_InternationLicenseID);
            InternationalLicenseInfoForm.ShowDialog();
        }

        private void llbShowPersonLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory showPersonLicenseHistory = new frmShowPersonLicenseHistory(_InternationalLicense.License.Driver.PersonID);
            showPersonLicenseHistory.ShowDialog();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to issue an international driving license for this driver with ID = "
                + _License.DriverID + " ?", "Confirm .", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop,MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                return;
           _InternationLicenseID = _License.IssueInternationalLicense(clsGlobal.CurrentUser.UserID);
            if(_InternationLicenseID ==-1)
            {
                MessageBox.Show("International License was not issued due to some issues .","Error .",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }
            _InternationalLicense = clsInternationalLicense.FindByInternationalLicenseID(_InternationLicenseID);
            LbInternationalApplicationID.Text = _InternationalLicense.ApplicationID.ToString();
            LbApplicationDate.Text = _InternationalLicense.Application.ApplicationDate.ToString();
            LbIssueDate.Text = _InternationalLicense.IssueDate.ToString();
            LbInternationalLicenseID.Text = _InternationLicenseID.ToString();
            LbExpirationDate.Text = _InternationalLicense   .ExpirationDate.ToString();
            btnIssue.Enabled = false;

            userControlFindLicenseWithFilter1.Enabled = false;
            llbShowLicenseInfo.Enabled = true;
            llbShowPersonLicenseHistory.Enabled = true;
            
            MessageBox.Show("International License was issued successfully .","Confirm .",MessageBoxButtons.OK, MessageBoxIcon.Question);

        }

        private void userControlFindLicenseWithFilter1_Load(object sender, EventArgs e)
        {

        }
    }
}

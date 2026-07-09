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
    public partial class userControlLocalDrivingLicenseApplicationInfo : UserControl
    {
        private int _LDLAppID = -1;
        clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
        public userControlLocalDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
           
        }

        private void gbApplicationBasicInfo_Enter(object sender, EventArgs e)
        {
           

        }

        private void userControlLocalDrivingLicenseApplicationInfo_Load(object sender, EventArgs e)
        {
           
        }

        public void LoadDataToControl(int LDLAppID)
        {
            LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseByID(LDLAppID);
            if (LocalDrivingLicenseApplication != null)
            {
                _LDLAppID = LDLAppID;
                clsUser user = clsUser.Find(LocalDrivingLicenseApplication.CreatedByUserID);
                if (user!=null)
                {
                    LbCreatedBy.Text = user.Username   ;
                }
                LbDate.Text = LocalDrivingLicenseApplication.ApplicationDate.ToString();
                LbFee.Text = LocalDrivingLicenseApplication.PaidFees.ToString();
                LbApplicant.Text = LocalDrivingLicenseApplication.ApplicantFull_Name.ToString();
                LbLDLApplicatioinID.Text  = LocalDrivingLicenseApplication.ApplicationID .ToString();
                LbLicenseClass.Text = LocalDrivingLicenseApplication.LicenseClass.ClassName;
                LbStatus.Text = LocalDrivingLicenseApplication.StatusText;
                LbStatusDate.Text = LocalDrivingLicenseApplication.LastStatusDate.ToString();
                LbType.Text = LocalDrivingLicenseApplication.ApplicationTypeInfo.ApplicationTypeTitle.ToString();
                lbID.Text = LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID .ToString();
               // lbPassedTests
            }
            else
            {
                MessageBox.Show("Local Driving License Application was not found .","Error .",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
        }

        private void llbShowPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmShowPersonDetails personDetails = new FrmShowPersonDetails(LocalDrivingLicenseApplication._ApplicantPersonID);
            personDetails.ShowDialog();
        }

        private void LLBViewLicenseDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // License Info 
        }
    }
}

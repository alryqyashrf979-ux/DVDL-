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
    public partial class frmIssueLocalDrivingLicenseForTheFirstTime : Form
    {
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsLocalDrivingLicenseApplication localDrivingLicenseApplication;
        public frmIssueLocalDrivingLicenseForTheFirstTime(int LDLAppID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LDLAppID;
        }


        private void frmIssueLocalDrivingLicenseForTheFirstTime_Load(object sender, EventArgs e)
        {
            localDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseByID(_LocalDrivingLicenseApplicationID);
            if (localDrivingLicenseApplication == null)
            {

                MessageBox.Show("Local Driving License Application was not found .","Error .",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.Close();
                return ;
            }

            string ClassName = localDrivingLicenseApplication.LicenseClass.ClassName.Trim();

            if(!clsLocalDrivingLicenseApplication.DidPersonPassAllTests(ClassName,_LocalDrivingLicenseApplicationID)) {

                MessageBox.Show(" Person did not pass all test , you have to pass all tests before ."
                    , "Error .", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            int LicenseID = clsLicense.GetActiveLicenseIDByPersonID(localDrivingLicenseApplication._ApplicantPersonID, localDrivingLicenseApplication.LicenseClassID);
            if (LicenseID!= -1 )
            {
                MessageBox.Show(" License already issued ."
                , "Error .", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            userControlLocalDrivingLicenseApplicationInfo1.LoadDataToControl(_LocalDrivingLicenseApplicationID);
            txtNote.Focus();


        }

        private void btnIssueDrivingLicenseForTheFirstTime_Click(object sender, EventArgs e)
        {
            int licenseID = localDrivingLicenseApplication.IssueLicenseForTheFirstTime(txtNote.Text, clsGlobal.CurrentUser.UserID);
            if (licenseID != -1)
            {
                MessageBox.Show(" Driving license was issued successfully .", "Confirm .", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }
            else
            {
                MessageBox.Show(" Driving license was not issued  .", "Confirm .", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
        }
    }
}

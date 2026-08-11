using DVLD.Classes;
using DVLD.Global_classes;
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
    public partial class UserControlInternationalLicenseInfo : UserControl
    {
        public int InternationalLicenseID ;
        public clsInternationalLicense InternationalLicense;
        public UserControlInternationalLicenseInfo()
        {
            InitializeComponent();
        }
        private void gbInternationalDrivingLicenseInfo_Enter(object sender, EventArgs e)
        {

        }
        public void LoadInfoToCtrl(int internationalLicenseID)
        {
            InternationalLicenseID = internationalLicenseID;
            InternationalLicense = clsInternationalLicense.FindByInternationalLicenseID(InternationalLicenseID);
            if (InternationalLicense != null)
            {
                lbName.Text = InternationalLicense.Driver.Person.Full_Name;
                LbInternationalLicenseID.Text = InternationalLicense.InternationalLicenseID.ToString();
                LbLicenseID.Text = InternationalLicense.LocalDrivingLicenseID.ToString();
                LbNationalNo.Text = InternationalLicense.Driver.Person.NationalNo.ToString();
                LbGendre.Text = InternationalLicense.Driver.Person.Gendre.ToString();
                lbIssueDate.Text = clsFormat.FormatDateToString( InternationalLicense.IssueDate).ToString();
                LbApplicationID.Text = InternationalLicense.ApplicationID.ToString();
                LbIsActive.Text = InternationalLicense.IsActive.ToString();
                LbDriverID.Text = InternationalLicense.DriverID.ToString();
                lbDateOfBirth.Text = InternationalLicense.Driver.Person.DateOfBirth.ToString();
                lbExpirationDate.Text = InternationalLicense.ExpirationDate.ToString();

                if (!string.IsNullOrEmpty(InternationalLicense.Driver.Person.ImagePath))
                    picPersonImage.Load(InternationalLicense.Driver.Person.ImagePath);
                else
                    picPersonImage.Image = Properties.Resources.Person_32;

            }
        }
    }
}

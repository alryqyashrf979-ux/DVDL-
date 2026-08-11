using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class UserControlShowDrivingLicense : UserControl
    {
        private int _LicenseID;
        private clsLicense _License;
        public UserControlShowDrivingLicense()
        {
            InitializeComponent();
            

        }

        public int LicenseID
        {
            get { return _LicenseID; }
        }
        public clsLicense SelectedLicense
        { get { return _License; } }
        private void groupBox1_Enter(object sender, EventArgs e)
        {


        }
        private void _HandlePersonImage()
        {

            if (!string.IsNullOrEmpty(_License.Driver.Person.ImagePath))
                picbPersonImage.Image = Image.FromFile(_License.Driver.Person.ImagePath);
            else
            {
                if (_License.Driver.Person.Gendre == 'F')
                {
                    picbPersonImage.Image = Properties.Resources.Female_512;
                }
                else
                   picbPersonImage.Image = Properties.Resources.Male_512;
            }
        }
        public void SetDefaultValues()
        {
            LBclass.Text =            "[???]";
            lbName.Text =             "[???]";
            LbNationalNo.Text =       "[???]";
            lbLicenseID.Text =        "[???]";
            LbGendre.Text =           "[F/M]";
            lbIssueDate.Text =        "[dd/mm/yyyy]";
            LbIssueReason.Text =      "[???]";
            lbNote.Text =             "[???]";
            lbDriverID.Text =         "[???]";
            LbIsActive.Text =         "[???]";
            LbBirthdate.Text =        "[dd/mm/yyyy]";
            LbExpiratationDate.Text = "[dd/mm/yyyy]";
            picbPersonImage.Image = Properties.Resources.Person_32;
        }
        private void _TransferDataFromObjToForm()
        {
            LBclass.Text = _License.LicenseClass.ClassName;
            lbName.Text = _License.Application.ApplicantFull_Name;
            LbNationalNo.Text = _License.Driver.Person.NationalNo;
            lbLicenseID.Text = _License.LicenseID.ToString();
            LbGendre.Text = _License.Driver.Person.Gendre.ToString();
            lbIssueDate.Text = _License.IssueDate.ToString();
            LbIssueReason.Text = _License.IssueReasonText;
            lbNote.Text = string.IsNullOrEmpty(_License.Note)  ? "No notes ." : _License.Note;
            lbDriverID.Text = _License.DriverID.ToString();
            LbIsActive.Text = _License.IsActive.ToString();
            LbBirthdate.Text = _License.Driver.Person.DateOfBirth.ToString();
            LbExpiratationDate.Text = _License.ExpirationDate.ToString();
            if(_License.DetainLicenseInfo != null)
          LbIsDetained.Text =   _License.DetainLicenseInfo.IsReleased? "No":"Yes";
            else
            {
                LbIsDetained.Text = "No";
            }
            
        }

        public void LoadDataToCtrl(int LicenseID)
        {
            _LicenseID = LicenseID;
            _License = clsLicense.FindByLicenseID(LicenseID);
            if (_License == null)
            {
                MessageBox.Show("License was not found .", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _LicenseID = -1;
                return;
            }
            else
            {
                _TransferDataFromObjToForm();
                _HandlePersonImage();
      
            }

        }
    }
}

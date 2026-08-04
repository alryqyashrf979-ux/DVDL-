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
    public partial class UserControlScheduledTest : UserControl
    {
        private int _TestTypeID = -1;
        private clsTestAppointment.enTestType _TestType = clsTestAppointment.enTestType.Vision;

        public clsTestAppointment.enTestType TestType
        {
            get { return _TestType; }
            set { _TestType = value;
                switch (TestType)
                { 
                case clsTestAppointment.enTestType.Vision:
                        {
                            picbTestype.Image = Properties.Resources.Vision_512;
                            _TestTypeID = (int)clsTestAppointment.enTestType.Vision;
                            gbTestType.Text = "Vision Test ";
                            break;
                        }
                    case clsTestAppointment.enTestType.Written:
                        {
                            picbTestype.Image = Properties.Resources.Written_Test_512;
                            gbTestType.Text = "Written Test ";
                            _TestTypeID = (int)clsTestAppointment.enTestType.Written;
                            break;
                        }
                    case clsTestAppointment.enTestType.Practical:
                        {
                            picbTestype.Image = Properties.Resources.Street_Test_32;
                            gbTestType.Text = "Street Test ";
                            _TestTypeID = (int)clsTestAppointment.enTestType.Practical;
                            break;
                        }
                }
            }
        }
        public UserControlScheduledTest()
        {
            InitializeComponent();
        }

    

        public void LoadDataToControl(int TestAppointmentID)
        {
            clsTestAppointment testAppointment = new clsTestAppointment();
            testAppointment = clsTestAppointment.FindByID(TestAppointmentID);
            if (testAppointment != null)
            {
                clsLocalDrivingLicenseApplication ldlapp =  clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseByID(testAppointment.LocalDrivingLicenseAppID);
                if (ldlapp != null) {
                    lbDClass.Text =ldlapp.LicenseClass.ClassName;
                    LbDate.Text = testAppointment.AppointmentDate.ToString();
                    LbFee.Text = clsTestTypes.Find(_TestTypeID).TestTypeFee.ToString();
                    LbLDLAppID.Text = testAppointment.LocalDrivingLicenseAppID.ToString();
                    Lbname.Text = ldlapp.FullName;
                    if(testAppointment.TestID == -1)
                    LbTestId.Text = "Not Taken yet ";
                    else
                    {
                        LbTestId .Text = testAppointment.TestID.ToString();
  
                    }
                    LbTrials.Text = ldlapp.TrialCountPerTestType((int)TestType).ToString();
                        }
            }
        }
        private void gbTestType_Enter(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class UserControlScheduleTest : UserControl
    {
        enum enMode { Add =1 , Edit  =2 }
        enMode Mode = enMode.Add;
        enum enCreationMode { FirstTimeCreation  =1 ,  RetakeTestCreation =2 }
        enCreationMode CreationMode = enCreationMode.FirstTimeCreation;

        private clsTestAppointment.enTestType _TestType = clsTestAppointment.enTestType.Vision;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication = null;
        private int _LocalDrivingLicenseApplicationID = -1;

        private int _TestAppointmentID = -1;
        private clsTestAppointment _TestAppointment = null;

        public clsTestAppointment.enTestType TestType
        {
            get { return _TestType; }
            set {
                
                _TestType = value; 
                switch(_TestType)
                {
                    case clsTestAppointment.enTestType.Vision :
                        {
                            GBTestTitle.Text = "Vision test ";
                            PicBTestType.Image = Properties.Resources.Vision_512;
                            break;
                        }
                    case clsTestAppointment.enTestType.Written:
                        {
                            GBTestTitle.Text = "Written test ";
                            PicBTestType.Image = Properties.Resources.Written_Test_512;
                            break;
                        }
                    case clsTestAppointment.enTestType.Practical:
                        {
                            GBTestTitle.Text = "Practical test ";
                            PicBTestType.Image = Properties.Resources.Street_Test_32; break;
                        }
                }
            }
        }
        private bool _HandleDoesLocalDrivingLicenseAppExist()
        {
            if( _LocalDrivingLicenseApplication == null )
            {
                MessageBox.Show("Local Driving License Application does not exist .","Error .",MessageBoxButtons.OK ,MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        public void LoadDataToCtrl(int LocalDrivingLicenseAppID , int  TestAppointmentID=-1)
        {
            if (TestAppointmentID == -1)
                Mode = enMode.Add;
            else
                Mode = enMode.Edit;


            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseAppID;
            _TestAppointmentID = TestAppointmentID;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseByID(_LocalDrivingLicenseApplicationID);
            if (!_HandleDoesLocalDrivingLicenseAppExist())
                return;

            if (_LocalDrivingLicenseApplication.DoesAttendTestType((int)_TestType))
                CreationMode = enCreationMode.RetakeTestCreation;
            else
                CreationMode = enCreationMode.FirstTimeCreation;

            if (CreationMode == enCreationMode.RetakeTestCreation)
            {
                LblTitle.Text = "Schedule Retake Test ";
                //Note that 7 refer to Retake Application Type in Db . 
                LbRetakeAppFees.Text = clsApplicationTypes.GetTypeOfApplication(7).ApplicationTypeFee.ToString();
                GBRetakeTestInfo.Enabled = true;
                LbRetakeTestAppID.Text = "0";
            }
            else
            {
                GBRetakeTestInfo.Enabled = false;
                LblTitle.Text = "Schedule Test";
                LbRetakeAppFees.Text = "0";
                LbRetakeTestAppID.Text = "N/A";
            }
            LbTrials.Text = _LocalDrivingLicenseApplication.TrialCountPerTestType((int)_TestType).ToString();
            LbLDLAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            LbLDLClass.Text = _LocalDrivingLicenseApplication.LicenseClass.ClassName;
            LbName.Text = _LocalDrivingLicenseApplication.FullName;
            LbFees.Text = clsTestTypes.Find((int)_TestType).TestTypeFee.ToString();

            if (Mode == enMode.Add)
            {
                DTPDate.MinDate = DateTime.Now;
                LbLDLAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
                LbRetakeTestAppID.Text = "N/A";
                _TestAppointment = new clsTestAppointment();
            }
            else
            {
                 if(!_LoadTestAppointmentDataToCtrl()) {return;}
               
            }

            // 1. Safely try to parse the text, defaulting to 0 if it fails
            float.TryParse(LbFees.Text, out float fees);
            float.TryParse(LbRetakeAppFees.Text, out float retakeFees);

            // 2. Do the math and assign it back as a string
            LbTotalFees.Text = (fees + retakeFees).ToString();

            if (_handleAppointmentIsLockedconstraint())
                return;
            if (_handleActiveAppointmentConstraint())
                return;
         
             if(_HandlePreviousTestConstraint())
                return ;


        }

        private bool _HandlePreviousTestConstraint()
        {
            switch(TestType)
            {
                case clsTestAppointment.enTestType.Vision:
                    {
                        LblSmallMessage.Visible = true;
                        return true;
                    }
                case clsTestAppointment.enTestType.Written:
                    {

                        if (!_LocalDrivingLicenseApplication.DidPassPreviousTestType((int)clsTestAppointment.enTestType.Vision))
                        {
                            LblSmallMessage.Text = "Cannot Sechule, Vision Test should be passed first";
                            LblSmallMessage.Visible = true;
                            btnSave.Enabled = false;
                            DTPDate.Enabled = false;
                            return false;
                        }
                        else
                        {
                            LblSmallMessage.Visible = false;
                            btnSave.Enabled = true;
                            DTPDate.Enabled = true;
                        }
                        break;

                    }
                    case clsTestAppointment.enTestType.Practical:
                    {
                        if (!_LocalDrivingLicenseApplication.DidPassPreviousTestType((int)clsTestAppointment.enTestType.Written))
                        {
                            LblSmallMessage.Text = "Cannot Sechule, Written Test should be passed first";
                            LblSmallMessage.Visible = true;
                            btnSave.Enabled = false;
                            DTPDate.Enabled = false;
                            return false;
                        }
                        else
                        {
                            LblSmallMessage.Visible = false;
                            btnSave.Enabled = true;
                            DTPDate.Enabled = true;
                        }
                        break;

                    }
                default:
                    return false;
            }
            return true;
        }
        private bool _handleAppointmentIsLockedconstraint()
        { 
        if(_TestAppointment.Is_Locked)
            {
                LblSmallMessage.Text = "Appointment has been already locked .";
                GBRetakeTestInfo.Enabled = false;
                btnSave.Enabled = false;
                DTPDate.Enabled = false;
               LblSmallMessage.Visible =true;
                return false;
            }
            LblSmallMessage.Visible =false;
            return true ;
        
        
        }
        private bool _handleActiveAppointmentConstraint()
        {
            if (Mode == enMode.Add && _LocalDrivingLicenseApplication.IsThereAnActiveScheduledTest((int)TestType))
            {
                LblSmallMessage.Text = "Person Already has an active appointment .";
                GBRetakeTestInfo.Enabled = false;
                btnSave.Enabled = false;
                DTPDate.Enabled = false;
                LbLDLAppID.Visible = true;
                return false;
            }
            LbLDLAppID.Visible = false;
            return true;

        }
        private bool _CheckTestAppointmentExist()
        {
            if (_TestAppointment == null)
            {
                MessageBox.Show("Test Appointment does not exist .", "Error .", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool _LoadTestAppointmentDataToCtrl()
        {
            _TestAppointment = clsTestAppointment.FindByID(_TestAppointmentID);
            if (!_CheckTestAppointmentExist())

            {
                btnSave.Enabled = false;
                return false;
            }
            else
            {
                btnSave.Enabled = true;

                // check if the dateTimePicker is greater or less than the dateTime now 
                if(DateTime.Compare(DTPDate.Value ,DateTime.Now)<0)
                {
                    DTPDate.MinDate = _TestAppointment.AppointmentDate;
                }
                else
                    DTPDate.MinDate = DateTime.Now;
                DTPDate.Value = _TestAppointment.AppointmentDate;
            }
            if(_TestAppointment.RetakeAppID == -1)
            {
                GBRetakeTestInfo.Enabled = false;
                LbRetakeAppFees.Text = "0";
                LbRetakeTestAppID.Text = "N/A";
            }
            else
            {
                GBRetakeTestInfo.Enabled = true;
                LbRetakeAppFees.Text = _TestAppointment.RetakeApplicationInfo.PaidFees.ToString();
                LbRetakeTestAppID.Text = _TestAppointment.RetakeAppID.ToString();
                LblTitle.Text = "Schedule Retake Test";
            }
            return true;
        }
        private bool _HandleRetakeApplication()
        {
            //this will decide to create a seperate application for retake test or not.
            // and will create it if needed , then it will linkit to the appoinment.
            if (Mode == enMode.Add && CreationMode == enCreationMode.RetakeTestCreation)
            {
                //incase the mode is add new and creation mode is retake test we should create a seperate application for it.
                //then we linke it with the appointment.

                //First Create Applicaiton 
                clsApplications Application = new clsApplications();

                Application._ApplicantPersonID = _LocalDrivingLicenseApplication._ApplicantPersonID;
                Application.ApplicationDate = DateTime.Now;
                Application.ApplicationTypeID = 7;
                Application.Status = clsApplications.enApplicationStatus.completed;
                Application.LastStatusDate = DateTime.Now;
                Application.PaidFees = clsApplicationTypes.GetTypeOfApplication(7).ApplicationTypeFee;
                Application.CreatedByUserID = clsGlobal.CurrentUser.UserID;

                if (!Application.Save())
                {
                    _TestAppointment.RetakeAppID = -1;
                    MessageBox.Show("Faild to Create application", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                _TestAppointment.RetakeAppID = Application.ApplicationID;

            }
            return true;
        }
        public UserControlScheduleTest()
        {
            InitializeComponent();
        }

        private void GBTestTitle_Enter(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
        if(_HandleRetakeApplication())
            {
                _TestAppointment.TestType = _TestType;
                _TestAppointment.LocalDrivingLicenseAppID = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID;
                _TestAppointment.AppointmentDate = DTPDate.Value;
                _TestAppointment.PaidFee = Convert.ToDecimal(LbFees.Text);
                _TestAppointment.CreatedByUserID = clsGlobal.CurrentUser.UserID;

                if (_TestAppointment.Save())
                {
                    Mode = enMode.Edit;
                    MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                    MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UserControlScheduleTest_Load(object sender, EventArgs e)
        {

        }
    }
}

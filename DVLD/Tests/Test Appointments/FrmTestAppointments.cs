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
    public partial class FrmTestAppointments : Form
    {
        enum enTestType { Vision =1 ,Written =2 , Street =3};
        enTestType testType = enTestType.Vision;
        private int _LDLAppID = -1;
        private int _TestTypeID = -1;
        clsLocalDrivingLicenseApplication _LDLApp = null;

        public FrmTestAppointments(int LDLAppID , int TestTypeID )
        {
            InitializeComponent();
            _LDLAppID = LDLAppID;
            _TestTypeID = TestTypeID;
            _LDLApp = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseByID( _LDLAppID );
            switch (TestTypeID)
            {
                case 1:
                    {
                        testType = enTestType.Vision; break;
                    }
                case 2:
                    {
                        testType = enTestType.Written; break;
                    }
                case 3:
                    {
                        testType = enTestType.Street; break;
                    }
            }
        }

        private void _Refresh()
        {
            DgvAppointments.DataSource = clsTestAppointment.GetAllAppointmentwithSpecificType((clsTestAppointment.enTestType)_TestTypeID, _LDLAppID);
        }
        private void FrmvisionTestAppointments_Load(object sender, EventArgs e)
        {
            DgvAppointments.DataSource = clsTestAppointment.GetAllAppointmentwithSpecificType((clsTestAppointment.enTestType) _TestTypeID , _LDLAppID);
            userControlLocalDrivingLicenseApplicationInfo1.LoadDataToControl( _LDLAppID);
            LbRecordsCount.Text = DgvAppointments.Rows.Count.ToString();
            switch (testType)
            {
            case enTestType.Vision:
                    {
                        this.Text = "Vision Test Type .";
                        lbTitle.Text = "Vision Test Type .";
                        PicTestAppointmentType.Image = Properties.Resources.Vision_512;
                        break;
                    }
                    case enTestType.Written:
                    {
                        this.Text = "Written Test Type .";
                        lbTitle.Text = "Written Test Type .";
                        PicTestAppointmentType.Image = Properties.Resources.Written_Test_512;
                        break;
                    }
                    case enTestType.Street:
                    {
                        this.Text = "Street Test Type .";
                        lbTitle.Text = "Street Test Type .";
                        PicTestAppointmentType.Image = Properties.Resources.Street_Test_32;
                        break;
                    }
            }

        }

        private void btnSchduleAppointment_Click(object sender, EventArgs e)
        {
            // if Applicant failed the last test of this type , then it will create an new retake test Application 
            if(!clsTest.DoesPassLastTest(_LDLAppID,_TestTypeID))
            {
            
                frmAddEditTestAppointment appointment = new frmAddEditTestAppointment(_TestTypeID, _LDLAppID );
                appointment.ShowDialog();
                _Refresh();
            }
            else if(clsTestAppointment.DoesApplicantHavePreviousTestAppointments(_LDLAppID, (clsTestAppointment.enTestType) _TestTypeID))
            {
                MessageBox.Show("This Applicant already has a test appointment .","Error .",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (DgvAppointments.Rows.Count > 0)
                {
                    int AppointmentID = Convert.ToInt32( DgvAppointments.CurrentRow.Cells[0].Value );
                    frmAddEditTestAppointment appointment = new frmAddEditTestAppointment(_TestTypeID,_LDLAppID, AppointmentID);
                  appointment.ShowDialog();
                    _Refresh();
                }
                else
                {
                    frmAddEditTestAppointment appointment = new frmAddEditTestAppointment(_TestTypeID, _LDLAppID);
                    appointment.ShowDialog();
                    _Refresh();
                }
                
            }

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AppointmentID = Convert.ToInt32(DgvAppointments.CurrentRow.Cells[0].Value);
            frmAddEditTestAppointment appointment = new frmAddEditTestAppointment(_TestTypeID,_LDLAppID, AppointmentID);
            appointment.ShowDialog();
            _Refresh();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AppointmentID = Convert.ToInt32(DgvAppointments.CurrentRow.Cells[0].Value);
            clsTest test = clsTest.FindTestByTestAppointmentID(AppointmentID);
            if (test != null)
            {
                frmTakeTest TakeTest = new frmTakeTest(AppointmentID, (clsTestAppointment.enTestType)_TestTypeID,test.TestID);
                TakeTest.ShowDialog();
                _Refresh();
            }
            else
            {
                frmTakeTest TakeTest = new frmTakeTest(AppointmentID, (clsTestAppointment.enTestType)_TestTypeID);
                TakeTest.ShowDialog();
                _Refresh();
            }
        }

        private void CMSAppointments_Opening(object sender, CancelEventArgs e)
        {
            bool IsLocked = Convert.ToBoolean(DgvAppointments.CurrentRow.Cells[3].Value);

            if (IsLocked) 
                CMSAppointments.Enabled=false;
            else
                CMSAppointments.Enabled=true;

        }
    }
}

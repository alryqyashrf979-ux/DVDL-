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
    public partial class frmTakeTest : Form
    {
        private int _TestAppointmentID = -1;
        public int TestTypeID = -1;
        private int _TestID = -1;
        private clsTestAppointment testAppointment;
        private clsTestAppointment.enTestType _TestType = clsTestAppointment.enTestType.Vision;

        clsTest Test = new clsTest();
        
        public frmTakeTest(int TestAppointmentID, clsTestAppointment.enTestType testType, int TestID =-1)
        {
            InitializeComponent();
            _TestAppointmentID = TestAppointmentID;
            _TestType = testType;
          _TestID = TestID;
        }
        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            userControlScheduledTest1.TestType = _TestType;
            userControlScheduledTest1.LoadDataToControl(_TestAppointmentID);
            if (_TestID != -1)
            {
                Test = clsTest.Find(_TestID);
                rbPass.Checked = Test.TestResult;
                if (!rbPass.Checked)
                    rbFail.Checked = true;
            }

        }
        private void _LoadDataFromScreenToObj()
        {
            Test.Note = txtNote.Text.Trim();
            Test.TestResult = (rbFail.Checked) ? false : true;
            Test.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            Test.TestAppointmentID = _TestAppointmentID;
        }
        private void userControlScheduledTest1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
             _LoadDataFromScreenToObj();
             if(Test.Add())
            {
                userControlScheduledTest1.LbTestId.Text = Test.TestID.ToString();
                testAppointment = clsTestAppointment.FindByID(Test.TestAppointmentID);
                if (testAppointment != null)
                {
                    testAppointment.Is_Locked= true;
                    if(testAppointment.Save())
                    {
                        MessageBox.Show("Test was taken successfully .", "confirm .", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        return;
                    }
                }
            
                MessageBox.Show("An Error occured .", "confirm .", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

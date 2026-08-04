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
    public partial class frmAddEditTestAppointment : Form
    {
        private int _TestTypeID = 0;
        private DVLD_BusinessLayer.clsTestAppointment.enTestType _TestType;
        private int _LocalDrivingLicenseID = 0;
        private int _AppointmentID = 0;
        public frmAddEditTestAppointment(int testTypeID, int localDrivingLicenseID, int appointmentID=-1)
        {
            InitializeComponent();
           _TestTypeID = testTypeID;
           _LocalDrivingLicenseID = localDrivingLicenseID;
           _AppointmentID = appointmentID;
           _TestType = (DVLD_BusinessLayer.clsTestAppointment.enTestType)_TestTypeID;
        }
        private void frmAddEditTestAppointment_Load(object sender, EventArgs e)
        {
            userControlScheduleTest1.TestType = _TestType;
            userControlScheduleTest1.LoadDataToCtrl(_LocalDrivingLicenseID, _AppointmentID);
        }

        private void userControlScheduleTest1_Load(object sender, EventArgs e)
        {

        }
    }
}

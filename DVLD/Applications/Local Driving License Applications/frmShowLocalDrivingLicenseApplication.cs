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
    public partial class frmShowLocalDrivingLicenseApplication : Form
    {
        public frmShowLocalDrivingLicenseApplication(int LDLAppID)
        {
            InitializeComponent();
            userControlLocalDrivingLicenseApplicationInfo1.LoadDataToControl(LDLAppID);
        }

        private void frmShowLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {

        }
    }
}

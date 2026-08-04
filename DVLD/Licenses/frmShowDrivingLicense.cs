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
    public partial class frmShowDrivingLicense : Form
    {
        private int _LicenseID;
        public frmShowDrivingLicense(int LicenseID)
        {
            InitializeComponent();
            _LicenseID = LicenseID;
        }
        private void frmShowDrivingLicense_Load(object sender, EventArgs e)
        {
            userControlShowDrivingLicense1.LoadDataToCtrl(_LicenseID);
        }
    }
}

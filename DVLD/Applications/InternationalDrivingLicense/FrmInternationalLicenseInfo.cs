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
    public partial class FrmInternationalLicenseInfo : Form
    {
         private int _InternationalLicenseID = -1 ;
        private clsInternationalLicense _InternationalLicense;
        public FrmInternationalLicenseInfo(int InternationalLicenseID)
        {
            InitializeComponent();
            _InternationalLicenseID = InternationalLicenseID;
        }

        private void FrmInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            userControlInternationalLicenseInfo1.LoadInfoToCtrl(_InternationalLicenseID);
        }
    }
}

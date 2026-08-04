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
    public partial class UserControlFindLicenseWithFilter : UserControl
    {
        public event Action<int> onLicenseSelected;

        protected virtual void LicenseSelected(int licenseId)
        {
            Action<int> handler = onLicenseSelected;
            if(handler != null)
                handler(licenseId);
        }

        private int _LicenseID;

        private clsLicense _License;

        public int LicenseID
        {
            get { return _LicenseID; }
        }

        public clsLicense License
        {
            get { return _License; }
        }
        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get { return _FilterEnabled; }
            set { _FilterEnabled = value;
                gbFilterLicense.Enabled = _FilterEnabled;
            }
        }
        public UserControlFindLicenseWithFilter()
        {
            InitializeComponent();
        }
        private void UserControlFindLicenseWithFilter_Load(object sender, EventArgs e)
        {
            txtLicenseID.Focus();
        }

        private void txtLicenseID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                btnFindLicense.PerformClick();
            }

            e.Handled = !char.IsDigit(e.KeyChar)&& !char.IsControl(e.KeyChar);
        }
        private void _SetDefaultValues()
        {
            _License = new clsLicense();
            _LicenseID = -1;
            userControlShowDrivingLicense1.SetDefaultValues();
        }
        public void LoadDataToCtrl(int LicenseID)
        {
        
          _LicenseID = LicenseID;

            _License = clsLicense.FindByLicenseID(_LicenseID);
            if (_License != null)
            {
                    txtLicenseID.Text = _LicenseID.ToString();
                    userControlShowDrivingLicense1.LoadDataToCtrl(_LicenseID);
                    if(onLicenseSelected != null && _FilterEnabled)
                        onLicenseSelected(_LicenseID);
            }
            else
            {
                MessageBox.Show(" License wan not found .", "Error .", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _SetDefaultValues();
                return;
            }
        }
        private void btnFindLicense_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("some fields are not validated .","Error .",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
             _LicenseID = Convert.ToInt32(txtLicenseID.Text);
            LoadDataToCtrl(_LicenseID);

        }

        private void txtLicenseID_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtLicenseID.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtLicenseID, "This field should not be empty .");
                return;
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtLicenseID,null);
            }
        }

        public void LicenseTextBoxFocus()
        {
            txtLicenseID.Focus();
        }
    }
}

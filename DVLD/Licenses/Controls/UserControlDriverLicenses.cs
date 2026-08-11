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
    public partial class UserControlDriverLicenses : UserControl
    {
        private int _DriverID = -1;
        private clsDrivers _Driver = new clsDrivers();
        public UserControlDriverLicenses()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        public void LoadDataToControlUsingDriverID(int DriverID)
        {
           
            _Driver = clsDrivers.FindByDriverID(DriverID);
            if(_Driver ==null)
            {
                MessageBox.Show("Driver was not found .", "Error .", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            _DriverID = _Driver.DriverID;
            tabControl1.SelectedIndex = 0;
            dgvLocalDrivingLicenses.DataSource = _Driver.GetAllLocalDrivingLicensesForDriver();
            dgvInternationalDrivingLicenses.DataSource = _Driver.GetAllInternationalDrivingLicensesForDriver();
            lbRecords.Text = dgvLocalDrivingLicenses.Rows.Count.ToString();
        }
        public void LoadDataToControlUsingPeronsID(int PersonID)
        {

            _Driver = clsDrivers.FindByPersonID(PersonID);
            if (_Driver == null)
            {
                MessageBox.Show("Driver was not found .", "Error .", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            _DriverID = _Driver.DriverID;
            tabControl1.SelectedIndex = 0;
            dgvLocalDrivingLicenses.DataSource = _Driver.GetAllLocalDrivingLicensesForDriver();
            dgvInternationalDrivingLicenses.DataSource = _Driver.GetAllInternationalDrivingLicensesForDriver();
            lbRecords.Text = dgvLocalDrivingLicenses.Rows.Count.ToString();
        }

        public void Clear()
        {
            dgvInternationalDrivingLicenses.Rows.Clear();
            dgvLocalDrivingLicenses.Rows.Clear();
        }

        private void dgvLocalDrivingLicenses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvLocalDrivingLicenses_TabIndexChanged(object sender, EventArgs e)
        {
        }

        private void UserControlDriverLicenses_Load(object sender, EventArgs e)
        {

        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = Convert.ToInt32( dgvLocalDrivingLicenses.CurrentRow.Cells[0].Value);
            frmShowDrivingLicense DrivingLicenseInfo = new frmShowDrivingLicense (LicenseID)
                ;
            DrivingLicenseInfo.ShowDialog();
        }

        private void dgvInternationalDrivingLicenses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

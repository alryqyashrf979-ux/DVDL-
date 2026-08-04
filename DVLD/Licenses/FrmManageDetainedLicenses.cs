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
    public partial class FrmManageDetainedLicenses : Form
    {
        public FrmManageDetainedLicenses()
        {
            InitializeComponent();
        }
        enum enFilterby { None = 0, DetainID = 1, LicenseID = 2, FullName = 3, NationalNo = 4, IsReleased = 5 }
        enFilterby FilterBy = enFilterby.None;
        private void FrmManageDetainedLicenses_Load(object sender, EventArgs e)
        {
            dgvDetainedLicenses.DataSource = clsDetainReleaseLicenses.GetAllRecords();
            cbFilterBy.SelectedIndex = 0;
            txtFilterBy.Enabled = false;
            LbRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();
            cbIsReleased.Visible = false;

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbFilterBy.SelectedIndex)
            {
                case 0:
                    {
                        FilterBy = enFilterby.None;
                        txtFilterBy.Enabled = false;
                        txtFilterBy.Visible = true;
                        cbIsReleased.Visible = false;
                        break;
                    }
                case 1:
                    {
                        FilterBy = enFilterby.DetainID;
                        txtFilterBy.Enabled = true;
                        txtFilterBy.Visible = true;
                        cbIsReleased.Visible = false;
                        break;
                    }
                case 2:
                    {
                        FilterBy = enFilterby.LicenseID;
                        txtFilterBy.Enabled = true;
                        txtFilterBy.Visible = true;
                        cbIsReleased.Visible = false;
                        break;
                    }
                case 3:
                    {
                        FilterBy = enFilterby.FullName;
                        txtFilterBy.Enabled = true;
                        txtFilterBy.Visible = true;
                        cbIsReleased.Visible = false;
                        break;
                    }
                case 4:
                    {
                        FilterBy = enFilterby.NationalNo;
                        txtFilterBy.Enabled = true;
                        txtFilterBy.Visible = true;
                        cbIsReleased.Visible = false;
                        break;
                    }
                case 5:
                    {
                        FilterBy = enFilterby.IsReleased;
                        txtFilterBy.Visible = false;
                        cbIsReleased.Visible = true;

                        break;
                    }
                default:
                    return;
            }
        }

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (FilterBy == enFilterby.LicenseID && FilterBy == enFilterby.DetainID)

            {
                e.Handled = !char.IsDigit(e.KeyChar) || !char.IsControl(e.KeyChar);
            }
        }

        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbIsReleased.SelectedIndex)
            {
                case 0:
                    {
                        dgvDetainedLicenses.DataSource = clsDetainReleaseLicenses.GetAllDetainRecordsByStatus(false);
                        LbRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();
                        break;
                    }
                case 1:
                    {
                        dgvDetainedLicenses.DataSource = clsDetainReleaseLicenses.GetAllDetainRecordsByStatus(true);
                        LbRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();
                        break;

                    }
            }
        }

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterBy.Text))
            {
               
                dgvDetainedLicenses.DataSource = clsDetainReleaseLicenses.GetAllRecords();
                LbRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();
                return;
            }
            else
                switch (FilterBy)
                {
                    case enFilterby.LicenseID:
                        {
                            int LicenseID = Convert.ToInt32(txtFilterBy.Text.Trim());
                            dgvDetainedLicenses.DataSource = clsDetainReleaseLicenses.FilterByLicenseID(LicenseID);
                            LbRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();
                            break;
                        }
                    case enFilterby.DetainID:
                        {
                            int DetainID = Convert.ToInt32(txtFilterBy.Text.Trim());
                            dgvDetainedLicenses.DataSource = clsDetainReleaseLicenses.FilterByDetainID(DetainID);
                            LbRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();
                            break;
                        }
                    case enFilterby.FullName:
                        {
                            dgvDetainedLicenses.DataSource = clsDetainReleaseLicenses.FilterByFullName(txtFilterBy.Text.Trim());
                            LbRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();
                            break;
                        }
                    case enFilterby.NationalNo:
                        {
                            dgvDetainedLicenses.DataSource = clsDetainReleaseLicenses.FilterByNationalNo(txtFilterBy.Text.Trim());
                            LbRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();
                            break;
                        }
                }
        }
        private void _Refresh()
        {
            dgvDetainedLicenses.DataSource = clsDetainReleaseLicenses.GetAllRecords();
            LbRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            FrmReleaseLicense releaseLicenseForm = new FrmReleaseLicense();
            releaseLicenseForm.ShowDialog();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            FrmDetainLicense DetainLicenseForm = new FrmDetainLicense();
            DetainLicenseForm.ShowDialog();
            _Refresh();
        }

        private void showPersonDetailesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = Convert.ToInt32( dgvDetainedLicenses.CurrentRow.Cells[1].Value);
            clsLicense License = clsLicense.FindByLicenseID(LicenseID);
            FrmShowPersonDetails ShowPersonDetails = new FrmShowPersonDetails(License.Driver.PersonID);
            ShowPersonDetails.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = Convert.ToInt32(dgvDetainedLicenses.CurrentRow.Cells[1].Value);
          frmShowDrivingLicense ShowDrivingLicenseForm = new frmShowDrivingLicense(LicenseID);
            ShowDrivingLicenseForm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = Convert.ToInt32(dgvDetainedLicenses.CurrentRow.Cells[1].Value);
            clsLicense License = clsLicense.FindByLicenseID(LicenseID);
            frmShowPersonLicenseHistory ShowPersonHistoryForm = new frmShowPersonLicenseHistory(License.Driver.PersonID);
            ShowPersonHistoryForm.ShowDialog();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            //check if License Released or not in order to enable or disable releaseToolStripMenueItem

            if ((bool)dgvDetainedLicenses.CurrentRow.Cells[3].Value)
                releaseToolStripMenuItem.Enabled = false;
            else
                releaseToolStripMenuItem.Enabled = true;
        }

        private void releaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = Convert.ToInt32(dgvDetainedLicenses.CurrentRow.Cells[1].Value);
            FrmReleaseLicense releaseLicenseForm = new FrmReleaseLicense(LicenseID);
            releaseLicenseForm.ShowDialog();
            _Refresh();
        }
    }
}

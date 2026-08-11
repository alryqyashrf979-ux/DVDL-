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
    public partial class FrmManageInternationalLicenses : Form
    {
        private int _DriverID = -1;
        private clsDrivers _Driver;
        enum enFilterBy
        {
            None = 0, InternationalLicenseID = 1, ApplicationID = 2, DriverID = 3,
            LocalLicenseID = 4, IsActive = 5
        };
        enFilterBy FilterBy = enFilterBy.None;
        public FrmManageInternationalLicenses()
        {
            InitializeComponent();
        }
        private void FrmManageInternationalLicenses_Load(object sender, EventArgs e)
        {
            txtFilter.Enabled = false;
            cbIsActive.Visible = false;
            cbFilterBy.SelectedIndex = 0;
            dgvInternationalLicense.DataSource = clsInternationalLicense.GetAllInternationalLicenses();
            LbRecords.Text = dgvInternationalLicense.Rows.Count.ToString();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _DriverID = Convert.ToInt32(dgvInternationalLicense.CurrentRow.Cells[2].Value);
            _Driver = clsDrivers.FindByDriverID(_DriverID);
            if (_Driver != null)
            {
                FrmShowPersonDetails ShowPersonDetailsForm = new FrmShowPersonDetails(_Driver.PersonID);
                ShowPersonDetailsForm.ShowDialog();
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbFilterBy.SelectedIndex)
            {
                case 1:
                    {
                        FilterBy = enFilterBy.InternationalLicenseID;
                        txtFilter.Visible = true;
                        txtFilter.Enabled = true;
                        //     cbIsActive.Enabled = true;
                        cbIsActive.Visible = false;
                        break;
                    }
                case 2:
                    {
                        FilterBy = enFilterBy.ApplicationID;
                        txtFilter.Visible = true;
                        txtFilter.Enabled = true;
                        //     cbIsActive.Enabled = true;
                        cbIsActive.Visible = false;
                        break;
                    }
                case 3:
                    {
                        FilterBy = enFilterBy.DriverID;
                        txtFilter.Visible = true;
                        txtFilter.Enabled = true;
                        //     cbIsActive.Enabled = true;
                        cbIsActive.Visible = false;
                        break;
                    }
                case 4:
                    {
                        FilterBy = enFilterBy.LocalLicenseID;
                        txtFilter.Visible = true;
                        txtFilter.Enabled = true;
                        //     cbIsActive.Enabled = true;
                        cbIsActive.Visible = false;
                        break;
                    }
                case 5:
                    {
                        FilterBy = enFilterBy.IsActive;
                        txtFilter.Visible = false;
                        //     cbIsActive.Enabled = true;
                        cbIsActive.Visible = true;
                        break;
                    }
                default:
                    {
                        FilterBy = enFilterBy.None;
                        txtFilter.Visible = true;
                        txtFilter.Enabled = false;
                        cbIsActive.Visible = false;
                        break;
                    }
            }
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbIsActive.SelectedIndex)
            {
                case 0:
                    {
                        dgvInternationalLicense.DataSource = clsInternationalLicense.FilterbyActivation(true);
                        break;
                    }
                case 1:
                    {
                        dgvInternationalLicense.DataSource = clsInternationalLicense.FilterbyActivation(false);
                        break;
                    }
                default:
                    {
                        dgvInternationalLicense.DataSource = clsInternationalLicense.GetAllInternationalLicenses();
                        break;
                    }
            }
            LbRecords.Text = dgvInternationalLicense.Rows.Count.ToString();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtFilter.Text)) 
                {
                dgvInternationalLicense.DataSource = clsInternationalLicense.GetAllInternationalLicenses();
                LbRecords.Text = dgvInternationalLicense.Rows.Count.ToString();
                return;
            }
            int FilterContent = -1;
            FilterContent = Convert.ToInt32(txtFilter.Text.Trim()); ;
            switch(FilterBy)
            {
                case enFilterBy.InternationalLicenseID:
                    {
                       
                        dgvInternationalLicense.DataSource = clsInternationalLicense.FilterbyInternationalLicenseID(FilterContent);
                        break;
                    }
                case enFilterBy.ApplicationID:
                    {
                       
                        dgvInternationalLicense.DataSource = clsInternationalLicense.FilterbyApplicationID(FilterContent);
                        break;
                    }
                case enFilterBy.DriverID:
                    {
                  
                        dgvInternationalLicense.DataSource = clsInternationalLicense.FilterbyDriverID(FilterContent);
                        break;
                    }
                case enFilterBy.LocalLicenseID:
                    {
                      
                        dgvInternationalLicense.DataSource = clsInternationalLicense.FilterbyLocalDrivingLicenseID(FilterContent);
                        break;
                    }
                default:
                    {
                        dgvInternationalLicense.DataSource = clsInternationalLicense.GetAllInternationalLicenses();
                        break;
                    }
            }
            LbRecords.Text = dgvInternationalLicense.Rows.Count.ToString();
        }
        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (FilterBy != enFilterBy.None && FilterBy != enFilterBy.IsActive)
            {
                e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
            }
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = Convert.ToInt32(dgvInternationalLicense.CurrentRow.Cells[0].Value);
          
           
                FrmInternationalLicenseInfo ShowInternationalLicenseInfoForm = new FrmInternationalLicenseInfo(LicenseID);
                ShowInternationalLicenseInfoForm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _DriverID = Convert.ToInt32(dgvInternationalLicense.CurrentRow.Cells[2].Value);
            _Driver = clsDrivers.FindByDriverID(_DriverID);
            if (_Driver != null)
            {
                frmShowPersonLicenseHistory ShowPersonLicenseHistory = new frmShowPersonLicenseHistory(_Driver.PersonID);
                ShowPersonLicenseHistory.ShowDialog();
            }
        }
        private void _Refresh()
        {
            dgvInternationalLicense.DataSource = clsInternationalLicense.GetAllInternationalLicenses();
            LbRecords.Text = dgvInternationalLicense.Rows.Count.ToString();
        }
        private void btnAddInternationalLicense_Click(object sender, EventArgs e)
        {
            FrmIssueInternationalDrivingLicense IssueAnInternationalDrivingLicenseForm = new FrmIssueInternationalDrivingLicense();
            IssueAnInternationalDrivingLicenseForm.ShowDialog();
            _Refresh();
        }
    }
    }

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
    public partial class FrmLocalDrivingLicenseApplications : Form
    {
        enum enFilterMode { None = 0, LDL_Apps = 1, NationalNo = 2, Full_Name = 3, Status = 4 };
        enFilterMode FilterMode = enFilterMode.None;
        public FrmLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }

        private void FrmLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            cbFilterLDLApps.SelectedIndex = 0;
            txtFilterLDLAppsBy.Visible = false;
            dgvLDLApps.DataSource = clsLocalDrivingLicenseApplication.GetAllDrivingLicenseApplicationsTable();
            LbRecords.Text = dgvLDLApps.Rows.Count.ToString();
        }

        private void cbFilterLDLApps_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbFilterLDLApps.SelectedIndex)
            {
                case 0:
                    {
                        FilterMode = enFilterMode.None;
                        txtFilterLDLAppsBy.Visible = false;

                        break;
                    }
                case 1:
                    {
                        FilterMode = enFilterMode.LDL_Apps;
                        txtFilterLDLAppsBy.Visible = true;
                        break;
                    }
                case 2:
                    {
                        FilterMode = enFilterMode.NationalNo;
                        txtFilterLDLAppsBy.Visible = true;
                        break;
                    }
                case 3:
                    {
                        FilterMode = enFilterMode.Full_Name;
                        txtFilterLDLAppsBy.Visible = true;
                        break;
                    }
                case 4:
                    {
                        FilterMode = enFilterMode.Status;
                        txtFilterLDLAppsBy.Visible = true;
                        break;
                    }
                default:
                    return;
            }
        }

        private void txtFilterLDLAppsBy_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtFilterLDLAppsBy.Text))
            {
                dgvLDLApps.DataSource= clsLocalDrivingLicenseApplication.GetAllDrivingLicenseApplicationsTable();
                LbRecords.Text = dgvLDLApps.Rows.Count.ToString();
                return;
            }
            switch (FilterMode)
            {
            case enFilterMode.None:
                    {
                       
                        dgvLDLApps.DataSource= clsLocalDrivingLicenseApplication.GetAllDrivingLicenseApplicationsTable();
                        LbRecords.Text = dgvLDLApps.Rows.Count.ToString();
                        break;
                    }
                    case enFilterMode.LDL_Apps:
                    {
                        if(int.TryParse(txtFilterLDLAppsBy.Text,out int ID))
                            {
                            dgvLDLApps.DataSource = clsLocalDrivingLicenseApplication.FilterDrivingLicenseApplicationsUsingID(ID);
                            LbRecords.Text = dgvLDLApps.Rows.Count.ToString();
                        }
                        break;
                    }
                    case enFilterMode.NationalNo:
                    {
                        dgvLDLApps.DataSource = clsLocalDrivingLicenseApplication.FilterDrivingLicenseApplicationsUsingNationalNo
                            (txtFilterLDLAppsBy.Text.Trim());
                        LbRecords.Text = dgvLDLApps.Rows.Count.ToString();
                        break;
                    }
                    case enFilterMode.Full_Name:
                    {
                        dgvLDLApps.DataSource = clsLocalDrivingLicenseApplication.FilterDrivingLicenseApplicationsUsingFullName
                            (txtFilterLDLAppsBy.Text.Trim());
                        LbRecords.Text = dgvLDLApps.Rows.Count.ToString();
                        break;
                    }
                    case enFilterMode.Status:
                    {
                        dgvLDLApps.DataSource = clsLocalDrivingLicenseApplication.FilterLocalDrivingLicenseApplicationsUsingStatus
                            (txtFilterLDLAppsBy.Text.Trim());
                        LbRecords.Text = dgvLDLApps.Rows.Count.ToString();
                        break;
                    }
            }
        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLAppID = Convert.ToInt32( dgvLDLApps.CurrentRow.Cells[0].Value);
            frmAddEditLocalDrivingLicenseApplication  editLocalDrivingLicenseApplication = new
                frmAddEditLocalDrivingLicenseApplication(LDLAppID);
            editLocalDrivingLicenseApplication.ShowDialog();
            _Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddEditLocalDrivingLicenseApplication AddNewLDLApp = new frmAddEditLocalDrivingLicenseApplication();
            AddNewLDLApp.ShowDialog();
            _Refresh();

        }
        private void _Refresh()
        {
            dgvLDLApps.DataSource = clsLocalDrivingLicenseApplication.GetAllDrivingLicenseApplicationsTable   ();
        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLAppID =Convert.ToInt32( dgvLDLApps.CurrentRow.Cells[0].Value);
            frmShowLocalDrivingLicenseApplication localDrivingLicenseApplication = new frmShowLocalDrivingLicenseApplication (LDLAppID);
            localDrivingLicenseApplication.ShowDialog();

        }
    }
}

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
            int LDLAppID = Convert.ToInt32(dgvLDLApps.CurrentRow.Cells[0].Value);
            frmAddEditLocalDrivingLicenseApplication  editLocalDrivingLicenseApplication = new
                frmAddEditLocalDrivingLicenseApplication(LDLAppID);
            editLocalDrivingLicenseApplication.ShowDialog();
            _Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int LDLAppID = Convert.ToInt32(dgvLDLApps.CurrentRow.Cells[0].Value);
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
            int LDLAppID = Convert.ToInt32(dgvLDLApps.CurrentRow.Cells[0].Value);
            frmShowLocalDrivingLicenseApplication localDrivingLicenseApplication = new frmShowLocalDrivingLicenseApplication (LDLAppID);
            localDrivingLicenseApplication.ShowDialog();
            _Refresh();


        }

        private void sechduleTestToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void visionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLAppID = Convert.ToInt32(dgvLDLApps.CurrentRow.Cells[0].Value);
            FrmTestAppointments visionTestAppointmentsform = new FrmTestAppointments (LDLAppID,(int)clsTestAppointment.enTestType.Vision );
            visionTestAppointmentsform.ShowDialog ();
            _Refresh();
        }

        private void CMSLDLApps_Opening(object sender, CancelEventArgs e)

        {
            CMSLDLApps.Enabled = true;
            editApplicationToolStripMenuItem.Enabled      = true;
            cancelApplicationToolStripMenuItem.Enabled    = true;
            cancelApplicationToolStripMenuItem.Enabled    = true;
            sechduleTestToolStripMenuItem.Enabled         = true;
            DeleteNewApplicationToolStripMenuItem.Enabled = true;
            showLicenseToolStripMenuItem.Enabled = true;
            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = true;

            string Status = dgvLDLApps.CurrentRow.Cells[6].Value.ToString().Trim();
            int PassedTests =Convert.ToInt32( dgvLDLApps.CurrentRow.Cells[5].Value );
            if (Status == "Completed")
            {
                editApplicationToolStripMenuItem.Enabled = false;
                cancelApplicationToolStripMenuItem.Enabled = false;
                sechduleTestToolStripMenuItem.Enabled = false;
                DeleteNewApplicationToolStripMenuItem.Enabled = false;
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
            }
            else if (Status == "New" && PassedTests == 1 || PassedTests ==2 )
            {
                showLicenseToolStripMenuItem.Enabled = false;
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                DeleteNewApplicationToolStripMenuItem.Enabled = false;
                editApplicationToolStripMenuItem.Enabled = false;
                showLicenseToolStripMenuItem.Enabled = false;
            }
            else if (Status == "New" && PassedTests == 3)
            {
                sechduleTestToolStripMenuItem.Enabled = false;
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = true;
                DeleteNewApplicationToolStripMenuItem.Enabled = false;
                editApplicationToolStripMenuItem.Enabled = false;
                showLicenseToolStripMenuItem.Enabled = false;
            }
            else if (Status == "New" && PassedTests == 0)
            {
                CMSLDLApps.Enabled = true;
                editApplicationToolStripMenuItem.Enabled = true;
                cancelApplicationToolStripMenuItem.Enabled = true;
             
                sechduleTestToolStripMenuItem.Enabled = true;
                DeleteNewApplicationToolStripMenuItem.Enabled = true;
                showLicenseToolStripMenuItem.Enabled = false;
                issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
            }
            else if (Status == "Cancelled")
            {
                CMSLDLApps.Enabled = false;
            }
        }

        private void sechduleTestToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            writtenTestToolStripMenuItem.Enabled = true;
            practicleTestToolStripMenuItem.Enabled = true;
            visionTestToolStripMenuItem.Enabled = true;
            string ClassName =  dgvLDLApps.CurrentRow.Cells[1].Value.ToString();
            int LDLAppID = Convert.ToInt32(dgvLDLApps.CurrentRow.Cells[0].Value);
             if (clsLocalDrivingLicenseApplication.IsVisionTestEnabled(ClassName, LDLAppID))
            {
                writtenTestToolStripMenuItem.Enabled = false;
                practicleTestToolStripMenuItem.Enabled = false;
            }
            else if (clsLocalDrivingLicenseApplication.IsWrittenTestEnabled(ClassName, LDLAppID) )
            {
                practicleTestToolStripMenuItem.Enabled = false;
                visionTestToolStripMenuItem.Enabled = false;
            }
            else if (clsLocalDrivingLicenseApplication.IsStreetTestEnabled(ClassName, LDLAppID))
            {
                visionTestToolStripMenuItem.Enabled = false;
                writtenTestToolStripMenuItem.Enabled = false;
            }
           
        }

        private void writtenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLAppID = Convert.ToInt32(dgvLDLApps.CurrentRow.Cells[0].Value);
            FrmTestAppointments writtenTestAppointmentsform = new FrmTestAppointments(LDLAppID, (int)clsTestAppointment.enTestType.Written);
            writtenTestAppointmentsform.ShowDialog();
            _Refresh();
        }

        private void practicleTestToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int LDLAppID = Convert.ToInt32(dgvLDLApps.CurrentRow.Cells[0].Value);
            FrmTestAppointments PracticleStreetTestAppointmentsform = new FrmTestAppointments(LDLAppID, (int)clsTestAppointment.enTestType.Practical);
            PracticleStreetTestAppointmentsform.ShowDialog();
            _Refresh();
        }
        private void _SaveLicenseInfo(clsLocalDrivingLicenseApplication localDrivingApplication , string NationalNo)
        {



        }
        

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLAppID = Convert.ToInt32(dgvLDLApps.CurrentRow.Cells[0].Value);
            frmIssueLocalDrivingLicenseForTheFirstTime IssueForm = new frmIssueLocalDrivingLicenseForTheFirstTime(LDLAppID);
            IssueForm.ShowDialog();
            _Refresh();
           
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLAppID = Convert.ToInt32(dgvLDLApps.CurrentRow.Cells[0].Value);
            int LicenseID = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseByID(LDLAppID).GetActiveLicenseID();
            if (LicenseID != -1)
            {
                frmShowDrivingLicense DrivingLicenseForm = new frmShowDrivingLicense(LicenseID);
                DrivingLicenseForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("License was not found .","Error .",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.Close();
                return;
            }
        }
    }
}

using DVLD.Classes;
using DVLD.Global_classes;
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
    public partial class frmAddEditLocalDrivingLicenseApplication : Form
    {
        enum enMode { Add = 1, Edit = 2 }
        enMode Mode = enMode.Add;

        int LDLAppID = -1;

        clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();

        public frmAddEditLocalDrivingLicenseApplication(int LDLAppID = -1)
        {
            InitializeComponent();
            if (LDLAppID != -1)
            {
                Mode = enMode.Edit;
                this.LDLAppID = LDLAppID;
            }
            else
                Mode = enMode.Add;
        }
        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void _FillLicenseClassComboBoxWithData()
        {
            foreach (DataRow row in clsLicenseClass.GetAllLicenseClasses().Rows)
            {
                cbLicenseClass.Items.Add(row[1].ToString());
            }
        }
        private void _SetAddEditLocalDrivingLicenseApplication()
        {

            tabApplicationInfo.Enabled = false;
            lbApplicationDate.Text = clsFormat.FormatDateToString(DateTime.Now);
            LbApplicationFee.Text = "15";
            LbCurrentUserID.Text = clsGlobal.CurrentUser.Username;
            _FillLicenseClassComboBoxWithData();
            cbLicenseClass.SelectedIndex = 2;
        }
        private void _TransferDataFromObjectToForm()
        {
            lbApplicationDate.Text = LocalDrivingLicenseApplication.ApplicationDate.ToString();
            LbApplicationFee.Text = clsApplicationTypes.GetTypeOfApplication(1).ApplicationTypeFee.ToString();
            LbCurrentUserID.Text = LocalDrivingLicenseApplication.CreatedByUserID.ToString();
            _FillLicenseClassComboBoxWithData();
            LbApplicationID.Text = LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            cbLicenseClass.SelectedIndex = LocalDrivingLicenseApplication.LicenseClassID - 1;
            tabApplicationInfo.Enabled = true;
            userControlShowPersonCardWithFilter1.userControlShowPersonDetails1.LoadDataToPersonInfoCard
                (LocalDrivingLicenseApplication._ApplicantPersonID);
            userControlShowPersonCardWithFilter1.FilterEnabled = false;

        }
        private void _TransferDatafromFormToObject()
        {
            LocalDrivingLicenseApplication.LastStatusDate = DateTime.Now;
            LocalDrivingLicenseApplication.Status = (clsApplications.enApplicationStatus)1;
            LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;
            LocalDrivingLicenseApplication.ApplicationTypeID = 1;
            LocalDrivingLicenseApplication.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            LocalDrivingLicenseApplication.LicenseClassID = cbLicenseClass.SelectedIndex + 1;
            LocalDrivingLicenseApplication.PaidFees = (decimal)15;
            LocalDrivingLicenseApplication._ApplicantPersonID = userControlShowPersonCardWithFilter1.PersonID;
        }
        private void frmAddEditLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            if (Mode == enMode.Add)
            {
                lbAddEditLDLAppTitle.Text = "New Local Driving License Application ";
                this.Text = "New Local Driving License Application ";
                _SetAddEditLocalDrivingLicenseApplication();
              
            }
            else
            {
                // Load  data from object to form .
                lbAddEditLDLAppTitle.Text = "Edit Local Driving License Application ";
                this.Text = "Edit Local Driving License Application ";
                LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindLocalDrivingLicenseByID(LDLAppID);
                if (LocalDrivingLicenseApplication != null)
                {
                    _TransferDataFromObjectToForm();
                }
                else
                    return;
            }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (userControlShowPersonCardWithFilter1.PersonID != -1)
            {
                tabApplicationInfo.Enabled = true;
                tab.SelectTab(1);
            }
            else
            {
                MessageBox.Show("Person was not found , you have to find Person First .", "Error .", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            switch (Mode)
            {
                case enMode.Add:
                    {
                        _TransferDatafromFormToObject();
                        if(!clsApplications.DoesPersonHaveActiveApplicationIDForLocalDrivingLicenseApplication(LocalDrivingLicenseApplication._ApplicantPersonID,
                           (byte)LocalDrivingLicenseApplication.LicenseClassID,LocalDrivingLicenseApplication.ApplicationTypeID))
                          // and also have to check if person has a license or not 
                        {
                            if (LocalDrivingLicenseApplication.Save())
                            {
                                MessageBox.Show("Application was Saved successfully .", "Confirmation .",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LbApplicationID.Text = LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
                            }
                            else
                            {
                                MessageBox.Show("Application was not saved .", "Error .",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        }
                        else
                            MessageBox.Show("Application was not saved , Person already have an active application .", "Error .",
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    }
                case enMode.Edit:
                    {
                        LocalDrivingLicenseApplication.LicenseClassID = cbLicenseClass.SelectedIndex+1;
                        if(LocalDrivingLicenseApplication.Save())
                        {
                            MessageBox.Show("Application was updated successfully .", "Confirmation .",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Application was not updated .", "Error .",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                            break;
                    }
            }
        }
    }
}

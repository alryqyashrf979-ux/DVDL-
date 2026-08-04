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
    public partial class FrmDriversList : Form
    {
        enum enFilterBy { None =0, DriverID =1, PersonID =2 , NationalNo =3 , FullName = 5};
        enFilterBy FilterBy = enFilterBy.None;
        public FrmDriversList()
        {
            InitializeComponent();
        }

        private int ChangeTxtIDToInt()
        {
            return Convert.ToInt32(txtFilterBy.Text);
        }

        private void FrmDriversList_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterBy.Enabled = false;
             dgvDrivers.DataSource = clsDrivers.GetAllDrivers();
            LbRecords.Text = dgvDrivers.Rows.Count.ToString();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cbFilterBy.SelectedIndex)
            {
                case 0:
                    {
                        FilterBy = enFilterBy.None;
                        txtFilterBy.Enabled =false;
                       
                        break;
                    }
                    case 1:
                    {
                        FilterBy = enFilterBy.DriverID;
                        txtFilterBy.Enabled = true;
                        txtFilterBy.Focus();
                   
                        break;
                    }
                    case 2:
                    {
                        FilterBy = enFilterBy.PersonID;
                        txtFilterBy.Enabled = true;
                        txtFilterBy.Focus();

                        break;
                    }
                    case 3:
                    {
                        FilterBy = enFilterBy.NationalNo;
                        txtFilterBy.Enabled = true;
                        txtFilterBy.Focus();
                        break;
                    }
                    case 4:
                    {
                        FilterBy = enFilterBy.FullName;
                        txtFilterBy.Enabled = true;
                        txtFilterBy.Focus();
                        break;
                    }
                default:
                    break;
            }
        }

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterBy.Text))
            {
                dgvDrivers.DataSource = clsDrivers.GetAllDrivers();
                return;
            }
            switch (FilterBy)
            {
                case enFilterBy.None:
                    {
                        dgvDrivers.DataSource = clsDrivers.GetAllDrivers();
                        LbRecords.Text = dgvDrivers.Rows.Count.ToString();
                        return;
                    }
                   
                case enFilterBy.DriverID:
                    {
                        dgvDrivers.DataSource = clsDrivers.FilterByDriverID(ChangeTxtIDToInt());
                        LbRecords.Text = dgvDrivers.Rows.Count.ToString();
                        break;
                    }
                case enFilterBy.PersonID:
                    {
                        dgvDrivers.DataSource = clsDrivers.FilterByPersonID(ChangeTxtIDToInt());
                        LbRecords.Text = dgvDrivers.Rows.Count.ToString();
                        break;
                    }
                case enFilterBy.NationalNo:
                    {
                        dgvDrivers.DataSource = clsDrivers.FilterByNationalNo(txtFilterBy.Text.Trim());
                        LbRecords.Text = dgvDrivers.Rows.Count.ToString();
                        break;
                    }
                case enFilterBy.FullName:
                    {
                        dgvDrivers.DataSource = clsDrivers.FilterByFullName(txtFilterBy.Text.Trim());
                        LbRecords.Text = dgvDrivers.Rows.Count.ToString();
                        break;
                    }
            }
        }
        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (FilterBy == enFilterBy.PersonID || FilterBy == enFilterBy.DriverID)
            {
                e.Handled= (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
            }
        }
        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = Convert.ToInt32(dgvDrivers.CurrentRow.Cells[1].Value);
            FrmShowPersonDetails ShowPersonDetails = new FrmShowPersonDetails(PersonID);
            ShowPersonDetails.ShowDialog();
        }
        private void showDriverLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = Convert.ToInt32(dgvDrivers.CurrentRow.Cells[1].Value);
            frmShowPersonLicenseHistory PersonLicensesHistoryForm = new frmShowPersonLicenseHistory(PersonID);
            PersonLicensesHistoryForm.ShowDialog();
        }
    }
}

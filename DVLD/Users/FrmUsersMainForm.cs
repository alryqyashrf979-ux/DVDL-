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
    public partial class FrmUsersMainForm : Form
    {
        enum enFilterUsersBy { None = 0, Username = 1, Full_Name = 2, PersonID = 3, IsActive = 4 };
        enFilterUsersBy FilterMode = enFilterUsersBy.None;
        public FrmUsersMainForm()
        {
            InitializeComponent();
        }
        private void _FillUsersDgvProperly()
        {
            dgvUsers.DataSource = clsUser.GetAllUsers();
            foreach (DataGridViewRow Row in dgvUsers.Rows)
            {
                if (!(bool)Row.Cells["IsActive"].Value)
                {
                    Row.DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }

        private void FrmUsersMainForm_Load(object sender, EventArgs e)
        {
            _FillUsersDgvProperly();
            lbUserRecords.Text = dgvUsers.Rows.Count.ToString();
            cbFilterUsersBy.SelectedIndex = 0;
        }

        private void updateUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = Convert.ToInt32(dgvUsers.CurrentRow.Cells[0].Value);
            frmAddEditUser frmEditPerson = new frmAddEditUser(UserID);
            frmEditPerson.ShowDialog();
            Refresh();
        }

        private void showUsersInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Username = dgvUsers.CurrentRow.Cells[1].Value.ToString();
            clsUser User = clsUser.Find(Username);

            if (User != null)
            {
                frmCurrentUser frmUser = new frmCurrentUser(User);
                frmUser.ShowDialog();
                Refresh();
            }
            else
            {
                MessageBox.Show("User is not found .", "Error .", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Username = dgvUsers.CurrentRow.Cells[1].Value.ToString();
            clsUser User = clsUser.Find(Username);

            if (User != null)
            {
                frmChangePassword frmUser = new frmChangePassword(User);
                frmUser.ShowDialog();
                Refresh();
            }
            else
            {
                MessageBox.Show("User is not found .", "Error .", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To be implemented later on .");
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To be implemented later on .");
        }

        private void cbFilterUsersBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbFilterUsersBy.SelectedIndex)
            {
                case 0:
                    {
                        txtFilterBox.Text = "";
                        FilterMode = enFilterUsersBy.None;
                        cbActivationFilter.Visible = false;
                        txtFilterBox.Visible = false;
                        _FillUsersDgvProperly();
                        lbUserRecords.Text = dgvUsers.Rows.Count.ToString();
                        break;
                    }

                case 1:
                    {
                        txtFilterBox.Text = "";
                        FilterMode = enFilterUsersBy.Username;
                        cbActivationFilter.Visible = false;
                        txtFilterBox.Visible = true;
                        txtFilterBox.Focus();
                        Refresh();

                        break;
                    }
                case 2:
                    {
                        txtFilterBox.Text = "";
                        FilterMode = enFilterUsersBy.Full_Name;
                        cbActivationFilter.Visible = false;
                        txtFilterBox.Visible = true;
                        txtFilterBox.Focus();
                        Refresh();
                        break;
                    }
                case 3:
                    {
                        txtFilterBox.Text = "";
                        FilterMode = enFilterUsersBy.PersonID;
                        cbActivationFilter.Visible = false;
                        txtFilterBox.Visible = true;
                        txtFilterBox.Focus();
                        Refresh();
                        break;
                    }
                case 4:
                    {
                        txtFilterBox.Text = "";
                        FilterMode = enFilterUsersBy.IsActive;
                        cbActivationFilter.Visible = true;
                        txtFilterBox.Visible = false;
                        cbActivationFilter.SelectedIndex = 0;
                        cbActivationFilter.Focus();
                        Refresh();
                        break;
                    }
            }
        }

        private void txtFilterBox_TextChanged(object sender, EventArgs e)
        {
            switch (FilterMode)
            {
                case enFilterUsersBy.Full_Name:
                    {
                        dgvUsers.DataSource = clsUser.FilterUsersByFullName(txtFilterBox.Text.Trim());
                        lbUserRecords.Text = dgvUsers.Rows.Count.ToString();
                        break;
                    }
                case enFilterUsersBy.Username:
                    {
                        dgvUsers.DataSource = clsUser.FilterUsersByUsername(txtFilterBox.Text.Trim());
                        lbUserRecords.Text = dgvUsers.Rows.Count.ToString();
                        break;
                    }
                case enFilterUsersBy.PersonID:
                    {
                        if (!string.IsNullOrEmpty(txtFilterBox.Text))
                        {
                            dgvUsers.DataSource = clsUser.FilterUsersByPersonID(Convert.ToInt32(txtFilterBox.Text.Trim()));
                            lbUserRecords.Text = dgvUsers.Rows.Count.ToString();
                        }
                        else
                        {
                            dgvUsers.DataSource = clsUser.GetAllUsers();
                            lbUserRecords.Text = dgvUsers.Rows.Count.ToString();
                        }
                        break;
                    }
            }
        }
        private void Refresh()

        {
            dgvUsers.DataSource = clsUser.GetAllUsers();
            lbUserRecords.Text = dgvUsers.Rows.Count.ToString();
        }
        private void cbActivationFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbActivationFilter.SelectedIndex)
            {
                case 0:
                    {
                        dgvUsers.DataSource = clsUser.GetAllUsers();
                        lbUserRecords.Text = dgvUsers.Rows.Count.ToString();
                        break;
                    }
                case 1:
                    {

                        dgvUsers.DataSource = clsUser.FilterUsersByIsActive(true);
                        lbUserRecords.Text = dgvUsers.Rows.Count.ToString();
                        break;
                    }
                case 2:
                    {
                        dgvUsers.DataSource = clsUser.FilterUsersByIsActive(false);
                        lbUserRecords.Text = dgvUsers.Rows.Count.ToString();
                        break;
                    }
            }
        }

        private void txtFilterBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(FilterMode == enFilterUsersBy.PersonID )
            e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = Convert.ToInt32( dgvUsers.CurrentRow.Cells[0].Value);
            if (MessageBox.Show("Are you sure you want to delete this user ??", "Confirm.", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
                == DialogResult.OK)
            {
                if (clsUser.Delete(UserID))
                {
                    MessageBox.Show("User was deleted successfully .", "Confirm.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Refresh();
                }
                else
                    MessageBox.Show("User was not deleted because it is connected to other records ."
                        , "Confirm.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditUser frmAddEditUser = new frmAddEditUser();
            frmAddEditUser.ShowDialog();
            Refresh();
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmAddEditUser frmAddEditUser = new frmAddEditUser();
            frmAddEditUser.ShowDialog();
            Refresh();
        }
    }
}

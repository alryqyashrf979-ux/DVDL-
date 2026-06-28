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
    public partial class UserControlUserInfoCard : UserControl
    {
        public UserControlUserInfoCard()
        {
            InitializeComponent();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }
        private void UserControlUserInfoCard_Load(object sender, EventArgs e)
        {
        }
        public void LoadDataFromObjectToForm(clsUser User)
        {
            if (User == null)
            {
                userControlShowPersonDetails1._SetAllControls();
                lbIsActive.Text = "No";
                lbuserID.Text = "???";
                lbusername.Text = "???";
                MessageBox.Show("There is no user to show .", "Error .", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FillUserCardWithInfo(User);

        }
        public void FillUserCardWithInfo(clsUser CurrentUser)
        {
            userControlShowPersonDetails1.LoadDataToPersonInfoCard(CurrentUser.PersonID);
            lbIsActive.Text = CurrentUser.IsActive ? "Yes" : "No";
                lbuserID.Text = CurrentUser.UserID.ToString();
            lbusername.Text = CurrentUser.Username.ToString();
        }

        private void userControlShowPersonDetails1_Load(object sender, EventArgs e)
        {

        }
    }
    }

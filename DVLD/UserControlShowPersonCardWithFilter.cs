using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class UserControlShowPersonCardWithFilter : UserControl
    {
        enum enFilterBy { NationalNo = 1, PersonID = 2 };
        enFilterBy FilteredBy = enFilterBy.NationalNo;

        public UserControlShowPersonCardWithFilter()
        {
            InitializeComponent();
        }

        private void userControlShowPersonDetails1_Load(object sender, EventArgs e)
        {

        }

        private void cbFilterPersonby_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbFilterPersonby.SelectedIndex)
            {
                case 0:
                    {
                        FilteredBy = enFilterBy.NationalNo;
                        break;
                    }
                case 1:
                    {
                        FilteredBy = enFilterBy.PersonID;
                        break;
                    }
                default:
                    break;
            }
        }

        private void btnFInd_Click(object sender, EventArgs e)
        {
            switch (FilteredBy)
            {
                case enFilterBy.NationalNo:
                    {
                        userControlShowPersonDetails1.LoadDataToPersonInfoCard(txtfilterby.Text.ToString().Trim());
                        break;
                    }
                case enFilterBy.PersonID:
                    {

                        if (int.TryParse(txtfilterby.Text.ToString().Trim(), out int Result))
                        {

                            userControlShowPersonDetails1.LoadDataToPersonInfoCard(Result);
                            break;
                        }
                        else
                        {
                            MessageBox.Show("There is invalid input .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                default: break;


            }
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson();
            frm.DataBack += GetNewPersonInfo;
            frm.ShowDialog();
        }
        private void GetNewPersonInfo(object sender, int PersonID)
        {

            clsPeople Person = clsPeople.FindPerson(PersonID);
            if (Person != null)
            {
                userControlShowPersonDetails1.LoadDataToPersonInfoCard(PersonID);
                txtfilterby.Text = PersonID.ToString();
                cbFilterPersonby.SelectedIndex = 1;
            }

        }
    }
}
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
        public event Action<int> OnPersonFound;
        protected virtual void PersonFound(int personID)
        {
            Action<int> Handler = OnPersonFound;
            if(Handler != null)
            {
                Handler(personID);
            }
        }
        
        private bool _FilterEnabled = true;
        public bool FilterEnabled
        { get { return _FilterEnabled; }

            set { _FilterEnabled = value;
                gbFilter.Visible = _FilterEnabled;
            }
        }

        private int _PersonID;
        public int PersonID { get { return userControlShowPersonDetails1.PersonId; } }
        private bool _ShowPersonCard = true;
        public bool ShowPersonCard
        {

            get { return _ShowPersonCard; }
            set
            {
                _ShowPersonCard = value;
                userControlShowPersonDetails1.Visible = _ShowPersonCard;
            }
        }
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
                        txtfilterby.Text = "";
                        txtfilterby.Focus();
                        break;
                    }
                case 1:
                    {
                        FilteredBy = enFilterBy.PersonID;
                        txtfilterby.Text = "";
                        txtfilterby.Focus();
                        break;
                    }
                default:
                    break;
            }
        }

        private void FindNow()
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

            if (OnPersonFound != null && _FilterEnabled)
                PersonFound(userControlShowPersonDetails1.PersonId);
        }
        private void btnFInd_Click(object sender, EventArgs e)
        {
            if(!ValidateChildren())
            {
                MessageBox.Show("There is sth wrong .","Error .",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
FindNow();

         
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

        private void txtfilterby_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtfilterby.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtfilterby, "This box should not be empty.");
            }
            else
            {
                errorProvider1.SetError(txtfilterby, null);
            }
        }

        private void txtfilterby_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13 )
                btnFInd.PerformClick();

            if(FilteredBy == enFilterBy.PersonID)
            {
                //if the user does not insert a digit or a control like delete then the event will not accept the input .
                e.Handled = !char.IsDigit(e.KeyChar)&&!char.IsControl(e.KeyChar);
            }

        }

        private void UserControlShowPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterPersonby.SelectedIndex = 0;
        }
    }
}
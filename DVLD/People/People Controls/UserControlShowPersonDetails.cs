using DVLD.Properties;
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
using System.IO;

namespace DVLD
{
    public partial class UserControlShowPersonDetails : UserControl
    {
        private clsPeople _Person;
        public clsPeople Person
        {  get { return _Person; } }

        private int _PersonId;
        public int PersonId
        { get { return _PersonId; } }

        public UserControlShowPersonDetails()
        {
            InitializeComponent();
        }
        public void LoadDataToPersonInfoCard(int PersonID)
        {
            _Person = clsPeople.FindPerson(PersonID);
            if (_Person == null)
            {
                _SetAllControls();
                MessageBox.Show("This Person is not found .", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ;
            }
            _FillDataToPersonCard();
        }
        public void LoadDataToPersonInfoCard(string NationalNo)
        {
                _Person = clsPeople.FindPerson(NationalNo);
            if (_Person == null)
            {
                _SetAllControls();
                MessageBox.Show("This Person is not found .", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillDataToPersonCard();
        }
        private void _SetAllControls()
        {
            LbPersonID.Text = "[????]";
            LbAddress.Text = "[????]";
            LbBirthDate.Text = "[????]";
            LbCountry.Text = "[????]";
            LbEmail.Text = "[????]";
            LbGendre.Text = "[????]";
            LbName.Text = "[????]";
            LbNationalNo.Text = "[????]";
            LbPhone.Text = "[????]";
            PicBPerson.Image = Resources.Male_512;
            LLBEditPerson.Visible = false;
        }

        private void _FillDataToPersonCard()
        {
            LbPersonID.Text = _Person.PersonID.ToString();
            LbAddress.Text =    _Person.Address.ToString();
            LbBirthDate.Text = _Person.DateOfBirth.ToString("dd/MM/yyyy");
            LbCountry.Text = clsPeople.GetCountryNameByID(_Person.NationalCountryID);
            LbEmail.Text = _Person.Email.ToString();
            LbGendre.Text = _Person.Gendre.ToString();
            LbName.Text = _Person.Full_Name.ToString();
            LbNationalNo.Text = _Person.NationalNo.ToString();
            LbPhone.Text = _Person.Phone.ToString();
            _LoadPersonImage();
        }
        private void _LoadPersonImage()
        {
            if (_Person.Gendre == 'M')
                PicBPerson.Image = Resources.Male_512;
            else
                PicBPerson.Image = Resources.Female_512;

            string ImagePath = _Person.ImagePath;
            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    PicBPerson.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void UserControlShowPersonDetails_Load(object sender, EventArgs e)
        {
        }
        private void GBPersonDetails_Enter(object sender, EventArgs e)
        {
        }

        private void LLBEditPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson(_Person.PersonID);
            frm.ShowDialog();
            LoadDataToPersonInfoCard(_Person.PersonID);
        }
    }
}

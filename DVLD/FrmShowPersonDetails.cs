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
    public partial class FrmShowPersonDetails : Form
    {
        clsPeople Person = new clsPeople();
        public FrmShowPersonDetails(int PersonID)
        {
            Person = clsPeople.FindPerson(PersonID);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this .Close();
        }

        private void FrmShowPersonDetails_Load(object sender, EventArgs e)
        {
            userControlShowPersonDetails1.LbPersonID.Text = Person.PersonID.ToString();
            userControlShowPersonDetails1.LbAddress.Text = Person.Address.ToString();
            userControlShowPersonDetails1.LbBirthDate.Text = Person.DateOfBirth.ToString("dd/MM/yyyy");
            userControlShowPersonDetails1.LbCountry.Text = clsPeople.GetCountryNameByID( Person.NationalCountryID);
            userControlShowPersonDetails1.LbEmail.Text = Person.Email.ToString();
            userControlShowPersonDetails1.LbGendre.Text = Person.Gendre.ToString();
            userControlShowPersonDetails1.LbName.Text = Person.Full_Name.ToString();
            userControlShowPersonDetails1.LbNationalNo.Text = Person.NationalNo.ToString();
            userControlShowPersonDetails1.LbPhone.Text = Person.Phone.ToString();
            if(!string.IsNullOrEmpty( Person.ImagePath))
            userControlShowPersonDetails1.pictureBox9.Load(Person.ImagePath.ToString().Trim());
        }
    }
}

using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DVLD
{
    public partial class frmAddEditPerson : Form
    {
        enum enMode { Add =0, Edit = 1 };
        enMode Mode = enMode.Add;
        clsPeople Person = null;
        string sourceFilePath = string.Empty;
        public frmAddEditPerson(int PersonID =-1)
        {
            InitializeComponent();
            if (PersonID == -1)
            {

                Mode = enMode.Add;
               Person = new clsPeople();
            }
            else
            {
                Mode = enMode.Edit;
                Person = clsPeople.FindPerson(PersonID);
            }          
        }
        public void LoadDataFromScreenToObject()
        {
            Person.FirstName = txtFirstName.Text.Trim();
            Person.SecondName = txtSecondName.Text.Trim();
            Person.ThirdName = txtThirdName.Text.Trim();
            Person.LastName = txtLastName.Text.Trim();
            Person.NationalNo = txtNationalNo.Text.Trim();
            Person.Phone = txtPhoneNumber.Text.Trim();
            if (!string.IsNullOrEmpty(sourceFilePath))
                Person.ImagePath = sourceFilePath.Trim();
            else
                Person.ImagePath = string.Empty;

                Person.DateOfBirth = DTPDateOfBirth.Value;
            Person.NationalCountryID = cbCountries.SelectedIndex;
            Person.Email = txtEmail.Text.Trim();
            Person.Address = txtAddress.Text.Trim();
            if (rbFemale.Checked)
                Person.Gendre = 'F';
            else
                Person.Gendre = 'M';
        }
        public void LoadDataFromObjectToScreen()
        {
            lbPersonID.Text = Person.PersonID.ToString().Trim();
            txtFirstName.Text = Person.FirstName.Trim();
            txtSecondName.Text = Person.SecondName.Trim();
            txtThirdName.Text = Person.ThirdName.Trim();
            txtLastName.Text = Person.LastName.Trim();
            txtNationalNo.Text = Person.NationalNo.Trim();
            txtEmail.Text = Person.Email.Trim();
            txtPhoneNumber.Text = Person.Phone.Trim();
            txtAddress.Text = Person.Address.Trim();
            if(Person.Gendre=='F'||Person.Gendre=='f')
            rbFemale.Checked = true;
            else
                rbMale.Checked = true;
            DTPDateOfBirth.Value = Person.DateOfBirth; 

            if(!string.IsNullOrEmpty( Person.ImagePath))
               picBPerson.Image= Image.FromFile(Person.ImagePath);

            cbCountries.SelectedIndex = Person.NationalCountryID;


        }
        public void SetScreen()
        {
            switch (Mode)
            {
                case enMode.Add:
                    {

                        lbAddEditPerson.Text = "Add Person .";
                        cbCountries.SelectedIndex = 190;
                        break;
                    }
                case enMode.Edit:
                    {
                        lbAddEditPerson.Text = "Edit Person .";
                        LoadDataFromObjectToScreen();
                        break;
                    }
            }
        }

        public void Save()
        {
            switch (Mode)
            {
                case enMode.Add:
                    {
                        LoadDataFromScreenToObject();
                        if (Person.Save())
                        {
                            MessageBox.Show("Person was added successfully .", "Confirmation.", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            clsUtil.CopyImageFromPlaceToAnotherAndGiveItAGuid(sourceFilePath, @"C:\Users\ALSAKHRA PC\Desktop\PeopleImages");
                            Mode = enMode.Edit;
                        }
                        else
                        {
                            MessageBox.Show("Person was not added successfully .", "Confirmation.", MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                        }
                        break;
                    }
                case enMode.Edit:
                    {
                        LoadDataFromScreenToObject();
                        if (Person.Save())
                        {
                            MessageBox.Show("Person was Updated successfully .", "Confirmation.", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            Mode = enMode.Edit;
                            clsUtil.CopyImageFromPlaceToAnotherAndGiveItAGuid(sourceFilePath, @"C:\Users\ALSAKHRA PC\Desktop\PeopleImages");
                        }
                        else
                        {
                            MessageBox.Show("Person was not updated successfully .", "Confirmation.", MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                        }
                        break;
                    }
            }
        }

        private void frmAddEditPerson_Load(object sender, EventArgs e)
        {
            PeopleMainForm.FillComboBoxWithCountries(cbCountries);
            SetScreen();
        }

        private void txt_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty( ((TextBox)sender).Text))
            {
                e.Cancel = true;
                ((TextBox)sender).Focus();
                errorProvider1.SetError(((TextBox)sender), "this must not be empty .");
            }
            else
            {
                e.Cancel= false;
                errorProvider1.SetError(((TextBox)sender), "");
            }
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            txt_Validating(sender, e);
            if (clsPeople.DoesNationalNoExist(txtNationalNo.Text.Trim())) 
            {
                e.Cancel = true;
                ((TextBox)sender).Focus();
                errorProvider1.SetError(((TextBox)sender), "this National No cannot be used .");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(((TextBox)sender), "");
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
          txt_Validating((TextBox)sender, e);
            if (clsUtil.IsValidEmail(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                ((TextBox)sender).Focus();
                errorProvider1.SetError(((TextBox)sender), "this Email is invalid .");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(((TextBox)sender), "");
            }

        }

        private void DTPDateOfBirth_Validating(object sender, CancelEventArgs e)
        {
            if (!clsUtil.IsPersonAgeGreaterThanSpecificAge(DTPDateOfBirth.Value,18))
            {
                e.Cancel = true;
               DTPDateOfBirth.Focus();
                errorProvider1.SetError(DTPDateOfBirth, "this Birthdate is less than 18 .");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(DTPDateOfBirth, "");
            }
        }

         private void lLbSetPhote_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
         {
            
               // Filter to ensure the user only selects image files
               openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
               openFileDialog1.Title = "Select a Person's Photo";
              
               // Show the dialog and check if the user clicked "OK"
               if (openFileDialog1.ShowDialog() == DialogResult.OK)
               {
                   // Get the full path of the selected file
                   sourceFilePath = openFileDialog1.FileName;
                    picBPerson.Image = Image.FromFile(sourceFilePath);
             
               }
         }
        private void button1_Click(object sender, EventArgs e)
        {
            Save();
            SetScreen();

        }
    }

    }



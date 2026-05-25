using DVLD.Properties;
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
        public delegate void DataBackEventHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        public enum enMode { AddNew = 0, Update = 1 };
        public enum enGendor { Male = 0, Female = 1 };

        private enMode _Mode;
        private int _PersonID = -1;
        clsPeople _Person;

        public frmAddEditPerson()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;

        }

        public frmAddEditPerson(int PersonID)
        {
            InitializeComponent();

            _Mode = enMode.Update;
            _PersonID = PersonID;
        }

        private void _ResetDefualtValues()
        {
            //this will initialize the reset the defaule values
            _FillCountriesInComoboBox();

            if (_Mode == enMode.AddNew)
            {
                lbAddEditPerson.Text = "Add New Person";
                _Person = new clsPeople();
            }
            else
            {
                lbAddEditPerson.Text = "Update Person";
            }

            //set default image for the person.
            if (rbMale.Checked)
                picBPerson.Image = Resources.Male_512;
            else
                picBPerson.Image = Resources.Female_512;

            //hide/show the remove linke incase there is no image for the person.
            llRemoveImage.Visible = (picBPerson.ImageLocation != null);

            //we set the max date to 18 years from today, and set the default value the same.
            DTPDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            DTPDateOfBirth.Value = DTPDateOfBirth.MaxDate;

            //should not allow adding age more than 100 years
            DTPDateOfBirth.MinDate = DateTime.Now.AddYears(-100);

            //this will set default country to Yemen.
            cbCountries.SelectedIndex = 189;

            txtFirstName.Text = "";
            txtSecondName.Text = "";
            txtThirdName.Text = "";
            txtLastName.Text = "";
            txtNationalNo.Text = "";
            rbMale.Checked = true;
            txtPhoneNumber.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";


        }

        private void _FillCountriesInComoboBox()
        {
            DataTable dtCountries = clsPeople.GetAllCountries();

            foreach (DataRow row in dtCountries.Rows)
            {
                cbCountries.Items.Add(row[0].ToString());
            }
        }

        private void _LoadData()
        {

            _Person = clsPeople.FindPerson(_PersonID);

            if (_Person == null)
            {
                MessageBox.Show("No Person with ID = " + _PersonID, "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            //the following code will not be executed if the person was not found
            lbPersonID.Text = _PersonID.ToString();
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            txtNationalNo.Text = _Person.NationalNo;
            DTPDateOfBirth.Value = _Person.DateOfBirth;

            if (_Person.Gendre == 0)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            txtAddress.Text = _Person.Address;
            txtPhoneNumber.Text = _Person.Phone;
            txtEmail.Text = _Person.Email;
            cbCountries.SelectedIndex = _Person.NationalCountryID + 1;


            //load person image incase it was set.
            if (_Person.ImagePath != "")
            {
                {
                    picBPerson.ImageLocation = _Person.ImagePath;

                }

                //hide/show the remove linke incase there is no image for the person.
                llRemoveImage.Visible = (_Person.ImagePath != "");

            }
        }

            public void frmAddEditPerson_Load(object sender, EventArgs e)
            {
                _ResetDefualtValues();

                if (_Mode == enMode.Update)
                    _LoadData();
            }

            private bool _HandlePersonImage()
            {

                //this procedure will handle the person image,
                //it will take care of deleting the old image from the folder
                //in case the image changed. and it will rename the new image with guid and 
                // place it in the images folder.


                //_Person.ImagePath contains the old Image, we check if it changed then we copy the new image
                if (_Person.ImagePath != picBPerson.ImageLocation)
                {
                    if (_Person.ImagePath != "")
                    {
                        //first we delete the old image from the folder in case there is any.

                        try
                        {
                            File.Delete(_Person.ImagePath);
                        }
                        catch (IOException)
                        {
                            // We could not delete the file.
                            //log it later   
                        }
                    }

                    if (picBPerson.ImageLocation != null)
                    {
                        //then we copy the new image to the image folder after we rename it
                        string SourceImageFile = picBPerson.ImageLocation.ToString();

                        if (clsUtil.CopyImageFromPlaceToAnotherAndGiveItAGuid(ref SourceImageFile, "C:\\Users\\ALSAKHRA PC\\Desktop\\DVLDImages"))
                        {
                            picBPerson.ImageLocation = SourceImageFile;
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                }
                return true;
            }


      

            private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
            {

                // First: set AutoValidate property of your Form to EnableAllowFocusChange in designer 
                TextBox Temp = ((TextBox)sender);
                if (string.IsNullOrEmpty(Temp.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(Temp, "This field is required!");
                }
                else
                {
                    //e.Cancel = false;
                    errorProvider1.SetError(Temp, null);
                }

            }

            private void txtEmail_Validating(object sender, CancelEventArgs e)
            {
                //no need to validate the email incase it's empty.
                if (txtEmail.Text.Trim() == "")
                    return;

                //validate email format
                if (!clsUtil.IsValidEmail(txtEmail.Text))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtEmail, "Invalid Email Address Format!");
                }
                else
                {
                    errorProvider1.SetError(txtEmail, null);
                };

            }

            private void txtNationalNo_Validating(object sender, CancelEventArgs e)
            {

                if (string.IsNullOrEmpty(txtNationalNo.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtNationalNo, "This field is required!");
                    return;
                }
                else
                {
                    errorProvider1.SetError(txtNationalNo, null);
                }

                //Make sure the national number is not used by another person
                if (txtNationalNo.Text.Trim() != _Person.NationalNo && clsPeople.DoesNationalNoExist(txtNationalNo.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtNationalNo, "National Number is used for another person!");

                }
                else
                {
                    errorProvider1.SetError(txtNationalNo, null);
                }
            }

      

        private void lLbSetPhote_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                picBPerson.Load(selectedFilePath);
                llRemoveImage.Visible = true;
                // ...
            }
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            //change the defualt image to male incase there is no image set.
            if (picBPerson.ImageLocation == null)
                picBPerson.Image = Resources.Male_512;
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            //change the defualt image to female incase there is no image set.
            if (picBPerson.ImageLocation == null)
                picBPerson.Image = Resources.Female_512;
        }

        private void llRemoveImage_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

            picBPerson.ImageLocation = null;



            if (rbMale.Checked)
                picBPerson.Image = Resources.Male_512;
            else
                picBPerson.Image = Resources.Female_512;

            llRemoveImage.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (!_HandlePersonImage())
                return;

            int NationalityCountryID = cbCountries.SelectedIndex + 1;

            _Person.FirstName = txtFirstName.Text.Trim();
            _Person.SecondName = txtSecondName.Text.Trim();
            _Person.ThirdName = txtThirdName.Text.Trim();
            _Person.LastName = txtLastName.Text.Trim();
            _Person.NationalNo = txtNationalNo.Text.Trim();
            _Person.Email = txtEmail.Text.Trim();
            _Person.Phone = txtPhoneNumber.Text.Trim();
            _Person.Address = txtAddress.Text.Trim();
            _Person.DateOfBirth = DTPDateOfBirth.Value;

            if (rbMale.Checked)
                _Person.Gendre = 'M';
            else
                _Person.Gendre = 'F';

            _Person.NationalCountryID = NationalityCountryID;

            if (picBPerson.ImageLocation != null)
                _Person.ImagePath = picBPerson.ImageLocation;
            else
                _Person.ImagePath = "";

            if (_Person.Save())
            {
                lbPersonID.Text = _Person.PersonID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;
                lbAddEditPerson.Text = "Update Person";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);


                // Trigger the event to send data back to the caller form.
                DataBack?.Invoke(this, _Person.PersonID);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }
    }
    }





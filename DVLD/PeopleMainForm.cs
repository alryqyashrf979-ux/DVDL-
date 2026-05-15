using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;
namespace DVLD
{
    public partial class PeopleMainForm : Form
    {
         public void FillComboBoxWithCountries()
        {
            DataTable dt = new DataTable();
            dt = clsPeople.GetAllCountries();
            foreach(DataRow row in dt.Rows)
            {
                cbNationalities.Items.Add(row[0].ToString());
            }

        }
        public PeopleMainForm()
        {
            InitializeComponent();

        }
        enum enFilterPeople
        {
            None = 0, PersonID = 1, NationalNo = 2, FirstName = 3, SecondName = 4, ThirdName = 5, LastName = 6, Nationality = 7
        , Gendre = 8, Phone = 9, Email = 10
        };
        enFilterPeople FilterPeople = enFilterPeople.None;
        private void PeopleMainForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = clsPeople.GetAllPpl();
            FillComboBoxWithCountries();
            cbPeopleFilter.SelectedIndex = 0;
            txtFilterPeople.Visible = false;
            cbNationalities.Visible=false;
           lbRecordsCount.Text= dataGridView1.Rows.Count.ToString();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void cbPeopleFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            switch (cbPeopleFilter.SelectedIndex)
            {
               
                case 0:
                    {
                        txtFilterPeople.Visible = false;
                        dataGridView1.DataSource = clsPeople.GetAllPpl();
                        break;
                    }
                case 1:
                    {
                        txtFilterPeople.Visible = true;
                        FilterPeople = enFilterPeople.PersonID;
                        break;
                    }
                case 2:
                    {
                        txtFilterPeople.Visible = true;
                        FilterPeople = enFilterPeople.NationalNo;
                        break;
                    }
                case 3:
                    {
                        txtFilterPeople.Visible = true;
                        FilterPeople = enFilterPeople.FirstName;
                        break;
                    }
                case 4:
                    {
                        txtFilterPeople.Visible = true;
                        FilterPeople = enFilterPeople.SecondName;
                        break;
                    }
                case 5:
                    {
                        txtFilterPeople.Visible = true;
                        FilterPeople = enFilterPeople.ThirdName;
                        break;
                    }
                case 6:
                    {
                        txtFilterPeople.Visible = true;
                        FilterPeople = enFilterPeople.LastName;
                        break;
                    }
                case 7:
                    {
                        txtFilterPeople.Visible = false;
                        cbNationalities.Visible = true;
                        cbNationalities.SelectedIndex = 190;
                        FilterPeople = enFilterPeople.Nationality;
                        break;
                    }
                case 8:
                    {
                        txtFilterPeople.Visible = true;
                        FilterPeople = enFilterPeople.Gendre;
                        break;
                    }
                case 9:
                    {
                        txtFilterPeople.Visible = true;
                        FilterPeople = enFilterPeople.Phone;
                        break;
                    }
                case 10:
                    {
                        txtFilterPeople.Visible = true;
                        FilterPeople = enFilterPeople.Email;
                        break;
                    }
            }
        }

        private void txtFilterPeople_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void txtFilterPeople_TextChanged_1(object sender, EventArgs e)
        {
            if( string.IsNullOrEmpty( txtFilterPeople.Text))
            {
                dataGridView1.DataSource = clsPeople.GetAllPpl();
                lbRecordsCount.Text = dataGridView1.Rows.Count.ToString();
                return;
            }
            int TextToINT;
            if (int.TryParse(txtFilterPeople.Text, out int Num))
            {
                TextToINT = Num;
            }
            switch (FilterPeople)
            {
                case enFilterPeople.PersonID:
                    {
                        dataGridView1.DataSource = clsPeople.FilterPeopleByPersonID(Num);
                        lbRecordsCount.Text = dataGridView1.Rows.Count.ToString();
                        break;
                    }
                case enFilterPeople.NationalNo:
                    {
                        dataGridView1.DataSource = clsPeople.FilterPeopleByNationalNo(txtFilterPeople.Text);
                        lbRecordsCount.Text = dataGridView1.Rows.Count.ToString();
                        break;
                    }
                case enFilterPeople.FirstName:
                    {
                        dataGridView1.DataSource = clsPeople.FilterPeopleByFirstName(txtFilterPeople.Text);
                        lbRecordsCount.Text = dataGridView1.Rows.Count.ToString();
                        break;
                    }
                case enFilterPeople.SecondName:
                    {
                        dataGridView1.DataSource = clsPeople.FilterPeopleBySecondName(txtFilterPeople.Text);
                        lbRecordsCount.Text = dataGridView1.Rows.Count.ToString();
                        break;
                    }
                case enFilterPeople.ThirdName:
                    {
                        dataGridView1.DataSource = clsPeople.FilterPeopleByThirdName(txtFilterPeople.Text);
                        lbRecordsCount.Text = dataGridView1.Rows.Count.ToString();
                        break;
                    }
                case enFilterPeople.LastName:
                    {
                        dataGridView1.DataSource = clsPeople.FilterPeopleByLastName(txtFilterPeople.Text);
                        lbRecordsCount.Text = dataGridView1.Rows.Count.ToString();
                        break;
                    }
               
                case enFilterPeople.Gendre:
                    {
                        dataGridView1.DataSource = clsPeople.FilterPeopleByGendre(txtFilterPeople.Text.ToString()[0]);
                        lbRecordsCount.Text = dataGridView1.Rows.Count.ToString();
                        break;
                    }
                case enFilterPeople.Phone:
                    {
                        dataGridView1.DataSource = clsPeople.FilterPeopleByPhone(txtFilterPeople.Text);
                        lbRecordsCount.Text = dataGridView1.Rows.Count.ToString();
                        break;
                    }
                case enFilterPeople.Email:
                    {
                        dataGridView1.DataSource = clsPeople.FilterPeopleByEmail(txtFilterPeople.Text);
                        lbRecordsCount.Text = dataGridView1.Rows.Count.ToString();
                        break;
                    }
            }
        }
        private void cbNationalities_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = clsPeople.FilterPeopleByNaitonality(cbNationalities.SelectedItem.ToString().Trim());
            lbRecordsCount.Text = dataGridView1.Rows.Count.ToString();
        }

        private void addPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void updatePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            FrmShowPersonDetails personDetailsForm = new FrmShowPersonDetails(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            personDetailsForm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

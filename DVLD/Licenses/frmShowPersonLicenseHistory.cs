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
    public partial class frmShowPersonLicenseHistory : Form
    {
        private int _PersonID = -1;
        private clsPeople _Person = new clsPeople();
        public frmShowPersonLicenseHistory()
        {
            InitializeComponent();
            _PersonID = -1;
        }
        public frmShowPersonLicenseHistory(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }

        private void frmShowPersonLicenseHistory_Load(object sender, EventArgs e)
        {
            if (_PersonID == -1)
            {
               userControlShowPersonCardWithFilter1.FilterEnabled = true;
                userControlShowPersonCardWithFilter1.cbFilterPersonby.Enabled = true;


            }
            else
            {
                _Person = clsPeople.FindPerson(_PersonID);
                if (_Person == null)
                {
                    MessageBox.Show("Driver was not found .", "Error .", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                userControlShowPersonCardWithFilter1.userControlShowPersonDetails1.LoadDataToPersonInfoCard(_PersonID);
                userControlShowPersonCardWithFilter1.FilterEnabled = false;
                userControlDriverLicenses1.LoadDataToControlUsingPeronsID(_PersonID);
            }
         
        
        }

        private void userControlDriverLicenses1_Load(object sender, EventArgs e)
        {

        }
    }
}

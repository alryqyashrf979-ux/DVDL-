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
     
        public FrmShowPersonDetails(int PersonID)
        {
            
            InitializeComponent();
            userControlShowPersonDetails1.LoadDataToPersonInfoCard(PersonID);
        }
        public FrmShowPersonDetails(string NationalNo)
        {
           
            InitializeComponent();
            userControlShowPersonDetails1.LoadDataToPersonInfoCard(NationalNo);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this .Close();
        }

        private void FrmShowPersonDetails_Load(object sender, EventArgs e)
        {
       
        }
    }
}

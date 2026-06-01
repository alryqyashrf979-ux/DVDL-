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
    public partial class FrmFindPerson : Form
    {
        public delegate void DataBackDelegate(object obj, int PersonID) ;
        public event DataBackDelegate DataBack;
        public FrmFindPerson()
        {
            InitializeComponent();
        }

        private void FrmFindPerson_Load(object sender, EventArgs e)
        {

        }

        private void FrmFindPerson_FormClosed(object sender, FormClosedEventArgs e)
        {
            DataBack?.Invoke(this, userControlShowPersonCardWithFilter1.PersonID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            //DataBack.Invoke(this, userControlShowPersonCardWithFilter1.PersonID);
        }
    }
}

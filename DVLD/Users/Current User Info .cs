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
    public partial class frmCurrentUser : Form
    {
        public frmCurrentUser(clsUser CurrentUser)
        {
            InitializeComponent();
            userControlUserInfoCard1.LoadDataFromObjectToForm(CurrentUser);
         
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Current_User_Info_Load(object sender, EventArgs e)
        {

        }

     

        private void userControlUserInfoCard1_Load(object sender, EventArgs e)
        {

        }
    }
}

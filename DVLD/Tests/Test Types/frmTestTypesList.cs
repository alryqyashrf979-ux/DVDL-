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
    public partial class frmTestTypesList : Form
    {
        public frmTestTypesList()
        {
            InitializeComponent();
        }
        private void Refresh()
        {
            dgvTestTypes.DataSource = clsTestTypes.GetAllTestTypes();
        }
        private void frmTestTypesList_Load(object sender, EventArgs e)
        {
            dgvTestTypes.DataSource= clsTestTypes.GetAllTestTypes();
            lbNumberOfRecords.Text = dgvTestTypes.Rows.Count.ToString();
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(dgvTestTypes.CurrentRow.Cells[0].Value);
            frmEditTestType EditTestType = new frmEditTestType(ID);
            EditTestType.ShowDialog();
            Refresh();

        }
    }
}

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
    public partial class frmAppTypescs : Form
    {
        public frmAppTypescs()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void Refresh()
        {
dgvAppsTypes.DataSource = clsApplicationTypes.GetAllAppsTypes();
        }
        private void frmAppTypescs_Load(object sender, EventArgs e)
        {
            dgvAppsTypes.DataSource = clsApplicationTypes.GetAllAppsTypes();
            lbRecords.Text = dgvAppsTypes.Rows.Count.ToString();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AppTypeID = Convert.ToInt16( dgvAppsTypes.CurrentRow.Cells[0].Value);
            FrmUpdateAppType updateAppType = new FrmUpdateAppType(AppTypeID);
            updateAppType.ShowDialog();
            Refresh();
        }
    }
}

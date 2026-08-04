using DVLD.Global_classes;
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
    public partial class frmEditTestType : Form
    {
        int TestTypeID = -1;
        clsTestTypes TestType = null;
        public frmEditTestType(int ID)
        {
            InitializeComponent();
            TestTypeID = ID;
        }
        private void frmEditTestType_Load(object sender, EventArgs e)
        {
            TestType = clsTestTypes.Find(TestTypeID);
            if (TestType != null)
            {
                lbTestTypeID.Text = TestType.TestTypeID.ToString();
                txtDescription.Text = TestType.TestTypeDescription.ToString();
                txtFees.Text = TestType.TestTypeFee.ToString();
                txtTitle.Text = TestType.TestTypeTitle.ToString();
            }
        }
        private void txt_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(((TextBox)sender).Text))
            {
                e.Cancel = true;
                errorProvider1.SetError((TextBox)sender, "This field must not be empty .");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError((TextBox)sender, null);
            }
        }

        private void FillObjectFromForm()
        {
            TestType.TestTypeTitle = txtTitle.Text.Trim();
            TestType.TestTypeDescription = txtDescription.Text.Trim();
            if (decimal.TryParse(txtFees.Text, out decimal value))
            {
                TestType.TestTypeFee = value;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            FillObjectFromForm();
            if(!this.ValidateChildren())
            {
                MessageBox.Show("some fields are not valid  .", "Error .", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (TestType.Update())
            {
                MessageBox.Show("TestType was updated successfully.", "Confirm.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("TestType was not updated .", "Error .", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            txt_Validating(sender, e);
            if (!clsVaidations1.IsNumber(((TextBox)sender).Text))
            {
                e.Cancel = true;
                errorProvider1.SetError((TextBox)sender, "This field must be a number  .");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError((TextBox)sender, null);
            }
        }
    }
}

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
    public partial class FrmUpdateAppType : Form
    {
         clsApplicationTypes AppType = new clsApplicationTypes();
        int AppID = 0;
        
        public FrmUpdateAppType(int AppTypeID)
        {
            InitializeComponent();
            AppID = AppTypeID;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lbApplicationType_Click(object sender, EventArgs e)
        {

        }

   
        private void FillAllControlsValues()
        {
            txtFees.Text = AppType.ApplicationTypeFee.ToString();
            txtTitle.Text = AppType.ApplicationTypeTitle.ToString();    
            lbID.Text = AppType.AppTypeID.ToString();
        }
        private void SaveAllDataToObject()
        {
            if(decimal.TryParse(txtFees.Text.ToString(),out decimal Result))
                AppType.ApplicationTypeFee= Result;
            
                AppType.ApplicationTypeTitle= txtTitle.Text.ToString();
        }
        private void FrmAppTypes_Load(object sender, EventArgs e)
        {
            AppType = clsApplicationTypes.GetTypeOfApplication(AppID);
            if (AppType == null)
            {
                MessageBox.Show("Type of app is not found .", "Error .", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
                FillAllControlsValues();

        }

        private void txt_validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(((TextBox)sender).Text ))
                {
                e.Cancel = true;
                errorProvider1.SetError((TextBox)sender, "this filed must not be empty .");
            }
            else
            {
                e.Cancel= false;
                errorProvider1.SetError((TextBox)sender, null);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid .","Error .",MessageBoxButtons.OK , MessageBoxIcon.Error);
                return;
            }
            else
            {
                SaveAllDataToObject();
                if(AppType.Save())
                {
                    MessageBox.Show(" App Type is saved successfully .","Confirm .", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("App type is not saved .","Error .",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

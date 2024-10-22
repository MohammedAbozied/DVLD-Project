using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Classes;
using DVLD_Business;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD.Tests.TestTypes
{
    public partial class frmUpdateTestType : Form
    {
        private clsTestType.enTestType _ID;
        private clsTestType _clsTestType;
        public frmUpdateTestType(clsTestType.enTestType id)
        {
            InitializeComponent();
            _ID = id;
        }

        private void frmUpdateTestType_Load(object sender, EventArgs e)
        {
            _clsTestType = clsTestType.Find(_ID);

            if(_clsTestType == null)
            {
                MessageBox.Show($"no Test Type with ID: {(int)_ID}", "not exist", MessageBoxButtons.OK);
                this.Close();
                return;
            }

            lblTestTypeID.Text = ((int)_clsTestType.ID).ToString();
            txtTestTypeTitle.Text = _clsTestType.Title;
            txtTestTypeTitle.Focus();
            txtTypeFees.Text = _clsTestType.Fees.ToString();
            txtTestTypeDescription.Text = _clsTestType.Description;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("are you sure ?","Update Test Type",
                MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if(!this.ValidateChildren())
                {
                    MessageBox.Show("Some fields are not valid.", "Fields error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _clsTestType.Title = txtTestTypeTitle.Text.Trim();
                _clsTestType.Description = txtTestTypeDescription.Text.Trim();
                _clsTestType.Fees = Convert.ToSingle(txtTypeFees.Text.Trim());

                if(_clsTestType.Save())
                {
                    MessageBox.Show("Data Saved Successfully", "saving successfully",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("an error occurred", "saving error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            

        }


        // ===== validation -----
        private void txtTypeFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsWhiteSpace(e.KeyChar) || char.IsLetter(e.KeyChar);
        }

        private void txtTestTypeTitle_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtTestTypeTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTestTypeTitle,"this field should not be empty");
            }
            else
                errorProvider1.SetError(txtTestTypeTitle,null);
            
        }

        private void txtTypeFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTypeFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTypeFees, "this field should not be empty");
            }
            else
                errorProvider1.SetError(txtTypeFees, null);

            // to prevent past nonNumbers  
            if (!clsValidatoin.IsNumber(txtTypeFees.Text)) 
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTypeFees, "Invalid Number.");
            }
            else
            {
                errorProvider1.SetError(txtTypeFees, null);
            };

        }

        private void txtTestTypeDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTestTypeDescription.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTestTypeDescription, "this field should not be empty");
            }
            else
                errorProvider1.SetError(txtTestTypeDescription, null);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        
    }
}

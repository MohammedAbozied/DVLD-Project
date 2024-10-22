using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Business;

namespace DVLD.Applications.ApplicationTypes
{
    public partial class frmEditApplicationType : Form
    {
        private int _id;
        private clsApplicationType _ApplicationType;
        public frmEditApplicationType(int id)
        {
            InitializeComponent();
            _id = id;
            
        }

       
        private void frmEditApplicationType_Load(object sender, EventArgs e)
        {
            _ApplicationType = clsApplicationType.Find(_id);
            if (_ApplicationType == null)
            {
                MessageBox.Show($"there is no application with id: {_id}", "invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lblAppID.Text = _ApplicationType.ID.ToString();
            txtAppTitle.Text = _ApplicationType.Title;
            txtAppTitle.Focus();
            txtAppFees.Text = _ApplicationType.Fees.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _ApplicationType.Title = txtAppTitle.Text.Trim();
            _ApplicationType.Fees = Convert.ToSingle(txtAppFees.Text.Trim());

            if(MessageBox.Show("are you sure?","save",MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_ApplicationType.Save())
                {
                    MessageBox.Show("the application type updated Successfully :)", "done",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    MessageBox.Show("error in updating application", "error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        



    }
}

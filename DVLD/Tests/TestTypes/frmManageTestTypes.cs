using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_Business.clsTestType;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD.Tests.TestTypes
{
    public partial class frmManageTestTypes : Form
    {
        private DataTable _dt;

        public frmManageTestTypes()
        {
            InitializeComponent();
        }

        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            _dt = clsTestType.GetAllTestTypes();
            dgvTestTypes.DataSource = _dt;
            lblCountTestTypes.Text = dgvTestTypes.Rows.Count.ToString();

            if(dgvTestTypes.Rows.Count > 0)
            {
                dgvTestTypes.Columns[0].HeaderText = "Test Type ID";
                dgvTestTypes.Columns[0].Width = 120;

                dgvTestTypes.Columns[1].HeaderText = "Test Type Title";
                dgvTestTypes.Columns[1].Width = 160;

                dgvTestTypes.Columns[2].HeaderText = "Test Type Description";
                dgvTestTypes.Columns[2].Width = 265;

                dgvTestTypes.Columns[3].HeaderText = "Test Fees";
                dgvTestTypes.Columns[3].Width = 120;
            }
        }


        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = (int)dgvTestTypes.CurrentRow.Cells[0].Value;
            frmUpdateTestType frmUpdateTestType = new frmUpdateTestType((clsTestType.enTestType)id);
            frmUpdateTestType.ShowDialog();
            frmManageTestTypes_Load(null,null); // refresh list 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}

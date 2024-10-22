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
    public partial class frmManageApplicationTypes : Form
    {
        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }

        private DataTable _dt;
        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _dt = clsApplicationType.GetAllTypes();
            dgvApplicationTypes.DataSource = _dt;
            lblCountApplicationTypes.Text = dgvApplicationTypes.Rows.Count.ToString();

            if(dgvApplicationTypes.Rows.Count > 0)
            {
                dgvApplicationTypes.Columns[0].HeaderText = "Application ID";
                dgvApplicationTypes.Columns[0].Width = 120;

                dgvApplicationTypes.Columns[1].HeaderText = "Application Title";
                dgvApplicationTypes.Columns[1].Width = 260;

                dgvApplicationTypes.Columns[2].HeaderText = "Fees";
                dgvApplicationTypes.Columns[2].Width = 120;
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = (int)dgvApplicationTypes.CurrentRow.Cells[0].Value;
            frmEditApplicationType frmEdit = new frmEditApplicationType(id);
            frmEdit.ShowDialog();
            frmManageApplicationTypes_Load(null, null);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}

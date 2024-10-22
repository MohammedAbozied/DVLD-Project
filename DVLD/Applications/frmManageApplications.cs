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

namespace DVLD.Applications
{
    public partial class frmManageApplications : Form
    {
        public frmManageApplications()
        {
            InitializeComponent();
        }

        private DataTable _dt;
        private void frmManageApplications_Load(object sender, EventArgs e)
        {
            _dt = clsApplication.GetAllApplications();
            dgvManageApplications.DataSource = _dt;
            lblCountManageApplications.Text = dgvManageApplications.Rows.Count.ToString();

            if(dgvManageApplications.Rows.Count > 0)
            {
                dgvManageApplications.Columns[0].HeaderText = "App ID";
                dgvManageApplications.Columns[0].Width = 75;

                dgvManageApplications.Columns[1].HeaderText = "Applicant Person ID";
                dgvManageApplications.Columns[1].Width = 120;

                dgvManageApplications.Columns[2].HeaderText = "App Date";
                dgvManageApplications.Columns[2].Width = 150;

                dgvManageApplications.Columns[3].HeaderText = "App TypeID";
                dgvManageApplications.Columns[3].Width = 100;

                dgvManageApplications.Columns[4].HeaderText = "App Status";
                dgvManageApplications.Columns[4].Width = 70;

                dgvManageApplications.Columns[5].HeaderText = "Last Date";
                dgvManageApplications.Columns[5].Width = 150;

                dgvManageApplications.Columns[6].HeaderText = "Fees";
                dgvManageApplications.Columns[6].Width = 100;

                dgvManageApplications.Columns[7].HeaderText = "User ID";
                dgvManageApplications.Columns[7].Width = 75;
            }
        }





    }
}

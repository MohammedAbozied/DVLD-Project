using DVLD.Tests;
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

namespace DVLD.Applications.Local_Driving_License
{
    public partial class frmManageLocalDrivingLicenseApplications : Form
    {

        private DataTable _dtLocalDrivingLicenseApplications;
        private DataView _dv;
        public frmManageLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }

        private void frmManageLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            _dtLocalDrivingLicenseApplications =
             clsLocalDrivingLicenseApplication.GetAllLicenseApplications();
            _dv = new DataView(_dtLocalDrivingLicenseApplications);

            dgvListLocalDrivingLicenseApps.DataSource = _dv;

            lblCountApplications.Text = dgvListLocalDrivingLicenseApps.Rows.Count.ToString();

            cbFilterBy.SelectedIndex = 0;

            if(dgvListLocalDrivingLicenseApps.Rows.Count > 0)
            {
                dgvListLocalDrivingLicenseApps.Columns[0].HeaderText = "L.D.L App ID";
                dgvListLocalDrivingLicenseApps.Columns[0].Width = 95;

                dgvListLocalDrivingLicenseApps.Columns[1].HeaderText = "Driving Class";
                dgvListLocalDrivingLicenseApps.Columns[1].Width = 200;

                dgvListLocalDrivingLicenseApps.Columns[2].HeaderText = "National No";
                dgvListLocalDrivingLicenseApps.Columns[2].Width = 90;

                dgvListLocalDrivingLicenseApps.Columns[3].HeaderText = "Full Name";
                dgvListLocalDrivingLicenseApps.Columns[3].Width = 250;

                dgvListLocalDrivingLicenseApps.Columns[4].HeaderText = "Application Date";
                dgvListLocalDrivingLicenseApps.Columns[4].Width = 140;

                dgvListLocalDrivingLicenseApps.Columns[5].HeaderText = "Passed Tests";
                dgvListLocalDrivingLicenseApps.Columns[5].Width = 70;

                dgvListLocalDrivingLicenseApps.Columns[6].HeaderText = "Status";
                dgvListLocalDrivingLicenseApps.Columns[6].Width = 85;

            }
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtFilter.Text = string.Empty;
            bool isStatusSelected = cbFilterBy.Text == "Status";

            cbStatusFilter.SelectedIndex = isStatusSelected ? 0 : -1; // -1 means no item selected

            txtFilter.Visible = !isStatusSelected && cbFilterBy.Text != "None";
            cbStatusFilter.Visible = isStatusSelected;

            if(txtFilter.Visible)
                txtFilter.Focus();
            else if(cbStatusFilter.Visible)
                cbStatusFilter.Focus();

            lblCountApplications.Text = dgvListLocalDrivingLicenseApps.Rows.Count.ToString();
        }
        private void cbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbStatusFilter.Text))
            {
                _dv.RowFilter = $"[Status] LIKE '{cbStatusFilter.Text}'";
            }
            else
            {
                _dv.RowFilter = ""; // when selected index is -1.
            }

            lblCountApplications.Text = dgvListLocalDrivingLicenseApps.Rows.Count.ToString();
        }
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtFilter.Text.Trim()))
            {
                string selectedRow = "";

                switch(cbFilterBy.Text)
                {
                    case "L.D.L App ID":
                        selectedRow = "LocalDrivingLicenseApplicationID";
                        break;

                    case "National No":
                        selectedRow = "NationalNo";
                        break;

                    case "Full Name":
                        selectedRow = "FullName";
                        break;
                }

                _dv.RowFilter = selectedRow == "LocalDrivingLicenseApplicationID" ?
                    $"[{selectedRow}] = '{txtFilter.Text.Trim()}'" :
                    $"[{selectedRow}] LIKE '%{txtFilter.Text.Trim()}%'";

                lblCountApplications.Text = dgvListLocalDrivingLicenseApps.Rows.Count.ToString();
            }
            else
            {
                _dv.RowFilter = "";
            }
        }
        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = cbFilterBy.Text == "L.D.L App ID" ?
                !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) : false;
            /*
            when e.handled true -> prevent enter the key 
            when cbFilterBy is app ID will allow to backspace and numbers only
            else allow to anything
            */
        }
        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDL_ApplicationID = (int)dgvListLocalDrivingLicenseApps.CurrentRow.Cells[0].Value;
            frmLocalDrivingLicenseApplicationInfo frm = new frmLocalDrivingLicenseApplicationInfo(LDL_ApplicationID);
            frm.ShowDialog();
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDL_ApplicationID = (int)dgvListLocalDrivingLicenseApps.CurrentRow.Cells[0].Value;

            frmAddUpdateLocalLicenseApplication frmUpdate = new frmAddUpdateLocalLicenseApplication(LDL_ApplicationID);
            frmUpdate.ShowDialog();

            frmManageLocalDrivingLicenseApplications_Load(null, null); // refresh
        }

        private void btnAdd_LDLApp_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalLicenseApplication frmAddNew = new frmAddUpdateLocalLicenseApplication();
            frmAddNew.ShowDialog();

            frmManageLocalDrivingLicenseApplications_Load(null, null); // refresh
            
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLAppID = (int)dgvListLocalDrivingLicenseApps.CurrentRow.Cells[0].Value;

            if(MessageBox.Show($"are you sure from deleting this L.D.L Application with id {LDLAppID}",
                "ensure the deletion",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                clsLocalDrivingLicenseApplication clsLDLApp =
                    clsLocalDrivingLicenseApplication.FindByLDLAppID(LDLAppID);

                if(clsLDLApp.Delete())
                {
                    MessageBox.Show("the application deleted successfully", "Successfully",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    frmManageLocalDrivingLicenseApplications_Load(null, null); // refresh
                }
                else
                {
                    MessageBox.Show("failed in deleting the application.", "deletion failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int LDLAppID = (int)dgvListLocalDrivingLicenseApps.CurrentRow.Cells[0].Value;

            if(MessageBox.Show($"are you sure you want cancelled this application with ID: {LDLAppID}",
                "cancel application",MessageBoxButtons.YesNo,MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            clsLocalDrivingLicenseApplication clsLDLApp = 
                clsLocalDrivingLicenseApplication.FindByLDLAppID(LDLAppID);

            if (clsLDLApp.Cancel())
            {
                MessageBox.Show("the application cancelled successfully");
                frmManageLocalDrivingLicenseApplications_Load(null, null); // refresh

            }
            else
                MessageBox.Show("failed in cancelled the application");
        }

        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmScheduleTest frmSchedule = new frmScheduleTest();
            frmSchedule.ShowDialog();
        }



    }
}

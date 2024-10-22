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

namespace DVLD.Users
{
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
        }

        private DataTable _dtUsers;
        private DataView _dvUsers;

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _dtUsers = clsUser.GetAllUsers();
            _dvUsers = new DataView(_dtUsers);
            dgvListUsers.DataSource = _dvUsers;

            lblCountUsers.Text = _dvUsers.Count.ToString();

            cbFilterBy.SelectedIndex = 0; // Combo box default 'None'
            if(dgvListUsers.Rows.Count >0)
            {

                dgvListUsers.Columns[0].HeaderText = "User ID";
                dgvListUsers.Columns[0].Width = 100;

                dgvListUsers.Columns[1].HeaderText = "Person ID";
                dgvListUsers.Columns[1].Width = 100;

                dgvListUsers.Columns[2].HeaderText = "Full Name";
                dgvListUsers.Columns[2].Width = 250;

                dgvListUsers.Columns[3].HeaderText = "User Name";
                dgvListUsers.Columns[3].Width = 200;

                dgvListUsers.Columns[4].HeaderText = "Is Active";
                dgvListUsers.Columns[4].Width = 100;
            }
        }

        // This method is my idea :)
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtFilterBy.Text = "";
            rbActive.Checked = false;
            rbNotActive.Checked = false;

            // radio buttons (activity)
            rbActive.Visible = rbNotActive.Visible
                             = rbActive.Checked 
                             = (cbFilterBy.SelectedItem.ToString() == "Is Active");
            

            //text box (search)
            txtFilterBy.Visible = (cbFilterBy.SelectedItem.ToString() != "Is Active");
            txtFilterBy.Enabled = (cbFilterBy.SelectedItem.ToString() != "None");
            txtFilterBy.Focus();
           
        }

        private void rbActive_CheckedChanged(object sender, EventArgs e)
        {
            _dvUsers.RowFilter = rbActive.Checked ? "[IsActive] = 1" : "";
            lblCountUsers.Text = _dvUsers.Count.ToString();
        }

        private void rbNotActive_CheckedChanged(object sender, EventArgs e)
        {
            _dvUsers.RowFilter = rbNotActive.Checked ? "[IsActive] = 0" : "";
            lblCountUsers.Text = _dvUsers.Count.ToString();
        }

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            string filterColumn = cbFilterBy.SelectedItem.ToString().Replace(" ", "");
            
            if (!string.IsNullOrEmpty(txtFilterBy.Text.Trim()))
            {
                if (filterColumn == "UserID" || filterColumn == "PersonID")
                {
                    if (int.TryParse(txtFilterBy.Text.Trim(), out int id))
                    {
                        _dvUsers.RowFilter = $"[{filterColumn}] = {id}";
                    }
                    else
                    {
                        _dvUsers.RowFilter = "";
                    }
                }
                else
                {
                    _dvUsers.RowFilter = $"[{filterColumn}] LIKE '%{txtFilterBy.Text.Trim()}%'";
                }
            }
            else
            {
                _dvUsers.RowFilter = "";
            }

            lblCountUsers.Text = _dvUsers.Count.ToString();
        }

        private void lblRefreshList_Click(object sender, EventArgs e)
        {
            /*_dvUsers.RowFilter = "";
            cbFilterBy.SelectedIndex = 0;*/

            frmManageUsers_Load(null, null); // this way to refresh form 
        }

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            // only allow to enter key, and controls keys like backspace and enter.
            if (cbFilterBy.Text =="User ID" || cbFilterBy.Text =="Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); 
            // Note : when e.Handled = true , this mean that the pressed key not allow 
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showUserInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frmUserInfo = new frmUserInfo((int)dgvListUsers.CurrentRow.Cells[0].Value);
            frmUserInfo.ShowDialog();
            frmManageUsers_Load(null, null); // refresh list, may user update person information.

        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frmAddUser = new frmAddUpdateUser();
            frmAddUser.ShowDialog();
            frmManageUsers_Load(null, null); // refresh list
        } 
        private void editUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frmUpdateUser = new frmAddUpdateUser((int)dgvListUsers.CurrentRow.Cells[0].Value);
            frmUpdateUser.ShowDialog();
            frmManageUsers_Load(null, null); // refresh list
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddNewUser.PerformClick();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvListUsers.CurrentRow.Cells[0].Value;
            frmChangePassword frmChangePassword = new frmChangePassword(UserID);
            frmChangePassword.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int userID = (int)dgvListUsers.CurrentRow.Cells[0].Value;
            frmUserInfo frmUserInfo = new frmUserInfo(userID,true);
            frmUserInfo.ShowDialog();
            frmManageUsers_Load(null, null); // refresh list
        }


    }
}

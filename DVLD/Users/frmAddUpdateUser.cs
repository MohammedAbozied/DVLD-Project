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
using static DVLD_Business.clsUser;
namespace DVLD.Users
{
    public partial class frmAddUpdateUser : Form
    {
        private enum eMode { AddNew =0, Update=1 } 
        private eMode _Mode = eMode.AddNew;
        private int _UserID;
        private clsUser _User;

        public frmAddUpdateUser()
        {
            InitializeComponent();
            _Mode = eMode.AddNew;
        }

        public frmAddUpdateUser(int UserID)
        {
            InitializeComponent();
            _Mode = eMode.Update;
            _UserID = UserID;
        }

        private void _ResetDefaultValues()
        {
            if(_Mode == eMode.AddNew)
            {
                lblAddUpdateUser.Text = this.Text  = "Add New User";
                _User = new clsUser();
                ctrlPersonCardWithFilter1.txtFilterBy.Focus();
                tpLoginInfo.Enabled = false;
            }
            else
            {
                lblAddUpdateUser.Text = this.Text = "Update User";
                tpLoginInfo.Enabled = true;
                btnSave.Enabled = true;
                btnNext.Enabled = true;
                ctrlPersonCardWithFilter1.FilterEnabled = false;
            }

            ctrlPersonCardWithFilter1.ctrlPersonInformation.ResetPersonInfo();
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            chkIsActive.Checked = true;

        }


        private void _LoadData()
        {
            _User = FindUserByUserID(_UserID);
            
            if (_User == null) 
            {
                MessageBox.Show($"the User with id {_UserID} Not Found.", "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // person information load 
            ctrlPersonCardWithFilter1.ctrlPersonInformation.LoadPersonInfo(_User.PersonID);
            // tap login information
            lblUserID.Text = _User.UserID.ToString();
            txtUserName.Text = _User.UserName;
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            chkIsActive.Checked = _User.IsActive;

        }
        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if (_Mode == eMode.Update)
                _LoadData();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlPersonCardWithFilter1_PersonSelected(object sender, People.controls.ctrlPersonCardWithFilter.DataBackEventArgs e)
        {
            
            if (IsUserExistByPersonID(e.PersonID))
            {
                _ResetDefaultValues();
                MessageBox.Show("the person already linked to another user","error",
                    MessageBoxButtons.OK,MessageBoxIcon.Error); 
                return;
            }

            btnNext.Enabled = btnSave.Enabled =  tpLoginInfo.Enabled = true;
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLoginInfo"];
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLoginInfo"];
                MessageBox.Show("all fields should be filled", "validation error",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            _User.PersonID = ctrlPersonCardWithFilter1.PersonID;
            _User.UserName = txtUserName.Text.Trim();
            _User.Password = txtPassword.Text.Trim();
            _User.IsActive = chkIsActive.Checked;

            if(_User.Save())
            {
                lblUserID.Text = _User.UserID.ToString();
                _Mode = eMode.Update;
                lblAddUpdateUser.Text = "Update User";
                this.Text = "Update User";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            // in case user name is empty
            if(string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "User Name Not should be empty.");
            }
            else
            {
                errorProvider1.SetError(txtUserName, null);
            }

            // in case add new user mode 
            if (_Mode == eMode.AddNew)
            {
                if(IsUserExist(txtUserName.Text.Trim()))
                {
                    e.Cancel=true;
                    errorProvider1.SetError(txtUserName, "the user is already existed.");
                }
                else
                {
                    errorProvider1.SetError(txtUserName, null);
                }

            }
            // in case Update mode 
            else 
            {
                if (txtUserName.Text.Trim() != _User.UserName)
                {
                    if (IsUserExist(txtUserName.Text.Trim()))
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(txtUserName, "the user is already existed.");
                    }
                    else
                    {
                        errorProvider1.SetError(txtUserName, null);
                    }
                }

            }


        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "password can't be blank");
            }
            else
                errorProvider1.SetError(txtPassword, null);


        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() != txtPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "doesn't match password");
            }
            else
                errorProvider1.SetError(txtConfirmPassword, null);
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsWhiteSpace(e.KeyChar);// not allow to space
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsWhiteSpace(e.KeyChar);// not allow to space
        }

        private void txtConfirmPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsWhiteSpace(e.KeyChar);// not allow to space
        }
    }
}

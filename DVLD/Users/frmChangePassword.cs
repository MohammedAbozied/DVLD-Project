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
    public partial class frmChangePassword : Form
    {

        private clsUser _User;
        private int _UserID;
        public frmChangePassword(int userID)
        {
            InitializeComponent();
            _UserID = userID;
        }
        private void _ResetDefault()
        {
            txtOldPassword.Text = "";
            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtOldPassword.Focus();
        }
        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _ResetDefault();
            _User = FindUserByUserID(_UserID);

            if(_User == null)
            {
                MessageBox.Show($"User Not with ID {_UserID} Not Found", "Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ctrlUserCard1.LoadUserInfo( _UserID);
        }




        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtOldPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsWhiteSpace(e.KeyChar); // not allow to space 
        }

        private void txtNewPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsWhiteSpace(e.KeyChar); // not allow to space 
        }

        private void txtConfirmPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsWhiteSpace(e.KeyChar); // not allow to space 
        }

        private void txtOldPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtOldPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtOldPassword, "password shouldn't be empty");
                return;
            }
            else
                errorProvider1.SetError(txtOldPassword, null);


            if (txtOldPassword.Text.Trim() != _User.Password)
            {
                e.Cancel = true ;
                errorProvider1.SetError(txtOldPassword,"password is not correct");
            }
            else
                errorProvider1.SetError(txtOldPassword , null);

        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtNewPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "password shouldn't be empty");
                return;
            }
            else
                errorProvider1.SetError(txtNewPassword, null);

            if (txtNewPassword.Text.Trim() == _User.Password)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "password same current password\n\tchoose a new");
            }
            else
                errorProvider1.SetError(txtNewPassword, null);

        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() != txtNewPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "password doesn't match new password");
            }
            else
                errorProvider1.SetError(txtConfirmPassword, null);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren() )
            {
                MessageBox.Show("there is something wrong","wrong",
                    MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }

            _User.Password = txtNewPassword.Text;

            if(_User.Save())
            {
                MessageBox.Show("the password changed successfully","done",
                    MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("password didn't change","error occurred",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}

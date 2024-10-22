using DVLD.Classes;
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

namespace DVLD
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsUser _User = clsUser.FindUserByUserNameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());

            if(_User != null)
            {
                if(chbRemeberMe.Checked)
                {
                    clsGlobal.RememberUsernameAndPassword(_User.UserName, _User.Password);
                }
                else
                {
                    clsGlobal.RememberUsernameAndPassword("", "");
                }

                if(!_User.IsActive)
                {
                    MessageBox.Show("this account is not active, contact Admin", "in active account",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUserName.Focus();
                    return;
                }

                clsGlobal.CurrentUser = _User;
                frmMain frmMain = new frmMain(this);
                this.Hide();
                frmMain.ShowDialog();

            }
            else
            {
                txtUserName.Focus();
                MessageBox.Show("the user name or password in not valid","not valid",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }


        private void frmLogin_Load(object sender, EventArgs e)
        {
            string UserName = "", Password = "";

            chbRemeberMe.Checked = clsGlobal.GetStoredCredential(ref UserName, ref Password);
            txtUserName.Text = UserName;
            txtPassword.Text = Password;
        }





        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsWhiteSpace(e.KeyChar); // now allow to space
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsWhiteSpace(e.KeyChar); // now allow to space

        }

        private void txtPassword_MouseHover(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '\0'; // '\0' represents null character
        }

        private void txtPassword_MouseLeave(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }




    }
}

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
    public partial class frmUserInfo : Form
    {
        private int _UserID;
        public frmUserInfo(int UserID, bool deleteForm = false)
        {
            InitializeComponent();
            this._UserID = UserID;
            btnDelete.Visible = deleteForm; // we can use this form to delete person.
        }

        private void frmUserInfo_Load(object sender, EventArgs e)
        {
            ctrlUserCard1.LoadUserInfo(_UserID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("are you sure you want delete this user", "delete user",
                MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (clsUser.DeleteUser(_UserID))
                {
                    MessageBox.Show("user deleted successfully", "successfully",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                    MessageBox.Show("failed in deleting user", "error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();

        }
    }
}

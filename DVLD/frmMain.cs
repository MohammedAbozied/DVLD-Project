using DVLD.Applications;
using DVLD.Applications.ApplicationTypes;
using DVLD.Applications.Local_Driving_License;
using DVLD.Classes;
using DVLD.People;
using DVLD.Tests.TestTypes;
using DVLD.Users;
using System;
using System.Deployment.Application;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmMain : Form
    {
        frmLogin _frmLogin;
        public frmMain(frmLogin frmLogin)
        {
            InitializeComponent();
            _frmLogin = frmLogin;
            
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManagePeople frm = new frmManagePeople();
            frm.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageUsers frmManageUsers = new frmManageUsers();
            frmManageUsers.ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmFindPerson frmFindPerson = new frmFindPerson();
            frmFindPerson.ShowDialog();

        }

        

        private void currenetUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frmUserInfo = new frmUserInfo(clsGlobal.CurrentUser.UserID);
            frmUserInfo.ShowDialog();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            /*this.Close();
            _frmLogin.Show();*/
            Application.Restart(); // restarting will open login form

        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); // will end tasks of all forms
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageApplicationTypes frm = new frmManageApplicationTypes();
            frm.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestTypes frmTestTypes = new frmManageTestTypes();
            frmTestTypes.ShowDialog();
        }

        private void toolStripSeparator2_Click(object sender, EventArgs e)
        {
            frmManageApplications frm = new frmManageApplications();
            frm.ShowDialog();
        }

        private void addNewLocalLicenseAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalLicenseApplication frmAddNew = new frmAddUpdateLocalLicenseApplication();
            frmAddNew.ShowDialog();
        }
    }



}

﻿using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Users.Controls
{
    public partial class ctrlUserCard : UserControl
    {

        public ctrlUserCard()
        {
            InitializeComponent();
        }


        private int _UserID;
        private clsUser _User;

        public int UserID { get { return _UserID; } }

        public void LoadUserInfo(int UserID)
        {
            this._UserID = UserID;
            _User = clsUser.FindUserByUserID(UserID);

            if(_User == null)
            {
                _ResetUserInfo();
                MessageBox.Show($"the user with id :{UserID} Not founded","User not founded",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }

            _FillUserInfo();
        }

        private void _FillUserInfo()
        {
            ctrlPersonCard1.LoadPersonInfo(_User.PersonID);
            lblUserID.Text = _User.UserID.ToString();
            lblUserName.Text = _User.UserName.ToString();
            lblIsActive.Text = _User.IsActive == true ? "YES" : "NO";
        }

        private void _ResetUserInfo()
        {
            ctrlPersonCard1.ResetPersonInfo();
            lblUserID.Text = "[????]";
            lblUserName.Text = "[????]";
            lblIsActive.Text = "[????]";
        }


    }
}

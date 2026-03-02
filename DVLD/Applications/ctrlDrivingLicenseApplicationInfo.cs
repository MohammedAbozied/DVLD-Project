using DVLD.People;
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
    public partial class ctrlDrivingLicenseApplicationInfo : UserControl
    {
        public ctrlDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplicationInfo;
        private int? _ApplicationID = null;
        private int? _licenseID = null;

        public int? ApplicationID 
        { 
            get  => _ApplicationID; 
        }
         
        public bool LoadApplicationInfoByApplicationID(int appID)
        {
            _LocalDrivingLicenseApplicationInfo =
                clsLocalDrivingLicenseApplication.FindByApplicationID(appID);

            if(_LocalDrivingLicenseApplicationInfo == null)
            {
                _ResetInfo();

                MessageBox.Show($"No D.L Application with ID {appID}", "Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            _FillInfo();
            return true;
        }

        public bool LoadApplicationInfoByLocalDrivingLicenseApplicationID(int ldlAppID)
        {
            _LocalDrivingLicenseApplicationInfo =
                clsLocalDrivingLicenseApplication.FindByLDLAppID(ldlAppID);

            if (_LocalDrivingLicenseApplicationInfo == null)
            {
                _ResetInfo();

                MessageBox.Show($"No L.D.L Application with ID {ldlAppID}", "Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            _FillInfo();
            return true;
        }

        private void _ResetInfo()
        {
            _ApplicationID = null;

            // license info
            lblLocalDrivingLicenseApplicationID.Text = "[???]";
            lblAppliedForLicense.Text = "[???]";
            lblPassedTests.Text = "[???]";

            // application info
            lblApplicationID.Text = "[???]";
            lblAppStatus.Text = "[???]";
            lblAppFees.Text = "[???]";
            lblAppType.Text = "[???]";
            lblApplicantName.Text = "[???]";
            lblDate.Text = "[???]";
            lblStatusDate.Text = "[???]";
            lblCreatedBy.Text = "[???]";
        }

        private void _FillInfo()
        {
            _licenseID = _LocalDrivingLicenseApplicationInfo.GetActiveLicenseID();

            lblShowLicenseInfo.Visible = _licenseID.HasValue;

            // fill driving licenseApplication info 
            lblLocalDrivingLicenseApplicationID.Text =
                _LocalDrivingLicenseApplicationInfo.LocalDrivingLicenseApplicationID.ToString();
            lblAppliedForLicense.Text = _LocalDrivingLicenseApplicationInfo.LicenseClassInfo.ClassName;
            lblPassedTests.Text = "[???]";

            // fill basic application info
            lblApplicationID.Text = _LocalDrivingLicenseApplicationInfo.ApplicationID.ToString();
            lblAppStatus.Text = _LocalDrivingLicenseApplicationInfo.ApplicationStatus.ToString();
            lblAppFees.Text = _LocalDrivingLicenseApplicationInfo.PaidFees.ToString();
            lblAppType.Text = _LocalDrivingLicenseApplicationInfo.ApplicationTypeInfo.Title;
            lblApplicantName.Text = _LocalDrivingLicenseApplicationInfo.PersonFullName;
            lblDate.Text = _LocalDrivingLicenseApplicationInfo.ApplicationDate.ToString();
            lblStatusDate.Text = _LocalDrivingLicenseApplicationInfo.LastStatusDate.ToString();
            lblCreatedBy.Text = _LocalDrivingLicenseApplicationInfo.CreatedByUserInfo.UserName.ToString();

        }

        private void lblViewPersonInfo_Click(object sender, EventArgs e)
        {
            frmPersonInfo frmPersonInfo = new
                frmPersonInfo(_LocalDrivingLicenseApplicationInfo.ApplicantPersonID);

            frmPersonInfo.ShowDialog();
        }
    }
}

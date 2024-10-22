using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Classes;
using DVLD_Business;

namespace DVLD.Applications.Local_Driving_License
{
    public partial class frmAddUpdateLocalLicenseApplication : Form
    {

        public enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode;

        private int _LocalDrivingLicenseApplicationID;
        private int? _SelectedPersonID = null;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        public frmAddUpdateLocalLicenseApplication()
        {
            InitializeComponent();
            this._Mode = enMode.AddNew;
           
        }

        public frmAddUpdateLocalLicenseApplication(int DrivingLicenseApplicationID)
        {
            InitializeComponent();
            this._LocalDrivingLicenseApplicationID = DrivingLicenseApplicationID;
            this._Mode = enMode.Update;
        }

        private void frmAddUpdateLocalLicenseApplication_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if (this._Mode == enMode.Update)
                _LoadPersonalInfo();
        }
        private void _FillLicenseClassComboBox()
        {

            DataTable dtLicenseClasses = clsLicenseClass.GetAllLicenseClasses(); 

            foreach (DataRow dr in dtLicenseClasses.Rows)
            {
                cbLicenseClass.Items.Add(dr["ClassName"]);
            }

        }

        private void _ResetDefaultValues()
        {
            _FillLicenseClassComboBox();

            if(_Mode == enMode.AddNew) // add new mode 
            {
                lblTitle.Text = this.Text = "New Local Driving License Application";
                _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
                // personal info tap
       
                tpApplicationInfo.Enabled = false;

                // application info tap
                lblApplicationDate.Text = DateTime.Now.ToShortDateString();
                lblApplicationFees.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.NewDrivingLicense).Fees.ToString();
                cbLicenseClass.SelectedIndex = 0;
                lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;

            }
            else // update mode 
            {
                lblTitle.Text = this.Text = "Update Local Driving License Application";
                ctrlPersonCardWithFilter1.FilterEnabled = false;
                btnSave.Enabled = true;
            }
        }

        private void _LoadPersonalInfo()
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.
                FindByLicenseID(_LocalDrivingLicenseApplicationID);

            if(_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show($"No Driving License Application With ID {_LocalDrivingLicenseApplicationID}",
                    "Not Found",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ctrlPersonCardWithFilter1.LoadPersonInfo(_LocalDrivingLicenseApplication.ApplicantPersonID);

            lblLocalDrivingClassApplicationID.Text = _LocalDrivingLicenseApplication.ApplicationID.ToString();
            lblApplicationDate.Text = _LocalDrivingLicenseApplication.ApplicationDate.ToShortDateString();
            cbLicenseClass.SelectedIndex = cbLicenseClass.FindString(clsLicenseClass.FindLicenseClassByID(_LocalDrivingLicenseApplication.LicenseClassID).ClassName);
            lblApplicationFees.Text= _LocalDrivingLicenseApplication.PaidFees.ToString();
            lblCreatedBy.Text = _LocalDrivingLicenseApplication.CreatedByUserInfo.UserName;

        }

        private void ctrlPersonCardWithFilter1_PersonSelected(object sender, People.controls.ctrlPersonCardWithFilter.DataBackEventArgs e)
        {
            _SelectedPersonID = e.PersonID;
            tpApplicationInfo.Enabled = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            if (_Mode == enMode.AddNew && !_SelectedPersonID.HasValue)
            {
                MessageBox.Show("you should select person to apply application",
                    "Not found person", MessageBoxButtons.OK);

                return;
            }

            tcLocalLicenseApplication.SelectedTab = 
                tcLocalLicenseApplication.TabPages["tpApplicationInfo"];

            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("are you sure you want to save this application","saving",
                MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {
                int LicenseClassID = clsLicenseClass.FindLicenseClassByClassName(cbLicenseClass.Text).LicenseClassID;

                int? activeApplication = clsApplication.GetActiveApplicationIDForLicenseClass(
                    _LocalDrivingLicenseApplication.ApplicantPersonID, clsApplication.enApplicationType.NewDrivingLicense, LicenseClassID);

                // if person has an active new driving license application in system.
                if(activeApplication.HasValue)
                {
                    MessageBox.Show($"the selected Person Already have an active application for the selected class with id {activeApplication}",
                        "Choose another License Class, ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbLicenseClass.Focus();
                    return;
                }

                // if person has the same type of license 
                // after complete clsLicense dataAccess and business

                // Fill object
                _LocalDrivingLicenseApplication.ApplicantPersonID = ctrlPersonCardWithFilter1.PersonID;
                _LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;
                _LocalDrivingLicenseApplication.ApplicationTypeID = (byte)clsApplication.enApplicationType.NewDrivingLicense;
                _LocalDrivingLicenseApplication.ApplicationStatus = clsApplication.enApplicationStatus.New;
                _LocalDrivingLicenseApplication.LastStatusDate = DateTime.Now;
                _LocalDrivingLicenseApplication.PaidFees = Convert.ToSingle(lblApplicationFees.Text);
                _LocalDrivingLicenseApplication.LicenseClassID = LicenseClassID;
                _LocalDrivingLicenseApplication.CreatedByUserID = clsGlobal.CurrentUser.UserID;

                if (_LocalDrivingLicenseApplication.Save())
                {
                    lblLocalDrivingClassApplicationID.Text = _LocalDrivingLicenseApplication.
                        LocalDrivingLicenseApplicationID.ToString();

                    this._Mode = enMode.Update;

                    lblTitle.Text = this.Text = "Update Local Driving License Application";

                    MessageBox.Show($"the local driving class application is saved successfully with ID: {_LocalDrivingLicenseApplicationID}",
                        "saved Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                    MessageBox.Show("Error: data is not saved", "error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }





    }
}

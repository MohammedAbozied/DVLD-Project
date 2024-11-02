using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsLocalDrivingLicenseApplication : clsApplication
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public int LocalDrivingLicenseApplicationID { get; set; } 
        public int LicenseClassID { get; set; }
        public clsLicenseClass LicenseClassInfo { get; set; }
        public string PersonFullName 
        { 
            get 
            {
                return base.PersonInfo.FullName;
            } 
        }

        public clsLocalDrivingLicenseApplication():base()
        {
            this.LocalDrivingLicenseApplicationID = -1;
            this.LicenseClassID = -1;

            this.Mode = enMode.AddNew;
        }

        public clsLocalDrivingLicenseApplication(int LicenseApplicationID, 
            int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate,
            int ApplicationTypeID, enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
            float PaidFees, int CreatedByUserID,int LicenseClassID): base(ApplicationID,
                ApplicantPersonID,ApplicationDate,ApplicationTypeID,ApplicationStatus,LastStatusDate,PaidFees,CreatedByUserID)
        {
            this.LocalDrivingLicenseApplicationID= LicenseApplicationID;
            this.LicenseClassID= LicenseClassID;
            this.LicenseClassInfo = clsLicenseClass.FindLicenseClassByID(LicenseClassID);

            this.Mode = enMode.Update;
        }

        private bool _AddNewLocalLicenseApplication()
        {
            this.LocalDrivingLicenseApplicationID =
                    clsLocalDrivingLicenseApplicationData.AddNewLocalDrivingLicenseApplication
                    (base.ApplicationID,this.LicenseClassID);

            return this.LocalDrivingLicenseApplicationID != -1;
        }

        private bool _UpdateLocalLicenseApplication()
        {
            return clsLocalDrivingLicenseApplicationData.UpdateLocalDrivingLicenseApplication
                (this.LocalDrivingLicenseApplicationID, base.ApplicationID, this.LicenseClassID);
        }

        public bool Save()
        {
            base._Mode = (clsApplication.enMode)this.Mode;
            if (!base.Save())
                return false;

            switch (Mode)
            {
                case enMode.AddNew:
                    if(_AddNewLocalLicenseApplication())
                    {
                        this.Mode = enMode.Update;
                        return true; 
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateLocalLicenseApplication();

                default:
                    return false;
            } 
        }

        public bool Delete(int LicenseID)
        {
            if (clsLocalDrivingLicenseApplicationData.DeleteLocalDrivingLicenseApplication(LicenseID))
                return clsApplicationData.DeleteApplication(base.ApplicationID);

            return false;
        }

        public static clsLocalDrivingLicenseApplication FindByLDLAppID(int ldlAppID)
        {
            int ApplicationID = -1, LicenseClassID = -1;  

            bool isFound = clsLocalDrivingLicenseApplicationData.
                GetLocalDrivingLicenseApplicationInfoByID(ldlAppID, ref ApplicationID, ref LicenseClassID);
             
            if(isFound)
            {
                clsApplication Application = clsApplication.Find(ApplicationID);

                return new clsLocalDrivingLicenseApplication(ldlAppID, ApplicationID,
                    Application.ApplicantPersonID, Application.ApplicationDate, Application.ApplicationTypeID,
                    Application.ApplicationStatus, Application.LastStatusDate, Application.PaidFees, Application.CreatedByUserID,
                    LicenseClassID);
            }
            else
                return null;
        }

        public static clsLocalDrivingLicenseApplication FindByApplicationID(int ApplicationID)
        {
            int LDLApplicationID = -1, LicenseClassID = -1;

            bool isFound = clsLocalDrivingLicenseApplicationData.
                GetLocalDrivingLicenseApplicationInfoByAppID(ApplicationID, ref LDLApplicationID, ref LicenseClassID);

            if (isFound)
            {
                clsApplication Application = clsApplication.Find(ApplicationID);

                return new clsLocalDrivingLicenseApplication(LDLApplicationID, ApplicationID,
                    Application.ApplicantPersonID, Application.ApplicationDate, Application.ApplicationTypeID,
                    Application.ApplicationStatus, Application.LastStatusDate, Application.PaidFees, Application.CreatedByUserID,
                    LicenseClassID);
            }
            else
                return null;
        }

        public static DataTable GetAllLicenseApplications()
        {
            return clsLocalDrivingLicenseApplicationData.GetAllLocalLicenseApplications();
        }

        public int? GetActiveLicenseID()
        {
            return clsLicense.GetActiveLicenseIDByPersonID(this.ApplicationID, this.LicenseClassID);
        }


    }
}

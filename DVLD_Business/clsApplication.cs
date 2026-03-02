using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsApplication
    {
        public enum enMode { AddNew = 0 , Update = 1 }
        public enMode _Mode = enMode.AddNew;
        public enum enApplicationType:byte 
        { NewDrivingLicense = 1,RenewDrivingLicense = 2, 
            ReplaceLostDrivingLicense = 3, ReplaceDamagedDrivingLicense = 4, 
            ReleaseDetainedDrivingLicense = 5, NewInternationalLicense = 6, RetakeTest = 7
        };
        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 };
        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }
        public clsPerson PersonInfo;
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public clsApplicationType ApplicationTypeInfo;
        public enApplicationStatus ApplicationStatus { get; set; }
        public string StatusText 
        { 
            get 
            { 
                switch (ApplicationStatus)
                {
                    case enApplicationStatus.New:
                        return "New";
                    case enApplicationStatus.Cancelled:
                        return "Cancelled";
                    case enApplicationStatus.Completed:
                        return "Completed";
                    default:
                        return "Unknown";
                }
            } 
        }  
        public DateTime LastStatusDate { get; set; }
        public float PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public clsUser CreatedByUserInfo;

        public clsApplication() // for table
        {
            this.ApplicationID = -1;
            this.ApplicantPersonID = -1;
            this.ApplicationDate = DateTime.Now;
            this.ApplicationTypeID = -1;
            this.ApplicationStatus = enApplicationStatus.New;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;

            this._Mode = enMode.AddNew;
        }

        // constructor using with find method 
        public clsApplication(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate,
            int ApplicationTypeID, enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
            float PaidFees, int CreatedByUserID)
        {
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.PersonInfo = clsPerson.Find(this.ApplicantPersonID);
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeInfo = clsApplicationType.Find(this.ApplicationTypeID);
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees= PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedByUserInfo = clsUser.FindUserByUserID(this.CreatedByUserID);

            this._Mode = enMode.Update;
        }

        private bool _AddNewApplication()
        {
            this.ApplicationID = clsApplicationData.AddNewApplication(this.ApplicantPersonID,
                this.ApplicationDate,this.ApplicationTypeID,(byte)this.ApplicationStatus,
                this.LastStatusDate,this.PaidFees,this.CreatedByUserID);

            return this.ApplicationID != -1;
        }

        private bool _UpdateApplication()
        {
            return clsApplicationData.UpdateApplication(this.ApplicationID,this.ApplicantPersonID,
                this.ApplicationDate, this.ApplicationTypeID, (byte)this.ApplicationStatus,
                this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
        }

        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplication())
                    {
                        _Mode = enMode.Update; 
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateApplication();

                default: 
                    return false;
            }
        }

        public static clsApplication Find(int ApplicationID)
        {
            int ApplicantPersonID = -1, ApplicationTypeID = -1,CreatedByUserID = -1;
            float PaidFees = 0;
            byte ApplicationStatus = 0;
            DateTime ApplicationDate = DateTime.Now, LastStatusDate = DateTime.Now;

            if (clsApplicationData.GetApplicationInfoByID(ApplicationID,ref ApplicantPersonID,
                ref ApplicationDate,ref ApplicationTypeID,ref ApplicationStatus,
                ref LastStatusDate,ref PaidFees,ref CreatedByUserID))
            {
                return new clsApplication(ApplicationID, ApplicantPersonID, ApplicationDate,
                    ApplicationTypeID,(enApplicationStatus)ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
            }
            else
               return null;
        }

        public static DataTable GetAllApplications()
        {
            return clsApplicationData.GetAllApplications();
        }

        public bool Delete()
        {
            return clsApplicationData.DeleteApplication(this.ApplicationID);
        }

        public static int? GetActiveApplicationIDForLicenseClass(int personID, clsApplication.enApplicationType applicationTypeID, int licenseClassID)
        {
            return clsApplicationData.GetActiveApplicationIDForLicenseClass(personID, (int)applicationTypeID, licenseClassID);
        }

        public bool Cancel()
        {
            this.ApplicationStatus = enApplicationStatus.Cancelled;
            return _UpdateApplication();
        }

    }
}

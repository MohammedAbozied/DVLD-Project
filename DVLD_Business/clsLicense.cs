using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;


namespace DVLD_Business
{
    public class clsLicense
    {
        private enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode;

        public enum enIssueReason : byte { FirstTime = 1, Renew = 2, DamagedReplacement = 3, LostReplacement = 4 };

        public int? LicenseID { get; set; }
        public int? ApplicationID { get; set; }
        public int? DriverID { get; set; }
        public clsDriver DriverInfo;
        public int? LicenseClass { get; set; }
        public clsLicenseClass LicenseClassInfo;
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public float? PaidFees { get; set; }
        public bool? IsActive { get; set; }
        public enIssueReason IssueReason { get; set; }
        public string IssueReasonText 
        {
            get => GetIssueReasonText(this.IssueReason);
        }
        public int? CreatedByUserID { get; set; }

        public clsLicense()
        {
            this.LicenseID = null;
            this.ApplicationID = null;
            this.DriverID = null;
            this.LicenseClass = null;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.Notes = null;
            this.PaidFees = null;
            this.IsActive = true;
            this.IssueReason = enIssueReason.FirstTime;
            this.CreatedByUserID = null;

            this._Mode = enMode.AddNew;
        }
        public clsLicense(int licenseID, int applicationID, int driverID, int licenseClass, DateTime issueDate,
            DateTime expirationDate, string notes, float paidFees, bool isActive,
            enIssueReason issueReason, int createdByUserID)
        {
            this.LicenseID = licenseID;
            this.ApplicationID = applicationID;
            this.DriverID = driverID;
            this.DriverInfo = clsDriver.FindByDriverID(this.DriverID.Value);
            this.LicenseClass = licenseClass;
            this.LicenseClassInfo = clsLicenseClass.FindLicenseClassByID(this.LicenseID.Value);
            this.IssueDate = issueDate;
            this.ExpirationDate = expirationDate;
            this.Notes = notes;
            this.PaidFees = paidFees;
            this.IsActive = isActive;
            this.IssueReason = issueReason;
            this.CreatedByUserID = createdByUserID;

            this._Mode = enMode.Update;
        }

        private bool _AddNewLicense()
        {
            this.LicenseID = clsLicenseData.AddNewLicense(this.ApplicationID.Value, this.DriverID.Value, this.LicenseClass.Value,
                this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees.Value, this.IsActive.Value,
                (byte)this.IssueReason, this.CreatedByUserID.Value);

            return LicenseID.HasValue;
        }

        private bool _UpdateLicense() => 
            clsLicenseData.UpdateLicense(this.LicenseID.Value, this.ApplicationID.Value, this.DriverID.Value, this.LicenseClass.Value,
                this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees.Value, this.IsActive.Value,
                (byte)this.IssueReason, this.CreatedByUserID.Value);

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicense())
                    {
                        this._Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateLicense();

                default:
                    return false;
            }
        }

        public static clsLicense Find(int licenseID)
        {
            int applicationID = 0, driverID = 0, licenseClass = 0, createdByUserID = 0;
            DateTime issueDate = DateTime.Now, expirationDate = DateTime.Now;
            string notes = string.Empty;
            float paidFees = 0;
            bool isActive = false;
            byte issueReason = 2;

            bool isFound = clsLicenseData.GetLicenseInfoByID(licenseID, ref applicationID, ref driverID, ref licenseClass,
                ref issueDate, ref expirationDate, ref notes, ref paidFees, ref isActive, ref issueReason, ref createdByUserID);

            if (isFound)
                return new clsLicense(licenseID, applicationID, driverID, licenseClass, issueDate, expirationDate,
                    notes, paidFees, isActive, (enIssueReason)issueReason, createdByUserID);

            else
                return null;
        }

        public static DataTable GetAllLicenses() => 
            clsLicenseData.GetAllLicenses();

        public static bool IsLicenseExistByPersonID(int personID, int licenseClassID) =>
            clsLicenseData.GetActiveLicenseIDByPersonID(personID, licenseClassID) != null;

        public static int? GetActiveLicenseIDByPersonID(int personID, int licenseClassID) =>
            clsLicenseData.GetActiveLicenseIDByPersonID(personID, licenseClassID);

        public static DataTable GetDriverLicenses(int driverID) =>
            clsLicenseData.GetDriverLicenses(driverID);

        public bool IsLicenseExpired() =>
            (this.ExpirationDate < DateTime.Now);

        public bool DeActiveLicense() => 
            clsLicenseData.DeactivateLicense(this.LicenseID.Value);

        public static string GetIssueReasonText(enIssueReason issueReason)
        {
            switch(issueReason)
            {
                case enIssueReason.FirstTime:
                    return "First Time";

                case enIssueReason.Renew:
                    return "Renew";

                case enIssueReason.LostReplacement:
                    return "Replacement For Lost";

                case enIssueReason.DamagedReplacement:
                    return "Replacement For Damaged";

                default:
                    return "Nothing";
            }
        }






    }
}

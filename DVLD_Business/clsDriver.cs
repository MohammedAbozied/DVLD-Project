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
    public class clsDriver
    {
        private enum enMode { AddNew = 0 , Update = 1 }
        private enMode _Mode;

        public int? DriverID { get; set; }
        public int? PersonID { get; set; }
        public clsPerson PersonInfo { get; set; }
        public int? CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }

        public clsDriver()
        {
            this.DriverID = null;
            this.PersonID = null;
            this.CreatedByUserID = null;
            this.CreatedDate = DateTime.Now;

            this._Mode = enMode.AddNew;
        }

        // call in find method
        private clsDriver(int driverID, int personID, int createdByUserID, DateTime createdDate)
        {
            this.DriverID = driverID;
            this.PersonID = personID;
            this.PersonInfo = clsPerson.Find(personID);
            this.CreatedByUserID = createdByUserID;
            this.CreatedDate = createdDate;

            this._Mode = enMode.Update;
        }

        private bool _AddNewDriver()
        {
            DriverID = clsDriverData.AddNewDriver(this.PersonID.Value,this.CreatedByUserID.Value,this.CreatedDate);

            return DriverID.HasValue;
        }

        private bool _UpdateDriver()
        {
            return clsDriverData.UpdateDriver(this.DriverID.Value,this.PersonID.Value, this.CreatedByUserID.Value);
        }

        public bool Save()
        {
            switch(this._Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDriver())
                    {
                        this._Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateDriver();

                default:
                    return false;
            }
        }

        public static clsDriver FindByDriverID(int driverID)
        {
            int personID = -1 , createdByUserID = -1;
            DateTime createdDate = DateTime.Now;

            if(clsDriverData.GetDriverInfoByDriverID(driverID,ref personID,ref createdByUserID,ref createdDate))
            {
                return new clsDriver(driverID,personID,createdByUserID,createdDate);
            }

            return null;
        }

        public static clsDriver FindByPersonID(int personID)
        {
            int driverID = -1, createdByUserID = -1;
            DateTime createdDate = DateTime.Now;

            if (clsDriverData.GetDriverInfoByPersonID(personID, ref driverID, ref createdByUserID, ref createdDate))
            {
                return new clsDriver(driverID, personID, createdByUserID, createdDate);
            }

            return null;
        }
        public static DataTable GetAllDrivers()
        {
            return clsDriverData.GetAllDrivers();
        }

        public DataTable GetLicenses()
        {
            return clsLicenseData.GetDriverLicenses((int)this.DriverID);
        }

        // after creating clsInternationalLicense
        /*public DataTable GetInternationalLicenses()
        {
            return clsInternationalLicense.GetDriverInternationalLicenses((int)this.DriverID);
        }*/

    }
}

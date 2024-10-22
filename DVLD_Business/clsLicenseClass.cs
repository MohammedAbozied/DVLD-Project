using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsLicenseClass
    {
        public enum enMode { AddNew= 0 , Update = 1 }
        private enMode _Mode;

        public int LicenseClassID { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public byte MinAge { get; set; }
        public byte DefaultValidityLength { get; set; }
        public float ClassFees { get; set; }

        public clsLicenseClass()
        {
            this.LicenseClassID = -1;
            this.ClassName = "";
            this.ClassDescription = "";
            this.MinAge = 18;
            this.DefaultValidityLength = 10;
            this.ClassFees = 0;

            this._Mode = enMode.AddNew;
        }

        public clsLicenseClass(int LicenseClassID, string ClassName, string ClassDescription,
            byte MinAge, byte DefaultValidityLength, float Fees)
        {
            this.LicenseClassID= LicenseClassID;
            this.ClassName= ClassName;
            this.ClassDescription= ClassDescription;
            this.MinAge= MinAge;
            this.DefaultValidityLength= DefaultValidityLength;
            this.ClassFees = Fees;

            this._Mode = enMode.Update;
        }


        private bool _AddNewLicenseClass()
        {
            this.LicenseClassID = clsLicenseClassData.AddNewLicenseClass(this.ClassName, this.ClassDescription,
                this.MinAge, this.DefaultValidityLength, this.ClassFees);

            return LicenseClassID != -1;
        }

        private bool _UpdateLicenseClass()
        {
            return clsLicenseClassData.UpdateLicenseClass(this.LicenseClassID, this.ClassName,
                this.ClassDescription, this.MinAge, this.DefaultValidityLength, this.ClassFees);
        }

        public bool Save()
        {
            switch(this._Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicenseClass())
                    {
                        this._Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateLicenseClass();

                default:
                    return false;
            }
        }

        public static clsLicenseClass FindLicenseClassByID(int LicenseClassID)
        {
            string ClassName = "", ClassDesc = "";
            byte MinAge = 18, DefaultValidityLength = 10;
            float Fees = 0;

            if (clsLicenseClassData.GetLicenseClassInfoByClassID(LicenseClassID, ref ClassName,ref ClassDesc,
                    ref MinAge, ref DefaultValidityLength, ref Fees)) 
             
                return new clsLicenseClass(LicenseClassID, ClassName, ClassDesc, MinAge,
                    DefaultValidityLength, Fees);
            else
                return null;
        }

        public static clsLicenseClass FindLicenseClassByClassName(string ClassName)
        {
            int LicenseClassID = -1;
            string ClassDesc = "";
            byte MinAge = 18, DefaultValidityLength = 10;
            float Fees = 0;

            if (clsLicenseClassData.GetLicenseClassInfoByClassName(ClassName,ref LicenseClassID, ref ClassDesc,
                    ref MinAge, ref DefaultValidityLength, ref Fees))
             
                return new clsLicenseClass(LicenseClassID, ClassName, ClassDesc, MinAge,
                    DefaultValidityLength, Fees);
            else
                return null;
        }

        public static DataTable GetAllLicenseClasses()
        {
            return clsLicenseClassData.GetAllLicenseClasses();
        }


    }
}

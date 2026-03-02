using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsTestAppointment
    {
        public enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode;

        public int TestAppointmentID { get; set; }
        public int TestTypeID { get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public float PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }
        public int? RetakeTestApplicationID { get; set; }

        public int? TestID 
        {
            get 
            { 
                return _GetTestID(); 
            }
        }
        public clsTestAppointment()
        {
            this.TestAppointmentID = -1;
            this.TestTypeID = -1;
            this.LocalDrivingLicenseApplicationID = -1;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = -1;
            this.CreatedByUserID = -1;
            this.IsLocked = false;
            this.RetakeTestApplicationID = -1;

            this._Mode = enMode.AddNew;
        }
        public clsTestAppointment(int testAppointmentID,int testTypeID,int ldlAppID,
            DateTime appointmentDate,float paidFees,int createdByUserID,bool isLocked,
            int? retakeTestApplicationID)
        {
            this.TestAppointmentID = testAppointmentID;
            this.TestTypeID = testTypeID;
            this.LocalDrivingLicenseApplicationID = ldlAppID;
            this.AppointmentDate = appointmentDate;
            this.PaidFees = paidFees;
            this.CreatedByUserID = createdByUserID;
            this.IsLocked = isLocked;
            this.RetakeTestApplicationID = retakeTestApplicationID;

            this._Mode = enMode.Update;
        }

        private bool _AddNewTestAppointment()
        {
            this.TestAppointmentID = clsTestAppointmentData.AddNewTestAppointment
                (this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.AppointmentDate,
                this.PaidFees, this.CreatedByUserID, this.RetakeTestApplicationID);

            return this.TestAppointmentID != -1;

        }

        private bool _UpdateTestAppointment()
        {
            return clsTestAppointmentData.UpdateTestAppointment(this.TestAppointmentID,
                this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.AppointmentDate,
                this.PaidFees, this.CreatedByUserID, this.IsLocked,this.RetakeTestApplicationID);
        }

        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                    if(_AddNewTestAppointment())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateTestAppointment();

                default:
                    return false;
            }
        }

        public static clsTestAppointment Find(int testAppointmentID)
        {
            int testTypeID = -1, ldlAppID = -1, createdByUserID = -1;
            DateTime appointmentDate = DateTime.Now;
            float paidFees = 0;
            bool isLocked = false;
            int? retakeTestApplicationID = null;

            return clsTestAppointmentData.GetTestAppointmentInfoByID(testAppointmentID, ref testTypeID,
                ref ldlAppID, ref appointmentDate, ref paidFees, ref createdByUserID, ref isLocked,
                ref retakeTestApplicationID) ? new clsTestAppointment() : null;

        }

        public static clsTestAppointment GetLastTestAppointment(int LDLApplicationID, clsTestType.enTestType testTypeID)
        {
            int testAppointmentID = -1, createdByUserID = -1;

            int? retakeTestApplicationID = null;
            DateTime appointmentDate = DateTime.Now;
            float paidFees = 0;
            bool isLocked = false;

            return clsTestAppointmentData.GetLastTestAppointment(LDLApplicationID, ref testAppointmentID, (int)testTypeID,
                    ref appointmentDate, ref paidFees, ref createdByUserID, ref isLocked, ref retakeTestApplicationID) ?
                new clsTestAppointment(testAppointmentID, (int)testTypeID, LDLApplicationID, appointmentDate, paidFees,
                    createdByUserID, isLocked, retakeTestApplicationID.Value) : null;
        }

        public static DataTable GetAllTestAppointments()
        {
            return clsTestAppointmentData.GetAllTestAppointments();
        }
        public DataTable GetApplicationTestAppointmentsPerTestType(clsTestType.enTestType testType)
        {
            return clsTestAppointmentData.GetApplicationTestAppointmentsPerTestType(this.LocalDrivingLicenseApplicationID, (int)testType);
        }
        public DataTable GetApplicationTestAppointmentsPerTestType(int ldlApplicationID,clsTestType.enTestType testType)
        {
            return clsTestAppointmentData.GetApplicationTestAppointmentsPerTestType(ldlApplicationID, (int)testType);
        }

        private int? _GetTestID()
        {
            return clsTestAppointmentData.GetTestID(this.TestAppointmentID);
        }

        

    }
}

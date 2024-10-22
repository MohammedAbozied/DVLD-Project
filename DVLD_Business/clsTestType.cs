using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;
namespace DVLD_Business
{
    public class clsTestType
    {
        private enum enMode { AddNew = 0 , Update = 1 }
        private enMode _Mode = enMode.AddNew;

        public enum enTestType { VisionTest= 1, WrittenTest = 2, PracticalTest = 3 };

        public enTestType ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public float Fees { get; set; }


        public clsTestType()
        {
            this.ID = enTestType.VisionTest;
            this.Title = "";
            this.Description = "";
            this.Fees = 0;

            this._Mode = enMode.AddNew;
        }

        public clsTestType(enTestType iD, string title, string description, float fees)
        {
            this.ID = iD;
            this.Title = title;
            this.Description = description;
            this.Fees = fees;

            this._Mode = enMode.Update;
        }

        private bool _AddNewTestType()
        {
            this.ID = (enTestType)clsTestTypeData.AddNewTestType(this.Title, this.Description,
                this.Fees);
            
            return (this.Title !="");
        }
        private bool _UpdateTestType()
        {
            return clsTestTypeData.UpdateTestType((int)this.ID, this.Title,
                this.Description, this.Fees);
                
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if(_AddNewTestType())
                        return true;
                    else
                        return false;

                case enMode.Update:
                    return _UpdateTestType();
            }

            return false;
        }


        public static clsTestType Find(enTestType id)
        {
            string title = "", description = "";
            float fees = 0;

            if( clsTestTypeData.GetTestTypeInfo((int)id, ref title, ref description, ref fees))
                return new clsTestType(id, title, description, fees);

            return null;
        }


        public static DataTable GetAllTestTypes()
        {
            return clsTestTypeData.GetAllTestTypes();
        }



    }
}

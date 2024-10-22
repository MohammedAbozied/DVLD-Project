using static DVLD_DataAccess.clsApplicationTypeData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Data;
using DVLD_DataAccess;


namespace DVLD_Business
{
    public class clsApplicationType
    {
        private enum eMode { AddNew = 0, Update = 1};
        private eMode _Mode = eMode.AddNew;

        public int ID { get; set; }
        public string Title { get; set; }
        public float Fees { get; set; } 
        
        public clsApplicationType()
        {
            ID = -1;
            Title = "";
            Fees = 0;
            _Mode = eMode.AddNew;
        }

        public clsApplicationType(int id, string title, float fees)
        {
            this.ID = id;
            this.Title = title;
            this.Fees = fees;
            _Mode = eMode.Update;
        }

        private bool _Update()
        {
            return UpdateApplicationType(ID, Title, Fees);
        }

        private bool _AddNew()
        {
            ID =  AddNewApplicationType(Title, Fees);
            return ID != -1;
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case eMode.AddNew:
                    if(_AddNew())
                    {
                        _Mode = eMode.Update;
                        return true;
                    }
                    else
                        return false;

                case eMode.Update:
                    return _Update();
            }

            return false;
        }


        public static clsApplicationType Find(int id)
        {
            string title = "";
            float fees = 0;

            if(GetApplicationTypeInfoById(id,ref title,ref fees))
                return new clsApplicationType(id, title, fees);
            else
                return null;
        }

        public static DataTable GetAllTypes()
        {
            return GetAllApplicationTypes();
        }

        



    }

}

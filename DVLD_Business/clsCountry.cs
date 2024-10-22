using System;
using System.Data;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsCountry
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }

        clsCountry(int CountryID, string CountryName)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;
        }

        public static clsCountry Find(int CountryID)
        {
            string CountryName = "";
            bool is_found = clsCountryData.GetCountryByID(CountryID, ref CountryName);

            if (is_found)
                return new clsCountry(CountryID, CountryName);

            else
                return null;

        }

        public static clsCountry Find(string CountryName)
        {
            int CountryID = -1;
            bool is_found = clsCountryData.GetCountryByCountryName(CountryName, ref CountryID);

            if (is_found)
                return new clsCountry(CountryID, CountryName);
            else
                return null;
        }

        public static DataTable GetAllCountries()
        {
            return clsCountryData.GetAllCountries();
        }




    }



}

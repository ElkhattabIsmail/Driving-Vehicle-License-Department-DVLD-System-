using System;
using System.Data;
using DVLD_DataAccess;

namespace DVLD_BuisnessLayer
{
    public class clsCountry
    {

        public int ID { set; get; }
        public string CountryName { set; get; }
   
        public clsCountry()

        {
            this.ID = -1;
            this.CountryName = "";

        }

        private clsCountry(int ID, string CountryName)

        {
            this.ID = ID;
            this.CountryName = CountryName;
        }

        public static clsCountry FindUserPersonID(int ID)
        {
            string CountryName = "";

            if (clsCountryData.GetCountryInfoByID(ID, ref CountryName))

                return new clsCountry(ID, CountryName);
            else
                return null;

        }

        public static clsCountry FindUserPersonID(string CountryName)
        {

            int ID = -1;
           
            if (clsCountryData.GetCountryInfoByName(CountryName, ref ID ))

                return new clsCountry(ID, CountryName);
            else
                return null;

        }

        public static DataTable GetAllCountries()
        {
            return clsCountryData.GetAllCountries();

        }

    }
}

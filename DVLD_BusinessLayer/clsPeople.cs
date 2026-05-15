using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DVLD_BusinessLayer
{
    public class clsPeople

    {
        enum enMode { AddMode =1 , UpdateMode =2 };
        enMode Mode = enMode.AddMode;
        public int _PersonID;
        public string FirstName {  get; set; }  = string.Empty;
        public string NationalNo { get; set; } = string.Empty;
        public string SecondName { get; set; } = string.Empty;
        public string ThirdName {  get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; } = DateTime.MinValue;
        public char Gendre { get; set; } = '\0';
        public string Address {  get; set; } = string.Empty;
        public string Email {  get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty ;
        public int NationalCountryID { get; set; } = -1;
        public string ImagePath { get; set; } = string.Empty;
        public int PersonID
        { get { return _PersonID; } }

        public string Full_Name { get { return (FirstName + " " + SecondName + " " + LastName); } }


        public clsPeople()
        {
            _PersonID = -1;
            NationalNo = string.Empty;
            FirstName = string.Empty;
            SecondName = string.Empty;
            ThirdName = string.Empty;
            LastName = string.Empty;
            DateOfBirth = DateTime.MinValue;
            Phone = string.Empty;
            Email = string.Empty;
            Address = string.Empty;
            NationalCountryID = -1;
            ImagePath = string.Empty;
            Gendre = '\0';
            Mode = enMode.AddMode;
        }

      public   clsPeople ( int personID ,string NationalNo, string firstName, string secondName, string thirdName, string lastName,
            DateTime dateOfBirth, char gendre, string address, string email, string phone, int nationalCountryID, string imagePath )
        {
            Mode = enMode.UpdateMode;
            this._PersonID = personID;
            this.NationalNo = NationalNo;
           this.FirstName = firstName;
           this.SecondName = secondName;
           this.ThirdName = thirdName;
           this.LastName = lastName;
           this.DateOfBirth = dateOfBirth;
           this.Gendre = gendre;
           this.Address = address;
           this.Email = email;
           this.Phone = phone;
           this.NationalCountryID = nationalCountryID;
           this.ImagePath = imagePath;
        }

        static public clsPeople FindPerson(int PersonID)
        {
            string NationalNo = string.Empty;
            string FirstName = string.Empty;
            string SecondName = string.Empty;
            string ThirdName = string.Empty;
            string LastName = string.Empty;
            string Email = string.Empty;
            string Address = string.Empty;
            string Phone = string.Empty;
            DateTime DateOfBirth = DateTime.MinValue;
            char Gendre = '\0';
            int nationalCountryID = -1;
            string imagePath = string.Empty;
            if(clsPeopleDataAccessLayer.FindPerson(PersonID, ref NationalNo,ref FirstName,ref SecondName,ref ThirdName,ref LastName,ref DateOfBirth,
                ref Gendre,ref Address ,ref Phone,ref Email,ref nationalCountryID,ref imagePath))
            {
                return new clsPeople(PersonID,NationalNo,FirstName,SecondName,ThirdName,LastName,DateOfBirth,
                    Gendre,Address,Email,Phone,nationalCountryID,imagePath);
            }
            else
                return new clsPeople();
                
        }

        static public clsPeople FindPerson(string NationalNo)
        {
          int PersonID = -1;
            string FirstName = string.Empty;
            string SecondName = string.Empty;
            string ThirdName = string.Empty;
            string LastName = string.Empty;
            string Email = string.Empty;
            string Address = string.Empty;
            string Phone = string.Empty;
            DateTime DateOfBirth = DateTime.MinValue;
            char Gendre = '\0';
            int nationalCountryID = -1;
            string imagePath = string.Empty;
            if (clsPeopleDataAccessLayer.FindPerson(NationalNo, ref PersonID,  ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth,
                ref Gendre, ref Address, ref Phone, ref Email, ref nationalCountryID, ref imagePath))
            {
                return new clsPeople(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth,
                    Gendre, Address, Email, Phone, nationalCountryID, imagePath);
            }
            else
                return new clsPeople();

        }
        public bool Add()
        {
            int PersonID = -1;

            if(clsPeopleDataAccessLayer.DoesNationalNoExist(NationalNo)&&clsUtil.IsValidEmail(Email)
                && clsUtil.IsPersonAgeGreaterThanSpecificAge(DateOfBirth,18))
            {
                PersonID = clsPeopleDataAccessLayer.AddPerson(NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendre,
              Address, Phone, Email, NationalCountryID, ImagePath);
            }
            if (PersonID == -1)
                return false;
            else
            {
                _PersonID=PersonID;
                return true;
            }       
        }

        public bool Update()
        {
            return clsPeopleDataAccessLayer.UpdatePerson(NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendre
                , Address, Phone, Email, NationalCountryID, ImagePath);
        }
        static public DataTable GetAllPpl()
        {
          
            return clsPeopleDataAccessLayer.GetAllPeople();
        }
        static public DataTable GetAllCountries  ()
        {
            return clsPeopleDataAccessLayer.GetAllCountries();
        }
        static public DataTable FilterPeopleByPersonID(int PersonID)
        {
            return clsPeopleDataAccessLayer.FilterPeopleByPersonID(PersonID);
        }
        static public DataTable FilterPeopleByNationalNo(string NationalNo)
        {
            return clsPeopleDataAccessLayer.FilterPeopleUsingNationalNo(NationalNo);
        }
        static public DataTable FilterPeopleByFirstName(string FirstName)
        {
            return clsPeopleDataAccessLayer.FilterPeopleUsingFirstName(FirstName);
        }
        static public DataTable FilterPeopleBySecondName(string SecondName)
        {
            return clsPeopleDataAccessLayer.FilterPeopleUsingSecondName(SecondName);
        }
        static public DataTable FilterPeopleByThirdName(string ThirdName)
        {
            return clsPeopleDataAccessLayer.FilterPeopleUsingThirdName(ThirdName);
        }
        static public DataTable FilterPeopleByLastName(string LastName)
        {
            return clsPeopleDataAccessLayer.FilterPeopleUsingLastName(LastName);
        }

        static public DataTable FilterPeopleByNaitonality(string Nationality)
        {
            return clsPeopleDataAccessLayer.FilterPeopleUsingNationality(Nationality);
        }

        static public string GetCountryNameByID(int CountryID)
        {
            return clsPeopleDataAccessLayer.GetCountryName(CountryID);
        }
        static public DataTable FilterPeopleByGendre(char Gendre)
        {
            return clsPeopleDataAccessLayer.FilterPeopleUsingGendre(Gendre);
        }
        static public DataTable FilterPeopleByPhone(string Phone)
        {
            return clsPeopleDataAccessLayer.FilterPeopleUsingPhone(Phone);
        }
        static public DataTable FilterPeopleByEmail(string Email)
        {
            return clsPeopleDataAccessLayer.FilterPeopleUsingEmail(Email);
        }
        static public bool DeoesNationalNoExist(string NationalNo)
        {
            return clsPeopleDataAccessLayer.DoesNationalNoExist(NationalNo);
        }

        static public bool DeoesPersonExist(int PersonID)
        {
            return clsPeopleDataAccessLayer.DoesPersonExist(PersonID);
        }

        static public bool DeletePerson(int PersonID)
        {
            return clsPeopleDataAccessLayer.DeletePerson(PersonID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddMode:
                    {
                        if (Add())
                        {
                            Mode = enMode.UpdateMode;
                            return true;
                        }
                        else
                            return false;
                    }
                    case enMode.UpdateMode:
                    {
                        if(Update())
                        {
                            return true;
                        }
                        return false;
                    }
            }
            return false;

        }
    }
}

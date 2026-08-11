using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsDrivers
    {
        private int _DriverID;
        public int DriverID { get { return _DriverID; } }
        public int PersonID { set; get; } 
        public int CreatedByUserID { set; get; }
        public DateTime CreationDate { set; get; }
        public clsPeople Person {  set; get; }

        public clsDrivers()
        {
            _DriverID = -1;
            PersonID = -1;
            CreatedByUserID = -1;
            CreationDate = new DateTime();
            Person = new clsPeople();
        }

        public clsDrivers (int driverID, int personID, int createdByUserID, DateTime creationDate)
        {
            _DriverID = driverID;
            PersonID = personID;
            CreatedByUserID = createdByUserID;
            CreationDate = creationDate;
            Person = clsPeople.FindPerson(PersonID);
        }

        public bool Add()
        {
          

           this._DriverID = clsDriversDataAccess.AddNewDriver( PersonID, CreatedByUserID,CreationDate);
            if( DriverID != -1 ) 
                return true;
            else
                return false;

        }

       static public clsDrivers FindByDriverID(int DriverID)
        {
            int PersonID = -1;
            int CreatedByUserID = -1;
            DateTime CreationDate = new DateTime();

            if (clsDriversDataAccess.FindByDriverID(DriverID, ref PersonID, ref CreatedByUserID, ref CreationDate))
                return new clsDrivers(DriverID, PersonID, CreatedByUserID, CreationDate);
            else
                return null;
        }
        static public clsDrivers FindByNationalNo(string NationalNo)
        {
            int DriverID = -1;
            int PersonID = -1;
            int CreatedByUserID = -1;
            DateTime CreationDate = new DateTime();

            if (clsDriversDataAccess.FindByNationalNo(NationalNo,ref DriverID, ref PersonID, ref CreatedByUserID, ref CreationDate))
                return new clsDrivers(DriverID, PersonID, CreatedByUserID, CreationDate);
            else
                return null;
        }

        static  public clsDrivers FindByPersonID(int PersonID)
        {
            int DriverID = -1;
            int CreatedByUserID = -1;
            DateTime CreationDate = new DateTime();

            if (clsDriversDataAccess.FindByPersonID(PersonID, ref DriverID, ref CreatedByUserID, ref CreationDate))
                return new clsDrivers(DriverID, PersonID, CreatedByUserID, CreationDate);
            else
                return null;
        }
        static public bool Delete(int DriverID)
        {
            return clsDriversDataAccess.Delete(DriverID);
        }
        static public DataTable GetAllDrivers()
        {
            return clsDriversDataAccess.GetAllDrivers();
        }
        static public DataTable FilterByDriverID(int DriverID)
        {
            return clsDriversDataAccess.FilterByDriverID(DriverID);
        }
        static public DataTable FilterByPersonID(int PersonID)
        {
            return clsDriversDataAccess.FilterByPersonID(PersonID);
        }
        static public DataTable FilterByNationalNo(string NationalNo)
        {
            return clsDriversDataAccess.FilterByNationalNo(NationalNo);
        }
        static public DataTable FilterByFullName(string FullName)
        {
            return clsDriversDataAccess.FilterByFullName(FullName);
        }
        static public bool DoesDriverExist(int PersonID)
        {
            return clsDriversDataAccess.DoesDriverExist(PersonID);
        }
        static public bool DoesDriverExist(string NationalNo)
        {
            return clsDriversDataAccess.DoesDriverExist(NationalNo);
        }
        public DataTable GetAllLocalDrivingLicensesForDriver()
        {
            return clsDriversDataAccess.GetAllLocalDrivingLicensesForDriver(this.DriverID);
        }
        public DataTable GetAllInternationalDrivingLicensesForDriver()
        {
            return clsDriversDataAccess.GetAllInternationalDrivingLicensesForDriver(this.DriverID);
        }


    }
}

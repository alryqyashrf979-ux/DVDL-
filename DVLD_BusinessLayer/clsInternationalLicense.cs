using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsInternationalLicense
    {
        enum enMode { Add = 0, Update = 1 }
        enMode Mode { get; set; } = enMode.Add;
        private int _InternationalLicenseID;
        public int InternationalLicenseID
        { get { return _InternationalLicenseID;
            } }
        public int ApplicationID { set; get; }
        public clsApplications Application { set; get; }
        public int DriverID { set; get; }

        public clsDrivers Driver { set; get; }

        public int LocalDrivingLicenseID { set; get; }
        public clsLicense License { set; get; }

        public DateTime IssueDate { set; get; }

        public DateTime ExpirationDate { set; get; }

        public bool IsActive { set; get; }

        public int createdByUserID { set; get; }

        public clsInternationalLicense()
        {
            _InternationalLicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            LocalDrivingLicenseID = -1;
            LocalDrivingLicenseID = -1;
            License = new clsLicense();
            Driver = new clsDrivers();
            Application = new clsApplications();
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.MaxValue;
            IsActive = true;
            createdByUserID = -1;
            Mode = enMode.Add;
        }
        public clsInternationalLicense(int InternationalLicenseID, int applicationID, int driverID, int localDrivingLicenseID, int CreatedByUserID
            , DateTime issueDate, DateTime expirationDate, bool isActive)
        {
            _InternationalLicenseID = InternationalLicenseID;
            ApplicationID = applicationID;
            DriverID = driverID;
            LocalDrivingLicenseID = localDrivingLicenseID;
            License = clsLicense.FindByLicenseID(LocalDrivingLicenseID);
            Driver = clsDrivers.FindByDriverID(DriverID);
            Application = clsApplications.Find(ApplicationID);
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            IsActive = isActive;
            createdByUserID = CreatedByUserID;
            Mode = enMode.Update;
        }

        static public clsInternationalLicense FindByInternationalLicenseID(int InternationalLicenseID)
        {
            int applicationID = -1; int DriverID = -1; int LocalDrivingLicenseID = -1; DateTime IssueDate = DateTime.MinValue;
            DateTime expirationDate = DateTime.MinValue; bool isActive = false; int createdByUserID = -1;
            if (clsInternationalLicenseDataAccess.FindByInternationalLicenseID(InternationalLicenseID, ref DriverID, ref applicationID, ref LocalDrivingLicenseID, ref IssueDate,
               ref expirationDate, ref isActive, ref createdByUserID))
                return new clsInternationalLicense(InternationalLicenseID, applicationID, DriverID, LocalDrivingLicenseID, createdByUserID, IssueDate
                    , expirationDate, isActive);
            else
                return null;
        }
        static public clsInternationalLicense FindByInternationalApplicationID(int ApplicationID)
        {
            int InternationalLicenseID = -1; ; int DriverID = -1; int LocalDrivingLicenseID = -1; DateTime IssueDate = DateTime.MinValue;
            DateTime expirationDate = DateTime.MinValue; bool isActive = false; int createdByUserID = -1;
            if (clsInternationalLicenseDataAccess.FindByApplicationID(ApplicationID, ref DriverID, ref InternationalLicenseID, ref LocalDrivingLicenseID, ref IssueDate,
               ref expirationDate, ref isActive, ref createdByUserID))
                return new clsInternationalLicense(InternationalLicenseID, ApplicationID, DriverID, LocalDrivingLicenseID, createdByUserID, IssueDate
                    , expirationDate, isActive);
            else
                return null;
        }

        static public clsInternationalLicense FindByDriverID(int DriverID)
        {
            int applicationID = -1; int InternationalLicenseID = -1; int LocalDrivingLicenseID = -1; DateTime IssueDate = DateTime.MinValue;
            DateTime expirationDate = DateTime.MinValue; bool isActive = false; int createdByUserID = -1;
            if (clsInternationalLicenseDataAccess.FindByDriverID(DriverID, ref InternationalLicenseID, ref applicationID, ref LocalDrivingLicenseID, ref IssueDate,
               ref expirationDate, ref isActive, ref createdByUserID))
                return new clsInternationalLicense(InternationalLicenseID, applicationID, DriverID, LocalDrivingLicenseID, createdByUserID, IssueDate
                    , expirationDate, isActive);
            else
                return null;
        }
        static public clsInternationalLicense FindByLocalLicenseID(int localLicenseID)
        {
            int ApplicationID = -1; int DriverID = -1; int InternationalLicenseID = -1; DateTime IssueDate = DateTime.MinValue;
            DateTime expirationDate = DateTime.MinValue; bool isActive = false; int createdByUserID = -1;
            if (clsInternationalLicenseDataAccess.FindByLocalDrivinglLicenseID(localLicenseID, ref InternationalLicenseID, ref DriverID, ref ApplicationID, ref IssueDate,
               ref expirationDate, ref isActive, ref createdByUserID))
                return new clsInternationalLicense(InternationalLicenseID, ApplicationID, DriverID, localLicenseID, createdByUserID, IssueDate
                    , expirationDate, isActive);
            else
                return null;
        }
        private bool _Add()
        {
            int InternationalLicenseID = clsInternationalLicenseDataAccess.Add(this.DriverID, this.ApplicationID, this.LocalDrivingLicenseID, this.IssueDate
                , this.ExpirationDate, this.IsActive, this.createdByUserID);
            if (InternationalLicenseID != -1)
            {
                this._InternationalLicenseID = InternationalLicenseID;
                return true;
            }
            return false;

        }
        private bool _Update()
        {
            return clsInternationalLicenseDataAccess.Update(this.InternationalLicenseID, this.DriverID, this.ApplicationID, this.LocalDrivingLicenseID, this.IssueDate
                , this.ExpirationDate, this.IsActive, this.createdByUserID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:
                    {
                        if (_Add())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        break;
                    }
                case enMode.Update:
                    {
                        if (_Update())
                            return true;
                    }
                    break;
                default:
                    {
                        return false;
                    }
            }
            return false;
        }

        static public bool Delete(int InternationalLicenseID)
        {
            return clsInternationalLicenseDataAccess.Delete(InternationalLicenseID);
        }

        static public DataTable GetAllInternationalLicenses()
        {
            return clsInternationalLicenseDataAccess.GetAllInternationalLicenses();
        }

        static public bool DoesInternationalLicenseExistByDriverID(int DriverID)
        {
            return clsInternationalLicenseDataAccess.DoesInternationalLicenseExistByDriverID(DriverID);
        }

        static public bool DoesInternationalLicenseExistByApplicationID(int ApplicationID)
        {
            return clsInternationalLicenseDataAccess.DoesInternationalLicenseExistByApplicationID(ApplicationID);
        }

        static public bool DoesInternationalLicenseExistByID(int InternationalLicenseID)
        {
            return clsInternationalLicenseDataAccess.DoesInternationalLicenseExistByID(InternationalLicenseID);
        }
        public bool Deactivate()
        {
            this.IsActive = false;
            return clsInternationalLicenseDataAccess.Deactivate(this.InternationalLicenseID);
        }

        static public DataTable FilterbyInternationalLicenseID(int InternationalLicenseID)
        {
            return clsInternationalLicenseDataAccess.FilterbyInternationalLicenseID(InternationalLicenseID);
        }
        static public DataTable FilterbyApplicationID(int ApplicationID)
        {
            return clsInternationalLicenseDataAccess.FilterbyApplicationID(ApplicationID);
        }
        static public DataTable FilterbyDriverID(int DriverID)
        {
            return clsInternationalLicenseDataAccess.FilterbyDriverID(DriverID);
        }
        static public DataTable FilterbyLocalDrivingLicenseID(int LicenseID)
        {
            return clsInternationalLicenseDataAccess.FilterbyLocalDrivingLicenseID(LicenseID);
        }
         public bool IsLicenseExpired()
        {
            return this.ExpirationDate < DateTime.Now;
        }
        static public DataTable FilterbyActivation(bool IsActive)
        {
            return clsInternationalLicenseDataAccess.FilterbyActivation(IsActive);
        }
    }
}

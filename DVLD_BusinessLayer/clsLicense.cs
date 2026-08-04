using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static DVLD_BusinessLayer.clsApplications;

namespace DVLD_BusinessLayer
{
    public class clsLicense
    {
    //IssueReasonText


        enum enMode { Add =1 , Update =2};
        enMode Mode = enMode.Add;
        private int _LicenseID;
        public int LicenseID
        { get { return _LicenseID; } }
        public int ApplicationID { set; get; }
        public clsApplications Application { set; get; }
        public int DriverID { set; get; }
        public clsDrivers Driver {  set; get; }
        public int LicenseClassID { set; get; }
        public clsLicenseClass LicenseClass { set; get; }
        public DateTime IssueDate { set; get; }
        public DateTime ExpirationDate { set; get; }
        public string Note { set; get; }
        public decimal PaidFees { set; get; }
        public bool IsActive { set; get; }
        public enum enIssueReason { FirstTime =1 , Renew =2 , ReplacementForDamage = 3 , ReplacementForLost = 4 };
        public enIssueReason IssueReason { set; get; } 
        public int CreatedByUserID { set; get; }

        public clsDetainReleaseLicenses DetainLicenseInfo { set; get; } = new clsDetainReleaseLicenses();

        public string IssueReasonText
        {
            get
            {
                switch (IssueReason)
                {
                    case enIssueReason.FirstTime:
                        return "First Time";
                    case enIssueReason.ReplacementForDamage:
                        return "Replacement For Damage";
                    case enIssueReason.ReplacementForLost:
                        return "Replacement For Loss";
                    case enIssueReason.Renew:
                        return "Renew";
                    default:
                        return "";

                }
            }
        }
        public clsLicense()
        {
            _LicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            LicenseClassID = -1;
            IssueDate = new DateTime();
            ExpirationDate = new DateTime();
            Note = string.Empty;
            PaidFees = default(decimal);
            IsActive = false;
            IssueReason = enIssueReason.FirstTime;
            CreatedByUserID = -1;
            Mode = enMode.Add;

        }

        public clsLicense( int licenseID, int applicationID, int driverID, int licenseClassID, DateTime issueDate,
            DateTime expirationDate, string note, decimal paidFees, bool isActive, enIssueReason issueReason, int createdByUserID)
        {
            Mode = enMode.Update;
            _LicenseID = licenseID;
            ApplicationID = applicationID;
            Application = clsApplications.Find(ApplicationID);
            DriverID = driverID;
            Driver = clsDrivers.FindByDriverID(DriverID);
            LicenseClassID = licenseClassID;
            LicenseClass  = clsLicenseClass.Find(LicenseClassID);
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            Note = note;
            PaidFees = paidFees;
            IsActive = isActive;
            IssueReason = issueReason;
            CreatedByUserID = createdByUserID;

            DetainLicenseInfo = clsDetainReleaseLicenses.FindByLicenseID(this.LicenseID);
        }

        static public clsLicense FindByLicenseID(int licenseID)
        {
            int ApplicationID = -1; int DriverID = -1; int LicenseClassID = -1; DateTime IssueDate = new DateTime();
            DateTime ExpirationDate = new DateTime(); string Note = string.Empty; decimal PaidFees = default(decimal); bool IsActive = false;
            byte issueReason = (byte)enIssueReason.FirstTime;
            int CreatedByUserID = -1;

            if (clsLicenseDataAccess.FindbyLicenseID(licenseID, ref ApplicationID, ref DriverID, ref LicenseClassID, ref IssueDate, ref ExpirationDate,
                ref Note, ref PaidFees, ref IsActive, ref issueReason, ref CreatedByUserID))
                return new clsLicense(licenseID, ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate, Note, PaidFees,
                    IsActive, (enIssueReason)issueReason, CreatedByUserID);

            return null;
        }
        static public clsLicense FindByApplicationID(int ApplicationID)
        {
            int LicenseID = -1; int DriverID = -1; int LicenseClassID = -1; DateTime IssueDate = new DateTime();
            DateTime ExpirationDate = new DateTime(); string Note = string.Empty; decimal PaidFees = default(decimal); bool IsActive = false;
            byte issueReason = (byte)enIssueReason.FirstTime;
            int CreatedByUserID = -1;

            if (clsLicenseDataAccess.FindbyAplicationID(ApplicationID , ref LicenseID, ref DriverID, ref LicenseClassID, ref IssueDate, ref ExpirationDate,
                ref Note, ref PaidFees, ref IsActive, ref issueReason, ref CreatedByUserID))
                return new clsLicense( LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate, Note, PaidFees,
                    IsActive, (enIssueReason)issueReason, CreatedByUserID);
            return null;
        }
        static public clsLicense FindByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID)
        {
            int ApplicationID = -1;  int LicenseID = -1; int DriverID = -1; int LicenseClassID = -1; DateTime IssueDate = new DateTime();
            DateTime ExpirationDate = new DateTime(); string Note = string.Empty; decimal PaidFees = default(decimal); bool IsActive = false;
            byte issueReason = (byte)enIssueReason.FirstTime;
            int CreatedByUserID = -1;

            if (clsLicenseDataAccess.FindbyLocalDrivingLicenseAppIDID(LocalDrivingLicenseApplicationID,ref LicenseID , ref ApplicationID, ref DriverID, ref LicenseClassID, ref IssueDate, ref ExpirationDate,
                ref Note, ref PaidFees, ref IsActive, ref issueReason, ref CreatedByUserID))
                return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate, Note, PaidFees,
                    IsActive, (enIssueReason)issueReason, CreatedByUserID);
            return null;
        }

        private bool _Add()
        {
            this._LicenseID = clsLicenseDataAccess.Add(this.ApplicationID, this.DriverID, this.LicenseClassID, this.IssueDate, this.ExpirationDate, this.Note,
                this.PaidFees, this.IsActive, (byte)this.IssueReason, this.CreatedByUserID);
            return this._LicenseID != -1;
        }
        private bool _Update()
        {
            return clsLicenseDataAccess.Update(this._LicenseID, this.ApplicationID, this.DriverID, this.LicenseClassID, this.IssueDate
                , this.ExpirationDate, this.Note, this.PaidFees, this.IsActive, (byte)this.IssueReason, this.CreatedByUserID);
        }

        public bool Save()
        {
            switch(Mode)
            {
                case enMode.Add:
                    {
                        if(_Add())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        break;
                    }
                case enMode.Update:
                    {
                        if(_Update())
                        {
                            return true ;
                        }
                        break;
                    }
                default:
                    return false;
            }
            return false;
        }

        static public bool IsLicenseActive(int LicenseID)
        {
            return clsLicenseDataAccess.IsLicenseActive(LicenseID);
        }
       
        public bool Deactivate()
        {
            if(clsLicenseDataAccess.DeactivateLicense(this.LicenseID))
            {
                this.IsActive = false;
                return true;
            }
            return false;
        }
      
        static public DataTable GetAllLicensesByLicenseClass(int LicenseClassID)
        {
            return clsLicenseDataAccess.GetAllLicensesByLicenseClass(LicenseClassID);
        }
        static public  DataTable GetAllLicensesByIssueReason(enIssueReason issueReason)
        {
            return clsLicenseDataAccess.GetAllLicensesByIssueReason((byte)issueReason);
        }
        static public  bool DoesLicenesExistByApplicationID(int ApplicationID)
        {
           
            return clsLicenseDataAccess.DoesLicenesExistByApplicationID(ApplicationID);
        }
        static bool DoesLicenesExistByLicenseID(int LicenseID)
        {
            return clsLicenseDataAccess.DoesLicenesExistByLicenseID(LicenseID);
        }
       static public int  GetActiveLicenseIDByPersonID(int PersonID , int LicenseClassID)
        {
            return clsLicenseDataAccess.GetActiveLicenseIDByPersonID(PersonID , LicenseClassID);
        }
        public bool IsLicenseExpired()
        {
            // compare datenow to expiration date 
            // if DateTime Now is greater then the license is already expired 
           
            return DateTime.Compare(DateTime.Now, this.ExpirationDate) > 0;
        }

        public clsLicense RenewLicense(string Note , int CurrentUserID)
        {
            clsApplications NewApp = new clsApplications();
            NewApp._ApplicantPersonID = this.Application._ApplicantPersonID;
            NewApp.ApplicationDate = DateTime.Now;
            // 2 refers to Application type ID of Renew Driving license 
            NewApp.ApplicationTypeID = 2;
            NewApp.Status = clsApplications.enApplicationStatus.completed;
            NewApp.LastStatusDate = DateTime.Now;
            NewApp.PaidFees = clsApplicationTypes.GetTypeOfApplication(2).ApplicationTypeFee;
            NewApp.CreatedByUserID = CurrentUserID;
            if (!NewApp.Save()) return null;
            clsLicense NewLicense = new clsLicense();
            NewLicense.ApplicationID =NewApp.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClassID = this.LicenseClassID;
            NewLicense.IssueDate = DateTime.Now;
            NewLicense.ExpirationDate = DateTime.Now.AddYears(this.LicenseClass.DefaultValidityLength);
            NewLicense.Note = Note.Trim();
            NewLicense.PaidFees = this.PaidFees;
            NewLicense.IsActive = true;
            NewLicense.IssueReason = enIssueReason.Renew;
            NewLicense.CreatedByUserID = CurrentUserID;
            if (!NewLicense.Save()) return null;
            Deactivate();
            return NewLicense;
        }

        public clsLicense ReplaceLicense(int ReplacementReason , int CurrentUserID)
        {
            clsApplications NewApp = new clsApplications();
            NewApp._ApplicantPersonID = this.Application._ApplicantPersonID;
            NewApp.ApplicationDate = DateTime.Now;
            NewApp.ApplicationTypeID = ReplacementReason;
            NewApp.Status = enApplicationStatus.completed;
            NewApp.LastStatusDate = DateTime.Now;
            NewApp.PaidFees = clsApplicationTypes.GetTypeOfApplication(ReplacementReason).ApplicationTypeFee;
            NewApp.CreatedByUserID = CurrentUserID;
            if (!NewApp.Save()) return null;
            clsLicense NewLicense = new clsLicense();
            NewLicense.ApplicationID = NewApp.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClassID = this.LicenseClassID;
            NewLicense.IssueDate = this.IssueDate;
            NewLicense.ExpirationDate = this.ExpirationDate;
          
            NewLicense.PaidFees = 0;
            NewLicense.IsActive = true;
            if (ReplacementReason == 3)
                NewLicense.IssueReason = enIssueReason.ReplacementForLost;
            else
                NewLicense.IssueReason = enIssueReason.ReplacementForDamage;
            NewLicense.CreatedByUserID = CurrentUserID;
            if (!NewLicense.Save()) return null;
            Deactivate();
            return NewLicense;
        }

        public int Detain(int CurrentUserID,decimal FineFees)
        {
            clsDetainReleaseLicenses DetainLicense = new clsDetainReleaseLicenses();
            DetainLicense.LicenseID = this.LicenseID;
            DetainLicense.CreatedByUserID =(CurrentUserID);
            DetainLicense.FineFees  = FineFees;
            DetainLicense.DetainDate = DateTime.Now;
            DetainLicense.IsReleased = false;
            if (!DetainLicense.Detain())
                return -1;
            else
                return DetainLicense.DetainID;

        }
        public bool ReleaseLicense(int CurrentUserID , ref int ReleaseApplicationID  )
        {
            //First Create Applicaiton 
            clsApplications Application = new clsApplications();

            Application._ApplicantPersonID = this.Driver.PersonID;
            Application.ApplicationDate = DateTime.Now;
            // 5 refers to Application of type release 
            Application.ApplicationTypeID = 5;
            Application.Status = clsApplications.enApplicationStatus.completed;
            Application.LastStatusDate = DateTime.Now;
            Application.PaidFees = clsApplicationTypes.GetTypeOfApplication(5).ApplicationTypeFee;
            Application.CreatedByUserID = CurrentUserID;

            if (!Application.Save())
            {
                ApplicationID = -1;
                return false;
            }

            ReleaseApplicationID = Application.ApplicationID;


            return this.DetainLicenseInfo.Release( CurrentUserID, Application.ApplicationID);
        }
   
      
    }
}

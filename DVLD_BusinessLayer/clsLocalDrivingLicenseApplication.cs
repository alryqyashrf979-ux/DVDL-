using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static DVLD_BusinessLayer.clsLicense;
using static DVLD_BusinessLayer.clsLocalDrivingLicenseApplication;

namespace DVLD_BusinessLayer
{
    public class clsLocalDrivingLicenseApplication : clsApplications
    {
       public  enum enMode { Add = 1, Edit = 2 }
        enMode Mode = enMode.Add;

        public int LicenseClassID {  get; set; }

       public clsLicenseClass LicenseClass { get; set; }

        private int _LocalDrivingLicenseApplicationID;
        public int LocalDrivingLicenseApplicationID
        {
            get { return _LocalDrivingLicenseApplicationID; }
        }

        public int ApplicationIDForLocalDrivingLicenseApp
        { set; get; }
        clsApplications Application {  get; set; }
        public string FullName { get { return base.ApplicantFull_Name; } }
        public clsLocalDrivingLicenseApplication():base()
        {
           this._LocalDrivingLicenseApplicationID = -1;
            this.ApplicationIDForLocalDrivingLicenseApp = -1;
            this.LicenseClassID = -1 ;
            Mode = enMode.Add;
        }
        public clsLocalDrivingLicenseApplication(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID
            , DateTime lastStatusDate, decimal PaidFees, int CreatedByUserID, enApplicationStatus Status
            , int LocalDrivingLicenseApplicationID , int licenseClassID , int ApplicationIDForLocalDrivingLicenseApp)
            :base( ApplicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID ,  lastStatusDate,  PaidFees,  CreatedByUserID,  Status)
        {
            this.LicenseClassID= licenseClassID;
            this._LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.ApplicationIDForLocalDrivingLicenseApp = ApplicationIDForLocalDrivingLicenseApp;
            this.LicenseClass = clsLicenseClass.Find(licenseClassID) ;
            Mode = enMode.Edit;
        }
        static public clsLocalDrivingLicenseApplication FindLocalDrivingLicenseByID(int LocalDrivingLicenseApplicationID)
        {
            int ApplicationID = -1; int licenseClassID = -1;

            if (clsLocalDrivingLicenseApplicationsDataAccess.FindByID(LocalDrivingLicenseApplicationID,ref licenseClassID ,ref ApplicationID ))
            {
                clsApplications Application = clsApplications.Find(ApplicationID) ;
                return new clsLocalDrivingLicenseApplication(ApplicationID , Application._ApplicantPersonID, Application.ApplicationDate,
                    Application.ApplicationTypeID, Application.LastStatusDate, Application.PaidFees,
                   Application.CreatedByUserID, (enApplicationStatus)Application.Status, LocalDrivingLicenseApplicationID, licenseClassID, ApplicationID) ;
            }
            else
                return null;
        }
        static public clsLocalDrivingLicenseApplication FindLocalDrivingLicenseByApplicationID(int ApplicationID)
        {
            int LocalDrivingLicenseApplicationID = -1; int licenseClassID = -1;
            if(clsLocalDrivingLicenseApplicationsDataAccess.FindByApplicationID(ApplicationID,ref LocalDrivingLicenseApplicationID
                ,ref licenseClassID))
            {
                clsApplications Application = clsApplications.Find(ApplicationID);
                return new clsLocalDrivingLicenseApplication(ApplicationID, Application._ApplicantPersonID,Application.ApplicationDate,
                    Application.ApplicationTypeID,Application.LastStatusDate,Application.PaidFees,Application.CreatedByUserID,Application.Status
                    ,LocalDrivingLicenseApplicationID,licenseClassID, ApplicationID) ;
            }
            return null;
        }
        private bool _Add()
        {
           
         
                int NewLocalDrivingLicenseApplicationID = -1;
                NewLocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationsDataAccess.Add(LicenseClassID, ApplicationID);
                if(NewLocalDrivingLicenseApplicationID != -1)
                {
                    this._LocalDrivingLicenseApplicationID= NewLocalDrivingLicenseApplicationID;
                    return true;
                }
                else
                    return false;
      
        }

        private bool _Update()
        {
           
         return (clsLocalDrivingLicenseApplicationsDataAccess.Update(
                    LocalDrivingLicenseApplicationID, LicenseClassID, ApplicationID));
        }
        public bool Save()
        {
            base.Mode = (enApplicationMode)Mode;
            if(!base.Save())
                { return false; }
            switch (Mode)
            {
                case enMode.Add:
                    {
                        if(_Add())
                        {
                            Mode = enMode.Edit;
                            return true;
                        }
                        return false;
                    }
            case enMode.Edit: {
                       
                        if(_Update())
                        {
                            return true;
                        }
                        return false;
                        }
                    default:
                    return false;
            }
        }
        public  bool Delete(int LocalDrivingLicenseApplicationID)
        {
           if( clsLocalDrivingLicenseApplicationsDataAccess.Delete(LocalDrivingLicenseApplicationID))
            {
                if(clsApplications.Delete(ApplicationID))
                {
                    return true;
                }
            }
           return false;
        }
        public static DataTable GetAllDrivingLicenseApplicationsTable()
        {
            return clsLocalDrivingLicenseApplicationsDataAccess.GetAllLocalDrivingLicenseApplications();
        }
        public static DataTable FilterDrivingLicenseApplicationsUsingID(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDrivingLicenseApplicationsDataAccess.FilterLocalDrivingLicensesApplicationsUsingID
                (LocalDrivingLicenseApplicationID);
        }
        public static DataTable FilterDrivingLicenseApplicationsUsingNationalNo(string NationalNo)
        {
            return clsLocalDrivingLicenseApplicationsDataAccess.FilterLocalDrivingLicensesApplicationsUsingNationalNo
                (NationalNo);
        }
        public static DataTable FilterDrivingLicenseApplicationsUsingFullName(string FullName)
        {
            return clsLocalDrivingLicenseApplicationsDataAccess.FilterLocalDrivingLicensesApplicationsUsingFullName
                (FullName);
        }
        public static DataTable FilterDrivingLicenseApplicationsUsingLicenseClass(string LicenseClass)
        {
            return clsLocalDrivingLicenseApplicationsDataAccess.FilterLocalDrivingLicensesApplicationsUsingLicenseClass
                (LicenseClass);
        }
        public static DataTable FilterDrivingLicenseApplicationsUsingID(string Status)
        {
            return clsLocalDrivingLicenseApplicationsDataAccess.FilterLocalDrivingLicensesApplicationsUsingStatus
                (Status);
        }
        public static DataTable FilterLocalDrivingLicenseApplicationsUsingStatus(string StatusText)
        {
            return clsLocalDrivingLicenseApplicationsDataAccess.FilterLocalDrivingLicensesApplicationsUsingStatus(StatusText);
        }
        static public bool IsVisionTestEnabled(string ClassName, int LDLAppID)
        {
            return clsLocalDrivingLicenseApplicationsDataAccess.IsVisionTestEnabled(ClassName,LDLAppID);
        }
        static public bool IsWrittenTestEnabled(string ClassName,int LDLAppID)
        {
            return clsLocalDrivingLicenseApplicationsDataAccess.IsWrittenTestEnabled(ClassName,LDLAppID);
        }
        static public bool IsStreetTestEnabled(string ClassName , int LDLAppID)
        {
            return clsLocalDrivingLicenseApplicationsDataAccess.IsStreetTestEnabled(ClassName, LDLAppID );
        }
        static public bool DidPersonPassAllTests(string ClassName,int LDLAppID)
        {
            return clsLocalDrivingLicenseApplicationsDataAccess.DidPersonPassAllTests(ClassName,LDLAppID);
        }
        public bool DoesAttendTestType(int TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationsDataAccess.DoesAttendTestType(LocalDrivingLicenseApplicationID, TestTypeID);
        }
        public int TrialCountPerTestType(int TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationsDataAccess.CountTrials(LocalDrivingLicenseApplicationID,TestTypeID);
        }
        public bool IsThereAnActiveScheduledTest(int TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationsDataAccess.IsThereAnActiveScheduledTest(LocalDrivingLicenseApplicationID, TestTypeID);
        }
        public bool DidPassPreviousTestType(int TestTypeID)
        {
            return clsLocalDrivingLicenseApplicationsDataAccess.DidPassPreviousTestType(LocalDrivingLicenseApplicationID, TestTypeID);
        }
        static public int GetPersonIDByLocalDrivingLicenseApplication(int LDLAppID)
        {
            return clsLocalDrivingLicenseApplicationsDataAccess.GetPersonIDByLocalDrivingLicenseApplication(LDLAppID);
        }
        public int IssueLicenseForTheFirstTime(string Note, int CreatedByUserID)
        {
            clsDrivers Driver = clsDrivers.FindByPersonID(this._ApplicantPersonID);
            if (Driver == null)
            {
                Driver = new clsDrivers();
                Driver.CreationDate = DateTime.Now;
                Driver.CreatedByUserID = CreatedByUserID;
                Driver.PersonID = this._ApplicantPersonID;

                if (Driver.Add())
                {
                    if (Driver.DriverID != -1)
                    {

                        clsLicense license = new clsLicense();
                        license.DriverID = Driver.DriverID;
                        license.CreatedByUserID = CreatedByUserID;
                        license.IssueDate = DateTime.Now;
                        license.ExpirationDate = DateTime.Now.AddYears(LicenseClass.DefaultValidityLength);
                        license.IsActive = true;
                        license.ApplicationID = this.ApplicationID;
                        license.Note = Note;
                        license.IssueReason = enIssueReason.FirstTime;
                        license.PaidFees = this.LicenseClass.ClassFee;
                        license.LicenseClassID = this.LicenseClassID;

                        if (license.Save())
                        {
                            this.setComplete();
                            return license.LicenseID;
                        }
                        else
                            return -1;
                    }
                    return -1;
                }
                return -1;
            }
            return -1;
        }

        public int GetActiveLicenseID()
        {
            return clsLocalDrivingLicenseApplicationsDataAccess.GetActiveLicenseID(this._ApplicantPersonID, this.LicenseClassID);
        }



    }
}

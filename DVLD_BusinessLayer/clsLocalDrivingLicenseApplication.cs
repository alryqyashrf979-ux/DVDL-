using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}

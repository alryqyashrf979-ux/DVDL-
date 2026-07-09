using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsApplications
    {
      public   enum enApplicationMode  {Add =1,Edit =2};
        public enApplicationMode Mode = enApplicationMode.Add;
       public  enum enApplicationStatus { New =1,Cancelled =2,completed =3};
        public enApplicationStatus Status = enApplicationStatus.New;

        private int _ApplicationID;
            public int _ApplicantPersonID { set; get; }
        public DateTime LastStatusDate { get; set; }
        public DateTime ApplicationDate { set; get; }
        public int ApplicationTypeID { get; set; }
        public Decimal PaidFees { get; set; }
        public int CreatedByUserID { set; get; }
        public clsApplicationTypes ApplicationTypeInfo ;
        public clsPeople ApplicantInfo { set; get; }
        public clsUser User { set; get; }
      
        public string StatusText
        {
            get
            {
                switch (Status)
                {
                    case enApplicationStatus.New:
                        return "New";
                    case enApplicationStatus.Cancelled:
                        return "Cancelled";
                    case enApplicationStatus.completed:
                        return "Completed";
                    default:
                        return "";
                }
            }
        }
        public int ApplicationID
        { get { return _ApplicationID; } }
      
        public string ApplicantFull_Name
        {get  { return ApplicantInfo.Full_Name; } }

        public clsApplications()
        {
            this._ApplicantPersonID = -1;
            this._ApplicationID = -1;
            this.ApplicationDate = DateTime.Now;
            this.ApplicationTypeID = -1;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = default(decimal); 
            this.CreatedByUserID = -1;
            this.User = null;
            this.ApplicationTypeInfo = null;
            this.ApplicantInfo = null;
            Status = enApplicationStatus.New;
            Mode = enApplicationMode.Add;
        }
        public clsApplications(int ApplicationID , int ApplicantPersonID , DateTime ApplicationDate , int ApplicationTypeID 
            , DateTime lastStatusDate , decimal PaidFees , int CreatedByUserID , enApplicationStatus Status )
        {
            this._ApplicationID = ApplicationID;
            this._ApplicantPersonID= ApplicantPersonID;
            this.ApplicationDate= ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.LastStatusDate = lastStatusDate;
            this.PaidFees= PaidFees; 
            this.CreatedByUserID = CreatedByUserID;
            this.User = clsUser.Find(CreatedByUserID);
            this.ApplicationTypeInfo = clsApplicationTypes.GetTypeOfApplication(ApplicationTypeID);
            this.ApplicantInfo = clsPeople.FindPerson(ApplicantPersonID);
            this.Status = Status;
            Mode = enApplicationMode.Edit;
        }
        static public clsApplications Find(int ApplicationID)
        {
            int ApplicantPersonID = -1; DateTime ApplicationIssueDate = DateTime.Now; int ApplicationTypeID = -1;
            byte ApplicationStatus = (byte)enApplicationStatus.New;  DateTime LastStatusDate = DateTime.Now; Decimal PaidFee = default(Decimal);
                 int CreatedByUserID = -1;
            if(clsApplicationsDataAccess.Find(ApplicationID,ref ApplicantPersonID,ref ApplicationIssueDate,ref ApplicationTypeID,ref ApplicationStatus
                ,ref  LastStatusDate,ref  PaidFee ,ref CreatedByUserID))
            {
                return new clsApplications(ApplicationID,ApplicantPersonID,ApplicationIssueDate,ApplicationTypeID,
                    LastStatusDate,PaidFee,CreatedByUserID,(enApplicationStatus)ApplicationStatus);
            }
            else
                return null;
        }
        private bool _Add()
        {
            this._ApplicationID = clsApplicationsDataAccess.AddNewApplication(this._ApplicantPersonID, this.ApplicationDate, this.ApplicationTypeID
                , (byte)this.Status, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
            return _ApplicationID != -1;
        }
        private bool _Update()
        {
            return clsApplicationsDataAccess.UpdateApplication(this._ApplicationID, this._ApplicantPersonID, this.ApplicationDate, this.ApplicationTypeID
                , (byte)this.Status, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enApplicationMode.Add:
                    {
                        if(_Add())
                        {
                            Mode = enApplicationMode.Edit;
                            return true;
                        }
                        return false;
                    }
                case enApplicationMode.Edit:
                    {
                        if(_Update())
                        {
                            Mode = enApplicationMode.Edit;
                            return true;
                        }
                        return false;
                    }
                default:
                    return false;

            }

        }
        static public bool Delete(int ApplicationID)
        {
            return clsApplicationsDataAccess.DeleteApplication(ApplicationID);
        }
        static public DataTable GetAllApplications()
        {
            return clsApplicationsDataAccess.GetAllApplications();
        }
        public bool UpdateStatus(int ApplicationID, enApplicationStatus Status ,DateTime LastUpdateDate )
        {
            return clsApplicationsDataAccess.UpdateApplicationStatus(ApplicationID, (byte)Status, LastUpdateDate);
        }
        public bool Cancel()
        {
            return clsApplicationsDataAccess.UpdateApplicationStatus(ApplicationID, 2, DateTime.Now);
        }
        public bool setComplete()
        {
            return clsApplicationsDataAccess.UpdateApplicationStatus(ApplicationID, 3, DateTime.Now);
        }
        static public bool DoesApplicationExist(int ApplicationID)
        {
            return clsApplicationsDataAccess.DoesApplicationExist(ApplicationID);
        }
        static public int GetActiveApplicationForPerson(int PersonID , int ApplicationTypeID)
        {
            return clsApplicationsDataAccess.GetActiveApplicationForPerson(PersonID, ApplicationTypeID);
        }
        static public bool DoesPersonHaveActiveApplication(int PersonID,int ApplicationTypeID)
        {
            return clsApplicationsDataAccess.DoesPersonHaveActiveApplication(PersonID, ApplicationTypeID);
        }
        static public int GetActiveApplicationIDForLocalDrivingLicenseApplication(int PersonID, enApplicationStatus LicenseClassID, int ApplicationTypeID)
        {
            return clsApplicationsDataAccess.GetActiveApplicationIDForLocalDrivingLicenseApplication(PersonID, (byte)LicenseClassID, ApplicationTypeID);
        }
        static public bool DoesPersonHaveActiveApplicationIDForLocalDrivingLicenseApplication(int PersonID , byte LicenseClassID , int ApplicaitonTypeID)
        {
            return clsApplicationsDataAccess.DoesPersonHaveActiveApplicationIDForLocalDrivingLicenseApplication(PersonID, LicenseClassID, ApplicaitonTypeID);
        }

    }
}

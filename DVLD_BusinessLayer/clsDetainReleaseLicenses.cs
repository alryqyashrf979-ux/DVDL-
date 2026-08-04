using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsDetainReleaseLicenses
    {
        public enum enMode { Detain = 0, Release = 1 }
        enMode Mode = enMode.Detain;
        private int _DetainID;
        public int DetainID
        {
            get { return _DetainID; }
        }
        public int LicenseID { set; get; }

 
        public DateTime DetainDate { set; get; }

        public decimal FineFees { set; get; }

        public int CreatedByUserID { set; get; }
        public int ReleasedByUserID { set; get; }

        public bool IsReleased { set; get; }
        public DateTime ReleaseDate { set; get; }

        public int ReleaseApplicationID { set; get; }

        public string StatusText
        {
            get
            {
                switch (Mode)
                {
                    case enMode.Detain:
                        return "Detained";
                    case enMode.Release:
                        return "Released";
                    default:
                        return string.Empty;
                }
            }
        }

        public clsDetainReleaseLicenses()
        {
            Mode = enMode.Detain;
            this.LicenseID = -1;
            this.ReleasedByUserID = -1;
            this.ReleaseDate = DateTime.MinValue;
            this.ReleaseApplicationID = -1;
            this.FineFees = -1;
            this.CreatedByUserID = -1;
            this.DetainDate = DateTime.MinValue;
            this._DetainID = -1;
            this.IsReleased = false;
        
        }
        public clsDetainReleaseLicenses(int DetainID, int LicenseID, DateTime DetainDate, decimal FineFees, int CreatedByUserID, bool IsReleased
            , DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            Mode = enMode.Release;
            this.LicenseID = LicenseID;
            this.ReleasedByUserID = ReleasedByUserID;
            this.ReleaseDate = ReleaseDate;
            this.ReleaseApplicationID = ReleaseApplicationID;
            this.FineFees = FineFees;
            this.CreatedByUserID = CreatedByUserID;
            this.DetainDate = DetainDate;
            this._DetainID = DetainID;
            this.IsReleased = IsReleased;
 
        }
        public bool Detain()
        {
            int NewDetainID = clsDetainedLicensesDataAccessLayer . Detain(this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID);
            if(NewDetainID != -1)
            {
                this._DetainID = NewDetainID;
                 return true;
            }
            return false;
        }
        public  bool Release(int CurrentUserID, int ReleaseApplicationID)
        {
            this.IsReleased = true;
            this.ReleaseDate = DateTime.Now;
            this.ReleaseApplicationID = ReleaseApplicationID;
            this.ReleasedByUserID =CurrentUserID;
            
            return clsDetainedLicensesDataAccessLayer.Release(this._DetainID, this.ReleaseDate, this.ReleaseApplicationID, this.ReleasedByUserID);
        }
       static  public  clsDetainReleaseLicenses Find(int DetainID)
        {
            int LicenseID = -1; 
            decimal FineFees = default(decimal);
            int CreatedByUserID = -1;
            DateTime DetainDate = DateTime.MinValue;
            bool IsReleased = false;
            DateTime ReleaseDate = DateTime.MinValue;
            int ReleaseApplicationID = -1;
            int ReleaseByUserID =-1;

             if(clsDetainedLicensesDataAccessLayer.Find(DetainID,ref LicenseID,ref DetainDate , ref FineFees , ref CreatedByUserID , ref IsReleased , ref ReleaseDate ,ref 
                 ReleaseByUserID,ref ReleaseApplicationID))
                return new clsDetainReleaseLicenses(DetainID, LicenseID, DetainDate,FineFees, CreatedByUserID, IsReleased,ReleaseDate, ReleaseByUserID,ReleaseApplicationID);
            else 
                return null;
        }
        static public clsDetainReleaseLicenses FindByLicenseID(int LicenseID)
        {
            int DetainID = -1;
            decimal FineFees = default(decimal);
            int CreatedByUserID = -1;
            DateTime DetainDate = DateTime.MinValue;
            bool IsReleased = false;
            DateTime ReleaseDate = DateTime.MinValue;
            int ReleaseApplicationID = -1;
            int ReleaseByUserID = -1;

            if (clsDetainedLicensesDataAccessLayer.FindbyLicenseID(LicenseID, ref  DetainID, ref DetainDate, ref FineFees, ref CreatedByUserID, ref IsReleased, ref ReleaseDate, ref
                ReleaseByUserID, ref ReleaseApplicationID))
                return new clsDetainReleaseLicenses(DetainID, LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased, ReleaseDate, ReleaseByUserID, ReleaseApplicationID);
            else
                return null;
        }
        static public bool Delete(int DetainID)
        {
            return clsDetainedLicensesDataAccessLayer.Delete(DetainID);
        }
        static public DataTable GetAllDetainRecordsByStatus(bool IsReleased)
        {
            return clsDetainedLicensesDataAccessLayer.GetAllLicenseByStatus(IsReleased);
        }
        static public bool DoesDetainLicenseRecordExist(int DetainID)
        {
            return clsDetainedLicensesDataAccessLayer.DoesDetainLicenseRecordExist(DetainID);
        }
        static public bool IsLicenseDetained(int LicenseID)
        {
            return clsDetainedLicensesDataAccessLayer.IsLicenseDetained(LicenseID);
        }
        static public DataTable FilterByDetainID(int DetainID)
        {

            return clsDetainedLicensesDataAccessLayer.FilterDetainedLicenseByDetainID(DetainID);
        }
        static public DataTable FilterByLicenseID(int LicenseID)
        {
            return clsDetainedLicensesDataAccessLayer.FilterDetainedLicenseByLicenseID(LicenseID);
        }
        static public DataTable FilterByFullName(string FullName)
        {
            return clsDetainedLicensesDataAccessLayer.FilterDetainedLicenseByFullName(FullName.Trim());

        }
        static public DataTable FilterByNationalNo(string NationalNo)
        {
            return clsDetainedLicensesDataAccessLayer.FilterDetainedLicenseByNationalNo(NationalNo.Trim());
        }
        static public DataTable GetAllRecords()
        {
            return clsDetainedLicensesDataAccessLayer.GetAllRecords();
        }


    

    }

}

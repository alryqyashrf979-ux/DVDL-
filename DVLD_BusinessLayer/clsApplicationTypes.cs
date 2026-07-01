using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsApplicationTypes
    {
        enum enMode { Add = 1, Edit =2};
        enMode Mode = enMode.Add;
        private int _AppTypeID;
        public int AppTypeID
        {
            get { return _AppTypeID; }
        }
        public string ApplicationTypeTitle { get; set; }
        public decimal ApplicationTypeFee { get; set; } 
        public clsApplicationTypes()
        {
            ApplicationTypeFee = default(decimal);
            ApplicationTypeTitle = string.Empty;
            Mode = enMode.Add;
        }
      public   clsApplicationTypes(int AppTypeID,string ApplicationTypeTitle,decimal ApplicationtypeFee)
        {
            this._AppTypeID = AppTypeID;
            this.ApplicationTypeFee = ApplicationtypeFee;
            this.ApplicationTypeTitle = ApplicationTypeTitle;
            Mode = enMode.Edit;
        }
       static  public clsApplicationTypes GetTypeOfApplication(int AppTypeID)
        {
            string ApplicationTypeName = string.Empty;
            decimal ApplicationTypeFee = default(decimal);
            if (clsApplicationTypesDataAccessLayer.GetApplicationTypeByID(AppTypeID,ref ApplicationTypeName,ref ApplicationTypeFee))
               return new clsApplicationTypes(AppTypeID,ApplicationTypeName,ApplicationTypeFee); 

                return null;
        }
        private bool _Add()
        { 
            int NewID = clsApplicationTypesDataAccessLayer.AddNewApplicationTypes(ApplicationTypeTitle, ApplicationTypeFee);
            return NewID != -1;
        }
        private bool _Edit()
        {
            return clsApplicationTypesDataAccessLayer.UpdatApplicationTypes(_AppTypeID, ApplicationTypeTitle, ApplicationTypeFee);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:
                    {
                        if(_Add())
                        {
                            Mode = enMode.Edit;
                            return true;
                        }
                            break;
                    }
                case enMode.Edit:
                    {
                        if (_Edit())
                        {
                            Mode = enMode.Edit;
                            return true;
                        }
                        break;
                    }
                default:
                    return false;
            }
            return false;
        }
        static public DataTable  GetAllAppsTypes()
        {
            return clsApplicationTypesDataAccessLayer.GetAllAppTypes();
        }
    }
}

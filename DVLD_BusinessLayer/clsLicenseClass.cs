using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsLicenseClass
    {
        public enum enMode { Add =1 , Update =2};
        public enMode Mode = enMode.Add;

        private int _LicenseClassID;
        public int LicenseClassID
        { get { return _LicenseClassID; } }

       public  string ClassName { get; set; } 
             public string ClassDescription { get; set; } 
        public byte MinimumAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set; }
        public decimal ClassFee { get; set; }

        public clsLicenseClass()
        {
            this._LicenseClassID = -1;
            this.DefaultValidityLength = 0;
            this.ClassFee = default(decimal);
            this.MinimumAllowedAge = 0;
            this.ClassDescription = string.Empty;
            this .ClassName = string.Empty;
            Mode = enMode.Add;
        }
        public clsLicenseClass(int licenseClassID , string ClassName ,string ClassDescription ,byte MinimumAllowedAge ,byte DefaultValidityLength 
            , decimal classFee)
        {
            this ._LicenseClassID = licenseClassID;
            this.ClassDescription = ClassDescription;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFee = classFee;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.ClassName = ClassName;
            Mode = enMode.Update;
        }
       static public clsLicenseClass Find(int LicenseClassID)
        {
            string ClassName = string.Empty; string ClassDescription = string.Empty; byte MinimumAllowedAge = 0; byte defaultVaidityAge = 0;
            decimal classFee = default(decimal);
             
            if(clsLicenseClassesDataAccess.Find(LicenseClassID,ref ClassName ,ref ClassDescription,ref MinimumAllowedAge,ref defaultVaidityAge
                ,ref classFee))
            {
                return new clsLicenseClass(LicenseClassID, ClassName, ClassDescription,MinimumAllowedAge
                    , defaultVaidityAge, classFee);
            }
            else
                return null;

        }
        private bool _Add()
        {
            int NewID = clsLicenseClassesDataAccess.Add(this.ClassDescription, this.ClassName, this.MinimumAllowedAge,
                this.DefaultValidityLength, this.ClassFee);
            if (NewID > 0)
            {
                this._LicenseClassID = NewID;
                return true;
            }
            return false;
        }
        private bool _Update()
        {
            return clsLicenseClassesDataAccess.Update(this.LicenseClassID, ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength
                , ClassFee);

        }

        public bool Save()
        {
            switch (Mode)
            { 
            case enMode.Add:
                    {
                        if(_Add())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        return false;
                    }
                    case enMode.Update:
                    {
                        if (_Update())
                            return true;
                        return false;
                    }
                default: return false;
            }
        }
        static public DataTable  GetAllLicenseClasses()
        {
            return clsLicenseClassesDataAccess.GetAllLicenseClasses();
        }
    }
}

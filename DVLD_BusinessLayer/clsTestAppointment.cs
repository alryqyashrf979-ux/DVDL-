using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsTestAppointment
    {
        enum enMode { Add = 1, Edit = 2 };
        enMode Mode = enMode.Add;
        public enum enTestType { Vision = 1, Written = 2, Practical = 3 }
        public enTestType TestType = enTestType.Vision;

        private int _TestAppointmentID;
        public int TestAppointmentID { get { return _TestAppointmentID; } }

            // Does it have to have composition for LDLAPPID
        public int LocalDrivingLicenseAppID { set; get; }
        public DateTime AppointmentDate { set; get; }
        public decimal PaidFee { set; get; }
        public int CreatedByUserID { set; get; }
        public bool Is_Locked { set; get; }
        public int RetakeAppID { set; get; }

        public clsTestAppointment()
        {
            this.Is_Locked = false;
            this.RetakeAppID = -1;
            this.CreatedByUserID = -1;
            this.LocalDrivingLicenseAppID = -1;
            this.AppointmentDate = DateTime.Now;
            this.PaidFee = default(decimal);
            this._TestAppointmentID = -1;
            this.TestType = enTestType.Vision;
            Mode = enMode.Add;

        }
        public clsTestAppointment(int testAppointmentID, int LDLAppId, DateTime AppointmentDate, decimal PaidFee, int CreatedByUserID
            , bool IsLocked, int RetakeTestAppID)
        {
            this.RetakeAppID = RetakeTestAppID;
            this._TestAppointmentID = testAppointmentID;
            this.PaidFee = PaidFee;
            this.LocalDrivingLicenseAppID = LDLAppId;
            this.AppointmentDate = AppointmentDate;
            this.CreatedByUserID = CreatedByUserID;
            this.Is_Locked = IsLocked;
            this.TestType = enTestType.Vision;
            Mode = enMode.Edit;
        }
        static public clsTestAppointment FindByID(int testAppointmentID)
        {
            int testType = -1; decimal PaidFee = default(decimal); int LDLAppID = -1;
            DateTime AppointmentDate = DateTime.Now; int CreatedByUserID = -1; int RetakeAppID = -1;
            bool IsLocked = false;

            if (clsTestAppointmentDataAccessLayer.FindTestAppiontmentID(testAppointmentID, ref testType, ref LDLAppID, ref AppointmentDate,
                ref PaidFee, ref CreatedByUserID, ref IsLocked, ref RetakeAppID))
            {
                return new clsTestAppointment(testAppointmentID, LDLAppID, AppointmentDate, PaidFee, CreatedByUserID, IsLocked, RetakeAppID);
            }
            else
                return null;
        }
        static public clsTestAppointment FindByLDLAppID(int LDLAppID)
        {
            int testType = -1; decimal PaidFee = default(decimal); 
            DateTime AppointmentDate = DateTime.Now; int CreatedByUserID = -1; int RetakeAppID = -1;
            bool IsLocked = false;
            int TestAppointmentID = -1;

            if (clsTestAppointmentDataAccessLayer.FindByLDLAppID(LDLAppID , ref testType, ref TestAppointmentID, ref AppointmentDate,
                ref PaidFee, ref CreatedByUserID, ref IsLocked, ref RetakeAppID))
            {
                return new clsTestAppointment(TestAppointmentID, LDLAppID, AppointmentDate, PaidFee, CreatedByUserID, IsLocked, RetakeAppID);
            }
            else
                return null;
        }
        private bool _Add()
        {
            int NewID = clsTestAppointmentDataAccessLayer.Add((int)TestType, LocalDrivingLicenseAppID, AppointmentDate, PaidFee, CreatedByUserID, Is_Locked, RetakeAppID);
            if (NewID != -1)
            {
                this._TestAppointmentID = NewID;
                return true;
            }
            else
                return false;
        }
        static public bool _Delete(int TestAppointmentID)
        {

            return clsTestAppointmentDataAccessLayer.Delete(TestAppointmentID);
        }
        private bool _Update()
        {
            return clsTestAppointmentDataAccessLayer.Update(TestAppointmentID, (int)TestType, LocalDrivingLicenseAppID, AppointmentDate, PaidFee
                , CreatedByUserID, Is_Locked, RetakeAppID);
        }
        static public DataTable GetAllAppointmentwithSpecificType(enTestType testType)
        {
            return clsTestAppointmentDataAccessLayer.GetTestAppointmentsByTestType((int)testType);
        }
        static public bool DoesApplicantHavePreviousTestAppointments(int ApplicantPersonID, enTestType testType)
        {
            return clsTestAppointmentDataAccessLayer.DoesApplicantHavePreviousTestAppointments(ApplicantPersonID,(int)testType);
        }

    }

    }


using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public class clsTest
    {
        private int _TestID = -1;
        public int TestID { get { return _TestID; } }

        public int TestAppointmentID { set; get; }

        public bool TestResult { set; get; }

        public string Note { set; get; }

        public int CreatedByUserID { set; get; }

        public clsTestAppointment Appointment { set; get; }

        public clsTest() {
        _TestID = -1;
            TestAppointmentID = -1;
            TestResult = false;
            Note = string.Empty;
            CreatedByUserID = -1;
        
            Appointment = new clsTestAppointment();
        }
       public clsTest(int testID,  int testAppointmentID ,  bool result , string note , int createdByUserID )
        {
            _TestID = testID;
            TestAppointmentID = testAppointmentID;
            TestResult = result;
            Note = note;
            CreatedByUserID = createdByUserID;

            Appointment = clsTestAppointment.FindByID(TestAppointmentID);
        }

        static public clsTest Find(int TestID)
        {
            string Note = string.Empty; int createdByUserID = -1; bool TestResult =false; int TestAppID = -1;
            bool Result = clsTestsDataAccessLayer.Find(TestID, ref TestAppID, ref TestResult, ref Note, ref createdByUserID);
            if(Result) { return new clsTest(TestID,TestAppID,TestResult, Note, createdByUserID); }
            else
                return null;
        }
        static public clsTest FindTestByTestAppointmentID(int TestAppointmentID)
        {
            string Note = string.Empty; int createdByUserID = -1; bool TestResult = false; int TestID = -1;
            bool Result = clsTestsDataAccessLayer.FindTestByTestAppointmentID(TestAppointmentID, ref TestID, ref TestResult, ref Note, ref createdByUserID);
            if (Result) { return new clsTest( TestID , TestAppointmentID , TestResult, Note, createdByUserID); }
            else
                return null;
        }
        public bool Add()
        {
            int NewID = clsTestsDataAccessLayer.AddTest(this.TestAppointmentID, this.TestResult, this.Note, this.CreatedByUserID);
            if( NewID != -1 ) 
                this._TestID = NewID;
            else
                this._TestID = -1;

                return NewID > -1;
        }
        static public bool DoesPassTest(int TestAppointmentID)
        {
            return clsTestsDataAccessLayer.DoesPassTest(TestAppointmentID);
        }
        static public bool DoesPassLastTest(int LDLAppID,int TestTypeID)
        {
            return clsTestsDataAccessLayer.DoesPassLastTest(LDLAppID,TestTypeID);
        }


    }
}

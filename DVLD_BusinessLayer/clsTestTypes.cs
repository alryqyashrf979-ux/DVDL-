using DVLD_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLayer
{
    public  class clsTestTypes
    {
        private int _TestTypeID;
        public int TestTypeID
            { get { return _TestTypeID; } }
        public string TestTypeDescription { get; set; }
        public string TestTypeTitle { get; set; }
        public decimal TestTypeFee { get; set; }
        public clsTestTypes(int testTypeID, string testTypeDescription, string testTypeTitle, decimal testTypeFee)
        {
            _TestTypeID = testTypeID;
            TestTypeDescription = testTypeDescription;
            TestTypeTitle = testTypeTitle;
            TestTypeFee = testTypeFee;
        }
        public clsTestTypes ()
        {
            _TestTypeID = -1;
            TestTypeDescription = string.Empty;
            TestTypeTitle = string.Empty;
            TestTypeFee = default(decimal);
        }
        static public clsTestTypes Find(int testTypeID)
        {
            string testTypeTitle = string.Empty;
            decimal testTypeFee = default(decimal);
            string testTypeDescription = string.Empty;
            if (clsTestManagementDataAccessLayer.Find(testTypeID, ref testTypeTitle, ref testTypeDescription, ref testTypeFee))
            {
                return new clsTestTypes(testTypeID, testTypeDescription, testTypeTitle, testTypeFee);
            }
            else
                return null;
        }
        static public DataTable GetAllTestTypes()
        {
            return clsTestManagementDataAccessLayer.GetAllTestsTypes();
        }
        public bool Update()
        {
            return clsTestManagementDataAccessLayer.EditTest(TestTypeID, TestTypeTitle, TestTypeDescription, TestTypeFee);
        }
    }
}

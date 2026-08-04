using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_DataAccessLayer
{
    static public class clsLocalDrivingLicenseApplicationsDataAccess
    {
        static public bool FindByID(int LocalDrivingLicenseApplicationID, ref int LocalDrivingLicenseAppClassID, ref int ApplicationID)
        {
            string Query = "select LocalDrivingLicenseApplicationID ,LicenseClassID, ApplicationID from LocalDrivingLicenseApplications " +
                "where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID ";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    LocalDrivingLicenseAppClassID = (int)dr["LicenseClassID"];
                    ApplicationID = (int)dr["ApplicationID"];
                    return true;
                }
                return false;
            }
        }
        static public bool FindByApplicationID(int ApplicationID, ref int LocalDrivingLicenseApplicationID, ref int LocalDrivingLicenseAppClassID)
        {
            string Query = "select LocalDrivingLicenseApplicationID ,LicenseClassID, ApplicationID from LocalDrivingLicenseApplications " +
                "where ApplicationID = @ApplicationID ";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    LocalDrivingLicenseApplicationID = (int)dr["LocalDrivingLicenseApplicationID"];
                    LocalDrivingLicenseAppClassID = (int)dr["LicenseClassID"];
                    return true;
                }
                return false;
            }
        }
        static public int Add(int LocalDrivingLicenseAppClassID, int ApplicationID)
        {
            string Query = "insert into LocalDrivingLicenseApplications \r\nvalues (@ApplicationID , @LocalDrivingLicenseAppClassID ) select Scope_Identity();";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                cmd.Parameters.AddWithValue("@LocalDrivingLicenseAppClassID", LocalDrivingLicenseAppClassID);

                object Result = cmd.ExecuteScalar();
                if (Result != DBNull.Value && int.TryParse(Result.ToString(), out int NewID))
                {
                    return NewID;
                }
                else
                    return -1;
            }
        }
        static public bool Update(int LocalDrivingLicenseApplicationID, int LocalDrivingLincesClassID, int ApplicationID)
        {
            string Query = " Update LocalDrivingLicenseApplications \r\nset LicenseClassID = @LocalDrivingLincesClassID \r\n," +
                " ApplicationID = @ApplicationID \r\nwhere LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@LocalDrivingLincesClassID", LocalDrivingLincesClassID);
                cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        static public DataTable GetAllLocalDrivingLicenseApplications()
        {
            DataTable dataTable = new DataTable();
            string Query = "select * from LocalDrivingLicenseApplications_View ";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dataTable.Load(reader);
                    return dataTable;
                }
            }
            return dataTable;
        }

        static public bool Delete(int LocalDrivingLicenseApplicationID)
        {
            string Query = "Delete from LocalDrivingLicenseApplications " +
                "where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        static public DataTable FilterLocalDrivingLicensesApplicationsUsingID(int LocalDrivingLicenseApplicationID)
        {
            DataTable dataTable = new DataTable();
            string Query = "select * from LocalDrivingLicenseApplications_View where LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    dataTable.Load(reader);


                return dataTable;
            }
        }
        static public DataTable FilterLocalDrivingLicensesApplicationsUsingLicenseClass(string LicenseClass)
        {
            DataTable dataTable = new DataTable();
            string Query = "select * from LocalDrivingLicenseApplications_View where ClassName like '%" + LicenseClass + "%'";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    dataTable.Load(reader);


                return dataTable;
            }
        }
        static public DataTable FilterLocalDrivingLicensesApplicationsUsingNationalNo(string NationalNo)
        {
            DataTable dataTable = new DataTable();
            string Query = "select * from LocalDrivingLicenseApplications_View where NationalNo like '%" + NationalNo + "%'";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    dataTable.Load(reader);


                return dataTable;
            }
        }
        static public DataTable FilterLocalDrivingLicensesApplicationsUsingFullName(string FullName)
        {
            DataTable dataTable = new DataTable();
            string Query = "select * from LocalDrivingLicenseApplications_View where FullName like '%" + FullName + "%'";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    dataTable.Load(reader);
                return dataTable;
            }
        }
        static public DataTable FilterLocalDrivingLicensesApplicationsUsingStatus(string StatusText)
        {
            DataTable dataTable = new DataTable();
            string Query = "select * from LocalDrivingLicenseApplications_View where Status like '%" + StatusText + "%'";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    dataTable.Load(reader);
                return dataTable;
            }
        }
        //select Found =1 from LocalDrivingLicenseApplications_View L
        //where L.PassedTestCount =0 and L.Status ='New' and L.ClassName like '%Class 3 - Ordinary driving license%'

        static public bool IsVisionTestEnabled(string ClassName, int LocalDrivingLicenseApplicationID)
        {
            string Query = "select Found = 1 from LocalDrivingLicenseApplications_View L  " +
                "where L.PassedTestCount = 0 and L.Status ='New' and L.ClassName like '%" + ClassName + "%' "+
            "and LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                //cmd.Parameters.AddWithValue("@ClassName",ClassName);
                cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                object Result = cmd.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int result))
                {
                    return result == 1;
                }
                else
                    return false;
            }
        }

        static public bool IsWrittenTestEnabled(string ClassName , int LocalDrivingLicenseApplicationID)
        {
            string Query = "select Found = 1 from LocalDrivingLicenseApplications_View L  " +
                "where L.PassedTestCount = 1 and L.Status ='New' and L.ClassName like '%" + ClassName + "%' " +
                "and LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                //cmd.Parameters.AddWithValue("@ClassName", ClassName);
                cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                object Result = cmd.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int result))
                {
                    return result == 1;
                }
                else
                    return false;
            }
        }

        static public bool IsStreetTestEnabled(string ClassName , int LocalDrivingLicenseApplicationID)
        {
            string Query = "select Found =1 from LocalDrivingLicenseApplications_View L  " +
                "where L.PassedTestCount =2 and L.Status ='New' and L.ClassName like '%" + ClassName + "%'" +
                "and LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                //cmd.Parameters.AddWithValue("@ClassName", ClassName);
                cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                object Result = cmd.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int result))
                {
                    return result == 1;
                }
                else
                    return false;
            }
        }

        static public bool DidPersonPassAllTests(string ClassName,int LDLAppID)
        {
            string Query = "select Found =1 from LocalDrivingLicenseApplications_View L  " +
                "where L.PassedTestCount =3 and L.Status ='New' and L.ClassName like '%" + ClassName + "%' and LocalDrivingLicenseApplicationID = @LDLAppID";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                //cmd.Parameters.AddWithValue("@ClassName", ClassName);
                cmd.Parameters.AddWithValue("@LDLAppID", LDLAppID);
                object Result = cmd.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int result))
                {
                    return result == 1;
                }
                else
                    return false;
            }

        }
        static public bool DoesAttendTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            string Query = "select top 1 * from LocalDrivingLicenseApplications LDLApps" +
                " \r\ninner join TestAppointments TApps on TApps.LocalDrivingLicenseApplicationID = LDLApps.LocalDrivingLicenseApplicationID " +
                "\r\ninner join tests T on T.TestAppointmentID = TApps.TestAppointmentID\r\n\r\n" +
                "where LDLApps.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID and TApps.TestTypeID =@TestTypeID ";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                object Result = cmd.ExecuteScalar();
                return Result != null;

            }
        }

        static public int CountTrials(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            string Query = "select TrialCount  = count (*) from LocalDrivingLicenseApplications LDLApps \r\n" +
                "inner join TestAppointments TApps on TApps.LocalDrivingLicenseApplicationID = LDLApps.LocalDrivingLicenseApplicationID\r\n" +
                "inner join tests T on T.TestAppointmentID = TApps.TestAppointmentID\r\n\r\n" +
                "where LDLApps.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID and TApps.TestTypeID =@TestTypeID ; select SCOPE_IDENTITY() ;";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                object Result = cmd.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int Count))
                {
                    return Count;
                }
                else
                    return 0;
            }
        }
        static public bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, int TestTypeID)

        {
            string Query = "\r\nselect TrialCount  = count (*) from LocalDrivingLicenseApplications LDLApps " +
                "\r\ninner join TestAppointments TApps on TApps.LocalDrivingLicenseApplicationID = LDLApps.LocalDrivingLicenseApplicationID" +
                "\r\nwhere LDLApps. LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID and TApps.TestTypeID = @TestTypeID" +
                " and TApps.IsLocked = 0";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                object Result = cmd.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int Count))
                {
                    return Count > 0;
                }
                else
                    return false;
            }
        }
        static public bool DidPassPreviousTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)

        {
            string Query = "select Count(*)from LocalDrivingLicenseApplications LDLApp inner join TestAppointments TA " +
                "on TA.LocalDrivingLicenseApplicationID = LDLApp.LocalDrivingLicenseApplicationID" +
                "\r\ninner join Tests T on T.TestAppointmentID = TA.TestAppointmentID \r\nwhere LDLApp. " +
                "LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID and TA.TestTypeID =@TestTypeID and T.TestResult =1";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
                object Result = cmd.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int Count))
                {
                    return Count > 0;
                }
                else
                    return false;
            }

        }
        static public int GetPersonIDByLocalDrivingLicenseApplication(int LDLAppID)
        {
            string Query = "\r\nselect A.ApplicantPersonID from LocalDrivingLicenseApplications L" +
                " inner join Applications A on L.ApplicationID = A.ApplicationID where LocalDrivingLicenseApplicationID= @LDLAppID";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@LDLAppID", LDLAppID);
                object Result = cmd.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int PersonID))
                {
                    return PersonID;
                }
                else
                    return -1;
            }
        }

        static public int GetActiveLicenseID(int PersonID, int LicenseClassID)
        {
            string Query = "select L.LicenseID from  Licenses L inner join Drivers D on L.DriverID = D.DriverID " +
                "\r\nwhere L.LicenseClass = @LicenseClassID and D.PersonID = @PersonID and L.IsActive = 1 ";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@PersonID", PersonID);
                cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                object Result = cmd.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int result))
                {
                    return result;
                }
                else
                    return -1;
            }

            }
    }
}
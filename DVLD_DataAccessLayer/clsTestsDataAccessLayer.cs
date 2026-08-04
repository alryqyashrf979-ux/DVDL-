using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DataAccessLayer
{
    public class clsTestsDataAccessLayer
    {
        static public bool Find(int TestID, ref int TestAppointmentID, ref bool TestResult, ref string Note, ref int CreatedByUserID)
        {
            string Query = "select * from Tests where TestID = @TestID";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@TestID", TestID);
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    TestResult = (bool)reader["TestResult"];
                    if (reader["Notes"] == DBNull.Value)
                        Note = "";
                    else
                        Note = (string)reader["Notes"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    reader.Close();
                    return true;
                }
                return false;

            }

            }
        static public bool FindTestByTestAppointmentID( int TestAppointmentID, ref int TestID, ref bool TestResult, ref string Note, ref int CreatedByUserID)
        {
            string Query = "select * from Tests where TestAppointmentID = @TestAppointmentID";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    TestID = (int)reader["TestID"];
                    TestResult = (bool)reader["TestResult"];
                    if(reader["Notes"]==DBNull.Value)
                    Note = "";
                    else
                        Note = (string)reader["Notes"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    reader.Close();
                    return true;
                }
                return false;

            }

        }
        static public int AddTest(int TestAppointmentID, bool TestResult, string Note, int CreatedByUserID)
        {
            string Query = "insert into Tests \r\nvalues(@TestAppointmentID, @TestResult,@Note ,@CreatedByUserID ) " +
                "select Scope_Identity();\r\n";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                cmd.Parameters.AddWithValue("@TestResult", TestResult);
                if (string.IsNullOrEmpty(Note))
                    cmd.Parameters.AddWithValue("@Note", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@Note", Note);
                cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                object Result = cmd.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int result))
                {
                    return result;
                }
            }
            return -1;
        }
        static public bool DoesPassTest(int TestAppointmentID)
        {
            string Query = "select TestResult from Tests where TestAppointmentID = @TestAppointmentID";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

                object Result = cmd.ExecuteScalar();
                if (Result != null && bool.TryParse(Result.ToString(), out bool result))
                {
                    return result;
                }
            }
            return false;
        }

        static public bool DoesPassLastTest(int LDLAppID, int TestTypeID)
        {
            string Query = "   select Top 1 T.TestResult from TestAppointments TA inner join Tests T on" +
                " T.TestAppointmentID = TA.TestAppointmentID\r\nwhere TA.LocalDrivingLicenseApplicationID =" +
                "@LDLAppID and TA.TestTypeID = @TestTypeID\r\norder by T.TestID desc";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                cmd.Parameters.AddWithValue("@LDLAppID", LDLAppID);

                object Result = cmd.ExecuteScalar();
                if (Result != null && bool.TryParse(Result.ToString(), out bool result))
                {
                    return result;
                }
            }
            return false;
        }
     
    }
}
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
    public class clsTestAppointmentDataAccessLayer
    {
        static public bool FindTestAppiontmentID(int TestAppointmentID, ref int TestTypeID, ref int LDLAppId, ref DateTime AppointmentDate, ref decimal PaidFee, ref int CreatedByUserID, ref bool IsLocked,
          ref int RetakeApplicationID)
        {
            string Query = "select * from TestAppointments where TestAppointmentID = @TestAppointmentID";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TestTypeID = (int)reader["TestTypeID"];
                    LDLAppId = (int)reader["LocalDrivingLicenseApplicationID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFee = (decimal)reader["PaidFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsLocked = (bool)reader["IsLocked"];
                    if (reader["RetakeTestApplicationID"] == DBNull.Value)
                    {
                        RetakeApplicationID = -1;
                    }
                    else
                        RetakeApplicationID = (int)reader["RetakeTestApplicationID"];
                    return true;
                }
                return false;
            }
        }
        static public bool FindByLDLAppID(int LDLAppId, ref int TestTypeID, ref int TestAppointmentID, ref DateTime AppointmentDate, ref decimal PaidFee, ref int CreatedByUserID, ref bool IsLocked,
       ref int RetakeApplicationID)
        {
            string Query = "select * from TestAppointments where LocalDrivingLicenseApplicationID = @LDLAppId";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@LDLAppId", LDLAppId);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TestTypeID = (int)reader["TestTypeID"];
                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFee = (decimal)reader["PaidFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsLocked = (bool)reader["IsLocked"];
                    if (reader["RetakeTestApplicationID"] == DBNull.Value)
                    {
                        RetakeApplicationID = -1;
                    }
                    else
                        RetakeApplicationID = (int)reader["RetakeTestApplicationID"];
                    return true;
                }
                return false;
            }
        }
        static public int Add(int TestTypeID, int LDLAppId, DateTime AppointmentDate, decimal PaidFee, int CreatedByUserID, bool IsLocked,
            int RetakeApplicationID)
        {
            string Query = "insert into TestAppointments \r\nvalues (@TestTypeID ,@LDLAppId ,@AppointmentDate , @PaidFee ," +
                "@CreatedByUserID,@IsLocked,@RetakeApplicationID)\r\nselect SCOPE_IDENTITY() ;";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                cmd.Parameters.AddWithValue("@LDLAppId", LDLAppId);
                cmd.Parameters.AddWithValue("@AppointmentDate", SqlDbType.SmallDateTime).Value = AppointmentDate;
                cmd.Parameters.Add("@PaidFee", System.Data.SqlDbType.SmallMoney).Value = PaidFee;
                cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                cmd.Parameters.Add("@IsLocked", System.Data.SqlDbType.Bit).Value = IsLocked;
                if (RetakeApplicationID != -1)
                    cmd.Parameters.AddWithValue("@RetakeApplicationID", RetakeApplicationID);
                else
                    cmd.Parameters.AddWithValue("@RetakeApplicationID", DBNull.Value);
                object Result = cmd.ExecuteScalar();
                if (Result != DBNull.Value && int.TryParse(Result.ToString(), out int NewID))
                {
                    return NewID;
                }
                else
                    return -1;
            }
        }
        static public bool Update(int TestAppointmentID, int TestTypeID, int LDLAppId, DateTime AppointmentDate, decimal PaidFee, int CreatedByUserID, bool IsLocked,
            int RetakeApplicationID)
        {
            string Query = "\r\nupdate TestAppointments \r\nset" +
                " TestTypeID =@TestTypeID ," +
                "LocalDrivingLicenseApplicationID = @LDLAppId , " +
                "AppointmentDate = @AppointmentDate, " +
                "PaidFee = @PaidFees ," +
                "CreatedByUserID = @CreatedByUserID ," +
                "IsLocked =@IsLocked ," +
                "RetakeTestApplicationID = @RetakeTestApplicationID  \r\nwhere TestAppointmentID = @TestAppointmentID ";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                cmd.Parameters.AddWithValue("@LDLAppId", LDLAppId);
                cmd.Parameters.AddWithValue("@AppointmentDate", SqlDbType.SmallDateTime).Value = AppointmentDate;
                cmd.Parameters.Add("@PaidFee", System.Data.SqlDbType.SmallMoney).Value = PaidFee;
                cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                cmd.Parameters.Add("@IsLocked", System.Data.SqlDbType.Bit).Value = IsLocked;
                if (RetakeApplicationID != -1)
                    cmd.Parameters.AddWithValue("@RetakeApplicationID", RetakeApplicationID);
                else
                    cmd.Parameters.AddWithValue("@RetakeApplicationID", DBNull.Value);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        static public bool Delete(int TestAppointmentID)
        {
            string Query = "Delete from TestAppointments where TestAppointmentID = @TestAppointmentID";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        static public DataTable GetTestAppointmentsByTestType(int TestTypeID)
        {
            DataTable dataTable = new DataTable();
            string Query = "select TestAppointmentID as 'Test Appointment ID ' ,AppointmentDate as 'Appointment Date'" +
                " , PaidFees as 'Paid Fees' ,IsLocked  from TestAppointments where TestTypeID =@TestTypeID";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dataTable.Load(reader);
                }
            }
            return dataTable;
        }
        static public bool DoesApplicantHavePreviousTestAppointments(int ApplicantPersonID,int TestTypeID)
        {
            string Query = "\r\nselect Found =1 from TestAppointments TA inner join LocalDrivingLicenseApplications LDLAPPS" +
                " \r\non TA.LocalDrivingLicenseApplicationID = LDLAPPS.LocalDrivingLicenseApplicationID\r\n" +
                "inner join Applications Apps on LDLAPPS.ApplicationID = Apps.ApplicationID \r\n\r\n" +
                "where ApplicantPersonID = ApplicantPersonID and TestTypeID =@TestTypeID\r\nselect SCOPE_IDENTITY();";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
                cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                object Result = cmd.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int result))
                {
                    return true;
                }
                else
                    return false;

            }
        }
    }

}
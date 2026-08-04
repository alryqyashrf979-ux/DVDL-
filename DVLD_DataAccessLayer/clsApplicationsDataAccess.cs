using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DataAccessLayer
{
    public class clsApplicationsDataAccess
    {
        static public bool Find(int ApplicationID, ref int ApplicantPersonID, ref DateTime ApplicationIssueDate, ref int ApplicationTypeID
            , ref byte ApplicationStatus, ref DateTime LastStatusDate, ref Decimal PaidFee, ref int CreatedByUserID)
        {
            string Query = "select * from Applications where ApplicationID = @ApplicationID";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                SqlDataReader Reader = cmd.ExecuteReader();
                while (Reader.Read())
                {
                    ApplicantPersonID = (int)Reader["ApplicantPersonID"];
                    ApplicationIssueDate = (DateTime)Reader["ApplicationDate"];
                    ApplicationTypeID = (int)Reader["ApplicationTypeID"];
                    ApplicationStatus = (byte)Reader["ApplicationStatus"];
                    LastStatusDate = (DateTime)Reader["LastStatusDate"];
                    PaidFee = (Decimal)Reader["PaidFees"];
                    CreatedByUserID = (int)Reader["CreatedByUserID"];
                    return true;
                }
                return false;
            }
        }
        static public int AddNewApplication(int ApplicantPersonID, DateTime ApplicationIssueDate, int ApplicationTypeID
            , byte ApplicationStatus, DateTime LastStatusDate, Decimal PaidFee, int CreatedByUserID)
        {
            string Query = "Insert into Applications " +
                "values(@ApplicantPersonID,@ApplicationIssueDate,@ApplicationTypeID,@ApplicationStatus,@LastStatusDate,@PaidFee,@CreatedByUserID);" +
                "select Scope_Identity();";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
                cmd.Parameters.AddWithValue("@ApplicationIssueDate", ApplicationIssueDate);
                cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                cmd.Parameters.Add("@ApplicationStatus", SqlDbType.TinyInt).Value = ApplicationStatus ;
                cmd.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
                cmd.Parameters.Add("@PaidFee", SqlDbType.SmallMoney).Value = PaidFee;
                cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                object Result = cmd.ExecuteScalar();
                if (int.TryParse(Result.ToString(), out int AppTypeID))
                {
                    return AppTypeID;
                }
                else
                    return -1;
            }

        }
        static public bool UpdateApplication(int ApplicationID, int ApplicantPersonID, DateTime ApplicationIssueDate, int ApplicationTypeID
            , byte ApplicationStatus, DateTime LastStatusDate, Decimal PaidFee, int CreatedByUserID)
        {
            string Query = "Update Applications " +
                "set ApplicantPersonID = @ApplicantPersonID ," +
                "ApplicationDate = @ApplicationIssueDate ," +
                "ApplicationTypeID = @ApplicationTypeID ," +
                "ApplicationStatus = @ApplicationStatus," +
                "LastStatusDate = @LastStatusDate," +
                " PaidFees = @PaidFee," +
                "CreatedByUserID =@CreatedByUserID " +
                "where ApplicationID = @ApplicationID ";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                cmd.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
                cmd.Parameters.AddWithValue("@ApplicationIssueDate", ApplicationIssueDate);
                cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                cmd.Parameters.Add("@ApplicationStatus", SqlDbType.TinyInt).Value = ApplicationStatus;
                cmd.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
                cmd.Parameters.Add("@PaidFee", SqlDbType.SmallMoney).Value = PaidFee;
                cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                return cmd.ExecuteNonQuery() > 0;

            }
        }
        static public bool DeleteApplication(int ApplicationID)
        {
            string Query = "Delete from Application where ApplicationID = @ApplicationID";

            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                return (cmd.ExecuteNonQuery() > 0);
            }
        }
        static public DataTable GetAllApplications()
        {
            DataTable dt = new DataTable();
            string Query = "Select * from Applications";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }
            return dt;
        }
        static public bool UpdateApplicationStatus(int ApplicationID, byte ApplicationStatus, DateTime LastStatusDate)
        {
            string Query = " Update Applications " +
                "set ApplicationStatus = @ApplicationStatus ," +
                " LastStatusDate = @LastStatusDate " +
                "where ApplicationID = @ApplicationID ";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                cmd.Parameters.Add("@ApplicationStatus", SqlDbType.TinyInt).Value = ApplicationStatus;
                cmd.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
              
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        static public bool DoesApplicationExist(int ApplicationID)
        {
            string Query = "select Found =1 from Applications where ApplicationID = @ApplicationID";
            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@ApplicationID",ApplicationID);
                SqlDataReader DataReader = cmd.ExecuteReader();
                return DataReader.HasRows;
            }
        }
        static public int GetActiveApplicationForPerson(int PersonID, int ApplicationTypeID)
        {
            int ActiveApplicationID = -1;
            string Query = "select ApplicationID from Applications where  ApplicationStatus =1 and ApplicantPersonID=@PersonID " +
                "and ApplicationTypeID= @ApplicationTypeID";
            using (SqlConnection connection = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, connection))
            {
                connection.Open();
                cmd.Parameters.AddWithValue("@PersonID", PersonID);
                cmd.Parameters.AddWithValue("@ApplicationTypeID",ApplicationTypeID);
          
                object Result = cmd.ExecuteScalar();
                if(Result != null && int.TryParse(Result.ToString(),out int AppID))
                {
                    ActiveApplicationID = AppID;
                }
                return ActiveApplicationID;
            }
        }
        static public bool DoesPersonHaveActiveApplication(int PersonID, int ApplicationTypeID)
        {
            return (GetActiveApplicationForPerson(PersonID, ApplicationTypeID) != -1);
        }
        static public int GetActiveApplicationIDForLocalDrivingLicenseApplication( int PersonID , byte LicenseClassID , int ApplicationTypeID  )
        {
            string Query = "select ActiveApplication = A.ApplicationID from Applications A " +
                "inner join LocalDrivingLicenseApplications L " +
                "\r\non A.ApplicationID = L.ApplicationID\r\n" +
                "where A.ApplicantPersonID = @PersonID and A.ApplicationStatus = 1" +
                " and A.ApplicationTypeID = @ApplicationTypeID and L.LicenseClassID = @LicenseClassID ";

            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@PersonID", PersonID);
                cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                cmd.Parameters.Add("@LicenseClassID", SqlDbType.TinyInt).Value = LicenseClassID;

                object Result = cmd.ExecuteScalar();
                if(Result != null && int.TryParse(Result.ToString(), out int AppID))
                {
                    return AppID;
                }
                else
                    return -1;
            }
        }
        static public bool DoesPersonHaveActiveApplicationIDForLocalDrivingLicenseApplication(int PersonID, 
            byte LicenseClassID ,int ApplicationTypeID)
        {
            return (GetActiveApplicationIDForLocalDrivingLicenseApplication(PersonID, LicenseClassID, ApplicationTypeID) != -1);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsInternationalLicenseDataAccess
    {

        //IsExpired

        static public bool FindByDriverID(int DriverID, ref int internationalLicenseID, ref int ApplicationID, ref int IssueUsingLocalLicenseID, ref DateTime IssueDate,
            ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        {
            string Query = "select * from InternationalLicenses where DriverID =@DriverID";
            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@DriverID", DriverID);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    internationalLicenseID = (int)reader["InternationalLicenseID"];
                    ApplicationID = (int)reader["ApplicationID"];
                    IssueUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    IsActive = (bool)reader["IsActive"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    return true;
                }
                return false;
            }
        }
        static public bool FindByApplicationID( int ApplicationID,ref int DriverID, ref int internationalLicenseID, ref int IssueUsingLocalLicenseID, ref DateTime IssueDate,
            ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        {
            string Query = "select * from InternationalLicenses where ApplicationID =@ApplicationID";
            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@DriverID", DriverID);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    internationalLicenseID = (int)reader["InternationalLicenseID"];
                    DriverID = (int)reader["DriverID"];
                    IssueUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    IsActive = (bool)reader["IsActive"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    return true;
                }
                return false;
            }
        }
        static public bool FindByInternationalLicenseID(int internationalLicenseID, ref int DriverID, ref int ApplicationID, ref int IssueUsingLocalLicenseID, ref DateTime IssueDate,
            ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        {
            string Query = "select * from InternationalLicenses where InternationalLicenseID =@internationalLicenseID";
            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@internationalLicenseID", internationalLicenseID);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    DriverID = (int)reader["DriverID"];
                    ApplicationID = (int)reader["ApplicationID"];
                    IssueUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    IsActive = (bool)reader["IsActive"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    return true;
                }
                return false;
            }
        }
        static public bool FindByLocalDrivinglLicenseID(int IssueUsingLocalLicenseID, ref int internationalLicenseID, ref int DriverID, ref int ApplicationID, ref DateTime IssueDate,
                ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        {
            string Query = "select * from InternationalLicenses where IssueUsingLocalLicenseID =@IssueUsingLocalLicenseID";
            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@IssueUsingLocalLicenseID", IssueUsingLocalLicenseID);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    internationalLicenseID = (int)reader["InternationalLicenseID"];
                    DriverID = (int)reader["DriverID"];
                    ApplicationID = (int)reader["ApplicationID"];
                    IssueUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    IsActive = (bool)reader["IsActive"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    return true;

                }
                return false;
            }
        }
        static public int Add(int DriverID, int ApplicationID, int IssueUsingLocalLicenseID, DateTime IssueDate,
             DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            string Query = "\r\ninsert into InternationalLicenses \r\nvalues (@ApplicationID, @DriverID , " +
                "@IssuedUsingLocalLicenseID , @IssueDate, @ExpirationDate , @IsActive  , @CreatedByuserID) ; select Scope_Identity();";
            
            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssueUsingLocalLicenseID);
                cmd.Parameters.Add("@IsActive", System.Data.SqlDbType.Bit).Value = IsActive;
                cmd.Parameters.AddWithValue("@DriverID", DriverID);
                cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                cmd.Parameters.Add("@IssueDate", System.Data.SqlDbType.SmallDateTime).Value = IssueDate;
                cmd.Parameters.AddWithValue("@ExpirationDate", System.Data.SqlDbType.SmallDateTime).Value = ExpirationDate;
                cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                object Result = cmd.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int result))
                {
                    return result;
                }
                else
                    return -1;
            }

        }
        static public bool Update(int InternationalLicenseID, int DriverID, int ApplicationID, int IssueUsingLocalLicenseID, DateTime IssueDate,
             DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            string Query = "Update InternationalLicenses \r\nset ApplicationID = @ApplicationID" +
                " ,\r\nDriverID = @DriverID ,\r\nIssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID " +
                ",\r\nIssueDate = @IssueDate ,\r\nExpirationDate = @ExpirationDate ,\r\nIsActive = @IsActive" +
                " ,\r\nCreatedByUserID = @CreatedByUserID ,\r\nwhere InternationalLicenseID = @InternationalLicenseID";
            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
                cmd.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssueUsingLocalLicenseID);
                cmd.Parameters.Add("@IsActive", System.Data.SqlDbType.Bit).Value = IsActive;
                cmd.Parameters.AddWithValue("@DriverID", DriverID);
                cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                cmd.Parameters.Add("@IssueDate", System.Data.SqlDbType.SmallDateTime).Value = IssueDate;
                cmd.Parameters.AddWithValue("@ExpirationDate", System.Data.SqlDbType.SmallDateTime).Value = ExpirationDate;
                cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        static public bool Delete(int InternationalLicenseID)
        {
            string Query = "delete from InternationalLicenses where InternationalLicenseID = @InternationalLicenseID";
            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
                return cmd.ExecuteNonQuery() > 0;

            }
        }
        static public DataTable GetAllInternationalLicenses()
        {
            DataTable dt = new DataTable();
            string Query = "select * from InternationalLicenses ; ";
            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, con))
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    dt.Load(reader);

            }
            return dt;
        }
        static public bool DoesInternationalLicenseExistByDriverID(int DriverID)
        {
            {
                string Query = "select Found =1  from internationalLicenses where DriverID = @DriverID";
                using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@DriverID", DriverID);
                    object Result = cmd.ExecuteScalar();

                    if(Result != null)
                        return true;
                }
                return false;
            }
        }
        static public bool DoesInternationalLicenseExistByApplicationID(int ApplicationID)
        {
            string Query = "select Found =1  from internationalLicenses where ApplicationID = @ApplicationID";
            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                object Result = cmd.ExecuteScalar();

                if (Result != null)
                    return true;
            }
            return false;
        }
        static public bool DoesInternationalLicenseExistByID(int InternationalLicenseID)
        {
            string Query = "select Found =1  from internationalLicenses where internationalLicensesID = @internationalLicensesID";
            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@internationalLicensesID", InternationalLicenseID);
                object Result = cmd.ExecuteScalar();

                if (Result != null)
                    return true;
            }
            return false;
        }


        static public bool Deactivate(int InternationalLicenseID)
        {
            string Query = "Update InternationalLicenses set IsActive = 1  where internationalLicensesID = @internationalLicensesID";
            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@internationalLicensesID", InternationalLicenseID);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        static public DataTable FilterbyInternationalLicenseID(int InternationalLicenseID)
        {
                DataTable dt = new DataTable();
                string Query = "select * from InternationalLicenses where InternationalLicenseID  = @InternatioalLicenseID; ";
                using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    con.Open();
                cmd.Parameters.AddWithValue("@InternatioalLicenseID", InternationalLicenseID);
                SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                        dt.Load(reader);
                }
                return dt;   
        }
        static public DataTable FilterbyApplicationID(int ApplicationID)
        {

            DataTable dt = new DataTable();
            string Query = "select * from InternationalLicenses where ApplicationID  = @ApplicationID; ";
            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    dt.Load(reader);

            }
            return dt;


        }
        static public DataTable FilterbyDriverID(int DriverID)
        {
            DataTable dt = new DataTable();
            string Query = "select * from InternationalLicenses where DriverID  = @DriverID ; ";
            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@DriverID", DriverID);
                SqlDataReader reader = cmd.ExecuteReader() ;
                if (reader.HasRows)
                    dt.Load(reader);
            }
            return dt;
        }
        static public DataTable FilterbyLocalDrivingLicenseID(int LicenseID)
        {
            DataTable dt = new DataTable();
            string Query = "select * from InternationalLicenses where IssuedUsingLocalLicenseID  = @LicenseID ; ";

            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    dt.Load(reader);
            }
            return dt;
        }
        static public DataTable FilterbyActivation(bool IsActive)
        {
            DataTable dt = new DataTable();
            string Query = "select * from InternationalLicenses where IsActive  = @IsActive ; ";

            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@IsActive", IsActive);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    dt.Load(reader);
            }
            return dt;
        }




    }
}

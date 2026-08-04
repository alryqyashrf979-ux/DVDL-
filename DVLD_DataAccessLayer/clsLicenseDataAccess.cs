using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsLicenseDataAccess
    {
        //Find(LocalDrivingLicenseApplicationID)

        static public bool FindbyLocalDrivingLicenseAppIDID( int LocalDrivingLicenseAppID ,ref int LicenseID, ref int ApplicationID, ref int DriverID, ref int LicenseClassID, ref DateTime IssueDate,
            ref DateTime ExpirationDate, ref string Note, ref decimal PaidFees, ref bool IsActive, ref byte IssueReason, ref int CreatedByUserID)
        {
            string Query = "select L.LicenseID ,L.ApplicationID,L.DriverID ,L.LicenseClass,L.IssueDate ,L.ExpirationDate ,L.Notes ,L.PaidFees,L.IsActive,L.IssueReason ,L.CreatedByUserID" +
                "\r\nfrom Licenses L inner join Applications A on A.ApplicationID = L.ApplicationID " +
                "inner join LocalDrivingLicenseApplications LDL on LDL.ApplicationID \r\n= A.ApplicationID where LocalDrivingLicenseApplicationID =@LocalDrivingLicenseAppID ";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@LocalDrivingLicenseAppID", LocalDrivingLicenseAppID);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        LicenseID = (int)reader["LicenseID"];
                        ApplicationID = (int)reader["ApplicationID"];
                        DriverID = (int)reader["DriverID"];
                        LicenseClassID = (int)reader["LicenseClass"];
                        IssueDate = (DateTime)reader["IssueDate"];
                        ExpirationDate = (DateTime)reader["ExpirationDate"];
                        Note = reader["Notes"] == DBNull.Value ? "" : (string)reader["Notes"];
                        PaidFees = (decimal)reader["PaidFees"];
                        IsActive = (bool)reader["IsActive"];
                        IssueReason = (byte)reader["IssueReason"];
                        CreatedByUserID = (int)reader["CreatedByUserID"];

                        return true;
                    }
                    return false;
                }
            }
        }

        // Find(LicenseID)

        static public bool FindbyLicenseID(int LicenseID, ref int ApplicationID, ref int DriverID, ref int LicenseClassID, ref DateTime IssueDate,
            ref DateTime ExpirationDate, ref string Note, ref decimal PaidFees, ref bool IsActive, ref byte IssueReason, ref int CreatedByUserID)
        {
            string Query = "Select * from Licenses where LicenseID = @LicenseID";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        ApplicationID = (int)reader["ApplicationID"];
                        DriverID = (int)reader["DriverID"];
                        LicenseClassID = (int)reader["LicenseClass"];
                        IssueDate = (DateTime)reader["IssueDate"];
                        ExpirationDate = (DateTime)reader["ExpirationDate"];
                        Note = reader["Notes"] == DBNull.Value ? "" : (string)reader["Notes"];
                        PaidFees = (decimal)reader["PaidFees"];
                        IsActive = (bool)reader["IsActive"];
                        IssueReason = (byte)reader["IssueReason"];
                        CreatedByUserID = (int)reader["CreatedByUserID"];

                        return true;
                    }
                    return false;
                }
            }
        }

        // Find(ApplicationID)
        static public bool FindbyAplicationID(int ApplicationID, ref int LicenseID, ref int DriverID, ref int LicenseClassID, ref DateTime IssueDate,
         ref DateTime ExpirationDate, ref string Note, ref decimal PaidFees, ref bool IsActive, ref byte IssueReason, ref int CreatedByUserID)
        {
            string Query = "Select * from Licenses where ApplicationID = @ApplicationID";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        LicenseID = (int)reader["LicenseID"];
                        DriverID = (int)reader["DriverID"];
                        LicenseClassID = (int)reader["LicenseClass"];
                        IssueDate = (DateTime)reader["IssueDate"];
                        ExpirationDate = (DateTime)reader["ExpirationDate"];
                        Note = reader["Note"] == DBNull.Value ? "" : (string)reader["Note"];
                        PaidFees = (decimal)reader["PaidFees"];
                        IsActive = (bool)reader["IsActive"];
                        IssueReason = (byte)reader["IssueReason"];
                        CreatedByUserID = (int)reader["CreatedByUserID"];

                        return true;
                    }
                    return false;
                }
            }
        }

        // Add 
        static public int Add(int ApplicationID, int DriverID, int LicenseClassID, DateTime IssueDate,
          DateTime ExpirationDate, string Note, decimal PaidFees, bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            string Query = "insert into Licenses \r\nvalues (@ApplicationID,@DriverID,@LicenseClassID,@IssueDate,@ExpirationDate," +
                "@Note,@PaidFees,@IsActive,@IssueReason,@CreatedByUserID) select Scope_Identity()";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                cmd.Parameters.AddWithValue("@DriverID", DriverID);
                cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                cmd.Parameters.AddWithValue("@IssueDate", IssueDate);
                cmd.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);

                if (!string.IsNullOrEmpty(Note))
                    cmd.Parameters.AddWithValue("@Note", Note);
                else
                    cmd.Parameters.AddWithValue("@Note", DBNull.Value);

                cmd.Parameters.AddWithValue("@PaidFees", System.Data.SqlDbType.SmallMoney).Value = PaidFees;
                cmd.Parameters.Add("@IsActive", System.Data.SqlDbType.Bit).Value = IsActive;
                cmd.Parameters.Add("@IssueReason", System.Data.SqlDbType.SmallInt).Value = IssueReason;
                cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                object Result = cmd.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int result))
                    return result;
                else
                    return 0;
            }
        }

        // Edit 
        static public bool Update(int LicenseID, int ApplicationID, int DriverID, int LicenseClassID, DateTime IssueDate,
          DateTime ExpirationDate, string Note, decimal PaidFees, bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            string Query = "update Licenses \r\nset ApplicationID =@ApplicationID , DriverID = @DriverID," +
                " LicenseClassID =@LicenseClassID , IssueDate =@IssueDate , ExpirationDate = @ExpirationDate ," +
                " Note = @Note, PaidFees =@PaidFees ,  IsActive = @IsActive , IssueReason = @IssueReason , " +
                "CreatedByUserID =@CreatedByUserID \r\nwhere LicenseID = @LicenseID";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
                cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                cmd.Parameters.AddWithValue("@DriverID", DriverID);
                cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                cmd.Parameters.AddWithValue("@IssueDate", IssueDate);
                cmd.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);

                if (!string.IsNullOrEmpty(Note))
                    cmd.Parameters.AddWithValue("@Note", Note);
                else
                    cmd.Parameters.AddWithValue("@Note", DBNull.Value);

                cmd.Parameters.AddWithValue("@PaidFees", System.Data.SqlDbType.SmallMoney).Value = PaidFees;
                cmd.Parameters.Add("@IsActive", System.Data.SqlDbType.Bit).Value = IsActive;
                cmd.Parameters.Add("@IssueReason", System.Data.SqlDbType.SmallInt).Value = IssueReason;
                cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                return cmd.ExecuteNonQuery() > 0;

            }
        }
        // IsActiveLicense(int License)

        static public bool IsLicenseActive(int LicenseID)
        {
            string Query = "select IsActive from Licenses where LicenseID = @LicenseID";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
                object Result = cmd.ExecuteScalar();
                if (Result != null && bool.TryParse(Result.ToString(), out bool result))
                    return result;

            }
            return false;
        }

        // Deactivate License
        static public bool DeactivateLicense(int LicenseID)
        {
            string Query = "update Licenses \r\nset IsActive = 0 \r\nwhere LicenseID = @LicenseID";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Get all Driver's Licenses (DriverID)
    
        // Get all Driver's Licenses (LicenseClass)
        static public DataTable GetAllLicensesByLicenseClass(int LicenseClassID)
        {
            DataTable table = new DataTable();
            string Query = "select * from Drivers where LicenseClass =@LicenseClassID";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    table.Load(reader);
            }
            return table;
        }
        // Get all Driver's Licenses (IssueReason)
        static public DataTable GetAllLicensesByIssueReason(byte IssueReason)
        {
            DataTable table = new DataTable();
            string Query = "select * from Drivers where IssueReason =@IssueReason";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@IssueReason", IssueReason);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    table.Load(reader);
            }
            return table;
        }
        //DoesLicenseExist(ApplicationID)
        static public bool DoesLicenesExistByApplicationID(int ApplicationID)
        {
            string Query = "select Found =1 from Licenses where ApplicationID = @ApplicationID \r\n";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                object Result = cmd.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int result))
                    return true;
                else
                    return false;
            }

            }
        //DoesLicenseExist(LicenseID)

        static public bool DoesLicenesExistByLicenseID(int LicenseID)
        {
            string Query = "select Found =1 from Licenses where LicenseID = @LicenseID \r\n";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
                object Result = cmd.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int result))
                    return true;
                else
                    return false;
            }

        }
        static public int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {
            string Query = "select L.LicenseID from People P inner join Drivers D  on D.PersonID  = P.PersonID" +
                " \r\ninner join Licenses L on D.DriverID = L.DriverID \r\nwhere D.PersonID = @PersonID and L.LicenseClass = @LicenseClassID " +
                " and L.IsActive= 1";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@PersonID", PersonID);
                cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                object Result = cmd.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int result)) return result;
                return -1;
            }
        }
    }
}

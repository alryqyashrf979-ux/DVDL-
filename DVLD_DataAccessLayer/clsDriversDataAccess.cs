using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsDriversDataAccess
    {


        // DriverID - int 
        // PersonID - int 
        // CreatedByUserID - int 
        // creationDate  -     DateTime 
        // Add
        static public int AddNewDriver(int PersonID, int CreatedByUserID, DateTime CreationDate)
        {
            string Query = "insert into Drivers \r\nvalues (@PersonID,@CreatedByUserID , @CreationDate) select  SCOPE_IDENTITY(); ";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@PersonID", PersonID);
                cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                cmd.Parameters.AddWithValue("@CreationDate", CreationDate);
                object Result = cmd.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int result))
                {
                    return result;
                }
                else return -1;

            }
        }
        // FindByDriverID
        static public bool FindByDriverID(int DriverID, ref int PersonID, ref int CreatedByUserID, ref DateTime CreationDate)
        {
            string Query = "select * from Drivers where DriverID = @DriverID";
            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@DriverID", DriverID);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PersonID = (int)reader["PersonID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    CreationDate = (DateTime)reader["CreatedDate"];
                    return true;
                }
                return false;
            }

        }
        static public bool FindByNationalNo(string NationalNo ,ref int DriverID, ref int PersonID, ref int CreatedByUserID, ref DateTime CreationDate)
        {
            string Query = "   select D.DriverID,D.PersonID,D.CreatedDate,D.CreatedByUserID " +
                "from Drivers D inner join People P on P.PersonID = D.PersonID where P.NationalNo = @NationalNo";
            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@NationalNo", NationalNo);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DriverID = (int)reader["DriverID"];
                    PersonID = (int)reader["PersonID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    CreationDate = (DateTime)reader["CreatedDate"];
                    return true;
                }
                return false;
            }

        }

             //

        //FindByPersonID
        static public bool FindByPersonID(int PersonID, ref int DriverID, ref int CreatedByUserID, ref DateTime CreationDate)
        {
            string Query = "select * from Drivers where PersonID = @PersonID";
            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@PersonID", PersonID);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DriverID = (int)reader["DriverID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    CreationDate = (DateTime)reader["CreatedDate"];
                    return true;
                }
                return false;
            }

        }
        // Delete Driver if there is no License associated to it 
        static public bool Delete(int DriverID)
        {
            string Query = "delete from Drivers where DriverID = @DriverID";
            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@DriverID", DriverID);
                return cmd.ExecuteNonQuery() > 0;

            }
        }
        // GetAllDriversFromDrivers_View

        static public DataTable GetAllDrivers()
        {
            DataTable dt = new DataTable();
            string Query = "select * from Drivers_View";
            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, con))
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }


            }
            return dt;
        }

        // DoesDriverExistByPersonID 

        static public bool DoesDriverExist(int PersonID)
        {
            string Query = "select Found = 1 from Drivers where PersonID = @PersonID";
            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@PersonID", PersonID);
                object Result = cmd.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int result))
                {
                    return true;
                }
                return false;

            }
        }
        static public bool DoesDriverExist(string NationalNo)
        {
            string Query = "select Found = 1  from Drivers D inner join People P on P.PersonID = D.PersonID where P.NationalNo = @NationalNo";
  
            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@NationalNo", NationalNo);
                object Result = cmd.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int result))
                {
                    return true;
                }
                return false;

            }
        }
        static public DataTable FilterByDriverID(int DriverID)
        {
            DataTable dt = new DataTable();
            string Query = "select DriverID as 'Driver ID', PersonID as 'Person ID' " +
                ", NationalNo as 'National No' , FullName as 'Full Name ' , CreatedDate as 'Date' " +
                ",NumberOfActiveLicenses \r\nas 'Number Of Active Licenses' from   Drivers_View" +
                " where DriverID =@DriverID";
            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@DriverID", DriverID);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }
            return dt;
        }
        static public DataTable FilterByPersonID(int PersonID)
        {
            DataTable dt = new DataTable();
            string Query = "select DriverID as 'Driver ID', PersonID as 'Person ID' ," +
                " NationalNo as 'National No' , FullName as 'Full Name ' , CreatedDate as 'Date'" +
                " ,NumberOfActiveLicenses \r\nas 'Number Of Active Licenses'" +
                " from   Drivers_View where PersonID =@PersonID";
            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@PersonID", PersonID);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }
            return dt;
        }
        static public DataTable FilterByNationalNo(string NationalNo)
        {
            DataTable dt = new DataTable();
            string Query = "select DriverID as 'Driver ID', PersonID as 'Person ID' " +
                ", NationalNo as 'National No' , FullName as 'Full Name ' , CreatedDate as 'Date'" +
                " ,NumberOfActiveLicensesnas 'Number Of Active Licenses' from   Drivers_View " +
                "where NationalNo like '%" + NationalNo+"%'";
            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@NationalNo", NationalNo);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }
            return dt;
        }
        static public DataTable FilterByFullName(string FullName)
        {
            DataTable dt = new DataTable();
            string Query = "select DriverID as 'Driver ID', PersonID as 'Person ID' " +
                ", NationalNo as 'National No' , FullName as 'Full Name ' , CreatedDate as 'Date'" +
                " ,NumberOfActiveLicenses \r\nas 'Number Of Active Licenses' from   Drivers_View " +
                "where FullName like '%" + FullName+"%'";
            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@FullName", FullName);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }
            return dt;
        }
        static public DataTable GetAllLocalDrivingLicensesForDriver(int DriverID)

        {
            DataTable table = new DataTable();
            string Query = "select L.LicenseID as 'License ID ' , A.ApplicationID as 'App ID' , LC.ClassName as 'Class Name' " +
                          ", L.IssueDate as 'Issue Date', L.ExpirationDate as 'Expiration Date' , L.IsActive as 'Is Active' " +
                          "from Licenses L inner join Applications A on A.ApplicationID = L.ApplicationID inner join LicenseClasses LC " +
                          "on LC.LicenseClassID = L.LicenseClass" + " where  L.DriverID = @DriverID and A.ApplicationTypeID = 1;";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@DriverID", DriverID);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    table.Load(reader);
            }
            return table;
        }
        static public DataTable GetAllInternationalDrivingLicensesForDriver(int DriverID)

        {
            DataTable table = new DataTable();
            string Query = " select IL.InternationalLicenseID as ' International License ID ' , A.ApplicationID as 'App ID' " +
                ", LC.ClassName as 'Class Name',\r\n                           IL.IssueDate as 'Issue Date', IL.ExpirationDate as 'Expiration Date' " +
                ", IL.IsActive as 'Is Active' \r\n                          from InternationalLicenses IL inner join Applications A " +
                "on A.ApplicationID = IL.ApplicationID inner join\r\n\t\t\t\t\t\t  Licenses L on L.LicenseID = IL.IssuedUsingLocalLicenseID " +
                "inner join \r\n\t\t\t\t\t\t  LicenseClasses LC on LC.LicenseClassID = L.LicenseClass \r\n                    " +
                "   where  IL.DriverID = @DriverID and A.ApplicationTypeID = 6 ;";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@DriverID", DriverID);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    table.Load(reader);
            }
            return table;
        }
    }
}

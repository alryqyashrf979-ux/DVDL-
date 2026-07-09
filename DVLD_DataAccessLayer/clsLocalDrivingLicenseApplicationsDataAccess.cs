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
        static public bool FindByID(int LocalDrivingLicenseApplicationID, ref int LocalDrivingLicenseAppClassID, ref int ApplicationID )
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
        static public bool FindByApplicationID(int ApplicationID,ref int LocalDrivingLicenseApplicationID, ref int LocalDrivingLicenseAppClassID)
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
            string Query = "select * from LocalDrivingLicenseApplications_View where ClassName like '%"+LicenseClass+"%'";
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
        

    }
}
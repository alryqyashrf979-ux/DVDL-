using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsLicenseClassesDataAccess
    {
        static public bool Find(int LicenseClassID, ref string ClassName, ref string ClassDescription, ref byte MinimumAllowedAge
            , ref byte DefaultValidityLength, ref decimal ClassFees)
        {
            string Query = "select * from LicenseClasses where LicenseClassID =@LicenseClassID ;";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand Cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                Cmd.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
                SqlDataReader reader = Cmd.ExecuteReader();
                while (reader.Read())
                {
                    ClassName = (string)reader["ClassName"];
                    ClassDescription = (string)reader["ClassDescription"];
                    MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                    DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                    ClassFees = (decimal)reader["ClassFees"];

                    return true;
                }
                return false;
            }
        }
        static public int Add( string ClassName, string ClassDescription,  byte MinimumAllowedAge
            ,  byte DefaultValidityLength, decimal ClassFees)
        {
            string Query = "insert into LicenseClasses " +
                "values (@ClassName,@ClassDescription,@MinimumAllowedAge,@DefaultValidityLength,@ClassFees) select Scope_Identity();";
            using (SqlConnection Connection = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using ( SqlCommand cmd = new SqlCommand(Query,Connection))
            {
                Connection.Open();
                object Result =  cmd.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int NewClassID))
                {
                    return NewClassID;
                }
                return -1;
                
            }
        }
        static public bool Update(int LicenseClassID,  string ClassName, string ClassDescription,  byte MinimumAllowedAge
            , byte DefaultValidityLength, decimal ClassFees)
        {
            string Query = "Update LicenseClasses " +
                "set ClassName = @ClassName ," +
                "ClassDescription= @ClassDescription ," +
                "MinimumAllowedAge = @MinimumAllowedAge ," +
                "DefaultValidityLength =@DefaultValidityLength ," +
                "ClassFees = @ClassFees " +
                "where LicenseClassID = @LicenseClassID";
            using (SqlConnection Connection = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
                using ( SqlCommand cmd = new SqlCommand( Query,Connection))
            {
                Connection.Open();
                cmd.Parameters.AddWithValue("@ClassName", ClassName);
                cmd.Parameters.AddWithValue("@ClassDescription", ClassDescription);
                cmd.Parameters.Add("@MinimumAllowedAge", System.Data.SqlDbType.TinyInt).Value = MinimumAllowedAge;
                cmd.Parameters.Add("@DefaultValidityLength",System.Data.SqlDbType.TinyInt).Value = DefaultValidityLength;
                cmd.Parameters.Add("@ClassFees",System.Data.SqlDbType.SmallMoney).Value = ClassFees;

                return cmd.ExecuteNonQuery() > 0;

            }
        }
        static public DataTable GetAllLicenseClasses()
        {
            DataTable dt = new DataTable();
            string Query = "select * from LicenseClasses ";
            using (SqlConnection Connection = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
                using (SqlCommand cmd = new SqlCommand( Query,Connection))
            {
                Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    dt.Load(reader);
            }
            return dt;
        }
    }
}

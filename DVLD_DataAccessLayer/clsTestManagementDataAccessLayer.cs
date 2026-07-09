using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsTestManagementDataAccessLayer
    {
        static public bool Find(int TestTypeID , ref string Title , ref string Description , ref  decimal Fees)
        {
            string Query = "select * from TestTypes where testTypeID = @TestTypeID";
            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    Title = (string)reader["TestTypeTitle"];
                    Description = (string)reader["TestTypeDescription"];
                    Fees = (decimal)reader["TestTypeFees"];
                    return true;
                }
                return false;
            }
        }
        static public bool EditTest(int TestTypeID, string TestTypeTitle, string TestTypeDescription, decimal TestTypeFee)
        {
            string Query = "Update TestTypes " +
                "set TestTypeTitle = @TestTypeTitle ," +
                "TestTypeDescription = @TestTypeDescription ," +
                "TestTypeFees = @TestTypeFee " +
                "where TestTypeID = @TestTypeID";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
                cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);
                cmd.Parameters.Add("@TestTypeFee", SqlDbType.Decimal).Value=TestTypeFee;
                cmd.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
                  int affectedRows = cmd.ExecuteNonQuery();
                return affectedRows > 0;
            }
        }
        static public DataTable GetAllTestsTypes()
        {
            DataTable dt = new DataTable();
            string Query = "select TestTypeID as ID , TestTypeTitle as Title  , TestTypeDescription as Description " +
                ", TestTypeFees as Fees from TestTypes";
            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
                using (SqlCommand cmd = new SqlCommand(Query,con))
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.HasRows)
                    dt.Load(reader);
            }
            return dt;
        }
    }
}

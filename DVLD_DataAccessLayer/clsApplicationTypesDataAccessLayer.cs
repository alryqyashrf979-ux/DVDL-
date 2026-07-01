using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public static class clsApplicationTypesDataAccessLayer
    {
         static public bool GetApplicationTypeByID(int ApplicationTypeID , ref string ApplicationTypeName 
             ,ref decimal ApplicationFee)
        {
            string Query = "select * from ApplicationTypes where ApplicationTypeID = @ApplicationTypeID";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    ApplicationTypeName = (string)sqlDataReader["ApplicationTypeTitle"];
                    ApplicationFee = (decimal)sqlDataReader["ApplicationFees"];
                    return true;
                }
            }
            return false;
        }
        static public int AddNewApplicationTypes(string ApplicationTypeName, decimal ApplicationFee)
        {
            string Query = "\r\ninsert into ApplicationTypes\r\n" +
                "values (@ApplicationTypeName,@ApplicationFee)\r\n\r\nselect SCOPE_IDENTITY()";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@ApplicationTypeName", ApplicationTypeName);
                cmd.Parameters.Add("@ApplicationFee", SqlDbType.SmallMoney).Value = ApplicationFee;
           object Result = cmd.ExecuteScalar();
                if(Result != DBNull.Value)
                {
                    if (int.TryParse(Result.ToString(), out int AppTypeID))
                    {
                        return AppTypeID;
                    }
                    else
                        return -1;
                }
            }
            return -1;
        }
        static public bool UpdatApplicationTypes(int AppID,string ApplicationTypeName, decimal ApplicationFee)
        {
            string Query = "\r\nupdate ApplicationTypes \r\n" +
                "set ApplicationTypeTitle = @ApplicationTypeName ," +
                " ApplicationFees = @ApplicationFee \r\nwhere ApplicationTypeID = @AppID";
            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query,con))
             {
                cmd.Parameters.AddWithValue("@AppID", AppID);
                cmd.Parameters.AddWithValue("@ApplicationTypeName", ApplicationTypeName);
                cmd.Parameters.Add("@ApplicationFee", SqlDbType.SmallMoney).Value = ApplicationFee;
                con.Open();
                 if(cmd.ExecuteNonQuery()>0)
                    return true;
                else
                    return false;
             }
        }
        static public DataTable GetAllAppTypes()
        {
            DataTable dt = new DataTable();
            string Query = "select ApplicationTypeID as ' Application Type ID ', ApplicationTypeTitle as ' Title ' ,ApplicationFees as ' Fees ' from ApplicationTypes \r\n";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query,conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.HasRows)
                {
                    dt.Load(reader);
                }
            }
            return dt;
        }
    }
}

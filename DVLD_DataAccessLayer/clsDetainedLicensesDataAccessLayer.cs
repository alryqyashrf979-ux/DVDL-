using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    public class clsDetainedLicensesDataAccessLayer
    {
        static public bool Find(int DetainID, ref int LicenseID, ref DateTime DetainDate, ref decimal FineFees, ref int CreatedByUserID
            , ref bool IsReleased, ref DateTime ReleasedDate, ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            string Query = "select * from DetainedLicenses where DetainID = @DetainID";
            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@DetainID", DetainID);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    LicenseID = (int)reader["LicenseID"];
                    DetainDate = (DateTime)reader["DetainDate"];
                    FineFees = (Decimal)reader["FineFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsReleased = (bool)reader["IsReleased"];
                    if (reader["ReleasedDate"] == DBNull.Value)
                        ReleasedDate = DateTime.MinValue;
                    else
                        ReleasedDate = (DateTime)reader["ReleasedDate"];
                    if (reader["ReleasedByUserID"] == DBNull.Value)
                        ReleasedByUserID = -1;
                    else
                        ReleasedByUserID = (int)reader["ReleasedByUserID"];
                    if(reader["ReleaseApplicationID"]==DBNull.Value)
                        ReleasedByUserID = -1;
                    else
                        ReleaseApplicationID = (int)reader["ReleaseApplicationID"];
                    return true;
                }
                return false;

            }
        }
        static public bool FindbyLicenseID(int LicenseID, ref int DetainID, ref DateTime DetainDate, ref decimal FineFees, ref int CreatedByUserID
            , ref bool IsReleased, ref DateTime ReleasedDate, ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            string Query = "select top 1  * from DetainedLicenses where LicenseID = @LicenseID  order by DetainID desc";
            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    DetainID = (int)reader["DetainID"];
                    DetainDate = (DateTime)reader["DetainDate"];
                    FineFees = (Decimal)reader["FineFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsReleased = (bool)reader["IsReleased"];
                    if (reader["ReleaseDate"] == DBNull.Value)
                        ReleasedDate = DateTime.MinValue;
                    else
                        ReleasedDate = (DateTime)reader["ReleaseDate"];
                    if (reader["ReleasedByUserID"] == DBNull.Value)
                        ReleasedByUserID = -1;
                    else
                        ReleasedByUserID = (int)reader["ReleasedByUserID"];
                    if (reader["ReleaseApplicationID"] == DBNull.Value)
                        ReleasedByUserID = -1;
                    else
                        ReleaseApplicationID = (int)reader["ReleaseApplicationID"];
                    return true;
                }
                return false;


            }
        }
            static public int Detain(int LicenseID, DateTime DetainDate, decimal FineFees, int CreatedByUserID, bool IsReleased = false)
        {
            string Query = "\r\ninsert into DetainedLicenses (LicenseID,DetainDate,FineFees ,CreatedByUserID ,IsReleased)\r\nvalues (@LicenseID,@DetainDate,@FineFees " +
                ", @CreatedByUserID, @IsReleased)\r\nselect SCOPE_IDENTITY()";
            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
                cmd.Parameters.Add("@DetainDate", SqlDbType.SmallDateTime).Value = DetainDate;
                cmd.Parameters.Add("@FineFees", SqlDbType.SmallMoney).Value = FineFees;
                cmd.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                cmd.Parameters.Add("@IsReleased", SqlDbType.Bit).Value = IsReleased;
                object Result = cmd.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int result))
                    return result;
                else
                    return -1;
            }
        }
        static public bool Release(int DetainID, DateTime ReleaseDate, int ReleaseApplicationID, int ReleaseByUserID, bool IsReleased = true)
        {
            string Query = "update DetainedLicenses \r\nset IsReleased = @IsReleased\r\n, ReleaseDate = @ReleaseDate" +
                "\r\n, ReleasedByUserID = @ReleaseByUserID" +
                           " ,\r\nReleaseApplicationID = @ReleaseApplicationID \r\nwhere DetainID = @DetainID";
            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@DetainID", DetainID);
                cmd.Parameters.Add("@IsReleased", SqlDbType.Bit).Value = IsReleased;
                if (ReleaseDate == DateTime.MinValue)
                cmd.Parameters.AddWithValue("@ReleaseDate", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@ReleaseDate" ,ReleaseDate);
                if(ReleaseApplicationID == -1)
                    cmd.Parameters.AddWithValue("@ReleaseApplicationID", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
                if (ReleaseByUserID == -1)
                    cmd.Parameters.AddWithValue("@ReleaseByUserID", DBNull.Value);
                else
                    cmd.Parameters.Add("@ReleaseByUserID", SqlDbType.Int).Value = ReleaseByUserID;
              
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        static public bool Delete(int DetainID)
        {
            string Query = "\r\ndelete from DetainedLicenses \r\nwhere DetainID = @DetainID";
            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@DetainID", DetainID);
                return cmd.ExecuteNonQuery() > 0;
            }

        }

        static public DataTable GetAllLicenseByStatus(bool IsReleased)
        {
            DataTable dt = new DataTable();
            string Query = "select * from DetainedLicenses_View where IsReleased = @IsReleased";

            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, con))
            {
                con.Open();
                cmd.Parameters.Add("@IsReleased", SqlDbType.Bit).Value = IsReleased;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

            }
            return dt;
        }
        static public bool DoesDetainLicenseRecordExist(int DetainID)
        {
            string Query = "\r\nselect FOund =1 from DetainedLicenses \r\nwhere DetainID = @DetainID";
            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@DetainID", DetainID);
                object Result = cmd.ExecuteScalar();
                if (Result != null) 
                    return true;
                else 
                    return false;
            }
        }
        static public bool IsLicenseDetained(int LicenseID)
        {
            string Query = "\r\n   select top 1 Found =1 from DetainedLicenses where LicenseID = @LicenseID order by DetainDate desc";
            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
                object Result = cmd.ExecuteScalar();
                if (Result != null)
                    return true;
                else
                    return false;
            }
        }
        static public DataTable FilterDetainedLicenseByDetainID(int DetainID)
        {
            DataTable dt = new DataTable();
            string Query = "select * from DetainedLicenses_View where DetainID = @DetainID";

            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@DetainID", DetainID);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

            }
            return dt;
        }
        static public DataTable FilterDetainedLicenseByLicenseID(int LicenseID)
        {
            DataTable dt = new DataTable();
            string Query = "select * from DetainedLicenses_View where LicenseID = @LicenseID";

            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

            }
            return dt;
        }
        static public DataTable FilterDetainedLicenseByFullName(string FullName)
        {
            DataTable dt = new DataTable();
            string Query = "select * from DetainedLicenses_View where FullName like @FullName";

            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@FullName", "%" + FullName + "%");

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }
            return dt;
        }

        static public DataTable FilterDetainedLicenseByNationalNo(string NationalNo)
        {
            DataTable dt = new DataTable();
            string Query = "select * from DetainedLicenses_View where NationalNo like @NationalNo";

            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, con))
            {
                con.Open();
                cmd.Parameters.AddWithValue("@NationalNo", "%" + NationalNo + "%");
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }
            return dt;
        }
        static public DataTable GetAllRecords()
        {
            DataTable dt = new DataTable();
            string Query = "select * from DetainedLicenses_View ";

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




    }
}

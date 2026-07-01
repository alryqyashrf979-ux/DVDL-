using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    static public  class clsUserDataAccessLayer
    {

        static public bool Find(string Username, ref string Password, ref int PersonID, ref bool IsActive, ref int UserID)
        {

            string Query = "select  * from users " +
                "\r\nwhere Username = @Username ";
            using (SqlConnection connection = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@Username", Username);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Password = (string)reader["Password"];
                        PersonID = (int)reader["PersonID"];
                        IsActive = (bool)reader["IsActive"];
                        UserID = (int)reader["UserID"];
                        
                        return true;
                    }
                }
            }
            return false;
        }
        static public bool Find(int UserID,ref string Username, ref string Password, ref int PersonID, ref bool IsActive)
        {

            string Query = "select  * from users " +
                "\r\nwhere UserID = @UserID ";
            using (SqlConnection connection = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@UserID", UserID);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Password = (string)reader["Password"];
                        PersonID = (int)reader["PersonID"];
                        IsActive = (bool)reader["IsActive"];
                        Username = (string)reader["Username"];

                        return true;
                    }
                }
            }
            return false;
        }
        static public bool Find(string Username, string Password, ref int PersonID, ref bool IsActive, ref int UserID)
        {

            string Query = "select  * from users  " + 
                "\r\nwhere Username = @Username and Password = @Password ";
            using (SqlConnection connection = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@Username", Username);
                command.Parameters.AddWithValue("@Password", Password);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        PersonID = (int)reader["PersonID"];
                        IsActive = (bool)reader["IsActive"];
                        UserID = (int)reader["UserID"];
                       
                        return true;
                    }
                }
            }
            return false;
        }
        static public bool DoesUserExist(string UserName)
        {
            string Query = "select 1 from users where username = @UserName";
            using (SqlConnection connection = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@UserName", UserName);
                object Result = command.ExecuteScalar();
                return (Result != DBNull.Value && Result != null);
            }
        }
        static public bool DoesUserExist(int PersonID)
        {
            string Query = "select 1 from users where PersonID = @PersonID";
            using (SqlConnection connection = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(Query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@PersonID", PersonID);
                object Result = command.ExecuteScalar();
                return (Result != DBNull.Value && Result != null);
            }
        }
        static public int AddNewUser(string UserName, string Password, int PersonID, bool IsActive)
        {

            int NewUserID = -1;
            string Query = "insert into Users \r\nvalues ( @PersonID, @UserName ,@Password , @IsActive )\r\nselect SCOPE_IDENTITY();";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(Query, conn))
            {
                conn.Open();
                command.Parameters.Add("@PersonID", SqlDbType.Int).Value = PersonID;
                command.Parameters.Add("@UserName", SqlDbType.NVarChar, 50).Value = UserName;
                command.Parameters.Add("@Password", SqlDbType.NVarChar, 50).Value = Password;
                command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = IsActive;
                object Result = command.ExecuteScalar();
                if (Result != null)
                {
                    if (int.TryParse(Result.ToString(), out int ID))
                    {
                        NewUserID = ID;
                    }
                }
                return NewUserID;
            }
        }
        static public bool UpdateUser(string UserName, bool IsActive , string Password)
        {
            int AffectedRows = 0;
            string Query = "\r\nupdate Users\r\nset IsActive = @IsActive , Password = @Password  \r\nwhere username = @UserName";
            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(Query, con))
            {

                command.Parameters.Add("@UserName", SqlDbType.NVarChar, 50).Value = UserName;
                command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = IsActive;
                command.Parameters.Add("@Password", SqlDbType.NVarChar, 50 ).Value = Password;
                try
                {
                    con.Open();
                    AffectedRows = command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    return false;
                }
                return AffectedRows > 0;
            }
        }

        static public bool UpdateUser(int UserID,string UserName, bool IsActive, string Password)
        {
            int AffectedRows = 0;
            string Query = "\r\nupdate Users\r\nset IsActive = @IsActive , Password = @Password  " +
                ",Username = @UserName \r\nwhere UserID = @UserID";
            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(Query, con))
            {

                command.Parameters.Add("@UserName", SqlDbType.NVarChar, 50).Value = UserName;
                command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = IsActive;
                command.Parameters.Add("@Password", SqlDbType.NVarChar, 50).Value = Password;
                command.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
                try
                {
                    con.Open();
                    AffectedRows = command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    return false;
                }
                return AffectedRows > 0;
            }
        }



        static public  bool DeleteUser(int UserID)
        {
            int AffectedRows = 0;
            string Query = "delete from users where UserID =@UserID";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(Query, conn))
            {
                command.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
                try
                {
                    conn.Open();
                    AffectedRows = command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    return false;
                }
                return AffectedRows > 0;
            }
        }
        static public DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();
            string Query = "select U.UserID as 'User Id ' ,U.UserName as 'Username', P.FirstName +' '+ P.SecondName +' '+ P.LastName as 'Full Name' , U.IsActive from Users U" +
                "\r\ninner join People P on P.PersonID = U.PersonID \r\n";
            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(Query, con))
            {
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                {
                    dt.Load(reader);
                }

            }
            return dt;
        }
        static public DataTable FilterUsersUsingFullName(string FullName)
        {
            DataTable dt = new DataTable();
            string Query = "select U.UserID as 'User Id ' ,U.UserName as 'Username', P.FirstName +' '+ P.SecondName +' '+ P.LastName as 'Full Name' , U.IsActive from Users U "+
                 " inner join People P on P.PersonID = U.PersonID where (P.FirstName + ' ' + P.SecondName + ' ' + P.LastName) "+
                 " like '%' + @FullName + '%'";
            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(Query, con))
            {
                command.Parameters.AddWithValue("@FullName", FullName);
                con.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

            }
            return dt;

        }
        static public DataTable FilterUsersUsingUsername(string username)
        {
            DataTable dt = new DataTable();
            string Query = "select U.UserID as 'User Id ' ,U.UserName as 'Username', P.FirstName +' '+ P.SecondName +' '+ P.LastName as 'Full Name' , U.IsActive from Users U " +
                 " inner join People P on P.PersonID = U.PersonID where username " +
                 " like '%' + @username + '%'";
            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(Query, con))
            {
                command.Parameters.AddWithValue("@username", username);
                con.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

            }
            return dt;

        }
        static public DataTable FilterUsersUsingIsActive(bool IsActive )
        {
            DataTable dt = new DataTable();
            string Query = "select U.UserID as 'User Id ' ,U.UserName as 'Username', P.FirstName +' '+ P.SecondName +' '+ P.LastName as 'Full Name' ," +
                " U.IsActive from Users U " +
                 " inner join People P on P.PersonID = U.PersonID where IsActive " +
                 " = @IsActive ";
            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(Query, con))
            {
                command.Parameters.AddWithValue("@IsActive", SqlDbType.Bit).Value = IsActive;
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }
            return dt;
        }
        static public DataTable FilterUsersUsingPersonID(int PersonID)
        {
            DataTable dt = new DataTable();
            string Query = "select U.UserID as 'User Id ' ,U.UserName as 'Username', P.FirstName +' '+ P.SecondName +' '+ P.LastName as 'Full Name' ," +
                " U.IsActive from Users U " +
                 " inner join People P on P.PersonID = U.PersonID where U.PersonID " +
                 " = @PersonID ";
            using (SqlConnection con = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand command = new SqlCommand(Query, con))
            {
                command.Parameters.AddWithValue("@PersonID", SqlDbType.Int).Value = PersonID;
                con.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }
            return dt;
        }
    }
}
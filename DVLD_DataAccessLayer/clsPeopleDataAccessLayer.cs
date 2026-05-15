using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccessLayer
{
    static public class clsPeopleDataAccessLayer
    {
        static public bool FindPerson(int PersonID,ref string NationalNo, ref string FirstName, ref string SecondName , ref string ThirdName
          ,ref string LastName , ref DateTime DateOfBirth , ref char Gendre , ref string Address , ref string Phone , ref string Email , 
            ref int NationalityCountryID , ref string ImagePath)
        {
            string Query = "  select * from People  where PersonID = @PersonID";
            using (SqlConnection connection = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, connection))
            {
                connection.Open();
                cmd.Parameters.AddWithValue("@PersonID", PersonID);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())

                    {
                        NationalNo = (string)reader["NationalNo"];
                        FirstName = (string)reader["FirstName"];
                        SecondName = (string)reader["SecondName"];
                        ThirdName = (string)reader["ThirdName"];
                       LastName= (string)reader["LastName"];
                        DateOfBirth = (DateTime)reader["DateOfBirth"];
                        Gendre = reader["Gendor"].ToString()[0];
                        Address = (string)reader["Address"];
                        Phone = (string)reader["Phone"];
                        if((reader["Email"]!=DBNull.Value))
                        Email = (string)reader["Email"];
                        else
                            Email = string.Empty;
                        NationalityCountryID = (int)reader["NationalityCountryID"];
                        if (reader["ImagePath"] == DBNull.Value)
                            ImagePath = string.Empty;
                       
                        else
                            ImagePath = (string)reader["ImagePath"];

                        return true;
                    }

            }
            
            }
            return false;
        }



        static public bool FindPerson( string NationalNo,ref  int PersonID, ref string FirstName, ref string SecondName, ref string ThirdName
       , ref string LastName, ref DateTime DateOfBirth, ref char Gendre, ref string Address, ref string Phone, ref string Email,
         ref int NationalityCountryID, ref string ImagePath)
        {
            string Query = "  select * from People  where PersonID = @PersonID";
            using (SqlConnection connection = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, connection))
            {
                connection.Open();
                cmd.Parameters.AddWithValue("@PersonID", PersonID);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())

                    {
                        PersonID = (int)reader["PersonID"];
                        FirstName = (string)reader["FirstName"];
                        SecondName = (string)reader["SecondName"];
                        ThirdName = (string)reader["ThirdName"];
                        LastName = (string)reader["LastName"];
                        DateOfBirth = (DateTime)reader["DateOfBirth"];
                        Gendre = reader["Gendor"].ToString()[0];
                        Address = (string)reader["Address"];
                        Phone = (string)reader["Phone"];
                        if ((reader["Email"] != DBNull.Value))
                            Email = (string)reader["Email"];
                        else
                            Email = string.Empty;
                        NationalityCountryID = (int)reader["NationalityCountryID"];
                        if (reader["ImagePath"] != DBNull.Value)
                            ImagePath = (string)reader["ImagePath"];
                        else
                            ImagePath = string.Empty;

                        return true;
                    }

                }

            }
            return false;
        }




        static public int AddPerson( string NationalNo , string FirstName , string SecondName , string ThirdName , string LastName 
            , DateTime DateOfBirth, char Gendre , string Address , string Phone , string Email , int NationalityCountryID,string ImagePath)
        {
          
            string Query = "\t\t\t\tinsert into People (NationalNo , FirstName , SecondName , ThirdName , LastName , DateOfBirth , Gendor , Address ," +
                "\r\n\t\t\t\tPhone , Email , NationalityCountryID , ImagePath )\r\n\t\t\t\t" +
                "values ( @NaitonalNo , @FirstName,@SecondName,@ThirdName, @LastName " +
                ", @DateOfBirth,@Gendre ,@Address,@Phone ,@Email,@NationalityCountryID,@ImagePath) ; select SCOPE_IDENTITY(); ";
            using (SqlConnection connection = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
                using (SqlCommand command = new SqlCommand(Query,connection))
            {
                connection.Open();
                command.Parameters.Add("@NationalNo",SqlDbType.NVarChar).Value = NationalNo ; 
                command.Parameters.Add("@FirstName",SqlDbType.NVarChar).Value=FirstName ;
                command.Parameters.Add("@SecondName", SqlDbType.NVarChar).Value = SecondName ;
                command.Parameters.Add("@ThirdName", SqlDbType.NVarChar).Value = ThirdName ;
                command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = LastName ;
                command.Parameters.Add("@DateOfBirth", SqlDbType.DateTime).Value = DateOfBirth ;
                command.Parameters.Add("@Gendre", SqlDbType.Char).Value = Gendre ;
                command.Parameters.Add("@Address", SqlDbType.NVarChar).Value = Address ;
                command.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = Phone ;
                if(Email!="")
                command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email ;
                else
                    command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = DBNull.Value;
                command.Parameters.Add("@NationalityCountryID", SqlDbType.Int).Value = NationalityCountryID;
                if(ImagePath != string.Empty)
                command.Parameters.Add("@ImagePath", SqlDbType.NVarChar).Value = ImagePath ; 
                else
                    command.Parameters.Add("@ImagePath", SqlDbType.NVarChar).Value = DBNull.Value;

                object Result = command.ExecuteScalar();
                
                if(Result != DBNull.Value)
                {
                    if (int.TryParse(Result.ToString(), out int ID))
                    {
                        return ID;
                    }
                    else
                        return -1;
                }

            }
            return -1;
        }



        static public bool UpdatePerson(string NationalNo , string FirstName , string SecondName , string ThirdName , string LastName 
            , DateTime DateOfBirth , char Gendre , string Address , string Phone , string Email , int NationalityCountryId , string ImagePath )
        {
            string Query = "Update People \r\nset \r\nNationalNo = @NationalNo " +
                ",\r\nFirstName = @FirstName ,\r\nSecondName = @SecondName " +
                ",\r\nThirdName = @ThirdName ,\r\nLastName = @LastName ," +
                " \r\nDateOfBirth = @DateOfBirth ,\r\nGendor = @Gendre ," +
                "\r\nAddress = @Address,\r\nPhone = @Phone ,\r\nEmail = @Email " +
                ",\r\nNationalityCountryID =@NationalityCountryID " +
                ",\r\nImagePath =@ImagePath \r\nwhere PersonID =@PersonID ";
            using (SqlConnection  connection = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
                using (SqlCommand cmd = new SqlCommand(Query , connection))
            {
                connection.Open();
              cmd.Parameters.Add("@NationalNo", SqlDbType.NVarChar).Value = NationalNo;
              cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = FirstName;
              cmd.Parameters.Add("@SecondName", SqlDbType.NVarChar).Value = SecondName;
              cmd.Parameters.Add("@ThirdName", SqlDbType.NVarChar).Value = ThirdName;
              cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = LastName;
              cmd.Parameters.Add("@DateOfBirth", SqlDbType.DateTime).Value = DateOfBirth;
              cmd.Parameters.Add("@Gendre", SqlDbType.Char).Value = Gendre;
              cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = Address;
              cmd.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = Phone;
                if (Email != "")
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email;
                else
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = DBNull.Value;
                cmd.Parameters.Add("@NationalityCountryID", SqlDbType.Int).Value = NationalityCountryId;
                if (ImagePath != string.Empty)
                    cmd.Parameters.Add("@ImagePath", SqlDbType.NVarChar).Value = ImagePath;
                else
                    cmd.Parameters.Add("@ImagePath", SqlDbType.NVarChar).Value = DBNull.Value;
                int AffectedRows = cmd.ExecuteNonQuery();
                return AffectedRows > 0;
            }

        }

        static public bool DeletePerson(int PersonID )
        {
            if(!DoesPersonExist(PersonID))
            {
                return false;
            }
            string Query = "delete from People where PersonID = @PersonID";
            using (SqlConnection connection = new SqlConnection( clsDVLDDataAccessSettings.ConnectionString))
                using (SqlCommand cmd = new SqlCommand( Query , connection))
            { 
                connection.Open();
                int AffectedRows = cmd.ExecuteNonQuery();
                return AffectedRows > 0;

            }
        }
        static public bool DoesNationalNoExist(string NationalNo)
        {
          
            string Query = "  select 1 from People where NationalNo = @NationalNo";
            using (SqlConnection connection = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, connection))
            {
                connection.Open();
                cmd.Parameters.AddWithValue("@NationalNo", NationalNo);
                object Result = cmd.ExecuteScalar();
             
                return Result != null ;
            }
          
        }

        static public bool DoesPersonExist(int PersonID)
        {
            string Query = "  select 1 from People where PersonnID = @PersonID";
            using (SqlConnection connection = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, connection))
            {
                connection.Open();
                cmd.Parameters.AddWithValue("@PersonID", PersonID);
                object Result = cmd.ExecuteScalar();
                return Result != null;
            }
        }

        static public DataTable GetAllPeople()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString);
            string Query = "select PersonID as 'Person ID ',NationalNo as 'National Number ',FirstName as 'First Name ',SecondName as 'Second Name '" +
                ",ThirdName as 'Third Name',LastName  as 'Last Name',Dateofbirth as 'Birth Date',Gendor as 'Gendre',Address "+
               "   , Phone, Email, CountryNAme as 'Country Name' from People P inner " +
                                             " join Countries C on P.NationalityCountryID = C.CountryID ";
            connection.Open();
            using (SqlCommand cmd = new SqlCommand(Query, connection))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
               
                if(reader.HasRows)
                {

                    dt.Load(reader);
                }
            }
         
                
            connection.Close();
            return dt;
        }
        static public DataTable GetAllCountries()
        {
            DataTable dt = new DataTable();
            string Query = " select CountryName from countries ";

            using (SqlConnection connection = new SqlConnection( clsDVLDDataAccessSettings.ConnectionString))
                using (SqlCommand cmd = new SqlCommand(Query,connection))
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.HasRows)
                    dt.Load(reader);
            }
            return dt;

            
        }
        static public DataTable FilterPeopleByPersonID(int PersonID) {
            DataTable dt = new DataTable();
       
            string Query = "select PersonID as 'Person ID ',NationalNo as 'National Number ',FirstName as 'First Name ',SecondName as 'Second Name '" +
                ",ThirdName as 'Third Name',LastName  as 'Last Name',Dateofbirth as 'Birth Date',Gendor as 'Gendre',Address " +
               "   , Phone, Email, CountryNAme as 'Country Name' from People P inner " +
                                             " join Countries C on P.NationalityCountryID = C.CountryID " +
                                             "where P.PersonID = @PersonID ";
using (SqlConnection connection = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, connection))
            {
                connection.Open() ;
                cmd.Parameters.AddWithValue("@PersonID", PersonID);
                SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {

                        dt.Load(reader);
                    }
            }
           
            return dt;
        }
        static public DataTable FilterPeopleUsingNationalNo(string NationalNo)
        {
            DataTable dt = new DataTable() ;

            string Query = "select PersonID as 'Person ID ',NationalNo as 'National Number ',FirstName as 'First Name ',SecondName as 'Second Name '\r\n     " +
                "           ,ThirdName as 'Third Name',LastName  as 'Last Name',Dateofbirth as 'Birth Date',Gendor as 'Gendre',Address \r\n          " +
                "       , Phone, Email, CountryNAme as 'Country Name' from People P inner \r\n                                          " +
                "   join Countries C on P.NationalityCountryID = C.CountryID \r\n       where p.NationalNo like @NationalNo";
            using (SqlConnection connection = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, connection))
            { 
               connection.Open();
                cmd.Parameters.AddWithValue("@NationalNo", "%" + NationalNo + "%");
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }

            return dt; 
        }
        static public DataTable FilterPeopleUsingFirstName(string FirstName)
        {
            DataTable dt = new DataTable();

            string Query = "select PersonID as 'Person ID ',NationalNo as 'National Number ',FirstName as 'First Name ',SecondName as 'Second Name '\r\n     " +
                "           ,ThirdName as 'Third Name',LastName  as 'Last Name',Dateofbirth as 'Birth Date',Gendor as 'Gendre',Address \r\n          " +
                "       , Phone, Email, CountryNAme as 'Country Name' from People P inner \r\n                                          " +
                "   join Countries C on P.NationalityCountryID = C.CountryID \r\n       where p.FirstName like @FirstName";
            using (SqlConnection connection = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, connection))
            {
                connection.Open();
                cmd.Parameters.AddWithValue("@FirstName", "%" + FirstName + "%");
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }

            return dt;
        }
        static public DataTable FilterPeopleUsingSecondName(string SecondName)
        {
            DataTable dt = new DataTable();

            string Query = "select PersonID as 'Person ID ',NationalNo as 'National Number ',FirstName as 'First Name ',SecondName as 'Second Name '\r\n     " +
                "           ,ThirdName as 'Third Name',LastName  as 'Last Name',Dateofbirth as 'Birth Date',Gendor as 'Gendre',Address \r\n          " +
                "       , Phone, Email, CountryNAme as 'Country Name' from People P inner \r\n                                          " +
                "   join Countries C on P.NationalityCountryID = C.CountryID \r\n       where p.SecondName like @SecondName";
            using (SqlConnection connection = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, connection))
            {
                connection.Open();
                cmd.Parameters.AddWithValue("@SecondName", "%" + SecondName + "%");
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }

            return dt;
        }
        static public DataTable FilterPeopleUsingThirdName(string ThirdName)
        {
            DataTable dt = new DataTable();

            string Query = "select PersonID as 'Person ID ',NationalNo as 'National Number ',FirstName as 'First Name ',SecondName as 'Second Name '\r\n     " +
                "           ,ThirdName as 'Third Name',LastName  as 'Last Name',Dateofbirth as 'Birth Date',Gendor as 'Gendre',Address \r\n          " +
                "       , Phone, Email, CountryNAme as 'Country Name' from People P inner \r\n                                          " +
                "   join Countries C on P.NationalityCountryID = C.CountryID \r\n       where p.ThirdName like @ThirdName";
            using (SqlConnection connection = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, connection))
            {
                connection.Open();
                cmd.Parameters.AddWithValue("@ThirdName", "%" + ThirdName + "%");
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }
            return dt;
        }
        static public DataTable FilterPeopleUsingLastName(string LastName)
        {
            DataTable dt = new DataTable();

            string Query = "select PersonID as 'Person ID ',NationalNo as 'National Number ',FirstName as 'First Name ',SecondName as 'Second Name '\r\n     " +
                "           ,ThirdName as 'Third Name',LastName  as 'Last Name',Dateofbirth as 'Birth Date',Gendor as 'Gendre',Address \r\n          " +
                "       , Phone, Email, CountryNAme as 'Country Name' from People P inner \r\n                                          " +
                "   join Countries C on P.NationalityCountryID = C.CountryID \r\n       where p.LastName like @LastName";
            using (SqlConnection connection = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, connection))
            {
                connection.Open();
                cmd.Parameters.AddWithValue("@LastName", "%" + LastName + "%");
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }

            return dt;
        }

        static public DataTable FilterPeopleUsingNationality(string Nationality)
        {
            DataTable dt = new DataTable();

            string Query = "select PersonID as 'Person ID ',NationalNo as 'National Number ',FirstName as 'First Name ',SecondName as 'Second Name '\r\n     " +
                "           ,ThirdName as 'Third Name',LastName  as 'Last Name',Dateofbirth as 'Birth Date',Gendor as 'Gendre',Address \r\n          " +
                "       , Phone, Email, CountryNAme as 'Country Name' from People P inner \r\n                                          " +
                "   join Countries C on P.NationalityCountryID = C.CountryID \r\n       where C.CountryName like @Nationality";
            using (SqlConnection connection = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, connection))
            {
                connection.Open();
                cmd.Parameters.AddWithValue("@Nationality", "%" + Nationality + "%");
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }

            return dt;
        }
        static public DataTable FilterPeopleUsingGendre(char Gendre)
        {
            DataTable dt = new DataTable();

            string Query = "select PersonID as 'Person ID ',NationalNo as 'National Number ',FirstName as 'First Name ',SecondName as 'Second Name ' "+
                     "    , ThirdName as 'Third Name',LastName as 'Last Name',Dateofbirth as 'Birth Date',Gendor as 'Gendre',Address "+
                   "  , Phone, Email, CountryNAme as 'Country Name' from People P inner "+
                                                               "    join Countries C on P.NationalityCountryID = C.CountryID      where p.Gendor like @Gendre ";
            using (SqlConnection connection = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, connection))
            {
                connection.Open();
                cmd.Parameters.AddWithValue("@Gendre", "%" + Gendre + "%");
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }

            return dt;
        }
        static public DataTable FilterPeopleUsingPhone(string Phone)
        {
            DataTable dt = new DataTable();

            string Query = "select PersonID as 'Person ID ',NationalNo as 'National Number ',FirstName as 'First Name ',SecondName as 'Second Name ' " +
                     "    , ThirdName as 'Third Name',LastName as 'Last Name',Dateofbirth as 'Birth Date',Gendor as 'Gendre',Address " +
                   "  , Phone, Email, CountryNAme as 'Country Name' from People P inner " +
                                                               "    join Countries C on P.NationalityCountryID = C.CountryID      where p.Phone like @Phone ";
            using (SqlConnection connection = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, connection))
            {
                connection.Open();
                cmd.Parameters.AddWithValue("@Phone", "%" + Phone + "%");
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }

            return dt;
        }
        static public DataTable FilterPeopleUsingEmail(string  Email)
        {
            DataTable dt = new DataTable();

            string Query = "select PersonID as 'Person ID ',NationalNo as 'National Number ',FirstName as 'First Name ',SecondName as 'Second Name ' " +
                     " , ThirdName as 'Third Name',LastName as 'Last Name',Dateofbirth as 'Birth Date',Gendor as 'Gendre',Address " +
                   " , Phone, Email, CountryNAme as 'Country Name' from People P inner " +
                                                               " join Countries C on P.NationalityCountryID = C.CountryID  " +
                                                               " where p.Email collate latin1_general_CS_As like @Email ";
            using (SqlConnection connection = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, connection))
            {
                connection.Open();
                cmd.Parameters.AddWithValue("@Email", "%" + Email + "%");
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }

            return dt;
        }
        static public string GetCountryName(int CountryId)
        {
            object Result = null;
            string Query = " select CountryName from countries where CountryID = @CountryId";
            using (SqlConnection conn = new SqlConnection(clsDVLDDataAccessSettings.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(Query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@CountryId", CountryId);
                Result = cmd.ExecuteScalar();
            

            }
            if (Result != null)
            {
                return (string)Result;
            }
            else
                return "";
        }

    }
}

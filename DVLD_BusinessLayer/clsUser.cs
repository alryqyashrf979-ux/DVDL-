using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsUser
    {
        enum enMode { Add = 0, Update = 1 };
        enMode Mode = enMode.Add;
        private int _UserID;
        public int UserID { get { return _UserID; } }
      
        public int PersonID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        private clsPeople _PersonInfo ;
        public clsPeople PersonInfo { get { if (_PersonInfo != null) return _PersonInfo; else return new clsPeople();  } }


        public clsUser()
        {
            _UserID = -1;
            Password = string.Empty;
            IsActive = true;
            Username = string.Empty;
            PersonID = -1;
            Mode = enMode.Add;
        }
        public clsUser(int UserID, string Username, string Password ,int PersonID, bool IsActive)
        {
            _UserID = UserID;
            this.Password = Password;
            _PersonInfo = clsPeople.FindPerson(PersonID);
            this.IsActive = IsActive;
            this.Username = Username;
            this.PersonID = PersonID;
            Mode = enMode.Update;
        }

        static public clsUser Find(string Username, string Password)
        {
            bool IsActive = true;
            int PersonID = -1;
            int UserID = -1;
            bool IsFound = clsUserDataAccessLayer.Find(Username, Password, ref PersonID, ref IsActive, ref UserID);
            if (IsFound)
            {
                return new clsUser(UserID, Username, Password, PersonID, IsActive);
            }
            return null;
        }
        static public clsUser Find(int UserID)
        {

            bool IsActive = true;
            int PersonID = -1;
            string Username = string.Empty;
          string Password = string.Empty;   
            bool IsFound = clsUserDataAccessLayer.Find(UserID,ref Username, ref Password, ref PersonID, ref IsActive);
            if (IsFound)
            {
                return new clsUser(UserID, Username, Password, PersonID, IsActive);
            }
            return null;
        }
        static public clsUser Find(string Username)
        {
            bool IsActive = true;
            string Password = string.Empty;
            int PersonID = -1;
            int UserID = -1;
            bool IsFound = clsUserDataAccessLayer.Find(Username, ref Password, ref PersonID, ref IsActive, ref UserID);
            if (IsFound)
            {
                return new clsUser(UserID, Username, Password,PersonID, IsActive);
            }
            return null;
        }
        static public bool DoesUserExist(string Username)
        {
            return clsUserDataAccessLayer.DoesUserExist(Username);
        }
        static public bool DoesUserExist(int  PersonID)
        {
            return clsUserDataAccessLayer.DoesUserExist(PersonID);
        }
        private bool _Add()
        {
            int NewUserID = clsUserDataAccessLayer.AddNewUser(Username, Password, PersonID, IsActive);

            return NewUserID != -1;
        }

        private bool _Update()
        {
            return clsUserDataAccessLayer.UpdateUser(UserID,Username, IsActive, Password);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:
                    {
                        if (_Add())
                        {
                            return true;
                        }
                        else
                        { return false; }

                    }
                case enMode.Update:
                    {
                        if (_Update())
                        {
                            return true;
                        }
                        else
                        { return false; }

                    }
                default:
                    return false ;
            }
        }

        static public bool Delete(int UserID)
        {
            return clsUserDataAccessLayer.DeleteUser(UserID);
        }

        static public DataTable GetAllUsers()
        {
            return clsUserDataAccessLayer.GetAllUsers();
        }

        static public DataTable FilterUsersByFullName(string FullName)
        {
            return clsUserDataAccessLayer.FilterUsersUsingFullName(FullName);
        }

        static public DataTable FilterUsersByUsername(string Username)
        {
            return clsUserDataAccessLayer.FilterUsersUsingUsername(Username);
        }
        static public DataTable FilterUsersByIsActive(bool IsActive)
        {
            return clsUserDataAccessLayer.FilterUsersUsingIsActive(IsActive);
        }
        static public DataTable FilterUsersByPersonID(int PersonID)
        {
            return clsUserDataAccessLayer.FilterUsersUsingPersonID(PersonID);
        }





    }
}

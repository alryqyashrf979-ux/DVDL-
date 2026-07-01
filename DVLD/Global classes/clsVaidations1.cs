using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DVLD.Global_classes
{
    public static class clsVaidations1
    {
        static public bool IsValidEmail(string email)
        {
            // this code is from .Net itself 
            // it acceptes to many formats 
            // but sometimes validate some kind of emails that you may not want .
            try
            {
                MailAddress mail = new MailAddress(email);
                return mail.Address.Equals(email);
            }
            catch
            {
                return false;
            }
        }
        public static bool IsFloat(string Number)
        {
            var Pattern = @"^[0-9]*(?:\.[0-9]*)?$";
            var regex = new Regex(Pattern);


            return regex.IsMatch(Number);
        }
        public static bool IsIntegar(string Number)
        {
            var Pattern = @"^[0-9]*$";
            var regex = new Regex(Pattern);
            return regex.IsMatch(Number);
        }
        public static bool IsEmail(string Email)
        {
            // faster and can control what format to accept

            // both of the methods dont ensure that the emails exist , when we study APIs , we will see how to verify emails 
            var Pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";
            var regex = new Regex(Pattern);
            return regex.IsMatch(Email);

        }
        public static bool IsNumber(string Number)
        {
            return (IsFloat(Number)||IsIntegar(Number));
        }
        public static bool IsPersonAgeGreaterThanSpecificAge(DateTime dateOfBirth, int age)
        {
            DateTime today = DateTime.Today;

            int personAge = today.Year - dateOfBirth.Year;

            // Check if birthday has not occurred yet this year
            if (dateOfBirth.Date > today.AddYears(-personAge))
                personAge--;

            return personAge >= age;
        }
    }
}

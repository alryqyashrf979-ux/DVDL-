using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
namespace DVLD_BusinessLayer
{
    static  class clsUtil
    {
        static public bool IsValidEmail(string email)
        {
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

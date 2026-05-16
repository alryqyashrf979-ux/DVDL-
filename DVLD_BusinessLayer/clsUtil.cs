using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
namespace DVLD_BusinessLayer
{
    static  public class clsUtil
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

        static public bool CopyImageFromPlaceToAnotherAndGiveItAGuid(string sourceFilePath, string targetDirectory)
        {

            try
            {
                // 2. Define the target directory on the other drive
                // Change "D:\\TargetFolder" to your actual destination drive and folder
                

                // Create the directory if it doesn't exist yet
                if (!Directory.Exists(targetDirectory))
                {
                    Directory.CreateDirectory(targetDirectory);
                }
                // 3. Generate a unique GUID and grab the original file extension
                string uniqueId = Guid.NewGuid().ToString();
                string extension = Path.GetExtension(sourceFilePath); // e.g., ".jpg" or ".png"

                // Combine them to create the new file name (e.g., "1234abcd-...jpg")
                string newFileName = uniqueId + extension;

                // 4. Combine target directory and new file name for the final path
                string destinationFilePath = Path.Combine(targetDirectory, newFileName);

                // 5. Copy the file to the new location (and rename it in the process) 
                 File.Copy(sourceFilePath, destinationFilePath, overwrite: true);

                // Success message
                //MessageBox.Show($"Photo successfully saved to:\n{destinationFilePath}",
                //                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception)
            {
                // Handle potential errors (e.g., Drive not found, Permission issues)
                return false;
            }

        }
    }
}

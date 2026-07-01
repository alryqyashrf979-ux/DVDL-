using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DVLD_BusinessLayer
{
    static  public class clsUtil
    {
     static  public string GenerateGuid()
        {
            return Guid.NewGuid().ToString();
        }
        static public bool CreateDirectoryIfDoesNotExist(string Path)
        {
            if (Directory.Exists(Path))
            {
                return true;
            }
            else
            {
                try
                {
                    Directory.CreateDirectory(Path);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating folder: " + ex.Message);
                    return false;
                }
            }
        }

        static public string ReplaceFileNameWithGuid(string FileName)
        {
            string uniqueId = GenerateGuid();
            string extension = Path.GetExtension(FileName);
            return uniqueId + extension;
        }

        static public bool CopyImageFromPlaceToAnotherAndGiveItAGuid( ref string sourceFilePath, string targetDirectory)
        {
            try
            {
                // 2. Define the target directory on the other drive
                // Change "D:\\TargetFolder" to your actual destination drive and folder
                

                // Create the directory if it doesn't exist yet
                if (!CreateDirectoryIfDoesNotExist(targetDirectory))
                {
                    return false;
                }
                // 3. Generate a unique GUID and grab the original file extension
                // e.g., ".jpg" or ".png"

                // Combine them to create the new file name (e.g., "1234abcd-...jpg")
                string newFileName = targetDirectory + ReplaceFileNameWithGuid(sourceFilePath);

                // 4. Combine target directory and new file name for the final path
                string destinationFilePath = Path.Combine(targetDirectory, newFileName);

                // 5. Copy the file to the new location (and rename it in the process) 
                 File.Copy(sourceFilePath, destinationFilePath, overwrite: true);

                // Success message
                //MessageBox.Show($"Photo successfully saved to:\n{destinationFilePath}",
                //
                //   "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sourceFilePath = destinationFilePath;
                return true;
            }
            catch (IOException Ioex)
            {
                MessageBox.Show(Ioex.Message, "Error .", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
    }
}

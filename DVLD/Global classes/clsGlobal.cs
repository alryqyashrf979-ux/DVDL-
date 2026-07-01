using DVLD_BusinessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DVLD
{
    public static class clsGlobal
    {
        public static clsUser CurrentUser;

        public static bool SaveLoginInfo(string Username, string Password)
        {

            try
            {
                string CurrentDirectory = Directory.GetCurrentDirectory();

                string FilePath = CurrentDirectory + "\\Remeber.txt";

                if (!string.IsNullOrEmpty(Username) && File.Exists(FilePath))
                {
                    File.Delete(FilePath);
                    return true;

                }
                string DataToSave = Username + "#" + Password;

                using (StreamWriter ST = new StreamWriter(FilePath))
                {
                    ST.WriteLine(DataToSave);
                    return true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }



        }
        public static bool GetStoredCredentials(ref string Username, ref string Password)
        {
            try
            {
                string CurrentDirectory = System.IO.Directory.GetCurrentDirectory();
                string FilePath = CurrentDirectory + "\\Remeber.txt";

                if (File.Exists(FilePath))
                {


                    using (StreamReader SR = new StreamReader(FilePath))
                    {
                        string Line = string.Empty;
                        while ((Line = SR.ReadLine()) != null)
                        {
                            string[] ListOfWord = Line.Split('#');

                            Username = ListOfWord[0].Trim();
                            Password = ListOfWord[1].Trim();
                        }

                    }
                    return true;
                }
                else
                    return false;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using DVLD_Buisness;
using Microsoft.Win32;
using System.Diagnostics;
using System.Security.Cryptography;


namespace C19_Project.OtherClasses
{
    internal class ClsGlobal
    {
         public static clsUser CurrentUser;

         public static string filePath = System.IO.Directory.GetCurrentDirectory() + @"\\RememberData.txt";

       
        public static void LogExecption(string ErrorMsg, string SourceName, EventLogEntryType Type)
        {
            if (!EventLog.SourceExists(SourceName))
            {
                EventLog.CreateEventSource(SourceName, "Application");
            }
            EventLog.WriteEntry(SourceName, ErrorMsg, Type);
        }
        public static void LogExecption(Exception ex, string SourceName, EventLogEntryType Type)
        {
            if (!EventLog.SourceExists(SourceName))
            {
                EventLog.CreateEventSource(SourceName, "Application");
            }
            EventLog.WriteEntry(SourceName, ex.Message + "\n" + ex.Source , Type);
        }
        public static bool GetStoredCredentialUsingRegisty(ref string Username, ref string Password)
        {
            // Read The values
            const string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";
            const string UserNameValue = "UserName";
            const string PasswordValue = "Password";

            try
            {

                Username = Registry.GetValue(keyPath, UserNameValue, null) as string;
                Password = Registry.GetValue(keyPath, PasswordValue, null) as string;

                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }

        }
        public static bool RememberUsernameAndPasswordUsingRegisty( string Username, string Password)
        {
            // write the values
            const string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";
            const string UserNameValue = "UserName";
            const string PasswordValue = "Password";

            try
            {
                Registry.SetValue(keyPath,UserNameValue,  Username, RegistryValueKind.String);
                Registry.SetValue(keyPath,PasswordValue,  Password, RegistryValueKind.String);

                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }

        }
        public static bool RememberUsernameAndPassword(string Username, string Password)
        {

            try
            {
                ////this will get the current project directory folder.
                //string currentDirectory = System.IO.Directory.GetCurrentDirectory();


                //// Define the path to the text file where you want to save the data
                //string filePath = currentDirectory + "\\data.txt";

                //incase the username is empty, delete the file
                if (Username == "" && File.Exists(filePath))
                {
                    File.Delete(filePath);
                    return true;
                }

                // concatonate username and passwrod withe seperator.
                string dataToSave = Username + "#//#" + Password;

                // Create a StreamWriter to write to the file
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Write the data to the file
                    writer.WriteLine(dataToSave);

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }

        }

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            //this will get the stored username and password and will return true if found and false if not found.
            try
            {
                if (File.Exists(filePath))
                {
                    // Create a StreamReader to read from the file
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        // Read data line by line until the end of the file
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            Console.WriteLine(line); // Output each line of data to the console
                            string[] result = line.Split(new string[] { "#//#" }, StringSplitOptions.None);

                            Username = result[0];
                            Password = result[1];
                        }
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }

        }
    }
}

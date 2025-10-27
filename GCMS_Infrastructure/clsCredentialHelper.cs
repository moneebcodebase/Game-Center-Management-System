using System;
using CredentialManagement;

namespace GCMS_Infrastructure
{

    //this class is static to prevent any object creation form this class
    //all of the methods will be static inside this class

    /// <summary>
    /// this class used to interact with windows credentials
    /// </summary>
    public static class clsCredentialHelper
    {
        //This method is to save Login credentials into windows credentials
        public static void SaveCredential(string username, string password)
        {
            using (var cred = new Credential())
            {
                cred.Target = "GCMS_Login";
                cred.Username = username;
                cred.Password = password;
                cred.Type = CredentialType.Generic;
                cred.PersistanceType = PersistanceType.LocalComputer;
                cred.Save();
            }
        }

        //This method is to retrive a saved login credentials from windows credentials
        //this function is (tuple deconstruction return type) 
        public static (string username, string password) GetCredential()
        {
            using (var cred = new Credential())
            {
                cred.Target = "GCMS_Login";
                if (cred.Load())
                {
                    return (cred.Username, cred.Password);
                }
                else
                {
                    return (null, null);
                }
            }
        }
    }
}

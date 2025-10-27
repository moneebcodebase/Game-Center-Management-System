using System;
using System.Text;
using System.Security.Cryptography;


namespace GCMS_Infrastructure
{

    //this class is static to prevent any object creation form this class
    //all of the methods will be static inside this class

    /// <summary>
    /// This class used for encryption 
    /// </summary>
    public static class clsEncryptionHelper
    {
        //Hashing algorithm
        public static string ComputeHash(string input)
        {

            // Create an instance of the SHA-256
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash value from the UTF-8 encoded input string
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert the byte array to a lowercase hexadecimal string
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}

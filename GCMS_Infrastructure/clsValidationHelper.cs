using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;



namespace GCMS_Infrastructure
{
    /// <summary>
    /// This class is used to help with validation
    /// </summary>
    
    //This class is static to prevent creating an object from it
    public static class clsValidationHelper
    {
        public static bool IsEmailValid(string Email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(Email, pattern);
        }
        public static bool ContainsNumber(string input)
        {
            return input.Any(char.IsDigit);
        }
        public static bool ContainsLetter(string input)
        {
            return input.Any(char.IsLetter);
        }
        public static bool IsEmptyOrWhiteSpaces(string input)
        {
            return string.IsNullOrWhiteSpace(input);
        }
        public static bool ContainsSymbols(string input)
        {
            // Returns true if any char other than letters, digits, or underscore found
            return Regex.IsMatch(input, @"[^a-zA-Z0-9_]");
        }
        public static bool IsValidCharacterRange(int MaxLenght, string Input)
        {
            return (Input.Length <= MaxLenght);
        }
    }
}

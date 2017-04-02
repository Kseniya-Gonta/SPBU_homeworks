using System;
using System.Text.RegularExpressions;

namespace RegExp
{
    public abstract class Validator
    {
        internal abstract string Pattern { get; }
        internal abstract string Entity { get; }

        public static string success = "Valid ";
        public static string fail = "Not valid ";


        public void CheckValidity(string str)
        {
            Console.WriteLine((Regex.Match(str, Pattern).Success ? success : fail) + Entity + ".");
        }

        public bool CheckValidness(string str)
        {
            if (str == String.Empty)
            {
                throw new ArgumentNullException();
            }
            return Regex.Match(str, Pattern).Success;
        }
    }
}
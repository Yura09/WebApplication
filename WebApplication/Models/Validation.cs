using System;

namespace WebApplication.Models
{
    public class Validation
    {

        public static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
        public static int CheckNumber(int cur)
        {
            if (cur < 0 || cur > 1000000)
            {
                throw new ArgumentException("incorrect input(number[0, 1000000])");
            }
           
            return cur;
        }

        public static string CheckString(string str) 
        {
            if (str.Length == 0)
            {
                return str;
            }
            return !IsDigitsOnly(str) ? str : throw new ArgumentException("incorrect input (without digits)");
        }
    }
}
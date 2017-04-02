using System;

namespace Palindrom
{
    internal sealed class PalindromChecker
    {
        public static bool IsPalindrom(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException();
            }
            int i = 0;
            int j = str.Length - 1;
            while (i <= j)
            {
                if (IsDelimiter(str[i]))
                {
                    i++;
                    continue;
                }
                if (IsDelimiter(str[j]))
                {
                    j--;
                    continue;
                }
                if (!Char.ToLower(str[i]).Equals(Char.ToLower(str[j])))
                {
                    return false;
                }
                i++;
                j--;
            }
            return true;
        }

        private static bool IsDelimiter(char symbol)
        {
            string ignoredSymbolsString = ""
            char[] ignoredSymbols = {',', ' ', '\t', '.', '!', '?', '“', '”', ';', '\'', ':', '‘', '’'};

            //foreach (char t in ignoredSymbols)
            /*{
                if (symbol == t)
                {
                    return true;
                }
            }
            return false;*/
            return ignoredSymbolsString.Contains(symbol.ToString());
            //return ignoredSymbols.Any(t => symbol == t);
        }
    }
}
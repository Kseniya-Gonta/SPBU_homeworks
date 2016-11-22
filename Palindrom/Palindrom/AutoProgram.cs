using System;
using System.Linq;

namespace Palindrom
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Привет! Меня зовут Дром и я могу проверить," +
                          " выживет ли твоя срока после взрыва в андроном коллайдере.\n");
            Console.Write("Какая твоя любимая строка?\n");
            string str = args.First().ToLowerInvariant();
            Console.WriteLine(str);
            if (IsPalindrom(str))
            {
                Console.WriteLine("Всё в порядке, вы со строкой в безопасности ;)");
            }
            else
            {
                Console.WriteLine("Очень жаль! Тебе нужно остановить взрыв в коллайдере или видоизменить строку.");
            }
        }

        static bool IsPalindrom(string str)
        {
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
                if (str[i] != str[j])
                {
                    return false;
                }
                i++;
                j--;
            }
            return true;
        }

        static bool IsDelimiter(char symbol)
        {
            char[] ignoredSymbols = {',', ' ', '\t', '.', '!', '?', '“', '”', ';', '\'', ':', '(', ')', '‘', '’', '-'};
            foreach (char t in ignoredSymbols)
            {
                if (symbol == t)
                {
                    return true;
                }
            }
            return false;
            //return ignoredSymbols.Any(t => symbol == t);
        }
    }
}

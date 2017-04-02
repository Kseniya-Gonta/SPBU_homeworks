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

            while (true)
            {
                string candidateToPalindrom = Console.ReadLine();
                if (candidateToPalindrom == "")
                {
                    return;
                }
                if (PalindromChecker.IsPalindrom(candidateToPalindrom))
                {
                    Console.WriteLine("Всё в порядке, вы со строкой в безопасности ;)");
                }
                else
                {
                    Console.WriteLine("Очень жаль! Тебе нужно остановить взрыв в коллайдере или видоизменить строку.");
                }
            }

        }


    }
}

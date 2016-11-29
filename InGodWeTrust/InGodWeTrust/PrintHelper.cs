using System;
using System.Collections.Generic;
using InGodWeTrust.Entities;

namespace InGodWeTrust
{
    public static class PrintHelper
    {
        public static void PrintPairs(List<Human> pairs)
        {
            if (pairs == null)
            {
                throw new ArgumentNullException();
            }
            var amount = pairs.Count;
            pairs.Reverse();

            var topPosition = Console.CursorTop - 1;
            var top = topPosition;
            Console.SetCursorPosition(0, topPosition);

            for (var i = 0; i < amount; i++)
            {
                pairs[i].Print();
                topPosition -= 2;
                Console.SetCursorPosition(0, topPosition);
            }
            Console.SetCursorPosition(0, top + 1);
        }    }
}
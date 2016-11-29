using System;
using InGodWeTrust.Entities;

namespace InGodWeTrust.Helpers
{
    public class RandomHelper
    {
        private static readonly Random Random = new Random();
        public int StudentAge()
        {
            return Random.Next(17, 25);
        }

        public int ParentAge()
        {
            return Random.Next(37, 45);
        }

        public Sex RandomSex()
        {
            return (Sex) Random.Next(2);
        }


        public double RandomGpa()
        {
            return Random.Next(4, 5);
        }

        public double RandomMoney()
        {
            return Random.Next((int) Math.Log10(4), (int) Math.Log10(5));
        }

        public HumanType RandomEntity()
        {
            return (HumanType) Random.Next(4);
        }

        public HumanType RandomStudentEntity()
        {
            return (HumanType) Random.Next(2);
        }

    }
}
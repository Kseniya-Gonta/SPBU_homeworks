using System;

namespace InGodWeTrust
{
    public class UniversityGod: IGod
    {
        public enum StorageFormat { Student, Botan, Parent, CoolParent }

        private readonly Random _random = new Random();

        public Human CreateHuman(StorageFormat format, Sex sex)
        {
            switch (format) {
                case StorageFormat.Student:
                    return new Student();

                case StorageFormat.Botan:
                    return new Botan();

                case StorageFormat.Parent:
                    return new Parent();

                case StorageFormat.CoolParent:
                    return new CoolParent();

                default:
                    throw new ArgumentException("An invalid format: " + format.ToString());
            }
        }

        public Human CreateHuman()
        {
            return CreateHuman((Sex)_random.Next(2));
        }

        public Human CreateHuman(Sex sex)
        {
            return CreateHuman((StorageFormat)_random.Next(4), sex);
        }

        public Human CreatePair(Human human)
        {
            throw new NotImplementedException();
        }
    }
}
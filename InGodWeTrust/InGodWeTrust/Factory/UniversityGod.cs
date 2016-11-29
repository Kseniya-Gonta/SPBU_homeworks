using System;
using System.Collections.Generic;
using System.Linq;
using InGodWeTrust.Entities;
using InGodWeTrust.Helpers;

namespace InGodWeTrust.Factory
{
    public class UniversityGod: IGod
    {
        public  static Helper Helper = new Helper();
        public static RandomHelper Randomizer = new RandomHelper();
        public List<Human> Humans = new List<Human>();

        public double this[int index]
        {
            get
            {
                var parent = Humans[index] as CoolParent;
                return parent?.AmountOfMoney ?? 0;
            }
        }

        public double GetTotalMoney()
        {
            return Enumerable.Range(0, Humans.Count).Sum(x => this[x]);
        }




        private static int Age(HumanType type)
        {
            return (type == HumanType.Student) ? Randomizer.StudentAge() : Randomizer.ParentAge();
        }
        private Human CreateHuman(HumanType type, Sex sex, string name = null,
            string patronymic = null, int age = 0, double gpaMoney = 0, bool isPair = false)
        {
            switch (type) {
                case HumanType.Student:
                    return patronymic != null ? new Student(Helper.RandomName(sex), sex, age, patronymic, isPair)
                        : new Student(Helper.RandomName(sex), sex, Age(HumanType.Student)
                            , Helper.RandomPatronymic(sex), isPair);

                case HumanType.Botan:
                    return patronymic != null ? new Botan(Helper.RandomName(sex), sex, age, patronymic, gpaMoney, isPair)
                        : new Botan(Helper.RandomName(sex), sex, Age(HumanType.Botan)
                            , Helper.RandomPatronymic(sex), Randomizer.RandomGpa(), isPair);

                case HumanType.Parent:
                    return name != null ? new Parent(name, age, sex, 1, isPair)
                        : new Parent(Helper.RandomName(sex), Age(HumanType.Parent), sex, 1, isPair);

                case HumanType.CoolParent:
                    if (name != null)
                    {
                        return new CoolParent(name, age, sex, 1, gpaMoney, isPair);
                    }
                    return new CoolParent(Helper.RandomName(sex), Age(HumanType.Parent), sex, 1,
                        Randomizer.RandomMoney(), isPair);

                default:
                    throw new ArgumentException("An invalid type: " + type);
            }

        }




        public Human CreateHuman()
        {
            return CreateHuman(RandomSex());
        }

        public Human CreateHuman(Sex sex)
        {
            var humanType = (sex == Sex.Female) ? Randomizer.RandomStudentEntity() : Randomizer.RandomEntity();

            switch (Humans.Count)
            {
                case 0:
                    if (sex == Sex.Female)
                    {
                        throw new InvalidOperationException("First person should be male!");
                    }
                    Save(CreateHuman(humanType, RandomSex()));
                    break;

                case 1:
                    if (sex == Sex.Male)
                    {
                        throw new InvalidOperationException("Second person should be female!");
                    }
                    Save(CreateHuman(humanType, RandomSex()));
                    break;

                default:
                    Save(CreateHuman(humanType, sex));
                    break;
            }

            return Humans.Last();
        }

        public Human CreatePair(Human human)
        {
            if (human is Botan)
            {
                var botan = human as Botan;
                Save(CreateHuman(HumanType.CoolParent, Sex.Male
                    , Helper.ParentNameFromStudent(botan.Patronymic),
                    null, Helper.ParentAgeFromStudent(botan.Age), Helper.MoneyFromGpa(botan.Gpa), true));
            }
            else if (human is CoolParent)
            {
                CoolParent parent = human as CoolParent;
                parent.NumberOfChildren++;
                var studentSex = RandomSex();
                Save(CreateHuman(HumanType.Botan, studentSex, null,
                    Helper.StudentPatronymicFromParent(parent.Name, studentSex),
                    Helper.StudentAgeFromParent(parent.Age), Helper.GpaFromMoney(parent.AmountOfMoney), true));
            }

            else if (human is Student)
            {
                Student student = human as Student;
                Save(CreateHuman(HumanType.Parent, Sex.Male
                    , Helper.ParentNameFromStudent(student.Patronymic),
                    null, Helper.ParentAgeFromStudent(student.Age), 0, true));
            }
            else if (human is Parent)
            {
                var parent = human as Parent;
                parent.NumberOfChildren++;
                var studentSex = RandomSex();
                Save(CreateHuman(HumanType.Student, studentSex, null,
                    Helper.StudentPatronymicFromParent(parent.Name, studentSex)
                    , Helper.StudentAgeFromParent(parent.Age), Randomizer.RandomGpa(), true));
            }

            return Humans.Last();
        }

        private void Save(Human human)
        {
            Humans.Add(human);
        }

        private Sex RandomSex()
        {
            switch (Humans.Count)
            {
                case 0:
                    return Sex.Male;

                case 1:
                    return Sex.Female;

                default:
                    return Randomizer.RandomSex();
            }
        }

    }
}
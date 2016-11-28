﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace InGodWeTrust
{
    public class UniversityGod: IGod
    {
        private static readonly Random _random = new Random();
        public List<Human> _humans = new List<Human>();
        private static readonly string[] FemaleNames = {"Анна", "Евгения", "Мария"};
        private static readonly string[] MaleNames = {"Фёдор", "Константин", "Валентин"};

        public int this[int index]
        {
            get
            {
                var parent = _humans[index] as CoolParent;
                return parent?.AmountOfMoney ?? 0;
            }
        }

        public int GetTotalMoney()
        {
            return Enumerable.Range(0, _humans.Count).Sum(x => this[x]);
        }

        private static string Name(Sex sex)
        {
            return sex == Sex.Female ? FemaleNames[_random.Next(0,3)] : MaleNames[_random.Next(0,3)];
        }

        private static string Patronymic(Sex sex)
        {
            return MaleNames[_random.Next(0,3)] + (sex == Sex.Female ? "овна" : "ович");
        }

        private static int Age(HumanType type)
        {
            return (type == HumanType.Student) ? _random.Next(17, 25) : _random.Next(37, 45);
        }
        private Human CreateHuman(HumanType type, Sex sex, string name = null,
            string patronymic = null, int age = 0, double gpaMoney = 0)
        {
            switch (type) {
                case HumanType.Student:
                    return patronymic != null ? new Student(Name(sex), sex, age, patronymic)
                        : new Student(Name(sex), sex, Age(HumanType.Student), Patronymic(sex));

                case HumanType.Botan:
                    return patronymic != null ? new Botan(Name(sex), sex, age, patronymic, Convert.ToInt32(gpaMoney))
                        : new Botan(Name(sex), sex, Age(HumanType.Botan), Patronymic(sex), _random.Next(4, 5));

                case HumanType.Parent:
                    return name != null ? new Parent(name, age, sex, 1)
                        : new Parent(Name(sex), Age(HumanType.Parent), sex, 1);

                case HumanType.CoolParent:
                    if (name != null)
                    {
                        return new CoolParent(name, age, sex, 1, Convert.ToInt32(gpaMoney));
                    }
                    return new CoolParent(Name(sex), Age(HumanType.Parent), sex, 1,
                        _random.Next((int) Math.Log10(4), (int) Math.Log10(5)));

                default:
                    throw new ArgumentException("An invalid type: " + type.ToString());
            }

        }




        public Human CreateHuman()
        {
            return CreateHuman(RandomSex());
        }

        public Human CreateHuman(Sex sex)
        {
            var humanType = (sex == Sex.Female) ? (HumanType) _random.Next(2) : (HumanType) _random.Next(4);

            switch (_humans.Count)
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

            return _humans.Last();
        }

        public Human CreatePair(Human human)
        {
            if (human is Botan)
            {
                var botan = human as Botan;
                Save(CreateHuman(HumanType.CoolParent, Sex.Male
                    , botan.Patronymic.Substring(0, botan.Patronymic.Length - 4),
                    null, human.Age + _random.Next(20, 40), Math.Log10(botan.Gpa)));
            }
            else if (human is CoolParent)
            {
                CoolParent parent = human as CoolParent;
                parent.NumberOfChildren++;
                var studentSex = RandomSex();
                Save(CreateHuman(HumanType.Botan, studentSex, null,
                    human.Name + ((studentSex == Sex.Female)? "овна" : "ович"),
                     _random.Next(17, 25), Math.Pow(10, parent.AmountOfMoney)));
            }

            else if (human is Student)
            {
                Student student = human as Student;
                Save(CreateHuman(HumanType.Parent, Sex.Male
                    , student.Patronymic.Substring(0, student.Patronymic.Length - 4),
                    null, human.Age + _random.Next(20, 40)));
            }
            else if (human is Parent)
            {
                var parent = human as Parent;
                parent.NumberOfChildren++;
                var studentSex = RandomSex();
                Save(CreateHuman(HumanType.Student, studentSex, null,
                    human.Name + ((studentSex == Sex.Female)? "овна" : "ович"  ), human.Age - _random.Next(20, 40),
                    _random.Next(4, 5)));
            }

            return _humans.Last();
        }

        private void Save(Human human)
        {
            _humans.Add(human);
        }

        private Sex RandomSex()
        {
            switch (_humans.Count)
            {
                case 0:
                    return Sex.Male;

                case 1:
                    return Sex.Female;

                default:
                    return (Sex) _random.Next(2);
            }
        }

    }
}
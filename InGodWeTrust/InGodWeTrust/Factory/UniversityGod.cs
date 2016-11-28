using System;
using System.Collections.Generic;
using System.Linq;

namespace InGodWeTrust
{
    public class UniversityGod: IGod
    {
        private enum HumanType { Student, Botan, Parent, CoolParent }
        private readonly Random _random = new Random();
        private List<Human> _humans = new List<Human>();

        private static Human CreateHuman(HumanType type, Sex sex, string name, string patronymic, int age, int gpaMoney)
        {
            switch (type) {
                case HumanType.Student:
                    if (patronymic.Equals(String.Empty))
                    {
                        return new Student();
                    }
                    return new Student(sex, patronymic);

                case HumanType.Botan:
                    if (patronymic.Equals(String.Empty))
                    {
                        return new Botan();
                    }
                    return new Botan(sex, patronymic, gpaMoney);

                case HumanType.Parent:
                    if (name.Equals(String.Empty))
                    {
                        return new Parent();
                    }
                    return new Parent(name, age);

                case HumanType.CoolParent:
                    if (name.Equals(String.Empty))
                    {
                        return new CoolParent();
                    }
                    return new CoolParent(name, age, gpaMoney);

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
                        throw new ArgumentException("First person should be male!");
                    }
                    Save(CreateHuman(humanType, RandomSex(), null, null, 0, 0));
                    break;

                case 1:
                    if (sex == Sex.Male)
                    {
                        throw new ArgumentException("Second person should be female!");
                    }
                    Save(CreateHuman(humanType, RandomSex(), null, null, 0, 0));
                    break;

                default:
                    Save(CreateHuman(humanType, sex, null, null, 0, 0));
                    break;
            }

            return _humans.Last();
        }

        public Human CreatePair(Human human)
        {
            if (human is Botan)
            {
                Botan botan = human as Botan;
                Save(CreateHuman(HumanType.CoolParent, Sex.Male, human.Name.Substring(0, botan.Patronymic.Length - 4),
                    null, human.Age + _random.Next(20, 40), botan.Gpa)); //исправить деньги
            }
            else if (human is CoolParent)
            {
                var studentSex = RandomSex();
                Save(CreateHuman(HumanType.Botan, studentSex, "", //дописать имя. А не надо
                    human.Name + ((human.Sex == Sex.Female)? "овна" : "ович"),
                     _random.Next(17, 25), 0));
            }

            else if (human is Student)
            {
                Student student = human as Student;
                Save(CreateHuman(HumanType.Parent, Sex.Male, human.Name.Substring(0, student.Patronymic.Length - 4),
                    null, human.Age + _random.Next(20, 40), 0));
            }
            else if (human is Parent)
            {
                var studentSex = RandomSex();
                Save(CreateHuman(HumanType.Student, studentSex, "", //дописать имя. А не надо
                    human.Name + ((human.Sex == Sex.Female)? "овна" : "ович"  ), human.Age - _random.Next(20, 40),
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
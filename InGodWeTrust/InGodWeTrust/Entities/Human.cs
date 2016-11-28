namespace InGodWeTrust
{
    public abstract class Human
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Sex Sex { get; set; }

        public abstract void Print();

    }
}
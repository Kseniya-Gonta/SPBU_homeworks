using System;

namespace InGodWeTrust
{
    public interface IGod
    {
        Human CreateHuman();
        Human CreateHuman(Sex sex);
        Human CreatePair(Human human);
    }
}
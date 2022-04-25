using System;

namespace InterfacesInheritingFromInterfaces
{
    class ScaryScary : FunnyFunny, IScaryClown
    {
        private readonly int scaryThingCount;

        public string ScaryThingIHave => $"{scaryThingCount} spider{(scaryThingCount != 1 ? "s" : "")}";

        public ScaryScary(string funnyThingIHave, int scaryThingCount) : base(funnyThingIHave)
        {
            this.scaryThingCount = scaryThingCount;
        }

        public void ScareLittleChildren()
        {
            Console.WriteLine($"Boo! Gotcha! Look at my {ScaryThingIHave}!");
        }
    }
}
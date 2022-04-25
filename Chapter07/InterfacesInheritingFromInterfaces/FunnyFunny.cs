using System;

namespace InterfacesInheritingFromInterfaces
{
    class FunnyFunny : IClown
    {
        private readonly string _funnyThingIHave;

        public string FunnyThingIHave => _funnyThingIHave;

        public FunnyFunny(string funnyThingIHave)
        {
            _funnyThingIHave = funnyThingIHave;
        }

        public void Honk()
        {
            Console.WriteLine($"Hi kids! I have a {_funnyThingIHave}");
        }
    }
}

using System;

namespace InterfacesInheritingFromInterfaces
{
    interface IClown
    {
        protected static Random random = new();

        private static int _carCapacity = 12;

        public static int CarCapacity
        {
            get => _carCapacity;
            set
            {
                if (value <= 10)
                {
                    throw new ArgumentException($"Car capacity {value} is too small");
                }

                _carCapacity = value;
            }
        }

        public static string ClownCarDescription()
        {
            return $"A clown car with {random.Next(CarCapacity / 2, CarCapacity)} clowns";
        }

        string FunnyThingIHave { get; }

        void Honk();
    }
}

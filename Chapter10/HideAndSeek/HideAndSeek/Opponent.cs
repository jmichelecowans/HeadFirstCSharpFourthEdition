using System;

namespace HideAndSeek
{
    public class Opponent
    {
        public string Name { get; }

        public Opponent(string name) => Name = name;

        public override string ToString() => Name;

        public void Hide()
        {
            var number = House.Random.Next(10, 50);
            var currentLocation = House.Entry;

            for (int i = 0; i < number; i++) currentLocation = House.RandomExit(currentLocation);
            while (currentLocation is not LocationWithHidingPlace) currentLocation = House.RandomExit(currentLocation);

            (currentLocation as LocationWithHidingPlace)?.Hide(this);
            System.Diagnostics.Debug.WriteLine($"{Name} is hiding " +
                $"{(currentLocation as LocationWithHidingPlace).HidingPlace} in the {currentLocation.Name}");
        }
    }
}

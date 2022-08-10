using System;
using System.Collections.Generic;
using System.Linq;

namespace HideAndSeek
{
    public static class House
    {
        static IEnumerable<Location> _locations = Enumerable.Empty<Location>();

        public static Location Entry { get; }

        public static Random Random { get; set; } = new Random();

        static House()
        {
            Entry = new Location("Entry");
            var garage = new LocationWithHidingPlace("Garage", "behind the car");
            var hallway = new Location("Hallway");
            var kitchen = new LocationWithHidingPlace("Kitchen", "next to the stove");
            var bathroom = new LocationWithHidingPlace("Bathroom", "behind the door");
            var livingRoom = new LocationWithHidingPlace("Living Room", "behind the curtain");
            var landing = new Location("Landing");
            var masterBedroom = new LocationWithHidingPlace("Master Bedroom", "in the closet");
            var masterBath = new LocationWithHidingPlace("Master Bath", "in the shower");
            var secondBathroom = new LocationWithHidingPlace("Second Bathroom", "in the shower");
            var nursery = new LocationWithHidingPlace("Nursery", "under the cradle");
            var pantry = new LocationWithHidingPlace("Pantry", "inside a cabinet");
            var kidsRoom = new LocationWithHidingPlace("Kids Room", "inside the chest");
            var attic = new LocationWithHidingPlace("Attic", "in a trunk");

            _locations = _locations.Append(Entry)
                .Append(garage)
                .Append(hallway)
                .Append(kitchen)
                .Append(bathroom)
                .Append(livingRoom)
                .Append(landing)
                .Append(masterBedroom)
                .Append(masterBath)
                .Append(secondBathroom)
                .Append(nursery)
                .Append(pantry)
                .Append(kidsRoom)
                .Append(attic);

            hallway.AddExit(Direction.North, bathroom);
            Entry.AddExit(Direction.Out, garage);
            Entry.AddExit(Direction.East, hallway);
            hallway.AddExit(Direction.Northwest, kitchen);
            hallway.AddExit(Direction.South, livingRoom);
            landing.AddExit(Direction.Up, attic);
            hallway.AddExit(Direction.Up, landing);
            landing.AddExit(Direction.Southeast, kidsRoom);
            landing.AddExit(Direction.Northwest, masterBedroom);
            landing.AddExit(Direction.Southwest, nursery);
            landing.AddExit(Direction.South, pantry);
            landing.AddExit(Direction.West, secondBathroom);
            masterBedroom.AddExit(Direction.East, masterBath);
        }

        public static Location GetLocationByName(string name)
            => _locations.SingleOrDefault(p => p.Name == name) ??
                throw new ArgumentException($"There is no location with the name {name}", 
                    nameof(name));

        public static Location RandomExit(Location location)
        {
            if (location == null) throw new ArgumentNullException(nameof(location));
            if (location.Exits.Count <= 0) throw new ArgumentException("The provide location has no exits",
                nameof(location));

            return location.Exits.Values.Skip(Random.Next(0, location.Exits.Count)).FirstOrDefault();
        }

        public static void ClearHidingPlaces()
        {
            var locationsWithHidingPlace = _locations.Where(p => p is LocationWithHidingPlace)
                        .Select(p => (p as LocationWithHidingPlace));

            foreach (var location in locationsWithHidingPlace) _ = location.CheckHidingPlace();
        }
    }
}

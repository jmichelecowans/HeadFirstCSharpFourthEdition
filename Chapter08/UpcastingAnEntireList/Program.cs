using System.Collections.Generic;
using System.Linq;

namespace UpcastingAnEntireList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Duck> ducks = new() {
                new Duck() { Kind = KindOfDuck.Mallard, Size = 17 },
                new Duck() { Kind = KindOfDuck.Muscovy, Size = 18 },
                new Duck() { Kind = KindOfDuck.Loon, Size = 14 },
                new Duck() { Kind = KindOfDuck.Muscovy, Size = 11 },
                new Duck() { Kind = KindOfDuck.Mallard, Size = 14 },
                new Duck() { Kind = KindOfDuck.Loon, Size = 13 },
            };

            IEnumerable<Bird> upcastBirds = ducks;
            Bird.FlyAway(upcastBirds.ToList(), "Minnesota");
        }
    }
}

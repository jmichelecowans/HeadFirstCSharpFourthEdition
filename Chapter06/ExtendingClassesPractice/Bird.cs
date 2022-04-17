using System;

namespace ExtendingClassesPractice
{
    class Bird
    {
        public static Random Randomizer = new();
        
        public virtual Egg[] LayEggs(int numberOfEggs)
        {
            Console.Error.WriteLine("Bird.LayEggs should never get called");
            return Array.Empty<Egg>();
        }
    }
}
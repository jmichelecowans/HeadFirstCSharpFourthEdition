using System;

namespace PracticingWithIsKeywork
{
    abstract class Animal
    {
        public abstract void MakeNoise();
    }

    class Hippo : Animal, ISwimmer
    {
        public override void MakeNoise()
        {
            Console.WriteLine("Grunt.");
        }

        public void Swim()
        {
            Console.WriteLine("Splash! I'm going for a swim!");
        }
    }

    abstract class Canine : Animal
    {
        public bool BelongsToPack { get; protected set; } = false;
    }

    class Wolf : Canine, IPackHunter
    {
        public Wolf(bool belongsToPack)
        {
            BelongsToPack = belongsToPack;
        }

        public override void MakeNoise()
        {
            if (BelongsToPack)
                Console.WriteLine("I'm in a pack.");
            Console.WriteLine("Aroooooo!");
        }

        public void HuntInPack()
        {
            if (BelongsToPack)
                Console.WriteLine("I'm going hunting with my pack!");
            else
                Console.WriteLine("I'm not in a pack.");
        }
    }
}

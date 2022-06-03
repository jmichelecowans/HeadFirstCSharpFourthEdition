using System;
using System.Collections.Generic;

namespace Cafeteria
{
    class Lumberjack
    {
        public string Name { get; private set; }

        private readonly Stack<Flapjack> flapjackStack = new();

        public Lumberjack(string name)
        {
            Name = name;
        }
        
        public void TakeFlapjack(Flapjack flapjack)
        {
            flapjackStack.Push(flapjack);
        }

        public void EatFlapjacks()
        {
            Console.WriteLine($"{Name} is eating flapjacks");

            while (flapjackStack.Count > 0)
            {
                Console.WriteLine($"{Name} ate a {flapjackStack.Pop().ToString().ToLower()} flapjack");
            }
        }
    }
}

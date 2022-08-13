﻿using System;

namespace RefModifierExample
{
    class Guy
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public override string ToString() => $"a {Age}-year-old named {Name}";
    }

    class Program
    {
        static void ModifyAnIntAndGuy(ref int valueRef, ref Guy guyRef)
        {
            valueRef += 10;
            guyRef.Name = "Bob";
            guyRef.Age = 37;
        }

        static void Main(string[] args)
        {
            int i = 1;
            Guy guy = new() { Name = "Joe", Age = 26 };
            Console.WriteLine("i is {0} and guy is {1}", i, guy);
            ModifyAnIntAndGuy(ref i, ref guy);
            Console.WriteLine("Now i is {0} and guy is {1}", i, guy);
        }
    }
}

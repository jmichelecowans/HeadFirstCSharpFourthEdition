using System;

namespace StructExample
{
    public struct Dog
    {
        public string Name { get; set; }

        public string Breed { get; set; }

        public Dog(string name, string breed)
        {
            Name = name;
            Breed = breed;
        }

        public void Speak()
        {
            Console.WriteLine("My name is {0} and I'm a {1}.", Name, Breed);
        }
    }
}

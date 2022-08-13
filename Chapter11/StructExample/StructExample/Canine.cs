using System;

namespace StructExample
{
    class Canine
    {
        public string Name { get; set; }

        public string Breed { get; set; }

        public Canine(string name, string breed)
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

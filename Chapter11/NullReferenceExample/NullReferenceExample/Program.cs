using System;

#nullable enable
namespace NullReferenceExample
{
    class Guy
    {
        /// <summary>
        /// Encapsulated Guy's name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Encapsulated Guy's age
        /// </summary>
        public int Age { get; private set; }

        public override string ToString() => $"a {Age}-year-old named {Name}";

        /// <summary>
        /// Using encapslation in order to prevent NREs
        /// </summary>
        /// <param name="name">Guy's name</param>
        /// <param name="age">Guy's age</param>
        public Guy(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Guy guy;
            guy = new Guy("Carl", 25);
            Console.WriteLine("guy.Name is {0} letters long", guy.Name.Length);
        }
    }
}

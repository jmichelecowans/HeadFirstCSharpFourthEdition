using System;

namespace UsingEnums
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("How many random cards? ");
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                Random random = new();

                for (int i = 0; i < result; i++)
                {
                    Console.WriteLine(new Card((Suits)random.Next(4), (Values)random.Next(1, 14)));
                }
            }
        }
    }
}

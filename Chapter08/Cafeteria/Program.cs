using System;
using System.Collections.Generic;

namespace Cafeteria
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new();
            Queue<Lumberjack> lumberjacks = new();

            string name;
            Console.Write("Lumberjack's name: ");

            while ((name = Console.ReadLine()) != string.Empty)
            {
                Console.Write("Number of flapjacks: ");

                if (int.TryParse(Console.ReadLine(), out int number))
                {
                    Lumberjack lumberjack = new Lumberjack(name);
                    int flapjackEnumLength = Enum.GetNames(typeof(Flapjack)).Length;

                    for (int i = 0; i < number; i++)
                    {
                        lumberjack.TakeFlapjack((Flapjack)random.Next(0, flapjackEnumLength));
                    }

                    lumberjacks.Enqueue(lumberjack);
                }

                Console.Write("Next lumberjack's name (blank to end): ");
            }

            while (lumberjacks.Count > 0)
            {
                Lumberjack next = lumberjacks.Dequeue();
                next.EatFlapjacks();
            }
        }
    }
}

using System;

namespace TestingRandom
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int randonInt = random.Next();
            Console.WriteLine(randonInt);

            int zeroToNine = random.Next(10);
            Console.WriteLine(zeroToNine);

            int dieRoll = random.Next(1, 7);
            Console.WriteLine(dieRoll);

            double randomDouble = random.NextDouble();
            Console.WriteLine(randomDouble);

            Console.WriteLine(randomDouble * 100);

            Console.WriteLine((float)randomDouble * 100F);
            Console.WriteLine((decimal)randomDouble * 100M);

            int zeroOrOne = random.Next(2);
            bool coinFlip = Convert.ToBoolean(zeroOrOne);
            Console.WriteLine(coinFlip);
        }
    }
}

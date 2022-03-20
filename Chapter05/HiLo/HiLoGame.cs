using System;

namespace HiLo
{
    static class HiLoGame
    {
        private static readonly Random random = new();
        private static int currentNumber = NextNumber();

        public static int Pot { get; private set; } = 10;

        public const int MAXIMUM = 10;

        public static void Guess(bool higher)
        {
            int nextNumber = NextNumber();

            if ((higher && nextNumber >= currentNumber) || (!higher && nextNumber <= currentNumber))
            {
                Console.WriteLine("You guessed right!");
                Pot++;
            }
            else
            {
                Console.WriteLine("Bad luck, you guessed wrong.");
                Pot--;
            }

            currentNumber = nextNumber;
            Console.WriteLine($"The current number is {currentNumber}");
        }

        public static void Hint()
        {
            int half = MAXIMUM / 2;

            if (currentNumber >= half)
            {
                Console.WriteLine($"The number is at least {half}");
            }
            else
            {
                Console.WriteLine($"The number is at most {half}");
            }

            Pot--;
        }

        private static int NextNumber()
        {
            return random.Next(1, MAXIMUM + 1);
        }
    }
}

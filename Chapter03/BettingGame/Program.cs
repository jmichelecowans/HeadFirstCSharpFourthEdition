using System;

namespace BettingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            double odds = .75;
            Guy player = new Guy("The player", 100);

            Console.WriteLine("Welcome to the casino, the odds are " + odds);

            while (player.Cash > 0)
            {
                player.WriteInfo();
                Console.Write("How much money do you want to bet: ");
                string howMuch = Console.ReadLine();
                if (int.TryParse(howMuch, out int amount) & amount > 0)
                {
                    int pot = player.GiveCash(amount) * 2;
                    if (random.NextDouble() > odds)
                    {
                        player.ReceiveCash(pot);
                        Console.WriteLine("You win " + pot);
                    }
                    else
                    {
                        Console.WriteLine("Bad luck, you loose.");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number greater than zero");
                }
            }
            Console.Write("The house aways wins.");
        }
    }
}

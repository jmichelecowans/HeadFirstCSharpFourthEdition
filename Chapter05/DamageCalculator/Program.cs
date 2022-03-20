using System;

namespace DamageCalculator
{
    class Program
    {
        private static readonly Random random = new ();

        static void Main()
        {
            SwordDamage swordDamage = new (RollDice());

            while (true)
            {
                Console.Write("0 for no magic/flaming, 1 for magic, 2 for flaming, 3 for both, anything else to quit: ");
                char key = Console.ReadKey(false).KeyChar;

                if (key < '0' || key > '3') return;

                swordDamage.Roll = RollDice();
                swordDamage.Magic = key is '3' or '1';
                swordDamage.Flaming = key is '2' or '3';

                Console.WriteLine($"{Environment.NewLine}Rolled {swordDamage.Roll} for {swordDamage.Damage} HP{Environment.NewLine}");
            }
        }

        static int RollDice()
        {
            return random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
        }
    }
}

using System;

namespace ArrowDamageCalculator
{
    class Program
    {
        private static readonly Random random = new();

        static void Main()
        {
            SwordDamage swordDamage = new(RollDice(3));
            ArrowDamage arrowDamage = new(RollDice());

            while (true)
            {
                Console.Write("0 for no magic/flaming, 1 for magic, 2 for flaming, 3 for both, anything else to quit: ");
                char key = Console.ReadKey(false).KeyChar;
                if (key < '0' || key > '3') return;

                Console.Write("\nS for sword, A for arrow, anything else to quit: ");
                char weaponKey = char.ToUpper(Console.ReadKey().KeyChar);

                switch (weaponKey)
                {
                    case 'S':
                        swordDamage.Roll = RollDice(3);
                        swordDamage.Magic = (key == '1' || key == '3');
                        swordDamage.Flaming = (key == '2' || key == '3');
                        Console.WriteLine(
                        $"\nRolled {swordDamage.Roll} for {swordDamage.Damage} HP\n");
                        break;
                    case 'A':
                        arrowDamage.Roll = RollDice();
                        arrowDamage.Magic = (key == '1' || key == '3');
                        arrowDamage.Flaming = (key == '2' || key == '3');
                        Console.WriteLine(
                        $"\nRolled {arrowDamage.Roll} for {arrowDamage.Damage} HP\n");
                        break;
                    default:
                        return;
                }
            }
        }

        static int RollDice(int numberOfRolls = 1)
        {
            int roll = 0;
            for (int i = 0; i < numberOfRolls; i++) roll += random.Next(1, 7);
            return roll;
        }
    }
}

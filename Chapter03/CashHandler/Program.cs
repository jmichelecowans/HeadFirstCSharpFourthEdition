using System;

namespace CashHandler
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new Guy object in a variable called joe
            // Set its Name field to "Joe"
            // Set its Cash field to 50
            Guy joe = new Guy(name: "Joe", cash: 50);

            // Create a new Guy object in a variable called bob
            // Set its Name field to "Bob"
            // Set its Cash field to 100
            Guy bob = new Guy(name: "Bob", cash: 100);

            while (true)
            {
                // Call the WriteMyInfo methods for each Guy object
                joe.WriteInfo();
                bob.WriteInfo();

                Console.Write("Enter a amount: ");
                string howMuch = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(howMuch)) return;

                // Use int.TryParse to try to convert the howMuch string to an int
                // if it was successful (just like you did earlier in the chapter)
                if (int.TryParse(howMuch, out int amount))
                {
                    Console.Write("Who should give the cash: ");
                    string whichGuy = Console.ReadLine();
                    if (whichGuy?.Trim()?.ToLower() == "joe")
                    {
                        // Call the joe object's GiveCash method and save the results
                        // Call the bob object's ReceiveCash method with the saved results
                        bob.ReceiveCash(joe.GiveCash(amount));
                    }
                    else if (whichGuy?.Trim()?.ToLower() == "bob")
                    {
                        // Call the bob object's GiveCash method and save the results
                        // Call the joe object's ReceiveCash method with the saved results
                        joe.ReceiveCash(bob.GiveCash(amount));
                    }
                    else
                    {
                        Console.WriteLine("Please enter 'Joe' or 'Bob'");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter an amount (or a blank line to exit).");
                }
            }
        }
    }
}

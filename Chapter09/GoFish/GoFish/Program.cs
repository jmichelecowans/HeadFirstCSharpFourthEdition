using System;
using System.Collections.Generic;
using System.Linq;

namespace GoFish
{
    class Program
    {
        /// <summary>
        /// The GameController to manage the game
        /// </summary>
        static GameController gameController;

        /// <summary>
        /// Play a game of Go Fish!
        /// </summary>
        static void Main(string[] args)
        {
            string humanPlayerName;
            int numberOfOpponents;

            do
            {
                Console.Write("Enter your name: ");
            } while (string.IsNullOrWhiteSpace(humanPlayerName = Console.ReadLine()?.Trim()));

            do
            {
                Console.Write("Enter the number of computer opponents from 1 to 4: ");
            } while (int.TryParse(Console.ReadLine()?.Trim(), out numberOfOpponents)
                && (numberOfOpponents < 1 || numberOfOpponents > 4));

            Console.WriteLine($"Welcome to the game, {humanPlayerName}");
            gameController = new GameController(humanPlayerName, 
                Enumerable.Range(1, numberOfOpponents).Select(p => $"Computer #{p}"));
            Console.WriteLine(gameController.Status?.Trim());

            while (!gameController.GameOver)
            {
                while (!gameController.GameOver)
                {
                    Console.WriteLine("Your hand:");
                    var hand = gameController.HumanPlayer.Hand.OrderBy(c => c.Suit).OrderBy(c => c.Value);
                    foreach (var card in hand) Console.WriteLine(card);
                    var value = PromptForAValue();
                    var opponent = PromptForAnOpponent();
                    gameController.NextRound(opponent, value);
                    Console.WriteLine(gameController.Status?.Trim());
                }

                Console.WriteLine("Press Q to quit, any other key for a new game.");
                if (Console.ReadKey(true).KeyChar.ToString().ToUpper() != "Q")
                {
                    gameController.NewGame();
                }
            }
        }

        /// <summary>
        /// Prompt the human player for a card value
        /// in their hand
        /// </summary>
        /// <returns>The value to ask for</returns>
        static Values PromptForAValue()
        {
            var handValues = gameController.HumanPlayer.Hand.Select(card => card.Value).ToList();

            while (true)
            {
                Console.Write("What card value do you want to ask for? ");
                if (Enum.TryParse(typeof(Values), Console.ReadLine(), out var value) &&
                handValues.Contains((Values)value))
                    return (Values)value;
                else
                    Console.WriteLine("Please enter a value in your hand.");
            }
        }

        /// <summary>
        /// Prompt the human player for an opponent
        /// to ask for a card
        /// </summary>
        /// <returns>The opponent to ask</returns>
        static Player PromptForAnOpponent()
        {
            var opponents = gameController.Opponents.ToList();

            for (int i = 1; i <= opponents.Count(); i++)
                Console.WriteLine($"{i}. {opponents[i - 1]}");
            
            Console.Write("Who do you want to ask for a card? ");
            
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int selection)
                && selection >= 1 && selection <= opponents.Count())
                    return opponents[selection - 1];
                else
                    Console.Write($"Please enter a number from 1 to {opponents.Count()}: ");
            }
        }
    }
}

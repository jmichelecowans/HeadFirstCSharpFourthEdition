﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace GoFish
{
    public class GameState
    {
        public IEnumerable<Player> Players { get; }

        public IEnumerable<Player> Opponents { get; }

        public Player HumanPlayer { get; }

        public bool GameOver { get; private set; } = false;

        public Deck Stock { get; }

        /// <summary>
        /// Constructor creates the players and deals their first hands
        /// </summary>
        /// <param name="humanPlayerName">Name of the human player</param>
        /// <param name="opponentNames">Names of the computer players</param>
        /// <param name="stock">Shuffled stock of cards to deal from</param>
        public GameState(string humanPlayerName, IEnumerable<string> opponentNames, Deck stock)
        {
            Stock = stock;
            HumanPlayer = new Player(humanPlayerName);
            HumanPlayer.GetNextHand(Stock);

            Players = Enumerable.Empty<Player>().Append(HumanPlayer);
            Opponents = Enumerable.Empty<Player>();

            foreach (var opponent in opponentNames.Select(p => new Player(p)))
            {
                opponent.GetNextHand(Stock);
                Opponents = Opponents.Append(opponent);
            }

            Players = Players.Concat(Opponents);
        }

        /// <summary>
        /// Gets a random player that doesn't match the current player
        /// </summary>
        /// <param name="currentPlayer">The current player</param>
        /// <returns>A random player that the current player can ask for a card</returns>
        public Player RandomPlayer(Player currentPlayer) => Players.Where(p => p != currentPlayer)
            .ToList()[Player.Random.Next(Players.Where(p => p != currentPlayer).Count())];

        /// <summary>
        /// Makes one player play a round
        /// </summary>
        /// <param name="player">The player asking for a card</param>
        /// <param name="playerToAsk">The player being asked for a card</param>
        /// <param name="valueToAskFor">The value to ask the player for</param>
        /// <param name="stock">The stock to draw cards from</param>
        /// <returns>A message that describes what just happened</returns>
        public string PlayRound(Player player, Player playerToAsk, Values valueToAskFor, Deck stock)
        {
            var pulledOutCards = playerToAsk.DoYouHaveAny(valueToAskFor, stock);
            var pluralizedValue = valueToAskFor == Values.Six ? "Sixes" : $"{valueToAskFor}s";
            string message = $"{player.Name} asked {playerToAsk.Name} for {pluralizedValue}";

            if (pulledOutCards.Any())
            {
                player.AddCardsAndPullOutBooks(pulledOutCards);
                message += $"{Environment.NewLine}"
                    + $"{playerToAsk.Name} has {pulledOutCards.Count()} {valueToAskFor} "
                    + $"card{Player.S(pulledOutCards.Count())}";
            }
            else if (stock.Count <= 0)
            {
                message += $"{Environment.NewLine}The stock is out of cards";
            }
            else
            {
                player.DrawCard(stock);
                message += $"{Environment.NewLine}{player.Name} drew a card";
            }

            if (player.Hand.Count() == 0)
            {
                player.GetNextHand(stock);
                message += $"{Environment.NewLine}{player.Name} ran out of cards,"
                + $" drew {player.Hand.Count()} from the stock";
            }

            return message;
        }

        /// <summary>
        /// Checks for a winner by seeing if any players have any cards left, sets GameOver
        /// if the game is over and there's a winner
        /// </summary>
        /// <returns>A string with the winners, an empty string if there are no winners</returns>
        public string CheckForWinner()
        {
            var playerCards = Players.Select(player => player.Hand.Count()).Sum();
            if (playerCards > 0) return "";
            GameOver = true;
            var winningBookCount = Players.Select(player => player.Books.Count()).Max();
            var winners = Players.Where(player => player.Books.Count() == winningBookCount);
            if (winners.Count() == 1) return $"The winner is {winners.First().Name}";
            return $"The winners are {string.Join(" and ", winners)}";
        }
    }
}

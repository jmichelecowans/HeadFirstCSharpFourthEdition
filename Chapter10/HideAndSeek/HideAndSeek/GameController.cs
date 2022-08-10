using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HideAndSeek
{
    public class GameController
    {

        /// <summary>
        /// Private list of opponents the player has found so far
        /// </summary>
        private readonly List<Opponent> _foundOpponents = new();

        /// <summary>
        /// The player's current location in the house
        /// </summary>
        public Location CurrentLocation { get; private set; }

        /// <summary>
        /// Returns the the current status to show to the player
        /// </summary>
        public string Status => $"You are in the {CurrentLocation.Name}."
            + (CurrentLocation.Exits.Values.Count <= 0 ? string.Empty : " You see the following exits:"
                + Environment.NewLine + string.Join(Environment.NewLine, CurrentLocation.ExitList.Select(e => $" - {e}")))
            + (CurrentLocation is LocationWithHidingPlace
                ? $"{Environment.NewLine}Someone could hide {(CurrentLocation as LocationWithHidingPlace).HidingPlace}"
                : string.Empty)
            + (_foundOpponents.Any() ? $"{Environment.NewLine}You have found {_foundOpponents.Count} of {Opponents.Count()} opponents: {string.Join(", ", _foundOpponents)}"
                : $"{Environment.NewLine}You have not found any opponents");

        /// <summary>
        /// A prompt to display to the player
        /// </summary>
        //public string Prompt => "Which direction do you want to go: ";

        /// <summary>
        /// The number of moves the player has made
        /// </summary>
        public int MoveNumber { get; private set; } = 1;

        /// <summary>
        /// Private list of opponents the player needs to find
        /// </summary>
        public readonly IEnumerable<Opponent> Opponents = new List<Opponent>()
        {
            new Opponent("Joe"),
            new Opponent("Bob"),
            new Opponent("Ana"),
            new Opponent("Owen"),
            new Opponent("Jimmy"),
        };

        /// <summary>
        /// Returns true if the game is over
        /// </summary>
        public bool GameOver => Opponents.Count() == _foundOpponents.Count;

        /// <summary>
        /// A prompt to display to the player
        /// </summary>
        public string Prompt => $"{MoveNumber}: Which direction do you want to go (or type 'check'): ";

        public GameController()
        {
            House.ClearHidingPlaces();
            foreach (var opponent in Opponents)
            {
                opponent.Hide();
            }

            CurrentLocation = House.Entry;
        }

        /// <summary>
        /// Move to the location in a direction
        /// </summary>
        /// <param name="direction">The direction to move</param>
        /// <returns>True if the player can move in that direction, false oterwise</returns>
        public bool Move(Direction direction, bool move = false)
        {
            if (move) MoveNumber++;

            if (CurrentLocation.Exits.Keys.Contains(direction))
            {
                CurrentLocation = CurrentLocation.Exits[direction];
                return true;
            }

            return false;
        }

        /// <summary>
        /// Parses input from the player and updates the status
        /// </summary>
        /// <param name="input">Input to parse</param>
        /// <returns>The results of parsing the input</returns>
        public string ParseInput(string input)
        {
            MoveNumber++;

            if (input?.Trim()?.ToLower() == "check")
            {
                if (CurrentLocation is LocationWithHidingPlace location)
                {
                    var opponents = location.CheckHidingPlace();
                    
                    if (opponents.Any())
                    {
                        _foundOpponents.AddRange(opponents);
                        var plural = opponents.Count() > 1 ? "s" : "";
                        return 
                            $"You found {opponents.Count()} opponent{plural} hiding {location.HidingPlace}";
                    }

                    return $"Nobody was hiding {location.HidingPlace}";
                }
                else
                {
                    return $"There is no hiding place in the {CurrentLocation.Name}";
                }
            }
            else if (Enum.TryParse(input?.Trim(), true, out Direction direction))
            {
                if (CurrentLocation.Exits.Keys.Contains(direction))
                {
                    Move(direction);
                    return $"Moving {direction}";
                }

                return "There's no exit in that direction";
            }

            MoveNumber--;
            return "That's not a valid direction";
        }
    }
}

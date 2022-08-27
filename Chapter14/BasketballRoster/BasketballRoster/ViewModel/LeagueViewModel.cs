using BasketballRoster.Model;
using System.Collections.Generic;
using System.Linq;

namespace BasketballRoster.ViewModel
{
    class LeagueViewModel
    {
        public RosterViewModel JimmysTeam { get; set; }
        public RosterViewModel AnasTeam { get; set; }

        public LeagueViewModel()
        {
            JimmysTeam = new RosterViewModel(new Roster("The Amazins", GetAmazinPlayers()));
            AnasTeam = new RosterViewModel(new Roster("The Bombers", GetBomberPlayers()));
        }

        private IEnumerable<Player> GetAmazinPlayers()
        {
            return Enumerable.Empty<Player>()
                .Append(new Player("Jimmy", 42, true))
                .Append(new Player("Henry", 11, true))
                .Append(new Player("Bob", 4, true))
                .Append(new Player("Lucinda", 18, true))
                .Append(new Player("Kim", 16, true))
                .Append(new Player("Bertha", 23, false))
                .Append(new Player("Ed", 21, false));
        }

        private IEnumerable<Player> GetBomberPlayers()
        {
            return Enumerable.Empty<Player>()
                .Append(new Player("Ana", 31, true))
                .Append(new Player("Lloyd", 23, true))
                .Append(new Player("Kathleen", 6, true))
                .Append(new Player("Lucinda", 18, true))
                .Append(new Player("Mike", 0, true))
                .Append(new Player("Herb", 32, false))
                .Append(new Player("Fingers", 8, false));
        }
    }
}

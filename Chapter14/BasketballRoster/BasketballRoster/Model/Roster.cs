using System.Collections.Generic;

namespace BasketballRoster.Model
{
    class Roster
    {
        public string TeamName { get; set; }

        private List<Player> _players = new List<Player>();
        public IEnumerable<Player> Players => new List<Player>(_players);

        public Roster(string teamName, IEnumerable<Player> players)
        {
            TeamName = teamName;
            _players.AddRange(players);
        }
    }
}

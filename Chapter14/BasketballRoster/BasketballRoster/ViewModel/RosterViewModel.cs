using BasketballRoster.Model;
using System.Collections.ObjectModel;
using System.Linq;

namespace BasketballRoster.ViewModel
{
    class RosterViewModel
    {
        private Roster _roster;

        public string TeamName { get; set; }
        public ObservableCollection<PlayerViewModel> Starters { get; private set; }
        public ObservableCollection<PlayerViewModel> Bench { get; private set; }

        public RosterViewModel(Roster roster)
        {
            TeamName = roster.TeamName;
            Starters = new ObservableCollection<PlayerViewModel>();
            Bench = new ObservableCollection<PlayerViewModel>();
            UpdateRosters(roster);
        }

        private void UpdateRosters(Roster roster)
        {
            var starters = roster.Players
                .Where(p => p.Starter)
                .Select(p => new PlayerViewModel() { Name = p.Name, Number = p.Number });

            foreach (PlayerViewModel player in starters)
            {
                Starters.Add(player);
            }

            var bench = roster.Players
                .Where(p => !p.Starter)
                .Select(p => new PlayerViewModel() { Name = p.Name, Number = p.Number });

            foreach (PlayerViewModel player in bench)
            {
                Bench.Add(player);
            }
        }
    }
}

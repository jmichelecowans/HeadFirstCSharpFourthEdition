using System;
using System.Collections.Generic;
using System.Linq;

namespace HideAndSeek
{
    public class LocationWithHidingPlace : Location
    {
        private IEnumerable<Opponent> _hiddenOpponents = Enumerable.Empty<Opponent>();

        public string HidingPlace { get; }

        public LocationWithHidingPlace(string name, string hidingPlace) : base(name)
        {
            HidingPlace = hidingPlace;
        }

        public void Hide(Opponent opponent)
        {
            _hiddenOpponents = _hiddenOpponents.Append(opponent ?? throw new ArgumentNullException(nameof(opponent)));
        }

        public IEnumerable<Opponent> CheckHidingPlace()
        {
            var foundOpponents = _hiddenOpponents;
            _hiddenOpponents = Enumerable.Empty<Opponent>();
            return foundOpponents;
        }
    }
}

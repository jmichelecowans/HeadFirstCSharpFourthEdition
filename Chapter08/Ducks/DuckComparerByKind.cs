using System.Collections.Generic;

namespace Ducks
{
    class DuckComparerByKind : IComparer<Duck>
    {
        public int Compare(Duck x, Duck y)
        {
            if (x.Kind > y.Kind)
            {
                return 1;
            }
            else if (x.Kind < y.Kind)
            {
                return -1;
            }

            return 0;
        }
    }
}
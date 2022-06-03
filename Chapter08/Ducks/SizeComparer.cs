using System.Collections.Generic;

namespace Ducks
{
    class DuckComparerBySize : IComparer<Duck>
    {
        public int Compare(Duck x, Duck y)
        {
            if (x.Size > y.Size)
            {
                return 1;
            }
            else if (x.Size < y.Size)
            {
                return -1;
            }

            return 0;
        }
    }
}
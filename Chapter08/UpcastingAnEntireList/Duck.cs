using System;

namespace UpcastingAnEntireList
{
    class Duck : Bird, IComparable<Duck>
    {
        public int Size { get; set; }

        public KindOfDuck Kind { get; set; }

        public int CompareTo(Duck other)
        {
            if (Size > other.Size)
            {
                return 1;
            }
            else if (Size < other.Size)
            {
                return -1;
            }

            return 0;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;

namespace YieldReturnExample
{
    class BetterEnumSequence<T> : IEnumerable<T> where T : Enum
    {
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            foreach (var item in Enum.GetValues(typeof(T)) ?? Array.Empty<object>())
            {
                yield return (T)item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => (this as IEnumerable<T>)?.GetEnumerator();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;

namespace ImplementingIEnumerabe
{
    class EnumSequence<T> : IEnumerable<T> where T : Enum
    {
        IEnumerator<T> IEnumerable<T>.GetEnumerator() => new EnumEnumerator<T>();

        IEnumerator IEnumerable.GetEnumerator() => (this as IEnumerable<T>)?.GetEnumerator();

        class EnumEnumerator<U> : IEnumerator<U>
        {
            int current = -1;
            readonly Array values = Enum.GetValues(typeof(U)) ?? Array.Empty<object>();

            U IEnumerator<U>.Current => (U)values.GetValue(current);

            object IEnumerator.Current => (this as IEnumerator<U>).Current;

            void IDisposable.Dispose() { }

            bool IEnumerator.MoveNext()
            {
                if (current >= values.Length - 1)
                {
                    return false;
                }

                current++;
                return true;
            }

            void IEnumerator.Reset() => current = 0;
        }
    }
}

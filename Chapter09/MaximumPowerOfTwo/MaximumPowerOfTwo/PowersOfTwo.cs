using System;
using System.Collections;
using System.Collections.Generic;

namespace MaximumPowerOfTwo
{
    class PowersOfTwo : IEnumerable<double>
    {
        IEnumerator<double> IEnumerable<double>.GetEnumerator()
        {
            var resultado = Math.Round(Math.Log(int.MaxValue, 2));
            for (int i = 0; i < resultado; i++)
            {
                yield return Math.Pow(2, i);
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => (this as IEnumerable<double>)?.GetEnumerator();
    }
}

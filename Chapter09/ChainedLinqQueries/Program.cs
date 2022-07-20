using System;
using System.Collections.Generic;
using System.Linq;

namespace ChainedLinqQueries
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] values = new int[] { 0, 12, 44, 36, 92, 54, 13, 8 };
            IEnumerable<int> result = from v in values
                                      where v < 37
                                      orderby -v
                                      select v;

            foreach (var v in result) Console.WriteLine(v);

            result = values.Where(p => p < 37).OrderBy(p => -p);
            foreach (var v in result) Console.WriteLine(v);
        }
    }
}

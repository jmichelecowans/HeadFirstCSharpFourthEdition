using System;
using System.Collections.Generic;

namespace YieldReturnExample
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var s in SimpleEnumerable())
            {
                Console.WriteLine(s);
            }

            Console.WriteLine();

            foreach (var s in new BetterEnumSequence<Sport>())
            {
                Console.WriteLine(s);
            }
        }

        static IEnumerable<string> SimpleEnumerable()
        {
            yield return "apples";
            yield return "oranges";
            yield return "bananas";
            yield return "unicorns";
        }
    }
}

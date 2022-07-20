using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new();
            for (int i = 1; i < 100; i++)
            {
                numbers.Add(i);
            }

            IEnumerable<int> firstAndLastFive = numbers.Take(5).Concat(numbers.TakeLast(5));
            foreach (int i in firstAndLastFive)
            {
                Console.Write($"{i} ");
            }

            int[] values = new int[] { 0, 12, 44, 36, 92, 54, 13, 8 };
            var result = from v in values
                         where v < 37
                         orderby -v
                         select v;

            Console.WriteLine();
            foreach (int i in result)
            {
                Console.Write($"{i} ");
            }
        }
    }
}

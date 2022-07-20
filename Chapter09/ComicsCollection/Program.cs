using System;
using System.Collections.Generic;
using System.Linq;

namespace ComicsCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            //IEnumerable<Comic> comics = 
            //    from price in Comic.Prices
            //    join comic in Comic.Catalog
            //    on price.Key equals comic.Issue
            //    where price.Value > 500
            //    orderby price.Value descending
            //    select comic;

            //IEnumerable<Comic> mostExpensive =
            //    from comic in Comic.Catalog
            //    where Comic.Prices[comic.Issue] > 500
            //    orderby Comic.Prices[comic.Issue] descending
            //    select comic;

            IEnumerable<string> mostExpensiveDescriptions =
                from comic in Comic.Catalog
                where Comic.Prices[comic.Issue] > 500
                orderby Comic.Prices[comic.Issue] descending
                select $"{comic} is worth {Comic.Prices[comic.Issue]:c}";

            foreach (var description in mostExpensiveDescriptions)
            {
                Console.WriteLine(description);
            }
        }
    }
}

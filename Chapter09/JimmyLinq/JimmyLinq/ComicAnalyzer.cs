using System;
using System.Collections.Generic;
using System.Linq;

namespace JimmyLinq
{
    public static class ComicAnalyzer
    {
        private static PriceRange CalculatePriceRange(decimal price)
            => price < 100 ? PriceRange.Cheap : PriceRange.Expensive;

        public static IEnumerable<IGrouping<PriceRange, Comic>> GroupComicsByPrice(IEnumerable<Comic> comics, IReadOnlyDictionary<int, decimal> prices)
            => comics?.Where(c => prices.Keys.Contains(c.Issue))
            .OrderBy(c => prices[c.Issue])
            .GroupBy(c => CalculatePriceRange(prices[c.Issue]))
            .OrderBy(g => g.Key);
        //from comic in comics
        //where prices.Keys.Contains(comic.Issue)
        //orderby prices[comic.Issue]
        //group comic by CalculatePriceRange(prices[comic.Issue]) into priceGroup 
        //orderby priceGroup.Key
        //select priceGroup;

        public static IEnumerable<string> GetReviews(IEnumerable<Comic> comics, IEnumerable<Review> reviews)
            => comics?.OrderBy(c => c.Issue).Join(reviews, 
                c => c.Issue, 
                r => r.Issue, 
                (c, r) => $"{r.Critic} rated #{c.Issue} '{c.Name}' {r.Score:0.00}");
        //from comic in comics
        //orderby comic.Issue
        //join review in reviews
        //on comic.Issue equals review.Issue
        //select $"{review.Critic} rated #{comic.Issue} '{comic.Name}' {review.Score:0.00}";
    }
}

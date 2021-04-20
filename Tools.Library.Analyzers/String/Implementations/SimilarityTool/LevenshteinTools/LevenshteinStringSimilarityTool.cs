using System.Collections.Generic;
using System.Linq;
using Tools.Library.Analyzers.String.Abstractions;

namespace Tools.Library.Analyzers.String.Implementations.SimilarityTool.LevenshteinTools
{
    public class LevenshteinStringSimilarityTool : IStringSimilarityTool
    {
        public string findTheMostSimilarString(IEnumerable<string> pool, string targetString)
        {
            var poolList = pool.ToList();
            poolList.Sort(new LevenshteinComparer(targetString));
            return poolList.First();
        }
    }
}
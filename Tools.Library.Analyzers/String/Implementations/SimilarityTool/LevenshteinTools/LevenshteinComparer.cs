using System.Collections.Generic;

namespace Tools.Library.Analyzers.String.Implementations.SimilarityTool.LevenshteinTools
{
    internal class LevenshteinComparer : IComparer<string>
    {
        private readonly string _targetString;
        
        
        public LevenshteinComparer(string targetString)
        {
            _targetString = targetString;
        }
        
        public int Compare(string? x, string? y)
        {
            if (string.IsNullOrEmpty(x)) return 1;
            if (string.IsNullOrEmpty(y)) return -1;

            var scoreX = x.CalculateSimilarity(_targetString);
            var scoreY = y.CalculateSimilarity(_targetString);

            if (scoreX > scoreY) return -1;
            if (scoreY > scoreX) return 1;
            
            return 0;
        }
    }
}
using System.Collections;
using System.Collections.Generic;

namespace Tools.Library.Analyzers.String.Abstractions
{
    public interface IStringSimilarityTool
    {
        string findTheMostSimilarString(IEnumerable<string> pool, string targetString);
    }
}
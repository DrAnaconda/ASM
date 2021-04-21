using System.Collections.Generic;

namespace Tools.Library.Analyzers.DateTime.Abstractions
{
    public interface IDateTimeAnalyzer
    {
        System.DateTime[] extractDateTimesFromStringArrays(IEnumerable<string> strings, 
            string separator, bool ignoreFailed);

        System.DateTime findTheMostClosestDateTime(System.DateTime target, IEnumerable<System.DateTime> pool,
            bool ignoreYear, bool ignoreMonth, bool ignoreDay);
    }
}
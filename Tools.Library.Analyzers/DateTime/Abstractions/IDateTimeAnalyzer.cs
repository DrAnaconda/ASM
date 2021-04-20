using System.Collections.Generic;

namespace Tools.Library.Analyzers.DateTime.Abstractions
{
    public interface IDateTimeAnalyzer
    {
        System.DateTime[] extractDateTimesFromStringArrays(IEnumerable<string> strings, 
            string separator, 
            int yearOverrider = -1, int monthOverrider = -1, int dayOverrider = -1);

        System.DateTime[] findTheMostClosestDateTime(System.DateTime current, System.DateTime target);
    }
}
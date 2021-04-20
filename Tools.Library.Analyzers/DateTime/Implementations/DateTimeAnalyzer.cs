using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Tools.Library.Analyzers.DateTime.Abstractions;

namespace Tools.Library.Analyzers.DateTime.Implementations
{
    public class DateTimeAnalyzer : IDateTimeAnalyzer
    {
        public System.DateTime[] extractDateTimesFromStringArrays(
            IEnumerable<string> strings, string separator,
            int yearOverrider = -1, int monthOverrider = -1, int dayOverrider = -1)
        {
            var result = new LinkedList<System.DateTime>();
            foreach (var stringToParse in strings)
            {
                var numbersAndSeparators = Regex.Replace(stringToParse, "[A-Za-z ]", string.Empty);
                var numbersOnly = numbersAndSeparators.Split('_');
                // TODO: Refactor => use separate entity for this thing
                var parsedDateTime = new System.DateTime(
                    (yearOverrider != -1) ? yearOverrider : numbersOnly[0].intToStr(), 
                    (monthOverrider != -1) ? monthOverrider : numbersOnly[1].intToStr(),
                    (dayOverrider != -1) ? dayOverrider : numbersOnly[2].intToStr(), 
                    numbersOnly[3].intToStr(), 
                    numbersOnly[4].intToStr(), 
                    numbersOnly[5].intToStr());
                result.AddLast(parsedDateTime);
            }

            return result.ToArray();
        }

        public System.DateTime[] findTheMostClosestDateTime(System.DateTime current, System.DateTime target)
        {
            throw new System.NotImplementedException();
        }
    }
}
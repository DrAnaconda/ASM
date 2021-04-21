using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Tools.Library.Analyzers.DateTime.Abstractions;

namespace Tools.Library.Analyzers.DateTime.Implementations
{
    public class DateTimeAnalyzer : IDateTimeAnalyzer
    {
        public System.DateTime[] extractDateTimesFromStringArrays(
            IEnumerable<string> strings, string separator, bool ignoreFailed)
        {
            try
            {
                // TODO: Make this method in AI style, super cool, super universal
                var result = new LinkedList<System.DateTime>();
                foreach (var stringToParse in strings)
                {
                    var numbersAndSeparators = Regex.Replace(stringToParse, "[A-Za-z ]", string.Empty);
                    if (!char.IsNumber(numbersAndSeparators[0]))
                        numbersAndSeparators = numbersAndSeparators.Remove(0, 1);
                    var numbersOnly = numbersAndSeparators.Split(separator);
                    // TODO: Refactor => use separate entity for this thing
                    var parsedDateTime = new System.DateTime(
                        numbersOnly[0].intToStr(),
                        numbersOnly[1].intToStr(),
                        numbersOnly[2].intToStr(),
                        numbersOnly[3].intToStr(),
                        numbersOnly[4].intToStr(),
                        numbersOnly[5].intToStr());
                    result.AddLast(parsedDateTime);
                }

                return result.ToArray();
            }
            catch (Exception)
            {
                if (!ignoreFailed) throw;
            }

            return Array.Empty<System.DateTime>();
        }

        public System.DateTime findTheMostClosestDateTime(System.DateTime target, IEnumerable<System.DateTime> pool,
            bool ignoreYear, bool ignoreMonth, bool ignoreDay)
        {
            var list = pool.ToList();
            list.Sort(new AdjustableDateTimeComparator(target, ignoreYear, ignoreMonth, ignoreDay));
            return list.First();
        }
    }
}
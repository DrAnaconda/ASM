using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Tools.Library.Analyzers.DateTime.Abstractions;
using Tools.Library.Analyzers.DateTime.Implementations;

namespace Tools.Library.Analyzers.Tests
{
    public class DateTimeAnalyzersTests
    {
        private IDateTimeAnalyzer _defaultDateTimeAnalyzer;

        private const string stringtifiedDateTime = "Time_2021_04_05_11_35_27";

        [SetUp]
        public void Setup()
        {
            _defaultDateTimeAnalyzer = new DateTimeAnalyzer();
        }

        [Test, Order(1)]
        public void ParseDateTime_ShouldReturnCorrectOutput()
        {
            var output = _defaultDateTimeAnalyzer.extractDateTimesFromStringArrays(new[] {stringtifiedDateTime}, "_", true);
            Assert.IsNotEmpty(output, "Extraction failed");
            var firstOutput = output.First();
            assertIsEqualsToTarget(firstOutput);
        }

        [Test, Order(2)]
        public void FindClosestDateTimeInList_ShouldReturnCorrectOutput()
        {
            var input = generateALotOfFakedDates();
            var expected = _defaultDateTimeAnalyzer.extractDateTimesFromStringArrays(new[] {stringtifiedDateTime}, "_", true).First();
            var result = _defaultDateTimeAnalyzer.findTheMostClosestDateTime(expected, input, false, false, false);
            assertIsEqualsToTarget(result);
        }

        private void assertIsEqualsToTarget(System.DateTime target)
        {
            Assert.AreEqual(2021, target.Year);
            Assert.AreEqual(4, target.Month);
            Assert.AreEqual(5, target.Day);
            Assert.AreEqual(11, target.Hour);
            Assert.AreEqual(35, target.Minute);
            Assert.AreEqual(27, target.Second);
        }

        private LinkedList<System.DateTime> generateALotOfFakedDates()
        {
            var result = new LinkedList<System.DateTime>();
            var targetDateTime = _defaultDateTimeAnalyzer.extractDateTimesFromStringArrays(new[] {stringtifiedDateTime}, "_");
            var randomizer = new Random();

            for (int i = 0; i < short.MaxValue; i++)
            {
                if (short.MaxValue / 2 == i)
                    result.AddLast(targetDateTime.First());
                result.AddLast(generateRandomDateTime(randomizer));
            }
            
            return result;
        }

        private System.DateTime generateRandomDateTime(Random randomizer, int range = Int32.MaxValue)
        {
            var start = new System.DateTime(1995, 1, 1);
            return start.AddMilliseconds(randomizer.Next(range));
        }
    }
}
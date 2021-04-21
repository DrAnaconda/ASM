using System.Collections.Generic;
using NUnit.Framework;
using Tools.Library.Analyzers.String.Abstractions;
using Tools.Library.Analyzers.String.Implementations.SimilarityTool.LevenshteinTools;

namespace Tools.Library.Analyzers.Tests
{
    public class StringSimilarityTests
    {
        private const string obviousDateTime = "Time_2021_04_05_11_35_27.png"; 
            
        private IStringSimilarityTool _levenshteinTool;
        
        [SetUp]
        public void Setup()
        {
            _levenshteinTool = new LevenshteinStringSimilarityTool();
        }

        [Test]
        public void FindTheMostSimilarString_ObviousInput_ShouldReturnTarget()
        {
            var testList = generateList(true);
            var result = _levenshteinTool.findTheMostSimilarString(testList, obviousDateTime);
            Assert.AreEqual(obviousDateTime, result);
        }

        [Test]
        public void FindTheMostSimilarSting_NotObviousInputShouldReturnClosest()
        {
            var testList = generateList(true);
            var result = _levenshteinTool.findTheMostSimilarString(testList, "Time_2021_04_86_14_52_54.png");
            Assert.AreEqual("Time_2021_04_86_14_53_54.png", result);
        }


        private List<string> generateList(bool shouldHaveObviousDateTime)
        {
            var result = new List<string>();
            result.Add("Time_2021_04_06_15_37_57.png");
            result.Add("Time_2021_04_26_14_54_54.png");
            if (shouldHaveObviousDateTime) result.Add(obviousDateTime);
            result.Add("Time_2021_04_86_14_53_54.png");
            result.Add("Time_2021_04_06_15_57_32.png");
            return result;
        }
    }
}
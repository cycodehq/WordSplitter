using System.Collections.Generic;
using FluentAssertions;
using WordSplitter;
using Xunit;

namespace WordSplitterTester {
    public class WordSplitterTests {
        [Theory]
        [MemberData(nameof(TestData.TestScenarios), MemberType = typeof(TestData))]
        public void TestScenarios(string input, List<string> expectedOutput) {
            var result = input.SplitWords();

            result.Should().BeEquivalentTo(expectedOutput);
        }
    }
}

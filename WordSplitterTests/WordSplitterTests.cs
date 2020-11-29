using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace WordSplitterTester {
    public class WordSplitterTests {
        [Theory]
        [MemberData(nameof(TestData.TestScenarios), MemberType = typeof(TestData))]
        public void TestScenarios(string input, List<string> expectedOutput) {
            var result = WordSplitter.WordSplitter.SplitWordToKeywords(input);

            result.Should().BeEquivalentTo(expectedOutput);
        }
    }
}

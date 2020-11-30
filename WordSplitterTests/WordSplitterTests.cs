using System.Collections.Generic;
using FluentAssertions;
using WordSplitter;
using Xunit;

namespace WordSplitterTester {
    public class WordSplitterTests {
        [Theory]
        [MemberData(nameof(TestData.TestScenarios), MemberType = typeof(TestData))]
        public void TestScenarios_ShouldReturnExpectedOutput(string input, List<string> expectedOutput) {
            var result = input.SplitWords();

            result.Should().BeEquivalentTo(expectedOutput);
        }

        [Fact]
        public void WordSplitter_ConfigurationReturnResultsInLowerCase_ShouldReturnResultInLowerCase() {
            const string input = "ABC_DEF";
            var configuration = new WordSplitterConfiguration {
                ShouldReturnResultsInLowerCase = true
            };

            var result = input.SplitWords(configuration);

            var expectedOutput = new List<string> {"abc", "def"};
            result.Should().BeEquivalentTo(expectedOutput);
        }

        [Fact]
        public void WordSplitter_ConfigurationSpecificDelimiters_ShouldReturnAccordingToDelimiters() {
            var configuration = new WordSplitterConfiguration {
                Delimiters = new List<char> {'W'}
            };

            const string inputWithNewDelimiters = "ABCWDEF";
            var result = inputWithNewDelimiters.SplitWords(configuration);

            var expectedOutput = new List<string> {"ABC", "DEF"};
            result.Should().BeEquivalentTo(expectedOutput);

            const string inputDefaultDelimiters = "abcWdef";
            result = inputDefaultDelimiters.SplitWords();
            expectedOutput = new List<string> {"abc", "Wdef"};
            result.Should().BeEquivalentTo(expectedOutput);
        }
    }
}

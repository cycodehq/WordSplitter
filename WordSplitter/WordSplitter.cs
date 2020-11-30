using System;
using System.Collections.Generic;
using System.Linq;

namespace WordSplitter {
    public static class WordSplitterExtension {
        private static readonly List<char> DefaultWordSplittingChars = new List<char> {
            '-', '_', '.', ' ', ';'
        };

        public static List<string> SplitWords(this String input,
            WordSplitterConfiguration? wordSplitterConfiguration = null) {
            var wordSplittingChars = wordSplitterConfiguration?.Delimiters ?? DefaultWordSplittingChars;

            var result = new List<string>();
            if (string.IsNullOrEmpty(input)) {
                return result;
            }

            var currentWordState = WordState.LowerCase;
            var currentKeywordIndex = 0;
            for (int currentIndex = 0; currentIndex < input.Length; currentIndex++) {
                var currentChar = input[currentIndex];
                if (wordSplittingChars.Contains(currentChar)) {
                    AddKeywordToResult(input, currentKeywordIndex, currentIndex, result);
                    currentKeywordIndex = currentIndex + 1;
                    continue;
                }

                if (!char.IsLetter(currentChar)) {
                    continue;
                }

                var isCurrentCharLower = char.IsLower(currentChar);
                if (HasLowerCaseSequenceFinished(isCurrentCharLower, currentWordState)) {
                    AddKeywordToResult(input, currentKeywordIndex, currentIndex, result);
                    currentKeywordIndex = currentIndex;
                }
                else if (HasUpperCaseSequenceFinished(isCurrentCharLower, currentWordState, currentIndex,
                    currentKeywordIndex)) {
                    AddKeywordToResult(input, currentKeywordIndex, currentIndex - 1, result);
                    currentKeywordIndex = currentIndex - 1;
                }

                currentWordState = isCurrentCharLower ? WordState.LowerCase : WordState.UpperCase;
            }

            // Reached end of string.
            // If the `currentKeywordIndex` is smaller than the string index, it means the
            // last keyword needs to be added.
            if (currentKeywordIndex < input.Length) {
                var keyword = input.Substring(currentKeywordIndex);
                result.Add(keyword);
            }

            return result
                .Where(keyword => !string.IsNullOrEmpty(keyword))
                .Select(keyword => wordSplitterConfiguration?.ShouldReturnResultsInLowerCase == true
                    ? keyword.ToLower()
                    : keyword)
                .ToList();
        }

        private static bool HasUpperCaseSequenceFinished(bool isCurrentCharLower, WordState currentWordState,
            int currentIndex, int currentKeywordIndex) {
            return isCurrentCharLower && currentWordState == WordState.UpperCase &&
                   currentIndex - currentKeywordIndex > 1;
        }

        private static bool HasLowerCaseSequenceFinished(bool isCurrentCharLower, WordState currentWordState) {
            return !isCurrentCharLower && currentWordState == WordState.LowerCase;
        }

        private static void AddKeywordToResult(string input, int lastKeywordIndex, int currentIndex,
            List<string> result) {
            var keyword = input.Substring(lastKeywordIndex, currentIndex - lastKeywordIndex);
            result.Add(keyword);
        }
    }
}

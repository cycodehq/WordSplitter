using System.Collections.Generic;
using System.Linq;

namespace WordSplitter {
    public static class WordSplitter {
        private static readonly List<char> WordSplittingChars = new List<char> {
            '-', '_', ' '
        };

        public static List<string> SplitWords(string input) {
            var result = new List<string>();
            if (string.IsNullOrEmpty(input)) {
                return result;
            }

            var currentState = WordState.LowerCase;
            var currentKeywordIndex = 0;
            for (int i = 0; i < input.Length; i++) {
                var currentChar = input[i];
                if (WordSplittingChars.Contains(currentChar)) {
                    AddKeywordToResult(input, currentKeywordIndex, i, result);
                    currentKeywordIndex = i + 1;
                    continue;
                }

                var isCurrentCharLower = char.IsLower(currentChar);
                // if (WasStateChanged(isCurrentCharLower, currentState) && i != 0) {
                if (!isCurrentCharLower && currentState == WordState.LowerCase && i != 0) {
                    AddKeywordToResult(input, currentKeywordIndex, i, result);
                    currentKeywordIndex = i;
                }

                if (isCurrentCharLower && currentState == WordState.UpperCase && i - currentKeywordIndex > 1) {
                    AddKeywordToResult(input, currentKeywordIndex, i - 1, result);
                    currentKeywordIndex = i - 1;
                }

                currentState = isCurrentCharLower ? WordState.LowerCase : WordState.UpperCase;
            }

            if (currentKeywordIndex < input.Length) {
                var keyword = input.Substring(currentKeywordIndex);
                result.Add(keyword);
            }

            return result
                .Where(keyword => !string.IsNullOrEmpty(keyword))
                .ToList();
        }

        private static bool WasStateChanged(bool isCurrentCharLower, WordState currentState) =>
            isCurrentCharLower && currentState == WordState.UpperCase ||
            !isCurrentCharLower && currentState == WordState.LowerCase;

        private static void AddKeywordToResult(string input, int lastKeywordIndex, int currentIndex, List<string> result) {
            var keyword = input.Substring(lastKeywordIndex, currentIndex - lastKeywordIndex);
            result.Add(keyword);
        }
    }
}

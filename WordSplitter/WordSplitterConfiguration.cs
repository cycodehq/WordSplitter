using System.Collections.Generic;

namespace WordSplitter {
    public class WordSplitterConfiguration {
        public bool ShouldReturnResultsInLowerCase { get; set; } = false;
        public List<char> Delimiters { get; set; } = null!;
    }
}

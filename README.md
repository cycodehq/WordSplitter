# WordSplitter
C# library to split a string into its containing words.

### Examples

#### Hyphen and underscore as delimiters
```
"first-second-third".SplitWords();
["first", "second", "third"]

"first_second_third".SplitWords();
["first", "second", "third"]
```

#### CamelCase
```
"CamelCase".SplitWords();
["Camel", "Case"]
```

#### UpperCase
```
"TheBIGHouse".SplitWords();
["The", "Big", "House"]
```

## Configuration

- ShouldReturnResultsInLowerCase
```
const string input = "ABC_DEF";
var configuration = new WordSplitterConfiguration {
    ShouldReturnResultsInLowerCase = true
};

input.SplitWords(configuration);
["abc", "def"]
```

- Custom Delimiters
```
var configuration = new WordSplitterConfiguration {
    Delimiters = new List<char> {'W'}
};

const string inputWithNewDelimiters = "ABCWDEF";
["ABC", "DEF"]
```

#### Default Configuration
- ShouldReturnResultsInLowerCase: `false`
- Delimiters: `['-', '_', '.', ' ', ';']`

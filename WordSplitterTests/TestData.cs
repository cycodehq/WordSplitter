using System;
using System.Collections.Generic;

namespace WordSplitterTester {
    public class TestData {
        public static IEnumerable<Object[]> TestScenarios {
            get {
                yield return new object[] {
                    string.Empty,
                    new List<string>()
                };

                yield return new object[] {
                    "abc",
                    new List<string> {"abc"}
                };

                yield return new object[] {
                    "ABC",
                    new List<string> {"ABC"}
                };

                yield return new object[] {
                    "ab-cd",
                    new List<string> {"ab", "cd"}
                };

                yield return new object[] {
                    "first_second_third",
                    new List<string> {"first", "second", "third"}
                };

                yield return new object[] {
                    "aBigHouse",
                    new List<string> {"a", "Big", "House"}
                };

                yield return new object[] {
                    "aBIGHouse",
                    new List<string> {"a", "BIG", "House"}
                };

                yield return new object[] {
                    "some-bigThing",
                    new List<string> {"some", "big", "Thing"}
                };

                yield return new object[] {
                    "CamelCase",
                    new List<string> {"Camel", "Case"}
                };

                yield return new object[] {
                    "BIG_HOUSE",
                    new List<string> {"BIG", "HOUSE"}
                };

                yield return new object[] {
                    "VERY_BIG-HOUSE",
                    new List<string> {"VERY", "BIG", "HOUSE"}
                };

                yield return new object[] {
                    "one---two",
                    new List<string> {"one", "two"}
                };

                yield return new object[] {
                    "one---___----two",
                    new List<string> {"one", "two"}
                };

                yield return new object[] {
                    "--ab__cd--ef--__",
                    new List<string> {"ab", "cd", "ef"}
                };

                yield return new object[] {
                    "one and two",
                    new List<string> {"one", "and", "two"}
                };

                yield return new object[] {
                    "aBc",
                    new List<string> {"a", "Bc"}
                };

                yield return new object[] {
                    "a123Test",
                    new List<string> {"a123", "Test"}
                };

                yield return new object[] {
                    "Test123Test",
                    new List<string> {"Test123", "Test"}
                };

                yield return new object[] {
                    "Test-123-Test",
                    new List<string> {"Test", "123", "Test"}
                };

                yield return new object[] {
                    "aa1Bb2",
                    new List<string> {"aa1", "Bb2"}
                };
            }
        }
    }
}

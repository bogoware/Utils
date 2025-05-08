# Common Utils Library

This repository is a collection of common utilities designed to streamline development by providing reusable, easy-to-integrate code snippets. The intent is to allow developers to **cut & paste** these utilities directly into their projects for quick and effective use.

## Features

The **Common Utils Library** provides the following utility classes and methods for simplifying common development tasks:

### **StringTokenizer**
   A utility class for tokenizing strings into substrings based on specified delimiters, with customizable options.

   - **Constructor:**
     - `StringTokenizer(StringTokenizer.TokenizerOptions? options = null):` Initializes a new instance with optional tokenizer settings.

   - **TokenizerOptions:**
     - **Delimiters:** An array of characters used to split the string. Default: `[ ' ', ',', ';', ':', '.', '!', '?' ]`.
     - **RemoveEmptyEntries:** A boolean indicating whether to exclude empty tokens. Default: `true`.
     - **TrimEntries:** A boolean indicating whether to trim whitespace from tokens. Default: `true`.

   - **Methods:**
     - **GetTokens(string query):** Splits the input string into tokens based on the specified delimiters and options.
       - **Returns:** An `IEnumerable<string>` containing the resulting tokens.

   - **Example:**
     ```csharp
     var tokenizer = new StringTokenizer(new StringTokenizer.TokenizerOptions
     {
         Delimiters = new[] { ',', ';' },
         RemoveEmptyEntries = true,
         TrimEntries = true
     });

     var tokens = tokenizer.GetTokens("apple, banana; orange");
     // Result: ["apple", "banana", "orange"]
     ```

### **TypeExtensions**
   - **IsSubclassOfRawGeneric(Type type, Type generic):**   
     Determines whether a given type is a subclass of a generic type.  
     Example: `typeof(B).IsSubclassOfRawGeneric(typeof(A<>));`

### **StringExtensions** (fluent API)
   - **IsNullOrEmpty(string? value):**  
     Checks if a string is null or an empty string.
   - **IsNullOrWhiteSpace(string? value):**  
     Checks if a string is null, empty, or consists only of whitespace characters.

### **ToStringHelpers** (fluent API)
   Provides helper methods to convert various types into their string representations using invariant culture formatting.
   - Examples:
     - **ToStringInvariant(byte obj):** Converts a byte to its string representation.
     - **ToStringInvariant(DateOnly obj):** Converts a `DateOnly` object to its string representation.

### **StringParseHelpers** (fluent API)
   Provides methods for parsing strings into various types using invariant culture.
   - Examples:
     - **ParseToIntInvariant(string obj):** Parses a string into an integer.
     - **ParseToDateTimeInvariant(string obj):** Parses a string into a `DateTime`.

### **CombinationGeneratorExtensions**
   Utilities for generating combinations from dictionaries and enumerables.
   - **GetAllCombinationsByKey<TKey, TValue>(IDictionary<TKey, IEnumerable<TValue>> dictionary):**  
     Generates all possible value combinations grouped by their respective keys.
   - **GetAllCombinations<T>(IEnumerable<T> enumerable):**  
     Generates all subsets for an enumerable, including the empty subset.

## Contributing

Contributions to this repository are most welcome! If you have utilities you believe would benefit other developers, feel free to submit a pull request. Please ensure all new utilities include:

1. Clear and concise documentation.
2. Unit tests to verify functionality and edge cases.
3. Code consistent with repository standards.

## License

This project is available under the **MIT License**, allowing you the freedom to use, modify, and distribute the utilities as needed.

---

We hope this library saves you time, reduces complexity, and enhances your projects' maintainability. Happy coding!
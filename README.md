# Common Utils Library

This repository is a collection of common utilities designed to streamline development by providing reusable, easy-to-integrate code snippets. The intent is to allow developers to **cut & paste** these utilities directly into their projects for quick and effective use.

## Features

The **Common Utils Library** provides the following utility classes and methods for simplifying common development tasks:

### 1. **TypeExtensions**
   - **IsSubclassOfRawGeneric(Type type, Type generic):**   
     Determines whether a given type is a subclass of a generic type.  
     Example: `typeof(B).IsSubclassOfRawGeneric(typeof(A<>));`

### 2. **StringExtensions** (fluent API)
   - **IsNullOrEmpty(string? value):**  
     Checks if a string is null or an empty string.
   - **IsNullOrWhiteSpace(string? value):**  
     Checks if a string is null, empty, or consists only of whitespace characters.

### 3. **ToStringHelpers** (fluent API)
   Provides helper methods to convert various types into their string representations using invariant culture formatting.
   - Examples:
     - **ToStringInvariant(byte obj):** Converts a byte to its string representation.
     - **ToStringInvariant(DateOnly obj):** Converts a `DateOnly` object to its string representation.

### 4. **StringParseHelpers** (fluent API)
   Provides methods for parsing strings into various types using invariant culture.
   - Examples:
     - **ParseToIntInvariant(string obj):** Parses a string into an integer.
     - **ParseToDateTimeInvariant(string obj):** Parses a string into a `DateTime`.

### 5. **CombinationGeneratorExtensions**
   Utilities for generating combinations from dictionaries and enumerables.
   - **GetAllCombinationsByKey<TKey, TValue>(IDictionary<TKey, IEnumerable<TValue>> dictionary):**  
     Generates all possible value combinations grouped by their respective keys.
   - **GetAllCombinations<T>(IEnumerable<T> enumerable):**  
     Generates all subsets for an enumerable, including the empty subset.

---

These utility classes provide flexible and reusable methods that reduce boilerplate code and simplify common operations in .NET applications.

## Contributing

Contributions to this repository are most welcome! If you have utilities you believe would benefit other developers, feel free to submit a pull request. Please ensure all new utilities include:

1. Clear and concise documentation.
2. Unit tests to verify functionality and edge cases.
3. Code consistent with repository standards.

## License

This project is available under the **MIT License**, allowing you the freedom to use, modify, and distribute the utilities as needed.

---

We hope this library saves you time, reduces complexity, and enhances your projects' maintainability. Happy coding!
namespace Bogoware.Utils;

/// <summary>
/// Provides extension methods for generating combinations of elements from dictionaries and enumerables.
/// </summary>
/// <remarks>
/// Source code is available at <a href="https://github.com/bogoware/Utils">Bogoware.Utils</a>.
/// </remarks>
public static class CombinationGeneratorExtensions
{
    /// <summary>
    /// Generates all possible combinations of values, grouped by their respective keys from the provided dictionary.
    /// Each combination is a list containing one value from each key in the input dictionary.
    /// Allows skipping keys during combination generation.
    /// </summary>
    /// <param name="dictionary">A dictionary where each key is associated with a list of possible values.
    /// This input determines the structure for generating combinations.</param>
    /// <returns>A list of lists, where each inner list represents a unique combination of values from the input dictionary.</returns>
    public static List<List<TV>> GetAllCombinationsByKey<TK, TV>(this IDictionary<TK, IEnumerable<TV>> dictionary)
        where TK : notnull
    {
        var keys = dictionary.Keys.ToList();
        var result = new List<List<TV>>();

        // Start the recursion
        Backtrack(0, []);
        return result;

        // Recursive helper function
        void Backtrack(int index, List<TV> currentCombination)
        {
            while (true)
            {
                if (index == keys.Count)
                {
                    // Add a copy of the current combination to the result
                    result.Add([..currentCombination]);
                    return;
                }

                var key = keys[index];
                var elements = dictionary[key];

                // Create combinations for the current key's elements
                foreach (var element in elements)
                {
                    currentCombination.Add(element);
                    Backtrack(index + 1, currentCombination);
                    currentCombination.RemoveAt(currentCombination.Count - 1);
                }

                // Also consider the case where the key could be skipped
                index++;
            }
        }
    }

    /// <inheritdoc cref="GetCombinationsByKeyByKey{TK,TV}"/>
    public static List<List<TV>> GetAllCombinationsByKey<TK, TV>(this IDictionary<TK, List<TV>> dictionary)
        where TK : notnull
        => GetAllCombinationsByKey(dictionary.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.AsEnumerable()));

    /// <summary>
    /// Generates all possible combinations of elements from the provided enumerable.
    /// Each combination is represented as a list, and all subsets, including the empty subset, are generated.
    /// </summary>
    /// <param name="enumerable">An enumerable of elements from which combinations will be generated.</param>
    /// <returns>A list of lists, where each inner list is a unique combination of elements from the input enumerable.</returns>
    public static List<List<T>> GetAllCombinations<T>(this IEnumerable<T> enumerable)
    {
        // Convert the enumerable to a list for consistent use
        var items = enumerable.ToList();
        var result = new List<List<T>>();

        // Start generating combinations
        for (var i = 0; i < (1 << items.Count); i++)
        {
            var combination = new List<T>();

            for (var j = 0; j < items.Count; j++)
            {
                // Check if the j-th element is included in the combination
                if ((i & (1 << j)) != 0)
                {
                    combination.Add(items[j]);
                }
            }

            result.Add(combination);
        }

        return result;
    }
}
// ReSharper disable PropertyCanBeMadeInitOnly.Global

namespace Bogoware.Utils;

/// <summary>
/// A utility class for tokenizing strings into substrings based on specified delimiters,
/// with support for custom options such as removing empty entries and trimming tokenized results.
/// </summary>
/// <remarks>
/// Source code is available at <a href="https://github.com/bogoware/Utils">Bogoware.Utils</a>.
/// </remarks>
public class StringTokenizer(StringTokenizer.TokenizerOptions? options = null)
{
    public class TokenizerOptions
    {
#pragma warning disable CA1819
        public char[] Delimiters { get; set; } = [' ', ',', ';', ':', '.', '!', '?'];
#pragma warning restore CA1819
        public bool RemoveEmptyEntries { get; set; } = true;
        public bool TrimEntries { get; set; } = true;
    }

    public TokenizerOptions Options { get; } = options ?? new TokenizerOptions();

    public IEnumerable<string> GetTokens(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            return [];
        }

        StringSplitOptions splitOptions = StringSplitOptions.None;
        if (Options.RemoveEmptyEntries)
        {
            splitOptions |= StringSplitOptions.RemoveEmptyEntries;
        }

        if (Options.TrimEntries)
        {
            splitOptions |= StringSplitOptions.TrimEntries;
        }

        // Split the query into tokens based on whitespace and punctuation
        var tokens = query.Split(Options.Delimiters, splitOptions);

        return tokens;
    }
}
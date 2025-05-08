using Bogoware.Utils;
using FluentAssertions;

namespace Tests;

public class StringTokenizerOptionsTests
{
    [Fact]
    public void Should_Return_Empty_When_InputString_IsEmpty()
    {
        // Arrange
        var input = string.Empty;
        var sut = new StringTokenizer();

        // Act
        var result = sut.GetTokens(input);

        // Assert
        result.Should().BeEmpty();
    }

    [Fact]
    public void Should_Return_Tokens_When_InputString_IsNotEmpty()
    {
        // Arrange
        const string input = "one,two,three";
        var sut = new StringTokenizer();

        // Act
        var result = sut.GetTokens(input);

        // Assert
        result.Should().BeEquivalentTo(["one", "two", "three"], x => x.WithStrictOrdering());
    }

    [Fact]
    public void Should_SkipEmptyEntries_When_OptionIsTrue()
    {
        // Arrange
        const string input = "one,,two,,three";
        var sut = new StringTokenizer();

        // Act
        var result = sut.GetTokens(input);

        // Assert
        result.Should().BeEquivalentTo(["one", "two", "three"], x => x.WithStrictOrdering());
    }

    [Fact]
    public void Should_NotSkipEmptyEntries_When_OptionIsFalse()
    {
        // Arrange
        const string input = "one,,two,,three";
        var options = new StringTokenizer.TokenizerOptions()
        {
            RemoveEmptyEntries = false,
            TrimEntries = false
        };
        var sut = new StringTokenizer(options);

        // Act
        var result = sut.GetTokens(input);

        // Assert
        result.Should().BeEquivalentTo(["one", "", "two", "", "three"], x => x.WithStrictOrdering());
    }

    [Fact]
    public void Should_TrimTokens_When_OptionIsTrue()
    {
        // Arrange
        const string input = "  one ,  two , three  ";
        var options = new StringTokenizer.TokenizerOptions()
        {
            RemoveEmptyEntries = true,
            TrimEntries = true
        };
        var sut = new StringTokenizer(options);
        // Act
        var result = sut.GetTokens(input);
        // Assert
        result.Should().BeEquivalentTo(["one", "two", "three"], x => x.WithStrictOrdering());
    }

    [Fact]
    public void Should_NotTrimTokens_When_OptionIsFalse()
    {
        // Arrange
        const string input = "  one ,  two , three  ";
        var options = new StringTokenizer.TokenizerOptions()
        {
            Delimiters = [','],
            RemoveEmptyEntries = true,
            TrimEntries = false
        };
        var sut = new StringTokenizer(options);

        // Act
        var result = sut.GetTokens(input);

        // Assert
        result.Should().BeEquivalentTo(["  one ", "  two ", " three  "], x => x.WithStrictOrdering());
    }
}
using Bogoware.Utils;
using FluentAssertions;

namespace Tests;

public class CombinationGeneratorDictionaryTests
{
    private static readonly VerifySettings _verifySettings;
    
    static CombinationGeneratorDictionaryTests()
    {
        _verifySettings = new VerifySettings();
        _verifySettings.UseDirectory("CombinationGeneratorValidationData");
    }
    
    [Fact]
    public void EmptyDictionary_produces_emptySet()
    {
        // Arrange
        var dictionary = new Dictionary<string, List<string>>();
        
        // Act
        var result = dictionary.GetAllCombinationsByKey();
        
        // Assert
        result.Should().HaveCount(1);
        result.First().Should().BeEmpty();
    }

    [Fact]
    public Task SingleKeyValue_produces_singleSet()
    {
        // Arrange
        var dictionary = new Dictionary<string, List<string>>
        {
            { "key1", ["1", "2", "3"] }
        };

        // Act
        var result = dictionary.GetAllCombinationsByKey();

        // Assert
        result.Should().HaveCount(4);
        result.Should().Contain(item => item.Count == 0);
        
        // Verify the combinations
        // [] // Verify does not include empty set
        // [1]
        // [2]
        // [3]
        return Verify(result, _verifySettings);
    }

    [Fact]
    public Task MultipleKeyValue_produces_allCombinations()
    {
        // Arrange
        var dictionary = new Dictionary<string, List<string>>
        {
            { "key1", ["1", "2"] },
            { "key2", ["A", "B"] }
        };
        // Act
        var result = dictionary.GetAllCombinationsByKey();
        // Assert
        result.Should().HaveCount(9);
        result.Should().Contain(item => item.Count == 0);
        
        // Verify the combinations
        // [] // Verify does not include empty set
        // [1]
        // [2]
        // [A]
        // [B]
        // [1, A]
        // [1, B]
        // [2, A]
        // [2, B]
        return Verify(result, _verifySettings);
    }
}
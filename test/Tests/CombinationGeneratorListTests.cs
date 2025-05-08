using Bogoware.Utils;
using FluentAssertions;

namespace Tests;

public class CombinationGeneratorListTests
{
    private static readonly VerifySettings _verifySettings;
    
    static CombinationGeneratorListTests()
    {
        _verifySettings = new VerifySettings();
        _verifySettings.UseDirectory("CombinationGeneratorValidationData");
    }
        
    [Fact]
    public void GenerateCombinations_EmptyList_ReturnsEmptyList()
    {
        // Arrange
        var input = new List<int>();

        // Act
        var result = input.GetAllCombinations();

        // Assert
        result.Should().HaveCount(1);
        result.First().Should().BeEmpty();
    }
    
    [Fact]
    public Task GenerateCombinations_SingleElementList_ReturnsSingleElementList()
    {
        // Arrange
        var input = new List<int> { 1 };

        // Act
        var result = input.GetAllCombinations();

        // Assert
        result.Should().HaveCount(2);
        result.Should().Contain(item => item.Count == 0);
        
        return Verify(result, _verifySettings);
    }
    
    [Fact]
    public Task GenerateCombinations_MultipleElementList_ReturnsAllCombinations()
    {
        // Arrange
        var input = new List<int> { 1, 2, 3 };

        // Act
        var result = input.GetAllCombinations();

        // Assert
        result.Should().HaveCount(8);
        result.Should().Contain(item => item.Count == 0);
        
        return Verify(result, _verifySettings);
    }
}
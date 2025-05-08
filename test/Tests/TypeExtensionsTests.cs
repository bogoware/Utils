// ReSharper disable UnusedTypeParameter

using System.Diagnostics.CodeAnalysis;
using Bogoware.Utils;
using FluentAssertions;

namespace Lechler.Catalogue.Utils.UnitTests;

[SuppressMessage("Minor Code Smell", "S2094:Classes should not be empty")]
[SuppressMessage("Major Code Smell", "S2326:Unused type parameters should be removed")]
[SuppressMessage("Style", "IDE0058:Expression value is never used")]
public class TypeExtensionsTests
{
    private class A<T1, T2>;
    private class B : A<int, int>;

    [Fact]
    public void IsSubclassOfRawGeneric_ShouldReturnTrue_WhenTypeIsSubclassOfGenericType()
    {
        // Arrange
        var type = typeof(B);
        var generic = typeof(A<,>);

        // Act
        var result = type.IsSubclassOfRawGeneric(generic);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void IsSubclassOfRawGeneric_ShouldReturnFalse_WhenTypeIsNotSubclassOfGenericType()
    {
        // Arrange
        var type = typeof(B);
        var generic = typeof(A<string, string>);

        // Act
        var result = type.IsSubclassOfRawGeneric(generic);

        // Assert
        result.Should().BeFalse();
    }
}
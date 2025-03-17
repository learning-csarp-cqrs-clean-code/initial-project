using DomainLayer.ValueObjects;
using FluentAssertions;
using System.Xml.Linq;

namespace InitialProject.Test.Test.Domain.ValueObjects
{
    public class NameTests
    {
        [Fact]
        public void Constructor_Should_Create_Valid_Name()
        {
            // Arrange
            string validName = "John Doe";

            // Act
            var name = new Name(validName);

            // Assert
            name.Value.Should().Be(validName);
        }

        [Theory]
        [InlineData("")]  // Üres név
        [InlineData(" ")] // Csak szóközök
        [InlineData("J")] // Túl rövid
        [InlineData("john doe")] // Kisbetûs kezdés
        [InlineData("John ")] // Utolsó karakter szóköz
        [InlineData(" John")] // Elsõ karakter szóköz
        [InlineData("John--Doe")] // Kettõs kötõjel
        [InlineData("John  Doe")] // Kettõs szóköz
        [InlineData("John-d")] // Kötõjel után kisbetû
        [InlineData("John doe")] // Szóköz után kisbetû
        public void Constructor_Should_Throw_Exception_For_Invalid_Names(string invalidName)
        {
            // Act
            Action act = () => new Name(invalidName);

            // Assert
            act.Should().Throw<ArgumentException>();
        }
    }
}

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
        [InlineData("")]  // �res n�v
        [InlineData(" ")] // Csak sz�k�z�k
        [InlineData("J")] // T�l r�vid
        [InlineData("john doe")] // Kisbet�s kezd�s
        [InlineData("John ")] // Utols� karakter sz�k�z
        [InlineData(" John")] // Els� karakter sz�k�z
        [InlineData("John--Doe")] // Kett�s k�t�jel
        [InlineData("John  Doe")] // Kett�s sz�k�z
        [InlineData("John-d")] // K�t�jel ut�n kisbet�
        [InlineData("John doe")] // Sz�k�z ut�n kisbet�
        public void Constructor_Should_Throw_Exception_For_Invalid_Names(string invalidName)
        {
            // Act
            Action act = () => new Name(invalidName);

            // Assert
            act.Should().Throw<ArgumentException>();
        }
    }
}

using System.ComponentModel.DataAnnotations;
using App.Attributes;
using FluentAssertions;
using Xunit;

namespace Tests.Attributes
{
    public class CountryValidatorAttributeTests
    {
        [Theory]
        [InlineData("BE")]
        [InlineData("nl-BE")]
        public void Should_Be_Valid_Culture(string culture)
        {
            // arrange
            var validator = new CountryValidatorAttribute();
            var context = new ValidationContext(culture);

            // act
            var result = validator.GetValidationResult(culture, context);

            // assert
            result.Should().Be(ValidationResult.Success);
        }

        [Theory]
        [InlineData("fr-FR")]
        [InlineData("es-ES")]
        public void Should_not_Be_Valid_Culture(string culture)
        {
            // arrange
            var validator = new CountryValidatorAttribute();
            var context = new ValidationContext(culture);

            // act
            var result = validator.GetValidationResult(culture, context);

            // assert
            result.Should().NotBe(ValidationResult.Success);
        }
    }
}
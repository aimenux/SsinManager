using System.ComponentModel.DataAnnotations;
using App.Attributes;
using FluentAssertions;
using Xunit;

namespace Tests.Attributes
{
    public class CountryValidatorAttributeTests
    {
        [Theory]
        [InlineData("Belgium")]
        [InlineData("BELGIUM")]
        public void Should_Be_Valid_Country(string country)
        {
            // arrange
            var validator = new CountryValidatorAttribute();
            var context = new ValidationContext(country);

            // act
            var result = validator.GetValidationResult(country, context);

            // assert
            result.Should().Be(ValidationResult.Success);
        }

        [Theory]
        [InlineData("Spain")]
        [InlineData("France")]
        public void Should_not_Be_Valid_Country(string country)
        {
            // arrange
            var validator = new CountryValidatorAttribute();
            var context = new ValidationContext(country);

            // act
            var result = validator.GetValidationResult(country, context);

            // assert
            result.Should().NotBe(ValidationResult.Success);
        }
    }
}
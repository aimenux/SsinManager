using FluentAssertions;
using Lib.Ssins;
using Xunit;

namespace Tests.Ssins
{
    public class BelgianSsinValidatorTests
    {
        [Theory]
        [InlineData("86022402508")]
        [InlineData("60061812456")]
        [InlineData("44121181161")]
        [InlineData("42082713590")]
        [InlineData("28061220565")]
        [InlineData("10110849339")]
        [InlineData("81050312962")]
        [InlineData("77090381596")]
        [InlineData("19092101115")]
        [InlineData("60090301554")]
        [InlineData("48021121292")]
        [InlineData("34080863490")]
        [InlineData("57070991264")]
        public void Should_Be_Valid_Ssin(string ssin)
        {
            // arrange
            var validator = new BelgianSsinValidator();

            // act
            var isValid = validator.IsValid(ssin);

            // assert
            isValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("86022402507")]
        [InlineData("60061812455")]
        [InlineData("44121181162")]
        [InlineData("42082713591")]
        [InlineData("28061220564")]
        [InlineData("10110849338")]
        [InlineData("81050312963")]
        [InlineData("77090381597")]
        [InlineData("19092101116")]
        [InlineData("60090301555")]
        [InlineData("48021121293")]
        [InlineData("34080863499")]
        [InlineData("57070991268")]
        public void Should_Not_Be_Valid_Ssin(string ssin)
        {
            // arrange
            var validator = new BelgianSsinValidator();

            // act
            var isValid = validator.IsValid(ssin);

            // assert
            isValid.Should().BeFalse();
        }
    }
}

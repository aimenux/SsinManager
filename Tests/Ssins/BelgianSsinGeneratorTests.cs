using FluentAssertions;
using Lib.Helpers;
using Lib.Ssins;
using Xunit;

namespace Tests.Ssins
{
    public class BelgianSsinGeneratorTests
    {
        [Fact]
        public void Should_Generate_Valid_Ssin()
        {
            // arrange
            var helper = new RandomHelper();
            var generator = new BelgianSsinGenerator(helper);
            var validator = new BelgianSsinValidator();

            // act
            var ssin = generator.GenerateSsin();
            var isValid = validator.IsValid(ssin);

            // assert
            ssin.Should().NotBeNullOrEmpty();
            isValid.Should().BeTrue();
        }
    }
}

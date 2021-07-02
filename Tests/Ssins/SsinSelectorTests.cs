using FluentAssertions;
using Lib.Helpers;
using Lib.Ssins;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Tests.Ssins
{
    public class SsinSelectorTests
    {
        [Theory]
        [InlineData("Belgium")]
        [InlineData("BELGIUM")]
        public void Should_Get_Validator_For_Supported_Country(string country)
        {
            // arrange
            var services = new ServiceCollection();
            services.AddTransient<ISsinValidator, BelgianSsinValidator>();
            var serviceProvider = services.BuildServiceProvider();
            var selector = new SsinSelector(serviceProvider);

            // act
            var validator = selector.Resolve<ISsinValidator>(country);

            // assert
            validator.Should().NotBeNull();
            validator.Should().BeOfType<BelgianSsinValidator>();
        }

        [Theory]
        [InlineData("Spain")]
        [InlineData("France")]
        public void Should_Not_Get_Validator_For_NotSupported_Country(string country)
        {
            // arrange
            var services = new ServiceCollection();
            services.AddTransient<ISsinValidator, BelgianSsinValidator>();
            var serviceProvider = services.BuildServiceProvider();
            var selector = new SsinSelector(serviceProvider);

            // act
            var validator = selector.Resolve<ISsinValidator>(country);

            // assert
            validator.Should().BeNull();
        }

        [Theory]
        [InlineData("Belgium")]
        [InlineData("BELGIUM")]
        public void Should_Get_Generator_For_Supported_Country(string country)
        {
            // arrange
            var services = new ServiceCollection();
            services.AddTransient<IRandomHelper, RandomHelper>();
            services.AddTransient<ISsinGenerator, BelgianSsinGenerator>();
            var serviceProvider = services.BuildServiceProvider();
            var selector = new SsinSelector(serviceProvider);

            // act
            var generator = selector.Resolve<ISsinGenerator>(country);

            // assert
            generator.Should().NotBeNull();
            generator.Should().BeOfType<BelgianSsinGenerator>();
        }

        [Theory]
        [InlineData("Spain")]
        [InlineData("France")]
        public void Should_Not_Get_Generator_For_NotSupported_Country(string country)
        {
            // arrange
            var services = new ServiceCollection();
            services.AddTransient<IRandomHelper, RandomHelper>();
            services.AddTransient<ISsinGenerator, BelgianSsinGenerator>();
            var serviceProvider = services.BuildServiceProvider();
            var selector = new SsinSelector(serviceProvider);

            // act
            var generator = selector.Resolve<ISsinGenerator>(country);

            // assert
            generator.Should().BeNull();
        }
    }
}

using System;
using System.Linq;
using System.Reflection;
using Lib.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Lib.Ssins
{
    public class SsinSelector : ISsinSelector
    {
        private readonly IServiceProvider _serviceProvider;

        public SsinSelector(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T Resolve<T>(string country) where T : class
        {
            var matchingType = FindType<T>(country);
            if (matchingType == null) return default;
            var services = _serviceProvider.GetServices<T>();
            var service = services.SingleOrDefault(x => x.GetType() == matchingType);
            return service;
        }

        private static Type FindType<T>(string country) where T : class
        {
            return AppDomain.CurrentDomain
                .GetAssemblies()
                .Where(IsLibAssembly)
                .SelectMany(x => x.GetTypes())
                .Where(x => typeof(T).IsAssignableFrom(x))
                .SingleOrDefault(x => x.GetAttributesForType(IsMatchingCountry(country)).Any());
        }

        private static bool IsLibAssembly(Assembly assembly)
        {
            return assembly?.FullName != null && assembly.FullName.StartsWith("Lib");
        }

        private static Predicate<SsinSelectorAttribute> IsMatchingCountry(string country)
        {
            return attribute => attribute.Country.IgnoreCaseEquals(country);
        }
    }
}
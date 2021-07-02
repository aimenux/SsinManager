using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Lib.Extensions
{
    public static class TypeExtensions
    {
        public static string GetAssemblyVersion(this Type type)
        {
            return type
                .Assembly
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                ?.InformationalVersion;
        }

        public static IEnumerable<T> GetAttributesForType<T>(this Type type, Predicate<T> predicate) where T : Attribute
        {
            return type
                .GetCustomAttributes(typeof(T), true)
                .OfType<T>()
                .Where(x => predicate(x));
        }
    }
}
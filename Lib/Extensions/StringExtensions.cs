using System;

namespace Lib.Extensions
{
    public static class StringExtensions
    {
        public static bool IgnoreCaseEquals(this string left, string right) => string.Equals(left, right, StringComparison.OrdinalIgnoreCase);
    }
}

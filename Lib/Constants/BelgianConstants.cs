using System;
using System.Text.RegularExpressions;

namespace Lib.Constants
{
    public static class BelgianConstants
    {
        public const int SsinLength = 11;

        public const int ControlKey = 97;

        public const string RegexPattern = @"^(\d{9})(\d{2})$";

        public static readonly Lazy<Regex> SsinRegex = new(() => new Regex(RegexPattern, RegexOptions.Compiled));
    }
}
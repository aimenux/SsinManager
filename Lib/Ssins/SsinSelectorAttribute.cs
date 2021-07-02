using System;

namespace Lib.Ssins
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public sealed class SsinSelectorAttribute : Attribute
    {
        public string Country { get; }

        public SsinSelectorAttribute(string country)
        {
            Country = country;
        }
    }
}

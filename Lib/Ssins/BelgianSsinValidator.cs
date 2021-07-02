using System.Linq;
using Lib.Constants;
using static Lib.Constants.BelgianConstants;

namespace Lib.Ssins
{
    [SsinSelector(nameof(Countries.Belgium))]
    public class BelgianSsinValidator : ISsinValidator
    {
        public bool IsValid(string ssin)
        {
            var cleanSsin = string.Concat(ssin.TakeWhile(char.IsDigit));
            if (cleanSsin.Length != SsinLength) return false;
            var match = SsinRegex.Value.Match(cleanSsin);
            if (!match.Success) return false;
            var value1 = match.Groups[1].Value;
            var value2 = match.Groups[2].Value;
            var value3 = ControlKey - int.Parse(value2);
            return long.Parse(value1) % ControlKey == value3 
                   || (long.Parse($"2{value1}")) % ControlKey == value3;
        }
    }
}
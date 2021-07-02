using System.Collections.Generic;
using System.Linq;
using Lib.Constants;
using Lib.Helpers;
using static Lib.Constants.BelgianConstants;

namespace Lib.Ssins
{
    [SsinSelector(nameof(Countries.Belgium))]
    public class BelgianSsinGenerator : ISsinGenerator
    {
        private readonly IRandomHelper _randomHelper;

        public BelgianSsinGenerator(IRandomHelper randomHelper)
        {
            _randomHelper = randomHelper;
        }

        public string GenerateSsin()
        {
            var part1 = ComputeFirstPart();
            var part2 = ComputeLastPart(part1);
            return $"{part1}{part2}";
        }

        public IEnumerable<string> GenerateSsin(int number)
        {
            return Enumerable.Range(0, number).Select(_ => GenerateSsin());
        }

        private string ComputeFirstPart()
        {
            var year = ApplyPadding(_randomHelper.RandomInteger(1, 99), 2);
            var month = ApplyPadding(_randomHelper.RandomInteger(1, 12), 2);
            var day = ApplyPadding(_randomHelper.RandomInteger(1, 30), 2);
            var sequence = ApplyPadding(_randomHelper.RandomInteger(0, 999), 3);
            return ApplyPadding($"{year}{month}{day}{sequence}", 9);
        }

        private static string ComputeLastPart(string firstPart)
        {
            var value1 = int.Parse(firstPart);
            var value2 = ControlKey - value1 % ControlKey;
            return ApplyPadding(value2, 2);
        }

        private static string ApplyPadding(int number, int width) => ApplyPadding(number.ToString(), width);

        private static string ApplyPadding(string number, int width) => number.PadLeft(width, '0');
    }
}
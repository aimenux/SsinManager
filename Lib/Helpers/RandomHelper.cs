using System;

namespace Lib.Helpers
{
    public class RandomHelper : IRandomHelper
    {
        private static readonly Random Random = new(Guid.NewGuid().GetHashCode());

        public int RandomInteger(int min, int max)
        {
            return Random.Next(min, max);
        }
    }
}
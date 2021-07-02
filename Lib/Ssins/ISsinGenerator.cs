using System.Collections.Generic;

namespace Lib.Ssins
{
    public interface ISsinGenerator
    {
        string GenerateSsin();

        IEnumerable<string> GenerateSsin(int number);
    }
}

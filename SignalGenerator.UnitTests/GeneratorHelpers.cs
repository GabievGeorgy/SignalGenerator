using System.Collections.Generic;

namespace SignalGenerator.UnitTests
{
    internal static class GeneratorHelpers
    {
        internal static double[] GetSignalSample(ISignalGenerator generator, double time)
        {
            var result = new List<double>();
            for (int i = 0; i < time; i++)
                result.Add(generator.GetSignal(i));

            return result.ToArray();
        }
    }
}
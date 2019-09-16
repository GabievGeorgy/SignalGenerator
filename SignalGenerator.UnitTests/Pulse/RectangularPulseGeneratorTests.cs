using System;
using NUnit.Framework;
using SignalGenerator.Pulse;

namespace SignalGenerator.UnitTests.Pulse
{
    [TestFixture]
    public class RectangularPulseGeneratorTests
    {
        [TestCase(1, 1, 0, 0.5, 0, 0)]
        [TestCase(1, 1, 0, 0.5, 249, 0)]
        [TestCase(1, 1, 0, 0.5, 250, 1)]
        [TestCase(1, 1, 0, 0.5, 500, 1)]
        [TestCase(1, 1, 0, 0.5, 750, 1)]
        [TestCase(1, 1, 0, 0.5, 751, 0)]
        [TestCase(1, 1, 0, 0.5, 1000, 0)]
        public void GetSignal_ChangeTime_ReturnsSignalLevel(
            double amplitude, double frequency, double phase, double dutyCycle, double time, double expectedSignalLevel)
        {
            var generator = new RectangularPulseGenerator(amplitude, frequency, phase, dutyCycle);
            
            var result = generator.GetSignal(time);
            result = Math.Round(result, 10);
            
            Assert.AreEqual(expectedSignalLevel, result);
        }
    }
}
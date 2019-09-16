using System;
using NUnit.Framework;
using SignalGenerator.Harmonic;

namespace SignalGenerator.UnitTests.Harmonic
{
    [TestFixture]
    public class SawtoothGeneratorTests
    {
        [TestCase(1, 1, 0, 0, 0)]
        [TestCase(1, 1, 0, 125, 0.25)]
        [TestCase(1, 1, 0, 250, 0.5)]
        [TestCase(1, 1, 0, 375, 0.75)]
        [TestCase(1, 1, 0, 500, -1)]
        [TestCase(1, 1, 0, 625, -0.75)]
        [TestCase(1, 1, 0, 750, -0.5)]
        [TestCase(1, 1, 0, 875, -0.25)]
        public void GetSignal_ChangeTime_ReturnsSignalLevel(
            double amplitude, double frequency, double phase, double time, double expectedSignalLevel)
        {
            var sineGenerator = new SawtoothGenerator(amplitude, frequency, phase);
            
            var result = sineGenerator.GetSignal(time);
            result = Math.Round(result, 10);
            
            Assert.AreEqual(expectedSignalLevel, result);
        }
    }
}
using System;
using NUnit.Framework;
using SignalGenerator.Harmonic;

namespace SignalGenerator.UnitTests.Harmonic
{
    [TestFixture]
    public class TriangleGeneratorTests
    {
        [TestCase(1, 1, 0, 0, 0)]
        [TestCase(1, 1, 0, 125, 0.5)]
        [TestCase(1, 1, 0, 250, 1)]
        [TestCase(1, 1, 0, 375, 0.5)]
        [TestCase(1, 1, 0, 500, 0)]
        [TestCase(1, 1, 0, 625, -0.5)]
        [TestCase(1, 1, 0, 750, -1)]
        [TestCase(1, 1, 0, 875, -0.5)]
        public void GetSignal_ChangeTime_ReturnsSignalLevel(
            double amplitude, double frequency, double phase, double time, double expectedSignalLevel)
        {
            var sineGenerator = new TriangleGenerator(amplitude, frequency, phase);
            
            var result = sineGenerator.GetSignal(time);
            result = Math.Round(result, 10);
            
            Assert.AreEqual(expectedSignalLevel, result);
        }
    }
}
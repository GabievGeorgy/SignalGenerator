using System.Collections.Generic;
using NUnit.Framework;
using SignalGenerator.Noise;

namespace SignalGenerator.UnitTests.Noise
{
    [TestFixture]
    public class BinaryNoiseGeneratorTests
    {
        [Test]
        public void GetSignal_NoiseOnlyConsistOfZerosAndOnes_ReturnsTrue()
        {
            var binaryNoiseGenerator = new BinaryNoiseGenerator();
            var observationTime = 1000;
            var noiseSample = GeneratorHelpers.GetSignalSample(binaryNoiseGenerator, observationTime);
            
            var result = true;
            foreach (var value in noiseSample)
                if (value != 0 && value != 1)
                    result = false;
            
            Assert.True(result);
        }
    }
}
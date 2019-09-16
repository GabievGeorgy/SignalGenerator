using System;
using System.Linq;
using NUnit.Framework;
using SignalGenerator.Pulse;

namespace SignalGenerator.UnitTests.Pulse
{
    [TestFixture]
    public class PulseGeneratorTests
    {
        [Test]
        public void GetSignal_ChangeDutyCycle_ChangedDutyCycle()
        {
            var generator = MakeGenerator();
            var observationTime = 1000;
            var dutyCycleModificator = 0.5d;
            var signal = GeneratorHelpers.GetSignalSample(generator, observationTime);
            generator.DutyCycle *= dutyCycleModificator;
            var changedSignal = GeneratorHelpers.GetSignalSample(generator, observationTime);

            var maxCountOfSignal = signal.Count(x => x == signal.Max()) - 1;
            var maxCountOfChangedSignal = changedSignal.Count(x => x == changedSignal.Max()) - 1;

            Assert.AreEqual(maxCountOfSignal, maxCountOfChangedSignal / dutyCycleModificator);
        }

        private static PulseGenerator MakeGenerator()
        {
            return new RectangularPulseGenerator(1, 1 , 0, 0.5);
        }
    }
}
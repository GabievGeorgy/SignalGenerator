using System;
using System.Linq;
using NUnit.Framework;
using SignalGenerator.Harmonic;

namespace SignalGenerator.UnitTests
{
    [TestFixture]
    public class HarmonicGeneratorTests
    {
        [Test]
        public void GetSignal_ChangeAmplitude_ChangesAmplitude()
        {
            PeriodicGenerator generator = MakeGenerator();
            var observationTime = 1000;
            var amplitudeModificator = 5;
            var signal = GeneratorHelpers.GetSignalSample(generator, observationTime);
            generator.Amplitude *= amplitudeModificator;
            var changedSignal = GeneratorHelpers.GetSignalSample(generator, observationTime);

            var amplitudeBeforeChange = Math.Abs(signal.Min() - signal.Max());
            var amplitudeAfterChange = Math.Abs(changedSignal.Min() - changedSignal.Max());

            Assert.AreEqual(amplitudeBeforeChange, amplitudeAfterChange / amplitudeModificator);
        }

        [Test]
        public void GetSignal_ChangeFrequency_ChangesFrequency()
        {
            PeriodicGenerator generator = MakeGenerator();
            var observationTime = 1000;
            var frequencyModificator = 5;
            var signal = GeneratorHelpers.GetSignalSample(generator, observationTime);
            generator.Frequency *= frequencyModificator;
            var changedSignal = GeneratorHelpers.GetSignalSample(generator, observationTime);

            var extremaOfDefaultSignal = signal.Where(x => Math.Abs(x - signal.Max()) < 0.0000000001);
            var extremaOfChangedSignal = changedSignal.Where(x => Math.Abs(x - changedSignal.Max()) < 0.0000000001);
            var result = extremaOfDefaultSignal.Count() * frequencyModificator == extremaOfChangedSignal.Count();

            Assert.True(result);
        }

        [Test]
        public void GetSignal_ChangePhase_ChangesPhase()
        {
            PeriodicGenerator generator = MakeGenerator();
            var observationTime = 1000;
            var phaseModificator = 180d / 360d;
            var signal = GeneratorHelpers.GetSignalSample(generator, observationTime);
            generator.Phase += phaseModificator;
            var changedSignal = GeneratorHelpers.GetSignalSample(generator, observationTime);
            
            var result = true;
            for (int i = 0; i < observationTime / 2; i++)
            {
                if (Math.Abs(signal[i] - changedSignal[i + observationTime / 2]) > 0.0000000001)
                    result = false;
                if (Math.Abs(signal[i + observationTime / 2] - changedSignal[i]) > 0.0000000001)
                    result = false;
            }
            
            Assert.True(result);
        }

        private static PeriodicGenerator MakeGenerator()
        {
            return new SineGenerator(1, 1, 0);
        }
    }
}
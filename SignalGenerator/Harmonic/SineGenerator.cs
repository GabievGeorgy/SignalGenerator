using System;

namespace SignalGenerator.Harmonic
{
    public class SineGenerator : PeriodicGenerator
    {
        public SineGenerator(double amplitude, double frequency, double phase) 
            : base(amplitude, frequency, phase) { }

        protected override double GetSignalLevel(double time)
        {
            return Math.Sin(2d * Math.PI * time);
        }
    }
}

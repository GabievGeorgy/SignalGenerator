using System;

namespace SignalGenerator.Harmonic
{
    public class SawtoothGenerator : PeriodicGenerator
    {
        public SawtoothGenerator(double amplitude, double frequency, double phase) 
            : base(amplitude, frequency, phase) { }

        protected override double GetSignalLevel(double time)
        {
            return 2 * (time - Math.Truncate(time + 0.5));
        }
    }
}

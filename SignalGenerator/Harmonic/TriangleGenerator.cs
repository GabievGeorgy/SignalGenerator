 using System;

 namespace SignalGenerator.Harmonic
{
    public class TriangleGenerator : PeriodicGenerator
    {
        public TriangleGenerator(double amplitude, double frequency, double phase) 
            : base(amplitude, frequency, phase) { }

        protected override double GetSignalLevel(double time)
        {
            return 1d - 4d * Math.Abs(Math.Round(time - 0.25d) - (time - 0.25d));
        }
    }
}
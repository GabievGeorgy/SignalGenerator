using System;

namespace SignalGenerator.Pulse
{
    public class RectangularPulseGenerator : PulseGenerator
    {
        protected override double GetSignalLevel(double time)
        {
            return 2 *  Math.Abs(Math.Ceiling(time - 0.5d) - time) < 1 - DutyCycle ? 0 : 1;
        }

        public RectangularPulseGenerator(double amplitude, double frequency, double phase, double dutyCycle) 
            : base(amplitude, frequency, phase, dutyCycle) { }
    }
}
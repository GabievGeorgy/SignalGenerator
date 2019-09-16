namespace SignalGenerator.Pulse
{
    public abstract class PulseGenerator : PeriodicGenerator
    {
        /// <summary>
        /// A duty cycle is the fraction of one period in which a signal or system is active.
        /// </summary>
        public double DutyCycle { get; set; }

        protected PulseGenerator(double amplitude, double frequency, double phase, double dutyCycle)
            : base(amplitude, frequency, phase)
        {
            DutyCycle = dutyCycle;
        }
    }
}
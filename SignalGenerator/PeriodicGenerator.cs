namespace SignalGenerator
{
    public abstract class PeriodicGenerator : ISignalGenerator
    {
        public double Amplitude { get; set; }
        public double Frequency { get; set; }
        public double Phase { get; set; }

        protected PeriodicGenerator(double amplitude, double frequency, double phase)
        {
            Amplitude = amplitude;
            Frequency = frequency;
            Phase = phase;
        }

        public double GetSignal(double millisecond)
        {
            millisecond /= 1000;
            var time = millisecond * Frequency + Phase;
            return Amplitude * GetSignalLevel(time);
        }

        protected abstract double GetSignalLevel(double time);
    }
}
using System;

namespace SignalGenerator.Noise
{
    public class BinaryNoiseGenerator : ISignalGenerator
    {
        private readonly Random _random = new Random();
        
        public double GetSignal(double millisecond)
        {
            return _random.Next(2);
        }
    }
}
using System;

namespace ActuarialIntelligence.Domain
{
    public static class Threshold
    {
        private static decimal accuracyThreshold = 0.000000001m;
        public static bool Equals(decimal currentValue, decimal previousValue)
        {
            bool result = Math.Abs(currentValue - previousValue) < accuracyThreshold ? false : true;
            return result;
        }
    }
}

using System;
namespace ActuarialIntelligence.Domain
{
    public class Interpolation
    {
        private decimal i1, i2 = 0;
        private decimal f = 0;
        private decimal previousValue = 0;

        public decimal Interpolate(Func<decimal, decimal> functional,
            decimal testValue1, decimal testValue2, decimal interpolationValue)
        {
            decimal tempI = 0;
            i1 = testValue1;
            i2 = testValue2;
            f = interpolationValue;
            bool _continue = true;

            while (_continue)
            {
                tempI = i2;
                previousValue = i2;
                if (functional(i1) == functional(i2)) { break; }
                i2 = nextValue(functional(i1), functional(i2), i1, i2, out _continue);
                i1 = tempI;
                Console.WriteLine(i2);
            }
            return i2;

        }

        private decimal nextValue(decimal f1, decimal f2,
            decimal i1, decimal i2, out bool _continue)
        {
            _continue = Threshold.Equals((i1 + (i2 - i1) * ((f - f1) / (f2 - f1))), previousValue);
            return (i1 + (i2 - i1) * ((f - f1) / (f2 - f1)));
        }

    }

}

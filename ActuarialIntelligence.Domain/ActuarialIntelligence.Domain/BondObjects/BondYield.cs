namespace ActuarialIntelligence.Domain.BondObjects
{
    public class BondYield
    {
        public BondDetails bondDetails { get; private set; }
        public decimal value { get { return GetValue(); } }

        private decimal cacheValue;

        public BondYield(BondDetails bondDetails)
        {
            this.bondDetails = bondDetails;
        }

        public decimal GetValue()
        {
            if (cacheValue == 0)
            {
                var bond = new BondHalfYearly(bondDetails.nominal, bondDetails.redemptionRate, bondDetails.yearlyCouponRate, bondDetails.term);
                var interpolation = new Interpolation();
                cacheValue = interpolation.Interpolate(bond.value, 0.01m, 0.09m, bondDetails.nominal * bondDetails.redemptionRate);
            }
            return cacheValue;
        }
    }
}

using ActuarialIntelligence.Domain.Enums;

namespace ActuarialIntelligence.Domain
{
    public class ZSpread
    {
        private ListTermCashflowSet cashFlowSet;
        int days;
        private decimal nominal;
        private decimal spread;

        public decimal Spread()
        {
            return spread == 0 ? CalculateZspread() : spread;
        }

        public ZSpread(ListTermCashflowSet cashFlowSet, decimal nominal)
        {
            this.cashFlowSet = cashFlowSet;
            this.nominal = nominal;
            days = cashFlowSet.termType == Term.YearlyEffective ? 365 :
                cashFlowSet.termType == Term.MonthlyEffective ? 30 : 0;
        }

        public decimal CalculateZspread()
        {
            var interpolator = new Interpolation();
            ZSpreadSpecificAnnuity annuity = new ZSpreadSpecificAnnuity(cashFlowSet, days);
            var result = interpolator.Interpolate(annuity.GetPV, 0.01m, 0.09m, nominal);
            spread = result;
            return result;
        }

    }
}

using ActuarialIntelligence.Domain.Enums;

namespace ActuarialIntelligence.Domain
{
    public class SpotYield
    {
        public Term Term { get; private set; }
        public decimal Yield { get; private set; }
        public SpotYield(decimal yield, Term term)
        {
            Yield = yield;
            Term = term;
        }
    }
}

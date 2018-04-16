using ActuarialIntelligence.Domain.BondObjects;
using NUnit.Framework;
using System;

namespace ActuarialIntelligence.Domain.Tests
{
    [TestFixture]
    [Category("Math")]
    class InterpolatorTests
    {
        private BondDetails details;
        private BondYield stripper;
        private Interpolation interpolator;
        [SetUp]
        public void BeforeEachTest()
        {
            details = new BondDetails(240000, 0.09m, 1, 15.5m, 0.02m);
            stripper = new BondYield(details);
            interpolator = new Interpolation();
        }

        [Test]
        public void InterpolatorTest()
        {
            BondHalfYearly bond = new BondHalfYearly(240000, 1, 0.09m, 15.5m);
            var yield = interpolator.Interpolate(bond.value, 0.01m, 0.09m, 240000m);
            Assert.IsTrue(isEqualWithinThreshold(240000m, bond.value(yield)));
        }

        private bool isEqualWithinThreshold(decimal expected, decimal actual)
        {
            if (Math.Abs(expected - actual) <= 0.0000000001m)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

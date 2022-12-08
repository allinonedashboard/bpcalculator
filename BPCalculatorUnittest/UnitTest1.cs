using System;
using BPCalculator;
using Xunit;

namespace BPCalculatorUnittest
{
    public class UnitTest1
    {
        public BloodPressure BP;
        //Unit test to check LOW bp
        [Theory]
        [InlineData(70, 40)] //low range
        [InlineData(78, 47)] //mid range
        [InlineData(89, 59)] //high range
        public void TestMethodLowVariables(int s, int d)
        {
            BP = new BloodPressure() { Systolic = s, Diastolic = d };
            Assert.Equal(BPCategory.Low, BP.Category);
        }
        //Unit test to check IDEAL bp
        [Theory]
        [InlineData(90, 60)] //low range
        [InlineData(105, 62)] //mid range
        [InlineData(119, 79)] //high range
        public void TestMethodIdealVariables(int s, int d)
        {
            BP = new BloodPressure() { Systolic = s, Diastolic = d };
            Assert.Equal(BPCategory.Ideal, BP.Category);
        }
        //Unit test to check PreHigh bp
        [Theory]
        [InlineData(121, 81)] //low range
        [InlineData(131, 85)] //mid range
        [InlineData(139, 89)] //high range
        public void TestMethodPreHighVariables(int s, int d)
        {
            BP = new BloodPressure() { Systolic = s, Diastolic = d };
            Assert.Equal(BPCategory.PreHigh, BP.Category);
        }
        //Unit test to check High bp
        [Theory]
        [InlineData(141, 91)] //low range
        [InlineData(160, 95)] //mid range
        [InlineData(190, 79)] //high range
        public void TestMethodHighVariables(int s, int d)
        {
            BP = new BloodPressure() { Systolic = s, Diastolic = d };
            Assert.Equal(BPCategory.High, BP.Category);
        }
    }
}

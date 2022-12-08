using System;
using BPCalculator;
using Xunit;

namespace BPCalculatorUnittest
{
    public class UnitTest1
    {
        public BloodPressure BP;
        //Unit test to check InValid blood pressure
        [Theory]
        [InlineData(195, 39)] //low range
        [InlineData(200, 23)] //mid range
        [InlineData(191, 101)] //high range
        public void TestMethodInvalidVariables(int s, int d)
        {
            BP = new BloodPressure() { Systolic = s, Diastolic = d };
            Assert.Equal(BPCategory.None, BP.Category);
        }

        //Unit test to check LOW bp
        [Theory]
        [InlineData(60, 30)] //low range
        [InlineData(92, 47)] //mid range
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
        //Unit test to check Elevated bp
        [Theory]
        [InlineData(90, 60)] //low range
        [InlineData(105, 62)] //mid range
        [InlineData(119, 79)] //high range
        public void TestMethodPreHighVariables(int s, int d)
        {
            BP = new BloodPressure() { Systolic = s, Diastolic = d };
            Assert.Equal(BPCategory.PreHigh, BP.Category);
        }
        //Unit test to check High2 bp
        [Theory]
        [InlineData(90, 60)] //low range
        [InlineData(105, 62)] //mid range
        [InlineData(119, 79)] //high range
        public void TestMethodHighVariables(int s, int d)
        {
            BP = new BloodPressure() { Systolic = s, Diastolic = d };
            Assert.Equal(BPCategory.High, BP.Category);
        }
    }
}

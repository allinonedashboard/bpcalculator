using BPCalculator;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SpecFlowAcceptanceTests.Features
{
    [Binding]
    public class CheckBloodPressureValuesSteps
    {
        private BloodPressure? bloodPressure;

        [Given(@"user enters (.*) in Systolic")]
        public void GivenUserEntersInSystolic(int sys)
        {
            bloodPressure = new BloodPressure
            {
                Systolic = sys
            };
        }

        [Given(@"user enters (.*) in Diastolic")]
        public void GivenUserEntersInDiastolic(int dys)
        {
            bloodPressure = new BloodPressure
            {
                Diastolic = dys
            };
        }



        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(string result)
        {
            Assert.AreEqual(bloodPressure.Category.ToString(), result);
        }
    }
}
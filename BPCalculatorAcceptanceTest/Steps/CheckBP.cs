using TechTalk.SpecFlow;
using BPCalculator;

namespace BPCalculatorAcceptTest.StepDef
{
    [Binding]
    public sealed class CalculateBP
    {
        private readonly BloodPressure bloodPressure = new();

        private string? my_result;

        [Given("Systolic number is (.*)")]
        public void GiveSystolicNumberIs(int number)
        {
            bloodPressure.Systolic = number;
        }
        [Given("Diastolic number is (.*)")]
        public void GiveDiastolicNumberIs(int number)
        {
            bloodPressure.Diastolic = number;
        }

        [When("blood pressure is calculated")]
        public void WhenBloodPressureIsCalculated()
        {
            my_result = bloodPressure.Category.ToString();
        }

        [Then("result should be (.*)")]
        public void ThenResultShouldBe(string result)
        {
            my_result.Should().Be(result);
        }
    }
}
using System;
	using TechTalk.SpecFlow;
	
	namespace MyNamespace
	{
		[Binding]
		public class StepDefinitions
		{
			private readonly ScenarioContext _scenarioContext;
	
			public StepDefinitions(ScenarioContext scenarioContext)
			{
				_scenarioContext = scenarioContext;
			}
			
[Given(@"Systolic number is (.*)")]
public void GivenSystolicnumberis(int args1)
{
	_scenarioContext.Pending();
}

[Given(@"Diastolic number is (.*)")]
public void GivenDiastolicnumberis(int args1)
{
	_scenarioContext.Pending();
}

[When(@"blood pressure is calculated")]
public void Whenbloodpressureiscalculated()
{
	_scenarioContext.Pending();
}

[Then(@"result should be Low BP")]
public void ThenresultshouldbeLowBP()
{
	_scenarioContext.Pending();
}

		}
	}
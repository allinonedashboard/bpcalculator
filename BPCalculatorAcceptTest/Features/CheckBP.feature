Feature: BloodPressure
	
Scenario: Calculate Low BP
	Given Systolic number is 70
	And Diastolic number is 40
	When blood pressure is calculated
	Then result should be Low BP



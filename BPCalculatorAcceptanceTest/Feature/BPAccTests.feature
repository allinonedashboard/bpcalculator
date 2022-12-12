Feature: Check Blood Pressure Values

@mytag
Scenario Outline: Check value for calculations
	Given user enters <Systolic> in Systolic 
	And user enters <Diastolic> in Diastolic
	Then the result should be <Result>

	Examples: 
    | Systolic	| Diastolic |	Result		|
    |    78		|   47		|   Low bp		|
    |    105	|	62		|	Ideal bp	|
	|	 131	|	85		|	PreHigh bp	| 
	|    160	|   95		|   High bp 	|
	|    195	|   101		|   NotValid bp	|
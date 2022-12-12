Feature: CheckBP

Scenario: Check Low BP
   Given Systolic number is 70
   And Diastolic number is 40
   When blood pressure is calculated
   Then result should be Low BP

Scenario: Check Ideal BP
    Given Systolic number is 90
    And Diastolic number is 60
    When blood pressure is calculated
    Then result should be Ideal BP 

Scenario: Cheeck PreHigh BP
    Given Systolic number is 121
    And Diastolic number is 81
    When blood pressure is calculated
    Then result should be PreHigh BP 

Scenario: Check High BP
    Given Systolic number is 141
    And Diastolic number is 91
    When blood pressure is calculated
    Then result should be High BP 
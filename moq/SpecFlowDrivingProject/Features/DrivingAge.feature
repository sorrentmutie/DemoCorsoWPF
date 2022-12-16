Feature: DrivingAge

Check if a person is allowed to drive a car in a given countryA short summary of the feature

Background: 
  Given the driver is 21 years old

Scenario: Permitted Driving In Italy
	When they live in Italy
	Then they are permitted to drive


Scenario: Permitted Driving In France
	When they live in France
	Then they are permitted to drive


#Scenario: Permitted Driving In different countries
#	Given the driver is <age> years old
#	When they live in <country>
#	Then they are permitted to drive
#	Examples: 
#	| age | country |
#	| 18  | Italy |
#	| 21  | France |
#   | 19  | USA |
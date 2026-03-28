Feature: OwnerSearch

A short summary of the feature

@FindOwnersPage
Scenario Outline: Validate owner search functionality with various inputs
	
	When I enter "<Value>" into the search form "<Field>" field
	And I click the "Find Owner" button
	Then I should see a warning message for the owner search "<Field>" field
Examples:
	| Field     | Value    |
	| Last Name |          |
	| Last Name | B        |
	| Last Name | Франклин |
	| Last Name | Fra      |
	| Last Name | George   |
	| Last Name | george   |
	| Last Name | *        |
	| Last Name |       00 |
Feature: VisitRegistration

As a system user, I want to add visits for pets so that the system can log visits and assign veterinarians.
@DefaultOwnerInformationPageUrl
Scenario: Successful appointment booking for a pet visit
	When I click the "Add Visit" link next to the pet's name
	And The visit page displays correct pet information
	And I fill in valid visit details
	And I click the "Add Visit" button
	Then I should be redirected to the Owner Information page.
	And I should see the visit description in the pet's visits table

@NegativeVisitRegistration
@DefaultOwnerInformationPageUrl
Scenario Outline: Verify visit field validation rules
	When I click the "Add Visit" link next to the pet's name
	And I enter "<Value>" into the visit "<Field>" field
	And I click the "Add Visit" button
	Then I should see a warning message for the visit "<Field>" field

Examples:
	| Field       | Value      | Reason                         |
	| Date        |            | Mandatory field can't be empty |
	| Date        | 2020/01/01 | Date can't be in the past      |
	| Description |            | Mandatory field can't be empty |
	| Description | Тест1      | English characters only        |
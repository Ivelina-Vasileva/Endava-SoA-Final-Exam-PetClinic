Feature: OwnerRegistration

As a system user, I want to register an owner so that the system can maintain a record of clinic clients.

@FindOwnersPage
Scenario: Successfully register a new owner with valid data
	When I click the "Add Owner" Link.
	And I fill in the owner valid data.
	And I click the "Add Owner Submit" button on the form.
	Then I should be redirected to the Owner Information page.
	And I should see the details of the newly created owner.

@NegativeOwnerRegistration
@FindOwnersPage
Scenario Outline: Verify field validation rules
	When I click the "Add Owner" Link.
	And I enter "<Value>" into the "<Field>" owner form field
	And I click the "Add Owner Submit" button
	Then I should see a warning message for the owner "<Field>" field

Examples:
	| Field      | Value       | Reason                                        |
	| First Name |             | Mandatory field can't be empty                |
	| First Name | A           | Below minimum length (2 characters)           |
	| First Name | John123     | English alphabet only (No numbers)            |
	| First Name | Иван        | English alphabet only (No Cyrillic)           |
	| Last Name  |             | Mandatory field can't be empty                |
	| Last Name  | B           | Below minimum length (2 characters)           |
	| Last Name  | Smith!      | English alphabet only (No special characters) |
	| Last Name  | Иванов      | English alphabet only (No Cyrillic)           |
	| City       |             | Mandatory field can't be empty                |
	| City       | C           | Below minimum length (2 characters)           |
	| City       | New York 1  | English alphabet only (No numbers)            |
	| City       | София       | English alphabet only (No Cyrillic)           |
	| Address    |             | Mandatory field can't be empty                |
	| Address    | София       | English alphabet only (No Cyrillic)           |
	| Telephone  |             | Mandatory field can't be empty                |
	| Telephone  | 12345678901 | Maximum 10 digits allowed                     |
	| Telephone  | 123-456-789 | Digits only (No hyphens/special characters)   |
	| Telephone  | 00000000000 | Length violation (11 digits)                  |
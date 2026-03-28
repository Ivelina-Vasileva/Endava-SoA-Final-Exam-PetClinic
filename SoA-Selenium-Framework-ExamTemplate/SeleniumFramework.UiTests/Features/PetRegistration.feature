Feature: PetRegistration

As a system user, I want to add pets to owners so the system can associate each pet with its respective owner.

@FindOwnersPage @CleanupPet
Scenario: Successfully adding a new pet to an existing owner
	When I click the "Find Owner" button
	And I select an owner from the list
	And I click the "Add New Pet" button
	And I fill in valid pet details
	And I click the "Add Pet" button
	Then I should be redirected to the Owner Information page.
	And I should see the details of the newly created pet in the profile table

@NegativePetRegistration
@FindOwnersPage
Scenario Outline: Verify pet field validation rules
	When I click the "Find Owner" button
	And I select an owner from the list
	And I click the "Add New Pet" button
	And I enter "<Value>" into the pet "<Field>" field
	And I click the "Add Pet" button
	Then I should see a warning message for the pet "<Field>" field

Examples:
	| Field      | Value      | Reason                                        |
	| Name       |            | Mandatory field can't be empty                |
	| Name       | Иван       | English alphabet only (No Cyrillic)           |
	| Name       | Ivan!      | English alphabet only (No special characters) |
	| Birth Date | 2099-01-01 | Date can't be in the future                   |
	| Birth Date |            | Mandatory field can't be empty                |
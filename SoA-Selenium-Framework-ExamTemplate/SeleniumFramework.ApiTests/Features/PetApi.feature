Feature: PetApi

Create a pet for an existing owner and verify persistence.

@API @DeletePet
Scenario: Pet API Creation
    Given I make a post request to pets endpoint with the following data:
        | name  | birthDate  | typeName | typeId | ownerId |
        | Leo1  | 2010-09-07 | cat      | 1      | 1       |
    Then the response status code should be 201
    And created pet response should contain the following data:
        | name  | birthDate  | typeName | typeId | ownerId |
        | Leo1  | 2010-09-07 | cat      | 1      | 1       |



Feature: OwnerApi

Validate the list of owners is returned correctly.

  @Api
  Scenario: Validate the list of owners is returned correctly via GET
    When I send a GET request to the owners API
    Then the response status code should be 200
	And the response should contain a list of owners

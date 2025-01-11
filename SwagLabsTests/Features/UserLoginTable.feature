Feature: UserLoginTable

@negative @emptyCredentials
Scenario: Test login form with empty credentials
	Given User navigates to the Login Page
	When User types any Username and Password:
          | UserName      | Password      |
          | <UserName>    | <Password>    |
	And User clears the inputs
	And User clicks the login button
    Then User should see an error message "<ErrorMessage>"

    Examples:
      | UserName      | Password      | ErrorMessage            |
      | someUser      | password      | Username is required    |

@negative @emptyPassword
Scenario: Test login form with credentials by passing Username
	Given User navigates to the Login Page
	When User types any Username
          | UserName      |
          | <UserName>    |
	And  User enters the Password
          | Password      |
          | <Password>    |
	And User clears the password input
	And User clicks the login button
    Then User should see an error message "<ErrorMessage>"

    Examples:
      | UserName      | Password     | ErrorMessage            |
      | someUser      | somePass     | Password is required    |

@positive
Scenario: Test login form with valid credentials
	Given User navigates to the Login Page
	When User types a valid Username and Password
      | UserName      | Password      |
      | <UserName>    | <Password>    |
	And User clicks the login button
	Then User should be navigated to the main page
        Examples:
      | UserName      | Password     |
      | standard_user | secret_sauce |

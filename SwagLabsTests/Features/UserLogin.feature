Feature: UserLogin

@negative @emptyCredentials
Scenario: [Test login form with empty credentials]
	Given [User navigates to the Login Page]
	When [User types any Username and Password]
	And [User clears the inputs]
	And [User clicks the login button]
	Then [User should see an error message "Username is required"]

@negative @emptyPassword
Scenario: [Test login form with credentials by passing Username]
	Given [User navigates to the Login Page]
	When [User types any Username]
	And  [User enters the Password]
	And [User clears the password input]
	And [User clicks the login button]
	Then [User should see an error message "Password is required"]

@positive
Scenario: [Test login form with valid credentials]
	Given [User navigates to the Login Page]
	When [User types a valid Username and Password]
	And [User clicks the login button]
	Then [User should be navigated to the main page]
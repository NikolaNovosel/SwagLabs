using OpenQA.Selenium;
using Serilog;
using SwagLabsPages.Models;
using SwagLabsPages.Pages;
using TechTalk.SpecFlow.Assist;

namespace SwagLabsTests.StepDefinitions
{
    [Binding]
    public class UserLoginTableStepDefinitions
    {
        private readonly IWebDriver _driver;
        private readonly LoginPage _loginPage;
        public UserLoginTableStepDefinitions(IWebDriver driver)
        {
            _driver = driver;
            _loginPage = new LoginPage(driver);
        }
        [Given(@"User navigates to the Login Page")]
        public void GivenUserNavigatesToTheLoginPage()
        {
            Log.Information("Navigating to the login page.");
            _loginPage.OpenPage();
        }

        [When(@"User types any Username and Password:")]
        public void WhenUserTypesAnyUsernameAndPassword(Table table)
        {
            Log.Information("Typing any username and password.");
            var user = table.CreateInstance<User>();
            _loginPage.TypeAnyCredentials(user.UserName, user.Password);
        }

        [When(@"User clears the inputs")]
        public void WhenUserClearsTheInputs()
        {
            Log.Information("Clear the input fields");
            _loginPage.ClearInputs();
        }

        [When(@"User clicks the login button")]
        public void WhenUserClicksTheLoginButton()
        {
            Log.Information("Click the login button");
            _loginPage.ClickLoginButton();
        }

        [Then(@"User should see an error message ""([^""]*)""")]
        public void ThenUserShouldSeeAnErrorMessage(string errorMessage)
        {
            Log.Information("Checking for an error message.");
            _loginPage.ErrorMessage.Text.Should().Contain(errorMessage);
        }

        [When(@"User types any Username")]
        public void WhenUserTypesAnyUsername(Table table)
        {
            Log.Information("Typing any username.");
            var user = table.CreateInstance<User>();
            _loginPage.TypeUserName(user.UserName);
        }

        [When(@"User enters the Password")]
        public void WhenUserEntersThePassword(Table table)
        {
            Log.Information("Entering the password.");
            var user = table.CreateInstance<User>();
            _loginPage.EnterPassword(user.Password);
        }

        [When(@"User clears the password input")]
        public void WhenUserClearsThePasswordInput()
        {
            Log.Information("Clear the password field");
            _loginPage.ClearPassword();
        }

        [When(@"User types a valid Username and Password")]
        public void WhenUserTypesAValidUsernameAndPassword(Table table)
        {
            Log.Information("Typing valid username and password.");
            var user = table.CreateInstance<User>();
            _loginPage.TypeValidCredentials(user.UserName, user.Password);
        }

        [Then(@"User should be navigated to the main page")]
        public void ThenUserShouldBeNavigatedToTheMainPage()
        {
            Log.Information("Checking for login error message.");
            _loginPage.ReturnMainPageTitleText().Should().Be(_driver.Title);
        }
    }
}

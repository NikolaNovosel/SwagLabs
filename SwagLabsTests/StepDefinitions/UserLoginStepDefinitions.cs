using OpenQA.Selenium;
using Serilog;
using SwagLabsPages.Models;
using SwagLabsPages.Pages;
using SwagLabsPages.Services;

namespace TestLoginTests.StepDefinitions
{
    [Binding]
    public class UserLoginStepDefinitions
    {
        private readonly IWebDriver _driver;
        private readonly LoginPage _loginPage;

        public UserLoginStepDefinitions(IWebDriver driver)
        {
            _driver = driver;
            _loginPage = new LoginPage(driver);
        }

        [Given(@"\[User navigates to the Login Page]")]
        public void GivenUserNavigatesToTheLoginPage()
        {
            Log.Information("Navigating to the login page.");
            _loginPage.OpenPage();
        }

        [When(@"\[User types any Username and Password]")]
        public void WhenUserTypesAnyUsernameAndPassword()
        {
            Log.Information("Typing any username and password.");
            User user = UserCreator.WithFakeCredentials();
            _loginPage.TypeAnyCredentials(user.GetUserName,user.GetPassword);
        }

        [When(@"\[User clears the inputs]")]
        public void WhenUserClearsTheInputs()
        {
            Log.Information("Clear the input fields");
            _loginPage.ClearInputs();
        }

        [When(@"\[User clicks the login button]")]
        public void WhenUserClicksTheLoginButton()
        {
            Log.Information("Click the login button");
            _loginPage.ClickLoginButton();
        }

        [Then(@"\[User should see an error message ""([^""]*)""]")]
        public void ThenUserShouldSeeAnErrorMessage(string p0)
        {
            Log.Information("Checking for an error message.");
            _loginPage.ErrorMessage.Text.Should().Contain(p0);
        }

        [When(@"\[User types any Username]")]
        public void WhenUserTypesAnyUsername()
        {
            Log.Information("Typing any username.");
            User user = UserCreator.WithFakeCredentials();
            _loginPage.TypeUserName(user.GetUserName);
        }

        [When(@"\[User enters the Password]")]
        public void WhenUserEntersThePassword()
        {
            Log.Information("Entering the password.");
            User user = UserCreator.WithFakeCredentials();
            _loginPage.EnterPassword(user.GetPassword);
        }

        [When(@"\[User clears the password input]")]
        public void WhenUserClearsThePasswordInput()
        {
            Log.Information("Clear the password field");
            _loginPage.ClearPassword();
        }

        [When(@"\[User types a valid Username and Password]")]
        public void WhenUserTypesAValidUsernameAndPassword()
        {
            Log.Information("Typing valid username and password.");
            User user = UserCreator.WithValidCredentials();
            _loginPage.TypeValidCredentials(user.GetUserName,user.GetPassword);
        }

        [Then(@"\[User should be navigated to the main page]")]
        public void ThenUserShouldBeNavigatedToTheMainPage()
        {
            Log.Information("Checking for login error message.");
            _loginPage.ReturnMainPageTitleText().Should().Be(_driver.Title);
        }
    }
}

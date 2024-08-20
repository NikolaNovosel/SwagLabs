using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace SwagLabsPages.Pages
{
    public class LoginPage : AbstractPage
    {
        private readonly string _page = "https://www.saucedemo.com/";
        public LoginPage(IWebDriver driver) : base(driver) { }
        public override LoginPage OpenPage()
        {
            driver.Navigate().GoToUrl(_page);
            return this;
        }
        public IWebElement InputUserName => driver.FindElement(By.Id("user-name"));
        public IWebElement InputPassword => driver.FindElement(By.Id("password"));
        public IWebElement LoginButton => driver.FindElement(By.Id("login-button"));
        public IWebElement ErrorMessage => driver.FindElement(By.TagName("h3"));
        public IWebElement MainPageTitle => driver.FindElement(By.XPath("//div[@class = 'app_logo']"));
        public void TypeAnyCredentials(string username, string password)
        {
            driver.ExecuteJavaScript($"arguments[0].value = '{username}'", InputUserName);
            driver.ExecuteJavaScript($"arguments[0].value = '{password}'", InputPassword);
        }
        public void TypeUserName(string username) => InputUserName.SendKeys(username);
        public void EnterPassword(string password) => driver.ExecuteJavaScript($"arguments[0].value = '{password}'", InputPassword);
        public void TypeValidCredentials(string username, string password)
        {
            InputUserName.SendKeys(username);
            InputPassword.SendKeys(password);
        }
        public void ClearInputs()
        {
            InputUserName.Clear();
            InputPassword.Clear();
        }
        public void ClearPassword() => InputPassword.Clear();
        public void ClickLoginButton() => LoginButton.Click();
        public string ReturnErrorMessageText() => ErrorMessage.Text;
        public string ReturnMainPageTitleText() => MainPageTitle.Text;
    }
}

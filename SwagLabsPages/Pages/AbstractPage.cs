using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SwagLabsPages.Pages
{
    public abstract class AbstractPage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        public abstract AbstractPage OpenPage();

        protected AbstractPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }
    }
}

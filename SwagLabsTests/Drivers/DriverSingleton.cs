using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SwagLabsTests.Drivers
{
    internal class DriverSingleton
    {
        private static IWebDriver? _driver;

        private DriverSingleton() { }

        internal static IWebDriver GetDriver(string browser = "chrome")
        {
            switch (browser.ToLower())
            {
                case "chrome":
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    _driver = new ChromeDriver();
                    break;
                case "firefox":
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    _driver = new FirefoxDriver();
                    break;
                case "edge":
                    new DriverManager().SetUpDriver(new EdgeConfig());
                    _driver = new EdgeDriver();
                    break;
                default:
                    throw new ArgumentException($"Browser '{browser}' is not supported.");
            }
            _driver.Manage().Window.Maximize();

            return _driver;
        }

        internal static void CloseDriver()
        {
            _driver!.Quit();
        }
    }
}

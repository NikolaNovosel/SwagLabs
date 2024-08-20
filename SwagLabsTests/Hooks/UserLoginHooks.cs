using BoDi;
using OpenQA.Selenium;
using Serilog;
using SwagLabsTests.Drivers;

namespace SwagLabsTests.Hooks
{
    [Binding]
    public sealed class UserLoginHooks
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IObjectContainer _objectContainer;
        private IWebDriver? _driver;
        public UserLoginHooks(IObjectContainer objectContainer, ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _objectContainer = objectContainer;
        }
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
             Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File("logs\\testlog-.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();
        }
        [BeforeScenario]
        public void BeforeScenario()
        {
            _driver = DriverSingleton.GetDriver();
            _objectContainer.RegisterInstanceAs(_driver);
        }
        [AfterScenario]
        public void AfterScenario()
        {
            if (_scenarioContext.TestError != null)
            {
                Log.Error("Scenario failed: {ScenarioTitle}", _scenarioContext.ScenarioInfo.Title);
                Log.Error("Error message: {ErrorMessage}", _scenarioContext.TestError.Message);
                TakeScreenshot();
            }
            else
            {
                Log.Information("Scenario passed: {ScenarioTitle}", _scenarioContext.ScenarioInfo.Title);
            }
            DriverSingleton.CloseDriver();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Log.CloseAndFlush();
        }
        private void TakeScreenshot()
        {
            try
            {
                var screenshot = ((ITakesScreenshot)_driver!).GetScreenshot();
                var screenshotPath = Path.Combine("screenshots", $"screenshot_{DateTime.Now:yyyyMMdd_HHmmss}.png");
                screenshot.SaveAsFile(screenshotPath);
                Log.Information("Screenshot saved to {screenshotPath}", screenshotPath);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while taking screenshot");
            }
        }
    }
}
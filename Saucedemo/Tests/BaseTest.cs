using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework.Interfaces;
using NUnit.Allure.Core;
using Allure.Commons;
using Core;
using Core.Utilites.Configuration;
using SauceDemoAutomationTests.Pages;
using NLog;

namespace SauceDemoAutomationTests.Tests
{
    [AllureNUnit]
    public class BaseTest
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public static readonly string? BaseUrl = Configurator.AppSettings.URL;

        protected static IWebDriver Driver;
        protected WaitService WaitService;
        private AllureLifecycle _allure;

        public LogInPage LogInPage { get; set; }
        public CheckoutFinalPage CheckoutFinalPage { get; set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
        }

        [SetUp]
        public void Setup()
        {
            _logger.Info("Info level message");
            _logger.Warn("Warn level message");
            _logger.Error("Error level message");
            _logger.Fatal("Fatal level message");

            Driver = new Browser().Driver;
            WaitService = new WaitService(Driver);
            LogInPage = new LogInPage(Driver);
            CheckoutFinalPage = new CheckoutFinalPage(Driver);
            LogInPage.OpenPageByUrl();
            _allure = AllureLifecycle.Instance;

        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                byte[] screenshotBytes = screenshot.AsByteArray;
                _allure.AddAttachment("Screenshot", "image/png", screenshotBytes);
            }

            Driver.Quit();
        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Core;
using Core.Utilites.Configuration;
using SauceDemoAutomationTests.Pages;

namespace SauceDemoAutomationTests.Tests
{
    public class BaseTest
    {
        public static readonly string? BaseUrl = Configurator.AppSettings.URL;

        protected static IWebDriver Driver;
        protected WaitService WaitService;
        public LogInPage LogInPage { get; set; }
        public CheckoutFinalPage CheckoutFinalPage { get; set; }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
        }

        [SetUp]
        public void Setup()
        {
            Driver = new Browser().Driver;
            WaitService = new WaitService(Driver);
            LogInPage = new LogInPage(Driver);
            CheckoutFinalPage = new CheckoutFinalPage(Driver);
            LogInPage.OpenPageByUrl();
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}

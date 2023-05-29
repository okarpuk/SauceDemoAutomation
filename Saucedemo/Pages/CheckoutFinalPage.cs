using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SauceDemoAutomationTests.Tests;

namespace SauceDemoAutomationTests.Pages
{
    public class CheckoutFinalPage : BasePage
    {
        private static string endpoint = "checkout-complete.html";

        private static readonly By BackHomeButtonBy = By.Id("back-to-products");
        private static readonly By CompleteMessageBy = By.ClassName("complete-header");

        public CheckoutFinalPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
            _logger.Info("User redirected to the [Checkout final] page");
        }

        public CheckoutFinalPage(IWebDriver driver) : base(driver, false)
        {
            _logger.Info("User redirected to the [Checkout final] page");
        }

        public override void OpenPageByUrl()
        {
            Driver.Navigate().GoToUrl(BaseTest.BaseUrl + endpoint);
        }

        public override bool IsPageOpened()
        {
            try
            {
                return CompleteMessage().Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public IWebElement CompleteMessage()
        {
            return Driver.FindElement(CompleteMessageBy);
        }

        public string CompleteMessageDisplays()
        {
            return Driver.FindElement(CompleteMessageBy).Text;
        }

        void ClickBackHomeButton()
        {
            Driver.FindElement(BackHomeButtonBy).Click();
        }

        public ProductsPage RedirectToHomePage()
        {
            ClickBackHomeButton();
            return new ProductsPage(Driver);
        }
    }
}

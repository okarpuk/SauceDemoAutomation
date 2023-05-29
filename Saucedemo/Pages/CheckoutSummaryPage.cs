using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SauceDemoAutomationTests.Tests;

namespace SauceDemoAutomationTests.Pages
{
    public class CheckoutSummaryPage : BasePage
    {
        private static string endpoint = "checkout-step-two.html";

        private static readonly By FinishButtonBy = By.Id("finish");

        public CheckoutSummaryPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
            _logger.Info("User redirected to the [Checkout summary] page");
        }

        public CheckoutSummaryPage(IWebDriver driver) : base(driver, false)
        {
            _logger.Info("User redirected to the [Checkout summary] page");
        }

        public override void OpenPageByUrl()
        {
            Driver.Navigate().GoToUrl(BaseTest.BaseUrl + endpoint);
        }

        public override bool IsPageOpened()
        {
            try
            {
                return Driver.FindElement(FinishButtonBy).Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        void ClickFinish()
        {
            Driver.FindElement(FinishButtonBy).Click();
        }

        public CheckoutFinalPage CompleteOrderAttempt()
        {
            ClickFinish();
            return new CheckoutFinalPage(Driver);
        }
    }
}

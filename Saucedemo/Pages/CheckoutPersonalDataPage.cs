using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Core.Models;
using SauceDemoAutomationTests.Tests;

namespace SauceDemoAutomationTests.Pages
{
    public class CheckoutPersonalDataPage : BasePage
    {
        private static string endpoint = "checkout-step-one.html";

        private static readonly By FirstNameInputBy = By.Id("first-name");
        private static readonly By LastNameInputBy = By.Id("last-name");
        private static readonly By ZipCodeInputBy = By.Id("postal-code");
        private static readonly By ContinueButtonBy = By.Id("continue");

        public CheckoutPersonalDataPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
            _logger.Info("User redirected to the [Checkout personal data] page");
        }

        public CheckoutPersonalDataPage(IWebDriver driver) : base(driver, false)
        {
            _logger.Info("User redirected to the [Checkout personal data] page");
        }

        public override void OpenPageByUrl()
        {
            Driver.Navigate().GoToUrl(BaseTest.BaseUrl + endpoint);
        }

        public override bool IsPageOpened()
        {
            try
            {
                return Driver.FindElement(ContinueButtonBy).Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        void FirstNameInput(string firstName)
        {
            Driver.FindElement(FirstNameInputBy).SendKeys(firstName);
        }

        void LastNameInput(string lastName)
        {
            Driver.FindElement(LastNameInputBy).SendKeys(lastName);
        }

        void ZipCodeInput(string zipCode)
        {
            Driver.FindElement(ZipCodeInputBy).SendKeys(zipCode);
        }

        void ClickContinueButton()
        {
            Driver.FindElement(ContinueButtonBy).Click();
        }

        public CheckoutSummaryPage CheckoutSummaryAttempt(User user)
        {
            FirstNameInput(user.FirstName);
            LastNameInput(user.LastName);
            ZipCodeInput(user.ZipCode);
            ClickContinueButton();
            return new CheckoutSummaryPage(Driver);
        }
    }
}

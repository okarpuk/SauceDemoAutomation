using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SauceDemoAutomationTests.Tests;


namespace SauceDemoAutomationTests.Pages
{
    public class ShoppingCartPage : BasePage
    {
        private static string endpoint = "cart.html";

        private static readonly By CheckoutButtonBy = By.Id("checkout");

        public ShoppingCartPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
            _logger.Info("User redirected to the [Shopping cart] page");
        }

        public ShoppingCartPage(IWebDriver driver) : base(driver, false)
        {
            _logger.Info("User redirected to the [Shopping cart] page");
        }

        public override void OpenPageByUrl()
        {
            Driver.Navigate().GoToUrl(BaseTest.BaseUrl + endpoint);
        }

        public override bool IsPageOpened()
        {
            try
            {
                return Driver.FindElement(CheckoutButtonBy).Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        void ClickCheckoutButton()
        {
            Driver.FindElement(CheckoutButtonBy).Click();
        }

        public CheckoutPersonalDataPage Checkout()
        {
            ClickCheckoutButton();
            return new CheckoutPersonalDataPage(Driver);
        }
    }
}

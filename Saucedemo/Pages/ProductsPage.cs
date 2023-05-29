using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SauceDemoAutomationTests.Tests;

namespace SauceDemoAutomationTests.Pages
{
    public class ProductsPage : BasePage
    {
        private static string endpoint = "inventory.html";

        private static readonly By AddToShoppingCartBackpackButtonBy = By.Id("add-to-cart-sauce-labs-backpack");
        private static readonly By ShoppingCartLinkBy = By.ClassName("shopping_cart_link");

        public ProductsPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
            _logger.Info("User redirected to the [Products] page");
        }

        public ProductsPage(IWebDriver driver) : base(driver, false)
        {
            _logger.Info("User redirected to the [Products] page");
        }

        public override void OpenPageByUrl()
        {
            Driver.Navigate().GoToUrl(BaseTest.BaseUrl + endpoint);
        }

        public override bool IsPageOpened()
        {
            try
            {
                return Driver.FindElement(AddToShoppingCartBackpackButtonBy).Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        void ClickAddToShoppingCartBackpackButton()
        {
            Driver.FindElement(AddToShoppingCartBackpackButtonBy).Click();
        }

        void ClickShoppingCartLink()
        {
            Driver.FindElement(ShoppingCartLinkBy).Click();
        }

        public ShoppingCartPage AddToShoppingCart()
        {
            ClickAddToShoppingCartBackpackButton();
            ClickShoppingCartLink();
            return new ShoppingCartPage(Driver);
        }
    }
}

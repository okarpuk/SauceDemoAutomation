using Core.Models;
using NLog;
using OpenQA.Selenium;
using SauceDemoAutomationTests.Tests;

namespace SauceDemoAutomationTests.Pages
{
    public class LogInPage : BasePage
    {
        private static readonly By LoginInputBy = By.Id("user-name");
        private static readonly By PasswordInputBy = By.Id("password");
        private static readonly By LoginButtonBy = By.Id("login-button");
        private static readonly By ErrorMessageBy = By.XPath("//h3[@data-test='error']");

        public LogInPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
            _logger.Info("User redirected to the [Login] page");
        }

        public LogInPage(IWebDriver driver) : base(driver, false)
        {
            _logger.Info("User redirected to the [Login] page");
        }

        public override void OpenPageByUrl()
        {
            Driver.Navigate().GoToUrl(BaseTest.BaseUrl);
        }

        public override bool IsPageOpened()
        {
            try
            {
                return Driver.FindElement(LoginButtonBy).Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        void LoginInput(string username)
        {
            Driver.FindElement(LoginInputBy).SendKeys(username);
        }

        void PasswordInput(string psw)
        {
            Driver.FindElement(PasswordInputBy).SendKeys(psw);
        }

        void ClickLoginButton()
        {
            Driver.FindElement(LoginButtonBy).Click();
        }

        public string IsErrorMessageDisplays()
        {
            return Driver.FindElement(ErrorMessageBy).Text;
        }

        public void LoginAttempt(User user)
        {
            LoginInput(user.Login);
            PasswordInput(user.Password);
            ClickLoginButton();
        }

        public ProductsPage Login(User user)
        {
            LoginAttempt(user);
            return new ProductsPage(Driver);
        }
    }
}

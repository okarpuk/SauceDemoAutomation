using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Allure.Commons;
using Core.Models;
using NLog;
using NLog.Fluent;
using NUnit.Allure.Attributes;
using SauceDemoAutomationTests.Pages;

namespace SauceDemoAutomationTests.Tests
{
    public class End2EndTest : BaseTest
    {
        [Test]
        [Description("End2End test for saucedemo.com")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("User")]
        [AllureSuite("PositiveTests")]
        [AllureSubSuite("GUI")]
        [AllureIssue("TMS-29")]
        [AllureTms("Sharelane-65")]
        [AllureTag("Smoke")]
        [AllureLink("https://saucedemo.com")]
        public void End2End()
        {
            string message = "Thank you for your order!";

            User user = new UserBuilder()
                .SetLogin("standard_user")
                .SetPassword("secret_sauce")
                .SetFirstName("Qwerty")
                .SetLastName("Qwerty")
                .SetZipCode("12345")
                .Build();

            LogInPage
                .Login(user)
                .AddToShoppingCart()
                .Checkout()
                .CheckoutSummaryAttempt(user)
                .CompleteOrderAttempt();

            Assert.That(CheckoutFinalPage.CompleteMessageDisplays, Is.EqualTo(message));
        }
    }
}

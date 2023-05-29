using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;
using SauceDemoAutomationTests.Pages;

namespace SauceDemoAutomationTests.Tests
{
    public class End2EndTest : BaseTest
    {
        [Test]
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

            LogInPage.Login(user)
                .AddToShoppingCart()
                .Checkout()
                .CheckoutSummaryAttempt(user)
                .CompleteOrderAttempt();

            Assert.That(CheckoutFinalPage.CompleteMessageDisplays, Is.EqualTo(message));
        }
    }
}

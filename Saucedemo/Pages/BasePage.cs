using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Core;
using NLog;

namespace SauceDemoAutomationTests.Pages
{
    public abstract class BasePage
    {
        protected static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        protected IWebDriver Driver;
        protected WaitService WaitService;

        public BasePage()
        {
        }

        public BasePage(IWebDriver? driver, bool openPageByUrl)
        {
            Driver = driver;

            if (openPageByUrl)
            {
                OpenPageByUrl();
            }
        }

        public abstract void OpenPageByUrl();
        public abstract bool IsPageOpened();
    }
}

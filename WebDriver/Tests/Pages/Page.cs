using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Pages.CalculatorPage;

namespace Tests.Pages
{
    public class Page
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public Page(IWebDriver driver, double seconds)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
        }

        public IWebElement FindElement(By locator)
        {
            return driver.FindElement(locator);
        }

        public IWebElement FindElementWithWait(By locator)
        {
            return wait.Until(driver => driver.FindElement(locator));
        }

        public void OnOpen()
        {
            driver.Manage().Window.Maximize();
        }

        public void OpenUrl(string URL)
        {
            driver.Navigate().GoToUrl(URL);
        }
    }
}

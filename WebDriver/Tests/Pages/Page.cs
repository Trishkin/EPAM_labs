using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Pages
{
    public class Page
    {
        public IWebDriver driver;
        public WebDriverWait wait;

        public Page(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
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

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Pages.AlpariPage
{
    public class PastebinChromeDriver
    {
        private IWebDriver driver;
        public string homeURL;
        WebDriverWait wait;

        public PastebinChromeDriver(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(15));
        }

        public void OpenPage()
        {
            driver.Manage().Window.Maximize();
            homeURL = "https://pastebin.com/";
            driver.Navigate().GoToUrl(homeURL);
            wait.Until(driver =>
    driver.FindElement(By.XPath("//textarea[@id='postform-text']")));
        }

        public void Select10MinutesExpiration()
        {
            driver.FindElement(By.CssSelector("#w0 > div.post-form__bottom > div.post-form__left > div.form-group.field-postform-expiration > div > span")).Click();
            wait.Until(driver =>
driver.FindElement(By.XPath("//*[contains(@id,'10M')]")));
            driver.FindElement(By.XPath("//*[contains(@id,'10M')]")).Click();
        }

        public void SelectBashSintax()
        {
            driver.FindElement(By.CssSelector("#w0 > div.post-form__bottom > div.post-form__left > div.form-group.field-postform-format > div > span")).Click();
            wait.Until(driver =>
driver.FindElement(By.XPath("//input[contains(@type,'search')] ")));
            driver.FindElement(By.XPath("//input[contains(@type,'search')]")).SendKeys("Bash" + Keys.Enter);
        }

        public void WriteCode(string str)
        {
            IWebElement element =
            driver.FindElement(By.XPath("//textarea[@id='postform-text']"));
            element.Click();
            element.Clear();
            element.SendKeys(str);
        }

        public void WriteTitle(string str)
        {
            IWebElement element =
            driver.FindElement(By.XPath("//input[@id='postform-name']"));
            element.SendKeys(str);
        }

        public IWebElement Paste()
        {
            IWebElement element =
            driver.FindElement(By.XPath("//input[@id='postform-name']"));
            element.Submit();
            return element;
        }


    }


}

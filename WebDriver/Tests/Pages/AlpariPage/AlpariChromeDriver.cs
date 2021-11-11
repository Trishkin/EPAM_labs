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
    public class AlpariChromeDriver
    {
        private IWebDriver driver;
        private string homeURL;
        WebDriverWait wait;

        public AlpariChromeDriver(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(15));
        }

        public void OpenPage()
        {
            driver.Manage().Window.Maximize();
            homeURL = "https://alpari.com/ru/";
            driver.Navigate().GoToUrl(homeURL);
        }

        public void Login()
        {
            
            wait.Until(driver =>
driver.FindElement(By.XPath("//a[@href='/ru/login/']")));


            driver.FindElement(By.XPath("//a[@href='/ru/login/']")).Click();
            wait.Until(driver =>
driver.FindElement(By.XPath("//*[@id='authorization_login']")));
            IWebElement login = driver.FindElement(By.XPath("//*[@id='authorization_login']"));
            login.Clear();
            login.SendKeys("dima.dmitry.kulikov@gmail.com");

            wait.Until(driver =>
driver.FindElement(By.XPath("//*[@id='authorization_password']")));
            IWebElement password = driver.FindElement(By.XPath("//*[@id='authorization_password']"));
            password.Clear();
            password.SendKeys("AY%S&iDd9b4c.sg");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }

        public void OpenAccountPage()
        {
            wait.Until(driver =>
                driver.FindElement(By.XPath("/html/body/div[4]/div[1]/ul/li[2]")));
            driver.FindElement(By.XPath("/html/body/div[4]/div[1]/ul/li[2]")).Click();
        }

        public void ChooseDemoAndInput100USD()
        {
            wait.Until(driver =>
                driver.FindElement(By.XPath("//input[@type='radio'][@value='demo']")));
            driver.FindElement(By.XPath("//input[@type='radio'][@value='demo']")).Click();

            wait.Until(driver =>
            driver.FindElement(By.XPath("//input[@type='text'][@value='0.00']")));
            driver.FindElement(By.XPath("//input[@type='text'][@value='0.00']")).SendKeys(Keys.ArrowLeft + Keys.ArrowLeft + Keys.ArrowLeft + "100");


            driver.FindElement(By.XPath("//button[@type='submit'][@name='send'][@tabindex='0']")).Click();

        }

        public IWebElement FindAccountInfo()
        {
            wait.Until(driver =>
                driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[2]/div[2]/div[2]/div[2]/div[1]/ul/li[1]")));

            return driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[2]/div[2]/div[2]/div[2]/div[1]/ul/li[1]"));
        }

        
    }


}

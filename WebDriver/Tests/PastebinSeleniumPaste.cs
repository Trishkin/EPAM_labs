using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class Chrome_Sample_test
    {
        private IWebDriver driver;
        public string homeURL;


        [Test]
        public void ICanWin()
        {

            driver.Manage().Window.Maximize();
            homeURL = "https://pastebin.com/";
            driver.Navigate().GoToUrl(homeURL);

            WebDriverWait wait = new WebDriverWait(driver,
System.TimeSpan.FromSeconds(15));

            wait.Until(driver =>
driver.FindElement(By.XPath("//textarea[@id='postform-text']")));


            driver.FindElement(By.CssSelector("#w0 > div.post-form__bottom > div.post-form__left > div.form-group.field-postform-expiration > div > span")).Click();
            wait.Until(driver =>
driver.FindElement(By.XPath("//*[contains(@id,'10M')]")));
            driver.FindElement(By.XPath("//*[contains(@id,'10M')]")).Click();

            IWebElement element =
driver.FindElement(By.XPath("//textarea[@id='postform-text']"));
            element.Click();
            element.Clear();
            element.SendKeys("Hello from WebDriver");

            
            element =
driver.FindElement(By.XPath("//input[@id='postform-name']"));
            element.SendKeys("helloweb");

            element.Submit();
        }



        [Test]
        public void BringItOn()
        {

            driver.Manage().Window.Maximize();
            homeURL = "https://pastebin.com/";
            driver.Navigate().GoToUrl(homeURL);

            WebDriverWait wait = new WebDriverWait(driver,
System.TimeSpan.FromSeconds(15));

            wait.Until(driver =>
driver.FindElement(By.XPath("//textarea[@id='postform-text']")));

            driver.FindElement(By.CssSelector("#w0 > div.post-form__bottom > div.post-form__left > div.form-group.field-postform-expiration > div > span")).Click();
            wait.Until(driver =>
driver.FindElement(By.XPath("//*[contains(@id,'10M')]")));
            driver.FindElement(By.XPath("//*[contains(@id,'10M')]")).Click();

             driver.FindElement(By.CssSelector("#w0 > div.post-form__bottom > div.post-form__left > div.form-group.field-postform-format > div > span")).Click();
            wait.Until(driver =>
driver.FindElement(By.XPath("//input[contains(@type,'search')] ")));
            driver.FindElement(By.XPath("//input[contains(@type,'search')]")).SendKeys("Bash" + Keys.Enter);


            IWebElement element =
driver.FindElement(By.XPath("//textarea[@id='postform-text']"));
            //element.Click();
            //element.Clear();
            element.SendKeys("git config --global user.name  \"New Sheriff in Town\" \n git reset $(git commit - tree HEAD ^{ tree} -m \"Legacy code\") \n git push origin master --force");

            

            element =
driver.FindElement(By.XPath("//input[@id='postform-name']"));
            element.SendKeys("how to gain dominance among developers");


            element.Submit();

        }


        [TearDown]
        public void TearDownTest()
        {
            driver.Quit();
        }


        [SetUp]
        public void SetupTest()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("load-extension=C:\\Users\\Asus\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Extensions\\gighmmpiobklfepjocnamgkkbiglidom\\4.39.1_0");
            driver = new ChromeDriver(options);
            homeURL = "https://pastebin.com/";

        }


    }
}

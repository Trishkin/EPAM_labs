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
    public class Alpari
    {
        private IWebDriver driver;
        public string homeURL;


        [Test]
        public void ICanWin()
        {

            driver.Manage().Window.Maximize();
            homeURL = "https://alpari.com/ru/";
            driver.Navigate().GoToUrl(homeURL);

            WebDriverWait wait = new WebDriverWait(driver,
System.TimeSpan.FromSeconds(15));

            wait.Until(driver =>
driver.FindElement(By.XPath("//a[@href='/ru/login/']")));


            driver.FindElement(By.XPath("//a[@href='/ru/login/']")).Click();
            wait.Until(driver =>
driver.FindElement(By.XPath("//*[@id='authorization_login']")));
            driver.FindElement(By.XPath("//*[@id='authorization_login']")).SendKeys("dima.dmitry.kulikov@gmail.com");

            wait.Until(driver =>
driver.FindElement(By.XPath("//*[@id='authorization_password']")));
            driver.FindElement(By.XPath("//*[@id='authorization_password']")).SendKeys("AY%S&iDd9b4c.sg");

            driver.FindElement(By.XPath("//button[@type='submit']")).Click();

            wait.Until(driver =>
            driver.FindElement(By.XPath("/html/body/div[4]/div[1]/ul/li[2]")));
            driver.FindElement(By.XPath("/html/body/div[4]/div[1]/ul/li[2]")).Click();


            wait.Until(driver =>
            driver.FindElement(By.XPath("//input[@type='radio'][@value='demo']")));
            driver.FindElement(By.XPath("//input[@type='radio'][@value='demo']")).Click();

            wait.Until(driver =>
            driver.FindElement(By.XPath("//input[@type='text'][@value='0.00']")));
            driver.FindElement(By.XPath("//input[@type='text'][@value='0.00']")).SendKeys(Keys.ArrowLeft+ Keys.ArrowLeft + Keys.ArrowLeft + "100");


            driver.FindElement(By.XPath("//button[@type='submit'][@name='send'][@tabindex='0']")).Click();


            wait.Until(driver =>
            driver.FindElement(By.XPath("//input[@type='text'][@value='0.00']")));
            driver.FindElement(By.XPath("//input[@type='text'][@value='0.00']")).SendKeys("100");

            wait.Until(driver =>
            driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[2]/div[2]/div[2]/div[2]/div[1]/ul/li[1]")));


            Assert.IsNotNull(driver.FindElement(By.XPath("/html/body/div[4]/div[1]/div[2]/div[2]/div[2]/div[2]/div[1]/ul/li[1]")));
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
            homeURL = "https://alpari.com/ru/";

        }


    }
}

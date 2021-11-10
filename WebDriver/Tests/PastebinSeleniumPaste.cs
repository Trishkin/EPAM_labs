using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Pages.AlpariPage;

namespace Tests
{
    [TestFixture]
    public class Chrome_Sample_test
    {
        private IWebDriver driver;


        [Test]
        public void CreatePaste()
        {
            PastebinChromeDriver chromeDriver = new PastebinChromeDriver(driver);

            chromeDriver.OpenPage();
            chromeDriver.Select10MinutesExpiration();
            chromeDriver.WriteCode("Hello from WebDriver");
            chromeDriver.WriteTitle("helloweb");
            
            Assert.IsNotNull(chromeDriver.Paste());
        }



        [Test]
        public void CreateBashPaste()
        {
            PastebinChromeDriver chromeDriver = new PastebinChromeDriver(driver);

            chromeDriver.OpenPage();
            chromeDriver.Select10MinutesExpiration();
            chromeDriver.SelectBashSintax();
            chromeDriver.WriteCode("git config --global user.name  \"New Sheriff in Town\" \n git reset $(git commit - tree HEAD ^{ tree} -m \"Legacy code\") \n git push origin master --force");
            chromeDriver.WriteTitle("how to gain dominance among developers");

            Assert.IsNotNull(chromeDriver.Paste());
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

        }


    }
}

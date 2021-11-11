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
    public class Alpari
    {
        IWebDriver driver;

        [Test]
        public void CreateDemoAccount()
        {

            AlpariChromeDriver chromeDriver = new AlpariChromeDriver(driver);

            chromeDriver.OpenPage();
            chromeDriver.Login();
            chromeDriver.OpenAccountPage();
            chromeDriver.ChooseDemoAndInput100USD();
            Assert.IsNotNull(chromeDriver.FindAccountInfo());
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

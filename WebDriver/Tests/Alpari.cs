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
        private IWebDriver driver;
        private string login= "dima.dmitry.kulikov@gmail.com";
        private string password = "AY%S&iDd9b4c.sg";
        private string loginAccount = "14649788";
        private string passwordAccount = "i4uLxpj";

        [Test]
        public void CreateDemoAccount()
        {

            AlpariChromeDriver chromeDriver = new AlpariChromeDriver(driver,15);

            chromeDriver.OpenPage();
            chromeDriver.Login(login, password);
            chromeDriver.OpenAccountPage();
            chromeDriver.ChooseDemoAndInput100USD();
            Assert.IsNotNull(chromeDriver.FindAccountInfo());
        }
        //[Test]
        //public void BeginTrading()
        //{

        //    AlpariChromeDriver chromeDriver = new AlpariChromeDriver(driver, 600);

        //    chromeDriver.OpenPage();
        //    chromeDriver.Login(login, password);
        //    chromeDriver.OpenAccountPage();
        //    chromeDriver.OpenTradingPage();
        //    chromeDriver.ConnectToTradingAccount(loginAccount, passwordAccount);
        //    Assert.IsNotNull(chromeDriver.FindTradingInfo());
        //}
        [Test]
        public void AddMoneyOnDemoAccount()
        {

            AlpariChromeDriver chromeDriver = new AlpariChromeDriver(driver, 15);
            chromeDriver.OpenPage();
            chromeDriver.Login(login, password);
            Assert.IsNotNull(chromeDriver.Add100USDOnTradingAccounts());
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

            //options.AddArguments("load-extension=C:\\Users\\Asus\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Extensions\\gighmmpiobklfepjocnamgkkbiglidom\\4.41.0_0");
            //options.AddArgument("user-data-dir=C:\\Users\\Asus\\AppData\\Local\\Google\\Chrome\\User Data");
            options.AddArgument("--enable-javascript");
            driver = new ChromeDriver(options);
        }

    }
}

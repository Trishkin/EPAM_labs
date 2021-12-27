using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Models;
using Tests.Service;
using Tests.Util;

namespace Tests.Steps
{
    public class Steps
    {
        IWebDriver driver;

        public void InitBrowser()
        {
            driver = Driver.DriverInstance.GetInstance();
        }
        public void CloseBrowser()
        {
            TestLog.LogStat(TestContext.CurrentContext);
            //Driver.DriverInstance.CloseBrowser();
        }

        public void LoginAlpari()
        {
            Pages.LoginPage loginPage = new Pages.LoginPage(driver);
            User testUser = UserCreator.CreateUser();
            loginPage.OpenPage()
                .Login(testUser)
                .OpenAccountPage()
                .ChooseDemoAndInput100USD();
        }

        public IWebElement CreatedAccount()
        {
            Pages.AccountPage accountPage = new Pages.AccountPage(driver);
            return accountPage.FindAccountInfo();
        }

        public void StartTrading()
        {
            Pages.TradingPage tradingPage = new Pages.TradingPage(driver);
            User testAccount = AccountCreator.CreateAccount();
            tradingPage.OpenPage()
                .ConnectToTradingAccount(testAccount);
        }

        public IWebElement FindTradInfo()
        {
            Pages.TradingPage accountPage = new Pages.TradingPage(driver);
            return accountPage.FindTradingInfo();
        }

        public bool FindMoneyInfo()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            return mainPage.MoneyChanges();
        }

        public void AddMoneyOnAccount()
        {
            Pages.LoginPage loginPage = new Pages.LoginPage(driver);
            User testUser = UserCreator.CreateUser();
            loginPage.OpenPage()
                .Login(testUser)
                .Add100USDOnTradingAccounts();
        }

        public void DeleteTradingAccount()
        {
            Pages.LoginPage loginPage = new Pages.LoginPage(driver);
            User testUser = UserCreator.CreateUser();
            loginPage.OpenPage()
                .Login(testUser)
                .DeleteFirstTradingAccounts();
        }

        public bool FindDeletedAccount()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            return mainPage.TryToFindDeletedAccount();
        }

        public void CreateOrder()
        {
            Pages.TradingPage tradingPage = new Pages.TradingPage(driver);
            User testAccount = AccountCreator.CreateAccount();
            tradingPage.OpenPage()
                .ConnectToTradingAccount(testAccount)
                .CreateBuyOrder();
        }
        public IWebElement FindCreatedOrder()
        {
            Pages.TradingPage tradingPage = new Pages.TradingPage(driver);
            return tradingPage.FindOrder();
        }
    }
}

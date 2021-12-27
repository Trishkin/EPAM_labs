using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Pages;
using Tests.Service;
using Tests.Models;

namespace Tests
{
    [TestFixture]
    public class Alpari
    {
        private Steps.Steps steps = new Steps.Steps();

        [Test]
        public void CreateDemoAccount()
        {
            steps.LoginAlpari();
            Assert.IsNotNull(steps.CreatedAccount());
        }
        [Test]
        public void BeginTrading()
        {
            steps.StartTrading();
            Assert.IsNotNull(steps.FindTradInfo());
        }
        [Test]
        public void AddMoneyOnDemoAccount()
        {

            steps.AddMoneyOnAccount();
            Assert.IsFalse(steps.FindMoneyInfo());
        }

        [Test]
        public void DeleteDemoAccount()
        {
            steps.DeleteTradingAccount();
            Assert.IsFalse(steps.FindDeletedAccount());
        }

        [Test]
        public void CreateBuyOrder()
        {
            steps.CreateOrder();
            Assert.NotNull(steps.FindCreatedOrder());
        }

        [TearDown]
        public void TearDownTest()
        {
            steps.CloseBrowser();
        }


        [SetUp]
        public void SetupTest()
        {
            steps.InitBrowser();
        }

    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Models;

namespace Tests.Pages
{
    public class TradingPage:Page
    {
        private string homeURL = "https://trade.mql5.com/trade?servers=Alpari-Demo,Alpari-ECN-Demo,Alpari-ECN1,Alpari-Nano,Alpari-Pro.ECN-Demo,Alpari-Pro.ECN,Alpari-Standard1,Alpari-Standard2,Alpari-Standard3,Alpari-MT5,Alpari-MT5-Demo,AINT%20TRADE01,FXTM%20ECN,FXTM%20ECNZERO,FXTM%20PRO,FXTM%20STANDARD,FXTM%20CENT&demo_server=Alpari-Demo&demo_type=forex&demo_leverage=500&lang=ru&save_password=on&version=4";
        private By logInTradeBtnLocator = By.XPath("//*[@id='login']");
        private By passwordTradeBtnLocator = By.XPath("//*[@id='password']");
        private By serverTradeBtnLocator = By.XPath("//select[@id='server']");
        private By serverAlphaTradeBtnLocator = By.XPath("//select[@id='server']/option[1]");
        private By okTradeBtnLocator = By.XPath("//button[contains(text(),'OK')]");
        private By polygonLocator = By.XPath("//*[contains(@class, 'svg')]/*");

        private By createOrderBtnLocator = By.XPath("//a[contains(@title,'Новый ордер')]");
        private By buyBtnLocator = By.XPath("//div[3]/button[contains(text(),'Buy')]");
        
        private By OrderLocator = By.XPath("//div[contains(@class, 'trade-table toolbox-table') and not(contains(@style, 'none'))]//tr[2]");
        public TradingPage(IWebDriver driver) : base(driver)
        {
        }
        public TradingPage OpenPage()
        {
            OnOpen();
            OpenUrl(homeURL);
            return this;
        }
        public TradingPage ConnectToTradingAccount(User account)
        {
            IWebElement Login = FindElementWithWait(logInTradeBtnLocator);
            Login.Clear();
            Login.SendKeys(account.getLogin());
            IWebElement Password = FindElementWithWait(passwordTradeBtnLocator);
            Password.Clear();
            Password.SendKeys(account.getPassword());
            IWebElement Password1 = FindElementWithWait(serverTradeBtnLocator);
            Password1.Click();
            IWebElement Password2 = FindElementWithWait(serverAlphaTradeBtnLocator);
            Password2.Click();
            FindElementWithWait(okTradeBtnLocator).Click();
            FindElementWithWait(polygonLocator);
            return this;
        }

        public void CreateBuyOrder()
        {
            FindElementWithWait(createOrderBtnLocator).Click();
            FindElementWithWait(buyBtnLocator).Click();
        }

        public IWebElement FindOrder()
        {
            return FindElementWithWait(OrderLocator);
        }
        
        public IWebElement FindTradingInfo()
        {
            return FindElementWithWait(polygonLocator);
        }
    }
}

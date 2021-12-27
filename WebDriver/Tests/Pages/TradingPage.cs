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

        private By typeBtnLocator = By.XPath("//*[@id='type']");
        private By typeLongBtnLocator = By.XPath("//*[@id='type']/option[2]");
        private By orderTypeBtnLocator = By.XPath("//*[@id='pend-type']");
        private By orderTypeSellBtnLocator = By.XPath("//*[@id='pend-type']/option[2]");
        private By priceInputLocator = By.XPath("//*[@id='pend-price']");
        private By sellBtnLocator = By.XPath("//button[contains(text(),'Установить ордер')]");

        private By successCreationLocator = By.XPath("//div[contains(text(), 'успешно')]");

        private By closeOrderBtnLocator = By.XPath("//button[contains(@class, 'input-button yellow') and contains(text(),' AUDCAD ')]");

        private By successCloseLocator = By.XPath("//div[contains(text(),' закрыт ')]");

        private By changeTypeLocator = By.XPath("//*[@id='type']");
        private By changeTypeBtnLocator = By.XPath("//*[@id='type']/option[3]");
        private By intputChangeValueLocator = By.XPath("//*[@id='mod-tp']");
        private By changeBtnLocator = By.XPath("//button[contains(text(),'Изменить ')]");

        private By successChangeLocator = By.XPath("//div[contains(text(),'Неверные ')]");

        private By lineBtnLocator = By.XPath("//a[contains(@title,'Линия')]");
        private By autoBtnLocator = By.XPath("//a[contains(@title,'Автопрокрутка')]");
        private By timeBtnLocator = By.XPath("//a[contains(@title,'5 Минут (M5)')]");
        private By scaleBtnLocator = By.XPath("//a[contains(@title,'Увеличить')]");
        private By fullScreenBtnLocator = By.XPath("//a[contains(@title,'Включить')]");

        private By checkedTimeLocator = By.XPath("//a[contains(@title,'5 Минут (M5)') and contains(@class,' checked')]");

        private By closeBtnLocator = By.XPath("//div[contains(@style, 'width: 770')]/div[2][contains(@class,'wx')]");
        public TradingPage(IWebDriver driver) : base(driver)
        {
        }

        public void ChangeGraph()
        {
            
            FindElementWithWait(lineBtnLocator).Click();
            FindElementWithWait(autoBtnLocator).Click();
            FindElementWithWait(timeBtnLocator).Click();
        }

        public IWebElement FindChangedGraph()
        {
            return FindElementWithWait(checkedTimeLocator);
        }
        public void ChangeOrder()
        {
            Actions act = new Actions(driver);

            IWebElement Order = FindElementWithWait(OrderLocator);
            Order.Click();
            act.DoubleClick(Order).Perform();
            FindElementWithWait(changeTypeLocator).Click();
            FindElementWithWait(changeTypeBtnLocator).Click();
            FindElementWithWait(intputChangeValueLocator).Click();
            FindElement(intputChangeValueLocator).SendKeys("999999999");
            FindElementWithWait(changeTypeLocator).Click();
            FindElementWithWait(changeBtnLocator).Click();
        }
        public IWebElement FindChangedOrder()
        {
            return FindElementWithWait(successChangeLocator);
        }
            public TradingPage OpenPage()
        {
            OnOpen();
            OpenUrl(homeURL);
            return this;
        }
        public TradingPage ConnectToTradingAccount(Account account)
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
            FindElementWithWait(closeBtnLocator).Click();
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

        public void CreateLongSellOrder()
        {
            FindElementWithWait(createOrderBtnLocator).Click();
            FindElementWithWait(typeBtnLocator).Click();
            FindElementWithWait(typeLongBtnLocator).Click();
            FindElementWithWait(orderTypeBtnLocator).Click();
            FindElementWithWait(orderTypeSellBtnLocator).Click();
            FindElementWithWait(priceInputLocator).Click();
            FindElementWithWait(priceInputLocator).SendKeys("1");
            FindElementWithWait(sellBtnLocator).Click();
        }

        public IWebElement FindLongOrder()
        {
            return FindElementWithWait(successCreationLocator);
        }

        public void CloseOrder()
        {
            Actions act = new Actions(driver);

           IWebElement Order = FindElementWithWait(OrderLocator);
            Order.Click();
           act.DoubleClick(Order).Perform();
           FindElementWithWait(closeOrderBtnLocator).Click();
        }

        public IWebElement FindDeletedOrder()
        { 
        return FindElementWithWait(successCloseLocator);
        }

        public void ScaleGraph()
        {
            FindElementWithWait(scaleBtnLocator).Click();
            FindElementWithWait(fullScreenBtnLocator).Click();
        }
    }
}

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Pages
{
    public class MainPage: Page
    {
        private string money;
        private string accountNumber;
        private By accountBtnLocator = By.XPath("//a[contains(text(), 'Открыть торговый счет')]");
        private By metaTrader4BtnLocator = By.XPath("//div[contains(@class,'dropdown__control menu-line__text') and contains(text(), 'MetaTrader 4')]");
        private By openTradeBtnLocator = By.XPath("//a[contains(@href,'/ru/platforms/webterminal_mt4/?version=4')]");
        private By demoAccountsLocator = By.XPath("//a[contains(text(),'Учебные') and contains(@class, 'tabs__control ')]");
        private By addMoneyLocator = By.XPath("//button[contains(@data-number, '14651579')]");
        private By countAddMoneyLocator = By.XPath("//*[@id='balance']/input");
        private By countMoneyLocator = By.XPath("//*[contains(@data-account-key, '14651579-mt4')]/*/*/span[contains(@class, 'js-balance-value')]");
        private By firstDemoAccountLocator = By.XPath("//*[contains(@class, 'js-account-row')][1]//span[contains(@class,'dropdown__text')]");
        private By deleteAccountLocator = By.XPath("//*[contains(@class, 'js-account-row')][1]//div[contains(@class,'option__text')]");
        private By deletebtnLocator = By.XPath("//*[contains(@class, 'js-form-el-holder js-form-el__input button button_type_primary js-form-el-field s_mb_18 focus field_active')]");
        public MainPage(IWebDriver driver) : base(driver)
        {
        }

        

        public IWebElement Add100USDOnTradingAccounts()
        {
            
            FindElementWithWait(demoAccountsLocator).Click();
            money = FindElementWithWait(countMoneyLocator).Text;
            FindElementWithWait(addMoneyLocator);
            FindElementWithWait(countAddMoneyLocator).SendKeys("100" + Keys.Enter);

            return FindElement(demoAccountsLocator);
        }

        public void DeleteFirstTradingAccounts()
        {
            FindElementWithWait(demoAccountsLocator).Click();
            accountNumber = FindElementWithWait(demoAccountsLocator).Text;
            FindElementWithWait(firstDemoAccountLocator).Click();
            FindElementWithWait(deleteAccountLocator).Click();
            FindElementWithWait(deletebtnLocator).Click();
        }

        public bool TryToFindDeletedAccount()
        {
            return accountNumber == FindElementWithWait(demoAccountsLocator).Text;
        }


        public TradingPage OpenTradingPage()
        {
            FindElementWithWait(metaTrader4BtnLocator).Click();
            FindElementWithWait(openTradeBtnLocator).Click();
            return new TradingPage(driver);
        }

        public bool MoneyChanges()
        {

            return money == FindElementWithWait(countMoneyLocator).Text;
        }

        public AccountPage OpenAccountPage()
        {
            FindElementWithWait(accountBtnLocator).Click();
            return new AccountPage(driver);

        }
    }
}

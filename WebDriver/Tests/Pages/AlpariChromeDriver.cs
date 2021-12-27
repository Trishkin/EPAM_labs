using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Models;

namespace Tests.Pages
{
    public class AlpariChromeDriver: Page
    {
        private string homeURL = "https://alpari.com/ru/";
        private By logInBtnLocator = By.XPath("//a[@href='/ru/login/']");
        private By emailLocator = By.XPath("//*[@id='authorization_login']");
        private By passwordLocator = By.XPath("//*[@id='authorization_password']");
        private By submitBtnLocator = By.XPath("//button[@type='submit']");
        private By accountBtnLocator = By.XPath("//a[contains(text(), 'Открыть торговый счет')]");
        private By demoBtnLocator = By.XPath("//input[@type='radio'][@value='demo']");
        private By inputMoneyFieldLocator = By.XPath("//input[@type='text'][@value='0.00']");
        private By openDemoBtnLocator = By.XPath("//button[@type='submit'][@name='send'][@tabindex='0']");
        private By informationPasswordFieldLocator = By.XPath("//li[contains(text(), 'Пароль:')]");
        private By metaTrader4BtnLocator = By.XPath("//div[contains(@class,'dropdown__control menu-line__text') and contains(text(), 'MetaTrader 4')]");
        private By openTradeBtnLocator = By.XPath("//a[contains(@href,'/ru/platforms/webterminal_mt4/?version=4')]");
        private By logInTradeBtnLocator = By.XPath("//*[@id='login']");
        private By passwordTradeBtnLocator = By.XPath("//*[@id='password']");
        private By okTradeBtnLocator = By.XPath("//button[contains(text(),'OK')]");
        private By polygonLocator = By.XPath("//*[@id='1639587467718_svg']");
        private By demoAccountsLocator = By.XPath("//a[contains(text(),'Учебные') and contains(@class, 'tabs__control ')]");
        private By addMoneyLocator = By.XPath("//button[contains(@data-number, '14651579')]");
        private By countAddMoneyLocator = By.XPath("//*[@id='balance']/input");
        public AlpariChromeDriver(IWebDriver driver): base(driver)
        {
        }

        public void OpenPage()
        {
            OnOpen();
            OpenUrl(homeURL);
        }

        public void Login(User user)
        {
            FindElementWithWait(logInBtnLocator).Click();
            IWebElement Email = FindElementWithWait(emailLocator);
            Email.Clear();
            Email.SendKeys(user.getLogin());
            IWebElement Password = FindElementWithWait(passwordLocator);
            Password.Clear();
            Password.SendKeys(user.getPassword());
            FindElementWithWait(submitBtnLocator).Click();
        }

        public void OpenAccountPage()
        {
            FindElementWithWait(accountBtnLocator).Click();

        }

        public void ChooseDemoAndInput100USD()
        {
            FindElementWithWait(demoBtnLocator).Click();
            FindElementWithWait(inputMoneyFieldLocator).SendKeys(Keys.Control + Keys.ArrowLeft);
            FindElement(inputMoneyFieldLocator).SendKeys("100");
            FindElementWithWait(openDemoBtnLocator).Click();

        }

        public IWebElement FindAccountInfo()
        {
            return FindElementWithWait(informationPasswordFieldLocator);
        }

        public void OpenTradingPage()
        {
            FindElementWithWait(metaTrader4BtnLocator).Click();
            FindElementWithWait(openTradeBtnLocator).Click();
        }

        public void ConnectToTradingAccount(User account)
        {
            IWebElement Login = FindElementWithWait(logInTradeBtnLocator);
            Login.Clear();
            Login.SendKeys(account.getLogin());
            IWebElement Password = FindElementWithWait(passwordTradeBtnLocator);
            Password.Clear();
            Password.SendKeys(account.getPassword());
            FindElementWithWait(okTradeBtnLocator).Click();
        }

        public IWebElement FindTradingInfo()
        {
            return FindElementWithWait(polygonLocator);
        }

        public IWebElement Add100USDOnTradingAccounts()
        {
            FindElementWithWait(demoAccountsLocator).Click();
            FindElementWithWait(addMoneyLocator).Click();
            FindElementWithWait(countAddMoneyLocator).SendKeys("100"+Keys.Enter);
            return FindElement(demoAccountsLocator);
        }
    }


}

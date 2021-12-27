using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Pages
{
    public class AccountPage:Page
    {
        
        private By demoBtnLocator = By.XPath("//input[@type='radio'][@value='demo']");
        private By inputMoneyFieldLocator = By.XPath("//input[@type='text'][@value='0.00']");
        private By openDemoBtnLocator = By.XPath("//button[@type='submit'][@name='send'][@tabindex='0']");
        private By metaTrader4BtnLocator = By.XPath("//div[contains(@class,'dropdown__control menu-line__text') and contains(text(), 'MetaTrader 4')]");
        private By openTradeBtnLocator = By.XPath("//a[contains(@href,'/ru/platforms/webterminal_mt4/?version=4')]");
        private By informationPasswordFieldLocator = By.XPath("//li[contains(text(), 'Пароль:')]");
        public AccountPage(IWebDriver driver) : base(driver)
        {
        }
        
        public void ChooseDemoAndInput100USD()
        {
            FindElementWithWait(demoBtnLocator).Click();
            FindElementWithWait(inputMoneyFieldLocator).SendKeys(Keys.Control + Keys.ArrowLeft);
            FindElement(inputMoneyFieldLocator).SendKeys("100");
            FindElementWithWait(openDemoBtnLocator).Click();

        }

        public TradingPage OpenTradingPage()
        {
            FindElementWithWait(metaTrader4BtnLocator).Click();
            FindElementWithWait(openTradeBtnLocator).Click();
            return new TradingPage(driver);
        }
        public IWebElement FindAccountInfo()
        {
            return FindElementWithWait(informationPasswordFieldLocator);
        }
    }

}

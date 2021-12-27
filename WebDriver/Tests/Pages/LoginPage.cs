using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Models;

namespace Tests.Pages
{
    public class LoginPage:Page
    {
        private string homeURL = "https://alpari.com/ru/";
        private By logInBtnLocator = By.XPath("//a[@href='/ru/login/']");
        private By emailLocator = By.XPath("//*[@id='authorization_login']");
        private By passwordLocator = By.XPath("//*[@id='authorization_password']");
        private By submitBtnLocator = By.XPath("//button[@type='submit']");
        public LoginPage OpenPage()
        {
            OnOpen();
            OpenUrl(homeURL);
            return this;
        }

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public MainPage Login(User user)
        {
            FindElementWithWait(logInBtnLocator).Click();
            IWebElement Email = FindElementWithWait(emailLocator);
            Email.Clear();
            Email.SendKeys(user.getLogin());

            IWebElement Password = FindElementWithWait(passwordLocator);
            Password.Clear();
            Password.SendKeys(user.getPassword());

            FindElementWithWait(submitBtnLocator).Click();

            return new MainPage(driver);
        }
    }
}

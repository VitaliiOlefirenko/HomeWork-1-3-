using System;
using System.Configuration;
using System.Linq;
using BasicFramework.Framework.Models;
using ChallengeTenFramework.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BasicFramework.Pages
{
    public class ChallengeTenPage : BasePage
    {
        public ChallengeTenPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement UsernameField => Driver.FindElement(By.Name("username"));
        public IWebElement PasswordField => Driver.FindElement(By.Name("password"));
        public IWebElement FirstnameField => Driver.FindElement(By.Name("firstname"));
        public IWebElement LastnameField => Driver.FindElement(By.Name("lastname"));
        public IWebElement SubmitButton => Driver.FindElement(By.XPath("//input[@type='submit']"));
        public IWebElement LoginLink => Driver.FindElement(By.XPath("//a[text()='link']"));
        public IWebElement GetTableRowByUserName(string userName) => Driver.FindElement(By.XPath($"//th[text()='{userName}']//parent::tr"));
        public IWebElement GetUserLoginByUserName(string userName) => GetTableRowByUserName(userName).FindElement(By.XPath("th[2]"));
        public IWebElement GetUserPasswordByUserName(string userName) => GetTableRowByUserName(userName).FindElement(By.XPath("th[3]"));
        public IWebElement GetUserFirstNameByUserName(string userName) => GetTableRowByUserName(userName).FindElement(By.XPath("th[4]"));
        public IWebElement GetUserLastNameByUserName(string userName) => GetTableRowByUserName(userName).FindElement(By.XPath("th[5]"));

        public ChallengeTenPage RegisterNewUser(User user)
        {
            UsernameField.SendKeys(user.Login);
            PasswordField.SendKeys(user.Password);
            FirstnameField.SendKeys(user.FirstName);
            LastnameField.SendKeys(user.LastName);
            SubmitButton.Click();
            return new ChallengeTenPage(Driver);
        }

        public LoginPage OpenLoginPageNewTab()
        {
            LoginLink.Click();
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            waitUntilLeftMenuDisappear();
            return new LoginPage(Driver);
        }

        public void waitUntilLeftMenuDisappear()
        {
            var timeSec = ConfigurationManager.AppSettings["timeToWait"];
            new WebDriverWait(Driver, TimeSpan.FromSeconds(Int32.Parse(timeSec)))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(".menu_container")));
        }
    }
}
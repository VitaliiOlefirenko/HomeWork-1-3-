using BasicFramework.Framework.Models;
using BasicFramework.Pages;
using OpenQA.Selenium;

namespace ChallengeTenFramework.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement usernameInput => Driver.FindElement(By.Name("username"));
        public IWebElement passwordInput => Driver.FindElement(By.Name("password"));
        public IWebElement loginButton => Driver.FindElement(By.XPath("//button[text()='log in']"));
        public WelcomePage Login(User user)
        {
            EnterUserLogin(user);
            EnterUserPassword(user);
            ClickLoginButton();
            return new WelcomePage(Driver);
        }

        public void EnterUserLogin(User user)
        {
            usernameInput.SendKeys(user.Login);
        }

        public void EnterUserPassword(User user)
        {
            passwordInput.SendKeys(user.Password);
        }

        public void ClickLoginButton()
        {
            loginButton.Click();
        }
    }
}

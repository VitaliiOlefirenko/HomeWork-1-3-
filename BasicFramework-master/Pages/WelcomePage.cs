using BasicFramework.Pages;
using OpenQA.Selenium;

namespace ChallengeTenFramework.Pages
{
    public class WelcomePage : BasePage
    {
        public WelcomePage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement WelcomeMessage => Driver.FindElement(By.XPath("//tr//th//h1"));
        public void CloseTabAndSwitchToPrevious()
        {
            Driver.SwitchTo().Window(Driver.CurrentWindowHandle).Close();
            Driver.SwitchTo().Window(Driver.WindowHandles[0]);
        }
    }
}

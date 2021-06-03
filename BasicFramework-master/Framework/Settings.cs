using System;
using System.Configuration;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BasicFramework.Framework
{
    class Settings
    {
        public static IWebDriver GetDriver()
        {
            switch (GetBrowserType())
            {
                case "chrome":
                    return new ChromeDriver(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources/Drivers"));

                default:
                    throw new Exception("Unknown browser type!");
            }
        }

        public static string GetBrowserType()
        {
            return ConfigurationManager.AppSettings["browserType"];
        }
    }
}

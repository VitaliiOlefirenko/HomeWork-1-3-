using System;
using System.IO;
using System.Reflection;
using BasicFramework.Framework;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace BasicFramework.Tests
{
    public class BaseTest
    {
        protected IWebDriver Driver;
        protected static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        [SetUp]
        public virtual void Init()
        {
            Logger.Info("log4net initialized");
            Driver = Settings.GetDriver();
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            Logger.Info("Test started");
        }

        public void UITest(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                var screenshot = Driver.TakeScreenshot();
                var filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"FailedTest" + DateTime.Now.ToString("yyyy-MM-dd-HH-ss"));
                screenshot.SaveAsFile(filePath + ".jpg", ScreenshotImageFormat.Jpeg);
                Logger.Error($"Test failed: {ex}");
                throw;
            }
        }

        [TearDown]
        public virtual void Cleanup()
        {
            Driver.Quit();
        }
    }
}
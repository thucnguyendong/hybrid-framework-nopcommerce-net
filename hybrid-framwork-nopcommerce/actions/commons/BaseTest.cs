using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Microsoft.Edge.SeleniumTools;
using System;
using System.IO;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using log4net;
using log4net.Config;
using NUnit.Framework;
using AventStack.ExtentReports;
using hybrid_framwork_nopcommerce.actions.reportConfig;
using NUnit.Framework.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "app.config", Watch = true)]


namespace hybrid_framwork_nopcommerce.actions.commons
{
    public class BaseTest
    {
        private IWebDriver driver;
        protected string userUrl, adminUrl;
        protected readonly ILog log;
        protected ExtentReports report;
        protected ExtentTest test;
        public static ReadOnlyCollection<Cookie> loginPageCookies;
        public static string globalEmail;
        public static string globalPasswword;

        public BaseTest()
        {
            log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            report = ExtentManager.CreateInstance();
            test = ExtentTestManager.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        protected IWebDriver GetBrowserDriver(string browserName, string url)
        {
            if (browserName.Equals("chrome"))
            {
                new DriverManager().SetUpDriver(new ChromeConfig());
                driver = new ChromeDriver();
            }
            else if (browserName.Equals("firefox"))
            {
                new DriverManager().SetUpDriver(new FirefoxConfig());
                driver = new FirefoxDriver();
            }
            else if (browserName.Equals("edge"))
            {
                new DriverManager().SetUpDriver(new EdgeConfig());
                var options = new EdgeOptions();
                options.UseChromium = true;
                options.BinaryLocation = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";
                string driverPath = Path.Combine(GlobalConstants.PROJECT_DIR, "driverBrowsers");
                driver = new EdgeDriver(driverPath, options);
            }
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(30);
            driver.Navigate().GoToUrl(url);
            return driver;
        }

        protected IWebDriver GetLocalBrowserDriver(string browserName)
        {
            if (browserName.Equals("chrome"))
            {
                driver = new ChromeDriver();
            }
            else if (browserName.Equals("firefox"))
            {
                driver = new FirefoxDriver();
            }
            else if (browserName.Equals("edge"))
            {
                var options = new EdgeOptions();
                options.UseChromium = true;
                options.BinaryLocation = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";
                string driverPath = Path.Combine(GlobalConstants.PROJECT_DIR, "driverBrowsers");
                driver = new EdgeDriver(driverPath, options);
            }
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(30);
            return driver;
        }

        protected void SetEnvironmentUrl(string environment)
        {
            switch (environment)
            {
                case "DEV":
                    userUrl = GlobalConstants.USER_URL;
                    adminUrl = GlobalConstants.ADMIN_URL;
                    break;
                default:
                    Console.WriteLine("Incorrect environment. Please input DEV, TEST or STG.");
                    break;
            }
        }

        private bool CheckTrue(bool condition)
        {
            bool pass = true;
            try
            {
                if (condition == true)
                {
                    log.Info(" -------------------------- PASSED -------------------------- ");
                }
                else
                {
                    log.Info(" -------------------------- FAILED -------------------------- ");
                }
                Assert.IsTrue(condition);
            }
            catch (Exception e)
            {
                pass = false;
            }
            return pass;
        }

        protected bool VerifyTrue(bool condition)
        {
            return CheckTrue(condition);
        }

        private bool CheckFailed(bool condition)
        {
            bool pass = true;
            try
            {
                if (condition == false)
                {
                    log.Info(" -------------------------- PASSED -------------------------- ");
                }
                else
                {
                    log.Info(" -------------------------- FAILED -------------------------- ");
                }
                Assert.IsFalse(condition);
            }
            catch (Exception e)
            {
                pass = false;
            }
            return pass;
        }

        protected bool VerifyFalse(bool condition)
        {
            return CheckFailed(condition);
        }

        private bool CheckEquals(Object actual, Object expected)
        {
            bool pass = true;
            try
            {
                Assert.AreEqual(actual, expected);
                log.Info(" -------------------------- PASSED -------------------------- ");
            }
            catch (Exception e)
            {
                pass = false;
                log.Info(" -------------------------- FAILED -------------------------- ");
            }
            return pass;
        }

        protected bool VerifyEquals(Object actual, Object expected)
        {
            return CheckEquals(actual, expected);
        }

        protected void LogExtentTestResult()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var message = TestContext.CurrentContext.Result.Message;
            var stacktrace = "";
            Status logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
                    test.AddScreenCaptureFromBase64String(SaveScreenShootAsBase64(driver));
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }

            test.Log(logstatus, "Test " + logstatus + "<br />" + message + "<br />" + stacktrace);           
            report.Flush();
        }

        public String CaptureScreenshoot(IWebDriver driver, String screenshotName)
        {
            try
            {
                string currentDate = DateTime.Now.ToString("ddMMyyyyhhmmss");
                String scrShootPath = GlobalConstants.PROJECT_DIR + Path.DirectorySeparatorChar + "img" + Path.DirectorySeparatorChar + screenshotName + currentDate + ".png";
                ITakesScreenshot scrShot = (ITakesScreenshot)driver;
                scrShot.GetScreenshot().SaveAsFile(scrShootPath, OpenQA.Selenium.ScreenshotImageFormat.Png);
                return scrShootPath;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public String SaveScreenShootAsBase64(IWebDriver driver)
        {
            try
            {
                ITakesScreenshot scrShot = (ITakesScreenshot)driver;
                return 
                    scrShot.GetScreenshot().AsBase64EncodedString;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

    }
}

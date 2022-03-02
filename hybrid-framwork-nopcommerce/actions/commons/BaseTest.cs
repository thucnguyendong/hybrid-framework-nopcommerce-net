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

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "app.config", Watch = true)]


namespace hybrid_framwork_nopcommerce.actions.commons
{
    public class BaseTest
    {
        private IWebDriver driver;
        protected string userUrl, adminUrl;
        protected readonly ILog log;

        // This will get the current WORKING directory (i.e. \bin\Debug)
        private string workingDirectory = Environment.CurrentDirectory;

        // This will get the current PROJECT directory
        private string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

        public BaseTest()
        {
            log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
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
                string driverPath = Path.Combine(projectDirectory, "driverBrowsers");
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
                string driverPath = Path.Combine(projectDirectory, "driverBrowsers");
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

        private bool checkTrue(bool condition)
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

        protected bool verifyTrue(bool condition)
        {
            return checkTrue(condition);
        }

        private bool checkFailed(bool condition)
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

        protected bool verifyFalse(bool condition)
        {
            return checkFailed(condition);
        }

        private bool checkEquals(Object actual, Object expected)
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

        protected bool verifyEquals(Object actual, Object expected)
        {
            return checkEquals(actual, expected);
        }
    }
}

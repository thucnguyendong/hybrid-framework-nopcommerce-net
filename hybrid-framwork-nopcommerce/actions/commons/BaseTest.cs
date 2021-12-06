using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Microsoft.Edge.SeleniumTools;
using System;
using System.IO;

namespace hybrid_framwork_nopcommerce.actions.commons
{
    public class BaseTest
    {
        private IWebDriver driver;

        // This will get the current WORKING directory (i.e. \bin\Debug)
        private string workingDirectory = Environment.CurrentDirectory;

        // This will get the current PROJECT directory
        private string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
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
    }
}

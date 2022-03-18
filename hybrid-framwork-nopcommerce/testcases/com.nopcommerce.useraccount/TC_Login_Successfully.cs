using Allure.Commons;
using hybrid_framwork_nopcommerce.actions.commons;
using hybrid_framwork_nopcommerce.actions.pageObject;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;

namespace hybrid_framwork_nopcommerce.testcases.com.nopcommerce.useraccount
{
    [TestFixture]
    [AllureNUnit]
    [AllureDisplayIgnored]
    [AllureEpic("Web")]
    [AllureFeature("user")]
    class TC_Login_Successfully:actions.commons.BaseTest
    {
        IWebDriver driver;
        UserHomePageObject homePage;
        UserLoginPageObject loginPage;

        [SetUp]
        public void SetUp()
        {
            driver = GetLocalBrowserDriver("chrome");
            homePage = new UserHomePageObject(driver);
            homePage.OpenHomePage();        }

        [Test]
        [AllureDescription("Log in email")]
        [AllureSeverity(SeverityLevel.blocker)]
        public void TC_01_Login_Email_Successfully()
        {
            loginPage = homePage.ClickLoginLink();
            loginPage = homePage.ClickLoginLink();
            loginPage.LoginAsUser(globalEmail, globalPasswword);
            Assert.True(homePage.IsMyAccountLinkDisplayed());
        }

        [TearDown]
        public void TearDown()
        {
            AddScreenShootToAllureReportWhenFailed(driver);
            driver.Quit();
        }
    }
}

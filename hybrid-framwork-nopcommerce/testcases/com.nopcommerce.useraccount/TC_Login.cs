using hybrid_framwork_nopcommerce.actions.pageObject;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace hybrid_framwork_nopcommerce.testcases.com.nopcommerce.useraccount
{
    class TC_Login:actions.commons.BaseTest
    {
        IWebDriver driver;
        HomePageObject homePage;
        LoginPageObject loginPage;

        [SetUp]
        public void SetUp()
        {
            driver = GetLocalBrowserDriver("edge");
            homePage = new HomePageObject(driver);
            homePage.OpenHomePage();
        }

        [Test]
        public void TC_01_Login_Empty_Data()
        {
            loginPage = homePage.ClickLoginLink();
            loginPage.ClickLogin();
            Assert.AreEqual(loginPage.GetEmailError(), "Please enter your email");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}

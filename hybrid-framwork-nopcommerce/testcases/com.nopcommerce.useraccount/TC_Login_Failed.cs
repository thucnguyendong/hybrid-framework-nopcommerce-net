using hybrid_framwork_nopcommerce.actions.pageObject;
using NUnit.Framework;
using OpenQA.Selenium;

namespace hybrid_framwork_nopcommerce.testcases.com.nopcommerce.useraccount
{
    class TC_Login_Failed: actions.commons.BaseTest
    {
        IWebDriver driver;
        UserHomePageObject homePage;
        UserLoginPageObject loginPage;

        private string email;
        private string password = "123456";

        [SetUp]
        public void SetUp()
        {
            driver = GetLocalBrowserDriver("chrome");
            homePage = new UserHomePageObject(driver);
            homePage.OpenHomePage();         
        }

        [Test]
        public void TC_01_Login_Empty_Data()
        {
            loginPage = homePage.ClickLoginLink();
            loginPage.ClickLoginButton();
            Assert.AreEqual(loginPage.GetEmailError(), "Please enter your email");
        }

        [Test]
        public void TC_02_Login_Invalid_Data()
        {
            loginPage = homePage.ClickLoginLink();
            loginPage.InputEmail("test");
            loginPage.ClickLoginButton();
            Assert.AreEqual(loginPage.GetEmailError(), "Wrong email");
        }

        [Test]
        public void TC_03_Login_Invalid_Data()
        {
            loginPage = homePage.ClickLoginLink();
            loginPage.InputEmail("test@123.com");
            loginPage.ClickLoginButton();
            Assert.AreEqual(loginPage.GetValidationError(),
                "Login was unsuccessful. Please correct the errors and try again."+ "\r\n" + "No customer account found");
        }


        [Test]
        public void TC_04_Login_Email_With_Invalid_Password()
        {
            loginPage = homePage.ClickLoginLink();
            loginPage.InputEmail(globalEmail);
            loginPage.ClickLoginButton();
            Assert.AreEqual(loginPage.GetValidationError(),
                "Login was unsuccessful. Please correct the errors and try again." + "\r\n" + "The credentials provided are incorrect");

            loginPage.InputEmail(globalEmail);
            loginPage.InputPassword("12345");
            loginPage.ClickLoginButton();
            Assert.AreEqual(loginPage.GetValidationError(),
                "Login was unsuccessful. Please correct the errors and try again." + "\r\n" + "The credentials provided are incorrect");
        }


        [TearDown]
        public void TearDown()
        {
            LogExtentTestResult();
            driver.Quit();
        }
    }
}

using hybrid_framwork_nopcommerce.actions.pageObject;
using NUnit.Framework;
using OpenQA.Selenium;

namespace hybrid_framwork_nopcommerce.testcases.com.nopcommerce.useraccount
{
    [TestFixture]
    public class TC_Login_Successfully_With_Cookie:actions.commons.BaseTest
    {
        IWebDriver driver;
        UserHomePageObject homePage;
        UserLoginPageObject loginPage;

        [SetUp]
        public void SetUp()
        {
            driver = GetLocalBrowserDriver("chrome");
            homePage = new UserHomePageObject(driver);
            homePage.OpenHomePage();
        }

        [Test]
        public void TC_01_Login_Email_Successfully()
        {
            loginPage = homePage.ClickLoginLink();
            loginPage.SetCookies(driver, loginPageCookies);
            VerifyTrue(homePage.IsMyAccountLinkDisplayed());
        }

        [TearDown]
        public void TearDown()
        {
            LogExtentTestResult();
            driver.Quit();
        }
    }
}

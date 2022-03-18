using hybrid_framwork_nopcommerce.actions.pageObject;
using NUnit.Framework;
using OpenQA.Selenium;

namespace hybrid_framwork_nopcommerce.testcases.com.nopcommerce.useraccount
{
    [TestFixture]
    [AllureNUnit]
    [AllureDisplayIgnored]
    class TC_Login_Successfully:actions.commons.BaseTest
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
            homePage.OpenHomePage();        }

        [Test]
        public void TC_01_Login_Email_Successfully()
        {
            loginPage = homePage.ClickLoginLink();
            loginPage = homePage.ClickLoginLink();
            loginPage.LoginAsUser(globalEmail, globalPasswword);
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

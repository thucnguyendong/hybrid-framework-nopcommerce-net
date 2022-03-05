using hybrid_framwork_nopcommerce.actions.pageObject;
using NUnit.Framework;
using OpenQA.Selenium;

namespace hybrid_framwork_nopcommerce.testcases.com.nopcommerce.useraccount
{
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
            homePage.OpenHomePage();
            UserRegisterPageObject registerPage = homePage.ClickRegisterLink();
            string firstName = "Nguyen";
            string lastName = "Thuc";
            string day = "11";
            string month = "May";
            string year = "1995";
            string company = "Nashtech";
            string confirmPassword = "123456";
            email = registerPage.GetRandomEmail("gmail.com");
            registerPage.SelectMaleGender();
            registerPage.InputFirstName(firstName);
            registerPage.InputLastName(lastName);
            registerPage.SelectDay(day);
            registerPage.SelectMonth(month);
            registerPage.SelectYear(year);
            registerPage.InputEmail(email);
            registerPage.InputCompany(company);
            registerPage.InputPassword(password);
            registerPage.InputConfirmPassword(confirmPassword);
            registerPage.ClickRegisterButton();

            Assert.AreEqual(registerPage.GetSuccessMessage(), "Your registration completed");

            homePage = registerPage.ClickLogOutLink();
            homePage.SleepInSecond(1);
        }

        [Test]
        public void TC_01_Login_Email_Successfully()
        {
            loginPage = homePage.ClickLoginLink();
            loginPage.InputEmail(email);
            loginPage.InputPassword(password);
            loginPage.ClickLoginButton();
            homePage = new UserHomePageObject(driver);
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

using hybrid_framwork_nopcommerce.actions.commons;
using hybrid_framwork_nopcommerce.actions.pageObject;
using hybrid_framwork_nopcommerce.actions.pageObject.admin;
using NUnit.Framework;
using OpenQA.Selenium;

namespace hybrid_framwork_nopcommerce.testcases.com.nopcommerce.adminaccount
{
    class TC_Admin_Login: actions.commons.BaseTest
    {
        IWebDriver driver;
        UserHomePageObject homePage;
        UserLoginPageObject loginPage;
        AdminLoginPageObject adminLoginPage;
        AdminDashboardPageObject adminDashboardPage;

        private string userEmail;
        private string userPassword = "123456";
        private string adminEmail = "admin@yourstore.com";
        private string adminPassword = "admin";

        [SetUp]
        public void SetUp()
        {
            driver = GetLocalBrowserDriver("chrome");
            SetEnvironmentUrl("DEV");
            homePage = PageGenerator.GetUserHomePage(driver);
            homePage.OpenUserURL(driver,userUrl);
            UserRegisterPageObject registerPage = homePage.ClickRegisterLink();
            string firstName = "Nguyen";
            string lastName = "Thuc";
            string day = "11";
            string month = "May";
            string year = "1995";
            string company = "Nashtech";
            string confirmPassword = "123456";
            userEmail = registerPage.GetRandomEmail("gmail.com");
            registerPage.SelectMaleGender();
            registerPage.InputFirstName(firstName);
            registerPage.InputLastName(lastName);
            registerPage.SelectDay(day);
            registerPage.SelectMonth(month);
            registerPage.SelectYear(year);
            registerPage.InputEmail(userEmail);
            registerPage.InputCompany(company);
            registerPage.InputPassword(userPassword);
            registerPage.InputConfirmPassword(confirmPassword);
            registerPage.ClickRegisterButton();

            Assert.AreEqual(registerPage.GetSuccessMessage(), "Your registration completed");

            homePage = registerPage.ClickLogOutLink();
            homePage.SleepInSecond(1);
        }

        [Test]
        public void TC_01_Login_Admin_Successfully()
        {
            loginPage = homePage.ClickLoginLink();
            homePage = loginPage.LoginAsUser(userEmail, userPassword);
            homePage.ClickUserLogoutLink(driver);

            adminLoginPage = homePage.OpenAdminURL(driver,adminUrl);
            adminDashboardPage = adminLoginPage.LoginAsAdmin(adminEmail, adminPassword);
            Assert.True(adminDashboardPage.IsDashBoardPageDisplayed());
            adminLoginPage=adminDashboardPage.ClickAdminLogoutLink(driver);
            Assert.Pass();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}

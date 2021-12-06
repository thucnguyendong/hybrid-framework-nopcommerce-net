using hybrid_framwork_nopcommerce.actions.pageObject;
using NUnit.Framework;
using OpenQA.Selenium;

namespace hybrid_framwork_nopcommerce.testcases.com.nopcommerce.useraccount
{
    class TC_Login_Failed: actions.commons.BaseTest
    {
        IWebDriver driver;
        HomePageObject homePage;
        LoginPageObject loginPage;

        private string email;
        private string password = "123456";

        [SetUp]
        public void SetUp()
        {
            driver = GetLocalBrowserDriver("chrome");
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

        [Test]
        public void TC_02_Login_Invalid_Data()
        {
            loginPage = homePage.ClickLoginLink();
            loginPage.InputEmail("test");
            loginPage.ClickLogin();
            Assert.AreEqual(loginPage.GetEmailError(), "Wrong email");
        }

        [Test]
        public void TC_03_Login_Invalid_Data()
        {
            loginPage = homePage.ClickLoginLink();
            loginPage.InputEmail("test@123.com");
            loginPage.ClickLogin();
            Assert.AreEqual(loginPage.GetValidationError(),
                "Login was unsuccessful. Please correct the errors and try again."+ "\r\n" + "No customer account found");
        }


        [Test]
        public void TC_04_Login_Email_With_Invalid_Password()
        {
            RegisterPageObject registerPage = homePage.ClickRegisterLink();
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

            loginPage = homePage.ClickLoginLink();
            loginPage.InputEmail(email);
            loginPage.ClickLogin();
            Assert.AreEqual(loginPage.GetValidationError(),
                "Login was unsuccessful. Please correct the errors and try again." + "\r\n" + "The credentials provided are incorrect");

            loginPage.InputEmail(email);
            loginPage.InputPassword("12345");
            loginPage.ClickLogin();
            Assert.AreEqual(loginPage.GetValidationError(),
                "Login was unsuccessful. Please correct the errors and try again." + "\r\n" + "The credentials provided are incorrect");
        }


        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}

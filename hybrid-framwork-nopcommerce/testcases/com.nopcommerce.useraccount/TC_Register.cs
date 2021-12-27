using hybrid_framwork_nopcommerce.actions.pageObject;
using NUnit.Framework;
using OpenQA.Selenium;

namespace hybrid_framwork_nopcommerce
{
    public class TC_Register: actions.commons.BaseTest
    {
        private IWebDriver driver;
        private UserHomePageObject homePage;
        private UserRegisterPageObject registerPage;

        private string firstName = "Nguyen";
        private string lastName = "Thuc";
        private string day = "11";
        private string month= "May";
        private string year = "1995";
        private string email;
        private string company = "Nashtech";
        private string password = "123456";
        private string confirmPassword = "123456";


        [SetUp]
        public void Setup()
        {
            driver = GetLocalBrowserDriver("chrome");
            homePage = new UserHomePageObject(driver);
            homePage.OpenHomePage();
        }

        [Test]
        public void TC_01_Register_Member_Successfully()
        {
            registerPage = homePage.ClickRegisterLink();
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
            Assert.Pass();
        }
    }
}
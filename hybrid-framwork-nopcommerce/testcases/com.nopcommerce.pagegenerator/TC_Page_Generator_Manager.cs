using hybrid_framwork_nopcommerce.actions.pageObject;
using hybrid_framwork_nopcommerce.actions.pageObject.mywebMenu;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace hybrid_framwork_nopcommerce.testcases.com.nopcommerce.pagegenerator
{
    class TC_Page_Generator_Manager : actions.commons.BaseTest
    {
        private IWebDriver driver;
        private UserHomePageObject homePage;
        private UserRegisterPageObject registerPage;
        private UserLoginPageObject loginPage;
        private CustomerInfoPageObject customerInfoPage;

        private string firstName = "Nguyen";
        private string lastName = "Thuc";
        private string day = "11";
        private string month = "May";
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
        }

        [Test]
        public void TC_Login_Successfully()
        {
            loginPage= homePage.ClickLoginLink();
            loginPage.InputEmail(email);
            loginPage.InputPassword(password);
            homePage =loginPage.ClickLoginButton();
            customerInfoPage = homePage.ClickMyAccountLink();
            Assert.AreEqual(customerInfoPage.GetFirstNameTextboxValue(),firstName);
            Assert.AreEqual(customerInfoPage.GetLastNameTextboxValue(),lastName);
            Assert.AreEqual(customerInfoPage.GetEmailTextboxValue(),email);
            Assert.Pass();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}

using hybrid_framwork_nopcommerce.actions.pageObject;
using hybrid_framwork_nopcommerce.actions.pageObject.mywebMenu;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace hybrid_framwork_nopcommerce.testcases.com.nopcommerce.pagegenerator
{
    class TC_Switch_Page : actions.commons.BaseTest
    {
        private IWebDriver driver;
        private UserHomePageObject homePage;
        private UserRegisterPageObject registerPage;
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
            homePage = registerPage.ClickRegisterButton();
            Assert.AreEqual(registerPage.GetSuccessMessage(), "Your registration completed");
        }

        [Test]
        public void TC_Switch_Page_Successfully()
        {
            customerInfoPage = homePage.ClickMyAccountLink();
            customerInfoPage.ClickItemInMyAccountMenuByName(driver, "Addresses");
            UserAddressPageObject addressPage = PageGenerator.GetAddressPage(driver);
            addressPage.ClickItemInMyAccountMenuByName(driver, "My product reviews");
            MyProductReviewPageObject myProductReviewPageObject = PageGenerator.GetMyProductReviewPage(driver);
            Assert.Pass();
        }

        [TearDown]
        public void TearDown()
        {
            //driver.Quit();
        }
    }
}

using hybrid_framwork_nopcommerce.actions.commons;
using hybrid_framwork_nopcommerce.actions.pageObject;
using hybrid_framwork_nopcommerce.actions.reportConfig;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace hybrid_framwork_nopcommerce.testcases.com.nopcommerce
{
    [SetUpFixture]
    public class TestFixtureSetupClass:BaseTest
    {
        private IWebDriver driver;
        private UserHomePageObject homePage;
        private UserRegisterPageObject registerPage;

        [OneTimeSetUp]
        public void Init()
        {
            string firstName = "Nguyen";
            string lastName = "Thuc";
            string day = "11";
            string month = "May";
            string year = "1995";
            string company = "Nashtech";
            globalPasswword = "123456";
            string confirmPassword = "123456";

            SetEnvironmentUrl("DEV");
            driver = GetBrowserDriver("chrome", userUrl);
            homePage = new UserHomePageObject(driver);

            registerPage = homePage.ClickRegisterLink();
            globalEmail = registerPage.GetRandomEmail("gmail.com");
            registerPage.SelectMaleGender();
            registerPage.InputFirstName(firstName);
            registerPage.InputLastName(lastName);
            registerPage.SelectDay(day);
            registerPage.SelectMonth(month);
            registerPage.SelectYear(year);
            registerPage.InputEmail(globalEmail);
            registerPage.InputCompany(company);
            registerPage.InputPassword(globalPasswword);
            registerPage.InputConfirmPassword(confirmPassword);
            registerPage.ClickRegisterButton();
            VerifyEquals(registerPage.GetSuccessMessage(), "Your registration completed");

            loginPageCookies = homePage.GetAllCookies(driver);
            driver.Quit();
        }
    }
}

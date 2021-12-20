using hybrid_framwork_nopcommerce.actions.pageObject.myWebMenuItem;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace hybrid_framwork_nopcommerce.actions.pageObject
{
    public class HomePageObject:commons.BasePage 
    {
        private IWebDriver driver;

        public HomePageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl("https://demo.nopcommerce.com/");
        }

        public RegisterPageObject ClickRegisterLink()
        {
            WaitForElementClickable(driver, HomePageUI.RESGISTER_LINK);
            ClickElement(driver, HomePageUI.RESGISTER_LINK);
            return PageGenerator.GetRegisterPage(driver);
        }

        public LoginPageObject ClickLoginLink()
        {
            WaitForElementClickable(driver, HomePageUI.LOGIN_LINK);
            ClickElement(driver, HomePageUI.LOGIN_LINK);
            return PageGenerator.GetLoginPage(driver);
        }


        public Boolean IsMyAccountLinkDisplayed()
        {
            return IsElementDisplayed(driver, HomePageUI.MY_ACCOUNT_LINK);
        }

        public CustomerInfoPageObject ClickMyAccountLink()
        {
            WaitForElementClickable(driver, HomePageUI.MY_ACCOUNT_LINK);
            ClickElement(driver, HomePageUI.MY_ACCOUNT_LINK);
            return PageGenerator.GetCustomerInfoPage(driver);
        }
    }
}

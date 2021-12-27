using hybrid_framwork_nopcommerce.actions.commons;
using hybrid_framwork_nopcommerce.actions.pageObject.mywebMenu;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace hybrid_framwork_nopcommerce.actions.pageObject
{
    public class UserHomePageObject:commons.BasePage 
    {
        private IWebDriver driver;

        public UserHomePageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void OpenHomePage()
        {
            OpenBrowser(driver, GlobalConstants.USER_URL);
        }

        public UserRegisterPageObject ClickRegisterLink()
        {
            WaitForElementClickable(driver, UserHomePageUI.RESGISTER_LINK);
            ClickElement(driver, UserHomePageUI.RESGISTER_LINK);
            return PageGenerator.GetRegisterPage(driver);
        }

        public UserLoginPageObject ClickLoginLink()
        {
            WaitForElementClickable(driver, UserHomePageUI.LOGIN_LINK);
            ClickElement(driver, UserHomePageUI.LOGIN_LINK);
            return PageGenerator.GetUserLoginPage(driver);
        }


        public Boolean IsMyAccountLinkDisplayed()
        {
            return IsElementDisplayed(driver, UserHomePageUI.MY_ACCOUNT_LINK);
        }

        public CustomerInfoPageObject ClickMyAccountLink()
        {
            WaitForElementClickable(driver, UserHomePageUI.MY_ACCOUNT_LINK);
            ClickElement(driver, UserHomePageUI.MY_ACCOUNT_LINK);
            return PageGenerator.GetCustomerInfoPage(driver);
        }
    }
}

using hybrid_framwork_nopcommerce.interfaces.pageUI;
using OpenQA.Selenium;
using System;

namespace hybrid_framwork_nopcommerce.actions.pageObject
{
    public class UserLoginPageObject:commons.BasePage
    {
        private IWebDriver driver;
        public UserLoginPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void InputEmail(string email)
        {
            WaitForElementVisible(driver, UserLoginPageUI.EMAIL_TEXTBOX);
            InputIntoElement(driver, UserLoginPageUI.EMAIL_TEXTBOX,email);
        }

        public void InputPassword(string password)
        {
            WaitForElementVisible(driver, UserLoginPageUI.PASSWORD_TEXTBOX);
            InputIntoElement(driver, UserLoginPageUI.PASSWORD_TEXTBOX, password);
        }

        public UserHomePageObject ClickLoginButton()
        {
            WaitForElementVisible(driver, UserLoginPageUI.LOGIN_BUTTON);
            ClickElement(driver, UserLoginPageUI.LOGIN_BUTTON);
            return PageGenerator.GetUserHomePage(driver);
        }

        public string GetEmailError()
        {
            WaitForElementVisible(driver, UserLoginPageUI.EMAIL_ERROR);
            return GetElementText(driver, UserLoginPageUI.EMAIL_ERROR);
        }

        public string GetValidationError()
        {
            WaitForElementVisible(driver, UserLoginPageUI.VALIDATION_ERROR);
            return GetElementText(driver, UserLoginPageUI.VALIDATION_ERROR);
        }

        public UserHomePageObject LoginAsUser(string userEmail, string userPassword)
        {
            InputEmail(userEmail);
            InputPassword(userPassword);
            return ClickLoginButton();
        }
    }
}

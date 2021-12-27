using hybrid_framwork_nopcommerce.interfaces.pageUI;
using hybrid_framwork_nopcommerce.interfaces.pageUI.nopcommerce.admin;
using OpenQA.Selenium;
using System;

namespace hybrid_framwork_nopcommerce.actions.pageObject.admin
{
    public class AdminLoginPageObject:commons.BasePage
    {
        private IWebDriver driver;
        public AdminLoginPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void InputEmail(string email)
        {
            WaitForElementVisible(driver, AdminLoginPageUI.EMAIL_TEXTBOX);
            InputIntoElement(driver, AdminLoginPageUI.EMAIL_TEXTBOX,email);
        }

        public void InputPassword(string password)
        {
            WaitForElementVisible(driver, AdminLoginPageUI.PASSWORD_TEXTBOX);
            InputIntoElement(driver, AdminLoginPageUI.PASSWORD_TEXTBOX, password);
        }

        public AdminDashboardPageObject ClickLoginButton()
        {
            WaitForElementVisible(driver, AdminLoginPageUI.LOGIN_BUTTON);
            ClickElement(driver, AdminLoginPageUI.LOGIN_BUTTON);
            return PageGenerator.GetAdminDashboardPage(driver);
        }

        public string GetEmailError()
        {
            WaitForElementVisible(driver, AdminLoginPageUI.EMAIL_ERROR);
            return GetElementText(driver, AdminLoginPageUI.EMAIL_ERROR);
        }

        public string GetValidationError()
        {
            WaitForElementVisible(driver, AdminLoginPageUI.VALIDATION_ERROR);
            return GetElementText(driver, AdminLoginPageUI.VALIDATION_ERROR);
        }

        public AdminDashboardPageObject LoginAsAdmin(string adminEmail, string adminPassword)
        {
            InputEmail(adminEmail);
            InputPassword(adminPassword);
            return ClickLoginButton();
        }
    }
}

using hybrid_framwork_nopcommerce.interfaces.pageUI;
using OpenQA.Selenium;

namespace hybrid_framwork_nopcommerce.actions.pageObject
{
    public class LoginPageObject:commons.BasePage
    {
        private IWebDriver driver;
        public LoginPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void InputEmail(string email)
        {
            WaitForElementVisible(driver, LoginPageUI.EMAIL_TEXTBOX);
            InputIntoElement(driver, LoginPageUI.EMAIL_TEXTBOX,email);
        }

        public void InputPassword(string password)
        {
            WaitForElementVisible(driver, LoginPageUI.PASSWORD_TEXTBOX);
            InputIntoElement(driver, LoginPageUI.PASSWORD_TEXTBOX, password);
        }

        public HomePageObject ClickLogin()
        {
            WaitForElementVisible(driver, LoginPageUI.LOGIN_BUTTON);
            ClickElement(driver, LoginPageUI.LOGIN_BUTTON);
            return PageGenerator.GetHomePage(driver);
        }

        public string GetEmailError()
        {
            WaitForElementVisible(driver, LoginPageUI.EMAIL_ERROR);
            return GetElementText(driver, LoginPageUI.EMAIL_ERROR);
        }

        public string GetValidationError()
        {
            WaitForElementVisible(driver, LoginPageUI.VALIDATION_ERROR);
            return GetElementText(driver, LoginPageUI.VALIDATION_ERROR);
        }
    }
}

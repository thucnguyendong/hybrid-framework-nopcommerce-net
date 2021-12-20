using hybrid_framwork_nopcommerce.interfaces.pageUI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace hybrid_framwork_nopcommerce.actions.pageObject.myWebMenuItem
{
    public class CustomerInfoPageObject : commons.BasePage
    {
        private IWebDriver driver;

        public CustomerInfoPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string GetFirstNameTextboxValue()
        {
            WaitForElementVisible(driver, CustomerInfoPageUI.FIRSTNAME_TEXTBOX);
            return GetElementAttribute(driver, CustomerInfoPageUI.FIRSTNAME_TEXTBOX,"value");
        }

        public string GetLastNameTextboxValue()
        {
            WaitForElementVisible(driver, CustomerInfoPageUI.LASTNAME_TEXTBOX);
            return GetElementAttribute(driver, CustomerInfoPageUI.LASTNAME_TEXTBOX,"value");
        }

        public string GetEmailTextboxValue()
        {
            WaitForElementVisible(driver, CustomerInfoPageUI.EMAIL_TEXTBOX);
            return GetElementAttribute(driver, CustomerInfoPageUI.EMAIL_TEXTBOX,"value");
        }
    }
}

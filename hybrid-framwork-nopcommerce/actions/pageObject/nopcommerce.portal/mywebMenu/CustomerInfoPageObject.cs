using hybrid_framwork_nopcommerce.interfaces.pageUI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace hybrid_framwork_nopcommerce.actions.pageObject.mywebMenu
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
            WaitForElementVisible(driver, UserCustomerInfoPageUI.FIRSTNAME_TEXTBOX);
            return GetElementAttribute(driver, UserCustomerInfoPageUI.FIRSTNAME_TEXTBOX,"value");
        }

        public string GetLastNameTextboxValue()
        {
            WaitForElementVisible(driver, UserCustomerInfoPageUI.LASTNAME_TEXTBOX);
            return GetElementAttribute(driver, UserCustomerInfoPageUI.LASTNAME_TEXTBOX,"value");
        }

        public string GetEmailTextboxValue()
        {
            WaitForElementVisible(driver, UserCustomerInfoPageUI.EMAIL_TEXTBOX);
            return GetElementAttribute(driver, UserCustomerInfoPageUI.EMAIL_TEXTBOX,"value");
        }
    }
}

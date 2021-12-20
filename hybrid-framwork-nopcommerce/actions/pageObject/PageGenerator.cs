using hybrid_framwork_nopcommerce.actions.pageObject.myWebMenuItem;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace hybrid_framwork_nopcommerce.actions.pageObject
{
    public class PageGenerator
    {
        public static LoginPageObject GetLoginPage(IWebDriver driver)
        {
            return new LoginPageObject(driver);
        }

        public static HomePageObject GetHomePage(IWebDriver driver)
        {
            return new HomePageObject(driver);
        }

        public static RegisterPageObject GetRegisterPage(IWebDriver driver)
        {
            return new RegisterPageObject(driver);
        }

        public static CustomerInfoPageObject GetCustomerInfoPage(IWebDriver driver)
        {
            return new CustomerInfoPageObject(driver);
        }

        internal static AddressPageObject GetAddressPage(IWebDriver driver)
        {
            return new AddressPageObject(driver);
        }

        internal static MyProductReviewPageObject GetMyProductReviewPage(IWebDriver driver)
        {
            return new MyProductReviewPageObject(driver);
        }
    }
}

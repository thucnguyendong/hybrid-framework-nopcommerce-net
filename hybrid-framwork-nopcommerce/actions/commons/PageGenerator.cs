using hybrid_framwork_nopcommerce.actions.pageObject.admin;
using hybrid_framwork_nopcommerce.actions.pageObject.mywebMenu;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace hybrid_framwork_nopcommerce.actions.pageObject
{
    public class PageGenerator
    {
        public static UserLoginPageObject GetUserLoginPage(IWebDriver driver)
        {
            return new UserLoginPageObject(driver);
        }

        public static UserHomePageObject GetUserHomePage(IWebDriver driver)
        {
            return new UserHomePageObject(driver);
        }

        public static UserRegisterPageObject GetRegisterPage(IWebDriver driver)
        {
            return new UserRegisterPageObject(driver);
        }

        public static CustomerInfoPageObject GetCustomerInfoPage(IWebDriver driver)
        {
            return new CustomerInfoPageObject(driver);
        }

        public static UserAddressPageObject GetAddressPage(IWebDriver driver)
        {
            return new UserAddressPageObject(driver);
        }

        public static MyProductReviewPageObject GetMyProductReviewPage(IWebDriver driver)
        {
            return new MyProductReviewPageObject(driver);
        }

        public static AdminDashboardPageObject GetAdminDashboardPage(IWebDriver driver)
        {
            return new AdminDashboardPageObject(driver);
        }

        public static AdminLoginPageObject GetAdminLoginPage(IWebDriver driver)
        {
            return new AdminLoginPageObject(driver);
        }
    }
}

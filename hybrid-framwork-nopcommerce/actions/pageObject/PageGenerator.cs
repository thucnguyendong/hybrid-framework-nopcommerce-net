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
    }
}

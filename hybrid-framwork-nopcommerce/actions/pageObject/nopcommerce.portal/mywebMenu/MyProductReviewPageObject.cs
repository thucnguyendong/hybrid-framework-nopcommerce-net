using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace hybrid_framwork_nopcommerce.actions.pageObject.mywebMenu
{
    public class MyProductReviewPageObject : commons.BasePage
    {
        private IWebDriver driver;

        public MyProductReviewPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}

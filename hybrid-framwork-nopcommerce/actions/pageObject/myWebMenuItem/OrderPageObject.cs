using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace hybrid_framwork_nopcommerce.actions.pageObject.myWebMenuItem
{
    class OrderPageObject : commons.BasePage
    {
        private IWebDriver driver;

        public OrderPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace hybrid_framwork_nopcommerce.actions.pageObject.myWebMenuItem
{
    public class AddressPageObject : commons.BasePage
    {
        private IWebDriver driver;

        public AddressPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}

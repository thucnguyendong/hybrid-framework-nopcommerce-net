using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace hybrid_framwork_nopcommerce.actions.pageObject
{
    class HomePageObject
    {
        private IWebDriver driver;

        public HomePageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

    }
}

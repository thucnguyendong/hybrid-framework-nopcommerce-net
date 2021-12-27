using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace hybrid_framwork_nopcommerce.actions.pageObject.mywebMenu
{
    class RewardPageObject : commons.BasePage
    {
        private IWebDriver driver;

        public RewardPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}

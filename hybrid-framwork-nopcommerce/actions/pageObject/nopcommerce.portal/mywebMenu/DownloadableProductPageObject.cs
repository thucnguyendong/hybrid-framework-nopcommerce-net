using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace hybrid_framwork_nopcommerce.actions.pageObject.mywebMenu
{
    public class DownloadableProductPageObject : commons.BasePage
    {
        private IWebDriver driver;

        public DownloadableProductPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
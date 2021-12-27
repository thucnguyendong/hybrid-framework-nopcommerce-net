using hybrid_framwork_nopcommerce.actions.pageObject.mywebMenu;
using hybrid_framwork_nopcommerce.interfaces.pageUI.nopcommerce.admin;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace hybrid_framwork_nopcommerce.actions.pageObject.admin
{
    public class AdminDashboardPageObject:commons.BasePage 
    {
        private IWebDriver driver;

        public AdminDashboardPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool IsDashBoardPageDisplayed()
        {
            WaitForElementVisible(driver, AdminDashboardPageUI.DASHBOARD_HEADER);
            return IsElementDisplayed(driver, AdminDashboardPageUI.DASHBOARD_HEADER);
        }
    }
}

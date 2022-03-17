using System;
using System.Collections.Generic;
using System.Text;

namespace hybrid_framwork_nopcommerce.interfaces.pageUI
{
    public class BasePageUI
    {
		/** Header */
		public static readonly string REGISTER_LINK = "//div[@class='header-links']//a[text()='Register']";
		public static readonly string USER_LOGOUT_LINK = "//div[@class='header-links']//a[text()='Log out']";
		public static readonly string ADMIN_LOGOUT_LINK = "//li[@class='nav-item']//a[text()='Logout']";
		public static readonly string LOGIN_LINK = "//div[@class='header-links']//a[text()='Log in']";
		public static readonly string MY_ACCOUNT_LINK = "//div[@class='header-links']//a[text()='My account']";

		public static readonly string DYNAMIC_ITEM_IN_MY_ACCOUNT = "//ul[@class='list']//a[text()='{0}']";
		public static readonly string DYNAMIC_PAGE_FOOTER = "//div[@class='footer']//a[text()='{0}']";
        public static readonly string DYNAMIC_TEXTBOX_BY_ID = "//input[@id='{0}']";
		public static readonly string DYNAMIC_DROPDOWN_LIST_BY_NAME = "//select[@name='{0}']";
		public static readonly string DYNAMIC_BUTTON_BY_TEXT = "//button[text()='{0}']";
	}
}

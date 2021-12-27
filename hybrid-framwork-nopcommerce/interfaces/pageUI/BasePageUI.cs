using System;
using System.Collections.Generic;
using System.Text;

namespace hybrid_framwork_nopcommerce.interfaces.pageUI
{
    public class BasePageUI
    {
		/** Header */
		public static readonly String REGISTER_LINK = "//div[@class='header-links']//a[text()='Register']";
		public static readonly String USER_LOGOUT_LINK = "//div[@class='header-links']//a[text()='Log out']";
		public static readonly String ADMIN_LOGOUT_LINK = "//li[@class='nav-item']//a[text()='Logout']";
		public static readonly String LOGIN_LINK = "//div[@class='header-links']//a[text()='Log in']";
		public static readonly String MY_ACCOUNT_LINK = "//div[@class='header-links']//a[text()='My account']";

		public static readonly String DYNAMIC_ITEM_IN_MY_ACCOUNT = "//ul[@class='list']//a[text()='{0}']";
		public static readonly String DYNAMIC_PAGE_FOOTER = "//div[@class='footer']//a[text()='{0}'";
    }
}

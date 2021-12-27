using System;
using System.Collections.Generic;
using System.Text;

namespace hybrid_framwork_nopcommerce.interfaces.pageUI.nopcommerce.admin
{
    public class AdminLoginPageUI
    {
        public static readonly string EMAIL_TEXTBOX = "//input[@id='Email']";
        public static readonly string PASSWORD_TEXTBOX = "//input[@id='Password']";
        public static readonly string LOGIN_BUTTON = "//button[text()='Log in']";
        public static readonly string EMAIL_ERROR = "//span[@id='Email-error']";
        public static readonly string VALIDATION_ERROR = "//div[contains(@class,'validation-summary-errors')]";
    }
}

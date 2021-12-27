using System;
using System.Collections.Generic;
using System.Text;

namespace hybrid_framwork_nopcommerce.interfaces.pageUI
{
    public class UserRegisterPageUI
    {
		public static readonly String MALE_RADIO_BUTTON ="//input[@id='gender-male']";
		public static readonly String FEMALE_RADIO_BUTTON = "//input[@id='gender-female']";
		public static readonly String FIRST_NAME_TEXTBOX = "//input[@id='FirstName']";
		public static readonly String LAST_NAME_TEXTBOX = "//input[@id='LastName']";
		public static readonly String DAY_DROPDOWN = "//select[@name='DateOfBirthDay']";
		public static readonly String MONTH_DROPDOWN = "//select[@name='DateOfBirthMonth']";
		public static readonly String YEAR_DROPDOWN = "//select[@name='DateOfBirthYear']";
		public static readonly String EMAIL_TEXTBOX = "//input[@id='Email']";
		public static readonly String COMPANY_TEXTBOX = "//input[@id='Company']";
		public static readonly String NEWSLETTER_CHECKBOX = "//input[@id='Newsletter']";
		public static readonly String PASSWORD_TEXTBOX = "//input[@id='Password']";
		public static readonly String CONFIRM_PASSWORD_TEXTBOX = "//input[@id='ConfirmPassword']";
		public static readonly String REGISTER_BUTTON = "//button[@id='register-button']";
		public static readonly String FIRST_NAME_ERROR_MESSAGE ="//span[@id='FirstName-error']";
		public static readonly String LAST_NAME_ERROR_MESSAGE ="//span[@id='LastName-error']";
		public static readonly String EMAIL_ERROR_MESSAGE ="//span[@id='Email-error']";
		public static readonly String PASSWORD_ERROR_MESSAGE ="//span[@id='Password-error']";
		public static readonly String CONFIRM_PASSWORD_ERROR_MESSAGE ="//span[@id='ConfirmPassword-error']";
		public static readonly String SUCCESS_MESSAGE ="//*[@class='result']";
		public static readonly String EXISTING_EMAIL_ERROR_MESSAGE ="//div[contains(@class,'validation-summary-errors')]//li";
		public static readonly String LOGOUT_LINK = "//a[text()='Log out']"; 
    }
}

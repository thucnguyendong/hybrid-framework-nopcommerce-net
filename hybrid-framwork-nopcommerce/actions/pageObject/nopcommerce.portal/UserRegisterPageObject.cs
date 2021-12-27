using hybrid_framwork_nopcommerce.interfaces.pageUI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace hybrid_framwork_nopcommerce.actions.pageObject
{
    public class UserRegisterPageObject:commons.BasePage
    {
		private IWebDriver driver;

        public UserRegisterPageObject(IWebDriver driver)
		{
			this.driver = driver;
		}

		public void SelectMaleGender()
		{
			WaitForElementClickable(driver, UserRegisterPageUI.MALE_RADIO_BUTTON);
			ClickElement(driver, UserRegisterPageUI.MALE_RADIO_BUTTON);
		}

		public void SelectFemaleGender()
		{
			WaitForElementClickable(driver, UserRegisterPageUI.FEMALE_RADIO_BUTTON);
			ClickElement(driver, UserRegisterPageUI.FEMALE_RADIO_BUTTON);
		}

		public void InputFirstName(String firstName)
		{
			WaitForElementVisible(driver, UserRegisterPageUI.FIRST_NAME_TEXTBOX);
			InputIntoElement(driver, UserRegisterPageUI.FIRST_NAME_TEXTBOX, firstName);
		}

		public void InputLastName(String lastName)
		{
			WaitForElementVisible(driver, UserRegisterPageUI.LAST_NAME_TEXTBOX);
			InputIntoElement(driver, UserRegisterPageUI.LAST_NAME_TEXTBOX, lastName);
		}

		public void SelectDay(String day)
		{
			WaitForElementVisible(driver, UserRegisterPageUI.DAY_DROPDOWN);
			SelectItemInDefaultDropdown(driver, UserRegisterPageUI.DAY_DROPDOWN, day);
		}

		public void SelectMonth(String month)
		{
			WaitForElementVisible(driver, UserRegisterPageUI.MONTH_DROPDOWN);
			SelectItemInDefaultDropdown(driver, UserRegisterPageUI.MONTH_DROPDOWN, month);
		}

		public void SelectYear(String year)
		{
			WaitForElementVisible(driver, UserRegisterPageUI.YEAR_DROPDOWN);
			SelectItemInDefaultDropdown(driver, UserRegisterPageUI.YEAR_DROPDOWN, year);
		}

		public void InputEmail(String email)
		{
			WaitForElementVisible(driver, UserRegisterPageUI.EMAIL_TEXTBOX);
			InputIntoElement(driver, UserRegisterPageUI.EMAIL_TEXTBOX, email);
		}

		public void InputCompany(String company)
		{
			WaitForElementVisible(driver, UserRegisterPageUI.COMPANY_TEXTBOX);
			InputIntoElement(driver, UserRegisterPageUI.COMPANY_TEXTBOX, company);
		}

		public void SelectNewsletter()
		{
			WaitForElementClickable(driver, UserRegisterPageUI.NEWSLETTER_CHECKBOX);
			CheckToDefaultCheckboxRadio(driver, UserRegisterPageUI.NEWSLETTER_CHECKBOX);
		}

		public void UnselectNewsletter()
		{
			WaitForElementClickable(driver, UserRegisterPageUI.NEWSLETTER_CHECKBOX);
			UncheckToDefaultCheckboxRadio(driver, UserRegisterPageUI.NEWSLETTER_CHECKBOX);
		}

		public void InputPassword(String password)
		{
			WaitForElementVisible(driver, UserRegisterPageUI.PASSWORD_TEXTBOX);
			InputIntoElement(driver, UserRegisterPageUI.PASSWORD_TEXTBOX, password);
		}

		public void InputConfirmPassword(String password)
		{
			WaitForElementVisible(driver, UserRegisterPageUI.CONFIRM_PASSWORD_TEXTBOX);
			InputIntoElement(driver, UserRegisterPageUI.CONFIRM_PASSWORD_TEXTBOX, password);
		}

		public UserHomePageObject ClickRegisterButton()
		{
			WaitForElementVisible(driver, UserRegisterPageUI.REGISTER_BUTTON);
			ClickElement(driver, UserRegisterPageUI.REGISTER_BUTTON);
			return PageGenerator.GetUserHomePage(driver);
		}

		public String GetFirstNameErrorMessage()
		{
			WaitForElementVisible(driver, UserRegisterPageUI.FIRST_NAME_ERROR_MESSAGE);
			return GetElementText(driver, UserRegisterPageUI.FIRST_NAME_ERROR_MESSAGE);
		}


		public String GetLastNameErrorMessage()
		{
			WaitForElementVisible(driver, UserRegisterPageUI.LAST_NAME_ERROR_MESSAGE);
			return GetElementText(driver, UserRegisterPageUI.LAST_NAME_ERROR_MESSAGE);
		}

		public String GetEmailErrorMessage()
		{
			WaitForElementVisible(driver, UserRegisterPageUI.EMAIL_ERROR_MESSAGE);
			return GetElementText(driver, UserRegisterPageUI.EMAIL_ERROR_MESSAGE);
		}

		public String GetPasswordErrorMessage()
		{
			WaitForElementVisible(driver, UserRegisterPageUI.PASSWORD_ERROR_MESSAGE);
			return GetElementText(driver, UserRegisterPageUI.PASSWORD_ERROR_MESSAGE);
		}

		public String GetConfirmPasswordErrorMessage()
		{
			WaitForElementVisible(driver, UserRegisterPageUI.CONFIRM_PASSWORD_ERROR_MESSAGE);
			return GetElementText(driver, UserRegisterPageUI.CONFIRM_PASSWORD_ERROR_MESSAGE);
		}

		public String GetExistingEmailErrorMessage()
		{
			WaitForElementVisible(driver, UserRegisterPageUI.EXISTING_EMAIL_ERROR_MESSAGE);
			return GetElementAttribute(driver, UserRegisterPageUI.EXISTING_EMAIL_ERROR_MESSAGE, "textContent");
		}

		public String GetSuccessMessage()
		{
			WaitForElementVisible(driver, UserRegisterPageUI.SUCCESS_MESSAGE);
			return GetElementText(driver, UserRegisterPageUI.SUCCESS_MESSAGE);
		}

		public UserHomePageObject ClickLogOutLink()
		{
			WaitForElementClickable(driver, UserRegisterPageUI.LOGOUT_LINK);
			ClickElement(driver, UserRegisterPageUI.LOGOUT_LINK);
			return PageGenerator.GetUserHomePage(driver);
		}

	}
}

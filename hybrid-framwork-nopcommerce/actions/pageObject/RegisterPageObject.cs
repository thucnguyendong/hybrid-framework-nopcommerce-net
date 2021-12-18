using hybrid_framwork_nopcommerce.interfaces.pageUI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace hybrid_framwork_nopcommerce.actions.pageObject
{
    public class RegisterPageObject:commons.BasePage
    {
		private IWebDriver driver;

        public RegisterPageObject(IWebDriver driver)
		{
			this.driver = driver;
		}

		public void SelectMaleGender()
		{
			WaitForElementClickable(driver, RegisterPageUI.MALE_RADIO_BUTTON);
			ClickElement(driver, RegisterPageUI.MALE_RADIO_BUTTON);
		}

		public void SelectFemaleGender()
		{
			WaitForElementClickable(driver, RegisterPageUI.FEMALE_RADIO_BUTTON);
			ClickElement(driver, RegisterPageUI.FEMALE_RADIO_BUTTON);
		}

		public void InputFirstName(String firstName)
		{
			WaitForElementVisible(driver, RegisterPageUI.FIRST_NAME_TEXTBOX);
			InputIntoElement(driver, RegisterPageUI.FIRST_NAME_TEXTBOX, firstName);
		}

		public void InputLastName(String lastName)
		{
			WaitForElementVisible(driver, RegisterPageUI.LAST_NAME_TEXTBOX);
			InputIntoElement(driver, RegisterPageUI.LAST_NAME_TEXTBOX, lastName);
		}

		public void SelectDay(String day)
		{
			WaitForElementVisible(driver, RegisterPageUI.DAY_DROPDOWN);
			SelectItemInDefaultDropdown(driver, RegisterPageUI.DAY_DROPDOWN, day);
		}

		public void SelectMonth(String month)
		{
			WaitForElementVisible(driver, RegisterPageUI.MONTH_DROPDOWN);
			SelectItemInDefaultDropdown(driver, RegisterPageUI.MONTH_DROPDOWN, month);
		}

		public void SelectYear(String year)
		{
			WaitForElementVisible(driver, RegisterPageUI.YEAR_DROPDOWN);
			SelectItemInDefaultDropdown(driver, RegisterPageUI.YEAR_DROPDOWN, year);
		}

		public void InputEmail(String email)
		{
			WaitForElementVisible(driver, RegisterPageUI.EMAIL_TEXTBOX);
			InputIntoElement(driver, RegisterPageUI.EMAIL_TEXTBOX, email);
		}

		public void InputCompany(String company)
		{
			WaitForElementVisible(driver, RegisterPageUI.COMPANY_TEXTBOX);
			InputIntoElement(driver, RegisterPageUI.COMPANY_TEXTBOX, company);
		}

		public void SelectNewsletter()
		{
			WaitForElementClickable(driver, RegisterPageUI.NEWSLETTER_CHECKBOX);
			CheckToDefaultCheckboxRadio(driver, RegisterPageUI.NEWSLETTER_CHECKBOX);
		}

		public void UnselectNewsletter()
		{
			WaitForElementClickable(driver, RegisterPageUI.NEWSLETTER_CHECKBOX);
			UncheckToDefaultCheckboxRadio(driver, RegisterPageUI.NEWSLETTER_CHECKBOX);
		}

		public void InputPassword(String password)
		{
			WaitForElementVisible(driver, RegisterPageUI.PASSWORD_TEXTBOX);
			InputIntoElement(driver, RegisterPageUI.PASSWORD_TEXTBOX, password);
		}

		public void InputConfirmPassword(String password)
		{
			WaitForElementVisible(driver, RegisterPageUI.CONFIRM_PASSWORD_TEXTBOX);
			InputIntoElement(driver, RegisterPageUI.CONFIRM_PASSWORD_TEXTBOX, password);
		}

		public HomePageObject ClickRegisterButton()
		{
			WaitForElementVisible(driver, RegisterPageUI.REGISTER_BUTTON);
			ClickElement(driver, RegisterPageUI.REGISTER_BUTTON);
			return PageGenerator.GetHomePage(driver);
		}

		public String GetFirstNameErrorMessage()
		{
			WaitForElementVisible(driver, RegisterPageUI.FIRST_NAME_ERROR_MESSAGE);
			return GetElementText(driver, RegisterPageUI.FIRST_NAME_ERROR_MESSAGE);
		}


		public String GetLastNameErrorMessage()
		{
			WaitForElementVisible(driver, RegisterPageUI.LAST_NAME_ERROR_MESSAGE);
			return GetElementText(driver, RegisterPageUI.LAST_NAME_ERROR_MESSAGE);
		}

		public String GetEmailErrorMessage()
		{
			WaitForElementVisible(driver, RegisterPageUI.EMAIL_ERROR_MESSAGE);
			return GetElementText(driver, RegisterPageUI.EMAIL_ERROR_MESSAGE);
		}

		public String GetPasswordErrorMessage()
		{
			WaitForElementVisible(driver, RegisterPageUI.PASSWORD_ERROR_MESSAGE);
			return GetElementText(driver, RegisterPageUI.PASSWORD_ERROR_MESSAGE);
		}

		public String GetConfirmPasswordErrorMessage()
		{
			WaitForElementVisible(driver, RegisterPageUI.CONFIRM_PASSWORD_ERROR_MESSAGE);
			return GetElementText(driver, RegisterPageUI.CONFIRM_PASSWORD_ERROR_MESSAGE);
		}

		public String GetExistingEmailErrorMessage()
		{
			WaitForElementVisible(driver, RegisterPageUI.EXISTING_EMAIL_ERROR_MESSAGE);
			return GetElementAttribute(driver, RegisterPageUI.EXISTING_EMAIL_ERROR_MESSAGE, "textContent");
		}

		public String GetSuccessMessage()
		{
			WaitForElementVisible(driver, RegisterPageUI.SUCCESS_MESSAGE);
			return GetElementText(driver, RegisterPageUI.SUCCESS_MESSAGE);
		}

		public HomePageObject ClickLogOutLink()
		{
			WaitForElementClickable(driver, RegisterPageUI.LOGOUT_LINK);
			ClickElement(driver, RegisterPageUI.LOGOUT_LINK);
			return PageGenerator.GetHomePage(driver);
		}

	}
}

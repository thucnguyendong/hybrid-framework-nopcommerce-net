﻿using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace hybrid_framwork_nopcommerce.actions.commons
{
    public class BasePage
    {
        public void OpenBrowser(IWebDriver driver, String url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public String GetPageTitle(IWebDriver driver) 
        {
            return driver.Title;
        }

        public String GetPageURL(IWebDriver driver)
        {
            return driver.Url;
        }

        public String GetPageSource(IWebDriver driver)
        {
            return driver.PageSource;
        }

        public void BackToPage(IWebDriver driver)
        {
            driver.Navigate().Back();
        }

        public void ForwardToPage(IWebDriver driver)
        {
            driver.Navigate().Forward();
        }

        public void RefreshCurrentPage(IWebDriver driver)
        {
            driver.Navigate().Refresh();
        }

        public IAlert WaitForAlertPresence(IWebDriver driver)
        {
            WebDriverWait explicitWait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(30));
            return explicitWait.Until(ExpectedConditions.AlertIsPresent());
        }

        public void AcceptAlert(IWebDriver driver)
        {
            WaitForAlertPresence(driver).Accept();
        }

        public void CloseAlert(IWebDriver driver)
        {
            WaitForAlertPresence(driver).Dismiss();
        }

        public String GetAlertText(IWebDriver driver)
        {
            return WaitForAlertPresence(driver).Text;
        }

        public void SwitchToWindowNotHomeByID(IWebDriver driver, String homeID)
        {
            IReadOnlyCollection<String> allIDs = driver.WindowHandles;
            foreach (String id in allIDs)
            {
                if (!id.Equals(homeID))
                {
                    driver.SwitchTo().Window(id);
                    break;
                }
            }
        }

        public void SwitchToWindowByTitle(IWebDriver driver, String windowTitle)
        {
            IReadOnlyCollection<String> allIDs = driver.WindowHandles;
            foreach (String id in allIDs)
            {
                driver.SwitchTo().Window(id);
                if (driver.Title.Contains(windowTitle))
                {
                    break;
                }
            }
        }
        public void CloseAllWithoutParent(IWebDriver driver, String parentID)
        {
            IReadOnlyCollection<String> allIDs = driver.WindowHandles;
            foreach (String id in allIDs)
            {
                if (!id.Equals(parentID))
                {
                    driver.SwitchTo().Window(id);
                    driver.Close();
                }
                driver.SwitchTo().Window(parentID);
            }
        }

        public void InputToAlert(IWebDriver driver, String textValue)
        {
            WaitForAlertPresence(driver).SendKeys(textValue);
        }

        private By GetByXpath(String xpath)
        {
            return By.XPath(xpath);
        }

        private IWebElement GetElement(IWebDriver driver, String xpathLocator)
        {
            return driver.FindElement(GetByXpath(xpathLocator));
        }

        private IReadOnlyCollection<IWebElement> GetListElement(IWebDriver driver, String xpathLocator)
        {
            return driver.FindElements(GetByXpath(xpathLocator));
        }

        public void ClickElement(IWebDriver driver, String xpathLocator)
        {
            GetElement(driver, xpathLocator).Click();
        }

        public void InputIntoElement(IWebDriver driver, String xpathLocator, String input)
        {
            IWebElement element = GetElement(driver, xpathLocator);
            element.Clear();
            element.SendKeys(input);
        }

        public void WaitForAllElementsToBePresenced(IWebDriver driver, String xpathLocator)
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(GetByXpath(xpathLocator)));
        }

        public void WaitForElementInvisible(IWebDriver driver, String xpathLocator)
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(GetByXpath(xpathLocator)));
        }

        public void WaitForAllElementsVisible(IWebDriver driver, String xpathLocator)
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(GetByXpath(xpathLocator)));
        }
        public void WaitForElementVisible(IWebDriver driver, String xpathLocator)
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(GetByXpath(xpathLocator)));
        }

        public void WaitForElementClickable(IWebDriver driver, String xpathLocator)
        {
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(GetByXpath(xpathLocator)));
        }

        public void SelectItemInDefaultDropdown(IWebDriver driver, String xpathLocator, String input)
        {
            WaitForAllElementsToBePresenced(driver, xpathLocator + "/option");
            SelectElement selectDropdownList = new SelectElement(GetElement(driver, xpathLocator));
            selectDropdownList.SelectByText(input);
        }

        public String GetItemInDefaultDropdown(IWebDriver driver, String xpathLocator)
        {
            SelectElement selectDropdownList = new SelectElement(GetElement(driver,xpathLocator));
            return selectDropdownList.SelectedOption.Text;
        }

        public void SelectItemInCustomDropdown(IWebDriver driver, String parentLocator, String childLocator, String itemValue)
        {
            WebDriverWait explicitWait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(30));
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;

            GetElement(driver, parentLocator).Click();
            IReadOnlyCollection<IWebElement> allItems = explicitWait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(GetByXpath(childLocator)));

            foreach (IWebElement item in allItems)
            {
                if (item.Text.Equals(itemValue))
                {
                    if (!item.Displayed)
                    {
                        jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true)", item);
                        SleepInSecond(1);
                    }
                    item.Click();
                    break;
                }
            }
        }

        public String GetElementText(IWebDriver driver, String xpathLocator)
        {
            return GetElement(driver, xpathLocator).Text;
        }

        public String GetElementAttribute(IWebDriver driver, String xpathLocator, String attributeName)
        {
            return GetElement(driver, xpathLocator).GetAttribute(attributeName);
        }

        public String GetCssValue(IWebDriver driver, String xpathLocator, String cssValue)
        {
            return GetElement(driver, xpathLocator).GetCssValue(cssValue);
        }

        public int GetElementSize(IWebDriver driver, String xpathLocator)
        {
            return GetListElement(driver,xpathLocator).Count;
        }

        public Boolean IsElementEnabled(IWebDriver driver, String xpathLocator)
        {
            return GetElement(driver, xpathLocator).Enabled;
        }

        public Boolean IsElementDisplayed(IWebDriver driver, String xpathLocator)
        {
            return GetElement(driver, xpathLocator).Displayed;
        }

        public Boolean IsElementSelected(IWebDriver driver, String xpathLocator)
        {
            return GetElement(driver, xpathLocator).Selected;
        }

        public void UncheckToDefaultCheckboxRadio(IWebDriver driver, String xpathLocator)
        {
            IWebElement element = GetElement(driver, xpathLocator);
            if (element.Selected)
            {
                element.Click();
            }
        }

        public void CheckToDefaultCheckboxRadio(IWebDriver driver, String xpathLocator)
        {
            IWebElement element = GetElement(driver, xpathLocator);
            if (!element.Selected)
            {
                element.Click();
            }
        }

        public void SwitchToDefaultContent(IWebDriver driver)
        {
            driver.SwitchTo().DefaultContent();
        }

        public void SwitchToFrame(IWebDriver driver, String xpathLocator)
        {
            driver.SwitchTo().Frame(GetElement(driver, xpathLocator));
        }

        public void MoveToElement(IWebDriver driver, String xpathLocator)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(GetElement(driver, xpathLocator)).Perform();
        }

        public Object ExecuteForBrowser(IWebDriver driver, String javaScript)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            return jsExecutor.ExecuteScript(javaScript);
        }

        public String GetInnerText(IWebDriver driver)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            return (String)jsExecutor.ExecuteScript("return document.documentElement.innerText;");
        }

        public Boolean AreExpectedTextInInnerText(IWebDriver driver, String textExpected)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            String textActual = (String)jsExecutor.ExecuteScript("return document.documentElement.innerText.match('" + textExpected + "')[0]");
            return textActual.Equals(textExpected);
        }

        public void ScrollToBottomPage(IWebDriver driver)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("window.scrollBy(0,document.body.scrollHeight)");
        }

        public void NavigateToUrlByJS(IWebDriver driver, String url)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("window.location = '" + url + "'");
        }

        public void HighlightElement(IWebDriver driver, String xpathLocator)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            IWebElement element = GetElement(driver, xpathLocator);
            String originalStyle = element.GetAttribute("style");
            jsExecutor.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2])", element, "style", "border: 2px solid red; border-style: dashed;");
            SleepInSecond(1);
            jsExecutor.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2])", element, "style", originalStyle);
        }

        public void ClickToElementByJS(IWebDriver driver, String xpathLocator)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("arguments[0].click();", GetElement(driver, xpathLocator));
        }

        public void ScrollToElement(IWebDriver driver, String xpathLocator)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("arguments[0].scrollIntoView(true);", GetElement(driver, xpathLocator));
        }

        public void SendkeyToElementByJS(IWebDriver driver, String xpathLocator, String value)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("arguments[0].setAttribute('value', '" + value + "')", GetElement(driver, xpathLocator));
        }

        public void RemoveAttributeInDOM(IWebDriver driver, String xpathLocator, String attributeRemove)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("arguments[0].removeAttribute('" + attributeRemove + "');", GetElement(driver, xpathLocator));
        }

        public String GetElementValidationMessage(IWebDriver driver, String xpathLocator)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            return (String)jsExecutor.ExecuteScript("return arguments[0].validationMessage;", GetElement(driver, xpathLocator));
        }

        public Boolean IsImageLoaded(IWebDriver driver, String xpathLocator)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            Boolean status = (Boolean)jsExecutor.ExecuteScript("return arguments[0].complete && typeof arguments[0].naturalWidth != \"undefined\" && arguments[0].naturalWidth > 0", GetElement(driver, xpathLocator));
            if (status)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [Obsolete]
        public bool IsJQueryAndPageLoadedSuccessfully(IWebDriver driver)
        {
            WebDriverWait explicitWait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(10));
            IJavaScriptExecutor script = (IJavaScriptExecutor)driver;
            bool jQueryLoad = explicitWait.Until<bool>(driver =>
            {
                return (long)script.ExecuteScript("return jQuery.active") == 0;
            });
            bool jsLoad = explicitWait.Until<bool>(driver =>
            {
                return script.ExecuteScript("return document.readyState").Equals("complete");
            });
            return jQueryLoad && jsLoad;
        }

        [Obsolete]
        public bool IsJQueryLoadedSuccessfully(IWebDriver driver)
        {
            WebDriverWait explicitWait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(10));
            IJavaScriptExecutor script = (IJavaScriptExecutor)driver;
            return explicitWait.Until<bool>(driver =>
            {
                return (Boolean)script.ExecuteScript("return (jQuery.active === 0) && (window.jQuery != null)");
            });
        }

        public int getRandomNumber()
        {
            Random rand = new Random();
            return rand.Next(999);
        }

        public void SleepInSecond(int timeoutInSecond)
        {
            try
            {
                Thread.Sleep(timeoutInSecond * 1000);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}

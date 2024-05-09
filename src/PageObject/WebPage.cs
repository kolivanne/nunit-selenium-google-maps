using System;
using GoogleMapsSeleniumCSharp.src.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace GoogleMapsSeleniumCSharp.src.PageObject
{
    /// <summary>
    /// Base class for all page objects
    /// </summary>
    public abstract class WebPage
    {
        private const int waitForElementTimeout = 30;

        public WebPage(IWebDriver driver)
        {
            Driver = driver;
            WebDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(waitForElementTimeout));
        }

        protected IWebDriver Driver { get; set; }
        protected WebDriverWait WebDriverWait { get; set; }

        /// <summary>
        /// Navigates and opens Url
        /// </summary>
        public void GoTo()
        {
            string languageCode = $"/?hl={ProjectConstants.ForcedLanguageCode}";
            string googleMapsUrl = ProjectConstants.GoogleMapsBaseUrl + languageCode;
            Driver.Navigate().GoToUrl(googleMapsUrl);
            WaitForPageToLoad();
        }

        /// <summary>
        /// Can be overridden by derivating classes
        /// Intended to make sure the page waits for a specific element
        /// </summary>
        protected virtual void WaitForPageToLoad()
        {

        }

        protected IWebElement WaitAndFindElement(By locator)
        {
            return WebDriverWait.Until(ExpectedConditions.ElementExists(locator));
        }

    }
}

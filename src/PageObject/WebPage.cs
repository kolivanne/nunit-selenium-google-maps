using System;
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
        private const int WAIT_FOR_ELEMENT_TIMEOUT = 30;
        protected const string GOOGLE_MAPS_URL = "https://www.google.com/maps";


        public WebPage(IWebDriver driver)
        {
            Driver = driver;
            WebDriverWait = new WebDriverWait(Driver, TimeSpan.FromSeconds(WAIT_FOR_ELEMENT_TIMEOUT));
        }

        protected IWebDriver Driver { get; set; }
        protected WebDriverWait WebDriverWait { get; set; }

        /// <summary>
        /// Navigates and opens Url
        /// </summary>
        public void GoTo()
        {
            Driver.Navigate().GoToUrl(GOOGLE_MAPS_URL);
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

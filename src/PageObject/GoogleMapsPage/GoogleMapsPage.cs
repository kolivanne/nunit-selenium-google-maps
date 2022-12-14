using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace GoogleMapsSeleniumCSharp.src.PageObject.GoogleMapsPage
{
    /// <summary>
    /// Google maps page actions
    /// </summary>
    public partial class GoogleMapsPage : WebPage
    {
        public GoogleMapsPage(IWebDriver driver) : base(driver)
        {

        }

        /// <summary>
        /// Clicks the direction button from the omnibox
        /// </summary>
        public void ClickOmniboxDirectionButton()
        {
            OmniboxRouteButton.Click();
        }

        /// <summary>
        /// Clears searchbox input and confirms search
        /// </summary>
        public void ClickSearchButtonWithEmptyInput()
        {
            OmniboxInputSearch.Clear();
            OmniboxSearchBoxButton.Click();
        }

        /// <summary>
        /// Enter destination
        /// </summary>
        /// <param name="destination">destination</param>
        public void SearchAddressWithMagnifierGlassButton(string destination)
        {
            EnterSearchInSearchbox(destination);
            OmniboxSearchBoxButton.Click();
        }
       
        /// <summary>
        /// Click menu option to switch to directions inputs
        /// </summary>
        public void ClickOmniboxDirectionsMenu()
        {
            OmniboxRouteButton.Click();
        }
        /// <summary>
        /// Searches an address or location by confirming with keybord "ENTER"
        /// </summary>
        /// <param name="destination">target location</param>
        public void SearchAddressWithEnterKey(string destination)
        {
            EnterSearchInSearchbox(destination);
            OmniboxInputSearch.SendKeys(Keys.Enter);
        }

        /// <summary>
        /// Enters search address
        /// </summary>
        /// <param name="searchAddress">target location</param>
        public void EnterSearchInSearchbox(string searchAddress)
        {
            OmniboxInputSearch.Clear();
            OmniboxInputSearch.SendKeys(searchAddress);
        }

        /// <summary>
        /// We wait for the searchbox
        /// </summary>
        protected override void WaitForPageToLoad()
        {
            WebDriverWait.Until(ExpectedConditions.ElementExists((By)OmniboxInputSearch));
        }
    }
}

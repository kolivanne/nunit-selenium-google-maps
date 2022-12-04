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
            WebDriverWait.Until(ExpectedConditions.ElementToBeClickable(InputDirectionInputStart));
        }

        /// <summary>
        /// Enter start and destination into the search
        /// </summary>
        public void FillStartAndDestination(string start, string destination)
        {
            FillStart(start);
            InputDirectionInputDestination.Clear();
            InputDirectionInputDestination.SendKeys(destination);
        }

        /// <summary>
        /// Fill start location
        /// </summary>
        public void FillStart(string startLocation)
        {
            InputDirectionInputStart.Clear();
            InputDirectionInputStart.SendKeys(startLocation);
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
            WebDriverWait.Until(ExpectedConditions.ElementToBeClickable(DirectionsButton));
        }
        /// <summary>
        /// Click direction button
        /// </summary>
        /// <param name="destination">destination</param>
        public void ClickDirectionButton()
        {
            DirectionsButton.Click();
            WebDriverWait.Until(ExpectedConditions.ElementToBeClickable(InputDirectionInputStart));
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
            WebDriverWait.Until(ExpectedConditions.ElementToBeClickable(DirectionsButton));
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

using OpenQA.Selenium;

namespace GoogleMapsSeleniumCSharp.src.PageObject.DirectionsPage
{
    /// <summary>
    /// Action with web elements
    /// </summary>
    public partial class DirectionsPage : WebPage
    {
        public DirectionsPage(IWebDriver driver) : base(driver)
        {
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
    }
}

using OpenQA.Selenium;

namespace GoogleMapsSeleniumCSharp.src.PageObject.SearchDetailsPage
{
    /// <summary>
    /// Web elements repository: travel results
    /// </summary>
    public partial class TravelResultPage
    {
        public IWebElement TravelResultBestMode => WaitAndFindElement(By.Id("section-directions-trip-0"));
        public IWebElement MapsCannotCreateTravelRoute => WaitAndFindElement(By.XPath("//div[@aria-live='assertive']//jsl"));
        public IWebElement RecommendGoogleSearchForUnknownLocation => WaitAndFindElement(By.XPath("//a[contains(@href, 'search?q=')]"));
    }
}

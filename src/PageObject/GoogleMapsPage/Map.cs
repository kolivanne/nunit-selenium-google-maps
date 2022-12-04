using OpenQA.Selenium;

namespace GoogleMapsSeleniumCSharp.src.PageObject.GoogleMapsPage
{
    /// <summary>
    /// Contains elements for google maps page
    /// </summary>
    public partial class GoogleMapsPage
    {
        public IWebElement Footer => WaitAndFindElement(By.ClassName("scene-footer"));
        public IWebElement OmniboxInputSearch => WaitAndFindElement(By.Id("searchboxinput"));
        public IWebElement OmniboxSearchBoxButton => WaitAndFindElement(By.Id("searchbox-searchbutton"));

        public IWebElement OmniboxRouteButton => WaitAndFindElement(By.XPath("//div[@id='omnibox']//button[starts-with(@jsaction, 'omnibox.show')]"));
        public IWebElement InputDirectionInputStart => WaitAndFindElement(By.XPath("//div[@id='directions-searchbox-0']//input[@class='tactile-searchbox-input']"));
        public IWebElement InputDirectionInputDestination => WaitAndFindElement(By.XPath("//div[@id='directions-searchbox-1']//input[@class='tactile-searchbox-input']"));
        public IWebElement DirectionsButton => WaitAndFindElement(By.XPath("//button[@class='g88MCb S9kvJb']"));

        public IWebElement TravelResultBestMode => WaitAndFindElement(By.Id("section-directions-trip-0"));
        public IWebElement MapsCannotCreateTravelRoute => WaitAndFindElement(By.XPath("//div[@aria-live='assertive']//jsl"));
        public IWebElement TravelTitleHeader => WaitAndFindElement(By.XPath("//h1[contains(@class,'fontHeadlineLarge')]/span[1]"));
        public IWebElement AddMissingPlace => WaitAndFindElement(By.XPath("//span[contains(text(),'Google Maps')]"));
        public IWebElement FullAddress => WaitAndFindElement(By.XPath("//button[@data-item-id='address']"));
        public IWebElement RecommendGoogleSearchForUnknownLoaction => WaitAndFindElement(By.XPath("//a[contains(@href, 'search?q=')]"));



    }
}

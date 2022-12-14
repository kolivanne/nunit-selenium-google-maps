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

    }
}

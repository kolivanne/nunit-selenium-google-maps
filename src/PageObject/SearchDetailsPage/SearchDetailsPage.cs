using OpenQA.Selenium;

namespace GoogleMapsSeleniumCSharp.src.PageObject.SearchDetailsPage
{
    /// <summary>
    /// Details page of the searched location, i.e. actions, photos, reviews,..
    /// </summary>
    public partial class SearchDetailsPage : WebPage
    {
        public SearchDetailsPage(IWebDriver driver) : base(driver)
        {
        }
        /// <summary>
        /// Click direction button
        /// </summary>
        public void ClickDirectionButton()
        {
            DirectionsButton.Click();
        }
    }
}

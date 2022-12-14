namespace GoogleMapsSeleniumCSharp.src.PageObject.GoogleMapsPage
{
    /// <summary>
    /// Assertions for google maps page
    /// </summary>
    public partial class GoogleMapsPage
    {
        /// <summary>
        /// Test the input field for the search is available
        /// </summary>
        public void AssertGoogleMapsSearchBoxIsAvailable()
        {
            Assert.That(OmniboxInputSearch.Displayed, Is.True);
        }

        /// <summary>
        /// Test the url is correctly displayed
        /// </summary>
        /// <param name="currentUrl">Current browser url</param>
        public void AssertMapsUrlIsCorrect(string currentUrl)
        {
            Assert.That(currentUrl, Is.EqualTo(GOOGLE_MAPS_URL));
        }

        /// <summary>
        /// Test the footer is enabled
        /// </summary>
        public void AssertFooterIsShown()
        {
            Assert.That(Footer.Enabled, Is.True);
        }

        /// <summary>
        /// Test the input field is empty
        /// </summary>
        public void AssertEmptyInputStaysEmptyAfterClickingSearch()
        {
            Assert.That(OmniboxInputSearch.Text, Is.Empty);
        }
        
    }
}

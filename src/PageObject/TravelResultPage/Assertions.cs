namespace GoogleMapsSeleniumCSharp.src.PageObject.SearchDetailsPage
{
    /// <summary>
    /// Assertions for travel results page
    /// </summary>
    public partial class TravelResultPage
    {
        /// <summary>
        /// Test best travel is displayed
        /// </summary>
        public void AssertDisplayBestTravelModeResult()
        {
            Assert.That(TravelResultBestMode.Displayed, Is.True);
        }
        /// <summary>
        /// Test info text is shown when search is not successful
        /// </summary>
        public void AssertInfoTextWhenNoRouteIsAvailable()
        {
            Assert.That(MapsCannotCreateTravelRoute.Displayed, Is.True);
        }

        /// <summary>
        /// Test that no travel results are available
        /// </summary>
        public void AssertNoTravelDetailsAreDisplayed()
        {
            Assert.That(RecommendGoogleSearchForUnknownLocation.Displayed, Is.True);
        }
    }
}

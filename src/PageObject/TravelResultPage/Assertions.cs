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
            Assert.That(TravelResultBestMode.Displayed, Is.True, "Best travel is available to inform the user.");
        }
        /// <summary>
        /// Test info text is shown when search is not successful
        /// </summary>
        public void AssertInfoTextWhenNoRouteIsAvailable()
        {
            Assert.That(MapsCannotCreateTravelRoute.Displayed, Is.True, "Info text is available to inform the user.");
        }

        /// <summary>
        /// Test that no travel results are available
        /// </summary>
        public void AssertNoTravelDetailsAreDisplayed()
        {
            Assert.That(RecommendGoogleSearchForUnknownLocation.Displayed, Is.True, "Unknown location info text is available to inform the user.");
        }
    }
}

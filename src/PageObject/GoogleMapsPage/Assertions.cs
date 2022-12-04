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
        /// Test the direction button is displayed
        /// </summary>
        public void AssertDirectionButtonIsDisplayed()
        {
            Assert.That(DirectionsButton.Displayed, Is.True);
        }
        /// <summary>
        /// Test that both inputs are available
        /// </summary>
        public void AssertInputDirectionsAreDisplayed()
        {
            bool isStartInputDisplayed = InputDirectionInputStart.Displayed;
            bool isDestinationInputDisplayed = InputDirectionInputDestination.Displayed;

            Assert.That(isStartInputDisplayed && isDestinationInputDisplayed, Is.True);
        }
        /// <summary>
        /// Test the input field is empty
        /// </summary>
        public void AssertEmptyInputStaysEmptyAfterClickingSearch()
        {
            Assert.That(OmniboxInputSearch.Text, Is.Empty);
        }
        /// <summary>
        /// Test the direction button is displayed after searching an address
        /// </summary>
        public void AssertDirectionButtonIsDisplayedAfterSearch()
        {
            Assert.That(DirectionsButton.Displayed, Is.True);
        }
        /// <summary>
        /// Test the user input is correctly displayed in the search
        /// </summary>
        /// <param name="expected">cCorrect input</param>
        public void AssertDestinationInputIsCorrect(string expected)
        {
            string actual = InputDirectionInputDestination.GetAttribute("aria-label");          
            Assert.That(actual, Does.Contain(expected));
        }
        /// Test the user input is correctly displayed in the search
        /// </summary>
        /// <param name="expected">cCorrect input</param>
        public void AssertStartInputIsCorrect(string expected)
        {
            string actualStart = InputDirectionInputStart.GetAttribute("aria-label");
            Assert.That(actualStart, Does.Contain(expected));
        }
        /// <summary>
        /// Test best travel is displayed
        /// </summary>
        public void AssertDisplayBestTravelModeResult()
        {
            Assert.That(TravelResultBestMode.Displayed, Is.True);
        }
        /// <summary>
        /// Test that no travel results are available
        /// </summary>
        public void AssertNoTravelDetailsAreDisplayed()
        {
          Assert.That(RecommendGoogleSearchForUnknownLoaction.Displayed, Is.True);
        }
        /// <summary>
        /// Test info text is shown when search is not successful
        /// </summary>
        public void AssertInfoTextWhenNoRouteIsAvailable()
        {
            Assert.That(MapsCannotCreateTravelRoute.Displayed, Is.True);
        }
        /// <summary>
        /// Test a valid search shows a headline
        /// </summary>
        /// <param name="expected">Headline text</param>
        public void AssertValidAddressDisplaysHeadLine(string expected)
        {
            Assert.That(TravelTitleHeader.Text, Is.EqualTo(expected));
        }
        /// <summary>
        /// Test "Add missing place" suggestion is shown
        /// </summary>
        public void AssertAddMissingPlaceOptionIsDisplayed()
        {
            Assert.That(AddMissingPlace.Displayed, Is.True);
        }

        /// <summary>
        /// Test the full address is shown
        /// </summary>
        /// <param name="expected">expected full address</param>
        public void AssertFullAddressIsDisplayed(string expected)
        {
            string actual = FullAddress.GetAttribute("aria-label");
            Assert.That(actual, Does.Contain(expected));
        }
    }
}

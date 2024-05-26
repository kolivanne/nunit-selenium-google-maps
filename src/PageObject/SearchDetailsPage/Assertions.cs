namespace GoogleMapsSeleniumCSharp.src.PageObject.SearchDetailsPage
{
    /// <summary>
    /// Assertions for SearchDetailsPage
    /// </summary>
    public partial class SearchDetailsPage
    {
        /// <summary>
        /// Test the direction button is displayed
        /// </summary>
        public void AssertDirectionButtonIsDisplayed()
        {
            Assert.That(DirectionsButton.Displayed, Is.True, "Directions button is available.");
        }
        /// <summary>
        /// Test the full address is shown
        /// </summary>
        /// <param name="expected">expected full address</param>
        public void AssertFullAddressIsDisplayed(string expected)
        {
            string actual = FullAddress.GetAttribute("aria-label");
            string cleanedAttribute = CleanAddressAttribute(actual);
            Assert.That(cleanedAttribute, Does.Contain(expected), "Detailed address is available.");
        }
        /// <summary>
        /// Test a valid search shows a headline
        /// </summary>
        /// <param name="expected">Headline text</param>
        public void AssertValidAddressDisplaysHeadLine(string expected)
        {
            Assert.That(TravelTitleHeader.Text, Is.EqualTo(expected), "Address headline is available.");
        }
        /// <summary>
        /// Test "Add missing place" suggestion is shown
        /// </summary>
        public void AssertAddMissingPlaceOptionIsDisplayed()
        {
            Assert.That(AddMissingPlace.Displayed, Is.True, "Missing place option is available.");
        }

        private string CleanAddressAttribute(string value)
        {
            int colonIndex = value.IndexOf(':');
            string extracted = value.Substring(colonIndex + 1).Trim();
            return extracted;
        }
    }
}

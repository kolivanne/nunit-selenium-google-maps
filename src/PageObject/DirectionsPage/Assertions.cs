﻿namespace GoogleMapsSeleniumCSharp.src.PageObject.DirectionsPage
{
    /// <summary>
    /// Assertions for directions page
    /// </summary>
    public partial class DirectionsPage
    {
        /// <summary>
        /// Test that both inputs are available
        /// </summary>
        public void AssertInputDirectionsAreDisplayed()
        {
            bool isStartInputDisplayed = InputDirectionInputStart.Displayed;
            bool isDestinationInputDisplayed = InputDirectionInputDestination.Displayed;

            Assert.That(isStartInputDisplayed && isDestinationInputDisplayed, Is.True, "Input directions are available.");
        }
        /// <summary>
        /// Test the user input is correctly displayed in the search
        /// </summary>
        /// <param name="expected">cCorrect input</param>
        public void AssertDestinationInputIsCorrect(string expected)
        {
            string actual = InputDirectionInputDestination.GetAttribute("aria-label");
            Assert.That(actual, Does.Contain(expected), "Entered destination matches input.");
        }
        /// Test the user input is correctly displayed in the search
        /// </summary>
        /// <param name="expected">cCorrect input</param>
        public void AssertStartInputIsCorrect(string expected)
        {
            string actualStart = InputDirectionInputStart.GetAttribute("aria-label");
            Assert.That(actualStart, Does.Contain(expected), "Entered start matches input.");
        }
    }
}

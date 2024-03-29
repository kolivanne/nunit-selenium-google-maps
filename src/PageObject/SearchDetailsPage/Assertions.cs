﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Assert.That(DirectionsButton.Displayed, Is.True);
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
    }
}

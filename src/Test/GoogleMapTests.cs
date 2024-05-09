using GoogleMapsSeleniumCSharp.src.Utils;
using OpenQA.Selenium;

namespace GoogleMapsSeleniumCSharp.src.Test
{

    [TestFixture(BrowserType.Chrome)]
    [TestFixture(BrowserType.Firefox)]
    // [Parallelizable(ParallelScope.Fixtures)] --> caused unstabale test runs, disabled for now
    public class GoogleMapTests : TestBase
    { 
        public GoogleMapTests(BrowserType type) : base(type) { }

        [Test, Category("Smoke")]
        public void GoogleMapsIsAvailable()
        {
            consentPage.AcceptConsent();
            mapsPage.AssertMapsUrlIsCorrect(Driver.Url);
            mapsPage.AssertGoogleMapsSearchBoxIsAvailable();
        }
        /// <summary>
        /// Simplified footer test without checking entries and links
        /// </summary>
        [Test, Category("Regression")]
        public void GoogleMapsHasFooter()
        {
            consentPage.AcceptConsent();
            mapsPage.AssertFooterIsShown();
        }

        [TestCaseSource(typeof(TestData.TestDataDE), nameof(TestData.TestDataDE.ValidAddressesDirectionSearch)), Category("Regression")]
        [Ignore("Ignored until test data fix")]
        public void ValidSearchViaOmniboxDirectionButtonShowsTravelDetails(string start, string destination)
        {
            consentPage.AcceptConsent();

            mapsPage.ClickOmniboxDirectionButton();

            directionsPage.FillStartAndDestination(start, destination);
            directionsPage.AssertStartInputIsCorrect(start);
            directionsPage.AssertDestinationInputIsCorrect(destination);
            directionsPage.InputDirectionInputDestination.SendKeys(Keys.Enter);

            travelResultPage.AssertDisplayBestTravelModeResult();
        }

        [TestCaseSource(typeof(TestData.TestDataDE), nameof(TestData.TestDataDE.ValidAddressesDirectionSearch)), Category("Regression")]
        [Ignore("Ignored until test data fix")]
        public void ValidSearchViaSearchboxShowsTravelDetails(string start, string destination)
        {
            consentPage.AcceptConsent();
            mapsPage.SearchAddressWithMagnifierGlassButton(destination);

            searchDetailsPage.AssertDirectionButtonIsDisplayed();
            searchDetailsPage.ClickDirectionButton();
            directionsPage.AssertDestinationInputIsCorrect(destination);
            directionsPage.FillStart(start);
            directionsPage.AssertStartInputIsCorrect(start);
            directionsPage.InputDirectionInputStart.SendKeys(Keys.Enter);

            travelResultPage.AssertDisplayBestTravelModeResult();
        }

        [TestCaseSource(typeof(TestData.TestDataDE), nameof(TestData.TestDataDE.ValidAddressesDirectionSearch)), Category("Regression")]
        [Ignore("Ignored until test data fix")]
        public void ValidSearchViaEnterKeyShowsTravelDetails(string start, string destination)
        {
            consentPage.AcceptConsent();
            mapsPage.SearchAddressWithEnterKey(destination);

            searchDetailsPage.AssertDirectionButtonIsDisplayed();
            searchDetailsPage.ClickDirectionButton();
            directionsPage.AssertDestinationInputIsCorrect(destination);
            directionsPage.FillStart(start);
            directionsPage.AssertStartInputIsCorrect(start);
            directionsPage.InputDirectionInputStart.SendKeys(Keys.Enter);

            travelResultPage.AssertDisplayBestTravelModeResult();
        }

        [TestCase("dhjdfhjgvhjfdg", "hjsdfhjgfsdvhstreet"), Category("Regression")]
        [Ignore("Ignored until test data fix")]
        public void InvalidSearchShowsNoTravelDetails(string start, string destination)
        {
            consentPage.AcceptConsent();

            mapsPage.ClickOmniboxDirectionButton();

            directionsPage.FillStartAndDestination(start, destination);
            directionsPage.AssertStartInputIsCorrect(start);
            directionsPage.AssertDestinationInputIsCorrect(destination);
            directionsPage.InputDirectionInputStart.SendKeys(Keys.Enter);

            travelResultPage.AssertNoTravelDetailsAreDisplayed();
        }

        [TestCase("Berlin", "Australia"), Category("Regression")]
        [Ignore("Ignored until test data fix")]
        public void MapsCannotComputeTravelRoute(string start, string destination)
        {
            consentPage.AcceptConsent();

            mapsPage.ClickOmniboxDirectionButton();

            directionsPage.FillStartAndDestination(start, destination);
            directionsPage.AssertStartInputIsCorrect(start);
            directionsPage.AssertDestinationInputIsCorrect(destination);
            directionsPage.InputDirectionInputStart.SendKeys(Keys.Enter);

            travelResultPage.AssertInfoTextWhenNoRouteIsAvailable();
        }

        [TestCaseSource(typeof(TestData.TestDataDE), nameof(TestData.TestDataDE.ValidAddresses)), Category("Regression")]
        [Ignore("Ignored until test data fix")]
        public void SearchedAddressDisplayedHeadline(string address, string headline)
        {
            consentPage.AcceptConsent();
            mapsPage.SearchAddressWithMagnifierGlassButton(address);
            searchDetailsPage.AssertValidAddressDisplaysHeadLine(headline);
        }

        [Test, Category("Regression")]
        public void SwitchToDirectionsInputSuccessfully()
        {
            consentPage.AcceptConsent();
            mapsPage.ClickOmniboxDirectionsMenu();
            directionsPage.AssertInputDirectionsAreDisplayed();
        }

        [Test, Category("Regression")]
        public void EmptySearchDoesNothing()
        {
            consentPage.AcceptConsent();

            mapsPage.ClickSearchButtonWithEmptyInput();
            mapsPage.AssertEmptyInputStaysEmptyAfterClickingSearch();
        }

        [TestCase("1234 Fake Street, Imaginary City"), Category("Regression")]
        [Ignore("Ignored until test data fix")]
        public void DisplayAddMissingPlaceOption(string invalidLocation)
        {
            consentPage.AcceptConsent();
            mapsPage.SearchAddressWithEnterKey(invalidLocation);
            searchDetailsPage.AssertAddMissingPlaceOptionIsDisplayed();
        }

        [TestCaseSource(typeof(TestData.TestDataDE), nameof(TestData.TestDataDE.Vacations)), Category("Regression")]
        [Ignore("Ignored until test data fix")]
        public void SuccessfulSearchShowsFullAddress(string address, string expected)
        {
            consentPage.AcceptConsent();
            mapsPage.SearchAddressWithMagnifierGlassButton(address);

            searchDetailsPage.AssertDirectionButtonIsDisplayed();
            searchDetailsPage.AssertFullAddressIsDisplayed(expected);
        }
    }
}
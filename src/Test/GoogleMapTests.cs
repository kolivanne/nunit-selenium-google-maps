using OpenQA.Selenium;
using GoogleMapsSeleniumCSharp.src.Utils;

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

        [TestCaseSource(typeof(TestData.TestDataENG), nameof(TestData.TestDataENG.ValidAddressesDirectionSearch)), Category("Regression")]
        public void ValidSearchViaOmniboxDirectionButtonShowsTravelDetails(string start, string destination)
        {
            consentPage.AcceptConsent();
            mapsPage.ClickOmniboxDirectionButton();
            mapsPage.FillStartAndDestination(start, destination);
            mapsPage.AssertStartInputIsCorrect(start);
            mapsPage.AssertDestinationInputIsCorrect(destination);
            mapsPage.InputDirectionInputDestination.SendKeys(Keys.Enter);
            mapsPage.AssertDisplayBestTravelModeResult();
        }

        [TestCaseSource(typeof(TestData.TestDataENG), nameof(TestData.TestDataENG.ValidAddressesDirectionSearch)), Category("Regression")]
        public void ValidSearchViaSearchboxShowsTravelDetails(string start, string destination)
        {
            consentPage.AcceptConsent();
            mapsPage.SearchAddressWithMagnifierGlassButton(destination);
            mapsPage.AssertDirectionButtonIsDisplayed();
            mapsPage.ClickDirectionButton();
            mapsPage.AssertDestinationInputIsCorrect(destination);
            mapsPage.FillStart(start);
            mapsPage.AssertStartInputIsCorrect(start);
            mapsPage.InputDirectionInputStart.SendKeys(Keys.Enter);
            mapsPage.AssertDisplayBestTravelModeResult();
        }

        [TestCaseSource(typeof(TestData.TestDataENG), nameof(TestData.TestDataENG.ValidAddressesDirectionSearch)), Category("Regression")]
        public void ValidSearchViaEnterKeyShowsTravelDetails(string start, string destination)
        {
            consentPage.AcceptConsent();
            mapsPage.SearchAddressWithEnterKey(destination);
            mapsPage.AssertDirectionButtonIsDisplayed();
            mapsPage.ClickDirectionButton();
            mapsPage.AssertDestinationInputIsCorrect(destination);
            mapsPage.FillStart(start);
            mapsPage.AssertStartInputIsCorrect(start);
            mapsPage.InputDirectionInputStart.SendKeys(Keys.Enter);
            mapsPage.AssertDisplayBestTravelModeResult();
        }

        [TestCase("dhjdfhjgvhjfdg", "hjsdfhjgfsdvhstreet"), Category("Regression")]
        public void InvalidSearchShowsNoTravelDetails(string start, string destination)
        {
            consentPage.AcceptConsent();
            mapsPage.ClickOmniboxDirectionButton();
            mapsPage.FillStartAndDestination(start, destination);
            mapsPage.AssertStartInputIsCorrect(start);
            mapsPage.AssertDestinationInputIsCorrect(destination);
            mapsPage.InputDirectionInputStart.SendKeys(Keys.Enter);
            mapsPage.AssertNoTravelDetailsAreDisplayed();
        }

        [TestCase("Berlin", "Australia"), Category("Regression")]
        public void MapsCannotComputeTravelRoute(string start, string destination)
        {
            consentPage.AcceptConsent();
            mapsPage.ClickOmniboxDirectionButton();
            mapsPage.FillStartAndDestination(start, destination);
            mapsPage.AssertStartInputIsCorrect(start);
            mapsPage.AssertDestinationInputIsCorrect(destination);
            mapsPage.InputDirectionInputStart.SendKeys(Keys.Enter);
            mapsPage.AssertInfoTextWhenNoRouteIsAvailable();
        }

        [TestCaseSource(typeof(TestData.TestDataENG), nameof(TestData.TestDataENG.ValidAddresses)), Category("Regression")]
        public void SearchedAddressDisplayedHeadline(string address, string headline)
        {
            consentPage.AcceptConsent();
            mapsPage.SearchAddressWithMagnifierGlassButton(address);
            mapsPage.AssertValidAddressDisplaysHeadLine(headline);
        }

        [Test, Category("Regression")]
        public void SwitchToDirectionsInputSuccessfully()
        {
            consentPage.AcceptConsent();
            mapsPage.ClickOmniboxDirectionsMenu();
            mapsPage.AssertInputDirectionsAreDisplayed();
        }

        [Test, Category("Regression")]
        public void EmptySearchDoesNothing()
        {
            consentPage.AcceptConsent();
            mapsPage.ClickSearchButtonWithEmptyInput();
            mapsPage.AssertEmptyInputStaysEmptyAfterClickingSearch();
        }

        [Test, Category("Regression")]
        public void DisplayAddMissingPlaceOption()
        {
            consentPage.AcceptConsent();
            mapsPage.EnterSearchInSearchbox("111111111111");
            mapsPage.AssertAddMissingPlaceOptionIsDisplayed();
        }

        [TestCaseSource(typeof(TestData.TestDataENG), nameof(TestData.TestDataENG.Vacations)), Category("Regression")]
        public void SuccessfulSearchShowsFullAddress(string address, string expected)
        {
            consentPage.AcceptConsent();
            mapsPage.SearchAddressWithMagnifierGlassButton(address);
            mapsPage.AssertDirectionButtonIsDisplayed();
            mapsPage.AssertFullAddressIsDisplayed(expected);
        }

      
    }
}
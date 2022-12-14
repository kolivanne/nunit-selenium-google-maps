using GoogleMapsSeleniumCSharp.src.PageObject.ConsentPage;
using GoogleMapsSeleniumCSharp.src.PageObject.DirectionsPage;
using GoogleMapsSeleniumCSharp.src.PageObject.GoogleMapsPage;
using GoogleMapsSeleniumCSharp.src.PageObject.SearchDetailsPage;
using GoogleMapsSeleniumCSharp.src.Utils;
using OpenQA.Selenium;

namespace GoogleMapsSeleniumCSharp.src.Test
{
    /// <summary>
    /// Base class for all tests
    /// Setup: reporting
    /// Setup: driver
    /// Cleanup after teardown and end of the test run
    /// </summary>
    public class TestBase
    {
        // <summary>
        /// Instances for extent reports
        /// </summary>
        private static AventStack.ExtentReports.ExtentReports extentReport;

        /// <summary>
        /// webdriver based on browser choice in TestFixture
        /// </summary>
        protected IWebDriver Driver { get; set; }
        protected BrowserType CurrentBrwoser { get; set; }
        /// <summary>
        /// browser of choice
        /// </summary>

        protected static GoogleConsentPage consentPage;
        protected static GoogleMapsPage mapsPage;
        protected static SearchDetailsPage searchDetailsPage;
        protected static DirectionsPage directionsPage;
        protected static TravelResultPage travelResultPage;

        public TestBase(BrowserType type)
        {
            CurrentBrwoser= type;
        }

       [OneTimeSetUp]
        public void CheckPathsAndSetUpReporter()
        {
            ExtentReportUtils.VerifyFireFoxExecutable();

            extentReport = new AventStack.ExtentReports.ExtentReports();
            var htmlReporter = ExtentReportUtils.SetUpHtmlReporter(CurrentBrwoser);

            extentReport.AttachReporter(htmlReporter);
            extentReport.AddSystemInfo("Host Name", "Google Maps Test Strategy Demo");
            extentReport.AddSystemInfo("Environment", "Wooga Test Device");
            extentReport.AddSystemInfo("Username", "June Parker");
        }

        [SetUp]
        public void Setup()
        {
            Driver = WebDriverInit.GetBrowserOptions(CurrentBrwoser, true);
            Driver.Manage().Window.Maximize();

            consentPage = new GoogleConsentPage(Driver);
            mapsPage = new GoogleMapsPage(Driver);
            searchDetailsPage = new SearchDetailsPage(Driver);
            directionsPage = new DirectionsPage(Driver);
            travelResultPage = new TravelResultPage(Driver);
        }

        /// <summary>
        /// Add test result to report
        /// Clean up driver session
        /// </summary>
        [TearDown]
        public void Teardown()
        {
            ExtentReportUtils.ReportTestResult(extentReport, Driver);

            Driver.Close();
            Driver.Quit();
        }

        [OneTimeTearDown]
        protected void StopExtentReport()
        {
            extentReport.Flush();
        }
    }
}

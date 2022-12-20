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
        protected BrowserType CurrentBrowser { get; set; }
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
            CurrentBrowser= type;
        }
        /// <summary>
        /// Verfies the paths are correct and sets up the extent report
        /// Will abort the test execution for Firefox if the path is not correct
        /// </summary>
       [OneTimeSetUp]
        public void CheckPathsAndSetUpReporter()
        {
            try
            {
                 FilePaths.VerifyFireFoxExecutable();
            }
            catch(Exception ex)
            {
                string message = "Abort test execution for Firefox: ";
                ExceptionLogger.LogException(message + ex.ToString());
                Assert.Fail();
            }

            extentReport = new AventStack.ExtentReports.ExtentReports();
            var htmlReporter = ExtentReportUtils.SetUpHtmlReporter(CurrentBrowser);

            extentReport.AttachReporter(htmlReporter);
            extentReport.AddSystemInfo("Host Name", "Google Maps Test Strategy Demo");
            extentReport.AddSystemInfo("Environment", "Wooga Test Device");
            extentReport.AddSystemInfo("Username", "June Parker");
        }

        [SetUp]
        public void Setup()
        {
            try 
            { 
                Driver = WebDriverInit.GetBrowserOptions(CurrentBrowser, true);
            }
            catch(Exception ex)
            {
                ExceptionLogger.LogException(ex.ToString());
            }
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
            try
            {
                ExtentReportUtils.ReportTestResult(extentReport, Driver);
                Driver.Close();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex.ToString());
            }
          
        }

        [OneTimeTearDown]
        protected void StopExtentReport()
        {
            try
            {
                Driver.Quit();
                extentReport.Flush();
            }
            catch(Exception ex)
            {
                ExceptionLogger.LogException(ex.ToString());
            }
        }
    }
}

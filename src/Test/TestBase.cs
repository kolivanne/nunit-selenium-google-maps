using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using GoogleMapsSeleniumCSharp.src.Utils;
using GoogleMapsSeleniumCSharp.src.PageObject.ConsentPage;
using GoogleMapsSeleniumCSharp.src.PageObject.GoogleMapsPage;
using GoogleMapsSeleniumCSharp.src.PageObject.SearchDetailsPage;
using GoogleMapsSeleniumCSharp.src.PageObject.DirectionsPage;

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
        private ExtentTest test;

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
        public void StartExtentReport()
        {
            string pth = System.Reflection.Assembly.GetCallingAssembly().Location;
            string actualPath = pth[..pth.LastIndexOf("bin")];

            string projectPath = new Uri(actualPath).LocalPath;

            //Append the html report file to current project path
            string reportFolderName = CurrentBrwoser.ToString() + ExtentReportUtils.GetUniqueTestRunName();
            string reportPath = projectPath + FilePaths.EXTENTREPORT_REPORT_FOLDER + reportFolderName;

            var htmlReporter = new ExtentHtmlReporter(reportPath);

            extentReport = new AventStack.ExtentReports.ExtentReports();
            extentReport.AttachReporter(htmlReporter);

            extentReport.AddSystemInfo("Host Name", "Google Maps Test Strategy Demo");
            extentReport.AddSystemInfo("Environment", "Wooga Test Device");
            extentReport.AddSystemInfo("Username", "June Parker");

            htmlReporter.LoadConfig(projectPath + FilePaths.EXTENTREPORT_CONFIG);
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
            string currentTestName = TestContext.CurrentContext.Test.Name;
            test = extentReport.CreateTest(currentTestName);

            var resultState = TestContext.CurrentContext.Result.Outcome.Status;
            var errorMessage = TestContext.CurrentContext.Result.Message;

            // it was "challenging" finding a solution to show a preview of the base64-img
            string infotext = "See snapshot by clicking 'base64-img' </br>";

            switch (resultState)
            {
                case TestStatus.Failed:
                    var mediaFailed = ExtentReportUtils.CaptureScreenShotAndReturnModel(Driver);
                    string details = resultState + errorMessage;
                    test.Log(Status.Fail, details + "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>");
                    test.Log(Status.Fail, infotext, mediaFailed);
                    break;
                case TestStatus.Passed:
                    test.Log(Status.Pass, "Test passed.");
                    break;
                case TestStatus.Skipped:
                    test.Log(Status.Pass, "Test skipped.");
                    break;
            }

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

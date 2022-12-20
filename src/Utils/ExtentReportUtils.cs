using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace GoogleMapsSeleniumCSharp.src.Utils
{
    /// <summary>
    /// Helper class to deal with report related tasks
    /// </summary>
    public class ExtentReportUtils
    {
        private const string CONFIG_FOLDER_NAME = "ExtentReportConfig";
        private const string CONFIG_FILE_NAME = "config.xml";

        /// <summary>
        /// Creates HTML report for extent reporter
        /// </summary>
        /// <param name="browser">Current browser</param>
        /// <returns>HTML reporter</returns>
        /// <exception cref="FileNotFoundException">HTML reporter</exception>
        public static ExtentHtmlReporter SetUpHtmlReporter(BrowserType browser)
        {
            string configPath = CONFIG_FOLDER_NAME + Path.DirectorySeparatorChar + CONFIG_FILE_NAME;

            string projectPath = FilePaths.GetProjectPath();
            string reportRootPath = projectPath + FilePaths.REPORT_ROOT_NAME;
            string pathToReportFile = GetUniqueTestRunName(browser.ToString());
            string reportPath = reportRootPath + Path.DirectorySeparatorChar + pathToReportFile;

            ExtentHtmlReporter htmlReporter = new(reportPath);

            if(!Directory.Exists(reportRootPath))
            {
                string message = "Unable to find 'Report' folder, invalid path: " + reportPath;
                throw new DirectoryNotFoundException(message);
            }

            string absoluteConfigPath = projectPath + configPath;
            if (!File.Exists(absoluteConfigPath))
            {
                string message = "Unable to find config.xml, invalid path: " + absoluteConfigPath;
                throw new FileNotFoundException(message);
            }
            else
            {
                htmlReporter.LoadConfig(projectPath + configPath);
            }

            return htmlReporter;
        }

        /// <summary>
        /// Creates an entry for the current test in the report
        /// with test result and details (if the test failed)
        /// </summary>
        /// <param name="report">Report</param>
        /// <param name="driver">Current browser</param>
        public static void ReportTestResult(AventStack.ExtentReports.ExtentReports report, IWebDriver driver)
        {
            if(report == null)
            {
                string message = "No instance of extent reporter.";
                throw new ArgumentNullException(message);
            }
            string currentTestName = TestContext.CurrentContext.Test.Name;
            ExtentTest test = report.CreateTest(currentTestName);

            var resultState = TestContext.CurrentContext.Result.Outcome.Status;
            var errorMessage = TestContext.CurrentContext.Result.Message;

            // it was "challenging" finding a solution to show a preview of the base64-img
            string infotext = "See snapshot by clicking 'base64-img' </br>";

            switch (resultState)
            {
                case TestStatus.Failed:
                    var mediaFailed = CaptureScreenShotAndReturnModel(driver);
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
        }

        /// <summary>
        /// Capture screenshot to be visible in extent report
        /// </summary>
        /// <param name="driver">Browser under test</param>
        /// <param name="name">Name for the media</param>
        /// <returns>Model that shows the screenshot in the report</returns>
        private static MediaEntityModelProvider CaptureScreenShotAndReturnModel(IWebDriver driver)
        {
            string screenShotName = "screenShot_" + DateTime.Now.ToString("yy-MM-ddThh_mm_ss");
            var ts = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;

            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(ts, screenShotName).Build();
        }

        /// <summary>
        /// Gets unique test run name for the report folder
        /// </summary>
        /// <returns>Name with date time</returns>
        private static string GetUniqueTestRunName(string browser)
        {
            string testRunName = browser + "_" + "TestRun" + "_";
            string timeStamp = DateTime.Now.ToString("yy-MM-ddThh_mm_ss");
            string indexFileName = "index.html";
  
            string name = testRunName + timeStamp + Path.DirectorySeparatorChar + indexFileName;
            return name;
        }
    }
}

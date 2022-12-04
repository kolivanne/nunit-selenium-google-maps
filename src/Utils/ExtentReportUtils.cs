using AventStack.ExtentReports;
using OpenQA.Selenium;

namespace GoogleMapsSeleniumCSharp.src.Utils
{
    /// <summary>
    /// Helper class to deal with report related tasks
    /// </summary>
    public class ExtentReportUtils
    {

        /// <summary>
        /// Capture screenshot to be visible in extent report
        /// </summary>
        /// <param name="driver">Browser under test</param>
        /// <param name="name">Name for the media</param>
        /// <returns>Model that shows the screenshot in the report</returns>
        public static MediaEntityModelProvider CaptureScreenShotAndReturnModel(IWebDriver driver)
        {
            string screenShotName = "screenShot_" + DateTime.Now.ToString("yy-MM-ddThh_mm_ss");
            var ts = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;

            return   MediaEntityBuilder.CreateScreenCaptureFromBase64String(ts, screenShotName).Build();
        }

        /// <summary>
        /// Gets unique test run name for the report folder
        /// </summary>
        /// <returns>Name with date time</returns>
        public static string GetUniqueTestRunName()
        {
            string name = "_" + "TestRun" + "_" + DateTime.Now.ToString("yy-MM-ddThh_mm_ss") + FilePaths.EXTENT_TESTRUN_INDEX_FILE;
            return name;
        }
    }
}

namespace GoogleMapsSeleniumCSharp.src.Utils
{
    /// <summary>
    /// Used paths inside the project
    /// </summary>
    public static class FilePaths
    {
        private const string FIREFOX_EXECUTABLE = @"C:\Program Files (x86)\Mozilla Firefox\Firefox.exe";
        /// <summary>
        /// Config file for HTML report
        /// </summary>
        public const string EXTENTREPORT_CONFIG = "ExtentReportConfig\\config.xml";
        /// <summary>
        /// Root folder for generated reports
        /// </summary>
        public const string EXTENTREPORT_REPORT_FOLDER = "Report\\";
        /// <summary>
        /// Index.html file 
        /// </summary>
        public const string EXTENT_TESTRUN_INDEX_FILE = "\\Index.html";
        /// <summary>
        /// Path to webdriver, e.g. geckodriver, chromedriver
        /// Put your driver in this folder :)
        /// </summary>
        public const string WEBDRIVER_FOLDER = @"webdriver";

        /// <summary>
        /// Check the path for the Firefox executable
        /// </summary>
        /// <returns>Path of Firefox executable</returns>
        /// <exception cref="Exception">Error message if path is worng</exception>
        public static string VerifyFireFoxExecutable()
        {
            if(File.Exists(FIREFOX_EXECUTABLE))
            {
                return FIREFOX_EXECUTABLE;
            }
            else
            {
                string message = "Unable to find Firefox exetubale. Please update path in Utils/FilePaths.cs. Thank you.";
                throw new Exception(message);
            }
        }
    }
}

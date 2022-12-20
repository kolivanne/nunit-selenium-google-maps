namespace GoogleMapsSeleniumCSharp.src.Utils
{
    /// <summary>
    /// Used paths inside the project
    /// </summary>
    public static class FilePaths
    {
        public const string FIREFOX_EXECUTABLE = @"C:\Program Files (x86)\Mozilla Firefox\Firefox.exe";
        /// <summary>
        /// Parent folder name for all reports
        /// </summary>
        public const string REPORT_ROOT_NAME = "Report";
        /// <summary>
        /// Path to webdriver, e.g. geckodriver, chromedriver
        /// Put your driver in this folder :)
        /// </summary>
        public const string WEBDRIVER_FOLDER = @"webdriver";
        
        /// <summary>
        /// Checks that Firefox executable is available before running the tests (GeckdoDriver)
        /// </summary>
        /// <exception cref="FileNotFoundException">Invalid path</exception>
        public static void VerifyFireFoxExecutable()
        {
            if (!File.Exists(FIREFOX_EXECUTABLE))
            {
                string message = "Unable to find Firefox executable, invalid path: " + FIREFOX_EXECUTABLE;
                throw new FileNotFoundException(message);
            }
        }
        /// <summary>
        /// Creates a string representing the absolute path to the project
        /// </summary>
        /// <returns>Absolute path to the project</returns>
        public static string GetProjectPath()
        {
            string pth = System.Reflection.Assembly.GetCallingAssembly().Location;
            string actualPath = pth[..pth.LastIndexOf("bin")];

            string projectPath = new Uri(actualPath).LocalPath;
            return projectPath;
        }
    }
}

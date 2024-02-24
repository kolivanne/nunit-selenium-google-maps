namespace GoogleMapsSeleniumCSharp.src.Utils
{
    /// <summary>
    /// Used paths inside the project
    /// </summary>
    public static class FilePaths
    {
        /// <summary>
        /// Parent folder name for all reports
        /// </summary>
        public const string REPORT_ROOT_NAME = "Report";
        
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

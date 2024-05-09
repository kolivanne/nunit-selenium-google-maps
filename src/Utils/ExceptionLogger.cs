namespace GoogleMapsSeleniumCSharp.src.Utils
{
    /// <summary>
    /// Log exceptions that can happen in (onetime)setup and (onetime)teardown 
    /// </summary>
    public static class ExceptionLogger
    {
        private const string exceptionLogFileName = "ExceptionLog-";
        public static void LogException(string details)
        {
            string projectPath = FilePaths.GetProjectPath() + ProjectConstants.ReportFolderName;
            try
            {

                if (!Directory.Exists(projectPath))
                {
                    Directory.CreateDirectory(projectPath);

                }
                string fileName = projectPath + Path.DirectorySeparatorChar + exceptionLogFileName + DateTime.Today.ToString("dd-MM-yyyy") + ".txt";  
                if (!File.Exists(fileName))
                {
                    File.Create(fileName).Dispose();
                }
                using StreamWriter sw = File.AppendText(fileName);
                string message = $"{DateTime.Now} : {details}";
                sw.WriteLine(message);
                sw.Flush();
                sw.Close();

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}

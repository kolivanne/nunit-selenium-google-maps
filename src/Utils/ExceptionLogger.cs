namespace GoogleMapsSeleniumCSharp.src.Utils
{
    /// <summary>
    /// Log exceptions that can happen in (onetime)setup and (onetime)teardown 
    /// </summary>
    public static class ExceptionLogger
    {
        private const string FILE_NAME = "ExceptionLog-";
        public static void LogException(string details)
        {
            string projectPath = FilePaths.GetProjectPath() + FilePaths.REPORT_ROOT_NAME;
            try
            {

                if (!Directory.Exists(projectPath))
                {
                    Directory.CreateDirectory(projectPath);

                }
                string fileName = projectPath + Path.DirectorySeparatorChar + FILE_NAME + DateTime.Today.ToString("dd-MM-yyyy") + ".txt";  
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

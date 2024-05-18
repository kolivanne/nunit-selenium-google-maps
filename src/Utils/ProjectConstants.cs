using GoogleMapsSeleniumCSharp.src.Utils;
using System.Text.RegularExpressions;

public static class ProjectConstants
{
    public static string ReportFolderName { get; private set; }
    public static string GoogleMapsBaseUrl { get; private set; }
    public static string ForcedLanguageCode { get; private set; }
    public static bool HeadlessExecutionFlag { get; private set; }
    public static int WebElementTimeout { get; private set; }

    static ProjectConstants()
    {
        string projectFolderPath = ProjectPath.GetProjectPath();
        if (projectFolderPath == null)
        {
            throw new DirectoryNotFoundException("Project folder not found.");
        }

        List<string> envFiles = new List<string>(Directory.GetFiles(projectFolderPath, "*.env", SearchOption.AllDirectories));

        if (envFiles.Count == 0)
        {
            throw new FileNotFoundException(".env file not found in project directory or its subfolders.");
        }

        // For simplicity, let's assume there's only one .env file in the project
        string envFilePath = envFiles[0];
        ParseEnvFile(envFilePath);
    }

    /// <summary>
    /// Parses the contents of the .env file located at the specified path.
    /// </summary>
    /// <param name="envFilePath">The path to the .env file.</param>
    private static void ParseEnvFile(string envFilePath)
    {
        List<string> lines = new List<string>(File.ReadAllLines(envFilePath));

        foreach (string line in lines)
        {
            string[] parts = line.Split('=');
            if (parts.Length == 2)
            {
                string key = parts[0].Trim();
                string value = parts[1].Trim();

                switch (key)
                {
                    case "ReportFolderName":
                        ParseReportFolderName(value);
                        break;
                    case "GoogleMapsBaseUrl":
                        GoogleMapsBaseUrl = value;
                        break;
                    case "ForcedLanguageCode":
                        ParseForcedLanguageCode(value);
                        break;
                    case "HeadlessExecutionFlag":
                        ParseHeadlessExecutionFlag(value);
                        break;
                    case "WebElementTimeout":
                        ParseWebElementTimeout(value);
                        break;
                    default:
                        // Log an InvalidOperationException for unrecognized keys
                        InvalidOperationException ex = new InvalidOperationException($"Unrecognized key '{key}' found in .env file.");
                        ExceptionLogger.LogException(ex.ToString());
                        break;
                }
            }
        }
    }

    /// <summary>
    /// Parses the value for ReportFolderName, ensuring it contains only alphabetic characters.
    /// If the value is invalid, sets it to the specified fallback value.
    /// </summary>
    /// <param name="value">The value to parse.</param>
    private static void ParseReportFolderName(string value)
    {
        string fallback = "Report";
        string alphabeticPattern = "^[a-zA-Z]+$";
        if (Regex.IsMatch(value, alphabeticPattern))
        {
            ReportFolderName = value;
        }
        else
        {
            ReportFolderName = fallback;
        }
    }

    /// <summary>
    /// Parses the value for HeadlessExecutionFlag, ensuring it represents a boolean value.
    /// If parsing fails, sets the flag to true as fallback.
    /// </summary>
    /// <param name="value">The value to parse.</param>
    private static void ParseHeadlessExecutionFlag(string value)
    {
        if (bool.TryParse(value, out bool parsedFlag))
        {
            HeadlessExecutionFlag = parsedFlag;
        }
        else
        {
            HeadlessExecutionFlag = true;
        }
    }

    /// <summary>
    /// Parses the value for WebElementTimeout, ensuring it represents a positive integer greater than 10.
    /// If parsing fails or value is not within the acceptable range, sets it to the fallback value.
    /// </summary>
    /// <param name="value">The value to parse.</param>
    private static void ParseWebElementTimeout(string value)
    {
        int fallback = 30;

        if (int.TryParse(value, out int parsedTimeout) || parsedTimeout <= 10)
        {
            WebElementTimeout = parsedTimeout;
        }
        else
        {
            WebElementTimeout = fallback;
        }
    }

    /// <summary>
    /// Parses the value for ForcedLanguageCode, ensuring it contains only alphabetic characters and has a length of 2.
    /// If the value is invalid, logs an ArgumentException.
    /// </summary>
    /// <param name="value">The value to parse.</param>
    private static void ParseForcedLanguageCode(string value)
    {
        // Check if the value contains only alphabetic characters and has a length of 2
        string pattern = "^[a-zA-Z]{2}$";
        string errorMessage = $"Invalid ForcedLanguageCode value '{value}' found in .env file.";

        if (Regex.IsMatch(value, pattern))
        {
            value = value.ToLower();

            if (!LanguageCode.IsValidLanguageCode(value))
            {
                throw new ArgumentException(errorMessage);
            }

            ForcedLanguageCode = value;
        }
        else
        {
            throw new ArgumentException(errorMessage);
        }
    }

}

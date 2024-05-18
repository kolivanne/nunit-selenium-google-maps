using System.Globalization;

namespace GoogleMapsSeleniumCSharp.src.Utils
{
    /// <summary>
    /// Utility class for browser localization
    /// </summary>
    public static class LanguageCode
    {
        /// <summary>
        /// Get Url with valid language code
        /// </summary>
        /// <returns>Url with localization</returns>
        public static string GetMapsUrlWithValidCountryCode() 
        {
            string formatLanguageCode = ProjectConstants.ForcedLanguageCode;
            string languageCode = $"/?hl={formatLanguageCode}";
            return ProjectConstants.GoogleMapsBaseUrl + languageCode;
        }

        /// <summary>
        /// Check if language code is valid
        /// </summary>
        /// <returns>True if the language code is valid, otherwise false</returns>
        public static bool IsValidLanguageCode(string languageCode)
        {
            List<string> validLanguageCodes = GetValidLanguageCodes();

            if (!validLanguageCodes.Contains(languageCode))
            {
                throw new ArgumentException($"Invalid language code: {languageCode}");
            }

            return true;
        }

        /// <summary>
        /// Get all valid language codes
        /// </summary>
        /// <returns>List of valid language codes</returns>
        private static List<string> GetValidLanguageCodes()
        {
            return CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                .Select(culture => new RegionInfo(culture.Name).TwoLetterISORegionName.ToLower())
                .Distinct()
                .ToList();
        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;

namespace GoogleMapsSeleniumCSharp.src.Utils
{
    /// <summary>
    /// Current browser under test
    /// </summary>
    public enum BrowserType
    {
        Chrome,
        Firefox,
        Safari,
    }

    /// <summary>
    /// Helper class to create browser instances, based on the selected browser
    /// </summary>
    public static class WebDriverInit
    {
        /// <summary>
        /// Creates a driver instance of the selected browser
        /// </summary>
        /// <param name="browser">Current browser</param>
        /// <param name="runHeadless">Set headless option for browser</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException">No valid browser was selected</exception>
        public static IWebDriver GetBrowserOptions(BrowserType browser, bool runHeadless) 
        {
            IWebDriver driver;

            switch (browser)
            {
                case BrowserType.Chrome:
                    ChromeOptions chromeOptions = new()
                    {
                        PageLoadStrategy = PageLoadStrategy.Normal
                    };
                    if(runHeadless) 
                     {
                         chromeOptions.AddArguments(ProjectConstants.HeadlessExecutionFlag);
                     } 
                    driver = new ChromeDriver(chromeOptions);
                    driver.Manage().Timeouts().PageLoad.Add(TimeSpan.FromSeconds(30));
                    break; 
                case BrowserType.Firefox:
                    FirefoxOptions firefoxOptions = new()
                    {
                        PageLoadStrategy = PageLoadStrategy.Normal,
                    };
                    if (runHeadless)
                      {
                          firefoxOptions.AddArguments(ProjectConstants.HeadlessExecutionFlag);
                      }
                    FirefoxProfile profile = new FirefoxProfile();
                    driver = new FirefoxDriver(firefoxOptions);
                    break;
                case BrowserType.Safari:
                    SafariOptions safariOptions = new()
                    {
                        PageLoadStrategy = PageLoadStrategy.Normal
                    };
                 
                    driver = new SafariDriver(safariOptions);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(browser), browser, null);
            }

            return driver;
        }
    }
}

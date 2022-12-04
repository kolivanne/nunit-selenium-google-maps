using OpenQA.Selenium;

namespace GoogleMapsSeleniumCSharp.src.PageObject.ConsentPage
{
    /// <summary>
    /// Consent page when visiting for the first time
    /// </summary>
    public partial class GoogleConsentPage : WebPage
    {
        public GoogleConsentPage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Open url and confirms  google consent dialog when visiting the page for the first time
        /// </summary>
        public void AcceptConsent()
        {
            GoTo();
            AcceptButton.Click();
        }
    }
}

using OpenQA.Selenium;

namespace GoogleMapsSeleniumCSharp.src.PageObject.ConsentPage
{
    /// <summary>
    /// Contains all needed elements for google consent dialog
    /// </summary>
    public partial class GoogleConsentPage
    {
        public IWebElement AcceptButton => WaitAndFindElement(By.CssSelector("button"));
    }
}

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsSeleniumCSharp.src.PageObject.SearchDetailsPage
{
    /// <summary>
    /// Web elements repository: search details
    /// </summary>
    public partial class SearchDetailsPage
    {
        public IWebElement DirectionsButton => WaitAndFindElement(By.XPath("//button[@class='g88MCb S9kvJb']"));
        public IWebElement FullAddress => WaitAndFindElement(By.XPath("//button[@data-item-id='address']"));
        public IWebElement TravelTitleHeader => WaitAndFindElement(By.XPath("//h1[contains(@class,'fontHeadlineLarge')]/span[1]"));
        public IWebElement AddMissingPlace => WaitAndFindElement(By.XPath("//span[contains(text(),'Google Maps')]"));
    }
}

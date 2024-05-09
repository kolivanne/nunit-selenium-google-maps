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
        public IWebElement DirectionsButton => WaitAndFindElement(By.XPath("//button[contains(@data-value, 'Routen') or contains(@data-value, 'Directions')]"));
        public IWebElement FullAddress => WaitAndFindElement(By.XPath("//button[@data-item-id='address']"));
        public IWebElement TravelTitleHeader => WaitAndFindElement(By.XPath("//h1[@class='DUwDvf lfPIob' and span]"));
        public IWebElement AddMissingPlace => WaitAndFindElement(By.XPath("//div[@class='Q2vNVc']"));

    }
}

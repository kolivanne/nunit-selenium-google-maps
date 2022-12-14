using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapsSeleniumCSharp.src.PageObject.DirectionsPage
{
    /// <summary>
    /// Repository for directions page
    /// </summary>
    public partial class DirectionsPage
    {
        public IWebElement InputDirectionInputStart => WaitAndFindElement(By.XPath("//div[@id='directions-searchbox-0']//input[@class='tactile-searchbox-input']"));
        public IWebElement InputDirectionInputDestination => WaitAndFindElement(By.XPath("//div[@id='directions-searchbox-1']//input[@class='tactile-searchbox-input']"));
    }
}

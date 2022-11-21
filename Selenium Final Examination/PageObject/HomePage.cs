using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumFramework.DriverCore;
using OpenQA.Selenium;
using NUnit.Framework;
using SeleniumFinalExamination.TestSetup;
using OpenQA.Selenium.Support.UI;

namespace SeleniumFinalExamination.PageObject
{
    public class HomePage : WebDriverAction
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        private string mainHeader = "//div[@class='main-header']";
        private string txtElement = "(//div[@class='card-up'])[1]";

        public void ClickToElement()
        {
            WaitForHomePageLoadedSuccessfully(); ;
            Click(txtElement);
        }

        public string GetTextMainHeader()
        {
            return GetText(mainHeader);
        }

        public string GetTitle()
        {
            return driver.Title;
        }

        public void WaitForElementClickable()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(ByXpath(txtElement)));
        }

        public void WaitForHomePageLoadedSuccessfully()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(ByXpath(txtElement)));
        }
    }
}

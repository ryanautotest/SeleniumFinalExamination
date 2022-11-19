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
        private string txtElement = "//*[name()='path' and contains(@d,'M16 132h41')]";

        public void SelectElement()
        {
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

    }
}

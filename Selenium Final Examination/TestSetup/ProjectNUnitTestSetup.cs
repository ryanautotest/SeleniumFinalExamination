using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumFinalExamination.PageObject;
using SeleniumFramework.TestSetup;

namespace SeleniumFinalExamination.TestSetup
{
    public class ProjectNUnitTestSetup : NUnitTestSetup
    {
        [SetUp]
        public void SetUp()
        {
            driverBaseAction.GoToURL(Constant.BASE_URL);
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {

        }

        public string GetExpectedTextWebTable()
        {
            HomePage homePage = new HomePage(driver);
            homePage.ClickToElement();
            string redirectURL = Constant.BASE_URL + homePage.GetTextMainHeader().ToLower();
            Assert.AreEqual(driver.Url, redirectURL);

            MenuLeft menuLeft = new MenuLeft(driver);
            menuLeft.ClickWebTables();

            WebTablesPage webTablesPage = new WebTablesPage(driver);
            return webTablesPage.GetTextWebTable();
        }
    }
}

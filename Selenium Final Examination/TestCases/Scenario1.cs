using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SeleniumFinalExamination.PageObject;
using SeleniumFinalExamination.TestSetup;
using SeleniumFinalExamination.Common;

namespace SeleniumFinalExamination.TestCases
{
    public class Scenario1 : ProjectNUnitTestSetup
    {
        [Test]
        public void TC1_VerifyDefaultInfo()
        {
            HomePage homePage = new HomePage(driver);
            homePage.SelectElement();
            string redirectURL = Constant.BASE_URL + homePage.GetTextMainHeader().ToLower();
            Assert.AreEqual(driver.Url, redirectURL);
            
            MenuLeft menuLeft = new MenuLeft(driver);
            menuLeft.ClickWebTables();
            
            WebTablesPage webTablesPage = new WebTablesPage(driver);
            Assert.AreEqual(webTablesPage.GetTextMainHeader(), webTablesPage.GetTextWebTable());
            //webTablesPage.GetDataFromTable();

        }

        public void TC2_AddNewEmployee()
        {
            HomePage homePage = new HomePage(driver);
            homePage.SelectElement();
            string redirectURL = Constant.BASE_URL + homePage.GetTextMainHeader().ToLower();
            Assert.AreEqual(driver.Url, redirectURL);

            MenuLeft menuLeft = new MenuLeft(driver);
            menuLeft.ClickWebTables();

            WebTablesPage webTablesPage = new WebTablesPage(driver);
            Assert.AreEqual(webTablesPage.GetTextMainHeader(), webTablesPage.GetTextWebTable());
            webTablesPage.ClickAdd();
            webTablesPage.AddNewEmployee("Toan", "Nguyen", "toan@gmail.com", "30", "35000", "Automation Tester" );
        }
    }
}

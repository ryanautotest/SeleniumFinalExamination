using OpenQA.Selenium;
using SeleniumFinalExamination.PageObject;
using SeleniumFinalExamination.TestSetup;

namespace SeleniumFinalExamination.Common
{
    public class CommonFlow
    {
            public static void SelectWebTableFlow(IWebDriver driver)
            {
            HomePage homePage = new HomePage(driver);
            homePage.ClickToElement();
            MenuLeft elementPage = new MenuLeft(driver);
            elementPage.ClickWebTables();
            }
    }
}

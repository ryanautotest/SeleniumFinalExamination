using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFinalExamination.PageObject
{
    public class WebTablesPage : HomePage
    {
        public WebTablesPage(IWebDriver driver) : base(driver)
        {
        }

        private string menuWebTables = "//span[contains(text(),'Web Tables')]";
        private string mainHeader = "//div[@class='main-header']";
        private string bttAdd = "//button[@id='addNewRecordButton']";
        private string tbFirstName = "//input[@id='firstName']";
        private string tbLastName = "//input[@id='lastName']";
        private string tbEmail = "//input[@id='userEmail']";
        private string tbAge = "//input[@id='age']";
        private string tbSalary = "//input[@id='salary']";
        private string tbDepartment = "//input[@id='department']";
        private string bttSubmit = "//button[@id='addNewRecordButton']";






        private string tableCols = "//div[@class='rt-table']//div[@class='rt-tr']//div[contains(@class, 'rt-th')]";
        private string rowGroupLocator = "//div[@role='rowgroup']";
        private string rowLocator = "//div[@role='rowgroup']//div[@role='row']";
        private string rowContent = "//div[@role='gridcell']";



        public string GetTextWebTable()
        {
            return GetText(menuWebTables);
        }

        public string GetTextElementHeader()
        {
            return GetText(mainHeader);
        }

        /*public string GetTextFromTable()
        {
            WebElement htmltable = FindElementByXpath("//*[@id='main']/table[1]/tbody");
            List<WebElement> rows = htmltable.FindElements("tr");

            for (int rnum = 0; rnum < rows.size(); rnum++)
            {
                List<WebElement> columns = rows.get(rnum).findElements(By.tagName("th"));
                System.out.println("Number of columns:" + columns.size());

                for (int cnum = 0; cnum < columns.size(); cnum++)
                {
                    System.out.println(columns.get(cnum).getText());
                }
            }
        }*/


        /*public void GetDataFromTable()
        {
            IList<IWebElement> rowGroup = FindElementsByXpath(rowGroupLocator);
            IList<IWebElement> row = FindElementsByXpath(rowLocator);

            var b = FindElementsByXpath(rowContent);

            foreach (var item in row)
            {
                for(int i = 1; i < b.Count(); i++)
                {
                    var a =  row..FindElementByXpath(By.XPath(rowContent));
                }
            }
            //}
        }

        private IWebElement getInsideElement(IWebElement el, By locator) {
            return el.FindElement(locator);
        }*/

        public void ClickAdd()
        {
            Click(bttAdd);
        }

        public void AddNewEmployee(string firstName, string lastName, string email, string age, string salary, string department)
        {
            SendKeys_(tbFirstName, firstName);
            SendKeys_(tbLastName, lastName);
            SendKeys_(tbEmail, email);
            SendKeys_(tbAge, age);
            SendKeys_(tbSalary, salary);
            SendKeys_(tbDepartment, department);
            Click(bttSubmit);
        }

        public void Click 
    }
}

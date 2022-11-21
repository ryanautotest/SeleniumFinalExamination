using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumFinalExamination.DAO;
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
        private string bttSubmit = "//button[@id='submit']";

        private string rowGroupLocator = "//div[@role='rowgroup']";
        private string rowLocator = "//div[@role='rowgroup']//div[@role='row']";
        private string rowContent = "//div[@role='gridcell']";

        //private string bttEdit = "//div[contains(text(),'" + FirstName + "')]/..//span[@title='Edit']";

        public string GetTextWebTable()
        {
            return GetText(menuWebTables);
        }

        public string GetTextElementHeader()
        {
            return GetText(mainHeader);
        }

        //get data from table, split
        public List<List<string>> GetDataFromTable()
        {
            IList<IWebElement> rowGroup = FindElementsByXpath(rowGroupLocator);
            IList<IWebElement> row = FindElementsByXpath(rowLocator);

            List<string> cellContent = FindElementsByXpath(rowContent).Select(x => x.Text).ToList();
            var splitted = cellContent.Select(
                (v, i) => new { val = v, idx = i }
                ).GroupBy(x => x.idx / 7)
                .Select(g => g.Select(y => y.val).ToList()).ToList();

            return splitted;
        }

        private IWebElement getInsideElement(IWebElement el, By locator)
        {
            return el.FindElement(locator);
        }

        public void ClickAdd()
        {
            Click(bttAdd);
        }

        public void AddNewEmployee(EmployeeDAO employee)
        {
            SendKeys_(tbFirstName, employee.FirstName);
            SendKeys_(tbLastName, employee.LastName);
            SendKeys_(tbEmail, employee.Email);
            SendKeys_(tbAge, employee.Age.ToString());
            SendKeys_(tbSalary, employee.Salary.ToString());
            SendKeys_(tbDepartment, employee.Department);
            Click(bttSubmit);
        }

        public void ClickEditByName(string FirstName)
        {
            Click(FindElementByXpath("//div[contains(text(),'" + FirstName + "')]/..//span[@title='Edit']"));
        }

        public void EditEmployee(EmployeeDAO employee)
        {
            ClearAndSendKey(tbFirstName, employee.FirstName);
            ClearAndSendKey(tbLastName, employee.LastName);
            ClearAndSendKey(tbEmail, employee.Email);
            ClearAndSendKey(tbAge, employee.Age.ToString());
            ClearAndSendKey(tbSalary, employee.Salary.ToString());
            ClearAndSendKey(tbDepartment, employee.Department);
            Click(bttSubmit);
        }

        public void DeleteEmployeeByName(string FirstName)
        {
            Click(FindElementByXpath("//div[contains(text(),'" + FirstName + "')]/..//span[@title='Delete']"));
        }

        public Boolean EmployeeDeleted(string FirstName)
        {
            IsElementDisplay("//div[contains(text(),'" + FirstName + "')]");
            return false;
        }
    }
}

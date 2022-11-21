using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SeleniumFinalExamination.PageObject;
using SeleniumFinalExamination.DAO;
using SeleniumFramework.Utilities;
using SeleniumFinalExamination.TestSetup;
using FluentAssertions;

namespace SeleniumFinalExamination.TestCases
{
    [TestFixture]
    public class WebTablesTest : ProjectNUnitTestSetup
    {
        [Test]
        [TestCase(3)]
        public void TC1_VerifyDefaultInfo(int itemEmployee)
        {
            WebTablesPage webTablesPage = new WebTablesPage(driver);
            string expectedTextWebTable = GetExpectedTextWebTable();
            Assert.AreEqual(webTablesPage.GetTextMainHeader(), expectedTextWebTable);

            //actual table data
            var actualTableContent = webTablesPage.GetDataFromTable().Take(itemEmployee).ToList();
            
            List<EmployeeDAO> lst = new List<EmployeeDAO>();
            foreach (var item in actualTableContent)
            {
                item.Remove(item[6]);
                EmployeeDAO employee = new EmployeeDAO();
                employee.FirstName = item[0];
                employee.LastName = item[1];
                employee.Age = item[2];
                employee.Email = item[3];
                employee.Salary = item[4];
                employee.Department = item[5];
                lst.Add(employee);
            }
            var actualEmployee = lst;

            List<EmployeeDAO> expectedEmployee = ReadData.GetListDataFromJsonFile<EmployeeDAO>($"Resource\\TestData\\Employee.json");
            
            //fluent assertion
            actualEmployee.Should().BeEquivalentTo(expectedEmployee);
            
        }

        [Test]
        [TestCase(4)]
        public void TC2_AddNewEmployee(int itemEmployee)
        {
            WebTablesPage webTablesPage = new WebTablesPage(driver);
            string expectedTextWebTable = GetExpectedTextWebTable();
            Assert.AreEqual(webTablesPage.GetTextMainHeader(), expectedTextWebTable);

            webTablesPage.ClickAdd();
            EmployeeDAO employee = new EmployeeDAO();
            employee.FirstName = "Toan";
            employee.LastName = "Nguyen";
            employee.Email = "toan@gmail.com";
            employee.Age = "30";
            employee.Salary = "35000";
            employee.Department = "Automation Tester";
            webTablesPage.AddNewEmployee(employee);


            var actualTableContent = webTablesPage.GetDataFromTable().Take(itemEmployee).ToList();

            List<EmployeeDAO> lst = new List<EmployeeDAO>();
            foreach (var item in actualTableContent)
            {
                item.Remove(item[6]);
                EmployeeDAO employee1 = new EmployeeDAO();
                employee1.FirstName = item[0];
                employee1.LastName = item[1];
                employee1.Age = item[2];
                employee1.Email = item[3];
                employee1.Salary = item[4];
                employee1.Department = item[5];
                lst.Add(employee1);
            }
            var actualEmployee = lst;

            List<EmployeeDAO> expectedEmployee = ReadData.GetListDataFromJsonFile<EmployeeDAO>($"Resource\\TestData\\EmployeeAfterAdd.json");

            //fluent assertion
            actualEmployee.Should().BeEquivalentTo(expectedEmployee);


        }

        [Test]
        [TestCase(3)]
        public void TC3_UpdateAndDeleteEmployee(int itemEmployee)
        {
            WebTablesPage webTablesPage = new WebTablesPage(driver);
            string expectedTextWebTable = GetExpectedTextWebTable();
            Assert.AreEqual(webTablesPage.GetTextMainHeader(), expectedTextWebTable);

            webTablesPage.ClickEditByName("Kierra");
            EmployeeDAO employee = new EmployeeDAO();
            employee.FirstName = "Toan";
            employee.LastName = "Nguyen";
            employee.Email = "toan@gmail.com";
            employee.Age = "30";
            employee.Salary = "35000";
            employee.Department = "Automation Tester";
            webTablesPage.EditEmployee(employee);


            var actualTableContent = webTablesPage.GetDataFromTable().Take(itemEmployee).ToList();

            List<EmployeeDAO> lst = new List<EmployeeDAO>();
            foreach (var item in actualTableContent)
            {
                item.Remove(item[6]);
                EmployeeDAO employee2 = new EmployeeDAO();
                employee2.FirstName = item[0];
                employee2.LastName = item[1];
                employee2.Age = item[2];
                employee2.Email = item[3];
                employee2.Salary = item[4];
                employee2.Department = item[5];
                lst.Add(employee2);
            }
            var actualEmployee = lst;

            List<EmployeeDAO> expectedEmployee = ReadData.GetListDataFromJsonFile<EmployeeDAO>($"Resource\\TestData\\EmployeeAfterEdit.json");

            actualEmployee.Should().BeEquivalentTo(expectedEmployee);
            
            //Delete
            webTablesPage.DeleteEmployeeByName(employee.FirstName);
            Assert.False(webTablesPage.EmployeeDeleted(employee.FirstName));
        }

    }
}

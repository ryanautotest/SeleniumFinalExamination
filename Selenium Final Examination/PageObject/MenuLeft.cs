using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFinalExamination.PageObject
{
    public class MenuLeft : HomePage
    {
        public MenuLeft(IWebDriver driver) : base(driver)
        {
        }

        private string menuWebTables = "//span[contains(text(),'Web Tables')]";

        public void ClickWebTables()
        {
            Click(menuWebTables);
        }

    }
}

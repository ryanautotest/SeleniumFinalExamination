using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SeleniumFramework.TestSetup;

namespace SeleniumFinalExamination.TestSetup
{
    public class ProjectNUnitTestSetup : NUnitTestSetup
    {
        [SetUp]
        public void SetUp()
        {
            driver.Url = Constant.BASE_URL;
        }

        [TearDown]
        public void TearDown()
        {

        }
    }
}

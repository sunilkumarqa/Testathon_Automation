using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Testathon_Framework.Factory;


namespace Testathon_Framework
{
  public  class StartupScript
    {
      public static IWebDriver driver = new ChromeDriver();
       public static void Main(string[] args)
        {
            FactoryDesign obj = new FactoryDesign();
            ITestCase testcase = obj.GetTestCase(TestModules.Login);
            testcase.Execute(driver,"param1", "param2", "param3", "param4");
        }
    }
}

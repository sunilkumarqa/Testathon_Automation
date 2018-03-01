using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testathon_Framework.Factory;
using Testathon_Framework.PageServices;

namespace Testathon_Framework.TestScenarios
{
    public class InvalidLoginScenarios : ITestCase
    {
        public ExtentReports extent;
        public ExtentTest test;
      LoginPageServices loginServices = new LoginPageServices();
      CommonPageServices commonPageServices = new CommonPageServices();

      public void Execute(IWebDriver driver,string validationType, string userName, string password, string param4)
      {
        
        try {
            // test = extent.StartTest("InValidLogin Scenarios");
              loginServices.Invalid_Login(driver, validationType, userName, password);
             // test.Log(LogStatus.Pass, "Assert Pass as condition is True");
              }
          catch (Exception e)
          {
              commonPageServices.getScreenShot(driver);
             // test.Log(LogStatus.Fail, "Failed" + "" + e);
              throw e;
          }
         
      }
    }
}

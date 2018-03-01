using NUnit.Framework;
using NUnit.Framework.Interfaces;
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
    public class LoginScenarios : ITestCase
    {
        public ExtentReports extent;
        public ExtentTest test;
        LoginPageServices loginServices = new LoginPageServices();
        CommonPageServices commonPageServices = new CommonPageServices();
      
      public void Execute(IWebDriver driver,string userName, string Password, string param3, string param4)
      {
       
          try {
              //test = extent.StartTest("ValidLogin Scenarios");
              loginServices.valid_Login(driver, userName, Password);
              }
          catch (Exception e)
          {
              commonPageServices.getScreenShot(driver);
             
              throw e;
              
          }
         
      }
    }
}

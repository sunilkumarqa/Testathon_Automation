using OpenQA.Selenium;
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
    public class VerifyLoginErrorMessagesScenario : ITestCase
    {
      LoginPageServices loginServices = new LoginPageServices();
      CommonPageServices commonPageServices = new CommonPageServices();

      public void Execute(IWebDriver driver,string validationType, string userName, string password, string param4)
      {
          try {
              loginServices.Invalid_Login(driver, validationType, userName, password);
              loginServices.verifyLoginErrorMessages(driver, validationType, param4);
              }
          catch (Exception e)
          {
              commonPageServices.getScreenShot(driver);
              throw e;
          }
         
      }
    }
}

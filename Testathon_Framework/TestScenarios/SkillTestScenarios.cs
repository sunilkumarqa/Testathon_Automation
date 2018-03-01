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
    public class SkillTestScenarios : ITestCase
    {
      LoginPageServices loginServices = new LoginPageServices();
      CommonPageServices commonPageServices = new CommonPageServices();
      SkillTestServices skillTestServices = new SkillTestServices();
      public void Execute(IWebDriver driver, string expectedText, string param2, string param3, string param4)
      {
          try {
              skillTestServices.SkillTest(driver);
              skillTestServices.verifySkillTestPage(driver, expectedText);
              }
          catch (Exception e)
          {
              commonPageServices.getScreenShot(driver);
              throw e;
          }
         
      }
    }
}

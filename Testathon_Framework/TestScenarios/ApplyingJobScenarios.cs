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
    public class ApplyingJobScenarios : ITestCase
    {
      LoginPageServices loginServices = new LoginPageServices();
      CommonPageServices commonPageServices = new CommonPageServices();
      ApplyingJobServices ApplyingJobServices = new ApplyingJobServices();
      public void Execute(IWebDriver driver,string searchtext, string param2, string param3, string param4)
      {
          try {
              ApplyingJobServices.applyingJob(driver, searchtext);
              }
          catch (Exception e)
          {
              commonPageServices.getScreenShot(driver);
              throw e;
          }
         
      }
    }
}

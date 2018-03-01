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
    public class ContestParticipationScenario : ITestCase
    {
      LoginPageServices loginServices = new LoginPageServices();
      CommonPageServices commonPageServices = new CommonPageServices();
      ContestParticipationServices contestParticipationServices = new ContestParticipationServices();
      public void Execute(IWebDriver driver, string ChallengeName, string testType, string param3, string param4)
      {
          try {
              contestParticipationServices.clickonChallenges(driver);
              contestParticipationServices.ChallengeParticipate(driver,ChallengeName,testType);
              }
          catch (Exception e)
          {
              commonPageServices.getScreenShot(driver);
              throw e;
          }
         
      }
    }
}

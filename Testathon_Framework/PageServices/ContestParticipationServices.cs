using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Testathon_Framework.PageElements;



namespace Testathon_Framework.PageServices
{
    public class ContestParticipationServices
    {
     
       LoginPageElements loginElements = new LoginPageElements();
       CommonPageServices commonPageServices = new CommonPageServices();
       LoginPageServices loginServices = new LoginPageServices();
       ContestParticipationElements contestParticipationElements = new ContestParticipationElements();
       SkillTestElements skillTestElements = new SkillTestElements();

        /// <summary>
        /// This method is used to navigate challenges page
        /// </summary>
        /// <param name="driver"></param>
          public void clickonChallenges(IWebDriver driver)
       {
           skillTestElements.linkCompete(driver).Click();
       }
        /// <summary>
        /// This method is used to verify the challenges page text
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="expectedText"></param>
        public void verifyChallengesPage(IWebDriver driver, string expectedText)
       {
           clickonChallenges(driver);
           string ActualText = contestParticipationElements.searchChallengesText(driver).Text;
         string expText = expectedText;
         Assert.AreEqual(expText, ActualText);
       }
        /// <summary>
        /// This method is used for searching the contents
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="skillTestName"></param>
        public void searchChallenges(IWebDriver driver, string skillTestName)
        {
            contestParticipationElements.textBox_SearchChallenges(driver).SendKeys(skillTestName);
            contestParticipationElements.textBox_SearchChallenges(driver).SendKeys(Keys.Enter);
            Thread.Sleep(3000);
        }
        /// <summary>
        /// This method is used to paricipate in any challenge
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="ChallengeName"></param>
        /// <param name="testType"></param>
        public void ChallengeParticipate(IWebDriver driver, string ChallengeName, string testType)
        {
            contestParticipationElements.textBox_SearchChallenges(driver).Clear();
            //contestParticipationElements.textBox_SearchChallenges(driver).SendKeys(ChallengeName);
            //Thread.Sleep(2000);
            contestParticipationElements.searchChallenges(driver).Click();
            Thread.Sleep(3000);
            contestParticipationElements.Button_startTest(driver).Click();
            Thread.Sleep(3000);
            if (contestParticipationElements.Button_takeTest(driver).Displayed)
            {
                contestParticipationElements.Button_takeTest(driver).Click();
            }
            Thread.Sleep(3000);
            switch (testType)
            {
                case "submitTest":
                    if (skillTestElements.button_Nextbutton(driver).Enabled)
                    {
                        for (int i = 0; i <= 23; i++)
                        {
                            skillTestElements.selectAnswer(driver).Click();
                            Thread.Sleep(3000);
                            skillTestElements.button_Nextbutton(driver).Click();
                        }
                    }
                    skillTestElements.button_submittest(driver).Click();
                    Thread.Sleep(3000);
                    skillTestElements.popupbutton_submittest(driver).Click();
                    break;
                case "ResumeTest":
                    skillTestElements.popupbutton_Resumetest(driver).Click();
                    driver.Navigate().Back();
                    driver.Navigate().Back();
                    break;
            }
        }
    }
}

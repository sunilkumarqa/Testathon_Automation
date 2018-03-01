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
    public class SkillTestServices
    {
      
       LoginPageElements loginElements = new LoginPageElements();
       CommonPageServices commonPageServices = new CommonPageServices();
       LoginPageServices loginServices = new LoginPageServices();
       SkillTestElements skillTestElements = new SkillTestElements();
        /// <summary>
        /// This method is used to click the skill test functionalities
        /// </summary>
        /// <param name="driver"></param>
       public void SkillTest(IWebDriver driver)
       {
           Actions act = new Actions(driver);
           act.ClickAndHold(skillTestElements.linkCompete(driver)).Perform() ;
           skillTestElements.linkskillTest(driver).Click();

       }
        /// <summary>
        /// This method is used to verify the skill test page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="expectedText"></param>
        public void verifySkillTestPage(IWebDriver driver, string expectedText)
       {
         string ActualText=  skillTestElements.skillTestPageText(driver).Text;
         string expText = expectedText;
         Assert.IsTrue(expText.Contains(ActualText));
       }
        /// <summary>
        /// This method is used to do searching the skill test contents
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="skillTestName"></param>
        public void searchSkillTest(IWebDriver driver, string skillTestName)
        {
            skillTestElements.textbox_SearchSkillTest(driver).SendKeys(skillTestName);
            skillTestElements.textbox_SearchSkillTest(driver).SendKeys(Keys.Enter);
            Thread.Sleep(3000);
        }
        /// <summary>
        /// This method is used for take the test
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="skillTestName"></param>
        /// <param name="testType"></param>
        public void TestSkillTest(IWebDriver driver, string skillTestName, string testType)
        {
            skillTestElements.textbox_SearchSkillTest(driver).Clear();
            skillTestElements.textbox_SearchSkillTest(driver).SendKeys(skillTestName);
            Thread.Sleep(2000);
            skillTestElements.searchcontent(driver).Click();
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
                    commonPageServices.WaitWebDriver(driver, skillTestElements.popupbutton_submittest(driver));
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

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testathon_Framework.PageElements
{
    public class ContestParticipationElements
    {
      public IWebElement textBox_SearchChallenges(IWebDriver driver)
       {
           IWebElement challenges = driver.FindElement(By.Id("search_skilltest"));
           return challenges;
       }
      public IWebElement searchChallenges(IWebDriver driver)
      {
          IWebElement searchChallenges = driver.FindElement(By.XPath("//*[@id='running_challenge_2']"));
          return searchChallenges;
      }
      public IWebElement searchChallengesText(IWebDriver driver)
      {
          IWebElement searchChallenges1 = driver.FindElement(By.XPath("//*[@class='main-search-block clearfix']/h2"));
          return searchChallenges1;
      }
      public IWebElement Button_ParticipateNow(IWebDriver driver)
      {
          IWebElement ParticipateNow = driver.FindElement(By.XPath("//*[@class='shedule-list active clearfix full-width'][1]/li[6]"));
          return ParticipateNow;
      }
      public IWebElement Button_startTest(IWebDriver driver)
      {
          IWebElement StartTest = driver.FindElement(By.XPath("//*[@class='form1']/a"));
          return StartTest;
      }
      public IWebElement Button_takeTest(IWebDriver driver)
      {
          IWebElement taketest = driver.FindElement(By.XPath(" //*[@id='access-to-login']"));
          return taketest;
      }
       
    }
}

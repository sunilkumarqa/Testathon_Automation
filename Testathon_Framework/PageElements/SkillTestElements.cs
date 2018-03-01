using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testathon_Framework.PageElements
{
    public class SkillTestElements
    {
      public IWebElement linkCompete(IWebDriver driver)
       {
           IWebElement Compete = driver.FindElement(By.XPath("//span[@class='menu-text'][text()='Compete']"));
           return Compete;
       }
      public IWebElement linkskillTest(IWebDriver driver)
      {
          IWebElement skilltest = driver.FindElement(By.LinkText("Skill Tests"));
          return skilltest;
      }
      public IWebElement skillTestPageText(IWebDriver driver)
      {
          IWebElement skillTestText = driver.FindElement(By.XPath("//*[@class = 'main-search-block clearfix']/h2"));
          return skillTestText;
      }
      public IWebElement textbox_SearchSkillTest(IWebDriver driver)
      {
          IWebElement searchbox = driver.FindElement(By.Id("search_skilltest"));
          return searchbox;

      }
      public IWebElement searchcontent(IWebDriver driver)
      {
          IWebElement searchContentRES = driver.FindElement(By.XPath("//*[@class ='searched-content']/ul/li[1]"));
          return searchContentRES;
      }
      public IWebElement button_submittest(IWebDriver driver)
      {
          IWebElement submittestButton = driver.FindElement(By.Id("submit_test"));
          return submittestButton;
      }
      public IWebElement  popupbutton_submittest(IWebDriver driver)
      {
          IWebElement popupbuttonsubmittest = driver.FindElement(By.XPath("//*[@class='btn button1 submit-complete']"));
          return popupbuttonsubmittest;
      }
      public IWebElement popupbutton_Resumetest(IWebDriver driver)
      {
          IWebElement popupbuttonResumetest = driver.FindElement(By.XPath("//*[@class= 'btn button2']"));
          return popupbuttonResumetest;
      }
      public IWebElement button_Nextbutton(IWebDriver driver)
      {
          IWebElement NextButton = driver.FindElement(By.XPath("//*[@class=' btn button1']"));
          return NextButton;
      }
      public IWebElement selectAnswer(IWebDriver driver)
      {
          IWebElement answer = driver.FindElement(By.XPath("//*[@class='options']/li[1]"));
          return answer;
      }
    }
}

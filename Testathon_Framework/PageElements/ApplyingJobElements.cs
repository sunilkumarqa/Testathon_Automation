using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testathon_Framework.PageElements
{
    public class ApplyingJobElements
    {
      public IWebElement linkJob(IWebDriver driver)
       {
           IWebElement jobOption = driver.FindElement(By.XPath("//span[@class='menu-text'][text()='Jobs']"));
           return jobOption;
       }
      public IWebElement SearchJob(IWebDriver driver)
      {
          IWebElement searchjobOption = driver.FindElement(By.Id("search_skilltest"));
          return searchjobOption;
      }
        public IWebElement button_SearchJob(IWebDriver driver)
      {
          IWebElement searchbutton = driver.FindElement(By.Id("btn-srch-search"));
          return searchbutton;
      }
    }
}

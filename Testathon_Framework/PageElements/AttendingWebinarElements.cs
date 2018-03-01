using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testathon_Framework.PageElements
{
    public class AttendingWebinarElements
    {
      public IWebElement webinarlink(IWebDriver driver)
       {
           IWebElement webnair = driver.FindElement(By.XPath("//span[@class='menu-text'][text()='Webinars']"));
           return webnair;
       }
      public IWebElement attendingwebnair(IWebDriver driver)
      {
          IWebElement webnair1 = driver.FindElement(By.XPath("//*[@class='col-md-4 col-sm-6'][2]"));
          return webnair1;
      }
        public IWebElement button_BookSeat(IWebDriver driver)
      {
          IWebElement bookseat = driver.FindElement(By.Id("ancJoinWebinar"));
          return bookseat;
      }
        public IWebElement greenCheck_BookSeat(IWebDriver driver)
        {
            IWebElement green = driver.FindElement(By.XPath("//*[@class='fa fa-check green']"));
            return green;
        }
    }
}

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
    public class WebinarServices
    {
      
       LoginPageElements loginElements = new LoginPageElements();
       CommonPageServices commonPageServices = new CommonPageServices();
       LoginPageServices loginServices = new LoginPageServices();
       AttendingWebinarElements attendingWebinarElements = new AttendingWebinarElements();
        /// <summary>
        /// This method is used to click the webinar link
        /// </summary>
        /// <param name="driver"></param>
       public void linkWebinar(IWebDriver driver)
       {
           attendingWebinarElements.webinarlink(driver).Click();

       }
        /// <summary>
        /// This method is used for attending a webinar
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
       public Boolean registerWebinar(IWebDriver driver)
       {
           attendingWebinarElements.attendingwebnair(driver).Click();
           Thread.Sleep(3000);
           if (attendingWebinarElements.button_BookSeat(driver).Enabled)
           {
               attendingWebinarElements.button_BookSeat(driver).Click();
           
           }
           return true;
       }
        
    }
}

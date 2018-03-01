using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testathon_Framework.PageElements
{
    public class LoginPageElements
    {
      public IWebElement linklogin(IWebDriver driver)
       {
        IWebElement element = driver.FindElement(By.LinkText("Login"));
         return element;
       }
      public IWebElement UsernameTextbox(IWebDriver driver)
       {
         IWebElement element1 = driver.FindElement(By.Id("username"));
         return element1;
       }
     public IWebElement PasswordTextbox(IWebDriver driver)
       {
        IWebElement element2 = driver.FindElement(By.Id("password"));
        return element2;
       }
     public IWebElement loginButton(IWebDriver driver)
     {
         IWebElement element3 = driver.FindElement(By.Id("button_login"));
         return element3;

     }
     public IWebElement loginErrorMessage(IWebDriver driver)
     {
         IWebElement error = driver.FindElement(By.XPath("//*[@class='error_msg']"));
         return error;
     }
  
       
    }
}

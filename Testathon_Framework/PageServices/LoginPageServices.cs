using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
   public class LoginPageServices
    {
      
       LoginPageElements loginElements = new LoginPageElements();
       CommonPageServices commonPageServices = new CommonPageServices();
       /// <summary>
       /// This method is used to launch the application and maximize the browser.
       /// </summary>
       /// <param name="driver"></param>
       public void Launch_Application(IWebDriver driver)
       {        
           driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["URL"]);
           driver.Manage().Window.Maximize();
           Thread.Sleep(3000);
           
       }
       /// <summary>
       /// This method is used to do valid login functionalities
       /// </summary>
       /// <param name="driver"></param>
       /// <param name="userName"></param>
       /// <param name="Password"></param>
       public void valid_Login(IWebDriver driver, string userName, string Password)
       {
           loginElements.linklogin(driver).Click();
           loginElements.UsernameTextbox(driver).SendKeys(userName);
           loginElements.PasswordTextbox(driver).SendKeys(Password);
           loginElements.loginButton(driver).Click();
       }
       /// <summary>
       /// This method is used to validate the invalid login scenarios.
       /// </summary>
       /// <param name="driver"></param>
       /// <param name="validationType"></param>
       /// <param name="userName"></param>
       /// <param name="password"></param>
       public void Invalid_Login(IWebDriver driver, string validationType, string userName, string password)
       {
           switch (validationType)
           {
               case "validUserInvalidPwd":
               case "InvalidUserValidPwd":
               case "InvalidUserInvalidPwd":
                   loginElements.linklogin(driver).Click();
                   loginElements.UsernameTextbox(driver).Clear();
                   loginElements.PasswordTextbox(driver).Clear();
                   loginElements.UsernameTextbox(driver).SendKeys(userName);
                   loginElements.PasswordTextbox(driver).SendKeys(password);
                   loginElements.loginButton(driver).Click();
                   break;
               case "WithoutUserPwd":
                   loginElements.linklogin(driver).Click();
                   loginElements.UsernameTextbox(driver).Clear();
                   loginElements.PasswordTextbox(driver).Clear();
                   loginElements.loginButton(driver).Click();
                   break;
               case "NoUservalidPwd":
                   loginElements.linklogin(driver).Click();
                   loginElements.UsernameTextbox(driver).Clear();
                   loginElements.PasswordTextbox(driver).SendKeys(password);
                   loginElements.loginButton(driver).Click();
                   break;
               case "validUsernoPwd":
                   loginElements.linklogin(driver).Click();
                   loginElements.UsernameTextbox(driver).SendKeys(userName);
                   loginElements.PasswordTextbox(driver).Clear();
                   loginElements.loginButton(driver).Click();
                   break;
           }
       }
       /// <summary>
       /// This method is used to verify the error messages for invalid login entry
       /// </summary>
       /// <param name="driver"></param>
       /// <param name="validationType"></param>
       /// <param name="expectedMsg"></param>
       public void verifyLoginErrorMessages(IWebDriver driver, string validationType, string expectedMsg)
       {
           switch (validationType)
           {
               case "NoUservalidPwd":
                   string actualMsg = loginElements.loginErrorMessage(driver).Text;
                   Assert.True(expectedMsg.Contains(actualMsg));
                   break;
               case "validUsernoPwd":
                   string actualMsg1 = loginElements.loginErrorMessage(driver).Text;
                   Assert.True(expectedMsg.Contains(actualMsg1));
                   break;
                   
           }
       }

    }
}

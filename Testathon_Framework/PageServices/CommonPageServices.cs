using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI; 
namespace Testathon_Framework.PageServices
{
   public class CommonPageServices
    {
       /// <summary>
       /// This method is used for generating random text
       /// </summary>
       /// <param name="length"></param>
       /// <returns></returns>
        public string EnterRandomText(int length)
        {
            string charSet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Random random = new Random();
            string randomText = new String(Enumerable.Repeat(charSet, length).Select(set => set[random.Next(set.Length)]).ToArray());
            return randomText;

        }
       /// <summary>
        /// This method is used for generating random No
       /// </summary>
       /// <returns></returns>
        public string EnterRandomNo()
        {
            Random random = new Random();
            int tal = random.Next(0, 100000000);
            string randomNumber = tal.ToString();
            return randomNumber;
        }
       /// <summary>
        /// This method is used for generating snapshot during execution time for failed test cases
       /// </summary>
       /// <param name="driver"></param>
        public void getScreenShot(IWebDriver driver)
        {

            Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
            //Save the screenshot
            image.SaveAsFile(string.Format("C:\\Users\\105798\\Documents\\Visual Studio 2013\\Projects\\Testathon_Framework\\snapShot\\Screenshot{0}.Png", getcurrentTime() + " "), ScreenshotImageFormat.Png);

        }
       /// <summary>
       /// This method is used for getting current time
       /// </summary>
       /// <returns></returns>
        public string getcurrentTime()
        {
            string currentTime = string.Format("{0:yyyy-MM-dd_hh-mm-ss-tt}", DateTime.Now);
            return currentTime;
        }
       /// <summary>
       /// This method is used of Webdriver wait
       /// </summary>
       /// <param name="driver"></param>
       /// <param name="element"></param>
        public void WaitWebDriver(IWebDriver driver, IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(3));
            Func<IWebDriver, bool> waitForElement = new Func<IWebDriver, bool>((IWebDriver Web) =>
            {
                IWebElement element1 = element;
                if (element.Enabled)
                {
                    return true;
                }
                return false;
            });
            wait.Until(waitForElement); 

        }
       /// <summary>
       /// This method is used for closing webdriver
       /// </summary>
       /// <param name="driver"></param>
        public void closeDriver(IWebDriver driver)
        {
            driver.Quit();
        }
    }
}

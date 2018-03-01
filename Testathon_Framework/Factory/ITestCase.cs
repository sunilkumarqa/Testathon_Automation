using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testathon_Framework.Factory
{
   public interface ITestCase
    {
       void Execute(IWebDriver driver,string param1, string param2 , string param3, string param4);
    }
}

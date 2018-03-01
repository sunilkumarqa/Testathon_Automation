using System;
using NUnit.Framework;
using Testathon_Framework.TestScenarios;
using Testathon_Framework.PageServices;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RelevantCodes.ExtentReports;
using NUnit.Framework.Interfaces;
using Testathon_Framework;
using System.Globalization;

namespace AutomationTestcases
{
    [TestFixture]
    public class LoginTestCases
    {
        public ExtentReports extent;
        public ExtentTest test;
        public static IWebDriver driver = new ChromeDriver();
        LoginScenarios loginScenarios = new LoginScenarios();
        InvalidLoginScenarios invalidLoginScenarios = new InvalidLoginScenarios();
        CommonPageServices commonPageServices = new CommonPageServices();
        LoginPageServices loginServices = new LoginPageServices();
        VerifyLoginErrorMessagesScenario verifyLoginErrorMessagesScenario = new VerifyLoginErrorMessagesScenario();
        BasicReport basicReport = new BasicReport();
        [SetUp]
        public void TestFixtureSetupSteps()
        {
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
           // string reportPath = projectPath + "Reports\\AutomationReport"+commonPageServices.getcurrentTime()+".html";
            string reportPath = projectPath + "Reports\\AutomationReport.html";
            extent = new ExtentReports(reportPath, false);
            extent
            .AddSystemInfo("Host Name", "Sunil")
            .AddSystemInfo("Environment", "QA")
            .AddSystemInfo("User Name", "sunilqa");
            extent.LoadConfig(projectPath + "extent-config.xml");
            test = extent.StartTest("LoginTestCases");
            loginServices.Launch_Application(driver);
        }
        [Test, Order(1)]
        public void WithoutUserPwd()
        {
            invalidLoginScenarios.Execute(driver, "WithoutUserPwd", "param2", "param3", "param4");
        }
        [Test, Order(2)]
        public void validUserInvalidPwd()
        {
            invalidLoginScenarios.Execute(driver, "validUserInvalidPwd", "sksahoo543@gmail.com", commonPageServices.EnterRandomText(5), "param4");
        }
        [Test, Order(3)]
        public void InvalidUserValidPwd()
        {
            //test = extent.StartTest("InvalidUserValidPwd");
           invalidLoginScenarios.Execute(driver, "InvalidUserValidPwd", commonPageServices.EnterRandomText(5), "sunil123", "param4");
        }
        [Test, Order(4)]
        public void InvalidUserInvalidPwd()
        {
           //test = extent.StartTest("InvalidUserInvalidPwd");
            invalidLoginScenarios.Execute(driver, "InvalidUserInvalidPwd", commonPageServices.EnterRandomText(5), commonPageServices.EnterRandomText(5), "param4");
        }
        [Test, Order(5)]
        public void NoUservalidPwd()
        {
            //test = extent.StartTest("NoUservalidPwd");
            invalidLoginScenarios.Execute(driver, "NoUservalidPwd", "param3", commonPageServices.EnterRandomText(5), "param4");
        }
        [Test, Order(6)]
        public void validUsernoPwd()
        {
            //test = extent.StartTest("validUsernoPwd");
            invalidLoginScenarios.Execute(driver, "validUsernoPwd", "sksahoo543@gmail.com", "param3", "param4");
        }
        [Test, Order(7)]
        public void VerifyErrorMsgvalidUsernoPwd()
        {
            //test = extent.StartTest("VerifyErrorMsgvalidUsernoPwd");
            verifyLoginErrorMessagesScenario.Execute(driver, "validUsernoPwd", "param2", "param3", "Please enter your password.");
        }
        [Test, Order(8)]
        public void VerifyErrorMsgNoUservalidPwd()
        {
            //test = extent.StartTest("VerifyErrorMsgNoUservalidPwd");
            verifyLoginErrorMessagesScenario.Execute(driver, "NoUservalidPwd", "param2", "param3", "Please enter your username.");
        }
        [Test, Order(9)]
        public void ValidLogin()
        {
            loginScenarios.Execute(driver, "sksahoo543@gmail.com", "sunil123", "param3", "param4");

            test.Log(LogStatus.Info, "ValidLogin passed");
            test.Log(LogStatus.Info, "Without username and Password passed");
            test.Log(LogStatus.Info, "VerifyErrorMsgNoUservalidPwd passed");
            test.Log(LogStatus.Info, "VerifyErrorMsgvalidUsernoPwd passed");
            test.Log(LogStatus.Info, "Valid username and no Password passed");
            test.Log(LogStatus.Info, "No username and valid Password passed");
            test.Log(LogStatus.Info, "Invalid username and invalid Password passed");
            test.Log(LogStatus.Info, "Invalid username and valid Password passed");
            test.Log(LogStatus.Info, "valid username and invalid Password passed");
            test.Log(LogStatus.Info, "Without username and Password passed");
        }

        [OneTimeTearDown]
        public void Teardown()
        {
           var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace ="" + TestContext.CurrentContext.Result.StackTrace + "";
            var errorMessage = TestContext.CurrentContext.Result.Message;

            //if (status == TestStatus.Passed)
            //{
            //    test.Log(LogStatus.Pass, "Login Test Cases Passed");
            //}
            if (status == TestStatus.Failed)
            {
                test.Log(LogStatus.Fail, stackTrace + errorMessage);
            }

            extent.EndTest(test);
            extent.Flush();
            extent.Close();
            commonPageServices.closeDriver(driver);
        }

    }
}
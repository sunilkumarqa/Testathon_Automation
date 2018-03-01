using System;
using NUnit.Framework;
using Testathon_Framework.TestScenarios;
using Testathon_Framework.PageServices;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RelevantCodes.ExtentReports;
using NUnit.Framework.Interfaces;

namespace AutomationTestcases
{
    [TestFixture]
    public class AttendingWebinarTestCases
    {
        public ExtentReports extent;
        public ExtentTest test;
        public static IWebDriver driver = new ChromeDriver();
        LoginScenarios loginScenarios = new LoginScenarios();
        InvalidLoginScenarios invalidLoginScenarios = new InvalidLoginScenarios();
        CommonPageServices commonPageServices = new CommonPageServices();
        LoginPageServices loginServices = new LoginPageServices();
        WebiNarScenarios webiNarScenarios = new WebiNarScenarios();
        //BasicReport basicReport = new BasicReport();
        [SetUp]
        public void TestFixtureSetupSteps()
        {
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string reportPath = projectPath + "Reports\\AutomationReport.html";
            extent = new ExtentReports(reportPath, false);
          
            extent
            .AddSystemInfo("Host Name", "Sunil")
            .AddSystemInfo("Environment", "QA")
            .AddSystemInfo("User Name", "Sunilqa");
            extent.LoadConfig(projectPath + "extent-config.xml");
            test = extent.StartTest("AttendingWebinar Test");
            loginServices.Launch_Application(driver);
        }
        [Test]
        public void AttendWebinarSuccessfully()
        {
            webiNarScenarios.Execute(driver, "param1", "param2", "param3", "param4");
            test.Log(LogStatus.Info, "AttendingWebinar passed");
        }
        [OneTimeTearDown]
        public void Teardown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = "" + TestContext.CurrentContext.Result.StackTrace + "";
            var errorMessage = TestContext.CurrentContext.Result.Message;

            //if (status == TestStatus.Passed)
            //{
            //    test.Log(LogStatus.Pass, "Attending Webinar Test Cases ----Passed");
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
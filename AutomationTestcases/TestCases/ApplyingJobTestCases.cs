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
    public class ApplyingJobTestCases
    {
        public ExtentReports extent;
        public ExtentTest test;
        public static IWebDriver driver = new ChromeDriver();
        CommonPageServices commonPageServices = new CommonPageServices();
        LoginPageServices loginServices = new LoginPageServices();
        ApplyingJobScenarios applyingJobScenarios = new ApplyingJobScenarios();
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
            test = extent.StartTest("ApplyingJob Test");
            loginServices.Launch_Application(driver);
            loginServices.valid_Login(driver, "sksahoo543@gmail.com", "sunil123");
        }
        [Test]
       public void applyingJob()
       {
           applyingJobScenarios.Execute(driver, "java", "param2", "param3", "param4");
           test.Log(LogStatus.Info, "applyingJob passed");
       }
        [OneTimeTearDown]
        public void Teardown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = "" + TestContext.CurrentContext.Result.StackTrace + "";
            var errorMessage = TestContext.CurrentContext.Result.Message;

            //if (status == TestStatus.Passed)
            //{
            //    test.Log(LogStatus.Pass, "Applying Job Test Cases ----Passed");
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
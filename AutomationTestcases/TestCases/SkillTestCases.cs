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
    public class SkillTestCases
    {
        public ExtentReports extent;
        public ExtentTest test;
        public static IWebDriver driver = new ChromeDriver();
        CommonPageServices commonPageServices = new CommonPageServices();
        LoginPageServices loginServices = new LoginPageServices();
        SkillTestScenarios skillTestScenarios = new SkillTestScenarios();
        SubmitSkillTestScenarios submitSkillTestScenarios = new SubmitSkillTestScenarios();
        SkillTestServices skillTestServices = new SkillTestServices();

        [SetUp]
        public void TestFixtureSetupSteps()
        {
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string reportPath = projectPath + "Reports\\AutomationReport.html";
            // extent = new ExtentReports(reportPath);
            // extent = new ExtentReports(reportPath, bool replaceExisting);
            // extent = new ExtentReports(reportPath, DisplayOrder displayOrder);


            extent = new ExtentReports(reportPath, false);
            //extent = new ExtentReports(reportPath, CultureInfo.GetCultureInfo("es-ES"), false, DisplayOrder.NewestFirst);
            extent
            .AddSystemInfo("Host Name", "Sunil")
            .AddSystemInfo("Environment", "QA")
            .AddSystemInfo("User Name", "Sunilqa");
            extent.LoadConfig(projectPath + "extent-config.xml");
            test = extent.StartTest("skillTest");
            loginServices.Launch_Application(driver);
            loginServices.valid_Login(driver, "sksahoo543@gmail.com", "sunil123");
        }
        [Test, Order(1)]
        public void VerifyskillTest()
        {
            skillTestScenarios.Execute(driver, "Search for Skill Tests", "param2", "param3", "param4");
        }
        [Test, Order(3)]
        public void SubmitSkillTest()
        {
            submitSkillTestScenarios.Execute(driver, "Search for Skill Tests", "SELENIUM", "submitTest", "param4");
        }
        [Test,Order(2)]
        public void ResumeSkillTest()
        {
            submitSkillTestScenarios.Execute(driver, "Search for Skill Tests", "SELENIUM", "ResumeTest", "param4");
        }
        [OneTimeTearDown]
        public void Teardown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = "" + TestContext.CurrentContext.Result.StackTrace + "";
            var errorMessage = TestContext.CurrentContext.Result.Message;

            //if (status == TestStatus.Passed)
            //{
            //    test.Log(LogStatus.Pass, "SkillTest Module Test Execution - Passed");
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
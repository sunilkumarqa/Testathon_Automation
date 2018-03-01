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
    public class ContestParticipationTestCases
    {
        public ExtentReports extent;
        public ExtentTest test;
        public static IWebDriver driver = new ChromeDriver();
        CommonPageServices commonPageServices = new CommonPageServices();
        LoginPageServices loginServices = new LoginPageServices();
        SkillTestScenarios skillTestScenarios = new SkillTestScenarios();
        ContestParticipationScenario contestParticipationScenario = new ContestParticipationScenario();
        ContestParticipationServices contestParticipationServices = new ContestParticipationServices();
        [SetUp]
        public void TestFixtureSetupSteps(){
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string reportPath = projectPath + "Reports\\AutomationReport.html";
            extent = new ExtentReports(reportPath, false);
            //extent = new ExtentReports(reportPath, CultureInfo.GetCultureInfo("es-ES"), false, DisplayOrder.NewestFirst);
            extent
            .AddSystemInfo("Host Name", "Sunil")
            .AddSystemInfo("Environment", "QA")
            .AddSystemInfo("User Name", "Sunilqa");
            extent.LoadConfig(projectPath + "extent-config.xml");
            test = extent.StartTest("ContestParticipationTestCases");
            loginServices.Launch_Application(driver);
            loginServices.valid_Login(driver, "sksahoo543@gmail.com", "sunil123");
        }
        [Test, Order(1)]
        public void VerifyChallengePage()
        {
            test = extent.StartTest("VerifyChallengePage test");
            contestParticipationServices.verifyChallengesPage(driver, "Search for Challenges");
            // contestParticipationScenario.Execute(driver, "Search for Challenges", "param2", "param3", "param4");
        }
        [Test, Order(3)]
        public void SubmitChallenges()
        {
            test = extent.StartTest("SubmitChallenges test");
            contestParticipationScenario.Execute(driver, "Testing", "submitTest", "param3", "param4");
            test.Log(LogStatus.Info, "ContestParticipation passed");
        }
        [Test,Order(2)]
        public void ResumeChallenges()
        {
            test = extent.StartTest("ResumeChallenges test");
            contestParticipationScenario.Execute(driver, "Testing", "ResumeTest", "param3", "param4");
        }
        [OneTimeTearDown]
        public void Teardown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = "" + TestContext.CurrentContext.Result.StackTrace + "";
            var errorMessage = TestContext.CurrentContext.Result.Message;

            //if (status == TestStatus.Passed)
            //{
            //    test.Log(LogStatus.Pass, "Contest Participation Test Cases ----Passed");
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
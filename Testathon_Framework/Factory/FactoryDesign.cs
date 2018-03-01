using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testathon_Framework.TestScenarios;


namespace Testathon_Framework.Factory
{
    public class FactoryDesign
    {
        public ITestCase GetTestCase(TestModules testmodule)
        {
            if (testmodule == TestModules.Login)
            {
                return new LoginScenarios();
            }
            if (testmodule == TestModules.ApplyingJob)
            {
                return new ApplyingJobScenarios();
            }
            else if (testmodule == TestModules.All)
            {
                return new LoginScenarios();
                
            }
            return null;
        }
    }
}

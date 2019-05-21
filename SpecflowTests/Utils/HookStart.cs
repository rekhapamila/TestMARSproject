using TechTalk.SpecFlow;
using System.Threading;
using SpecflowPages;
using static SpecflowPages.CommonMethods;
using RelevantCodes.ExtentReports;
using static SpecflowPages.ConstantUtils;

namespace SpecflowTests.Utils
{
    [Binding]
    public sealed class HookStart : Driver
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

            [BeforeFeature]
            public static void BeforeFeature()
            {
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
        }
        [BeforeScenario(Order =0)]
        public void BeforeScenario()
        {
            //TODO: implement logic that has to run before executing each scenario
            Initialize();
            Thread.Sleep(500);
            //Call the Login Class            
            SpecflowPages.Utils.LoginPage.LoginStep();
            

        }

        [AfterScenario(Order =1)]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
            Thread.Sleep(500);
            // Screenshot
            //string img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");
            test.Log(LogStatus.Info, "Snapshot below: " + test.AddScreenCapture(imageFile));

            
            CommonMethods.extent.EndTest(CommonMethods.test);

            // calling Flush writes everything to the log file (Reports)
            
            

            //Close the browser
            Close();
        }
        [AfterFeature]
        public static void AfterFeature()
        {
            CommonMethods.extent.Flush();
        }
    }
}
